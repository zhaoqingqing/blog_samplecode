# less快速入门

## 我对less的读后感

通过less.js让less不再像传统的css是静态数据表，让它具备了编程语言的动态性。

得益于Variables(变量)和Mixins()让less可以做到编程语言很多的基础和实用特性，这将大大减少前端的代码量，使用代码变得更加优雅小巧。

官网：http://lesscss.org/

官网对less的解释：css的变体，通过less.js进行转换成css

本文内容来源于英文官网加上自己的阅读笔记。

## Variables(变量)

让css成为编程语言最基础最核心的功能，变量

```less
@width: 10px;
@height: @width + 10px;

#header {
  width: @width;
  height: @height;
}
```



## Mixins(属性包括)

Mixins把一串属性包括起来，PS.把including 翻译成中文的**`包括`**  确实有些怪怪的

根据官网提供的demo，结合我自身的理解，我把它叫它`可复用样式属性`

在此处定义一段样式代码属性名叫 .bordered

```less
.bordered {
  border-top: dotted 1px black;
  border-bottom: solid 2px black;
}
```
在其它地方通过引用.bordered()就相当于引用了上处定义的样式
```less
#menu a {
  color: #111;
  .bordered();
}

.post a {
  color: red;
  .bordered();
}
```



## Nesting(嵌套)

在CSS中对于子项语法我们需要这样写

```less
#header {
  color: black;
}
#header .navigation {
  font-size: 12px;
}
#header .logo {
  width: 300px;
}
```

而在less可以嵌套写（PS.这是语法糖？）

```less
#header {
  color: black;
  .navigation {
    font-size: 12px;
  }
  .logo {
    width: 300px;
  }
}
```



## Operations(运算符)

```less
// numbers are converted into the same units
@conversion-1: 5cm + 10mm; // result is 6cm
@conversion-2: 2 - 3cm - 5mm; // result is -1.5cm

// conversion is impossible
@incompatible-units: 2 + 5px - 3cm; // result is 4px

// example with variables
@base: 5%;
@filler: @base * 2; // result is 10%
@other: @base + @filler; // result is 15%
```

## Escaping(转义字符)

通过~""或~‘’ 中单插入任务字符串作属性和变量，便可转换成熟悉的css

```less
@min768: ~"(min-width: 768px)";
.element {
  @media @min768 {
    font-size: 1.2rem;
  }
}
```

转换后css如下

```less
@media (min-width: 768px) {
  .element {
    font-size: 1.2rem;
  }
}
```

## Functions(函数/内置函数)

less提供多种函数，比如 transform color，字符串操作，数学运算

示例：

转成百分比，把0.5 变成50%

设置颜色饱和度为5%

使用颜色lightened(变亮)25%，spun(旋转)8度

```less
@base: #f04615;
@width: 0.5;

.class {
  width: percentage(@width); // returns `50%`
  color: saturate(@base, 5%);//颜色饱和度
  background-color: spin(lighten(@base, 25%), 8);
}
```

## Namespaces and Accessors

(Not to be confused with [CSS `@namespace`](http://www.w3.org/TR/css3-namespace/) or [namespace selectors](http://www.w3.org/TR/css3-selectors/#typenmsp)).

*不要困惑 css中提供的@namespace 或 namespace 选择器* 

官方此话的意思应该是less中namespace和css是不一样的。



当在团队合作中要对某个功能进行封装，或对外提供sdk，less提供了命名空间。

### namespspace定义

注意：需要在namespace后使用()，比如#bundle()，

```less
#bundle() {
  .button {
    display: block;
    border: 1px solid black;
    background-color: grey;
    &:hover {
      background-color: white;
    }
  }
  .tab { ... }
  .citation { ... }
}
```

然后在某处需要使用.button的样式，我们可以这样调用

```less
#header a {
  color: orange;
  #bundle.button();  // can also be written as #bundle > .button
}
```



## Maps(映射表)

less3.5版本支持Maps，可以定义maps

```less
#colors() {
  primary: blue;
  secondary: green;
}

.button {
  color: #colors[primary];
  border: 1px solid #colors[secondary];
}
```

输出结果

```less
.button {
  color: blue;
  border: 1px solid green;
}
```



## Scope(作用域)

less和css类似，先从local查找变量，如果无则往 parent 查找。

```less
@var: red;

#page {
  #header {
    color: @var; // white
  }
  @var: white;
}
```



## Comments(注释)

// 单行

 /**/ 多行注释

##  Importing(文件导入)

@import关键字可以在less的任意位置使用，它可以导入*.less可以导入css

```less
@import "library"; // library.less
@import "typo.css";
```

