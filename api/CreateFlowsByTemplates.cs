using System;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class CreateFlowsByTemplatesService
    {
        public static CreateFlowsByTemplatesResponse CreateFlowsByTemplates(Agent agent, FlowInfo[] flowInfos)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                // 实例化一个请求对象,每个接口都会对应一个request对象
                CreateFlowsByTemplatesRequest req = new CreateFlowsByTemplatesRequest();

                req.Agent = agent;

                req.FlowInfos = flowInfos;
                
                // 返回的resp是一个CreateFlowsByTemplatesResponse的实例，与请求对象对应
                CreateFlowsByTemplatesResponse resp = client.CreateFlowsByTemplatesSync(req);
                // 输出json格式的字符串回包
                Console.WriteLine(AbstractModel.ToJsonString(resp));
                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }
    }
}