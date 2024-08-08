using Microsoft.Extensions.DependencyInjection;
using MyStack.FormulaParser.Numbers;

namespace MyStack.FormulaParser.Test
{
    public class FormulaNodeParserTest : TestBase
    {
        [Test]
        public void TestId()
        {
            var idFormulaNodeParser = ServiceProvider.GetRequiredService<IdFormulaNodeParser>();
            var nodes = new List<FormulaNode>();
            var chars = "1+<1>".AsSpan();
            var result = false;
            for (int i = 0; i < chars.Length; i++)
            {
                result = idFormulaNodeParser.Parse("123<1>abc", ref i, ref nodes);
            }
            Assert.IsTrue(result);
        }
    }
}
