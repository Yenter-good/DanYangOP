﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
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
    /// 实体类OP_UserInterval。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("OP_UserInterval")]
    [Serializable]
    public partial class OP_UserInterval : Entity
    {
        #region Model
        private string _ID;
        private string _UserID;
        private string _Code;
        private int? _Count;
        private string _Name;
        private int _No;

        /// <summary>
        /// 
        /// </summary>
        [Field("ID")]
        public string ID
        {
            get { return _ID; }
            set
            {
                this.OnPropertyValueChange("ID");
                this._ID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("UserID")]
        public string UserID
        {
            get { return _UserID; }
            set
            {
                this.OnPropertyValueChange("UserID");
                this._UserID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Code")]
        public string Code
        {
            get { return _Code; }
            set
            {
                this.OnPropertyValueChange("Code");
                this._Code = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Count")]
        public int? Count
        {
            get { return _Count; }
            set
            {
                this.OnPropertyValueChange("Count");
                this._Count = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Name")]
        public string Name
        {
            get { return _Name; }
            set
            {
                this.OnPropertyValueChange("Name");
                this._Name = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("No")]
        public int No
        {
            get { return _No; }
            set
            {
                this.OnPropertyValueChange("No");
                this._No = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
                _.ID,
            };
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
                _.ID,
                _.UserID,
                _.Code,
                _.Name,
                _.No,
                _.Count,
            };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                this._ID,
                this._UserID,
                this._Code,
                this._Name,
                this._No,
                this._Count
            };
        }
        /// <summary>
        /// 是否是v1.10.5.6及以上版本实体。
        /// </summary>
        /// <returns></returns>
        public override bool V1_10_5_6_Plus()
        {
            return true;
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
            public readonly static Field All = new Field("*", "OP_UserInterval");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID", "OP_UserInterval", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field UserID = new Field("UserID", "OP_UserInterval", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field Code = new Field("Code", "OP_UserInterval", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Name = new Field("Name", "OP_UserInterval", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field No = new Field("No", "OP_UserInterval", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Count = new Field("Count", "OP_UserInterval", "");
        }
        #endregion
    }
}