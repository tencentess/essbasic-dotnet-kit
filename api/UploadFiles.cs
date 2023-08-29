using System;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class UploadFilesService
    {
        public static UploadFilesResponse UploadFiles(Agent agent,string fileBase64, string filename)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.fileServiceEndPoint);
                // 实例化一个请求对象,每个接口都会对应一个request对象
                UploadFilesRequest req = new UploadFilesRequest();


                req.Agent = agent;

                req.BusinessType="DOCUMENT";

                UploadFile file = new UploadFile();

                file.FileBody = fileBase64;

                file.FileName = filename;

                req.FileInfos = new UploadFile[] { file };

                // 返回的resp是一个UploadFilesResponse的实例，与请求对象对应
                UploadFilesResponse resp = client.UploadFilesSync(req);
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
            string fileBase64 = "********";
            string filename = "********";
            UploadFilesResponse resp = UploadFiles(Common.getAgent(), fileBase64, filename);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}
            