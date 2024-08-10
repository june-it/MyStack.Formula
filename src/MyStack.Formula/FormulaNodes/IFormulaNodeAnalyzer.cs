using System.Collections.Generic;

namespace MyStack.Formula.FormulaNodes
{
    /// <summary>
    /// 表示公式解析器接口
    /// </summary>
    public interface IFormulaNodeAnalyzer
    {
        /// <summary>
        /// 返回解析的公式节点列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        List<FormulaNode> Analysis(string input);
    }
}
