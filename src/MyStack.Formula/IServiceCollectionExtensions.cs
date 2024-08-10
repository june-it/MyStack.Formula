using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyStack.Formula.FormulaNodes;
using MyStack.Formula.FormulaNodes.Bracket;
using MyStack.Formula.FormulaNodes.Operator;
using MyStack.Formula.FormulaNodes.Value;
using System;

namespace MyStack.Formula
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// 添加公式
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection AddFormula(this IServiceCollection services, IConfiguration configuration, Action<IFormulaConfigurator>? configure = null)
        {

            services.AddTransient<FormulaEngine>();
            services.AddTransient<IFormulaNodeAnalyzer, DefaultFormulaNodeAnalyzer>();
            services.AddTransient<IRpnCalculator, DefaultRpnCalculator>();
            services.AddTransient<IFormulaNodeParser, BracketFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, OperatorFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, NumberFormulaNodeParser>();
            services.AddTransient<IFormulaNodeParser, ObjectFormulaNodeParser>();
#if DEBUG
            // 用于单元测试
            services.AddTransient<BracketFormulaNodeParser>();
            services.AddTransient<OperatorFormulaNodeParser>();
            services.AddTransient<NumberFormulaNodeParser>();
            services.AddTransient<ObjectFormulaNodeParser>();
#endif

            var configurator = new DefaultFormulaConfigurator(services);
            configure?.Invoke(configurator);

            services.Configure<FormulaParserOptions>(configuration.GetSection("MyStack.Formula"));
            return services;
        }
    }
}
