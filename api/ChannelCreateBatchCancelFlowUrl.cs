using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelCreateBatchCancelFlowUrlService
    {
        public static ChannelCreateBatchCancelFlowUrlResponse ChannelCreateBatchCancelFlowUrl(Agent agent, String[] flowIds)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelCreateBatchCancelFlowUrlRequest req = new ChannelCreateBatchCancelFlowUrlRequest();

                req.Agent = agent;
                req.FlowIds = flowIds;
                
                // 返回的resp是一个ChannelCreateBatchCancelFlowUrlResponse的实例，与请求对象对应
                ChannelCreateBatchCancelFlowUrlResponse resp = client.ChannelCreateBatchCancelFlowUrlSync(req);
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
            String[] flowIds = new[] { "************************" };
            ChannelCreateBatchCancelFlowUrlResponse resp = ChannelCreateBatchCancelFlowUrl(Common.getAgent(),
                flowIds);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}