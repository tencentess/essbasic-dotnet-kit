using System;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class GetDownloadFlowUrlService
    {
        static GetDownloadFlowUrlResponse GetDownloadFlowUrl(Agent agent, DownloadFlowInfo[] downLoadFlows)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                // 实例化一个请求对象,每个接口都会对应一个request对象
                GetDownloadFlowUrlRequest req = new GetDownloadFlowUrlRequest();

                req.Agent = agent;

                req.DownLoadFlows = downLoadFlows;
                
                // 返回的resp是一个GetDownloadFlowUrlResponse的实例，与请求对象对应
                GetDownloadFlowUrlResponse resp = client.GetDownloadFlowUrlSync(req);
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
            DownloadFlowInfo downloadFlowInfo = new DownloadFlowInfo();
            downloadFlowInfo.FileName = "***";
            string flowId = "********";
            downloadFlowInfo.FlowIdList = new String[]{flowId};
            GetDownloadFlowUrlResponse resp = GetDownloadFlowUrl(Common.getAgent(), new DownloadFlowInfo[]{downloadFlowInfo});
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}
            