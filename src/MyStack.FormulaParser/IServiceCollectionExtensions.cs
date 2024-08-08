using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyStack.FormulaParser.Brackets;
using MyStack.FormulaParser.Numbers;
using MyStack.FormulaParser.Operators;
using System;

namespace MyStack.FormulaParser
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddFormulaParser(this IServiceCollection services, IConfiguration configuration, Action<IFormulaConfigurator>? configure = null)
        {
            services.AddTransient<FormulaAnalyzer>();
            services.AddTransient<IFormulaNodeParser, BracketFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, OperatorFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, NumberFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, IdFormulaNodeParser>();
            services.AddTransient<IdFormulaNodeParser>();

            var configurator = new DefaultFormulaConfigurator(services);
            configure?.Invoke(configurator);

            services.Configure<FormulaParserOptions>(configuration.GetSection("MyStack.FormulaParser"));
            return services;
        }
    }
}
