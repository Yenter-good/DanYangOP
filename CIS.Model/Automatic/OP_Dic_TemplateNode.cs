﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
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
    /// 实体类OP_Dic_TemplateNode 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("OP_Dic_TemplateNode")]
	[Serializable]
	public partial class OP_Dic_TemplateNode : Entity 
	{
		#region Model
		private string _Code;
		private string _Name;
		private int? _No;
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
				_.No};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Code,
				this._Name,
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
			public readonly static Field All = new Field("*","OP_Dic_TemplateNode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Code = new Field("Code","OP_Dic_TemplateNode","Code");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Name = new Field("Name","OP_Dic_TemplateNode","Name");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field No = new Field("No","OP_Dic_TemplateNode","No");
		}
		#endregion


	}
}

