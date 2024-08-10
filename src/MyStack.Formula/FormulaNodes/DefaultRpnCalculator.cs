using MyStack.Formula.FormulaNodes.Bracket;
using MyStack.Formula.FormulaNodes.Operator;
using MyStack.Formula.FormulaNodes.Value;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace MyStack.Formula.FormulaNodes
{
    public class DefaultRpnCalculator : IRpnCalculator
    {
        public List<FormulaNode> Preprocessing(List<FormulaNode> nodes)
        {
            var rpnNodes = new List<FormulaNode>();
            var tempNodes = new Stack<FormulaNode>();
            foreach (FormulaNode node in nodes)
            {
                if (node.NodeType == NodeType.Number)
                {
                    // 纯数字直接入队列
                    rpnNodes.Add(node);
                }
                else if (node.NodeType == NodeType.Operator)
                {
                    while (tempNodes.Count > 0)
                    {
                        var peekOperatorNode = tempNodes.Peek() as OperatorNode;
                        if (peekOperatorNode != null && peekOperatorNode.Priority >= ((OperatorNode)node).Priority)
                        {
                            rpnNodes.Add(tempNodes.Pop());
                        }
                        else
                            break;
                    }
                    tempNodes.Push(node);
                    continue;
                }
                else if (node.NodeType == NodeType.Bracket)
                {
                    if (((BracketNode)node).BracketType == BracketType.Left)
                    {
                        tempNodes.Push(node);
                    }
                    else if (((BracketNode)node).BracketType == BracketType.Right)
                    {
                        BracketNode? peekBracketNode;
                        while (tempNodes.Count > 0)
                        {
                            peekBracketNode = tempNodes.Peek() as BracketNode;
                            if (tempNodes.Peek().NodeType == NodeType.Bracket && peekBracketNode != null && peekBracketNode.BracketType == BracketType.Left)
                            {
                                break;
                            }
                            else
                            {
                                rpnNodes.Add(tempNodes.Pop());
                            }
                        }
                        tempNodes.Pop();
 
                    }
                }
            }
            while (tempNodes.Count > 0)
            {
                rpnNodes.Add(tempNodes.Pop());
            }
            return rpnNodes;
        }
        public double Calculate(List<FormulaNode> rpnNodes)
        {
            Stack<FormulaNode> numberNodes = new Stack<FormulaNode>();
            foreach (var node in rpnNodes)
            {
                if (node.NodeType == NodeType.Number)
                    numberNodes.Push(node);
                else if (node.NodeType == NodeType.Operator)
                {
                    var y = (NumberNode)numberNodes.Pop();
                    var x = (NumberNode)numberNodes.Pop();
                    var operatorNode = (OperatorNode)node;
                    var value = operatorNode.OperatorType switch
                    {
                        OperatorType.Multiply => x.Value * y.Value,
                        OperatorType.Divide => x.Value / y.Value,
                        OperatorType.Plus => x.Value + y.Value,
                        OperatorType.Minus => x.Value - y.Value,
                        OperatorType.Pow => Math.Pow(x.Value, y.Value),
                        _ => throw new InvalidOperationException("不支持的操作符类型。")
                    };
                    numberNodes.Push(new NumberNode(value));
                }
            }
            return ((NumberNode)numberNodes.Pop()).Value;
        }
    }
}
