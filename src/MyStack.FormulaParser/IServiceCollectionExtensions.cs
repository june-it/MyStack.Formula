using Microsoft.Extensions.DependencyInjection;
using MyStack.FormulaParser.Brackets;
using MyStack.FormulaParser.Numbers;
using MyStack.FormulaParser.Operators;

namespace MyStack.FormulaParser
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddFormulaParser(this IServiceCollection services)
        {
            services.AddTransient<FormulaAnalyzer>();
            services.AddTransient<IFormulaNodeParser, BracketFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, OperatorFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, NumberFormulaNodeParser>();
            return services;
        }
    }
}
