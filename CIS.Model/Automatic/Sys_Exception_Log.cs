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
    /// 实体类Sys_Exception_Log。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_Exception_Log")]
    [Serializable]
    public partial class Sys_Exception_Log : Entity
    {
        #region Model
        private string _ID;
        private string _ExceptionText;
        private string _UserID;
        private string _UserName;
        private string _DeptCode;
        private string _DeptName;
        private string _Type;
        private DateTime? _UpdateTime;

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
        [Field("ExceptionText")]
        public string ExceptionText
        {
            get { return _ExceptionText; }
            set
            {
                this.OnPropertyValueChange("ExceptionText");
                this._ExceptionText = value;
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
        [Field("UserName")]
        public string UserName
        {
            get { return _UserName; }
            set
            {
                this.OnPropertyValueChange("UserName");
                this._UserName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("DeptCode")]
        public string DeptCode
        {
            get { return _DeptCode; }
            set
            {
                this.OnPropertyValueChange("DeptCode");
                this._DeptCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("DeptName")]
        public string DeptName
        {
            get { return _DeptName; }
            set
            {
                this.OnPropertyValueChange("DeptName");
                this._DeptName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("UpdateTime")]
        public DateTime? UpdateTime
        {
            get { return _UpdateTime; }
            set
            {
                this.OnPropertyValueChange("UpdateTime");
                this._UpdateTime = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Type")]
        public string Type
        {
            get { return _Type; }
            set
            {
                this.OnPropertyValueChange("Type");
                this._Type = value;
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
                _.ExceptionText,
                _.UserID,
                _.UserName,
                _.DeptCode,
                _.DeptName,
                _.UpdateTime,
                _.Type
            };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                this._ID,
                this._ExceptionText,
                this._UserID,
                this._UserName,
                this._DeptCode,
                this._DeptName,
                this._UpdateTime,
                this._Type,
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
            public readonly static Field All = new Field("*", "Sys_Exception_Log");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "Sys_Exception_Log", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ExceptionText = new Field("ExceptionText", "Sys_Exception_Log", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UserID = new Field("UserID", "Sys_Exception_Log", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UserName = new Field("UserName", "Sys_Exception_Log", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DeptCode = new Field("DeptCode", "Sys_Exception_Log", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DeptName = new Field("DeptName", "Sys_Exception_Log", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UpdateTime = new Field("UpdateTime", "Sys_Exception_Log", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Type = new Field("Type", "Sys_Exception_Log", "");
        }
        #endregion
    }
}