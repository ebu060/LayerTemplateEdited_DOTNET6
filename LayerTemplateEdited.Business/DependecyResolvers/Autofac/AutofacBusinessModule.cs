using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using LayerTemplateEdited.Business.Abstract;
using LayerTemplateEdited.Business.Concrete;
using LayerTemplateEdited.Core.Utilities.Interceptors;
using LayerTemplateEdited.Core.Utilities.Security.JWT;
using LayerTemplateEdited.DataAccess.Abstract;
using LayerTemplateEdited.DataAccess.Concrete.EntityFramework;

namespace LayerTemplateEdited.Business.DependecyResolvers.Autofac
{
	public class AutofacBusinessModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<TemporaryManager>().As<ITemporaryService>().SingleInstance();
			builder.RegisterType<TemporaryCategoryManager>().As<ITemporaryCategoryService>().SingleInstance();
			builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
			builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
			builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();



			builder.RegisterType<TemporaryDal>().As<ITemporaryDal>().SingleInstance();
			builder.RegisterType<TemporaryCategoryDal>().As<ITemporaryCategoryDal>().SingleInstance();
			builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();
	



			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();

		}
	}
} 