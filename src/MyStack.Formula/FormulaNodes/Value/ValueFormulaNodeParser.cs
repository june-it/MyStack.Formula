using System;
using System.Collections.Generic;

namespace MyStack.Formula.FormulaNodes.Value
{
    /// <summary>
    /// 值节点转换器实现
    /// </summary>
    public class ValueFormulaNodeParser : IFormulaNodeParser
    {
        public int Priority => 2;

        public bool Parse(CharacterList chars, ref List<FormulaNode> nodes)
        {
            var ch = Convert.ToChar(chars[0]);
            if (ch != '-' && !IsDigit(ch))
                return false;

            double value = 0;
            var flag = false;
            // 是否为负数
            var isNegativeNumber = ch.Equals('-');
            // 负数时将索引下标后移一位
            var localIndex = isNegativeNumber ? 1 : 0;
            // 循环检查数值的字符
            for (int i = localIndex; i < chars.Count; i++)
            {
                ch = Convert.ToChar(chars[i]);
                if (IsDigit(ch))
                {
                    // 如果检查为数字且索引为最后一位时，则转换字符串并返回数值  
                    if (i == chars.Count - 1 && double.TryParse(chars.GetString(), out value))
                    {
                        chars.Clear();
                        flag = true;
                        break;
                    }
                }
                // 当出现非数值时，进行字符串转换数值
                else if (double.TryParse(chars.GetRangeString(0, i), out value))
                {
                    chars.RemoveRange(0, i);
                    flag = true;
                    break;
                }
                else
                    break;
            }
            if (flag)
            {
                nodes.Add(new ValueNode(value));
            }
            return flag;
        }
        public static bool IsDigit(char ch)
        {
            return char.IsDigit(ch) || ch == '.';
        }
    }
}
