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
    /// 实体类OP_Dic_Report。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OP_Dic_Report : Entity, ICloneable
    {
        public OP_Dic_Report() : base("OP_Dic_Report") { }

        #region Model
        private string _ID;
        private string _SystemName;
        private string _ParentID;
        private string _ItemName;
        private string _Type;
        private string _Assembly;
        private string _NameSpace;
        private string _MethodName;
        private int? _No;
        private string _XML;
        private int? _Status;
        private bool _CanStatistic;

        /// <summary>
        /// 主键
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set
            {
                if (this._ID == value)
                    this.OnPropertyValueChange(_.ID, _ID, value);
                this._ID = value;
            }
        }
        /// <summary>
        /// 上级分组
        /// </summary>
        public string ParentID
        {
            get { return _ParentID; }
            set
            {
                if (this._ParentID == value)
                    this.OnPropertyValueChange(_.ParentID, _ParentID, value);
                this._ParentID = value;
            }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                if (this._ItemName == value)
                    this.OnPropertyValueChange(_.ItemName, _ItemName, value);
                this._ItemName = value;
            }
        }
        /// <summary>
        /// 操作方式
        /// </summary>
        public string Type
        {
            get { return _Type; }
            set
            {
                if (this._Type == value)
                    this.OnPropertyValueChange(_.Type, _Type, value);
                this._Type = value;
            }
        }
        /// <summary>
        /// 程序集
        /// </summary>
        public string Assembly
        {
            get { return _Assembly; }
            set
            {
                if (this._Assembly == value)
                    this.OnPropertyValueChange(_.Assembly, _Assembly, value);
                this._Assembly = value;
            }
        }
        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace
        {
            get { return _NameSpace; }
            set
            {
                if (this._NameSpace == value)
                    this.OnPropertyValueChange(_.NameSpace, _NameSpace, value);
                this._NameSpace = value;
            }
        }
        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName
        {
            get { return _MethodName; }
            set
            {
                if (this._MethodName == value)
                    this.OnPropertyValueChange(_.MethodName, _MethodName, value);
                this._MethodName = value;
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
                if (this._No == value)
                    this.OnPropertyValueChange(_.No, _No, value);
                this._No = value;
            }
        }
        /// <summary>
        /// 文档xml
        /// </summary>
        public string XML
        {
            get { return _XML; }
            set
            {
                if (this._XML == value)
                    this.OnPropertyValueChange(_.XML, _XML, value);
                this._XML = value;
            }
        }
        /// <summary>
        /// 状态   0启用 1停用
        /// </summary>
        public int? Status
        {
            get { return _Status; }
            set
            {
                if (this._Status == value)
                    this.OnPropertyValueChange(_.Status, _Status, value);
                this._Status = value;
            }
        }
        /// <summary>
        /// 是否可被统计
        /// </summary>
        public bool CanStatistic
        {
            get { return _CanStatistic; }
            set
            {
                if (this._CanStatistic == value)
                    this.OnPropertyValueChange(_.CanStatistic, _CanStatistic, value);
                this._CanStatistic = value;
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
                _.ID,
            };
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
                _.ID,
                _.ParentID,
                _.ItemName,
                _.Type,
                _.Assembly,
                _.NameSpace,
                _.MethodName,
                _.No,
                _.XML,
                _.Status,
                _.CanStatistic
            };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                this._ID,
                this._ParentID,
                this._ItemName,
                this._Type,
                this._Assembly,
                this._NameSpace,
                this._MethodName,
                this._No,
                this._XML,
                this._Status,
                this._CanStatistic
            };
        }

        public object Clone()
        {
            return new OP_Dic_Report
            {
                ID = this._ID,
                ParentID = this._ParentID,
                ItemName = this._ItemName,
                Type = this._Type,
                Assembly = this._Assembly,
                NameSpace = this._NameSpace,
                MethodName = this._MethodName,
                No = this._No,
                XML = this._XML,
                Status = this._Status,
                CanStatistic = this._CanStatistic,
            };
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
            public readonly static Field All = new Field("*", "OP_Dic_Report");
            /// <summary>
            /// 主键
            /// </summary>
            public readonly static Field ID = new Field("ID", "OP_Dic_Report", "主键");
            /// <summary>
            /// 上级分组
            /// </summary>
            public readonly static Field ParentID = new Field("ParentID", "OP_Dic_Report", "上级分组");
            /// <summary>
            /// 项目名称
            /// </summary>
            public readonly static Field ItemName = new Field("ItemName", "OP_Dic_Report", "项目名称");
            /// <summary>
            /// 操作方式
            /// </summary>
            public readonly static Field Type = new Field("Type", "OP_Dic_Report", "操作方式");
            /// <summary>
            /// 程序集
            /// </summary>
            public readonly static Field Assembly = new Field("Assembly", "OP_Dic_Report", "程序集");
            /// <summary>
            /// 命名空间
            /// </summary>
            public readonly static Field NameSpace = new Field("NameSpace", "OP_Dic_Report", "命名空间");
            /// <summary>
            /// 方法名
            /// </summary>
            public readonly static Field MethodName = new Field("MethodName", "OP_Dic_Report", "方法名");
            /// <summary>
            /// 排序
            /// </summary>
            public readonly static Field No = new Field("No", "OP_Dic_Report", "排序");
            /// <summary>
            /// 文档xml
            /// </summary>
            public readonly static Field XML = new Field("XML", "OP_Dic_Report", "文档xml");
            /// <summary>
            /// 状态   0启用 1停用
            /// </summary>
            public readonly static Field Status = new Field("Status", "OP_Dic_Report", "状态   0启用 1停用");
            /// <summary>
            /// 是否可被统计
            /// </summary>
            public readonly static Field CanStatistic = new Field("CanStatistic", "OP_Dic_Report", "是否可被统计");
        }
        #endregion
    }
}