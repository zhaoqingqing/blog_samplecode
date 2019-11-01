### npm源改为国内

由于 Node 的官方模块仓库网速太慢，模块仓库需要切换到阿里的源。

```
npm config set registry https://registry.npm.taobao.org/
```

执行下面的命令，确认是否切换成功。

```
npm config get registry
```

如果输出为 taobao字样，则表示切换成功

### 安装 Postman

Postman 是一个 HTTP 通信测试工具，REST API 的练习会用到它。

请到官网 [GetPostman.com](https://www.getpostman.com/) 下载独立安装包。

### 运行tsc报错

在windows10 x64 专业版(10.0.16299) 通过npm 安装ts之后，执行tsc xx.ts，报错信息如下：

```powershell
tsc : 无法加载文件 C:\Users\Administrator\AppData\Roaming\npm\tsc.ps1，因为在此系统上禁止运行脚本。有关详细信息，请参阅
 https:/go.microsoft.com/fwlink/?LinkID=135170 中的 about_Execution_Policies。
所在位置 行:1 字符: 1
+ tsc .\model\Person.ts
+ ~~~
    + CategoryInfo          : SecurityError: (:) []，PSSecurityException
    + FullyQualifiedErrorId : UnauthorizedAccess
```

**解决办法**

执行策略可帮助你防止执行不信任的脚本

1.管理员身份打开powerShell

2.输入set-ExecutionPolicy RemoteSigned  

3 选择Y 或者A ，就好了

### webstrom

webstrom界面中有ts的log窗口

安装webstrom之后，有内置的typescript模块，也可以手动安装 `npm install -g typescript`

