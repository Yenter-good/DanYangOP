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
    /// 实体类IView_Inside_DrugDetail 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("IView_Inside_DrugDetail")]
    [Serializable]
    public partial class IView_Inside_DrugDetail : Entity
    {
        #region Model
        private string _ID;
        private string _GroupID;
        private float? _Amount;
        private string _DosageUnit;
        private string _Frequency;
        private string _Usage;
        private string _Owner;
        private int? _No;
        private string _DrugID;
        private string _DrugName;
        private string _Specification;
        private string _PackingUnit;
        private string _DrugProperties;
        private decimal? _PackingNumber;
        private string _Way;
        private string _DrugDept;
        private decimal? _DrugPrice;
        private string _ProductionSites;
        private string _DrugCategory;
        private string _MinDose;
        private string _MinDoseUnit;
        private string _DrugStatus;
        private string _DrugFlag;
        private string _AntibioticsLevel;
        private string _City_Medicare;
        private string _Village_Medicare;
        private string _SearchCode;
        private string _WubiCode;
        private decimal? _Reserve;
        private int? _Num;
        private int? _Days;
        private string _GroupNo;
        private string _DrugSerial;
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
        public float? Amount
        {
            get { return _Amount; }
            set
            {
                this.OnPropertyValueChange(_.Amount, _Amount, value);
                this._Amount = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DosageUnit
        {
            get { return _DosageUnit; }
            set
            {
                this.OnPropertyValueChange(_.DosageUnit, _DosageUnit, value);
                this._DosageUnit = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Frequency
        {
            get { return _Frequency; }
            set
            {
                this.OnPropertyValueChange(_.Frequency, _Frequency, value);
                this._Frequency = value;
            }
        }
        /// <summary>
        /// 
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
        public int? No
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
        public decimal? DrugPrice
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
        public string MinDose
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
        public int? Num
        {
            get { return _Num; }
            set
            {
                this.OnPropertyValueChange(_.Num, _Num, value);
                this._Num = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Days
        {
            get { return _Days; }
            set
            {
                this.OnPropertyValueChange(_.Days, _Days, value);
                this._Days = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupNo
        {
            get { return _GroupNo; }
            set
            {
                this.OnPropertyValueChange(_.GroupNo, GroupNo, value);
                this._GroupNo = value;
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
                this.OnPropertyValueChange(_.DrugSerial, DrugSerial, value);
                this._DrugSerial = value;
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
				_.GroupID,
				_.Amount,
				_.DosageUnit,
				_.Frequency,
				_.Usage,
				_.Owner,
				_.No,
				_.DrugID,
				_.DrugName,
				_.Specification,
				_.PackingUnit,
				_.DrugProperties,
				_.PackingNumber,
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
				_.WubiCode,
				_.Reserve,
				_.Num,
				_.Days,
            _.GroupNo};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._GroupID,
				this._Amount,
				this._DosageUnit,
				this._Frequency,
				this._Usage,
				this._Owner,
				this._No,
				this._DrugID,
				this._DrugName,
				this._Specification,
				this._PackingUnit,
				this._DrugProperties,
				this._PackingNumber,
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
				this._WubiCode,
				this._Reserve,
				this._Num,
				this._Days,
				this._GroupNo,
            this._DrugSerial};
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
            public readonly static Field All = new Field("*", "IView_Inside_DrugDetail");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "IView_Inside_DrugDetail", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field GroupID = new Field("GroupID", "IView_Inside_DrugDetail", "GroupID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Amount = new Field("Amount", "IView_Inside_DrugDetail", "Amount");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DosageUnit = new Field("DosageUnit", "IView_Inside_DrugDetail", "DosageUnit");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Frequency = new Field("Frequency", "IView_Inside_DrugDetail", "Frequency");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Usage = new Field("Usage", "IView_Inside_DrugDetail", "Usage");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Owner = new Field("Owner", "IView_Inside_DrugDetail", "Owner");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field No = new Field("No", "IView_Inside_DrugDetail", "No");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugID = new Field("DrugID", "IView_Inside_DrugDetail", "DrugID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugName = new Field("DrugName", "IView_Inside_DrugDetail", "DrugName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Specification = new Field("Specification", "IView_Inside_DrugDetail", "Specification");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PackingUnit = new Field("PackingUnit", "IView_Inside_DrugDetail", "PackingUnit");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugProperties = new Field("DrugProperties", "IView_Inside_DrugDetail", "DrugProperties");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PackingNumber = new Field("PackingNumber", "IView_Inside_DrugDetail", "PackingNumber");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Way = new Field("Way", "IView_Inside_DrugDetail", "Way");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugDept = new Field("DrugDept", "IView_Inside_DrugDetail", "DrugDept");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugPrice = new Field("DrugPrice", "IView_Inside_DrugDetail", "DrugPrice");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ProductionSites = new Field("ProductionSites", "IView_Inside_DrugDetail", "ProductionSites");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugCategory = new Field("DrugCategory", "IView_Inside_DrugDetail", "DrugCategory");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field MinDose = new Field("MinDose", "IView_Inside_DrugDetail", "MinDose");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field MinDoseUnit = new Field("MinDoseUnit", "IView_Inside_DrugDetail", "MinDoseUnit");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugStatus = new Field("DrugStatus", "IView_Inside_DrugDetail", "DrugStatus");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugFlag = new Field("DrugFlag", "IView_Inside_DrugDetail", "DrugFlag");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field AntibioticsLevel = new Field("AntibioticsLevel", "IView_Inside_DrugDetail", "AntibioticsLevel");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field City_Medicare = new Field("City_Medicare", "IView_Inside_DrugDetail", "City_Medicare");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Village_Medicare = new Field("Village_Medicare", "IView_Inside_DrugDetail", "Village_Medicare");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field SearchCode = new Field("SearchCode", "IView_Inside_DrugDetail", "SearchCode");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field WubiCode = new Field("WubiCode", "IView_Inside_DrugDetail", "WubiCode");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Reserve = new Field("Reserve", "IView_Inside_DrugDetail", "Reserve");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Num = new Field("Num", "IView_Inside_DrugDetail", "Num");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Days = new Field("Days", "IView_Inside_DrugDetail", "Days");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field GroupNo = new Field("GroupNo", "IView_Inside_DrugDetail", "GroupNo");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DrugSerial = new Field("DrugSerial", "IView_Inside_DrugDetail", "DrugSerial");
        }
        #endregion


    }
}

