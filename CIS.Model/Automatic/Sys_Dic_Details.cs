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
    /// 实体类Sys_Dic_Details 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_Dic_Details")]
	[Serializable]
	public partial class Sys_Dic_Details : Entity 
	{
		#region Model
		private int _ID;
		private string _DicCode;
		private string _Code;
		private string _Value;
		private string _Description;
		private int? _No;
		private string _SearchCode;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			get{ return _ID; }
			set
			{
				this.OnPropertyValueChange(_.ID,_ID,value);
				this._ID=value;
			}
		}
		/// <summary>
		/// 所属数据字典代码
		/// </summary>
		public string DicCode
		{
			get{ return _DicCode; }
			set
			{
				this.OnPropertyValueChange(_.DicCode,_DicCode,value);
				this._DicCode=value;
			}
		}
		/// <summary>
		/// 代码
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
		/// 值
		/// </summary>
		public string Value
		{
			get{ return _Value; }
			set
			{
				this.OnPropertyValueChange(_.Value,_Value,value);
				this._Value=value;
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
		/// 
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
		/// <summary>
		/// 
		/// </summary>
		public string SearchCode
		{
			get{ return _SearchCode; }
			set
			{
				this.OnPropertyValueChange(_.SearchCode,_SearchCode,value);
				this._SearchCode=value;
			}
		}
		#endregion

		#region Method
		/// <summary>
		/// 获取实体中的标识列
		/// </summary>
		public override Field GetIdentityField()
		{
			return _.ID;
		}
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
				_.DicCode,
				_.Code,
				_.Value,
				_.Description,
				_.No,
				_.SearchCode};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._DicCode,
				this._Code,
				this._Value,
				this._Description,
				this._No,
				this._SearchCode};
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
			public readonly static Field All = new Field("*","Sys_Dic_Details");
			/// <summary>
			/// ID
			/// </summary>
			public readonly static Field ID = new Field("ID","Sys_Dic_Details","ID");
			/// <summary>
			/// 所属数据字典代码
			/// </summary>
			public readonly static Field DicCode = new Field("DicCode","Sys_Dic_Details","所属数据字典代码");
			/// <summary>
			/// 代码
			/// </summary>
			public readonly static Field Code = new Field("Code","Sys_Dic_Details","代码");
			/// <summary>
			/// 值
			/// </summary>
			public readonly static Field Value = new Field("Value","Sys_Dic_Details","值");
			/// <summary>
			/// 描述
			/// </summary>
			public readonly static Field Description = new Field("Description","Sys_Dic_Details","描述");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field No = new Field("No","Sys_Dic_Details","No");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SearchCode = new Field("SearchCode","Sys_Dic_Details","SearchCode");
		}
		#endregion


	}
}

