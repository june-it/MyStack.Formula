using System;
using System.Xml.Linq;

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
        /// <summary>
        /// 获取计算后的值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public double Calculate(double x, double y)
        {
            return OperatorType switch
            {
                OperatorType.Multiply => x * y,
                OperatorType.Divide => x / y,
                OperatorType.Plus => x + y,
                OperatorType.Minus => x - y,
                OperatorType.Pow => Math.Pow(x, y),
                _ => throw new InvalidOperationException("不支持的操作符类型。")
            };
        }
        /// <summary>
        /// 获取三角函数计算后的值
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public double Calculate(double x)
        {
            return OperatorType switch
            {
                OperatorType.Sin => Math.Sin(x),
                OperatorType.Cos => Math.Cos(x),
                OperatorType.Tan => Math.Tan(x),
                OperatorType.Cot => 1.0 / Math.Tan(x),
                _ => throw new InvalidOperationException("不支持的操作符类型。")
            };
        }
        
    }
}
