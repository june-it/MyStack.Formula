using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MyStack.Formula.FormulaNodes.Value
{
    /// <summary>
    /// 表示对象节点转换器
    /// </summary>
    public class ObjectFormulaNodeParser : IFormulaNodeParser
    {
        public int Priority => 98;
        protected char Prefix => '<';
        protected char Postfix => '>';
        protected IObjectDataProvider ObjectDataProvider { get; }
        public ObjectFormulaNodeParser(IObjectDataProvider objectDataProvider)
        {
            ObjectDataProvider = objectDataProvider;
        }
        public bool Parse(CharacterList chars, ref List<FormulaNode> nodes)
        {
            var ch = Convert.ToChar(chars[0]);
            if (ch == Prefix)
            {
                var length = 0;
                for (int i = 1; i < chars.Count; i++)
                {
                    if (Convert.ToChar(chars[i]) == Postfix)
                    {
                        length = i + 1;
                        break;
                    }
                }
                var id = chars.GetRangeString(1, length - 2);
                chars.RemoveRange(0, length);
                // 查询数据源中的值
                var value = ObjectDataProvider.GetValueAsync(id).Result;

                if (double.TryParse(value, out var number))
                {
                    // 转换成数字
                    nodes.Add(new NumberNode(number));
                }
                else
                {
                    // 按公式继续计算
                    chars.AddRange(value.ToCharArray());
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 检查字符串是否符合对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsMatch(string input)
        {
            return new Regex("^\\<(.*?)\\>$").IsMatch(input);
        }
    }
}
