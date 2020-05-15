## XML-RPC

**XML-RPC**是一个[远程过程调用](https://zh.wikipedia.org/wiki/远程过程调用)（[远程过程调用](https://zh.wikipedia.org/wiki/遠端程序呼叫)）（remote procedure call，RPC)的[分布式计算](https://zh.wikipedia.org/wiki/分布式计算)[协议](https://zh.wikipedia.org/wiki/互聯網協議)，通过[XML](https://zh.wikipedia.org/wiki/XML)将调用函数封装，并使用[HTTP](https://zh.wikipedia.org/wiki/超文本传输协议)协议作为发送机制。

XML-RPC发表于1998年，由[UserLand Software](https://zh.wikipedia.org/w/index.php?title=UserLand_Software&action=edit&redlink=1)（[UserLand Software](https://zh.wikipedia.org/w/index.php?title=UserLand_Software&action=edit&redlink=1)）的[Dave Winer](https://zh.wikipedia.org/w/index.php?title=Dave_Winer&action=edit&redlink=1)及[Microsoft](https://zh.wikipedia.org/wiki/Microsoft)共同发表。后来在新的功能不断被引入下，这个标准慢慢演变成为今日的[SOAP](https://zh.wikipedia.org/wiki/SOAP)协议。

XML-RPC协议是已登记的专利项目，由[Phillip Merrick](https://zh.wikipedia.org/w/index.php?title=Phillip_Merrick&action=edit&redlink=1)、Stewart Allen及Joseph Lapp共同持有，于1998年3月提出申请，指其将用于一个构想中的应用程序，并于2006年4月获得接纳。现时这个专利由位于[美国](https://zh.wikipedia.org/wiki/美國)[维珍尼亚州](https://zh.wikipedia.org/wiki/維珍尼亞州)[费尔法克斯](https://zh.wikipedia.org/wiki/費爾法克斯_(維吉尼亞州))的[webMethods](https://zh.wikipedia.org/w/index.php?title=WebMethods&action=edit&redlink=1)使用。

## 用法

XML-RPC透过向设备了这个协议的服务器发出HTTP请求。发出请求的客户端一般都是需要向远程系统要求调用的软件。

[JSON-RPC](https://zh.wikipedia.org/wiki/JSON-RPC)（[JSON-RPC](https://zh.wikipedia.org/wiki/JSON-RPC)）跟 XML-RPC 相类似。

## 数据类型

以下的例子为日常的[数据类型](https://zh.wikipedia.org/wiki/數據類型)在转化为等同的XML后的面貌：

| 名称      | 标记示例                                                     | 描述                                                         |
| :-------- | :----------------------------------------------------------- | :----------------------------------------------------------- |
| array     | <array><br/>  <data><br/>    <value><i4>1404</i4></value><br/>    <value><string>Something here</string></value><br/>    <value><i4>1</i4></value><br/>  </data><br/></array> |                                                              |
| base64    | <base64>eW91IGNhbid0IHJlYWQgdGhpcyE=</base64>                |                                                              |
| boolean   | <boolean>1</boolean>                                         | [布尔型](https://zh.wikipedia.org/wiki/布尔型)逻辑值 (0 或 1) |
| date/time | <dateTime.iso8601>19980717T14:08:55</dateTime.iso8601>       |                                                              |
| double    | <double>-12.53</double>                                      | [双倍精确浮点数](https://zh.wikipedia.org/wiki/雙倍精確浮點數) |
| integer   | <i4>42</i4><br /><br /><int>42</int>                         | [整数](https://zh.wikipedia.org/wiki/整數)                   |
| string    | <string>Hello world!</string>                                | 字符串，必须遵守[XML encoding](https://zh.wikipedia.org/w/index.php?title=XML_encoding&action=edit&redlink=1)（[XML encoding](https://zh.wikipedia.org/wiki/XML)）的格式。 |
| struct    | <pre><br/><struct><br/>  <member><br/>    <name>foo</name><br/>    <value><i4>1</i4></value><br/>  </member><br/>  <member><br/>    <name>bar</name><br/>    <value><i4>2</i4></value><br/>  </member><br/></struct><br/></pre> | [结构体](https://zh.wikipedia.org/wiki/结构体)               |
| nil       | <nil/>                                                       |                                                              |



## 标准的XML-RPC

以下为一个寻常的 XML-RPC 请求的示例：

```xml
<?xml version="1.0"?>
<methodCall>
  <methodName>examples.getStateName</methodName>
  <params>
    <param>
        <value><i4>40</i4></value>
    </param>
  </params>
</methodCall>
```

相对于上述请求，以下为一个寻常回应的示例：

```xml
<?xml version="1.0"?>
<methodResponse>
  <params>
    <param>
        <value><string>South Dakota</string></value>
    </param>
  </params>
</methodResponse>
```

以下为一个寻常的 XML-RPC 错误：

```xml
<?xml version="1.0"?>
<methodResponse>
  <fault>
    <value>
      <struct>
        <member>
          <name>faultCode</name>
          <value><int>4</int></value>
        </member>
        <member>
          <name>faultString</name>
          <value><string>Too many parameters.</string></value>
        </member>
      </struct>
    </value>
  </fault>
</methodResponse>
```



原文出自维基百科 https://zh.wikipedia.org/wiki/XML-RPC