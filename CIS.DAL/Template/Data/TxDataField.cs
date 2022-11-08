using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CIS.DAL.Template
{
    /// <summary>
    /// 数据字段
    /// </summary>
    [Serializable]
    public class TxDataField:ICloneable
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
        /// 是否必须
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool ReadOnly { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public System.Data.DbType DataType { get; set; } 
        /// <summary>
        /// 是否可见
        /// </summary>
        public bool Visible { get; set; }
        [XmlIgnore]
        public TxDataSourceNode Owner { get; set; }
        public TxDataField()
        {
            this.DataType = System.Data.DbType.String;
            this.Visible = true;
        }
        /// <summary>
        /// 移除自身
        /// </summary>
        public void Remove()
        {
            if (this.Owner != null)
                this.Owner.Fields.Remove(this);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 数据字段集合
    /// </summary>
    [Serializable]
    public class TxDataFieldList : List<TxDataField>,ICloneable
    {
        public TxDataField this[string id]
        {
            get
            {
                foreach (TxDataField field in this)
                {
                    if (string.Compare(field.ID, id, true) == 0)
                    {
                        return field;
                    }
                }
                return null;
            }
        }
        public TxDataFieldList()
        {
 
        }
        public object Clone()
        {
            TxDataFieldList list = new TxDataFieldList();
            foreach (var item in this)
            {
                list.Add(item.Clone() as TxDataField);
            }
            return list;
        }
    }
}
