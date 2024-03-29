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
    /// 实体类TP_WordLIB 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("TP_WordLIB")]
    [Serializable]
    public partial class TP_WordLIB : Entity
    {
        #region Model
        private string _ID;
        private string _ParentID;
        private string _UserID;
        private string _Name;
        private string _Description;
        private int? _No;
        private string _Content;
        private string _Format;
        private string _SearchCode;
        private string _SpellCode;
        private string _WubiCode;
        private string _Tag;
        private int? _NodeType;
        private int? _Status;
        private string _DTLimit;
        private int? _DNLimit;
        private string _TPLimit;
        private int? _SystemSign;
        private DateTime? _UpdateTime;
        private string _UpdatorID;
        /// <summary>
        /// 编号
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set
            {
                this.OnPropertyValueChange(_.ID, _ID, value);
                this._ID = value;
            }
        }
        /// <summary>
        /// 父节点编号
        /// </summary>
        public string ParentID
        {
            get { return _ParentID; }
            set
            {
                this.OnPropertyValueChange(_.ParentID, _ParentID, value);
                this._ParentID = value;
            }
        }
        /// <summary>
        /// 用户编号 * 代表全院通用
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set
            {
                this.OnPropertyValueChange(_.UserID, _UserID, value);
                this._UserID = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set
            {
                this.OnPropertyValueChange(_.Name, _Name, value);
                this._Name = value;
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set
            {
                this.OnPropertyValueChange(_.Description, _Description, value);
                this._Description = value;
            }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? No
        {
            get { return _No; }
            set
            {
                this.OnPropertyValueChange(_.No, _No, value);
                this._No = value;
            }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set
            {
                this.OnPropertyValueChange(_.Content, _Content, value);
                this._Content = value;
            }
        }
        /// <summary>
        /// 格式
        /// </summary>
        public string Format
        {
            get { return _Format; }
            set
            {
                this.OnPropertyValueChange(_.Format, _Format, value);
                this._Format = value;
            }
        }
        /// <summary>
        /// 检索码
        /// </summary>
        public string SearchCode
        {
            get { return _SearchCode; }
            set
            {
                this.OnPropertyValueChange(_.SearchCode, _SearchCode, value);
                this._SearchCode = value;
            }
        }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string SpellCode
        {
            get { return _SpellCode; }
            set
            {
                this.OnPropertyValueChange(_.SpellCode, _SpellCode, value);
                this._SpellCode = value;
            }
        }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string WubiCode
        {
            get { return _WubiCode; }
            set
            {
                this.OnPropertyValueChange(_.WubiCode, _WubiCode, value);
                this._WubiCode = value;
            }
        }
        /// <summary>
        /// 特征码
        /// </summary>
        public string Tag
        {
            get { return _Tag; }
            set
            {
                this.OnPropertyValueChange(_.Tag, _Tag, value);
                this._Tag = value;
            }
        }
        /// <summary>
        /// 节点类型 0 文件夹 1 内容
        /// </summary>
        public int? NodeType
        {
            get { return _NodeType; }
            set
            {
                this.OnPropertyValueChange(_.NodeType, _NodeType, value);
                this._NodeType = value;
            }
        }
        /// <summary>
        /// 状态 0停用 1 启用 2 作废
        /// </summary>
        public int? Status
        {
            get { return _Status; }
            set
            {
                this.OnPropertyValueChange(_.Status, _Status, value);
                this._Status = value;
            }
        }
        /// <summary>
        /// 科室限制
        /// </summary>
        public string DTLimit
        {
            get { return _DTLimit; }
            set
            {
                this.OnPropertyValueChange(_.DTLimit, _DTLimit, value);
                this._DTLimit = value;
            }
        }
        /// <summary>
        /// 医护限制 0 无限制 1 医生专用 2 护士专用
        /// </summary>
        public int? DNLimit
        {
            get { return _DNLimit; }
            set
            {
                this.OnPropertyValueChange(_.DNLimit, _DNLimit, value);
                this._DNLimit = value;
            }
        }
        /// <summary>
        /// 模板限制
        /// </summary>
        public string TPLimit
        {
            get { return _TPLimit; }
            set
            {
                this.OnPropertyValueChange(_.TPLimit, _TPLimit, value);
                this._TPLimit = value;
            }
        }
        /// <summary>
        /// 系统标记 0 住院 1 门诊
        /// </summary>
        public int? SystemSign
        {
            get { return _SystemSign; }
            set
            {
                this.OnPropertyValueChange(_.SystemSign, _SystemSign, value);
                this._SystemSign = value;
            }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime
        {
            get { return _UpdateTime; }
            set
            {
                this.OnPropertyValueChange(_.UpdateTime, _UpdateTime, value);
                this._UpdateTime = value;
            }
        }
        /// <summary>
        /// 更新人员编号
        /// </summary>
        public string UpdatorID
        {
            get { return _UpdatorID; }
            set
            {
                this.OnPropertyValueChange(_.UpdatorID, _UpdatorID, value);
                this._UpdatorID = value;
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
				_.UserID,
				_.Name,
				_.Description,
				_.No,
				_.Content,
				_.Format,
				_.SearchCode,
				_.SpellCode,
				_.WubiCode,
				_.Tag,
				_.NodeType,
				_.Status,
				_.DTLimit,
				_.DNLimit,
				_.TPLimit,
				_.SystemSign,
				_.UpdateTime,
				_.UpdatorID};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._ParentID,
				this._UserID,
				this._Name,
				this._Description,
				this._No,
				this._Content,
				this._Format,
				this._SearchCode,
				this._SpellCode,
				this._WubiCode,
				this._Tag,
				this._NodeType,
				this._Status,
				this._DTLimit,
				this._DNLimit,
				this._TPLimit,
				this._SystemSign,
				this._UpdateTime,
				this._UpdatorID};
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
            public readonly static Field All = new Field("*", "TP_WordLIB");
            /// <summary>
            /// 编号
            /// </summary>
            public readonly static Field ID = new Field("ID", "TP_WordLIB", "编号");
            /// <summary>
            /// 父节点编号
            /// </summary>
            public readonly static Field ParentID = new Field("ParentID", "TP_WordLIB", "父节点编号");
            /// <summary>
            /// 用户编号 * 代表全院通用
            /// </summary>
            public readonly static Field UserID = new Field("UserID", "TP_WordLIB", "用户编号 * 代表全院通用");
            /// <summary>
            /// 名称
            /// </summary>
            public readonly static Field Name = new Field("Name", "TP_WordLIB", "名称");
            /// <summary>
            /// 描述
            /// </summary>
            public readonly static Field Description = new Field("Description", "TP_WordLIB", "描述");
            /// <summary>
            /// 排序
            /// </summary>
            public readonly static Field No = new Field("No", "TP_WordLIB", "排序");
            /// <summary>
            /// 内容
            /// </summary>
            public readonly static Field Content = new Field("Content", "TP_WordLIB", "内容");
            /// <summary>
            /// 格式
            /// </summary>
            public readonly static Field Format = new Field("Format", "TP_WordLIB", "格式");
            /// <summary>
            /// 检索码
            /// </summary>
            public readonly static Field SearchCode = new Field("SearchCode", "TP_WordLIB", "检索码");
            /// <summary>
            /// 拼音码
            /// </summary>
            public readonly static Field SpellCode = new Field("SpellCode", "TP_WordLIB", "拼音码");
            /// <summary>
            /// 五笔码
            /// </summary>
            public readonly static Field WubiCode = new Field("WubiCode", "TP_WordLIB", "五笔码");
            /// <summary>
            /// 特征码
            /// </summary>
            public readonly static Field Tag = new Field("Tag", "TP_WordLIB", "特征码");
            /// <summary>
            /// 节点类型 0 文件夹 1 内容
            /// </summary>
            public readonly static Field NodeType = new Field("NodeType", "TP_WordLIB", "节点类型 0 文件夹 1 内容");
            /// <summary>
            /// 状态 0停用 1 启用 2 作废
            /// </summary>
            public readonly static Field Status = new Field("Status", "TP_WordLIB", "状态 0停用 1 启用 2 作废");
            /// <summary>
            /// 科室限制
            /// </summary>
            public readonly static Field DTLimit = new Field("DTLimit", "TP_WordLIB", "科室限制");
            /// <summary>
            /// 医护限制 0 无限制 1 医生专用 2 护士专用
            /// </summary>
            public readonly static Field DNLimit = new Field("DNLimit", "TP_WordLIB", "医护限制 0 无限制 1 医生专用 2 护士专用");
            /// <summary>
            /// 模板限制
            /// </summary>
            public readonly static Field TPLimit = new Field("TPLimit", "TP_WordLIB", "模板限制");
            /// <summary>
            /// 系统标记 0 住院 1 门诊
            /// </summary>
            public readonly static Field SystemSign = new Field("SystemSign", "TP_WordLIB", "系统标记 0 住院 1 门诊");
            /// <summary>
            /// 更新时间
            /// </summary>
            public readonly static Field UpdateTime = new Field("UpdateTime", "TP_WordLIB", "更新时间");
            /// <summary>
            /// 更新人员编号
            /// </summary>
            public readonly static Field UpdatorID = new Field("UpdatorID", "TP_WordLIB", "更新人员编号");
        }
        #endregion


    }
}

