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
    /// 实体类OP_HospitalizedReport。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("OP_HospitalizedReport")]
    [Serializable]
    public partial class OP_HospitalizedReport : Entity
    {
        #region Model
        private string _ID;
        private string _Content;
        private string _DoctorID;
        private string _DeptCode;
        private string _DoctorName;
        private string _DeptName;
        private string _TreatmentNo;
        private string _InHosType;
        private string _PatientName;
        private string _PatientSex;
        private string _PatientAge;
        private string _PatientAddress;
        private string _PatientPhoneNumber;
        private string _HMDiagnosis;
        private string _WMDiagnosis;
        private string _InHosDept;
        private string _InHosNurseArea;
        private string _InHosBedNo;
        private string _Advice;
        private string _Note;
        private string _ContantName;
        private string _ContantRelation;
        private string _ContantPhoneNumber;

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

        public DateTime? ProcessTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field("Content")]
        public string Content
        {
            get { return _Content; }
            set
            {
                this.OnPropertyValueChange("Content");
                this._Content = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("DoctorID")]
        public string DoctorID
        {
            get { return _DoctorID; }
            set
            {
                this.OnPropertyValueChange("DoctorID");
                this._DoctorID = value;
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
        [Field("DoctorName")]
        public string DoctorName
        {
            get { return _DoctorName; }
            set
            {
                this.OnPropertyValueChange("DoctorName");
                this._DoctorName = value;
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
        [Field("TreatmentNo")]
        public string TreatmentNo
        {
            get { return _TreatmentNo; }
            set
            {
                this.OnPropertyValueChange("TreatmentNo");
                this._TreatmentNo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("InHosType")]
        public string InHosType
        {
            get { return _InHosType; }
            set
            {
                this.OnPropertyValueChange("InHosType");
                this._InHosType = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("PatientName")]
        public string PatientName
        {
            get { return _PatientName; }
            set
            {
                this.OnPropertyValueChange("PatientName");
                this._PatientName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("PatientSex")]
        public string PatientSex
        {
            get { return _PatientSex; }
            set
            {
                this.OnPropertyValueChange("PatientSex");
                this._PatientSex = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("PatientAge")]
        public string PatientAge
        {
            get { return _PatientAge; }
            set
            {
                this.OnPropertyValueChange("PatientAge");
                this._PatientAge = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("PatientAddress")]
        public string PatientAddress
        {
            get { return _PatientAddress; }
            set
            {
                this.OnPropertyValueChange("PatientAddress");
                this._PatientAddress = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("PatientPhoneNumber")]
        public string PatientPhoneNumber
        {
            get { return _PatientPhoneNumber; }
            set
            {
                this.OnPropertyValueChange("PatientPhoneNumber");
                this._PatientPhoneNumber = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("HMDiagnosis")]
        public string HMDiagnosis
        {
            get { return _HMDiagnosis; }
            set
            {
                this.OnPropertyValueChange("HMDiagnosis");
                this._HMDiagnosis = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("WMDiagnosis")]
        public string WMDiagnosis
        {
            get { return _WMDiagnosis; }
            set
            {
                this.OnPropertyValueChange("WMDiagnosis");
                this._WMDiagnosis = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("InHosDept")]
        public string InHosDept
        {
            get { return _InHosDept; }
            set
            {
                this.OnPropertyValueChange("InHosDept");
                this._InHosDept = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("InHosNurseArea")]
        public string InHosNurseArea
        {
            get { return _InHosNurseArea; }
            set
            {
                this.OnPropertyValueChange("InHosNurseArea");
                this._InHosNurseArea = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("InHosBedNo")]
        public string InHosBedNo
        {
            get { return _InHosBedNo; }
            set
            {
                this.OnPropertyValueChange("InHosBedNo");
                this._InHosBedNo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Advice")]
        public string Advice
        {
            get { return _Advice; }
            set
            {
                this.OnPropertyValueChange("Advice");
                this._Advice = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Note")]
        public string Note
        {
            get { return _Note; }
            set
            {
                this.OnPropertyValueChange("Note");
                this._Note = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ContantName")]
        public string ContantName
        {
            get { return _ContantName; }
            set
            {
                this.OnPropertyValueChange("ContantName");
                this._ContantName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ContantRelation")]
        public string ContantRelation
        {
            get { return _ContantRelation; }
            set
            {
                this.OnPropertyValueChange("ContantRelation");
                this._ContantRelation = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ContantPhoneNumber")]
        public string ContantPhoneNumber
        {
            get { return _ContantPhoneNumber; }
            set
            {
                this.OnPropertyValueChange("ContantPhoneNumber");
                this._ContantPhoneNumber = value;
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
                _.Content,
                _.DoctorID,
                _.DeptCode,
                _.DoctorName,
                _.DeptName,
                _.TreatmentNo,
                _.InHosType,
                _.PatientName,
                _.PatientSex,
                _.PatientAge,
                _.PatientAddress,
                _.PatientPhoneNumber,
                _.HMDiagnosis,
                _.WMDiagnosis,
                _.InHosDept,
                _.InHosNurseArea,
                _.InHosBedNo,
                _.Advice,
                _.Note,
                _.ContantName,
                _.ContantRelation,
                _.ContantPhoneNumber,
            };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                this._ID,
                this._Content,
                this._DoctorID,
                this._DeptCode,
                this._DoctorName,
                this._DeptName,
                this._TreatmentNo,
                this._InHosType,
                this._PatientName,
                this._PatientSex,
                this._PatientAge,
                this._PatientAddress,
                this._PatientPhoneNumber,
                this._HMDiagnosis,
                this._WMDiagnosis,
                this._InHosDept,
                this._InHosNurseArea,
                this._InHosBedNo,
                this._Advice,
                this._Note,
                this._ContantName,
                this._ContantRelation,
                this._ContantPhoneNumber,
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
            public readonly static Field All = new Field("*", "OP_HospitalizedReport");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field Content = new Field("Content", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field DoctorID = new Field("DoctorID", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field DeptCode = new Field("DeptCode", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field DoctorName = new Field("DoctorName", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field DeptName = new Field("DeptName", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field TreatmentNo = new Field("TreatmentNo", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field InHosType = new Field("InHosType", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field PatientName = new Field("PatientName", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field PatientSex = new Field("PatientSex", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field PatientAge = new Field("PatientAge", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field PatientAddress = new Field("PatientAddress", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field PatientPhoneNumber = new Field("PatientPhoneNumber", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field HMDiagnosis = new Field("HMDiagnosis", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field WMDiagnosis = new Field("WMDiagnosis", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field InHosDept = new Field("InHosDept", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field InHosNurseArea = new Field("InHosNurseArea", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field InHosBedNo = new Field("InHosBedNo", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field Advice = new Field("Advice", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field Note = new Field("Note", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field ContantName = new Field("ContantName", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field ContantRelation = new Field("ContantRelation", "OP_HospitalizedReport", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field ContantPhoneNumber = new Field("ContantPhoneNumber", "OP_HospitalizedReport", "");
        }
        #endregion
    }
}