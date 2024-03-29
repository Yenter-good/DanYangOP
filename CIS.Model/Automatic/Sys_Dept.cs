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
    /// 实体类Sys_Dept 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_Dept")]
	[Serializable]
	public partial class Sys_Dept : Entity 
	{
		#region Model
		private string _ID;
		private string _Code;
		private string _PCode;
		private string _Name;
		private int _Status;
		private int? _Type;
		private string _Category;
		private string _Category_Code;
		private string _SearchCode;
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
		/// 
		/// </summary>
		public string PCode
		{
			get{ return _PCode; }
			set
			{
				this.OnPropertyValueChange(_.PCode,_PCode,value);
				this._PCode=value;
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
		/// 状态（0启用 1停用）
		/// </summary>
		public int Status
		{
			get{ return _Status; }
			set
			{
				this.OnPropertyValueChange(_.Status,_Status,value);
				this._Status=value;
			}
		}
		/// <summary>
		/// 部门类型（1门诊 2护理 3临床 4医技 5急诊 6留观病房 7库房 8后勤 9行政职能）
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
		/// <summary>
		/// 部门归类名称（例如 内科  外科 等医学科室分类）
		/// </summary>
		public string Category
		{
			get{ return _Category; }
			set
			{
				this.OnPropertyValueChange(_.Category,_Category,value);
				this._Category=value;
			}
		}
		/// <summary>
		/// 部门分类代码
		/// </summary>
		public string Category_Code
		{
			get{ return _Category_Code; }
			set
			{
				this.OnPropertyValueChange(_.Category_Code,_Category_Code,value);
				this._Category_Code=value;
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
				_.PCode,
				_.Name,
				_.Status,
				_.Type,
				_.Category,
				_.Category_Code,
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
				this._PCode,
				this._Name,
				this._Status,
				this._Type,
				this._Category,
				this._Category_Code,
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
			public readonly static Field All = new Field("*","Sys_Dept");
			/// <summary>
			/// ID
			/// </summary>
			public readonly static Field ID = new Field("ID","Sys_Dept","ID");
			/// <summary>
			/// 代码
			/// </summary>
			public readonly static Field Code = new Field("Code","Sys_Dept","代码");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PCode = new Field("PCode","Sys_Dept","PCode");
			/// <summary>
			/// 名称
			/// </summary>
			public readonly static Field Name = new Field("Name","Sys_Dept","名称");
			/// <summary>
			/// 状态（0启用 1停用）
			/// </summary>
			public readonly static Field Status = new Field("Status","Sys_Dept","状态（0启用 1停用）");
			/// <summary>
			/// 部门类型（1门诊 2护理 3临床 4医技 5急诊 6留观病房 7库房 8后勤 9行政职能）
			/// </summary>
			public readonly static Field Type = new Field("Type","Sys_Dept","部门类型（1门诊 2护理 3临床 4医技 5急诊 6留观病房 7库房 8后勤 9行政职能）");
			/// <summary>
			/// 部门归类名称（例如 内科  外科 等医学科室分类）
			/// </summary>
			public readonly static Field Category = new Field("Category","Sys_Dept","部门归类名称（例如 内科  外科 等医学科室分类）");
			/// <summary>
			/// 部门分类代码
			/// </summary>
			public readonly static Field Category_Code = new Field("Category_Code","Sys_Dept","部门分类代码");
			/// <summary>
			/// 检索码
			/// </summary>
			public readonly static Field SearchCode = new Field("SearchCode","Sys_Dept","检索码");
		}
		#endregion


	}
}

