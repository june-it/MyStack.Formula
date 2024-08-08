using System;
using System.Collections.Generic;
using System.Linq;
using MyStack.FormulaParser.Brackets;
using MyStack.FormulaParser.Numbers;
using MyStack.FormulaParser.Operators;

namespace MyStack.FormulaParser
{
    public class FormulaAnalyzer
    {
        public FormulaAnalyzer(IEnumerable<IFormulaNodeParser> nodeParsers)
        {
            NodeParsers = nodeParsers;
        }
        protected IEnumerable<IFormulaNodeParser> NodeParsers { get; set; }
        protected virtual List<FormulaNode> Analysis(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "输入的公式值不能为空。");
            var nodes = new List<FormulaNode>();
            var chars = input.AsSpan();
            for (int i = 0; i < chars.Length; i++)
            {
                foreach (var nodeParser in NodeParsers.OrderByDescending(x => x.Priority))
                {
                    if (nodeParser.Parse(chars, ref i, ref nodes))
                        break;
                }
            }
            return nodes;
        }

        protected virtual List<FormulaNode> ChangeToRPN(List<FormulaNode> nodes)
        {
            var rpnNodes = new List<FormulaNode>();
            var tempNodes = new Stack<FormulaNode>();
            foreach (FormulaNode node in nodes)
            {
                if (node.NodeType == NodeType.Number)
                {
                    rpnNodes.Add(node);
                    continue;
                }
                if (node.NodeType == NodeType.Operator)
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
                if (node.NodeType == NodeType.Bracket)
                {
                    if (((BracketNode)node).BracketType == BracketType.Left)
                    {
                        tempNodes.Push(node);
                        continue;
                    }

                }
                if (node.NodeType == NodeType.Bracket)
                {
                    if (((BracketNode)node).BracketType == BracketType.Right)
                    {
                        while (tempNodes.Count > 0)
                        {
                            var peekBracketNode = tempNodes.Peek() as BracketNode;
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
                        continue;
                    }
                }
            }
            if (tempNodes.Count > 0)
            {
                rpnNodes.Add(tempNodes.Pop());
            }
            return rpnNodes;
        }

        protected virtual double CalculationRPN(List<FormulaNode> rpnNodes)
        {
            double result = 0;
            Stack<FormulaNode> numberNodes = new Stack<FormulaNode>();
            foreach (var node in rpnNodes)
            {
                if (node.NodeType == NodeType.Number)
                    numberNodes.Push(node);
                else if (node.NodeType == NodeType.Operator)
                {
                    var x = (NumberNode)numberNodes.Pop();
                    var y = (NumberNode)numberNodes.Pop();
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
            result = ((NumberNode)numberNodes.Pop()).Value;
            return result;
        }

        public double Calculation(string input)
        {
            var nodes = Analysis(input);
            var rpnNodes = ChangeToRPN(nodes);
            return CalculationRPN(rpnNodes);
        }
    }
}
