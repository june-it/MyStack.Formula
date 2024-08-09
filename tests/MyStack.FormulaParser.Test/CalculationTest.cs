using Microsoft.Extensions.DependencyInjection;

namespace MyStack.FormulaParser.Test
{
    public class CalculationTest : TestBase
    {


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_Plus()
        {
            var formulaAnalyzer = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaAnalyzer.Calculate("1+1");
            Assert.That(actualValue, Is.EqualTo(2));
        }
        [Test]
        public void Test_NegativeNumber_Plus()
        {
            var formulaAnalyzer = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaAnalyzer.Calculate("-1+1");
            Assert.That(actualValue, Is.EqualTo(0));
        }
        [Test]
        public void Test_Plus_Multiply()
        {
            var formulaAnalyzer = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaAnalyzer.Calculate("2*(1+1)");
            Assert.That(actualValue, Is.EqualTo(4));
        }

        [Test]
        public void Test_Id()
        {
            var formulaAnalyzer = ServiceProvider.GetRequiredService<FormulaEngine>();
            // <1>=10
            var actualValue = formulaAnalyzer.Calculate("(1+<1>)*2");
            Assert.That(actualValue, Is.EqualTo(22));
        }
    }
}