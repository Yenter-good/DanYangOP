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
    /// 实体类TP_DataMeta 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("TP_DataMeta")]
	[Serializable]
	public partial class TP_DataMeta : Entity 
	{
		#region Model
		private string _Code;
		private string _ParentCode;
		private int _NodeType;
		private string _Name;
		private string _Description;
		private string _RangeTypeCode;
		private string _DataType;
		private bool _UseFlag;
		private DateTime _UpdateDate;
		private string _Updater;
		private int _No;
		/// <summary>
		/// 编码
		/// </summary>
		public string Code
		{
			get{ return _Code; }
			set
			{
				this.OnPropertyValueChange(_.Code,_Code,value);
				this._Code=value;
			}
		}
		/// <summary>
		/// 父节点
		/// </summary>
		public string ParentCode
		{
			get{ return _ParentCode; }
			set
			{
				this.OnPropertyValueChange(_.ParentCode,_ParentCode,value);
				this._ParentCode=value;
			}
		}
		/// <summary>
		/// 节点类型  0数据元  1数据组
		/// </summary>
		public int NodeType
		{
			get{ return _NodeType; }
			set
			{
				this.OnPropertyValueChange(_.NodeType,_NodeType,value);
				this._NodeType=value;
			}
		}
		/// <summary>
		/// 名称
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
		/// 描述
		/// </summary>
		public string Description
		{
			get{ return _Description; }
			set
			{
				this.OnPropertyValueChange(_.Description,_Description,value);
				this._Description=value;
			}
		}
		/// <summary>
		/// 对应的值域类型
		/// </summary>
		public string RangeTypeCode
		{
			get{ return _RangeTypeCode; }
			set
			{
				this.OnPropertyValueChange(_.RangeTypeCode,_RangeTypeCode,value);
				this._RangeTypeCode=value;
			}
		}
		/// <summary>
		/// 数据类型
		/// </summary>
		public string DataType
		{
			get{ return _DataType; }
			set
			{
				this.OnPropertyValueChange(_.DataType,_DataType,value);
				this._DataType=value;
			}
		}
		/// <summary>
		/// 使用标志 0 不使用 1 使用
		/// </summary>
		public bool UseFlag
		{
			get{ return _UseFlag; }
			set
			{
				this.OnPropertyValueChange(_.UseFlag,_UseFlag,value);
				this._UseFlag=value;
			}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime UpdateDate
		{
			get{ return _UpdateDate; }
			set
			{
				this.OnPropertyValueChange(_.UpdateDate,_UpdateDate,value);
				this._UpdateDate=value;
			}
		}
		/// <summary>
		/// 更新人编号
		/// </summary>
		public string Updater
		{
			get{ return _Updater; }
			set
			{
				this.OnPropertyValueChange(_.Updater,_Updater,value);
				this._Updater=value;
			}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int No
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
				_.Code};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.Code,
				_.ParentCode,
				_.NodeType,
				_.Name,
				_.Description,
				_.RangeTypeCode,
				_.DataType,
				_.UseFlag,
				_.UpdateDate,
				_.Updater,
				_.No};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Code,
				this._ParentCode,
				this._NodeType,
				this._Name,
				this._Description,
				this._RangeTypeCode,
				this._DataType,
				this._UseFlag,
				this._UpdateDate,
				this._Updater,
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
			public readonly static Field All = new Field("*","TP_DataMeta");
			/// <summary>
			/// 编码
			/// </summary>
			public readonly static Field Code = new Field("Code","TP_DataMeta","编码");
			/// <summary>
			/// 父节点
			/// </summary>
			public readonly static Field ParentCode = new Field("ParentCode","TP_DataMeta","父节点");
			/// <summary>
			/// 节点类型  0数据元  1数据组
			/// </summary>
			public readonly static Field NodeType = new Field("NodeType","TP_DataMeta","节点类型  0数据元  1数据组");
			/// <summary>
			/// 名称
			/// </summary>
			public readonly static Field Name = new Field("Name","TP_DataMeta","名称");
			/// <summary>
			/// 描述
			/// </summary>
			public readonly static Field Description = new Field("Description","TP_DataMeta","描述");
			/// <summary>
			/// 对应的值域类型
			/// </summary>
			public readonly static Field RangeTypeCode = new Field("RangeTypeCode","TP_DataMeta","对应的值域类型");
			/// <summary>
			/// 数据类型
			/// </summary>
			public readonly static Field DataType = new Field("DataType","TP_DataMeta","数据类型");
			/// <summary>
			/// 使用标志 0 不使用 1 使用
			/// </summary>
			public readonly static Field UseFlag = new Field("UseFlag","TP_DataMeta","使用标志 0 不使用 1 使用");
			/// <summary>
			/// 更新时间
			/// </summary>
			public readonly static Field UpdateDate = new Field("UpdateDate","TP_DataMeta","更新时间");
			/// <summary>
			/// 更新人编号
			/// </summary>
			public readonly static Field Updater = new Field("Updater","TP_DataMeta","更新人编号");
			/// <summary>
			/// 排序
			/// </summary>
			public readonly static Field No = new Field("No","TP_DataMeta","排序");
		}
		#endregion


	}
}

