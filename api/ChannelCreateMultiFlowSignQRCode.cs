using System;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelCreateMultiFlowSignQRCodeService
    {
        static ChannelCreateMultiFlowSignQRCodeResponse ChannelCreateMultiFlowSignQRCode(Agent agent, String templateId, String flowName)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelCreateMultiFlowSignQRCodeRequest req = new ChannelCreateMultiFlowSignQRCodeRequest();
                req.Agent = agent;
                req.FlowName = flowName;
                req.TemplateId = templateId;
                
                // 返回的resp是一个ChannelCreateMultiFlowSignQRCodeResponse的实例，与请求对象对应
                ChannelCreateMultiFlowSignQRCodeResponse resp = client.ChannelCreateMultiFlowSignQRCodeSync(req);
                // 输出json格式的字符串回包
                Console.WriteLine(AbstractModel.ToJsonString(resp));
                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.Read();
            return null;
        }

        public static void Main1(string[] args)
        {
            string templateId = "********";
            string flowName = "************";
            ChannelCreateMultiFlowSignQRCodeResponse resp = ChannelCreateMultiFlowSignQRCode(Common.getAgent(),templateId,flowName);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}
            