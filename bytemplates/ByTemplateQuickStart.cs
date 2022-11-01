using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;
using api;

namespace bytemplate
{
    class ByTemplateQuickStart
    {
        static void Main(string[] args)
        {
            // Step 1
            // 定义合同名
            String flowName = "我的第2个合同";
            String proxyOrganizationName = "我的企业";

            // 模板Id，根据自己传入的模板需求修改第三个参数为对应的TemplateId，在Config中配置
            String templateId = Configs.templateId;

            // 创建控制台链接
            CreateConsoleLoginUrlResponse loginUrlResponse =
                    CreateConsoleLoginUrlService.CreateConsoleLoginUrl(Common.getAgent(), proxyOrganizationName);


            //Step 2
            // 获取模板里面的RecipientId
            Recipient[] recipients = ByTemplate.GetRecipients(templateId);
            if (recipients == null)
            {
                throw new Exception("签署人不能为空");
            }

            //step 3
            //构造签署人信息
            FlowApproverInfo[] flowApproverInfos = ByTemplate.BuildApprovers(new List<Recipient>(recipients));

            // Step 4
            // 发起合同
            // 样例为BtoC
            Dictionary<String, String[]> resp = CreateFlowByTemplateDirectly.ChannelCreateFlowByTemplateDirectly(flowName,
                     templateId, flowApproverInfos);


            //  返回相关信息
            Console.WriteLine("您的控制台入口为：");
            Console.WriteLine(loginUrlResponse.ConsoleUrl);
            Console.WriteLine("\r\n\r\n");
            int count = Configs.count;
            for (int i = 0; i < count; i++)
            {
                // 返回合同Id
                Console.WriteLine("您创建的合同id为：");
                Console.WriteLine(resp["FlowIds"][i]);
                Console.WriteLine("\r\n\r\n");
                // 返回签署的链接
                Console.WriteLine("签署链接为：");
                Console.WriteLine(resp["Urls"][i]);
                Console.WriteLine("\r\n\r\n");
                // Step 5
                // 下载合同
                // 返回合同下载链接
                DescribeResourceUrlsByFlowsResponse urlResp = DescribeResourceUrlsByFlowsService.DescribeResourceUrlsByFlows(Common.getAgent(),new String[]{resp["FlowIds"][i]} );
                Console.WriteLine("请访问以下地址下载您的合同：");
                Console.WriteLine(urlResp.FlowResourceUrlInfos[0].ResourceUrlInfos[0].Url);
                Console.WriteLine("\r\n\r\n");
            }
        }
    }
}
