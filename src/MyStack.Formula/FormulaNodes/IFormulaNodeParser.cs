using System.Collections.Generic;

namespace MyStack.Formula.FormulaNodes
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
        /// <param name="chars">待处理字符列表</param>
        /// <param name="nodes">节点列表</param>
        /// <returns></returns>
        bool Parse(CharacterList chars, ref List<FormulaNode> nodes);
    }
}
