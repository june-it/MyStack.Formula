using System;
using System.Collections.Generic;

namespace MyStack.FormulaParser.FormulaNodes.Bracket
{
    public class BracketFormulaNodeParser : IFormulaNodeParser
    {
        public int Priority => 2;
        protected char LeftBracket = '(';
        protected char RightBracket = ')';
        public virtual bool Parse(ReadOnlySpan<char> chars, ref int index, ref List<FormulaNode> nodes)
        {
            if (chars[index].Equals(LeftBracket))
            {
                nodes.Add(new BracketNode(BracketType.Left));
                return true;
            }
            else if (chars[index].Equals(RightBracket))
            {
                nodes.Add(new BracketNode(BracketType.Right));
                return true;
            }
            return false;
        }
    }
}
