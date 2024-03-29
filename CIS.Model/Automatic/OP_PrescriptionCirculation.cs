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
	/// 实体类OP_PrescriptionCirculation。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("OP_PrescriptionCirculation")]
	[Serializable]
	public partial class OP_PrescriptionCirculation : Entity
	{
		#region Model
		private string _TreatmentNo;
		private string _PatientID;
		private string _PatientName;
		private long _PrescriptionNo;
		private int? _RecordNumber;
		private string _DeptCode;
		private string _UserID;
		private DateTime? _UpdateTime;
		private int? _Status;
		private string _IDCard;
		private string _DoctorPhone;
		private string _PayType;
		private string _UserName;
		private string _Sex;
		private string _Age;
		private string _CardNo;
		private string _PrescriptionCirculationNo;
		private bool _UploadFlag;

		/// <summary>
		/// 就诊号
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
		/// 患者ID
		/// </summary>
		[Field("PatientID")]
		public string PatientID
		{
			get { return _PatientID; }
			set
			{
				this.OnPropertyValueChange("PatientID");
				this._PatientID = value;
			}
		}
		/// <summary>
		/// 患者姓名
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
		/// 处方编号
		/// </summary>
		[Field("PrescriptionNo")]
		public long PrescriptionNo
		{
			get { return _PrescriptionNo; }
			set
			{
				this.OnPropertyValueChange("PrescriptionNo");
				this._PrescriptionNo = value;
			}
		}
		/// <summary>
		/// 记录数量
		/// </summary>
		[Field("RecordNumber")]
		public int? RecordNumber
		{
			get { return _RecordNumber; }
			set
			{
				this.OnPropertyValueChange("RecordNumber");
				this._RecordNumber = value;
			}
		}
		/// <summary>
		/// 下嘱科室
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
		/// 下嘱医生ID
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
		/// 下嘱时间
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
		/// 0上传中 1上传完成 2上传失败 3撤回
		/// </summary>
		[Field("Status")]
		public int? Status
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
		[Field("IDCard")]
		public string IDCard
		{
			get { return _IDCard; }
			set
			{
				this.OnPropertyValueChange("IDCard");
				this._IDCard = value;
			}
		}
		/// <summary>
		/// 医生短号
		/// </summary>
		[Field("DoctorPhone")]
		public string DoctorPhone
		{
			get { return _DoctorPhone; }
			set
			{
				this.OnPropertyValueChange("DoctorPhone");
				this._DoctorPhone = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Field("PayType")]
		public string PayType
		{
			get { return _PayType; }
			set
			{
				this.OnPropertyValueChange("PayType");
				this._PayType = value;
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
		[Field("Sex")]
		public string Sex
		{
			get { return _Sex; }
			set
			{
				this.OnPropertyValueChange("Sex");
				this._Sex = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Field("Age")]
		public string Age
		{
			get { return _Age; }
			set
			{
				this.OnPropertyValueChange("Age");
				this._Age = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Field("CardNo")]
		public string CardNo
		{
			get { return _CardNo; }
			set
			{
				this.OnPropertyValueChange("CardNo");
				this._CardNo = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Field("PrescriptionCirculationNo")]
		public string PrescriptionCirculationNo
		{
			get { return _PrescriptionCirculationNo; }
			set
			{
				this.OnPropertyValueChange("PrescriptionCirculationNo");
				this._PrescriptionCirculationNo = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Field("UploadFlag")]
		public bool UploadFlag
		{
			get { return _UploadFlag; }
			set
			{
				this.OnPropertyValueChange("UploadFlag");
				this._UploadFlag = value;
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
				_.PrescriptionNo,
			};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.TreatmentNo,
				_.PatientID,
				_.PatientName,
				_.PrescriptionNo,
				_.RecordNumber,
				_.DeptCode,
				_.UserID,
				_.UpdateTime,
				_.Status,
				_.IDCard,
				_.DoctorPhone,
				_.PayType,
				_.UserName,
				_.Sex,
				_.Age,
				_.CardNo,
				_.PrescriptionCirculationNo,
				_.UploadFlag,
			};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._TreatmentNo,
				this._PatientID,
				this._PatientName,
				this._PrescriptionNo,
				this._RecordNumber,
				this._DeptCode,
				this._UserID,
				this._UpdateTime,
				this._Status,
				this._IDCard,
				this._DoctorPhone,
				this._PayType,
				this._UserName,
				this._Sex,
				this._Age,
				this._CardNo,
				this._PrescriptionCirculationNo,
				this._UploadFlag,
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
			public readonly static Field All = new Field("*", "OP_PrescriptionCirculation");
			/// <summary>
			/// 就诊号
			/// </summary>
			public readonly static Field TreatmentNo = new Field("TreatmentNo", "OP_PrescriptionCirculation", "就诊号");
			/// <summary>
			/// 患者ID
			/// </summary>
			public readonly static Field PatientID = new Field("PatientID", "OP_PrescriptionCirculation", "患者ID");
			/// <summary>
			/// 患者姓名
			/// </summary>
			public readonly static Field PatientName = new Field("PatientName", "OP_PrescriptionCirculation", "患者姓名");
			/// <summary>
			/// 处方编号
			/// </summary>
			public readonly static Field PrescriptionNo = new Field("PrescriptionNo", "OP_PrescriptionCirculation", "处方编号");
			/// <summary>
			/// 记录数量
			/// </summary>
			public readonly static Field RecordNumber = new Field("RecordNumber", "OP_PrescriptionCirculation", "记录数量");
			/// <summary>
			/// 下嘱科室
			/// </summary>
			public readonly static Field DeptCode = new Field("DeptCode", "OP_PrescriptionCirculation", "下嘱科室");
			/// <summary>
			/// 下嘱医生ID
			/// </summary>
			public readonly static Field UserID = new Field("UserID", "OP_PrescriptionCirculation", "下嘱医生ID");
			/// <summary>
			/// 下嘱时间
			/// </summary>
			public readonly static Field UpdateTime = new Field("UpdateTime", "OP_PrescriptionCirculation", "下嘱时间");
			/// <summary>
			/// 0上传中 1上传完成 2上传失败 3撤回
			/// </summary>
			public readonly static Field Status = new Field("Status", "OP_PrescriptionCirculation", "状态  OP_Dic_Process 对应");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IDCard = new Field("IDCard", "OP_PrescriptionCirculation", "");
			/// <summary>
			/// 医生短号
			/// </summary>
			public readonly static Field DoctorPhone = new Field("DoctorPhone", "OP_PrescriptionCirculation", "医生短号");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PayType = new Field("PayType", "OP_PrescriptionCirculation", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UserName = new Field("UserName", "OP_PrescriptionCirculation", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Sex = new Field("Sex", "OP_PrescriptionCirculation", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Age = new Field("Age", "OP_PrescriptionCirculation", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CardNo = new Field("CardNo", "OP_PrescriptionCirculation", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PrescriptionCirculationNo = new Field("PrescriptionCirculationNo", "OP_PrescriptionCirculation", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UploadFlag = new Field("UploadFlag", "OP_PrescriptionCirculation", "");
		}
		#endregion
	}
}