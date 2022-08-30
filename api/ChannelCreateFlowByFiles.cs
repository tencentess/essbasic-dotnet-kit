using System;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelCreateFlowByFilesService
    {
        public static ChannelCreateFlowByFilesResponse ChannelCreateFlowByFiles(Agent agent, FlowApproverInfo[] flowApproverInfos, String flowName, String fileId)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                
                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelCreateFlowByFilesRequest req = new ChannelCreateFlowByFilesRequest();

                req.Agent = agent;

                 // 签署pdf文件的资源编号列表，通过UploadFiles接口获取
                req.FileIds = new string[] { fileId };

                // 签署流程参与者信息
                req.FlowApprovers = flowApproverInfos;

                // 签署流程名称,最大长度200个字符
                req.FlowName = flowName;
                
                // 返回的resp是一个ChannelCreateFlowByFilesResponse的实例，与请求对象对应
                ChannelCreateFlowByFilesResponse resp = client.ChannelCreateFlowByFilesSync(req);
                // 输出json格式的字符串回包
                // Console.WriteLine(AbstractModel.ToJsonString(resp));
                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            // Console.Read();
            return null;
        }
    }
}