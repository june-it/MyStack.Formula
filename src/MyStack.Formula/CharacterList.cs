using System.Collections;

namespace MyStack.Formula
{
    /// <summary>
    /// 表示字符串列表
    /// </summary>
    public class CharacterList : ArrayList
    {
        /// <summary>
        /// 初始化一个字符串列表对象
        /// </summary>
        /// <param name="chars"></param>
        public CharacterList(char[] chars)
            : base(chars)
        {
        }
        /// <summary>
        /// 返回字符串列表指定范围的元素项字符串
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public string GetRangeString(int index, int count)
        {
            return string.Join("", GetRange(index, count).ToArray());
        }
        /// <summary>
        /// 返回字符串列表的字符串
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            return GetRangeString(0, Count);
        }
    }
}
