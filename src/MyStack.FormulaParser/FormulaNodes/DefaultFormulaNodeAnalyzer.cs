using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStack.FormulaParser.FormulaNodes
{
    public class DefaultFormulaNodeAnalyzer : IFormulaNodeAnalyzer
    {
        public DefaultFormulaNodeAnalyzer(IEnumerable<IFormulaNodeParser> nodeParsers)
        {
            NodeParsers = nodeParsers;
        }
        protected IEnumerable<IFormulaNodeParser> NodeParsers { get; set; }
        public List<FormulaNode> Analysis(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "输入的公式值不能为空。");
            var nodes = new List<FormulaNode>();
            var chars = input.AsSpan();
            for (int i = 0; i < chars.Length; i++)
            {
                foreach (var nodeParser in NodeParsers.OrderByDescending(x => x.Priority))
                {
                    if (nodeParser.Parse(chars, ref i, ref nodes))
                        break;
                }
            }
            return nodes;
        }
    }
}
