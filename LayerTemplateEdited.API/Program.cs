using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LayerTemplateEdited.API.Middleware;
using LayerTemplateEdited.Business.DependecyResolvers.Autofac;
using LayerTemplateEdited.Core.DependencyResolver;
using LayerTemplateEdited.Core.Extensions;
using LayerTemplateEdited.Core.Utilities.IoC;
using LayerTemplateEdited.Core.Utilities.Security.Encryption;
using LayerTemplateEdited.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
builder.Host.UseMetricsWebTracking().UseMetrics(options =>
{
	options.EndpointOptions = endpointOptions =>
	{
		endpointOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
		endpointOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
		endpointOptions.EnvironmentInfoEndpointEnabled = false;
	};
});


// Add services to the container.
builder.Services.AddMetrics();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidIssuer = tokenOptions.Issuer,
			ValidAudience = tokenOptions.Audience,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
		};
	});

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
	new CoreModule()
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseHttpMetrics();

app.UseMiddleware<MetricMiddleware>();

app.UseMetricServer();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
 

