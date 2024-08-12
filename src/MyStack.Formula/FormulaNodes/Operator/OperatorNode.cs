namespace MyStack.Formula.FormulaNodes.Operator
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
        /// 获取优先级
        /// </summary>
        public int Priority
        {
            get
            {
                return OperatorType switch
                {
                    OperatorType.Sin => 4,
                    OperatorType.Cos => 4,
                    OperatorType.Tan => 4,
                    OperatorType.Cot => 4,
                    OperatorType.Pow => 3,
                    OperatorType.Multiply => 2,
                    OperatorType.Divide => 2,
                    OperatorType.Plus => 1,
                    OperatorType.Minus => 1,
                    _ => 0
                };
            }
        }
        /// <summary>
        /// 获取是否为三角函数
        /// </summary>
        public bool IsTrigonometricFunction
        {
            get
            {
                return OperatorType switch
                {
                    OperatorType.Sin => true,
                    OperatorType.Cos => true,
                    OperatorType.Tan => true,
                    OperatorType.Cot => true,
                    _ => false
                };
            }
        }

        public override string ToString()
        {
            return OperatorType switch
            {
                OperatorType.Pow => "^",
                OperatorType.Multiply => "*",
                OperatorType.Divide => "/",
                OperatorType.Plus => "+",
                OperatorType.Minus => "-",
                _ => OperatorType.ToString().ToUpper()
            };
        }
    }
}
