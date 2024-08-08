using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyStack.FormulaParser.Test
{
    public class Tests
    {


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_Plus()
        {
            var services = new ServiceCollection();
            services.AddFormulaParser();
            var serviceProvider = services.BuildServiceProvider();
            var formulaAnalyzer = serviceProvider.GetRequiredService<FormulaAnalyzer>();
            var actualValue = formulaAnalyzer.Calculation("1+1");
            Assert.That(actualValue, Is.EqualTo(2));
        }
        [Test]
        public void Test_NegativeNumber_Plus()
        {
            var services = new ServiceCollection();
            services.AddFormulaParser();
            var serviceProvider = services.BuildServiceProvider();
            var formulaAnalyzer = serviceProvider.GetRequiredService<FormulaAnalyzer>();
            var actualValue = formulaAnalyzer.Calculation("-1+1");
            Assert.That(actualValue, Is.EqualTo(0));
        }
        [Test]
        public void Test_Plus_Multiply()
        {
            var services = new ServiceCollection();
            services.AddFormulaParser();
            var serviceProvider = services.BuildServiceProvider();
            var formulaAnalyzer = serviceProvider.GetRequiredService<FormulaAnalyzer>();
            var actualValue = formulaAnalyzer.Calculation("(1+1)*2");
            Assert.That(actualValue, Is.EqualTo(4));
        }
    }
}