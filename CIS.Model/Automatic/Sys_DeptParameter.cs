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
    /// 实体类Sys_DeptParameter 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_DeptParameter")]
	[Serializable]
	public partial class Sys_DeptParameter : Entity 
	{
		#region Model
		private string _Code;
		private string _Name;
		private string _Description;
		private int? _Type;
		/// <summary>
		/// 参数代码
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
		/// 参数名称
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
		/// _0列表内显示参数  1单独设置的参数
		/// </summary>
		public int? Type
		{
			get{ return _Type; }
			set
			{
				this.OnPropertyValueChange(_.Type,_Type,value);
				this._Type=value;
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
				_.Name,
				_.Description,
				_.Type};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Code,
				this._Name,
				this._Description,
				this._Type};
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
			public readonly static Field All = new Field("*","Sys_DeptParameter");
			/// <summary>
			/// 参数代码
			/// </summary>
			public readonly static Field Code = new Field("Code","Sys_DeptParameter","参数代码");
			/// <summary>
			/// 参数名称
			/// </summary>
			public readonly static Field Name = new Field("Name","Sys_DeptParameter","参数名称");
			/// <summary>
			/// 描述
			/// </summary>
			public readonly static Field Description = new Field("Description","Sys_DeptParameter","描述");
			/// <summary>
			/// _0列表内显示参数  1单独设置的参数
			/// </summary>
			public readonly static Field Type = new Field("Type","Sys_DeptParameter","_0列表内显示参数  1单独设置的参数");
		}
		#endregion


	}
}
