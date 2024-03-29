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
    /// 实体类IView_Dept。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("IView_Dept")]
    [Serializable]
    public partial class IView_Dept : Entity
    {
        #region Model
        private string _ClinicCode;
        private string _ClinicName;
        private string _ID;
        private string _Code;
        private string _PCode;
        private string _Name;
        private int _Status;
        private int? _Type;
        private string _Category;
        private string _Category_Code;
        private string _SearchCode;
        private string _InfectUp;
        private string _Chronic;
        private string _RegionName;

        /// <summary>
        /// 
        /// </summary>
        [Field("ClinicCode")]
        public string ClinicCode
        {
            get { return _ClinicCode; }
            set
            {
                this.OnPropertyValueChange("ClinicCode");
                this._ClinicCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ClinicName")]
        public string ClinicName
        {
            get { return _ClinicName; }
            set
            {
                this.OnPropertyValueChange("ClinicName");
                this._ClinicName = value;
            }
        }
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
        [Field("PCode")]
        public string PCode
        {
            get { return _PCode; }
            set
            {
                this.OnPropertyValueChange("PCode");
                this._PCode = value;
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
        [Field("Status")]
        public int Status
        {
            get { return _Status; }
            set
            {
                this.OnPropertyValueChange("Status");
                this._Status = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Type")]
        public int? Type
        {
            get { return _Type; }
            set
            {
                this.OnPropertyValueChange("Type");
                this._Type = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Category")]
        public string Category
        {
            get { return _Category; }
            set
            {
                this.OnPropertyValueChange("Category");
                this._Category = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Category_Code")]
        public string Category_Code
        {
            get { return _Category_Code; }
            set
            {
                this.OnPropertyValueChange("Category_Code");
                this._Category_Code = value;
            }
        }
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        [Field("InfectUp")]
        public string InfectUp
        {
            get { return _InfectUp; }
            set
            {
                this.OnPropertyValueChange("InfectUp");
                this._InfectUp = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Chronic")]
        public string Chronic
        {
            get { return _Chronic; }
            set
            {
                this.OnPropertyValueChange("Chronic");
                this._Chronic = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("RegionName")]
        public string RegionName
        {
            get { return _RegionName; }
            set
            {
                this.OnPropertyValueChange("RegionName");
                this._RegionName = value;
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
			};
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.ClinicCode,
				_.ClinicName,
				_.ID,
				_.Code,
				_.PCode,
				_.Name,
				_.Status,
				_.Type,
				_.Category,
				_.Category_Code,
				_.SearchCode,
				_.InfectUp,
				_.Chronic,
				_.RegionName,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ClinicCode,
				this._ClinicName,
				this._ID,
				this._Code,
				this._PCode,
				this._Name,
				this._Status,
				this._Type,
				this._Category,
				this._Category_Code,
				this._SearchCode,
				this._InfectUp,
				this._Chronic,
				this._RegionName,
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
            public readonly static Field All = new Field("*", "IView_Dept");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ClinicCode = new Field("ClinicCode", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ClinicName = new Field("ClinicName", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Code = new Field("Code", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PCode = new Field("PCode", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Name = new Field("Name", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Status = new Field("Status", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Type = new Field("Type", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Category = new Field("Category", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Category_Code = new Field("Category_Code", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field SearchCode = new Field("SearchCode", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field InfectUp = new Field("InfectUp", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Chronic = new Field("Chronic", "IView_Dept", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RegionName = new Field("RegionName", "IView_Dept", "");
        }
        #endregion
    }
}