using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelGetTaskResultApiService
    {
        public static ChannelGetTaskResultApiResponse ChannelGetTaskResultApi(Agent agent, 
            String taskId)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelGetTaskResultApiRequest req = new ChannelGetTaskResultApiRequest();

                // 渠道应用相关信息
                req.Agent = agent;
                req.TaskId = taskId;
                
                // 返回的resp是一个ChannelGetTaskResultApiResponse的实例，与请求对象对应
                ChannelGetTaskResultApiResponse resp = client.ChannelGetTaskResultApiSync(req);
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
            String taskId = "************************";       
            ChannelGetTaskResultApiResponse resp = ChannelGetTaskResultApi(Common.getAgent(), taskId);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}