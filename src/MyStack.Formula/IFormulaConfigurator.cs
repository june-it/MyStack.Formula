using Microsoft.Extensions.DependencyInjection;

namespace MyStack.Formula
{
    public interface IFormulaConfigurator
    {
        IServiceCollection Services { get; }

        void UseConfigurationIdValue();
    }
}
