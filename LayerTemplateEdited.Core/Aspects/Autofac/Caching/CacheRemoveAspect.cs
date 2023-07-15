using Castle.DynamicProxy;
using LayerTemplateEdited.Core.CrossCuttingConcerns.Caching;
using LayerTemplateEdited.Core.Utilities.Interceptors;
using LayerTemplateEdited.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace LayerTemplateEdited.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
