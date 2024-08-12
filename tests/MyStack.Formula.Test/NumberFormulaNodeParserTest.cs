using Microsoft.Extensions.DependencyInjection;
using MyStack.Formula.FormulaNodes;
using MyStack.Formula.FormulaNodes.Value;

namespace MyStack.Formula.Test
{
    public class NumberFormulaNodeParserTest : TestBase
    {
        [Test]
        public void Test()
        {
            var nodeParser = ServiceProvider.GetRequiredService<ValueFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("1+".ToCharArray());
            nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(nodes.Count == 1);
        }
        [Test]
        public void Test_Integer()
        {
            var nodeParser = ServiceProvider.GetRequiredService<ValueFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("12345".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Float()
        {
            var nodeParser = ServiceProvider.GetRequiredService<ValueFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("12345.234".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Negative()
        {
            var nodeParser = ServiceProvider.GetRequiredService<ValueFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("-12345.234".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }

    }
}
