using System;
using System.IO;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class ChannelCreateFlowGroupByFilesService
    {
        public static ChannelCreateFlowGroupByFilesResponse ChannelCreateFlowGroupByFiles(Agent agent, 
            String flowGroupName, FlowFileInfo[] flowFileInfos)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);
                
                // 实例化一个请求对象,每个接口都会对应一个request对象
                ChannelCreateFlowGroupByFilesRequest req = new ChannelCreateFlowGroupByFilesRequest();

                req.Agent = agent;

                req.FlowGroupName = flowGroupName;

                req.FlowFileInfos = flowFileInfos;
                
                // 返回的resp是一个ChannelCreateFlowGroupByFilesResponse的实例，与请求对象对应
                ChannelCreateFlowGroupByFilesResponse resp = client.ChannelCreateFlowGroupByFilesSync(req);
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
            String flowGroupName = "************************";

            FlowFileInfo flowFileInfo = new FlowFileInfo();
            flowFileInfo.FileIds = new[] { "************************" };
            flowFileInfo.FlowName = "************************";


            FlowApproverInfo flowApprover = new FlowApproverInfo();
            flowApprover.ApproverType = "PERSON";
            flowApprover.Name = "************************";
            flowApprover.Mobile = "************************";

            Component signComponent = new Component();
            signComponent.ComponentType = "SIGN_SIGNATURE";
            signComponent.FileIndex = 0;
            signComponent.ComponentHeight = 100;
            signComponent.ComponentWidth = 100;
            signComponent.ComponentPosX = 100;
            signComponent.ComponentPosY = 100;
            signComponent.ComponentPosY = 100;
            signComponent.ComponentPage = 1;
            
            flowApprover.SignComponents = new[] { signComponent };
            flowFileInfo.FlowApprovers = new[] { flowApprover };
            
            FlowFileInfo[] flowFileInfos = { flowFileInfo, flowFileInfo };
            
            ChannelCreateFlowGroupByFilesResponse resp = ChannelCreateFlowGroupByFiles(Common.getAgent(), 
                flowGroupName, flowFileInfos);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}