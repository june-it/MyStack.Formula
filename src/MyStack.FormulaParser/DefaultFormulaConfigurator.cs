using Microsoft.Extensions.DependencyInjection;
using MyStack.FormulaParser.Numbers;

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
            Services.AddTransient<IIdValueProvider, ConfigurationIdValueProvider>();
        }
    }
}
