﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//     Website: http://ITdos.com/Dos/ORM/Index.html
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using Dos.ORM;

namespace CIS.Model
{

    /// <summary>
    /// 实体类IView_Inside_ExamineGroup 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("IView_Inside_ExamineGroup")]
    [Serializable]
    public partial class IView_Inside_ExamineGroup : Entity
    {
        #region Model
        private string _ID;
        private string _ParentID;
        private string _GroupType;
        private string _Name;
        private int _No;
        private string _Owner;
        private string _GroupID;
        private int _GroupLevel;
        private string _NickName;
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set
            {
                this.OnPropertyValueChange(_.ID, _ID, value);
                this._ID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentID
        {
            get { return _ParentID; }
            set
            {
                this.OnPropertyValueChange(_.ParentID, _ParentID, value);
                this._ParentID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupType
        {
            get { return _GroupType; }
            set
            {
                this.OnPropertyValueChange(_.GroupType, _GroupType, value);
                this._GroupType = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set
            {
                this.OnPropertyValueChange(_.Name, _Name, value);
                this._Name = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int No
        {
            get { return _No; }
            set
            {
                this.OnPropertyValueChange(_.No, _No, value);
                this._No = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Owner
        {
            get { return _Owner; }
            set
            {
                this.OnPropertyValueChange(_.Owner, _Owner, value);
                this._Owner = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupID
        {
            get { return _GroupID; }
            set
            {
                this.OnPropertyValueChange(_.GroupID, _GroupID, value);
                this._GroupID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GroupLevel
        {
            get { return _GroupLevel; }
            set
            {
                this.OnPropertyValueChange(_.GroupLevel, _GroupLevel, value);
                this._GroupLevel = value;
            }
        }

        public string NickName
        {
            get { return _NickName; }
            set
            {
                this.OnPropertyValueChange(_.NickName, _NickName, value);
                this._NickName = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 是否只读
        /// </summary>
        public override bool IsReadOnly()
        {
            return true;
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.ID,
				_.ParentID,
				_.GroupType,
				_.Name,
				_.No,
				_.Owner,
				_.GroupID,
				_.GroupLevel,
            _.NickName};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._ParentID,
				this._GroupType,
				this._Name,
				this._No,
				this._Owner,
				this._GroupID,
				this._GroupLevel,
            this._NickName};
        }
        #endregion

        #region _Field
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
            /// <summary>
            /// * 
            /// </summary>
            public readonly static Field All = new Field("*", "IView_Inside_ExamineGroup");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "IView_Inside_ExamineGroup", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ParentID = new Field("ParentID", "IView_Inside_ExamineGroup", "ParentID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field GroupType = new Field("GroupType", "IView_Inside_ExamineGroup", "GroupType");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Name = new Field("Name", "IView_Inside_ExamineGroup", "Name");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field No = new Field("No", "IView_Inside_ExamineGroup", "No");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Owner = new Field("Owner", "IView_Inside_ExamineGroup", "Owner");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field GroupID = new Field("GroupID", "IView_Inside_ExamineGroup", "GroupID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field GroupLevel = new Field("GroupLevel", "IView_Inside_ExamineGroup", "GroupLevel");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field NickName = new Field("NickName", "IView_Inside_ExamineGroup", "NickName");
        }
        #endregion


    }
}
