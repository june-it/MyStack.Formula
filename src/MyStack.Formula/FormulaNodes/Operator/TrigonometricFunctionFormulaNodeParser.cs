using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStack.Formula.FormulaNodes.Operator
{
    public class TrigonometricFunctionFormulaNodeParser : IFormulaNodeParser
    {
        public int Priority => 3;
        /// <summary>
        /// 三角函数运算符
        /// </summary>
        protected string[] TrigonometricFunctions = new[] { "SIN", "COS", "TAN", "COT", "SEC", "CSC" };
        public bool Parse(CharacterList chars, ref List<FormulaNode> nodes)
        {
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
                _ => throw new InvalidOperationException("不支持的操作符")
            };
        }
    }
}
