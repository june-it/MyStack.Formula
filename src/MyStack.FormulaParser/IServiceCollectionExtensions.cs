using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyStack.FormulaParser.FormulaNodes;
using MyStack.FormulaParser.FormulaNodes.Bracket;
using MyStack.FormulaParser.FormulaNodes.Operator;
using MyStack.FormulaParser.FormulaNodes.Value;
using System;

namespace MyStack.FormulaParser
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddFormulaParser(this IServiceCollection services, IConfiguration configuration, Action<IFormulaConfigurator>? configure = null)
        {

            services.AddTransient<FormulaEngine>();
            services.AddTransient<IFormulaNodeAnalyzer, DefaultFormulaNodeAnalyzer>();
            services.AddTransient<IRpnCalculator, DefaultRpnCalculator>();
            services.AddTransient<IFormulaNodeParser, BracketFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, OperatorFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, NumberFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, ObjectFormulaNodeParser>();
            services.AddTransient<ObjectFormulaNodeParser>();

            var configurator = new DefaultFormulaConfigurator(services);
            configure?.Invoke(configurator);

            services.Configure<FormulaParserOptions>(configuration.GetSection("MyStack.FormulaParser"));
            return services;
        }
    }
}
