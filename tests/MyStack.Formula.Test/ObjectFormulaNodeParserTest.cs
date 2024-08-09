using Microsoft.Extensions.DependencyInjection;
using MyStack.Formula.FormulaNodes;
using MyStack.Formula.FormulaNodes.Value;

namespace MyStack.Formula.Test
{
    public class ObjectFormulaNodeParserTest : TestBase
    {
        [Test]
        public void Test_From_Number()
        {
            var nodeParser = ServiceProvider.GetRequiredService<ObjectFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            //<1>的值10
            CharacterList chars = new CharacterList("<1>".ToCharArray());
            var result = nodeParser.Parse(chars, ref nodes);
            Assert.IsTrue(result);
        }

    }
}
