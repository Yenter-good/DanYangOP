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
    /// 实体类TP_ElementLIB 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("TP_ElementLIB")]
	[Serializable]
	public partial class TP_ElementLIB : Entity 
	{
		#region Model
		private string _ID;
		private string _ParentID;
		private string _Name;
		private string _Content;
		private string _Format;
		private int? _No;
		private string _SearchCode;
		private string _SpellCode;
		private string _WubiCode;
		private string _Tag;
		private int _NodeType;
		private int _Status;
		private DateTime _UpdateTime;
		private string _UpdatorID;
		private int? _SystemSign;
		/// <summary>
		/// 编号
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
		/// 父节点编号
		/// </summary>
		public string ParentID
		{
			get{ return _ParentID; }
			set
			{
				this.OnPropertyValueChange(_.ParentID,_ParentID,value);
				this._ParentID=value;
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
		/// 内容
		/// </summary>
		public string Content
		{
			get{ return _Content; }
			set
			{
				this.OnPropertyValueChange(_.Content,_Content,value);
				this._Content=value;
			}
		}
		/// <summary>
		/// 格式
		/// </summary>
		public string Format
		{
			get{ return _Format; }
			set
			{
				this.OnPropertyValueChange(_.Format,_Format,value);
				this._Format=value;
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
		/// <summary>
		/// 拼音码
		/// </summary>
		public string SpellCode
		{
			get{ return _SpellCode; }
			set
			{
				this.OnPropertyValueChange(_.SpellCode,_SpellCode,value);
				this._SpellCode=value;
			}
		}
		/// <summary>
		/// 五笔码
		/// </summary>
		public string WubiCode
		{
			get{ return _WubiCode; }
			set
			{
				this.OnPropertyValueChange(_.WubiCode,_WubiCode,value);
				this._WubiCode=value;
			}
		}
		/// <summary>
		/// 特征码
		/// </summary>
		public string Tag
		{
			get{ return _Tag; }
			set
			{
				this.OnPropertyValueChange(_.Tag,_Tag,value);
				this._Tag=value;
			}
		}
		/// <summary>
		/// 节点类型 0 文件夹 1 内容
		/// </summary>
		public int NodeType
		{
			get{ return _NodeType; }
			set
			{
				this.OnPropertyValueChange(_.NodeType,_NodeType,value);
				this._NodeType=value;
			}
		}
		/// <summary>
		/// 状态 0 停用 1 启用
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
		/// 更新时间
		/// </summary>
		public DateTime UpdateTime
		{
			get{ return _UpdateTime; }
			set
			{
				this.OnPropertyValueChange(_.UpdateTime,_UpdateTime,value);
				this._UpdateTime=value;
			}
		}
		/// <summary>
		/// 更新人编号
		/// </summary>
		public string UpdatorID
		{
			get{ return _UpdatorID; }
			set
			{
				this.OnPropertyValueChange(_.UpdatorID,_UpdatorID,value);
				this._UpdatorID=value;
			}
		}
		/// <summary>
		/// 系统标记 0 住院 1 门诊
		/// </summary>
		public int? SystemSign
		{
			get{ return _SystemSign; }
			set
			{
				this.OnPropertyValueChange(_.SystemSign,_SystemSign,value);
				this._SystemSign=value;
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
				_.ParentID,
				_.Name,
				_.Content,
				_.Format,
				_.No,
				_.SearchCode,
				_.SpellCode,
				_.WubiCode,
				_.Tag,
				_.NodeType,
				_.Status,
				_.UpdateTime,
				_.UpdatorID,
				_.SystemSign};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._ParentID,
				this._Name,
				this._Content,
				this._Format,
				this._No,
				this._SearchCode,
				this._SpellCode,
				this._WubiCode,
				this._Tag,
				this._NodeType,
				this._Status,
				this._UpdateTime,
				this._UpdatorID,
				this._SystemSign};
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
			public readonly static Field All = new Field("*","TP_ElementLIB");
			/// <summary>
			/// 编号
			/// </summary>
			public readonly static Field ID = new Field("ID","TP_ElementLIB","编号");
			/// <summary>
			/// 父节点编号
			/// </summary>
			public readonly static Field ParentID = new Field("ParentID","TP_ElementLIB","父节点编号");
			/// <summary>
			/// 名称
			/// </summary>
			public readonly static Field Name = new Field("Name","TP_ElementLIB","名称");
			/// <summary>
			/// 内容
			/// </summary>
			public readonly static Field Content = new Field("Content","TP_ElementLIB","内容");
			/// <summary>
			/// 格式
			/// </summary>
			public readonly static Field Format = new Field("Format","TP_ElementLIB","格式");
			/// <summary>
			/// 序号
			/// </summary>
			public readonly static Field No = new Field("No","TP_ElementLIB","序号");
			/// <summary>
			/// 检索码
			/// </summary>
			public readonly static Field SearchCode = new Field("SearchCode","TP_ElementLIB","检索码");
			/// <summary>
			/// 拼音码
			/// </summary>
			public readonly static Field SpellCode = new Field("SpellCode","TP_ElementLIB","拼音码");
			/// <summary>
			/// 五笔码
			/// </summary>
			public readonly static Field WubiCode = new Field("WubiCode","TP_ElementLIB","五笔码");
			/// <summary>
			/// 特征码
			/// </summary>
			public readonly static Field Tag = new Field("Tag","TP_ElementLIB","特征码");
			/// <summary>
			/// 节点类型 0 文件夹 1 内容
			/// </summary>
			public readonly static Field NodeType = new Field("NodeType","TP_ElementLIB","节点类型 0 文件夹 1 内容");
			/// <summary>
			/// 状态 0 停用 1 启用
			/// </summary>
			public readonly static Field Status = new Field("Status","TP_ElementLIB","状态 0 停用 1 启用");
			/// <summary>
			/// 更新时间
			/// </summary>
			public readonly static Field UpdateTime = new Field("UpdateTime","TP_ElementLIB","更新时间");
			/// <summary>
			/// 更新人编号
			/// </summary>
			public readonly static Field UpdatorID = new Field("UpdatorID","TP_ElementLIB","更新人编号");
			/// <summary>
			/// 系统标记 0 住院 1 门诊
			/// </summary>
			public readonly static Field SystemSign = new Field("SystemSign","TP_ElementLIB","系统标记 0 住院 1 门诊");
		}
		#endregion


	}
}

