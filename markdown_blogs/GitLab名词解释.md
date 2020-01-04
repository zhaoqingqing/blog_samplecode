### 1. Gitlab

GitLab是一个利用Ruby on Rails开发的开源应用程序，实现一个自托管的Git项目仓库，可通过Web界面进行访问公开的或者私人项目。
它拥有与GitHub类似的功能，能够浏览源代码，管理缺陷和注释。可以管理团队对仓库的访问，它非常易于浏览提交过的版本并提供一个文件历史库。团队成员可以利用内置的简单聊天程序（Wall）进行交流。它还提供一个代码片段收集功能可以轻松实现代码复用，便于日后有需要的时候进行查找。

### 2. Gitlab-CI

[Gitlab-CI](https://docs.gitlab.com/ce/ci/quick_start/README.html)是GitLab Continuous Integration（Gitlab持续集成）的简称。
从Gitlab的8.0版本开始，gitlab就全面集成了Gitlab-CI,并且对所有项目默认开启。
只要在项目仓库的根目录添加`.gitlab-ci.yml`文件，并且配置了Runner（运行器），那么每一次合并请求（MR）或者push都会触发CI [pipeline](https://docs.gitlab.com/ce/ci/pipelines.html)。

### 3. Gitlab-runner

[Gitlab-runner](https://docs.gitlab.com/ce/ci/runners/README.html)是`.gitlab-ci.yml`脚本的运行器，Gitlab-runner是基于Gitlab-CI的API进行构建的相互隔离的机器（或虚拟机）。GitLab Runner 不需要和Gitlab安装在同一台机器上，但是考虑到GitLab Runner的资源消耗问题和安全问题，也不建议这两者安装在同一台机器上。

Gitlab Runner分为两种，Shared runners和Specific runners。
Specific runners只能被指定的项目使用，Shared runners则可以运行所有开启` Allow shared runners`选项的项目。

### 4. Pipelines

Pipelines是定义于`.gitlab-ci.yml`中的不同阶段的不同任务。
我把[Pipelines](https://docs.gitlab.com/ce/ci/pipelines.html)理解为流水线，流水线包含有多个阶段（[stages](https://docs.gitlab.com/ce/ci/yaml/README.html#stages)），每个阶段包含有一个或多个工序（[jobs](https://docs.gitlab.com/ce/ci/yaml/README.html#jobs)），比如先购料、组装、测试、包装再上线销售，每一次push或者MR都要经过流水线之后才可以合格出厂。而`.gitlab-ci.yml`正是定义了这条流水线有哪些阶段，每个阶段要做什么事。

### 5. Badges

[徽章](https://docs.gitlab.com/ce/ci/pipelines.html#badges)，当Pipelines执行完成，会生成徽章，你可以将这些徽章加入到你的README.md文件或者你的网站。