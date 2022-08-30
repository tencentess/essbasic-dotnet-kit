using System;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class CreateSignUrlsService
    {
        public static CreateSignUrlsResponse CreateSignUrls(String[] flowIds, Agent agent)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                // 实例化一个请求对象,每个接口都会对应一个request对象
                CreateSignUrlsRequest req = new CreateSignUrlsRequest();

                 // 渠道应用相关信息
                req.Agent = agent;
                // 多个合同（签署流程）信息
                req.FlowIds = flowIds;
                
                // 返回的resp是一个CreateSignUrlsResponse的实例，与请求对象对应
                CreateSignUrlsResponse resp = client.CreateSignUrlsSync(req);
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
            string flowId = "********";
            CreateSignUrlsResponse resp = CreateSignUrls(new String[]{flowId},Common.getAgent());
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}
            