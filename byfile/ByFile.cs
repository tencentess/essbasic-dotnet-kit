using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Essbasic.V20210526;
using TencentCloud.Essbasic.V20210526.Models;

namespace byfile
{
    class ByFile
    {
        // 构造签署人 - 以个人为例, 实际请根据自己的场景构造签署方、控件
        public static FlowApproverInfo[] BuildApprovers()
        {

            // 个人签署方参数
            String personName = "********";
            String personMobile = "********";

            // 企业签署方参数
            //String organizationName = "*********";
            //String organizationOpenId = "***************";
            //String openId = "*********";

            // 用列表存储(此处根据自己签署的类型选择对应的传入参数，
            // 如单c就只传入一次个人签署方，BtoC就传入一次个人签署方，一次企业签署方)
            List<FlowApproverInfo> flowApproverInfoList = new List<FlowApproverInfo>();

            // 传入个人签署方
            flowApproverInfoList.Add(BuildPersonApprover(personName, personMobile));

            // 传入企业签署方
            // flowApproverInfoList.add(BuildOrganizationApprover(organizationName, organizationOpenId, openId));

            // 传入企业静默签署
            // flowApproverInfoList.add(BuildServerSignApprover());

            // 转换为对象数组
            FlowApproverInfo[] flowApproverInfo = flowApproverInfoList.ToArray();

            return flowApproverInfo;
        }

        // 打包个人签署方参与者信息
        public static FlowApproverInfo BuildPersonApprover(String name, String mobile)
        {
            // 签署参与者信息
            // 个人签署方
            FlowApproverInfo flowApproverInfo = new FlowApproverInfo();

            flowApproverInfo.ApproverType = "PERSON";

            flowApproverInfo.Name = name;
            flowApproverInfo.Mobile = mobile;

            // 这里简单定义一个个人手写签名的签署控件
            Component componentAdd = BuildComponent(146.15625F, 472.78125F, 112F,
                    40F, 0L, "SIGN_SIGNATURE", 1L, "");
            Component[] component = new Component[] { componentAdd };
            flowApproverInfo.SignComponents = component;

            return flowApproverInfo;
        }

        // 打包企业签署方参与者信息
        public static FlowApproverInfo BuildOrganizationApprover(String organizationName, String organizationOpenId, String openId)
        {
            // 签署参与者信息
            // 企业签署方
            FlowApproverInfo flowApproverInfo = new FlowApproverInfo();

            flowApproverInfo.ApproverType = "ORGANIZATION";

            flowApproverInfo.OrganizationName = organizationName;

            flowApproverInfo.OrganizationOpenId = organizationOpenId;

            flowApproverInfo.OpenId = openId;

            // 这里简单定义一个个人手写签名的签署控件
            Component componentAdd = BuildComponent(146.15625F, 472.78125F, 112F,
                    40F, 0L, "SIGN_SIGNATURE", 1L, "");
            Component[] component = new Component[] { componentAdd };
            flowApproverInfo.SignComponents = component;

            return flowApproverInfo;
        }

        // 打包企业静默签署方参与者信息
        public static FlowApproverInfo BuildServerSignApprover()
        {
            // 签署参与者信息
            // 企业静默签
            FlowApproverInfo flowApproverInfo = new FlowApproverInfo();

            flowApproverInfo.ApproverType = "ENTERPRISESERVER";

            // 这里简单定义一个个人手写签名的签署控件
            Component componentAdd = BuildComponent(146.15625F, 472.78125F, 112F,
                    40F, 0L, "SIGN_SIGNATURE", 1L, "");
            Component[] component = new Component[] { componentAdd };
            flowApproverInfo.SignComponents = component;

            return flowApproverInfo;
        }

        public static Component BuildComponent(float componentPosX, float componentPosY, float componentWidth,
                                               float componentHeight, long fileIndex, String componentType,
                                               long componentPage, String componentValue)
        {
            Component component = new Component();

            component.ComponentPosX = componentPosX;

            component.ComponentPosY = componentPosY;

            component.ComponentWidth = componentWidth;

            component.ComponentHeight = componentHeight;

            component.FileIndex = fileIndex;

            component.ComponentPage = componentPage;

            component.ComponentType = componentType;
            component.ComponentValue = componentValue;

            return component;
        }
    }
}
