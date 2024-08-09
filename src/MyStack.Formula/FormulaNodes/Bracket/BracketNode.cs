namespace MyStack.Formula.FormulaNodes.Bracket
{
    /// <summary>
    /// 表示圆括号节点
    /// </summary>
    public class BracketNode : FormulaNode
    {
        /// <summary>
        /// 初始化一个圆括号节点对象
        /// </summary>
        /// <param name="bracketType">括号类型</param>
        public BracketNode(BracketType bracketType) : base(NodeType.Bracket)
        {
            BracketType = bracketType;
        }
        /// <summary>
        /// 获取括号的类型
        /// </summary>
        public BracketType BracketType { get; }
    }
}
