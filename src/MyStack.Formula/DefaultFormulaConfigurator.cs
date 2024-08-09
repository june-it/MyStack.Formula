using Microsoft.Extensions.DependencyInjection;
using MyStack.Formula.FormulaNodes.Value;

namespace MyStack.Formula
{
    public class DefaultFormulaConfigurator : IFormulaConfigurator
    {
        public IServiceCollection Services { get; }
        public DefaultFormulaConfigurator(IServiceCollection services)
        {
            Services = services;
        }
        public void UseConfigurationIdValue()
        {
            Services.AddTransient<IObjectDataProvider, ConfigurationObjectDataProvider>();
        }
    }
}
