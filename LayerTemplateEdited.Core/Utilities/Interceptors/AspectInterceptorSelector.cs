using Castle.DynamicProxy;
using LayerTemplateEdited.Core.Aspects.Autofac.Exception;
using LayerTemplateEdited.Core.Aspects.Autofac.Performance;
using LayerTemplateEdited.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.Reflection;

namespace LayerTemplateEdited.Core.Utilities.Interceptors
{
	public class AspectInterceptorSelector : IInterceptorSelector
	{
		public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
		{
			var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
				(true).ToList();
			var methodAttributes = type.GetMethod(method.Name)
				.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
			classAttributes.AddRange(methodAttributes);

            //TÜM METODLARDAKI HATALARI LOGLAR
            classAttributes.Add(new ExceptionLogAspect(typeof(DatabaseExceptionLogger)));
            //TÜM METODLARA PERFORMANS LOGU EKLER
            classAttributes.Add(new PerformanceAspect(5,typeof(DatabasePerformanceLogger)));

			return classAttributes.OrderBy(x => x.Priority).ToArray();
		}
	}
}
