using LayerTemplateEdited.Core.CrossCuttingConcerns.Caching;
using LayerTemplateEdited.Core.CrossCuttingConcerns.Caching.Microsoft;
using LayerTemplateEdited.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LayerTemplateEdited.Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
