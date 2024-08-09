namespace MyStack.FormulaParser.FormulaNodes.Operator
{
    /// <summary>
    /// 表示操作符节点
    /// </summary>
    public class OperatorNode : FormulaNode
    {
        /// <summary>
        /// 初始化一个操作符节点对象
        /// </summary>
        /// <param name="operatorType">操作符类型</param>
        public OperatorNode(OperatorType operatorType) : base(NodeType.Operator)
        {
            OperatorType = operatorType;
        }
        /// <summary>
        /// 获取操作符类型
        /// </summary>
        public OperatorType OperatorType { get; }
        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority
        {
            get
            {
                return OperatorType switch
                {
                    OperatorType.Pow => 6,
                    OperatorType.Multiply => 5,
                    OperatorType.Divide => 5,
                    OperatorType.Plus => 4,
                    OperatorType.Minus => 4,
                    _ => 0
                };
            }
        }
    }
}
