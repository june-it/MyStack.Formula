namespace MyStack.Formula.FormulaNodes
{
    /// <summary>
    /// 表示公式节点
    /// </summary>
    public class FormulaNode
    {
        /// <summary>
        /// 初始化一个公式节点
        /// </summary>
        /// <param name="nodeType">节点类型</param>
        public FormulaNode(NodeType nodeType)
        {
            NodeType = nodeType;
        }
        /// <summary>
        /// 获取节点类型
        /// </summary>
        public NodeType NodeType { get; }
    }
}
