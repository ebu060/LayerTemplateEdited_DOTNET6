using Microsoft.Extensions.DependencyInjection;

namespace LayerTemplateEdited.Core.Utilities.IoC
{
    public  interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
