using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class PrepareFlowsService
    {
        public static PrepareFlowsResponse PrepareFlows(Agent agent, String jumpUrl, FlowInfo[] flowInfos)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                
                // 实例化一个请求对象,每个接口都会对应一个request对象
                PrepareFlowsRequest req = new PrepareFlowsRequest();

                req.Agent = agent;

                req.JumpUrl = jumpUrl;

                req.FlowInfos = flowInfos;
                
                // 返回的resp是一个PrepareFlowsResponse的实例，与请求对象对应
                PrepareFlowsResponse resp = client.PrepareFlowsSync(req);
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
            String jumpUrl = "************************";

            FlowInfo flowInfo = new FlowInfo();
            flowInfo.FlowName = "***";
            flowInfo.TemplateId = "************************";

            FlowApproverInfo flowApprover = new FlowApproverInfo();
            flowApprover.Name = "***";
            flowApprover.Mobile = "***********";
            flowInfo.FlowApprovers = new[] { flowApprover };
            
            FlowInfo[] flowInfos = { flowInfo };
            PrepareFlowsResponse resp = PrepareFlows(Common.getAgent(), 
                jumpUrl, flowInfos);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}