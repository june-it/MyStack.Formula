using Microsoft.Extensions.DependencyInjection;

namespace MyStack.FormulaParser
{
    public interface IFormulaConfigurator
    {
        IServiceCollection Services { get; }

        void UseConfigurationIdValue();
    }
}
