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
    /// 实体类TP_KnowlageNode 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("TP_KnowlageNode")]
	[Serializable]
	public partial class TP_KnowlageNode : Entity 
	{
		#region Model
		private string _ID;
		private string _Text;
		private string _DataSourceCode;
		private int? _Stauts;
		private string _Property;
		/// <summary>
		/// 
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
		/// 
		/// </summary>
		public string Text
		{
			get{ return _Text; }
			set
			{
				this.OnPropertyValueChange(_.Text,_Text,value);
				this._Text=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DataSourceCode
		{
			get{ return _DataSourceCode; }
			set
			{
				this.OnPropertyValueChange(_.DataSourceCode,_DataSourceCode,value);
				this._DataSourceCode=value;
			}
		}
		/// <summary>
		/// 状态 0停用 1启用
		/// </summary>
		public int? Stauts
		{
			get{ return _Stauts; }
			set
			{
				this.OnPropertyValueChange(_.Stauts,_Stauts,value);
				this._Stauts=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Property
		{
			get{ return _Property; }
			set
			{
				this.OnPropertyValueChange(_.Property,_Property,value);
				this._Property=value;
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
				_.Text,
				_.DataSourceCode,
				_.Stauts,
				_.Property};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._Text,
				this._DataSourceCode,
				this._Stauts,
				this._Property};
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
			public readonly static Field All = new Field("*","TP_KnowlageNode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","TP_KnowlageNode","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Text = new Field("Text","TP_KnowlageNode","Text");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DataSourceCode = new Field("DataSourceCode","TP_KnowlageNode","DataSourceCode");
			/// <summary>
			/// 状态 0停用 1启用
			/// </summary>
			public readonly static Field Stauts = new Field("Stauts","TP_KnowlageNode","状态 0停用 1启用");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Property = new Field("Property","TP_KnowlageNode","Property");
		}
		#endregion


	}
}

