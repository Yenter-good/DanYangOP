using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;

namespace CIS.ControlLib.Components
{
    [ProvideProperty("ValueBinding", typeof(System.Windows.Forms.Control))]
    public class BindingManager :Component, IExtenderProvider
    {
        private XDataBindingProvider provider;
        private Hashtable datasources;
        private Hashtable valueBindings;
        public BindingManager()
        {
            provider = new XDataBindingProvider();
            datasources = new Hashtable();
            valueBindings = new Hashtable();
        }
        public BindingManager(IContainer parent):this()
        {
            parent.Add(this);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            datasources.Clear();
            datasources = null;
            valueBindings.Clear();
            valueBindings = null;
            provider = null;

        }
        public bool CanExtend(object extendee)
        {
            if (extendee is System.Windows.Forms.ListControl
                || extendee is System.Windows.Forms.TextBoxBase
                || extendee is System.Windows.Forms.DateTimePicker
                || extendee is System.Windows.Forms.NumericUpDown
                || extendee is System.Windows.Forms.Label
                || extendee is System.Windows.Forms.CheckBox
                || extendee is System.Windows.Forms.RadioButton
                || extendee is ToolStripItem)
            {
                return true;
            }
            return false;
        }

        public XDataBinding GetValueBinding(object extendee)
        {
            XDataBinding valudBinding=valueBindings[extendee] as XDataBinding;
            if (valudBinding == null)
            {
                return new XDataBinding();
            }
            return valudBinding;
        }

        public void SetValueBinding(object extendee,XDataBinding valueBinding)
        {
            if (valueBinding == null)
                valueBindings.Remove(extendee);
            else
                valueBindings[extendee]=valueBinding;
        }

        public void SetDataSource(string dataSourceName, object dataSource)
        {
            if (dataSource == null)
                this.datasources.Remove(dataSourceName);
            else
                this.datasources[dataSourceName] = dataSource;
        }

        public object GetDataSource(string dataSourceName)
        {
            return this.datasources[dataSourceName];
        }

        private object GetExtendeeValue(object extendee)
        {
            if (extendee is System.Windows.Forms.TextBoxBase)
                return (extendee as System.Windows.Forms.TextBoxBase).Text.Trim();
            if (extendee is System.Windows.Forms.NumericUpDown)
                return (extendee as System.Windows.Forms.NumericUpDown).Value;
            if (extendee is System.Windows.Forms.DateTimePicker)
                return (extendee as System.Windows.Forms.DateTimePicker).Value;
            if (extendee is RadioButton)
                return (extendee as RadioButton).Checked;
            if (extendee is CheckBox)
                return (extendee as CheckBox).Checked;
            if (extendee is System.Windows.Forms.ListControl)
            {
                var list = extendee as ListControl;
                if (string.IsNullOrWhiteSpace(list.ValueMember))
                    return list.Text;
                else
                    return list.SelectedValue;
            }
            if (extendee is ToolStripItem)
            {
                if (extendee is ToolStripComboBox)
                {
                    var tscb = extendee as ToolStripComboBox;
                    if (string.IsNullOrWhiteSpace(tscb.ComboBox.ValueMember))
                        return tscb.Text.Trim();
                    return tscb.ComboBox.SelectedValue;
                }
                return (extendee as ToolStripItem).Text.Trim();
            }
            if (extendee is System.Windows.Forms.Control)
                return (extendee as System.Windows.Forms.Control).Text.Trim();
            return null;
        }
        private void SetExtendeeValue(object extendee, object value)
        {
            if (extendee is System.Windows.Forms.TextBoxBase)
            { (extendee as System.Windows.Forms.TextBoxBase).Text = value.AsString();
                return;
            }
            if (extendee is System.Windows.Forms.NumericUpDown)
            {
                var nud =extendee as System.Windows.Forms.NumericUpDown;
                decimal v=value.AsDecimal(0);
                if (v > nud.Maximum)
                    nud.Value = nud.Maximum;
                else
                    if (v < nud.Minimum)
                        nud.Value = nud.Minimum;
                    else
                        nud.Value = v;
            }
            if (extendee is System.Windows.Forms.DateTimePicker)
            {
                var dtp = (extendee as System.Windows.Forms.DateTimePicker);
                var t = value.AsDateTime(DateTime.Now);
                if (dtp.MaxDate < t)
                    dtp.Value = dtp.MaxDate;
                else
                    if (t < dtp.MinDate)
                        dtp.Value = dtp.MinDate;
                    else
                        dtp.Value = t;
            }
            if (extendee is RadioButton)
            {
                (extendee as RadioButton).Checked = value.AsBoolean();
                return;
            }
            if (extendee is CheckBox)
            {
                (extendee as CheckBox).Checked = value.AsBoolean();
                return;
            }


            if (extendee is System.Windows.Forms.ListControl)
            {
                var list = extendee as ListControl;
                if (string.IsNullOrWhiteSpace(list.ValueMember))
                { list.Text = value.AsString(); return; }
                else
                {
                    list.SelectedValue = value;
                    return;
                }
            }
            if (extendee is ToolStripItem)
            {
                if (extendee is ToolStripComboBox)
                {
                    var tscb = extendee as ToolStripComboBox;
                    if (string.IsNullOrWhiteSpace(tscb.ComboBox.ValueMember))
                    {
                        tscb.Text = value.AsString();
                        return;
                    }
                    tscb.ComboBox.SelectedValue = value;
                    return;
                }
                (extendee as ToolStripItem).Text = value.AsString();
                return;
            }
            if (extendee is System.Windows.Forms.Control)
            {
                (extendee as System.Windows.Forms.Control).Text = value.AsString();
                return;
            }
        }

        public void UpdateDataSourceForView()
        {
            if (this.datasources.Count == 0) return;
            if (this.valueBindings.Count == 0) return;
            foreach (DictionaryEntry datasource in this.datasources)
            {
                this.UpdateSpecifyDataSourceForView(datasource.Key.ToString());
            }
        }

        public void UpdateSpecifyDataSourceForView(string dataSourceName)
        {
            if(!this.datasources.ContainsKey(dataSourceName))
            {
                return;
            }
            foreach (DictionaryEntry item in this.valueBindings)
            {
                XDataBinding valueBinding = item.Value as XDataBinding;
                if (valueBinding != null)
                {
                    if (valueBinding.DataSource == dataSourceName)
                    {
                        provider.WriteValue(valueBinding, this.datasources[dataSourceName], this.GetExtendeeValue(item.Key), true);
                    }
                }
            }
        }

        public void UpdateViewForDataSource()
        {
            if (this.datasources.Count == 0) return;
            if (this.valueBindings.Count == 0) return;
            foreach (DictionaryEntry datasource in this.datasources)
            {
                this.UpdateViewForSpecifyDataSource(datasource.Key.ToString());
            }
        }

        public void UpdateViewForSpecifyDataSource(string dataSourceName)
        {
            if (!this.datasources.ContainsKey(dataSourceName)) return;

            foreach (DictionaryEntry item in this.valueBindings)
            {
                var valueBinding = item.Value as XDataBinding;
                if (valueBinding == null) continue;
                if (valueBinding.DataSource != dataSourceName) continue;

                this.SetExtendeeValue(item.Key, provider.ReadValue(valueBinding, this.datasources[dataSourceName], null, false));
            }
        }
    }
    [TypeConverter(typeof(Converters.XDataBindingConverter))]
    [Serializable]
    public class XDataBinding : ICloneable
    {
        private string _DataSource = null;
        private string _FormatString = null;
        private string _BindingPath = null;
        private bool _AutoUpdate = false;
        private bool _Readonly = true;
        /// <summary>
        /// 数据源名称
        /// </summary>
        [DefaultValue(null)]
        public string DataSource
        {
            get
            {
                return this._DataSource;
            }
            set
            {
                this._DataSource = value;
            }
        }
        /// <summary>
        /// 格式化
        /// </summary>
        public string FormatString
        {
            get
            {
                return this._FormatString;
            }
            set
            {
                this._FormatString = value;
            }
        }
        /// <summary>
        /// 读取路径
        /// </summary>
        [DefaultValue(null)]
        public string BindingPath
        {
            get
            {
                return this._BindingPath;
            }
            set
            {
                this._BindingPath = value;
            }
        }
        /// <summary>
        /// 暂时未使用
        /// </summary>
        [DefaultValue(false)]
        public bool AutoUpdate
        {
            get
            {
                return this._AutoUpdate;
            }
            set
            {
                this._AutoUpdate = value;
            }
        }
        /// <summary>
        /// 暂时未使用
        /// </summary>
        [DefaultValue(true)]
        public bool Readonly
        {
            get
            {
                return this._Readonly;
            }
            set
            {
                this._Readonly = value;
            }
        }

        public XDataBinding() { }

        public XDataBinding(string dataSource,string bindingPath,string formatString) {
            this.FormatString = formatString;
            this.BindingPath = bindingPath;
            this.DataSource = dataSource;
        }
        public XDataBinding Clone()
        {
            return (XDataBinding)((ICloneable)this).Clone();
        }
        object ICloneable.Clone()
        {
            return (XDataBinding)base.MemberwiseClone();
        }
        public override string ToString()
        {
            string text = this.DataSource;
            if (!string.IsNullOrEmpty(this.BindingPath))
            {
                text = text + "[" + this.BindingPath + "]";
            }
            return text;
        }

 
    }


    public class XDataBindingProvider
    {
        //public virtual object DomReadValue(WriterAppHost host, XTextDocument document, XTextElement element, XDataBinding binding, bool throwException)
        //{
        //    object parameterValue = document.GetParameterValue(binding.DataSource);
        //    object result;
        //    if (parameterValue != null)
        //    {
        //        object obj = this.ReadValue(binding, parameterValue, null, throwException);
        //        result = obj;
        //    }
        //    else
        //    {
        //        result = null;
        //    }
        //    return result;
        //}
        //public virtual bool DomWriteValue(WriterAppHost host, XTextDocument document, XTextElement element, XDataBinding binding, object newValue, bool throwException)
        //{
        //    bool result = false;
        //    if (!binding.Readonly)
        //    {
        //        if (string.IsNullOrEmpty(binding.BindingPath))
        //        {
        //            DocumentParameter documentParameter = document.Parameters[binding.DataSource];
        //            if (documentParameter != null)
        //            {
        //                documentParameter.Value = newValue;
        //                result = true;
        //            }
        //        }
        //        else
        //        {
        //            object parameterValue = document.GetParameterValue(binding.DataSource);
        //            if (parameterValue != null)
        //            {
        //                result = this.WriteValue(binding, parameterValue, newValue, throwException);
        //            }
        //        }
        //    }
        //    return result;
        //}
        public virtual object ReadItemValue(XDataBindingPathItem item, object instance, object defaultValue, bool throwException)
        {
            return XDataBindingProvider.StdReadItemValue(item, instance, defaultValue, throwException);
        }
        public static object StdReadItemValue(XDataBindingPathItem item, object instance, object defaultValue, bool throwException)
        {
            object result;
            if (item == null)
            {
                if (throwException)
                {
                    throw new ArgumentNullException("item");
                }
                result = defaultValue;
            }
            else
            {
                if (instance == null)
                {
                    if (throwException)
                    {
                        throw new ArgumentNullException("instance");
                    }
                    result = defaultValue;
                }
                else
                {
                    if (!item.InstanceType.IsInstanceOfType(instance))
                    {
                        if (throwException)
                        {
                            throw new InvalidCastException(instance.GetType().FullName + "->" + item.InstanceType.FullName);
                        }
                        result = defaultValue;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(item.Name))
                        {
                            result = instance;
                        }
                        else
                        {
                            if (instance is IDictionary)
                            {
                                IDictionary dictionary = (IDictionary)instance;
                                if (dictionary.Contains(item.Name))
                                {
                                    result = dictionary[item.Name];
                                }
                                else
                                {
                                    result = defaultValue;
                                }
                            }
                            else
                            {
                                if (instance is XmlNode)
                                {
                                    XmlNode xmlNode = (XmlNode)instance;
                                    XmlNode xmlNode2 = xmlNode.SelectSingleNode(item.Name);
                                    if (xmlNode2 == null)
                                    {
                                        result = defaultValue;
                                    }
                                    else
                                    {
                                        if (xmlNode2 is XmlElement)
                                        {
                                            result = xmlNode2.InnerText;
                                        }
                                        else
                                        {
                                            result = xmlNode2.Value;
                                        }
                                    }
                                }
                                else
                                {
                                    if (instance is DataRow)
                                    {
                                        DataRow dataRow = (DataRow)instance;
                                        if (!dataRow.Table.Columns.Contains(item.Name))
                                        {
                                            if (throwException)
                                            {
                                                throw new IndexOutOfRangeException(item.Name);
                                            }
                                            result = defaultValue;
                                            return result;
                                        }
                                        else
                                        {
                                            if (throwException)
                                            {
                                                result = dataRow[item.Name];
                                                return result;
                                            }
                                            try
                                            {
                                                result = dataRow[item.Name];
                                                return result;
                                            }
                                            catch
                                            {
                                                result = defaultValue;
                                                return result;
                                            }
                                        }
                                    }
                                    if (instance is DataRowView)
                                    {
                                        DataRowView dataRowView = (DataRowView)instance;
                                        if (throwException)
                                        {
                                            result = dataRowView[item.Name];
                                            return result;
                                        }
                                        try
                                        {
                                            result = dataRowView[item.Name];
                                            return result;
                                        }
                                        catch
                                        {
                                            result = defaultValue;
                                            return result;
                                        }
                                    }
                                    if (instance is IDataRecord)
                                    {
                                        IDataRecord dataRecord = (IDataRecord)instance;
                                        int ordinal = dataRecord.GetOrdinal(item.Name);
                                        if (ordinal < 0)
                                        {
                                            if (throwException)
                                            {
                                                throw new IndexOutOfRangeException(item.Name);
                                            }
                                            result = defaultValue;
                                            return result;
                                        }
                                        else
                                        {
                                            if (throwException)
                                            {
                                                result = dataRecord.GetValue(ordinal);
                                                return result;
                                            }
                                            try
                                            {
                                                result = dataRecord.GetValue(ordinal);
                                                return result;
                                            }
                                            catch
                                            {
                                                result = defaultValue;
                                                return result;
                                            }
                                        }
                                    }
                                    if (throwException)
                                    {
                                        result = item.Property.GetValue(instance);
                                    }
                                    else
                                    {
                                        try
                                        {
                                            result = item.Property.GetValue(instance);
                                        }
                                        catch
                                        {
                                            result = defaultValue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        public virtual bool WriteItemValue(XDataBindingPathItem item, object instance, object newValue, bool throwException)
        {
            bool result;
            if (item == null)
            {
                if (throwException)
                {
                    throw new ArgumentNullException("item");
                }
                result = false;
            }
            else
            {
                if (instance == null)
                {
                    if (throwException)
                    {
                        throw new ArgumentNullException("instance");
                    }
                    result = false;
                }
                else
                {
                    if (!item.InstanceType.IsInstanceOfType(instance))
                    {
                        if (throwException)
                        {
                            throw new InvalidCastException(instance.GetType().FullName + ">" + item.InstanceType.FullName);
                        }
                        result = false;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(item.Name))
                        {
                            result = false;
                        }
                        else
                        {
                            if (instance is IDictionary)
                            {
                                IDictionary dictionary = (IDictionary)instance;
                                dictionary[item.Name] = newValue;
                                result = true;
                            }
                            else
                            {
                                if (instance is XmlNode)
                                {
                                    XmlNode xmlNode = (XmlNode)instance;
                                    string text = item.Name;
                                    XmlNode xmlNode2;
                                    if (text == null)
                                    {
                                        xmlNode2 = xmlNode;
                                    }
                                    else
                                    {
                                        text = text.Trim();
                                        if (text.Length == 0)
                                        {
                                            xmlNode2 = xmlNode;
                                        }
                                        else
                                        {
                                            xmlNode2 = xmlNode.SelectSingleNode(text);
                                            if (xmlNode2 == null)
                                            {
                                                if (XmlReader.IsName(text))
                                                {
                                                    xmlNode2 = xmlNode.OwnerDocument.CreateElement(text);
                                                    xmlNode.AppendChild(xmlNode2);
                                                }
                                                else
                                                {
                                                    if (text.StartsWith("@") && xmlNode is XmlElement)
                                                    {
                                                        text = text.Substring(1);
                                                        if (XmlReader.IsName(text))
                                                        {
                                                            xmlNode2 = xmlNode.OwnerDocument.CreateAttribute(text);
                                                            xmlNode.Attributes.Append((XmlAttribute)xmlNode2);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (xmlNode2 == null)
                                    {
                                        result = false;
                                    }
                                    else
                                    {
                                        if (xmlNode2 is XmlElement)
                                        {
                                            xmlNode2.InnerText = Convert.ToString(newValue);
                                        }
                                        else
                                        {
                                            xmlNode2.Value = Convert.ToString(newValue);
                                        }
                                        result = true;
                                    }
                                }
                                else
                                {
                                    if (instance is DataRow)
                                    {
                                        DataRow dataRow = (DataRow)instance;
                                        if (!dataRow.Table.Columns.Contains(item.Name))
                                        {
                                            if (throwException)
                                            {
                                                throw new IndexOutOfRangeException(item.Name);
                                            }
                                            result = false;
                                            return result;
                                        }
                                        else
                                        {
                                            if (throwException)
                                            {
                                                dataRow[item.Name] = newValue;
                                                result = true;
                                                return result;
                                            }
                                            try
                                            {
                                                dataRow[item.Name] = newValue;
                                                result = true;
                                                return result;
                                            }
                                            catch
                                            {
                                                result = false;
                                                return result;
                                            }
                                        }
                                    }
                                    if (instance is DataRowView)
                                    {
                                        DataRowView dataRowView = (DataRowView)instance;
                                        if (throwException)
                                        {
                                            dataRowView[item.Name] = newValue;
                                            result = true;
                                            return result;
                                        }
                                        try
                                        {
                                            dataRowView[item.Name] = newValue;
                                            result = true;
                                            return result;
                                        }
                                        catch
                                        {
                                            result = false;
                                            return result;
                                        }
                                    }
                                    if (throwException)
                                    {
                                        item.Property.SetValue(instance, newValue);
                                        result = true;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            item.Property.SetValue(instance, newValue);
                                            result = true;
                                        }
                                        catch
                                        {
                                            result = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        public virtual bool WriteValue(XDataBinding binding, object dataSourceInstance, object newValue, bool throwException)
        {
            bool result;
            if (dataSourceInstance == null)
            {
                if (throwException)
                {
                    throw new ArgumentNullException("dataSourceInstance");
                }
                result = false;
            }
            else
            {
                XDataBindingPath instance = XDataBindingPath.GetInstance(dataSourceInstance.GetType(), binding.BindingPath, throwException);
                if (instance != null)
                {
                    if (instance.Readonly)
                    {
                        if (throwException)
                        {
                            throw new NotSupportedException("Write " + instance.RootType.FullName + "." + instance.Path);
                        }
                        result = false;
                    }
                    else
                    {
                        object obj = dataSourceInstance;
                        for (int i = 0; i < instance.Items.Count - 1; i++)
                        {
                            object obj2 = this.ReadItemValue(instance.Items[i], obj, null, throwException);
                            if (obj2 == null)
                            {
                            }
                            obj = obj2;
                        }
                        if (obj == null)
                        {
                            result = false;
                        }
                        else
                        {
                            XDataBindingPathItem xDataBindingPathItem = instance.Items[instance.Items.Count - 1];
                            if (xDataBindingPathItem.Property != null && xDataBindingPathItem.Property.PropertyType != null)
                            {
                                newValue = this.ConvertType(binding, newValue, xDataBindingPathItem.Property.PropertyType);
                            }
                            result = this.WriteItemValue(xDataBindingPathItem, obj, newValue, throwException);
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        protected virtual object ConvertType(XDataBinding binding, object oldValue, Type descType)
        {
            object result;
            if (!string.IsNullOrEmpty(binding.FormatString) && descType.Equals(typeof(DateTime)))
            {
                DateTime now = DateTime.Now;
                DateTime.TryParseExact(Convert.ToString(oldValue), binding.FormatString, null, DateTimeStyles.AllowWhiteSpaces, out now);
                result = now;
            }
            else
            {
                TypeConverter converter = TypeDescriptor.GetConverter(descType);
                if (converter != null)
                {
                    result = converter.ConvertFrom(oldValue);
                }
                else
                {
                    result = oldValue;
                }
            }
            return result;
        }
        public virtual object ReadValue(XDataBinding binding, object dataSourceInstance, object defaultValue, bool throwException)
        {
            return XDataBindingProvider.StdReadValue(binding, dataSourceInstance, defaultValue, throwException, this);
        }
        public static object StdReadValue(XDataBinding binding, object dataSourceInstance, object defaultValue, bool throwException, XDataBindingProvider provider)
        {
            object result;
            if (dataSourceInstance == null)
            {
                if (throwException)
                {
                    throw new ArgumentNullException("dataSourceInstance");
                }
                result = false;
            }
            else
            {
                XDataBindingPath instance = XDataBindingPath.GetInstance(dataSourceInstance.GetType(), binding.BindingPath, throwException);
                if (instance != null)
                {
                    object obj = dataSourceInstance;
                    for (int i = 0; i < instance.Items.Count; i++)
                    {
                        object obj2;
                        if (provider == null)
                        {
                            obj2 = XDataBindingProvider.StdReadItemValue(instance.Items[i], obj, null, throwException);
                        }
                        else
                        {
                            obj2 = provider.ReadItemValue(instance.Items[i], obj, null, throwException);
                        }
                        if (obj2 == null)
                        {
                        }
                        obj = obj2;
                    }
                    if (!string.IsNullOrEmpty(binding.FormatString))
                    {
                        if (obj is IFormattable)
                        {
                            obj = ((IFormattable)obj).ToString(binding.FormatString, null);
                        }
                    }
                    result = obj;
                }
                else
                {
                    result = defaultValue;
                }
            }
            return result;
        }
        public static object StdReadValue(XDataBindingPath path, object instance, object defaultValue, bool throwException, XDataBindingProvider provider)
        {
            object obj = instance;
            object result;
            for (int i = 0; i < path.Items.Count; i++)
            {
                object obj2;
                if (provider == null)
                {
                    obj2 = XDataBindingProvider.StdReadItemValue(path.Items[i], obj, null, throwException);
                }
                else
                {
                    obj2 = provider.ReadItemValue(path.Items[i], obj, null, throwException);
                }
                if (obj2 == null)
                {
                    result = defaultValue;
                    return result;
                }
                obj = obj2;
            }
            result = obj;
            return result;
        }
    }

    public class XDataBindingPath
    {
        private static List<XDataBindingPath> _buffer = new List<XDataBindingPath>();
        private static List<XDataBindingPath> _badPath = new List<XDataBindingPath>();
        private Type _RootType = null;
        private string _Path = null;
        private bool _Readonly = false;
        private List<XDataBindingPathItem> _Items = new List<XDataBindingPathItem>();
        public Type RootType
        {
            get
            {
                return this._RootType;
            }
        }
        public string Path
        {
            get
            {
                return this._Path;
            }
        }
        public bool Readonly
        {
            get
            {
                return this._Readonly;
            }
        }
        public List<XDataBindingPathItem> Items
        {
            get
            {
                return this._Items;
            }
            set
            {
                this._Items = value;
            }
        }
        public static void ClearBuffer()
        {
            XDataBindingPath._buffer.Clear();
            XDataBindingPath._badPath.Clear();
        }
        public static XDataBindingPath GetInstance(Type rootType, string path, bool throwException)
        {
            XDataBindingPath result;
            if (rootType == null)
            {
                if (throwException)
                {
                    throw new ArgumentNullException("rootType");
                }
                result = null;
            }
            else
            {
                foreach (XDataBindingPath current in XDataBindingPath._buffer)
                {
                    if (current.RootType.Equals(rootType) && string.Compare(current.Path, path, false) == 0)
                    {
                        result = current;
                        return result;
                    }
                }
                foreach (XDataBindingPath current in XDataBindingPath._badPath)
                {
                    if (current.RootType == rootType && current.Path == path)
                    {
                        if (throwException)
                        {
                            throw new ArgumentOutOfRangeException("Type=" + rootType.FullName + " Path=" + path);
                        }
                        result = null;
                        return result;
                    }
                }
                XDataBindingPath xDataBindingPath = XDataBindingPath.Create(rootType, path, throwException);
                if (xDataBindingPath != null)
                {
                    XDataBindingPath._buffer.Add(xDataBindingPath);
                }
                else
                {
                    XDataBindingPath xDataBindingPath2 = new XDataBindingPath();
                    xDataBindingPath2._RootType = rootType;
                    xDataBindingPath2._Path = path;
                    XDataBindingPath._badPath.Add(xDataBindingPath2);
                }
                result = xDataBindingPath;
            }
            return result;
        }
        private static XDataBindingPath Create(Type rootType, string path, bool throwException)
        {
            XDataBindingPath xDataBindingPath = new XDataBindingPath();
            xDataBindingPath._RootType = rootType;
            xDataBindingPath._Path = path;
            XDataBindingPath result;
            if (string.IsNullOrEmpty(path))
            {
                XDataBindingPathItem xDataBindingPathItem = new XDataBindingPathItem();
                xDataBindingPathItem.Name = null;
                xDataBindingPathItem.InstanceType = rootType;
                xDataBindingPath._Items.Add(xDataBindingPathItem);
            }
            else
            {
                if (typeof(XmlNode).IsAssignableFrom(rootType))
                {
                    XDataBindingPathItem xDataBindingPathItem = new XDataBindingPathItem();
                    xDataBindingPathItem.Name = path;
                    xDataBindingPathItem.InstanceType = rootType;
                    xDataBindingPathItem.Style = XBindingPathItemStyle.XPath;
                    xDataBindingPath._Items.Add(xDataBindingPathItem);
                }
                else
                {
                    if (typeof(DataRow).IsAssignableFrom(rootType))
                    {
                        XDataBindingPathItem xDataBindingPathItem = new XDataBindingPathItem();
                        xDataBindingPathItem.Name = path;
                        xDataBindingPathItem.InstanceType = rootType;
                        xDataBindingPathItem.Style = XBindingPathItemStyle.DataRow;
                        xDataBindingPath._Items.Add(xDataBindingPathItem);
                    }
                    else
                    {
                        if (typeof(DataRowView).IsAssignableFrom(rootType))
                        {
                            XDataBindingPathItem xDataBindingPathItem = new XDataBindingPathItem();
                            xDataBindingPathItem.Name = path;
                            xDataBindingPathItem.InstanceType = rootType;
                            xDataBindingPathItem.Style = XBindingPathItemStyle.DataRow;
                            xDataBindingPath._Items.Add(xDataBindingPathItem);
                        }
                        else
                        {
                            if (typeof(IDataRecord).IsAssignableFrom(rootType))
                            {
                                XDataBindingPathItem xDataBindingPathItem = new XDataBindingPathItem();
                                xDataBindingPathItem.Name = path;
                                xDataBindingPathItem.InstanceType = rootType;
                                xDataBindingPathItem.Style = XBindingPathItemStyle.Record;
                                xDataBindingPath._Items.Add(xDataBindingPathItem);
                            }
                            else
                            {
                                if (typeof(IDictionary).IsAssignableFrom(rootType))
                                {
                                    XDataBindingPathItem xDataBindingPathItem = new XDataBindingPathItem();
                                    xDataBindingPathItem.Name = path;
                                    xDataBindingPathItem.InstanceType = rootType;
                                    xDataBindingPathItem.Style = XBindingPathItemStyle.Dictionary;
                                    xDataBindingPath._Items.Add(xDataBindingPathItem);
                                }
                                else
                                {
                                    string[] array = path.Split(new char[]
									{
										'.'
									});
                                    Type type = xDataBindingPath._RootType;
                                    for (int i = 0; i < array.Length; i++)
                                    {
                                        string text = array[i].Trim();
                                        if (string.IsNullOrEmpty(text))
                                        {
                                            XDataBindingPathItem xDataBindingPathItem = new XDataBindingPathItem();
                                            xDataBindingPathItem.InstanceType = type;
                                            xDataBindingPathItem.Name = null;
                                            type = typeof(string);
                                            xDataBindingPath._Items.Add(xDataBindingPathItem);
                                        }
                                        else
                                        {
                                            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(type);
                                            bool flag = false;
                                            foreach (PropertyDescriptor propertyDescriptor in properties)
                                            {
                                                if (string.Compare(propertyDescriptor.Name, text, true) == 0)
                                                {
                                                    XDataBindingPathItem xDataBindingPathItem = new XDataBindingPathItem();
                                                    xDataBindingPathItem.InstanceType = type;
                                                    xDataBindingPathItem.Property = propertyDescriptor;
                                                    xDataBindingPathItem.Name = propertyDescriptor.Name;
                                                    xDataBindingPathItem.Style = XBindingPathItemStyle.Property;
                                                    xDataBindingPath._Items.Add(xDataBindingPathItem);
                                                    type = propertyDescriptor.PropertyType;
                                                    flag = true;
                                                    break;
                                                }
                                            }
                                            if (!flag)
                                            {
                                                if (throwException)
                                                {
                                                    throw new NotSupportedException(type.FullName + "." + text);
                                                }
                                                result = null;
                                                return result;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            xDataBindingPath._Readonly = false;
            XDataBindingPathItem xDataBindingPathItem2 = xDataBindingPath._Items[xDataBindingPath._Items.Count - 1];
            if (xDataBindingPathItem2.Style == XBindingPathItemStyle.Property)
            {
                if (xDataBindingPathItem2.Property == null)
                {
                    xDataBindingPath._Readonly = true;
                }
                else
                {
                    xDataBindingPath._Readonly = xDataBindingPathItem2.Property.IsReadOnly;
                }
            }
            else
            {
                if (xDataBindingPathItem2.Style == XBindingPathItemStyle.DataRow || xDataBindingPathItem2.Style == XBindingPathItemStyle.Dictionary || xDataBindingPathItem2.Style == XBindingPathItemStyle.XPath)
                {
                    xDataBindingPath._Readonly = false;
                }
                else
                {
                    xDataBindingPath._Readonly = true;
                }
            }
            result = xDataBindingPath;
            return result;
        }
        private XDataBindingPath()
        {
        }
    }
    public enum XBindingPathItemStyle
    {
        Self,
        XPath,
        Dictionary,
        DataRow,
        Property,
        Record,
        Auto
    }
    public class XDataBindingPathItem
    {
        private Type _InstanceType = null;
        private PropertyDescriptor _Property = null;
        private string _Name = null;
        private XBindingPathItemStyle _Style = XBindingPathItemStyle.Property;
        public Type InstanceType
        {
            get
            {
                return this._InstanceType;
            }
            set
            {
                this._InstanceType = value;
            }
        }
        public PropertyDescriptor Property
        {
            get
            {
                return this._Property;
            }
            set
            {
                this._Property = value;
            }
        }
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }
        public XBindingPathItemStyle Style
        {
            get
            {
                return this._Style;
            }
            set
            {
                this._Style = value;
            }
        }
    }


}
