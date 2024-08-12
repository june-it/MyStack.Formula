namespace MyStack.Formula.FormulaNodes.Value
{
    /// <summary>
    /// 表示数值节点
    /// </summary>
    public class ValueNode : FormulaNode
    {
        /// <summary>
        /// 初始化一个数值节点对象
        /// </summary>
        /// <param name="value">数值</param>
        public ValueNode(double value) : base(NodeType.Value)
        {
            Value = value;
        }
        /// <summary>
        /// 获取数值
        /// </summary>
        public double Value { get; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
