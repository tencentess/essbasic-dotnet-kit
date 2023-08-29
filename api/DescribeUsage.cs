using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class DescribeUsageService
    {
        public static DescribeUsageResponse DescribeUsage(Agent agent, 
            String startDate, String endDate, Boolean needAggregate, ulong limit, ulong offset)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                
                // 实例化一个请求对象,每个接口都会对应一个request对象
                DescribeUsageRequest req = new DescribeUsageRequest();

                req.Agent = agent;

                req.StartDate = startDate;

                req.EndDate = endDate;

                req.NeedAggregate = needAggregate;

                req.Limit = limit;

                req.Offset = offset;
                
                // 返回的resp是一个DescribeUsageResponse的实例，与请求对象对应
                DescribeUsageResponse resp = client.DescribeUsageSync(req);
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
            String startDate = "2022-10-01";
            String endDate = "2022-10-20";
            Boolean needAggregate = false;
            ulong limit = 10;
            ulong offset = 0;
            DescribeUsageResponse resp = DescribeUsage(Common.getAgent(), 
                startDate, endDate, needAggregate, limit, offset);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}