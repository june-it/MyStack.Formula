using Microsoft.Extensions.DependencyInjection;
using MyStack.Formula.FormulaNodes;

namespace MyStack.Formula.Test
{
    public class RPNTest : TestBase
    {
        [Test]
        public void Test()
        {
            var formulaNodeAnalyzer = ServiceProvider.GetRequiredService<IFormulaNodeAnalyzer>();
            var rpnCalculator = ServiceProvider.GetRequiredService<IRpnCalculator>();
            var nodes = formulaNodeAnalyzer.Analysis("3+4*2/(1-5)^2^3+2*(2+1)");
            var rpnNodes = rpnCalculator.Preprocessing(nodes);

            var formula1 = nodes.ToFormulaString();
            var formula2 = rpnNodes.ToFormulaString();

            Assert.Pass();
        }
    }
}
