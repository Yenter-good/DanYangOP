using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace CIS.Template
{
    /// <summary>
    /// 数据源类
    /// </summary>
    [XmlRoot("DataSource")]
    [Serializable]
    public class TxDataSource
    {
        /// <summary>
        /// 数据源节点集合
        /// </summary>
        [XmlArrayItem("Node",typeof(TxDataSourceNode))]
        public TxDataSourceNodeList Nodes { get; private set; }
        public TxDataSource()
        {
            this.Nodes = new TxDataSourceNodeList();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //获取数据库中配置的数据源信息
            var tpSources =  CIS.Model.DBHelper.CIS.From<CIS.Model.TP_DataSource>()
                .Select(d=>d.Script)
                .Where(d => d.Status == 1)
                .OrderBy(d=>d.No)
                .ToList();
            foreach (var item in tpSources)
            {
                if (item.Script.IsNullOrWhiteSpace())
                    continue;
                try
                {
                    var dsn = CIS.Utility.XMLHelper.LoadObjectFromXMLString(typeof(TxDataSourceNode), item.Script) as TxDataSourceNode;
                    this.Nodes.Add(dsn);
                }
                catch { }
            }
        }
        /// <summary>
        /// 通过类型注册数据源节点
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public TxDataSourceNode Register(Type type)
        {
            var node =this.Nodes[type.Name];
            if (node == null)
            {
                node = TxDataSource.CreateNode(type);
                this.Nodes.Add(node);
            }
            return node;
        }
        /// <summary>
        /// 通过类型创建数据源节点
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static  TxDataSourceNode CreateNode(Type type)
        {
            TxDataSourceNode node = new TxDataSourceNode();
            node.ID = Guid.NewGuid().ToString();
            node.Name = type.Name;
            node.Visible = true;
            node.Fields = new TxDataFieldList();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                TxDataField field = new TxDataField();
                field.ID = prop.Name;
                var description = Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute), true) as DescriptionAttribute;
                if (description != null)
                    field.Name = description.Description;
                else
                    field.Name = prop.Name;
                field.DataType = System.Data.DbType.String;
                field.ReadOnly = !prop.CanWrite;
                field.Required = prop.PropertyType.IsGenericType
                    && prop.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)) ? false : true;
                field.DataType = Convert(prop.PropertyType);

                node.Fields.Add(field);
            }
            node.FixDomState();
            return node;
        }
        /// <summary>
        /// 类型转换为数据类型 默认为字符串
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static System.Data.DbType Convert(Type type)
        {
            if (type == typeof(string))
                return System.Data.DbType.String;
            if (type == typeof(int) || type == typeof(Nullable<int>))
                return System.Data.DbType.Int32;
            if (type == typeof(float) || type == typeof(Nullable<float>))
                return System.Data.DbType.Single;
            if (type == typeof(decimal) || type == typeof(Nullable<decimal>))
                return System.Data.DbType.Decimal;
            if (type == typeof(double) || type == typeof(Nullable<double>))
                return System.Data.DbType.Double;
            if (type == typeof(DateTime) || type == typeof(Nullable<DateTime>))
                return System.Data.DbType.DateTime;
            if (type == typeof(bool) || type == typeof(Nullable<bool>))
                return System.Data.DbType.Boolean;
            if (type == typeof(byte) || type == typeof(Nullable<byte>))
                return System.Data.DbType.Byte;
            //if (type == typeof(byte[]) || type == typeof(Nullable<byte[]>))
            //    return System.Data.DbType.Binary;
            return System.Data.DbType.String;
        }
    }
}
