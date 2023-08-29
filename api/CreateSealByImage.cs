using System;
using System.IO;
using TencentCloud.Common;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace api
{
    class CreateSealByImageService
    {
        public static CreateSealByImageResponse CreateSealByImage(Agent agent, 
            String sealName, String sealImage)
        {
            try
            {
                // 构造客户端调用实例
                EssbasicClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

                // 实例化一个请求对象,每个接口都会对应一个request对象
                CreateSealByImageRequest req = new CreateSealByImageRequest();

                req.Agent = agent;

                req.SealName = sealName;

                req.SealImage = sealImage;
                
                // 返回的resp是一个CreateSealByImageResponse的实例，与请求对象对应
                CreateSealByImageResponse resp = client.CreateSealByImageSync(req);
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
            String sealName = "************************";   
            Byte[] bytes = File.ReadAllBytes("testdata/test_seal.png");
            String sealImage = Convert.ToBase64String(bytes);
            CreateSealByImageResponse resp = CreateSealByImage(Common.getAgent(), sealName, sealImage);
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}