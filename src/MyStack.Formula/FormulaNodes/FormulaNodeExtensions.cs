using System.Collections.Generic;
using System.Linq;

namespace MyStack.Formula.FormulaNodes
{
    public static class FormulaNodeExtensions
    {
        public static string ToFormulaString(this List<FormulaNode> nodes)
        {
            return string.Join(",", nodes.Select(x => x.ToString()));
        }
    }
}
