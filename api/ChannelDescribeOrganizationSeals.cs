using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelDescribeOrganizationSealsService
    {
        public static ChannelDescribeOrganizationSealsResponse ChannelDescribeOrganizationSeals(Agent agent, 
            long infoType, String sealId, long limit, long offset)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelDescribeOrganizationSealsRequest req = new ChannelDescribeOrganizationSealsRequest();

                // 渠道应用相关信息
                req.Agent = agent;
                req.InfoType = infoType;
                req.SealId = sealId;
                req.Limit = limit;
                req.Offset = offset;
                
                // 返回的resp是一个ChannelDescribeOrganizationSealsResponse的实例，与请求对象对应
                ChannelDescribeOrganizationSealsResponse resp = client.ChannelDescribeOrganizationSealsSync(req);
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
            long infoType = 0;
            String sealId = "************************";
            long limit = 10;
            long offset = 0;           
            ChannelDescribeOrganizationSealsResponse resp = ChannelDescribeOrganizationSeals(Common.getAgent(), 
                infoType, sealId, limit,  offset);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}