using System;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class DescribeTemplatesService
    {
        public static DescribeTemplatesResponse DescribeTemplates(Agent agent, String TemplateId)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                
                // 实例化一个请求对象,每个接口都会对应一个request对象
                DescribeTemplatesRequest req = new DescribeTemplatesRequest();

                req.Agent = agent;

                req.TemplateId = TemplateId;

                
                // 返回的resp是一个DescribeTemplatesResponse的实例，与请求对象对应
                DescribeTemplatesResponse resp = client.DescribeTemplatesSync(req);
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
            String templateId = "**************";
            DescribeTemplatesResponse resp = DescribeTemplates(Common.getAgent(), templateId);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}
            