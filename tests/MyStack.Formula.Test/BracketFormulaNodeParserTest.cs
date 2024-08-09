using Microsoft.Extensions.DependencyInjection;
using MyStack.Formula.FormulaNodes;
using MyStack.Formula.FormulaNodes.Bracket;

namespace MyStack.Formula.Test
{
    public class BracketFormulaNodeParserTest : TestBase
    {
        [Test]
        public void Test_Left()
        {
            var nodeParser = ServiceProvider.GetRequiredService<BracketFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList("(".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Right()
        {
            var nodeParser = ServiceProvider.GetRequiredService<BracketFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            CharacterList chars = new CharacterList(")".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }
    }
}
