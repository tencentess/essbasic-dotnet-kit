using System;
using System.IO;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class SyncProxyOrganizationOperatorsService
    {
        public static SyncProxyOrganizationOperatorsResponse SyncProxyOrganizationOperators(Agent agent, 
            String operatorType, ProxyOrganizationOperator[] proxyOrganizationOperators)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                
                // 实例化一个请求对象,每个接口都会对应一个request对象
                SyncProxyOrganizationOperatorsRequest req = new SyncProxyOrganizationOperatorsRequest();

                // 渠道应用相关信息
                req.Agent = agent;
                req.OperatorType = operatorType;
                req.ProxyOrganizationOperators = proxyOrganizationOperators;
                
                // 返回的resp是一个SyncProxyOrganizationOperatorsResponse的实例，与请求对象对应
                SyncProxyOrganizationOperatorsResponse resp = client.SyncProxyOrganizationOperatorsSync(req);
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
            String operatorType = "************************";


            ProxyOrganizationOperator proxyOrganizationOperator = new ProxyOrganizationOperator();
            proxyOrganizationOperator.Id = "************************";
            proxyOrganizationOperator.Name = "************************";
            proxyOrganizationOperator.IdCardType = "************************";
            proxyOrganizationOperator.IdCardNumber = "************************";
            proxyOrganizationOperator.Mobile = "************************";
            
            ProxyOrganizationOperator[] proxyOrganizationOperators = { proxyOrganizationOperator };
            
            SyncProxyOrganizationOperatorsResponse resp = SyncProxyOrganizationOperators(Common.getAgent(), 
                operatorType, proxyOrganizationOperators);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}