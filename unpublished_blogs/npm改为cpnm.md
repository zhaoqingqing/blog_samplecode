## cnpm

淘宝团队做的国内镜像，因为npm的服务器位于国外可能会影响安装。淘宝镜像与官方同步频率目前为 10分钟 一次以保证尽量与官方服务同步。

官网：https://developer.aliyun.com/mirror/NPM?from=tnpm

安装：命令提示符执行
 `npm install cnpm -g --registry=https://registry.npm.taobao.org`

`cnpm -v` 来测试是否成功安装

安装完成后可以cnpm通过来代替默认的npm

```
cnpm install [name]
```



## npm源改为国内

此方法不需要安装cnpm也使用淘宝镜像，提高国内访问速度

由于 Node 的官方模块仓库网速太慢，模块仓库需要切换到阿里的源。

```
npm config set registry https://registry.npm.taobao.org/
```

执行下面的命令，确认是否切换成功。

```
npm config get registry
```

如果输出看到 taobao字样，则表示切换成功

## npm源换回默认

```
npm config set registry https://registry.npmjs.org/
npm config get registry
```

## nrm

- `nrm`包安装命令： `npm i nrm -g`
- `nrm`能够管理所用可用的镜像源地址以及当前所使用的镜像源地址，但是只是单纯的提供了几个url并能够让我们在这几个地址之间方便切换
- `nrm ls`即nrm list，查看所有可用的镜像，并可以切换。*号表示当前npm使用的地址，可以使用命令`nrm use taobao`或 `nrm use npm`来进行两者之间的切换。

```powershell
C:\Users\qing>nrm ls
  npm -------- https://registry.npmjs.org/
  yarn ------- https://registry.yarnpkg.com/
  cnpm ------- http://r.cnpmjs.org/
* taobao ----- https://registry.npm.taobao.org/
  nj --------- https://registry.nodejitsu.com/
  npmMirror -- https://skimdb.npmjs.com/registry/
  edunpm ----- http://registry.enpmjs.org/
```

## npm参数-g -S -D

- `-g`：全局安装。 将会安装在C：\ Users \ Administrator \ AppData \ Roaming \ npm，**并且写入系统环境变量**；非全局安装：将会安装在当前定位目录;全局安装可以通过命令行任何地方调用它，本地安装将安装在定位目录的node_modules文件夹下，通过要求调用;
- `-S`：即`npm install module_name --save`,写入`package.json`的`dependencies` ,`dependencies` 是需要发布到生产环境的，比如jq，vue全家桶，ele-ui等ui框架这些项目运行时必须使用到的插件就需要放到`dependencies`
- `-D`：即`npm install module_name --save-dev`,写入`package.json`的`devDependencies` ,`devDependencies` 里面的插件只用于开发环境，不用于生产环境。比如一些babel编译功能的插件、webpack打包插件就是开发时候的需要，真正程序打包跑起来并不需要的一些插件。

> 为什么要保存在`package.json`  因为node_module包实在是太大了。用一个配置文件保存，只打包安装对应配置文件的插件，按需导入。

## EAI_AGAIN

```powershell
C:\Users\qing>npm install -g artipub --registry=https://registry.npm.taobao.org
npm ERR! code EAI_AGAIN
npm ERR! errno EAI_AGAIN
npm ERR! request to https://registry.npm.taobao.org/caporal failed, reason: getaddrinfo EAI_AGAIN registry.npm.taobao.org

npm ERR! A complete log of this run can be found in:
npm ERR!     C:\Users\qing\AppData\Roaming\npm-cache\_logs\2020-05-12T04_34_24_304Z-debug.log
```

网上有说防火墙的，我机器上的防火墙是关闭状态的，通过ping也是能连通这个链接

解决方法

通过上面提到的nrm，把源从taobao切换为其它就解决了，因为我们公司网站屏蔽了淘宝和京东等网站。