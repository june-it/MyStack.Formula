# MyStack.Formula
 公式运算

## 调用方式
```
// 服务注入
var services = new ServiceCollection();
services.AddFormula(context.Configuration, configure =>
{
    // 配置JSON数据源
    configure.UseConfigurationIdValue();
});


```

## 功能
```
// 调用
var formulaEngine = serviceProvider.GetRequiredService<FormulaEngine>();
```


### 运算符 `+`、`-`、`*`、`/`、`^`
``` 
// 结果：2
var actualValue = formulaEngine.Calculate("1+1");
```


### 括号符

```
// 结果：4
var actualValue = formulaEngine.Calculate("(1+1)*2");
```

### 复杂公式

```
// 调用
// 结果：9.001953125
var actualValue = formulaEngine.Calculate("3+4*2/(1-5)^2^3+2*(2+1)");
```
 

### 数据源

#### 值类型计算

```
// 配置Id的值为：<1> = 1
// 结果：4
var actualValue = formulaEngine.Calculate("(1+<1>)*2");


```
#### 公式类型计算
```
// 配置Id的值为：<2> = (2+1)*2
// 结果：22
var actualValue = formulaEngine.Calculate("(1+<1>)*2");

```
