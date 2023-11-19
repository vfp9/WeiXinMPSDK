﻿/*----------------------------------------------------------------
    Copyright (C) 2023 XiaoPoTian
    
    文件名：RequestMessageEvent_Change_External_Tag_Base.cs
    文件功能描述：企业客户标签或标签组事件
    
    
    创建标识：XiaoPoTian - 20231119
    
----------------------------------------------------------------*/

using System;

namespace Senparc.Weixin.Work.Entities
{
    /// <summary>
    /// 企业客户标签或标签组事件
    /// </summary>
    public class RequestMessageEvent_Change_External_Tag_Base : RequestMessageEventBase, IRequestMessageEventBase
    {
        public override Event Event
        {
            get { return Event.CHANGE_EXTERNAL_TAG; }
        }

        /// <summary>
        /// 标签或标签组ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 标签或标签组所属的规则组id，只回调给“客户联系”应用
        /// </summary>
        public string StrategyId { get; set; }

        public virtual ExternalTagChangeType ChangeType { get { return ExternalTagChangeType.create; } }
    }

    /// <summary>
    /// 企业客户标签创建
    /// </summary>
    public class RequestMessageEvent_Change_External_Tag_Create : RequestMessageEvent_Change_External_Tag_Base
    {
        /// <summary>
        /// 变更类型
        /// </summary>
        public ExternalTagChangeTagType TagType { get; set; }
        public RequestMessageEvent_Change_External_Tag_Create(string TagTypeStr)
        {
            TagType = (ExternalTagChangeTagType)Enum.Parse(typeof(ExternalTagChangeTagType), TagTypeStr, true);
        }
    }

    /// <summary>
    /// 企业客户标签变更
    /// </summary>
    public class RequestMessageEvent_Change_External_Tag_Update : RequestMessageEvent_Change_External_Tag_Base
    {
        /// <summary>
        /// 变更类型
        /// </summary>
        public ExternalTagChangeTagType TagType { get; set; }
        public RequestMessageEvent_Change_External_Tag_Update(string TagTypeStr)
        {
            TagType = (ExternalTagChangeTagType)Enum.Parse(typeof(ExternalTagChangeTagType), TagTypeStr, true);
        }
        public override ExternalTagChangeType ChangeType => ExternalTagChangeType.update;

    }

    /// <summary>
    /// 企业客户标签删除
    /// </summary>
    public class RequestMessageEvent_Change_External_Tag_Delete : RequestMessageEvent_Change_External_Tag_Base
    {
        /// <summary>
        /// 变更类型
        /// </summary>
        public ExternalTagChangeTagType TagType { get; set; }
        public RequestMessageEvent_Change_External_Tag_Delete(string TagTypeStr)
        {
            TagType = (ExternalTagChangeTagType)Enum.Parse(typeof(ExternalTagChangeTagType), TagTypeStr, true);
        }
        public override ExternalTagChangeType ChangeType => ExternalTagChangeType.delete;
    }

    /// <summary>
    /// 企业客户标签重排
    /// </summary>
    public class RequestMessageEvent_Change_External_Tag_Shuffle : RequestMessageEvent_Change_External_Tag_Base
    {
        public override ExternalTagChangeType ChangeType => ExternalTagChangeType.shuffle;
    }



    public enum ExternalTagChangeType
    {
        /// <summary>
        /// 创建
        /// </summary>
        create,
        /// <summary>
        /// 更新
        /// </summary>
        update,
        /// <summary>
        /// 删除
        /// </summary>
        delete,
        /// <summary>
        /// 重新排序
        /// </summary>
        shuffle,
    }

    /// <summary>
    /// 变更类型
    /// </summary>
    public enum ExternalTagChangeTagType
    {
        /// <summary>
        /// 变更标签
        /// </summary>
        tag,
        /// <summary>
        /// 变更标签组
        /// </summary>
        tag_group,
    }
}
