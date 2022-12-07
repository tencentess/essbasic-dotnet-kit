using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelCreateConvertTaskApiService
    {
        public static ChannelCreateConvertTaskApiResponse ChannelCreateConvertTaskApi(Agent agent, String resourceName,
            String resourceId, String resourceType)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelCreateConvertTaskApiRequest req = new ChannelCreateConvertTaskApiRequest();

                // 渠道应用相关信息
                req.Agent = agent;
                req.ResourceName = resourceName;
                req.ResourceId = resourceId;
                req.ResourceType = resourceType;
                
                // 返回的resp是一个ChannelCreateConvertTaskApiResponse的实例，与请求对象对应
                ChannelCreateConvertTaskApiResponse resp = client.ChannelCreateConvertTaskApiSync(req);
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
            String resourceName = "hello.docx";
            String resourceId = "************************";
            String resourceType = "docx";           
            ChannelCreateConvertTaskApiResponse resp = ChannelCreateConvertTaskApi(Common.getAgent(), 
                resourceName, resourceId, resourceType);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}