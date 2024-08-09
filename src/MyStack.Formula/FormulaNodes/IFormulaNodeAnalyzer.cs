using System.Collections.Generic;

namespace MyStack.Formula.FormulaNodes
{
    public interface IFormulaNodeAnalyzer
    {
        List<FormulaNode> Analysis(string input);
    }
}
