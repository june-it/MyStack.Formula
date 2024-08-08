# MyStack.FormulaParser
 公式运算

## 调用方式
```
// 服务注入
var services = new ServiceCollection();
services.AddFormulaParser();

// 调用
var formulaAnalyzer = serviceProvider.GetRequiredService<FormulaAnalyzer>();
// 结果：2
var actualValue = formulaAnalyzer.Calculation("(1+1)*2");
```