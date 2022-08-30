using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    public class Common
    {
        public static EssbasicClient GetClientInstance(string secretId, string secretKey, string endPoint)
        {
            // 实例化一个认证对象，入参需要传入腾讯云账户密钥对secretId，secretKey。
            Credential cred = new Credential
            {
                SecretId = secretId,
                SecretKey = secretKey
            };
            // 实例化一个client选项，可选的，没有特殊需求可以跳过
            ClientProfile clientProfile = new ClientProfile();
            // 指定签名算法(默认为HmacSHA256)
            clientProfile.SignMethod = ClientProfile.SIGN_TC3SHA256;

            // 实例化一个客户端配置对象，可以指定超时时间等配置
            HttpProfile httpProfile = new HttpProfile();
            httpProfile.Endpoint = endPoint;
            clientProfile.HttpProfile = httpProfile;

            EssbasicClient client = new EssbasicClient(cred, "ap-guangzhou", clientProfile);

            return client;
        }

        public static Agent getAgent()
        {
            Agent agent = new Agent();
            UserInfo userInfo = new UserInfo();
            agent.AppId = Configs.AppId;
            agent.ProxyAppId = Configs.ProxyAppId;
            agent.ProxyOrganizationOpenId = Configs.ProxyOrganizationOpenId;
            userInfo.OpenId = Configs.ProxyOperatorOpenId;
            agent.ProxyOperator = userInfo;
            return agent;
        }
    }
}