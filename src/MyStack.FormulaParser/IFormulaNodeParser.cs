using System;
using System.Collections.Generic;

namespace MyStack.FormulaParser
{
    /// <summary>
    /// 表示公式节点转换器接口
    /// </summary>
    public interface IFormulaNodeParser
    {
        /// <summary>
        /// 优先级
        /// 值越大越优先
        /// </summary>
        int Priority { get; }
        /// <summary>
        /// 进行公式节点转换
        /// </summary>
        /// <param name="chars">字符数组</param>
        /// <param name="index">返回结束索引下标</param>
        /// <param name="nodes">节点列表</param>
        /// <returns></returns>
        bool Parse(ReadOnlySpan<char> chars, ref int index, ref List<FormulaNode> nodes);
    } 
}
