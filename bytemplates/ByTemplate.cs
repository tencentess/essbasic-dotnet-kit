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
    class ByTemplate
    {
        // 构造签署人 - 以个人为例, 实际请根据自己的场景构造签署方、控件
        public static FlowApproverInfo[] BuildApprovers(List<Recipient> recipients)
        {

            // 个人签署方参数
            String personName = "********";
            String personMobile = "*********";

            // 企业签署方参数
            String organizationName = "*********";
            String organizationOpenId = "***************";
            String openId = "*********";

            List<FlowApproverInfo> flowApproverInfoList = new List<FlowApproverInfo>();
            foreach (Recipient recipient in recipients)
            {
                switch (recipient.RecipientType)
                {
                    case "INDIVIDUAL":
                        flowApproverInfoList.Add(BuildPersonApprover(personName, personMobile, recipient.RecipientId));
                        break;
                    case "ENTERPRISE":
                        flowApproverInfoList.Add(BuildOrganizationApprover(organizationName, organizationOpenId, openId, recipient.RecipientId));
                        break;

                }
            }

            // 转换为对象数组
            FlowApproverInfo[] flowApproverInfo = flowApproverInfoList.ToArray();


            return flowApproverInfo;
        }

        // 打包个人签署方参与者信息
        public static FlowApproverInfo BuildPersonApprover(String name, String mobile, String recipientId)
        {

            // 签署参与者信息
            // 个人签署方
            FlowApproverInfo flowApproverInfo = new FlowApproverInfo();
            // 签署人类型，PERSON-个人；
            // ORGANIZATION-企业；
            // ENTERPRISESERVER-企业静默签;
            // 注：ENTERPRISESERVER 类型仅用于使用文件创建流程（ChannelCreateFlowByFiles）接口；并且仅能指定发起方企业签署方为静默签署；
            flowApproverInfo.ApproverType = "PERSON";
            // 本环节需要操作人的名字
            flowApproverInfo.Name = name;
            // 本环节需要操作人的手机号
            flowApproverInfo.Mobile = mobile;

            flowApproverInfo.RecipientId = recipientId;

            return flowApproverInfo;
        }

        // 打包企业签署方参与者信息
        public static FlowApproverInfo BuildOrganizationApprover(String organizationName, String organizationOpenId, String openId, String recipientId)
        {

            // 签署参与者信息
            // 个人签署方
            FlowApproverInfo flowApproverInfo = new FlowApproverInfo();
            // 签署人类型，PERSON-个人；
            // ORGANIZATION-企业；
            // ENTERPRISESERVER-企业静默签;
            // 注：ENTERPRISESERVER 类型仅用于使用文件创建流程（ChannelCreateFlowByFiles）接口；并且仅能指定发起方企业签署方为静默签署；
            flowApproverInfo.ApproverType = "ORGANIZATION";
            // 本环节需要企业操作人的企业名称
            flowApproverInfo.OrganizationName = organizationName;
            //
            flowApproverInfo.OrganizationOpenId = organizationOpenId;
            flowApproverInfo.OpenId = openId;

            flowApproverInfo.RecipientId = recipientId;

            return flowApproverInfo;
        }

        // 打包企业静默签署方参与者信息
        public static FlowApproverInfo BuildServerSignApprover()
        {
            // 签署参与者信息
            // 个人签署方
            FlowApproverInfo flowApproverInfo = new FlowApproverInfo();
            // 签署人类型，PERSON-个人；
            // ORGANIZATION-企业；
            // ENTERPRISESERVER-企业静默签;
            // 注：ENTERPRISESERVER 类型仅用于使用文件创建流程（ChannelCreateFlowByFiles）接口；并且仅能指定发起方企业签署方为静默签署；
            flowApproverInfo.ApproverType = "ENTERPRISESERVER";

            return flowApproverInfo;
        }

        //获取所有签署人信息
        public static Recipient[] GetRecipients(String templateId)
        {
            Agent agent = Common.getAgent();
            DescribeTemplatesResponse templatesResponse = DescribeTemplatesService.DescribeTemplates(agent,
                    templateId);
            return templatesResponse.Templates[0].Recipients;
        }


    }
}
