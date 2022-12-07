using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelDescribeEmployeesService
    {
        public static ChannelDescribeEmployeesResponse ChannelDescribeEmployees(Agent agent, 
            Filter[] filters, long limit, long offset)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelDescribeEmployeesRequest req = new ChannelDescribeEmployeesRequest();

                // 渠道应用相关信息
                req.Agent = agent;
                req.Filters = filters;
                req.Limit = limit;
                req.Offset = offset;
                
                // 返回的resp是一个ChannelDescribeEmployeesResponse的实例，与请求对象对应
                ChannelDescribeEmployeesResponse resp = client.ChannelDescribeEmployeesSync(req);
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
            Filter filter = new Filter();
            filter.Key = "";
            filter.Values = new[] { "" };
            Filter[] filters = { filter };
            long limit = 10;
            long offset = 0;           
            ChannelDescribeEmployeesResponse resp = ChannelDescribeEmployees(Common.getAgent(), 
                filters, limit,  offset);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}