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
using System.Data;
using System.Data.Common;
using Dos.ORM;
using Dos.ORM.Common;

namespace CIS.Model
{

    /// <summary>
    /// 实体类OP_Log_InOut 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("OP_Log_InOut")]
    [Serializable]
    public partial class OP_Log_InOut : Entity
    {
        #region Model
        private string _UserCode;
        private DateTime _OperationDate;
        private DateTime _OperationTime;
        private int _OperationType;
        private string _IP;
        /// <summary>
        /// 
        /// </summary>
        public string UserCode
        {
            get { return _UserCode; }
            set
            {
                this.OnPropertyValueChange(_.UserCode, _UserCode, value);
                this._UserCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OperationDate
        {
            get { return _OperationDate; }
            set
            {
                this.OnPropertyValueChange(_.OperationDate, _OperationDate, value);
                this._OperationDate = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OperationTime
        {
            get { return _OperationTime; }
            set
            {
                this.OnPropertyValueChange(_.OperationTime, _OperationTime, value);
                this._OperationTime = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OperationType
        {
            get { return _OperationType; }
            set
            {
                this.OnPropertyValueChange(_.OperationType, _OperationType, value);
                this._OperationType = value;
            }
        }
        /// <summary>
		/// 
		/// </summary>
		public string IP
        {
            get { return _IP; }
            set
            {
                this.OnPropertyValueChange(_.IP, _IP, value);
                this._IP = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
                _.UserCode,
                _.OperationDate,
                _.OperationTime,
                _.OperationType,
            _.IP};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                this._UserCode,
                this._OperationDate,
                this._OperationTime,
                this._OperationType,
            this._IP};
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
            public readonly static Field All = new Field("*", "OP_Log_InOut");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UserCode = new Field("UserCode", "OP_Log_InOut", "UserCode");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OperationDate = new Field("OperationDate", "OP_Log_InOut", "OperationDate");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OperationTime = new Field("OperationTime", "OP_Log_InOut", "OperationTime");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OperationType = new Field("OperationType", "OP_Log_InOut", "OperationType");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IP = new Field("IP", "OP_Log_InOut", "IP");
        }
        #endregion


    }
}

