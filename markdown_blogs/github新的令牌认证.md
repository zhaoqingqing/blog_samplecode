## 收到邮件

在2021年收到几次github的邮件，内容如下：

Hi @zhaoqingqing,

You recently used a password to access the repository at zhaoqingqing/blog_samplecode with git using git/2.26.2.windows.1.

Basic authentication using a password to Git is deprecated and will soon no longer work. Visit https://github.blog/2020-12-15-token-authentication-requirements-for-git-operations/ for more information around suggested workarounds and removal dates.

Thanks,
The GitHub Team

大意为2021-8-31之后会停止通过密码的方式访问github

## 您今天需要做什么

- 对于开发人员来说，如果您今天使用密码来验证GitHub.com上的Git操作，则必须在2021年8月13日之前开始通过HTTPS（推荐）或SSH密钥使用[个人访问令牌](https://docs.github.com/en/free-pro-team@latest/github/authenticating-to-github/creating-a-personal-access-token)，以免造成干扰。如果收到警告，说明您正在使用过时的第三方集成，则应将客户端更新为最新版本。


别一个方法： 启用两因素身份验证

如果要确保您的帐户不允许基于密码的身份验证，则可以立即为您的帐户[启用两因素身份验证](https://help.github.com/en/github/authenticating-to-github/configuring-two-factor-authentication)。这将要求您将个人访问令牌用于通过Git和第三方集成进行的所有经过身份验证的操作。



## 我的决定

PS：这个两因素身份认证，查看了文档，操作比较麻烦，暂时不使用此方式。我很早就使用https来访问github了，可能是git的版本过低，需要升级一下家里的git版本。

公司电脑上的git版本信息，未收到警告信息

TortoiseGit 2.7.0.0 (C:\Program Files\TortoiseGit\bin)
git version 2.21.0.windows.1 (C:\Program Files\Git\bin; C:\Program Files\Git\mingw64\; C:\Program Files\Git\mingw64\etc\gitconfig; C:\ProgramData\Git\config)