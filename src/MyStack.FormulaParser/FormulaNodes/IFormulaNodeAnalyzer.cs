using System.Collections.Generic;

namespace MyStack.FormulaParser.FormulaNodes
{
    public interface IFormulaNodeAnalyzer
    {
        List<FormulaNode> Analysis(string input);
    }
}
