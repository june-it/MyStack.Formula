using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStack.Formula.FormulaNodes.Operator
{
    public class OperatorFormulaNodeParser : IFormulaNodeParser
    {
        public int Priority => 3;
        /// <summary>
        /// 一般运算符
        /// </summary>
        protected char[] Operators = new[] { '+', '-', '*', '/', '^' };
        /// <summary>
        /// 三角函数运算符
        /// </summary>
        protected string[] TrigonometricFunctions = new[] { "SIN", "COS", "TAN", "COT", "SEC", "CSC" };
        public virtual bool Parse(CharacterList chars, ref List<FormulaNode> nodes)
        {
            var ch = chars[0];
            if (Operators.Contains(Convert.ToChar(chars[0])))
            {
                if (chars.Count != 1 && nodes.Count == 0)
                    return false;
                nodes.Add(new OperatorNode(GetOperatorType(chars[0].ToString())));
                chars.Remove(ch);
                return true;
            }
            if (chars.Count > 3)
            {
                var threeChars = chars.GetRangeString(0, 3).ToUpper();
                if (TrigonometricFunctions.Contains(threeChars))
                {
                    nodes.Add(new OperatorNode(GetOperatorType(threeChars)));
                    chars.RemoveRange(0, 3);
                    return true;
                }
            }
            return false;
        }
        protected virtual OperatorType GetOperatorType(string @operator)
        {
            return @operator switch
            {
                "SIN" => OperatorType.Sin,
                "COS" => OperatorType.Cos,
                "TAN" => OperatorType.Sin,
                "COT" => OperatorType.Cot,
                "+" => OperatorType.Plus,
                "-" => OperatorType.Minus,
                "*" => OperatorType.Multiply,
                "/" => OperatorType.Divide,
                "^" => OperatorType.Pow,
                _ => throw new InvalidOperationException("不支持的操作符")
            };
        }
    }
}
