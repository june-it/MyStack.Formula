using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStack.FormulaParser.Operators
{
    public class OperatorFormulaNodeParser : IFormulaNodeParser
    {
        public int Priority => 1;
        protected char[] Operators = new[] { '+', '-', '*', '/', '^' };
        public virtual bool Parse(ReadOnlySpan<char> chars, ref int index, ref List<FormulaNode> nodes)
        {
            if (Operators.Contains(chars[index]))
            {
                nodes.Add(new OperatorNode(GetOperatorType(chars[index].ToString())));
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
