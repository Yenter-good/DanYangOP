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
    /// 实体类Sys_Dic 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_Dic")]
	[Serializable]
	public partial class Sys_Dic : Entity 
	{
		#region Model
		private int _ID;
		private string _Code;
		private string _Name;
		private string _Description;
		private int _Style;
		private string _SearchCode;
		/// <summary>
		/// 
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
		/// 加载样式  默认为0   0为不可修改  1为可修改  其余为扩展
		/// </summary>
		public int Style
		{
			get{ return _Style; }
			set
			{
				this.OnPropertyValueChange(_.Style,_Style,value);
				this._Style=value;
			}
		}
		/// <summary>
		/// 检索码
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
				_.Code,
				_.Name,
				_.Description,
				_.Style,
				_.SearchCode};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._Code,
				this._Name,
				this._Description,
				this._Style,
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
			public readonly static Field All = new Field("*","Sys_Dic");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","Sys_Dic","ID");
			/// <summary>
			/// 代码
			/// </summary>
			public readonly static Field Code = new Field("Code","Sys_Dic","代码");
			/// <summary>
			/// 名称
			/// </summary>
			public readonly static Field Name = new Field("Name","Sys_Dic","名称");
			/// <summary>
			/// 描述
			/// </summary>
			public readonly static Field Description = new Field("Description","Sys_Dic","描述");
			/// <summary>
			/// 加载样式  默认为0   0为不可修改  1为可修改  其余为扩展
			/// </summary>
			public readonly static Field Style = new Field("Style","Sys_Dic","加载样式  默认为0   0为不可修改  1为可修改  其余为扩展");
			/// <summary>
			/// 检索码
			/// </summary>
			public readonly static Field SearchCode = new Field("SearchCode","Sys_Dic","检索码");
		}
		#endregion


	}
}

