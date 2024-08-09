using Microsoft.Extensions.DependencyInjection;
using MyStack.FormulaParser.FormulaNodes.Value;

namespace MyStack.FormulaParser
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
