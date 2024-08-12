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
        public void Test_From_Formula_FirstBracket()
        {
            var formulaEngine = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaEngine.Calculate("(2+1)*2+1");
            Assert.That(actualValue, Is.EqualTo(7));
        }
        [Test]
        public void Test_From_Formula_LastBracket()
        {
            var formulaEngine = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaEngine.Calculate("1+(2+1)*2");
            Assert.That(actualValue, Is.EqualTo(7));
        }
        [Test]
        public void Test_From_Formula_Complex()
        {
            var formulaEngine = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaEngine.Calculate("3+4*2/(1-5)^2^3+2*(2+1)");
            Assert.That(actualValue, Is.EqualTo(9.001953125));
        }
        [Test]
        public void Test_From_Formula_Complex_TrigonometricFunctions()
        {
            var formulaEngine = ServiceProvider.GetRequiredService<FormulaEngine>();
            var actualValue = formulaEngine.Calculate("COS(900-3*10*30)+123.45+30*30-0.45+TAN(0)");
            Assert.That(actualValue, Is.EqualTo(1024));
        }

        
    }
}