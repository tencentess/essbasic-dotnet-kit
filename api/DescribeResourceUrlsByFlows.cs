using System;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class DescribeResourceUrlsByFlowsService
    {
        public static DescribeResourceUrlsByFlowsResponse DescribeResourceUrlsByFlows(Agent agent, String[] flowIds)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                // 实例化一个请求对象,每个接口都会对应一个request对象
                DescribeResourceUrlsByFlowsRequest req = new DescribeResourceUrlsByFlowsRequest();

                req.Agent = agent;

                req.FlowIds = flowIds;

                // 返回的resp是一个DescribeResourceUrlsByFlowsResponse的实例，与请求对象对应
                DescribeResourceUrlsByFlowsResponse resp = client.DescribeResourceUrlsByFlowsSync(req);
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
            string flowId = "********";
            DescribeResourceUrlsByFlowsResponse resp = DescribeResourceUrlsByFlows(Common.getAgent(), new String[]{flowId});
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}
            