using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStack.Formula.FormulaNodes
{
    /// <summary>
    /// 实现默认的公式解析器
    /// </summary>
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

            CharacterList chars = new CharacterList(input.ToCharArray());
            while (chars.Count > 0)
            {
                foreach (var nodeParser in NodeParsers.OrderByDescending(x => x.Priority))
                {
                    if (nodeParser.Parse(chars, ref nodes))
                        break;
                }
            }

            return nodes;
        }
    }
}
