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
    /// 实体类IView_HIS_DrugInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("IView_HIS_DrugInfo")]
    [Serializable]
    public partial class IView_HIS_DrugInfo : Entity
    {
        #region Model
        private string _DrugID;
        private string _DrugName;
        private string _Specification;
        private string _PackingUnit;
        private string _DrugProperties;
        private decimal? _PackingNumber;
        private string _DrugSerial;
        private string _NickName;
        private string _Way;
        private string _DrugDept;
        private decimal _DrugPrice;
        private string _ProductionSites;
        private string _DrugCategory;
        private decimal? _MinDose;
        private string _MinDoseUnit;
        private string _DrugStatus;
        private string _DrugFlag;
        private string _AntibioticsLevel;
        private string _City_Medicare;
        private string _Village_Medicare;
        private string _SearchCode;
        private decimal? _Reserve;
        private string _WubiCode;
        private string _DrugForm;
        private string _MedicalInsuranceDrugSerial;
        private string _Usage;
        private string _IsJY;
        private string _reyphh;
        private string _CityCode;
        /// <summary>
        /// 
        /// </summary>
        public string DrugID
        {
            get { return _DrugID; }
            set
            {
                this.OnPropertyValueChange(_.DrugID, _DrugID, value);
                this._DrugID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DrugName
        {
            get { return _DrugName; }
            set
            {
                this.OnPropertyValueChange(_.DrugName, _DrugName, value);
                this._DrugName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Specification
        {
            get { return _Specification; }
            set
            {
                this.OnPropertyValueChange(_.Specification, _Specification, value);
                this._Specification = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PackingUnit
        {
            get { return _PackingUnit; }
            set
            {
                this.OnPropertyValueChange(_.PackingUnit, _PackingUnit, value);
                this._PackingUnit = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DrugProperties
        {
            get { return _DrugProperties; }
            set
            {
                this.OnPropertyValueChange(_.DrugProperties, _DrugProperties, value);
                this._DrugProperties = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PackingNumber
        {
            get { return _PackingNumber; }
            set
            {
                this.OnPropertyValueChange(_.PackingNumber, _PackingNumber, value);
                this._PackingNumber = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DrugSerial
        {
            get { return _DrugSerial; }
            set
            {
                this.OnPropertyValueChange(_.DrugSerial, _DrugSerial, value);
                this._DrugSerial = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            get { return _NickName; }
            set
            {
                this.OnPropertyValueChange(_.NickName, _NickName, value);
                this._NickName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Way
        {
            get { return _Way; }
            set
            {
                this.OnPropertyValueChange(_.Way, _Way, value);
                this._Way = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DrugDept
        {
            get { return _DrugDept; }
            set
            {
                this.OnPropertyValueChange(_.DrugDept, _DrugDept, value);
                this._DrugDept = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DrugPrice
        {
            get { return _DrugPrice; }
            set
            {
                this.OnPropertyValueChange(_.DrugPrice, _DrugPrice, value);
                this._DrugPrice = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductionSites
        {
            get { return _ProductionSites; }
            set
            {
                this.OnPropertyValueChange(_.ProductionSites, _ProductionSites, value);
                this._ProductionSites = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DrugCategory
        {
            get { return _DrugCategory; }
            set
            {
                this.OnPropertyValueChange(_.DrugCategory, _DrugCategory, value);
                this._DrugCategory = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinDose
        {
            get { return _MinDose; }
            set
            {
                this.OnPropertyValueChange(_.MinDose, _MinDose, value);
                this._MinDose = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinDoseUnit
        {
            get { return _MinDoseUnit; }
            set
            {
                this.OnPropertyValueChange(_.MinDoseUnit, _MinDoseUnit, value);
                this._MinDoseUnit = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DrugStatus
        {
            get { return _DrugStatus; }
            set
            {
                this.OnPropertyValueChange(_.DrugStatus, _DrugStatus, value);
                this._DrugStatus = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DrugFlag
        {
            get { return _DrugFlag; }
            set
            {
                this.OnPropertyValueChange(_.DrugFlag, _DrugFlag, value);
                this._DrugFlag = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AntibioticsLevel
        {
            get { return _AntibioticsLevel; }
            set
            {
                this.OnPropertyValueChange(_.AntibioticsLevel, _AntibioticsLevel, value);
                this._AntibioticsLevel = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City_Medicare
        {
            get { return _City_Medicare; }
            set
            {
                this.OnPropertyValueChange(_.City_Medicare, _City_Medicare, value);
                this._City_Medicare = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Village_Medicare
        {
            get { return _Village_Medicare; }
            set
            {
                this.OnPropertyValueChange(_.Village_Medicare, _Village_Medicare, value);
                this._Village_Medicare = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SearchCode
        {
            get { return _SearchCode; }
            set
            {
                this.OnPropertyValueChange(_.SearchCode, _SearchCode, value);
                this._SearchCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Reserve
        {
            get { return _Reserve; }
            set
            {
                this.OnPropertyValueChange(_.Reserve, _Reserve, value);
                this._Reserve = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WubiCode
        {
            get { return _WubiCode; }
            set
            {
                this.OnPropertyValueChange(_.WubiCode, _WubiCode, value);
                this._WubiCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DrugForm
        {
            get { return _DrugForm; }
            set
            {
                this.OnPropertyValueChange(_.DrugForm, _DrugForm, value);
                this._DrugForm = value;
            }
        }
        /// <summary>
        /// 医保货号
        /// </summary>
        public string MedicalInsuranceDrugSerial
        {
            get { return _MedicalInsuranceDrugSerial; }
            set
            {
                this.OnPropertyValueChange(_.MedicalInsuranceDrugSerial, _MedicalInsuranceDrugSerial, value);
                this._MedicalInsuranceDrugSerial = value;
            }
        }
        /// <summary>
        /// 默认用法
        /// </summary>
        public string Usage
        {
            get { return _Usage; }
            set
            {
                this.OnPropertyValueChange(_.Usage, _Usage, value);
                this._Usage = value;
            }
        }
        public string IsJY
        {
            get { return _IsJY; }
            set
            {
                this.OnPropertyValueChange(_.IsJY, _IsJY, value);
                this._IsJY = value;
            }
        }
        public string reyphh
        {
            get { return _reyphh; }
            set
            {
                this.OnPropertyValueChange(_.reyphh, _reyphh, value);
                this._reyphh = value;
            }
        }
        public string CityCode
        {
            get { return _CityCode; }
            set
            {
                this.OnPropertyValueChange(_.CityCode, _CityCode, value);
                this._CityCode = value;
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
                _.DrugID,
                _.DrugName,
                _.Specification,
                _.PackingUnit,
                _.DrugProperties,
                _.PackingNumber,
                _.DrugSerial,
                _.NickName,
                _.Way,
                _.DrugDept,
                _.DrugPrice,
                _.ProductionSites,
                _.DrugCategory,
                _.MinDose,
                _.MinDoseUnit,
                _.DrugStatus,
                _.DrugFlag,
                _.AntibioticsLevel,
                _.City_Medicare,
                _.Village_Medicare,
                _.SearchCode,
                _.Reserve,
                _.WubiCode,
            _.DrugForm,
            _.MedicalInsuranceDrugSerial,
            _.Usage,
            _.IsJY,
            _.reyphh,
            _.CityCode
            };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                this._DrugID,
                this._DrugName,
                this._Specification,
                this._PackingUnit,
                this._DrugProperties,
                this._PackingNumber,
                this._DrugSerial,
                this._NickName,
                this._Way,
                this._DrugDept,
                this._DrugPrice,
                this._ProductionSites,
                this._DrugCategory,
                this._MinDose,
                this._MinDoseUnit,
                this._DrugStatus,
                this._DrugFlag,
                this._AntibioticsLevel,
                this._City_Medicare,
                this._Village_Medicare,
                this._SearchCode,
                this._Reserve,
                this._WubiCode,
            this._DrugForm,
            this._MedicalInsuranceDrugSerial,
            this._Usage,
            _IsJY,
            this._reyphh,
            this._CityCode
            };
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
            public readonly static Field All = new Field("*", "IView_HIS_DrugInfo");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugID = new Field("DrugID", "IView_HIS_DrugInfo", "DrugID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugName = new Field("DrugName", "IView_HIS_DrugInfo", "DrugName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Specification = new Field("Specification", "IView_HIS_DrugInfo", "Specification");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PackingUnit = new Field("PackingUnit", "IView_HIS_DrugInfo", "PackingUnit");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugProperties = new Field("DrugProperties", "IView_HIS_DrugInfo", "DrugProperties");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PackingNumber = new Field("PackingNumber", "IView_HIS_DrugInfo", "PackingNumber");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugSerial = new Field("DrugSerial", "IView_HIS_DrugInfo", "DrugSerial");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field NickName = new Field("NickName", "IView_HIS_DrugInfo", "NickName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Way = new Field("Way", "IView_HIS_DrugInfo", "Way");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugDept = new Field("DrugDept", "IView_HIS_DrugInfo", "DrugDept");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugPrice = new Field("DrugPrice", "IView_HIS_DrugInfo", "DrugPrice");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ProductionSites = new Field("ProductionSites", "IView_HIS_DrugInfo", "ProductionSites");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugCategory = new Field("DrugCategory", "IView_HIS_DrugInfo", "DrugCategory");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field MinDose = new Field("MinDose", "IView_HIS_DrugInfo", "MinDose");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field MinDoseUnit = new Field("MinDoseUnit", "IView_HIS_DrugInfo", "MinDoseUnit");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugStatus = new Field("DrugStatus", "IView_HIS_DrugInfo", "DrugStatus");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugFlag = new Field("DrugFlag", "IView_HIS_DrugInfo", "DrugFlag");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field AntibioticsLevel = new Field("AntibioticsLevel", "IView_HIS_DrugInfo", "AntibioticsLevel");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field City_Medicare = new Field("City_Medicare", "IView_HIS_DrugInfo", "City_Medicare");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Village_Medicare = new Field("Village_Medicare", "IView_HIS_DrugInfo", "Village_Medicare");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field SearchCode = new Field("SearchCode", "IView_HIS_DrugInfo", "SearchCode");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Reserve = new Field("Reserve", "IView_HIS_DrugInfo", "Reserve");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field WubiCode = new Field("WubiCode", "IView_HIS_DrugInfo", "WubiCode");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugForm = new Field("DrugForm", "IView_HIS_DrugInfo", "DrugForm");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field MedicalInsuranceDrugSerial = new Field("MedicalInsuranceDrugSerial", "IView_HIS_DrugInfo", "MedicalInsuranceDrugSerial");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Usage = new Field("Usage", "IView_HIS_DrugInfo", "Usage");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IsJY = new Field("IsJY", "IView_HIS_DrugInfo", "IsJY");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field reyphh = new Field("reyphh", "IView_HIS_DrugInfo", "reyphh");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field CityCode = new Field("CityCode", "IView_HIS_DrugInfo", "CityCode");
        }
        #endregion


    }
}

