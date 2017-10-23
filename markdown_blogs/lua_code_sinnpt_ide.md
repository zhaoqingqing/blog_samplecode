### 前言

当在一个大型工程中编写大量的lua脚本时，代码提示和方法跳转等功能很实用，据我所了解的目前除LuaStudio之外，似乎还没有一个很好的编辑器。但今天讲述的是Idea +EmmyLua插件 达到很强大的功能。



我的使用环境：

idea 2017.1.2 社区免费版

EmmyLua在线文档： <https://emmylua.github.io/>



### 原理分析

EmmyLua利用Idea的注解功能

EmmyLua注解功能只是单纯的辅助编辑器代码提示以及其它功能，和Lua代码的实际运行逻辑没有任何关系，因为它们就是普通的Lua注释



### 使用说明

为每个Lua脚本写上注解（`如果你希望方法参数有类型提示，那为方法也写上注解`），在编写过程中，就能够像写C#的class和method一样，提供代码提示，代码跳转。

在Idea中按Alt +Enter 选择**Create xx Annotation** 或者**Create LuaDoc** ，会自动填充模版。

更多丰富的注解类型，见EmmyLua的文档；https://emmylua.github.io/annotation.html



### Idea创建Lua文件的模版

**table类形注解**

```lua
---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: ${DATE}
---
---@type ${NAME}
local ${NAME} = {}

return ${NAME}
```



**class类型注解**

```lua
---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: ${DATE}
---
---@type ${NAME}
local ${NAME} = class("${NAME}")

function ${NAME}:ctor()
    
end

return ${NAME}
```

