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
    /// 实体类Sys_Dic_SurgeryCategory 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_Dic_SurgeryCategory")]
	[Serializable]
	public partial class Sys_Dic_SurgeryCategory : Entity 
	{
		#region Model
		private string _Code;
		private string _Name;
		/// <summary>
		/// 
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
		/// 
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
				_.Name};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Code,
				this._Name};
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
			public readonly static Field All = new Field("*","Sys_Dic_SurgeryCategory");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Code = new Field("Code","Sys_Dic_SurgeryCategory","Code");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Name = new Field("Name","Sys_Dic_SurgeryCategory","Name");
		}
		#endregion


	}
}

