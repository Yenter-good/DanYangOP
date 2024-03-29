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
    /// 实体类OP_Dic_CommonICD。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("OP_Dic_CommonICD")]
    [Serializable]
    public partial class OP_Dic_CommonICD : Entity
    {
        #region Model
        private string _ID;
        private string _Code;
        private string _Name;
        private string _SearchCode;
        private string _DeptCode;
        private string _Updater;
        private DateTime? _UpdateTime;
        private string _Type;

        /// <summary>
        /// ID
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
        /// ICD编码
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
        /// 诊断名称
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
        /// 检索码
        /// </summary>
        [Field("SearchCode")]
        public string SearchCode
        {
            get { return _SearchCode; }
            set
            {
                this.OnPropertyValueChange("SearchCode");
                this._SearchCode = value;
            }
        }
        /// <summary>
        /// 科室编号
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
        /// 更新人员
        /// </summary>
        [Field("Updater")]
        public string Updater
        {
            get { return _Updater; }
            set
            {
                this.OnPropertyValueChange("Updater");
                this._Updater = value;
            }
        }
        /// <summary>
        /// 更新时间
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
        /// 诊断类型
        /// </summary>
        [Field("DiagnosisType")]
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
				_.Code,
				_.Name,
				_.SearchCode,
				_.DeptCode,
				_.Updater,
				_.UpdateTime,
				_.Type,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._Code,
				this._Name,
				this._SearchCode,
				this._DeptCode,
				this._Updater,
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
            public readonly static Field All = new Field("*", "OP_Dic_CommonICD");
            /// <summary>
            /// ID
            /// </summary>
            public readonly static Field ID = new Field("ID", "OP_Dic_CommonICD", "ID");
            /// <summary>
            /// ICD编码
            /// </summary>
            public readonly static Field Code = new Field("Code", "OP_Dic_CommonICD", "ICD编码");
            /// <summary>
            /// 诊断名称
            /// </summary>
            public readonly static Field Name = new Field("Name", "OP_Dic_CommonICD", "诊断名称");
            /// <summary>
            /// 检索码
            /// </summary>
            public readonly static Field SearchCode = new Field("SearchCode", "OP_Dic_CommonICD", "检索码");
            /// <summary>
            /// 科室编号
            /// </summary>
            public readonly static Field DeptCode = new Field("DeptCode", "OP_Dic_CommonICD", "科室编号");
            /// <summary>
            /// 更新人员
            /// </summary>
            public readonly static Field Updater = new Field("Updater", "OP_Dic_CommonICD", "更新人员");
            /// <summary>
            /// 更新时间
            /// </summary>
            public readonly static Field UpdateTime = new Field("UpdateTime", "OP_Dic_CommonICD", "更新时间");
            /// <summary>
            /// 诊断类型
            /// </summary>
            public readonly static Field Type = new Field("Type", "OP_Dic_CommonICD", "诊断类型");
        }
        #endregion
    }
}