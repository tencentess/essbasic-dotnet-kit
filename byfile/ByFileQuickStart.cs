using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;
using api;

namespace byfile
{
    class ByFileQuickStart
    {
        static void Main1(string[] args)
        {
            // Step 1
            // 定义文件所在的路径
            String filePath = "testdata/test.pdf";
            // 定义合同名
            String flowName = "我的第一个合同";

            String proxyOrganizationName = "我的企业";
            // 创建控制台链接
            CreateConsoleLoginUrlResponse loginUrlResponse =
                    CreateConsoleLoginUrlService.CreateConsoleLoginUrl(Common.getAgent(), proxyOrganizationName);


            // 此处为快速发起；如果是正式接入，构造签署人，请参考函数内说明，构造需要的场景参数
            FlowApproverInfo[] flowApproverInfos = ByFile.BuildApprovers();

            // Step 2
            // 将文件处理为Base64编码后的文件内容
            Byte[] bytes = File.ReadAllBytes(filePath);
            String fileBase64 = Convert.ToBase64String(bytes);

            // 发起合同
            // CreateFlowByFileDirectly createFlowByFileDirectly = new CreateFlowByFileDirectly();
            Dictionary<String, String> resp = CreateFlowByFileDirectly.ChannelCreateFlowByFilesDirectly
                    (fileBase64, flowApproverInfos, flowName);

            //  返回相关信息
            Console.WriteLine("您的控制台入口为：");
            Console.WriteLine(loginUrlResponse.ConsoleUrl);
            Console.WriteLine("\r\n\r\n");

            // 返回合同Id
            Console.WriteLine("您创建的合同id为：");
            Console.WriteLine(resp["flowId"]);
            Console.WriteLine("\r\n\r\n");
            // 返回签署的链接
            Console.WriteLine("签署链接为：");
            Console.WriteLine(resp["url"]);
            Console.WriteLine("\r\n\r\n");
            // Step 3
            // 下载合同
            // 返回合同下载链接
            DescribeResourceUrlsByFlowsResponse urlResp = DescribeResourceUrlsByFlowsService.DescribeResourceUrlsByFlows(Common.getAgent(),new String[]{resp["flowId"]} );
            Console.WriteLine("请访问以下地址下载您的合同：");
            Console.WriteLine(urlResp.FlowResourceUrlInfos[0].ResourceUrlInfos[0].Url);
            Console.WriteLine("\r\n\r\n");
            
        }
    }
}
            