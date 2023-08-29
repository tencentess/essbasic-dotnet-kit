using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelCancelFlowService
    {
        public static ChannelCancelFlowResponse ChannelCancelFlow(Agent agent, String flowId, 
            String cancelMessage, long cancelMessageFormat)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelCancelFlowRequest req = new ChannelCancelFlowRequest();

                req.Agent = agent;

                req.FlowId = flowId;

                req.CancelMessage = cancelMessage;

                req.CancelMessageFormat = cancelMessageFormat;
                
                // 返回的resp是一个ChannelCancelFlowResponse的实例，与请求对象对应
                ChannelCancelFlowResponse resp = client.ChannelCancelFlowSync(req);
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
            String flowId = "************************";
            String cancelMessage = "";
            long cancelMessageFormat = 0;
            ChannelCancelFlowResponse resp = ChannelCancelFlow(Common.getAgent(),
                flowId, cancelMessage, cancelMessageFormat);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}