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
    /// 实体类Sys_Role_AuthorityCode 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_Role_AuthorityCode")]
	[Serializable]
	public partial class Sys_Role_AuthorityCode : Entity 
	{
		#region Model
		private int _ID;
		private string _RoleCode;
		private string _AuthorityCode;
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
		/// 角色代码
		/// </summary>
		public string RoleCode
		{
			get{ return _RoleCode; }
			set
			{
				this.OnPropertyValueChange(_.RoleCode,_RoleCode,value);
				this._RoleCode=value;
			}
		}
		/// <summary>
		/// 权限参数代码
		/// </summary>
		public string AuthorityCode
		{
			get{ return _AuthorityCode; }
			set
			{
				this.OnPropertyValueChange(_.AuthorityCode,_AuthorityCode,value);
				this._AuthorityCode=value;
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
				_.RoleCode,
				_.AuthorityCode};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._RoleCode,
				this._AuthorityCode};
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
			public readonly static Field All = new Field("*","Sys_Role_AuthorityCode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","Sys_Role_AuthorityCode","ID");
			/// <summary>
			/// 角色代码
			/// </summary>
			public readonly static Field RoleCode = new Field("RoleCode","Sys_Role_AuthorityCode","角色代码");
			/// <summary>
			/// 权限参数代码
			/// </summary>
			public readonly static Field AuthorityCode = new Field("AuthorityCode","Sys_Role_AuthorityCode","权限参数代码");
		}
		#endregion


	}
}
