### React Developer Tools

安装后，在扩展管理中，勾选 **允许访问文件网址**
React Developer Tools是一款由facebook开发的有用的[Chrome 浏览器扩展](http://chromecj.com/Handler/Download/890)，可以通过 Chrome Web存储获取。使用 Chrome Devtools 进行调试时，可以查看应用程序的 React 组件分层结构，而不是更加神秘的浏览器 DOM 表示。添加react developer tools到chrome，是对chrome开发工具的React调试工具。

React的开发工具是开源Chrome DevTools延伸反应的JavaScript库。它允许你检查React在Chrome开发者工具组件的层次结构（原名WebKit Web Inspector）。你会得到新的标签要求在你的Chrome DevTools反应。这表明你的根反应组件在页面渲染，以及他们最终渲染组件。

### yarn.lock

包管理器，和npm一样，facebook发明的。



### 字符串

字符串模板 ${} ${}，C#中${},{}



### ES6的箭头函数

箭头所指向的内容将会自动返回，如果函数只包含一个参数，还可以移除两边的括号

```javascript
let sayHello = (name)=>'hello:'+ name
console.log(sayHello("qing"))
```

在webstrom下，如果单行添加{}，反而会出现意外的结果，出现 undefined

