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
    /// 实体类Sys_Module 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_Module")]
	[Serializable]
	public partial class Sys_Module : Entity 
	{
		#region Model
		private int _ID;
		private string _Code;
		private string _PCode;
		private string _Text;
		private string _FName;
		private string _IconCls;
		private int? _No;
		private string _OpenStyle;
		private int? _Status;
		private string _RNO;
		/// <summary>
		/// 自增列
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
		/// 上级代码
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
		/// 菜单名称
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
		/// 窗体文件名
		/// </summary>
		public string FName
		{
			get{ return _FName; }
			set
			{
				this.OnPropertyValueChange(_.FName,_FName,value);
				this._FName=value;
			}
		}
		/// <summary>
		/// 菜单样式
		/// </summary>
		public string IconCls
		{
			get{ return _IconCls; }
			set
			{
				this.OnPropertyValueChange(_.IconCls,_IconCls,value);
				this._IconCls=value;
			}
		}
		/// <summary>
		/// 序号
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
		/// 打开方式
		/// </summary>
		public string OpenStyle
		{
			get{ return _OpenStyle; }
			set
			{
				this.OnPropertyValueChange(_.OpenStyle,_OpenStyle,value);
				this._OpenStyle=value;
			}
		}
		/// <summary>
		/// _0停用 1启用
		/// </summary>
		public int? Status
		{
			get{ return _Status; }
			set
			{
				this.OnPropertyValueChange(_.Status,_Status,value);
				this._Status=value;
			}
		}
		/// <summary>
		/// 菜单所属系统
		/// </summary>
		public string RNO
		{
			get{ return _RNO; }
			set
			{
				this.OnPropertyValueChange(_.RNO,_RNO,value);
				this._RNO=value;
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
				_.PCode,
				_.Text,
				_.FName,
				_.IconCls,
				_.No,
				_.OpenStyle,
				_.Status,
				_.RNO};
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
				this._Text,
				this._FName,
				this._IconCls,
				this._No,
				this._OpenStyle,
				this._Status,
				this._RNO};
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
			public readonly static Field All = new Field("*","Sys_Module");
			/// <summary>
			/// 自增列
			/// </summary>
			public readonly static Field ID = new Field("ID","Sys_Module","自增列");
			/// <summary>
			/// 代码
			/// </summary>
			public readonly static Field Code = new Field("Code","Sys_Module","代码");
			/// <summary>
			/// 上级代码
			/// </summary>
			public readonly static Field PCode = new Field("PCode","Sys_Module","上级代码");
			/// <summary>
			/// 菜单名称
			/// </summary>
			public readonly static Field Text = new Field("Text","Sys_Module","菜单名称");
			/// <summary>
			/// 窗体文件名
			/// </summary>
			public readonly static Field FName = new Field("FName","Sys_Module","窗体文件名");
			/// <summary>
			/// 菜单样式
			/// </summary>
			public readonly static Field IconCls = new Field("IconCls","Sys_Module","菜单样式");
			/// <summary>
			/// 序号
			/// </summary>
			public readonly static Field No = new Field("No","Sys_Module","序号");
			/// <summary>
			/// 打开方式
			/// </summary>
			public readonly static Field OpenStyle = new Field("OpenStyle","Sys_Module","打开方式");
			/// <summary>
			/// _0停用 1启用
			/// </summary>
			public readonly static Field Status = new Field("Status","Sys_Module","_0停用 1启用");
			/// <summary>
			/// 菜单所属系统
			/// </summary>
			public readonly static Field RNO = new Field("RNO","Sys_Module","菜单所属系统");
		}
		#endregion


	}
}

