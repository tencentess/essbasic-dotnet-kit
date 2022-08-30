// 基础配置，调用API之前必须填充的参数
public class Configs
{
    // 调用API的密钥对，通过腾讯云控制台获取
    public static string secretId = "**************";
    public static string secretKey = "****************";

    // AppId
    public static  string AppId = "*******************";

    // 腾讯电子签颁发给渠道侧合作企业的应用ID
    public static  string ProxyAppId = "******************";

    // 渠道/平台合作企业的企业ID
    public static  string ProxyOrganizationOpenId = "****************";

    // 渠道/平台合作企业经办人（操作员）ID
    public static  string ProxyOperatorOpenId = "***************";

    // 企业方静默签用的印章Id，电子签控制台获取
    public static string ServerSignSealId = "****************";

    // 模板Id，电子签控制台获取，仅在通过模板发起时使用
    public static string templateId = "*****************";

    // API域名，现网使用 ess.tencentcloudapi.com
    public static string endPoint = "essbasic.test.ess.tencent.cn";

    // 文件服务域名，现网使用 file.ess.tencent.cn
    public static string fileServiceEndPoint = "file.test.ess.tencent.cn";

    public static int count = 1;


}