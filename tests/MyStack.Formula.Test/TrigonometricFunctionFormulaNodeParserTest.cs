using Microsoft.Extensions.DependencyInjection;
using MyStack.Formula.FormulaNodes;
using MyStack.Formula.FormulaNodes.Operator;

namespace MyStack.Formula.Test
{
    public class TrigonometricFunctionFormulaNodeParserTest : TestBase
    {
        [Test]
        public void Test_Sin()
        {
            var nodeParser = ServiceProvider.GetRequiredService<TrigonometricFunctionFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("Sin(1)".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Cos()
        {
            var nodeParser = ServiceProvider.GetRequiredService<TrigonometricFunctionFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("Cos(1)".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Tan()
        {
            var nodeParser = ServiceProvider.GetRequiredService<TrigonometricFunctionFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("TAN(1)".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Cot()
        {
            var nodeParser = ServiceProvider.GetRequiredService<TrigonometricFunctionFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("Cot(1)".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
         
    }
}
