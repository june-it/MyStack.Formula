# MyStack.FormulaParser
 公式运算

## 调用方式
```
// 服务注入
var services = new ServiceCollection();
services.AddFormulaParser();


```

## 功能

1、运算符 `+`、`-`、`*`、`/`、`^`
```
// 调用
var formulaAnalyzer = serviceProvider.GetRequiredService<FormulaAnalyzer>();
// 结果：2
var actualValue = formulaAnalyzer.Calculation("1+1");
```


2、括号符

```
// 调用
var formulaAnalyzer = serviceProvider.GetRequiredService<FormulaAnalyzer>();
// 结果：4
var actualValue = formulaAnalyzer.Calculation("(1+1)*2");
```
 
3、数据源

```
// 调用
var formulaAnalyzer = serviceProvider.GetRequiredService<FormulaAnalyzer>();
// 配置Id的值为：<1>=10
// 结果：22
var actualValue = formulaAnalyzer.Calculation("(1+<1>)*2");
```

