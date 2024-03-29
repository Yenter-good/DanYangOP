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
    /// 实体类OP_Prescription_Chronic 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("OP_Prescription_Chronic")]
	[Serializable]
	public partial class OP_Prescription_Chronic : Entity 
	{
		#region Model
		private string _ID;
		private string _PrescriptionCode;
		private string _ChronicCode;
		private string _ChronicName;
		private string _ChronicType;
		/// <summary>
		/// 主键
		/// </summary>
		public string ID
		{
			get{ return _ID; }
			set
			{
				this.OnPropertyValueChange(_.ID,_ID,value);
				this._ID=value;
			}
		}
		/// <summary>
		/// 处方ID
		/// </summary>
		public string PrescriptionCode
		{
			get{ return _PrescriptionCode; }
			set
			{
				this.OnPropertyValueChange(_.PrescriptionCode,_PrescriptionCode,value);
				this._PrescriptionCode=value;
			}
		}
		/// <summary>
		/// 慢性病ID
		/// </summary>
		public string ChronicCode
		{
			get{ return _ChronicCode; }
			set
			{
				this.OnPropertyValueChange(_.ChronicCode,_ChronicCode,value);
				this._ChronicCode=value;
			}
		}
		/// <summary>
		/// 慢性病名称
		/// </summary>
		public string ChronicName
		{
			get{ return _ChronicName; }
			set
			{
				this.OnPropertyValueChange(_.ChronicName,_ChronicName,value);
				this._ChronicName=value;
			}
		}
		/// <summary>
		/// 慢性病类型
		/// </summary>
		public string ChronicType
		{
			get{ return _ChronicType; }
			set
			{
				this.OnPropertyValueChange(_.ChronicType,_ChronicType,value);
				this._ChronicType=value;
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
				_.ID};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.ID,
				_.PrescriptionCode,
				_.ChronicCode,
				_.ChronicName,
				_.ChronicType};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._PrescriptionCode,
				this._ChronicCode,
				this._ChronicName,
				this._ChronicType};
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
			public readonly static Field All = new Field("*","OP_Prescription_Chronic");
			/// <summary>
			/// 主键
			/// </summary>
			public readonly static Field ID = new Field("ID","OP_Prescription_Chronic","主键");
			/// <summary>
			/// 处方ID
			/// </summary>
			public readonly static Field PrescriptionCode = new Field("PrescriptionCode","OP_Prescription_Chronic","处方ID");
			/// <summary>
			/// 慢性病ID
			/// </summary>
			public readonly static Field ChronicCode = new Field("ChronicCode","OP_Prescription_Chronic","慢性病ID");
			/// <summary>
			/// 慢性病名称
			/// </summary>
			public readonly static Field ChronicName = new Field("ChronicName","OP_Prescription_Chronic","慢性病名称");
			/// <summary>
			/// 慢性病类型
			/// </summary>
			public readonly static Field ChronicType = new Field("ChronicType","OP_Prescription_Chronic","慢性病类型");
		}
		#endregion


	}
}

