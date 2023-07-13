using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using LayerTemplateEdited.Business.Abstract;
using LayerTemplateEdited.Business.Concrete;
using LayerTemplateEdited.Core.Utilities.Interceptors;
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

			builder.RegisterType<TemporaryDal>().As<ITemporaryDal>().SingleInstance();
			builder.RegisterType<TemporaryCategoryDal>().As<ITemporaryCategoryDal>().SingleInstance();



			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();

		}
	}
} 