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
    /// 实体类Sys_User_Dept 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_User_Dept")]
	[Serializable]
	public partial class Sys_User_Dept : Entity 
	{
		#region Model
		private int _ID;
		private string _UserID;
		private string _DepartCode;
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
		/// 
		/// </summary>
		public string UserID
		{
			get{ return _UserID; }
			set
			{
				this.OnPropertyValueChange(_.UserID,_UserID,value);
				this._UserID=value;
			}
		}
		/// <summary>
		/// 部门编号
		/// </summary>
		public string DepartCode
		{
			get{ return _DepartCode; }
			set
			{
				this.OnPropertyValueChange(_.DepartCode,_DepartCode,value);
				this._DepartCode=value;
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
				_.UserID,
				_.DepartCode};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._UserID,
				this._DepartCode};
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
			public readonly static Field All = new Field("*","Sys_User_Dept");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","Sys_User_Dept","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UserID = new Field("UserID","Sys_User_Dept","UserID");
			/// <summary>
			/// 部门编号
			/// </summary>
			public readonly static Field DepartCode = new Field("DepartCode","Sys_User_Dept","部门编号");
		}
		#endregion


	}
}

