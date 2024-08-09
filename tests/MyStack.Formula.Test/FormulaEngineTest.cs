using Microsoft.Extensions.DependencyInjection;

namespace MyStack.Formula.Test
{
    public class FormulaEngineTest : TestBase
    {

        [Test]
        public void Test_Plus()
        {
            var formulaEngine = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaEngine.Calculate("1+1");
            Assert.That(actualValue, Is.EqualTo(2));
        }
        [Test]
        public void Test_NegativeNumber_Plus()
        {
            var formulaEngine = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaEngine.Calculate("-1+1");
            Assert.That(actualValue, Is.EqualTo(0));
        }
        [Test]
        public void Test_Plus_Multiply()
        {
            var formulaEngine = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaEngine.Calculate("2*(1+1)");
            Assert.That(actualValue, Is.EqualTo(4));
        }

        [Test]
        public void Test_Object_From_Value()
        {
            var formulaEngine = ServiceProvider.GetRequiredService<FormulaEngine>();
            // <1>=1
            var actualValue = formulaEngine.Calculate("(1+<1>)*2");
            Assert.That(actualValue, Is.EqualTo(4));
        }

        [Test]
        public void Test_Object_From_Formula()
        {
            var formulaEngine = ServiceProvider.GetRequiredService<FormulaEngine>();
            // <2>=(2+1)*2
            var actualValue = formulaEngine.Calculate("1+<2>");
            Assert.That(actualValue, Is.EqualTo(7));
        }
        [Test]
        public void Test_From_Formula()
        {
            var formulaEngine = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaEngine.Calculate("1+(2+1)*2");
            Assert.That(actualValue, Is.EqualTo(7));
        }
    }
}