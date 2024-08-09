# MyStack.Formula
 公式运算

## 调用方式
```
// 服务注入
var services = new ServiceCollection();
services.AddFormulaParser();


```

## 功能
```
// 调用
var formulaEngine = serviceProvider.GetRequiredService<FormulaEngine>();
```


### 运算符 `+`、`-`、`*`、`/`、`^`
``` 
// 结果：2
var actualValue = formulaEngine.Calculation("1+1");
```


### 括号符

```
// 调用
var formulaAnalyzer = serviceProvider.GetRequiredService<FormulaAnalyzer>();
// 结果：4
var actualValue = formulaEngine.Calculation("(1+1)*2");
```
 
### 数据源

#### 值类型计算

```
// 配置Id的值为：<1> = 1
// 结果：4
var actualValue = formulaEngine.Calculation("(1+<1>)*2");


```
#### 公式类型计算
```
// 配置Id的值为：<2> = (2+1)*2
// 结果：22
var actualValue = formulaEngine.Calculation("(1+<1>)*2");

```
