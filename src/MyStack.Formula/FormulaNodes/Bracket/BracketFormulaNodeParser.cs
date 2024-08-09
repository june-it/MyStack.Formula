using System.Collections.Generic;

namespace MyStack.Formula.FormulaNodes.Bracket
{
    public class BracketFormulaNodeParser : IFormulaNodeParser
    {
        public int Priority => 2;
        protected char LeftBracket = '(';
        protected char RightBracket = ')';
        public virtual bool Parse(CharacterList chars, ref List<FormulaNode> nodes)
        {
            var ch = chars[0];
            if (ch.Equals(LeftBracket))
            {
                chars.Remove(ch);
                nodes.Add(new BracketNode(BracketType.Left));
                return true;
            }
            else if (ch.Equals(RightBracket))
            {
                chars.Remove(ch);
                nodes.Add(new BracketNode(BracketType.Right));
                return true;
            }
            return false;
        }
    }
}
