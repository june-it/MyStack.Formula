using Microsoft.Extensions.DependencyInjection;
using MyStack.Formula.FormulaNodes;
using MyStack.Formula.FormulaNodes.Operator;

namespace MyStack.Formula.Test
{
    public class OperatorFormulaNodeParserTest : TestBase
    {
        [Test]
        public void Test_Plus()
        {
            var nodeParser = ServiceProvider.GetRequiredService<OperatorFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("+".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Minus()
        {
            var nodeParser = ServiceProvider.GetRequiredService<OperatorFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("-".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Multiply()
        {
            var nodeParser = ServiceProvider.GetRequiredService<OperatorFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("*".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Divide()
        {
            var nodeParser = ServiceProvider.GetRequiredService<OperatorFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("/".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Sin()
        {
            var nodeParser = ServiceProvider.GetRequiredService<OperatorFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("Sin(1)".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Cos()
        {
            var nodeParser = ServiceProvider.GetRequiredService<OperatorFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("Cos(1)".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Tan()
        {
            var nodeParser = ServiceProvider.GetRequiredService<OperatorFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("TAN(1)".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Cot()
        {
            var nodeParser = ServiceProvider.GetRequiredService<OperatorFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("Cot(1)".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Sec()
        {
            var nodeParser = ServiceProvider.GetRequiredService<OperatorFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("sec(1)".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Csc()
        {
            var nodeParser = ServiceProvider.GetRequiredService<OperatorFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("csc(1)".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
    }
}
