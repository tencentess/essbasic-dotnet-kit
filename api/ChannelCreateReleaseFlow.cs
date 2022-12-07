using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelCreateReleaseFlowService
    {
        public static ChannelCreateReleaseFlowResponse ChannelCreateReleaseFlow(Agent agent, String needRelievedFlowId, 
            RelieveInfo reliveInfo, ReleasedApprover[] releasedApprovers, String callbackUrl)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelCreateReleaseFlowRequest req = new ChannelCreateReleaseFlowRequest();

                // 渠道应用相关信息
                req.Agent = agent;
                req.NeedRelievedFlowId = needRelievedFlowId;
                req.ReliveInfo = reliveInfo;
                req.ReleasedApprovers = releasedApprovers;
                req.CallbackUrl = callbackUrl;
                
                // 返回的resp是一个ChannelCreateReleaseFlowResponse的实例，与请求对象对应
                ChannelCreateReleaseFlowResponse resp = client.ChannelCreateReleaseFlowSync(req);
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
            String needRelievedFlowId = "************************";
            
            RelieveInfo reliveInfo = new RelieveInfo();
            reliveInfo.Reason = "************************";
            reliveInfo.RemainInForceItem = "************************";
            reliveInfo.OriginalExpenseSettlement = "************************";
            reliveInfo.OriginalOtherSettlement = "************************";
            reliveInfo.OtherDeals = "************************";

            ReleasedApprover releasedApprover = new ReleasedApprover();
            releasedApprover.OrganizationName = "************************";
            releasedApprover.ApproverNumber = 0;
            releasedApprover.ApproverType = "************************";
            releasedApprover.Name = "************************";
            releasedApprover.IdCardType = "************************";
            releasedApprover.IdCardNumber = "************************";
            releasedApprover.Mobile = "************************";
            releasedApprover.OrganizationOpenId = "************************";
            releasedApprover.OpenId = "************************";
            
            ReleasedApprover[] releasedApprovers = { releasedApprover };
            String callbackUrl = "************************";
            ChannelCreateReleaseFlowResponse resp = ChannelCreateReleaseFlow(Common.getAgent(),
                needRelievedFlowId, reliveInfo, releasedApprovers, callbackUrl);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}