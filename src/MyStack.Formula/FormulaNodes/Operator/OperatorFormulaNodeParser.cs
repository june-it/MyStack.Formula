using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStack.Formula.FormulaNodes.Operator
{
    public class OperatorFormulaNodeParser : IFormulaNodeParser
    {
        public int Priority => 3;
        protected char[] Operators = new[] { '+', '-', '*', '/', '^' };
        public virtual bool Parse(CharacterList chars, ref List<FormulaNode> nodes)
        {
            var ch = chars[0];
            if (Operators.Contains(Convert.ToChar(chars[0])))
            {
                nodes.Add(new OperatorNode(GetOperatorType(chars[0].ToString())));
                chars.Remove(ch);
                return true;
            }
            return false;
        }
        protected virtual OperatorType GetOperatorType(string @operator)
        {
            return @operator switch
            {
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
