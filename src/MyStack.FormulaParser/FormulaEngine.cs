using MyStack.FormulaParser.FormulaNodes;

namespace MyStack.FormulaParser
{
    public class FormulaEngine
    {
        protected IFormulaNodeAnalyzer NodeAnalyzer { get; }
        protected IRpnCalculator RpnCalculator { get; }
        public FormulaEngine(IFormulaNodeAnalyzer nodeAnalyzer,
            IRpnCalculator rpnCalculator)
        {
            NodeAnalyzer = nodeAnalyzer;
            RpnCalculator = rpnCalculator;
        }
        public double Calculate(string input)
        {
            if (input == null) throw new System.ArgumentNullException(nameof(input));
            var nodes = NodeAnalyzer.Analysis(input);
            var rpnNodes = RpnCalculator.Preprocessing(nodes);
            return RpnCalculator.Calculate(rpnNodes);
        }
    }
}
