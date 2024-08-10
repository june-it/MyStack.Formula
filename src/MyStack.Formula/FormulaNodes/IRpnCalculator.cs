using System.Collections.Generic;

namespace MyStack.Formula.FormulaNodes
{
    /// <summary>
    /// 表示逆波兰式（Reverse Polish Notation，RPN，或逆波兰记法）接口
    /// </summary>
    public interface IRpnCalculator
    {
        /// <summary>
        /// 返回后缀表达式处理后的公式节点列表
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        List<FormulaNode> Preprocessing(List<FormulaNode> nodes);
        /// <summary>
        /// 计算后缀表达式结果
        /// </summary>
        /// <param name="rpnNodes"></param>
        /// <returns></returns>
        double Calculate(List<FormulaNode> rpnNodes);
    }

}
