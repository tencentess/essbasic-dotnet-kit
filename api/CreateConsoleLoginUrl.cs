using System;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class CreateConsoleLoginUrlService
    {
        public static CreateConsoleLoginUrlResponse CreateConsoleLoginUrl(Agent agent, String proxyOrganizationName)
        {
            try
            {
                 // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                CreateConsoleLoginUrlRequest req = new CreateConsoleLoginUrlRequest();

                agent.ProxyAppId = "";  //不需要此参数
                req.Agent = agent;

                req.ProxyOrganizationName = proxyOrganizationName;

                CreateConsoleLoginUrlResponse resp = client.CreateConsoleLoginUrlSync(req);
                // 输出json格式的字符串回包
                // Console.WriteLine(AbstractModel.ToJsonString(resp));
                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public static void Main1(string[] args)
        {
            string proxyOrganizationName = "********";
            CreateConsoleLoginUrlResponse resp = CreateConsoleLoginUrl(Common.getAgent(),proxyOrganizationName);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}