using System;
using System.Collections.Generic;

namespace MyStack.FormulaParser.FormulaNodes.Value
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
        public bool Parse(ReadOnlySpan<char> chars, ref int index, ref List<FormulaNode> nodes)
        {
            if (chars[index] == Prefix)
            {
                var length = 0;
                var startIndex = index + 1;
                for (int i = index + 1; i < chars.Length; i++)
                {
                    if (chars[i] == Postfix)
                    {
                        length = i - index - 1;
                        index = i;
                        break;
                    }
                }
                var id = chars.Slice(startIndex, length).ToString();
                // 查询数据源中的值
                var value = ObjectDataProvider.GetValueAsync(id).Result;
                nodes.Add(new NumberNode(value));
                return true;
            }
            return false;
        }
    }
}
