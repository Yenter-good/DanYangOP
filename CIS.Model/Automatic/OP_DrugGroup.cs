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
    /// 实体类OP_DrugGroup 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("OP_DrugGroup")]
	[Serializable]
	public partial class OP_DrugGroup : Entity 
	{
		#region Model
		private string _ID;
		private string _ParentID;
		private int? _GroupType;
		private string _Owner;
		private string _Name;
		private int? _DrugType;
		private int? _No;
		/// <summary>
		/// ID
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
		/// 父节点
		/// </summary>
		public string ParentID
		{
			get{ return _ParentID; }
			set
			{
				this.OnPropertyValueChange(_.ParentID,_ParentID,value);
				this._ParentID=value;
			}
		}
		/// <summary>
		/// 组套类别（1科室 2个人）
		/// </summary>
		public int? GroupType
		{
			get{ return _GroupType; }
			set
			{
				this.OnPropertyValueChange(_.GroupType,_GroupType,value);
				this._GroupType=value;
			}
		}
		/// <summary>
		/// 拥有者（GroupType为科室 存科室编号 为个人存用户ID）
		/// </summary>
		public string Owner
		{
			get{ return _Owner; }
			set
			{
				this.OnPropertyValueChange(_.Owner,_Owner,value);
				this._Owner=value;
			}
		}
		/// <summary>
		/// 组套名称
		/// </summary>
		public string Name
		{
			get{ return _Name; }
			set
			{
				this.OnPropertyValueChange(_.Name,_Name,value);
				this._Name=value;
			}
		}
		/// <summary>
		/// _1西（中成）药   2草药
		/// </summary>
		public int? DrugType
		{
			get{ return _DrugType; }
			set
			{
				this.OnPropertyValueChange(_.DrugType,_DrugType,value);
				this._DrugType=value;
			}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? No
		{
			get{ return _No; }
			set
			{
				this.OnPropertyValueChange(_.No,_No,value);
				this._No=value;
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
				_.ParentID,
				_.GroupType,
				_.Owner,
				_.Name,
				_.DrugType,
				_.No};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._ParentID,
				this._GroupType,
				this._Owner,
				this._Name,
				this._DrugType,
				this._No};
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
			public readonly static Field All = new Field("*","OP_DrugGroup");
			/// <summary>
			/// ID
			/// </summary>
			public readonly static Field ID = new Field("ID","OP_DrugGroup","ID");
			/// <summary>
			/// 父节点
			/// </summary>
			public readonly static Field ParentID = new Field("ParentID","OP_DrugGroup","父节点");
			/// <summary>
			/// 组套类别（1科室 2个人）
			/// </summary>
			public readonly static Field GroupType = new Field("GroupType","OP_DrugGroup","组套类别（1科室 2个人）");
			/// <summary>
			/// 拥有者（GroupType为科室 存科室编号 为个人存用户ID）
			/// </summary>
			public readonly static Field Owner = new Field("Owner","OP_DrugGroup","拥有者（GroupType为科室 存科室编号 为个人存用户ID）");
			/// <summary>
			/// 组套名称
			/// </summary>
			public readonly static Field Name = new Field("Name","OP_DrugGroup","组套名称");
			/// <summary>
			/// _1西（中成）药   2草药
			/// </summary>
			public readonly static Field DrugType = new Field("DrugType","OP_DrugGroup","_1西（中成）药   2草药");
			/// <summary>
			/// 排序
			/// </summary>
			public readonly static Field No = new Field("No","OP_DrugGroup","排序");
		}
		#endregion


	}
}

