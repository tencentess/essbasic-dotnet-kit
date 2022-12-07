using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelCreateBoundFlowsService
    {
        public static ChannelCreateBoundFlowsResponse ChannelCreateBoundFlows(Agent agent, String[] flowIds)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelCreateBoundFlowsRequest req = new ChannelCreateBoundFlowsRequest();

                // 渠道应用相关信息
                req.Agent = agent;
                req.FlowIds = flowIds;
                
                // 返回的resp是一个ChannelCreateBoundFlowsResponse的实例，与请求对象对应
                ChannelCreateBoundFlowsResponse resp = client.ChannelCreateBoundFlowsSync(req);
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
            ChannelCreateBoundFlowsResponse resp = ChannelCreateBoundFlows(Common.getAgent(), flowIds);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}