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
    /// 数据源节点
    /// </summary>
    [XmlRoot("Node")]
    [Serializable]
    public class TxDataSourceNode:ICloneable
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否可见
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 字段集合
        /// </summary>
        [XmlArrayItem("Field", typeof(TxDataField))]
        public TxDataFieldList Fields { get; set; }

        //public string InsertScript { get; set; }
        //public string DeleteScript { get; set; }
        //public string UpdateScript { get; set; }
        //public string SelectOneRecordScript { get; set; }
        //public string SelectListScript { get; set; }
        public TxDataSourceNode()
        {
 
        }

        /// <summary>
        /// 修正
        /// </summary>
        public void FixDomState()
        {
            if (this.Fields == null) return;
            foreach (var item in this.Fields)
            {
                item.Owner = this; 
            }
        }
        public object Clone()
        {
            return null;
        }
    }
    /// <summary>
    /// 数据源节点
    /// </summary>
    public class TxDataSourceNodeList : List<TxDataSourceNode>,ICloneable   
    {
        public TxDataSourceNode this[string id]
        {
            get
            {
                foreach (var item in this)
                {
                    if (item.ID == id)
                        return item;
                }
                return null;              
            }
        }
        public TxDataSourceNodeList()
        {
 
        }
        public object Clone()
        {
            TxDataSourceNodeList list = new TxDataSourceNodeList();
            foreach (var item in this)
            {
                list.Add(item.Clone() as TxDataSourceNode);
            }
            return list;
        }
        
    }
}
