# 腾讯电子签渠道版API接入工具包

## 安装腾讯云sdk
安装 .NET SDK 前，先获取安全凭证。在第一次使用云API之前，用户首先需要在腾讯云控制台上申请安全凭证，安全凭证包括 SecretID 和 SecretKey ， SecretID 是用于标识 API 调用者的身份， SecretKey 是用于加密签名字符串和服务器端验证签名字符串的密钥。 SecretKey 必须严格保管，避免泄露。
参考：https://cloud.tencent.com/document/sdk/.NET
### 通过nuget 安装(推荐)
1. 通过命令行安装: dotnet add package TencentCloudSDK ，其他信息请到 nuget 获取。如果想单独安装某个产品，例如云服务器 CVM，则添加依赖 TencentCloudSDK.Cvm 即可。

2. 通过 Visual Studio 的添加包

### 通过源码安装
前往 Github 仓库 或者 Gitee 仓库 下载最新代码，解压后使用 Visual Studio 2017 打开编译。

## 目录文件说明
### api
api目录是对电子签渠道版所有API的简单封装，以及调用的Example。
如果需要API更加高级的功能，需要结合业务修改api的封装。

### byfile
byfile目录是电子签渠道版的核心场景之一 - 通过文件发起的快速上手样例。
业务方可以结合自己的业务调整，用于正式对接。

### bytemplate
byfile目录是电子签渠道版的核心场景之一 - 通过模版发起的快速上手样例。
业务方可以结合自己的业务调整，用于正式对接。

### callback
callback目录是电子签渠道版对接的回调解密部分。
业务方需要配置好回调地址和加密key，就可以接收到相关的回调了。

### testdata
testdata是一个空白的pdf用于快速发起合同，测试。

### config.php
里面定义调用电子签渠道版API需要的一些核心参数。

## 电子签渠道版官网入口
[腾讯电子签渠道版](https://cloud.tencent.com/document/product/1420/61534)


