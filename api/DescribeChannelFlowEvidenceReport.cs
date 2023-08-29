using System;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class DescribeChannelFlowEvidenceReportService
    {
        public static DescribeChannelFlowEvidenceReportResponse DescribeChannelFlowEvidenceReport(Agent agent, 
            String reportId)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                DescribeChannelFlowEvidenceReportRequest req = new DescribeChannelFlowEvidenceReportRequest();

                req.Agent = agent;

                req.ReportId = reportId;
                
                // 返回的resp是一个DescribeChannelFlowEvidenceReportResponse的实例，与请求对象对应
                DescribeChannelFlowEvidenceReportResponse resp = client.DescribeChannelFlowEvidenceReportSync(req);
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
            String reportId = "************************";       
            DescribeChannelFlowEvidenceReportResponse resp = DescribeChannelFlowEvidenceReport(Common.getAgent(), reportId);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}