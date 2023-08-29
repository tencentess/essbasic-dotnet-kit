using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class OperateChannelTemplateService
    {
        public static OperateChannelTemplateResponse OperateChannelTemplate(Agent agent, 
            String operateType, String templateId, String proxyOrganizationOpenIds, String authTag)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                
                // 实例化一个请求对象,每个接口都会对应一个request对象
                OperateChannelTemplateRequest req = new OperateChannelTemplateRequest();

                req.Agent = agent;

                req.OperateType = operateType;

                req.TemplateId = templateId;

                req.ProxyOrganizationOpenIds = proxyOrganizationOpenIds;

                req.AuthTag = authTag;
                
                // 返回的resp是一个OperateChannelTemplateResponse的实例，与请求对象对应
                OperateChannelTemplateResponse resp = client.OperateChannelTemplateSync(req);
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
            String operateType = "SELECT";
            String templateId = "************************";
            String proxyOrganizationOpenIds = "";
            String authTag = "all";
            OperateChannelTemplateResponse resp = OperateChannelTemplate(Common.getAgent(), 
                operateType, templateId, proxyOrganizationOpenIds, authTag);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}