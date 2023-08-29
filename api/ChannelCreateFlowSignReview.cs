using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelCreateFlowSignReviewService
    {
        public static ChannelCreateFlowSignReviewResponse ChannelCreateFlowSignReview(Agent agent, String flowId,
            String reviewType, String reviewMessage, String recipientId)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelCreateFlowSignReviewRequest req = new ChannelCreateFlowSignReviewRequest();

                req.Agent = agent;

                req.FlowId = flowId;

                req.ReviewType = reviewType;

                req.ReviewMessage = reviewMessage;

                req.RecipientId = recipientId;
                
                // 返回的resp是一个ChannelCreateFlowSignReviewResponse的实例，与请求对象对应
                ChannelCreateFlowSignReviewResponse resp = client.ChannelCreateFlowSignReviewSync(req);
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
            String reviewType = "************************";
            String reviewMessage = "************************";           
            String recipientId = "************************";           
            ChannelCreateFlowSignReviewResponse resp = ChannelCreateFlowSignReview(Common.getAgent(), 
                flowId, reviewType,  reviewMessage,  recipientId);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}