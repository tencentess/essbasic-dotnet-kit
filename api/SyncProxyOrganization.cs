using System;
using System.IO;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class SyncProxyOrganizationService
    {
        public static SyncProxyOrganizationResponse SyncProxyOrganization(Agent agent, 
            String proxyOrganizationName, String pusinessLicense, String uniformSocialCreditCode, String proxyLegalName)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                
                // 实例化一个请求对象,每个接口都会对应一个request对象
                SyncProxyOrganizationRequest req = new SyncProxyOrganizationRequest();

                req.Agent = agent;

                req.ProxyOrganizationName = proxyOrganizationName;

                req.BusinessLicense = pusinessLicense;

                req.UniformSocialCreditCode = uniformSocialCreditCode;

                req.ProxyLegalName = proxyLegalName;
                
                // 返回的resp是一个SyncProxyOrganizationResponse的实例，与请求对象对应
                SyncProxyOrganizationResponse resp = client.SyncProxyOrganizationSync(req);
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
            String proxyOrganizationName = "************************";
            String pusinessLicense = "************************";
            Byte[] bytes = File.ReadAllBytes("testdata/test_businessLicense.png");
            String uniformSocialCreditCode = Convert.ToBase64String(bytes);
            String proxyLegalName = "************************";
            
            SyncProxyOrganizationResponse resp = SyncProxyOrganization(Common.getAgent(), 
                proxyOrganizationName, pusinessLicense, uniformSocialCreditCode, proxyLegalName);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}