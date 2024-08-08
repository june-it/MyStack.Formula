using System;
using System.Collections.Generic;

namespace MyStack.FormulaParser.Numbers
{
    /// <summary>
    /// 数值节点转换器实现
    /// </summary>
    public class NumberFormulaNodeParser : IFormulaNodeParser
    {
        public int Priority => 99;
        public bool Parse(ReadOnlySpan<char> chars, ref int index, ref List<FormulaNode> nodes)
        {
            double value = 0;
            var flag = false;
            // 是否为负数
            var isNegativeNumber = chars[index] == '-';
            // 负数时将索引下标后移一位
            var localIndex = isNegativeNumber ? index + 1 : index;
            // 循环检查数值的字符
            for (int i = localIndex; i < chars.Length; i++)
            {
                var ch = chars[i];
                if (IsDigit(ch))
                {
                    // 如果检查为数字且索引为最后一位时，则转换字符串并返回数值
                    if (i == chars.Length - 1 && double.TryParse(chars.Slice(index, chars.Length - i), out value))
                    {
                        index = i;
                        flag = true;
                        break;
                    }
                }
                // 当出现非数值时，进行字符串转换数值
                else if (double.TryParse(chars.Slice(index, i - index), out value))
                {
                    index = i - 1;
                    flag = true;
                    break;
                }
                else
                    break;
            }
            if (flag)
            {
                nodes.Add(new NumberNode(value));
            }
            return flag;
        }
        public static bool IsDigit(char ch)
        {
            return char.IsDigit(ch) || ch == '.';
        }
    }
}
