using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Xml;
using System.Runtime.InteropServices;
using System.ComponentModel;
using CIS.Utility;

namespace CIS.ControlLib.Controls.TemperatureChart.Data
{
    [ComVisible(false)]
    public class DCSingleDataSource
    {
        private static Dictionary<Type, Dictionary<string, PropertyInfo>> properInfoCache = new Dictionary<Type, Dictionary<string, PropertyInfo>>();
        private object _DataBoundItem = null;
        public object DataBoundItem
        {
            get
            {
                return this._DataBoundItem;
            }
            set
            {
                this._DataBoundItem = value;
            }
        }
        public static DCSingleDataSource Package(object instance)
        {
            DCSingleDataSource result;
            if (instance == null)
            {
                result = null;
            }
            else
            {
                if (instance is DCSingleDataSource)
                {
                    result = (DCSingleDataSource)instance;
                }
                else
                {
                    result = new DCSingleDataSource(instance);
                }
            }
            return result;
        }
        public DCSingleDataSource()
        {
        }
        public DCSingleDataSource(object dataBoundItem)
        {
            this._DataBoundItem = dataBoundItem;
        }
        public object ReadValue(string fieldName)
        {
            return DCSingleDataSource.ReadValue(this._DataBoundItem, fieldName);
        }
        public bool WriteValue(string fieldName, object fieldValue)
        {
            return DCSingleDataSource.WriteValue(this._DataBoundItem, fieldName, fieldValue);
        }
        public string[] GetFieldNames()
        {
            return DCSingleDataSource.GetFieldNames(this._DataBoundItem);
        }
        public static bool WriteValue(object dataBoundItem, string fieldName, object fieldValue)
        {
            bool result;
            if (dataBoundItem == null)
            {
                result = false;
            }
            else
            {
                if (dataBoundItem is IDataRecord)
                {
                    result = false;
                }
                else
                {
                    if (dataBoundItem is DataRow)
                    {
                        DataRow dataRow = (DataRow)dataBoundItem;
                        dataRow[fieldName] = fieldValue;
                        result = true;
                    }
                    else
                    {
                        if (dataBoundItem is DataRowView)
                        {
                            DataRowView dataRowView = (DataRowView)dataBoundItem;
                            dataRowView[fieldName] = fieldValue;
                        }
                        if (dataBoundItem is DataTable)
                        {
                            DataTable dataTable = (DataTable)dataBoundItem;
                            if (dataTable.Rows.Count > 0)
                            {
                                dataTable.Rows[0][fieldName] = fieldValue;
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        else
                        {
                            if (dataBoundItem is DataView)
                            {
                                DataView dataView = (DataView)dataBoundItem;
                                if (dataView.Count > 0)
                                {
                                    DataRowView dataRowView = dataView[0];
                                    dataRowView[fieldName] = fieldValue;
                                    result = true;
                                }
                                else
                                {
                                    result = false;
                                }
                            }
                            else
                            {
                                if (dataBoundItem is IDictionary)
                                {
                                    IDictionary dictionary = (IDictionary)dataBoundItem;
                                    dictionary[fieldName] = fieldValue;
                                    result = true;
                                }
                                else
                                {
                                    if (dataBoundItem is XmlNode)
                                    {
                                        XmlNode rootNode = (XmlNode)dataBoundItem;
                                        XmlNode xmlNode = XMLHelper.CreateXMLNodeByPath(rootNode, fieldName, 1, null);
                                        if (xmlNode != null)
                                        {
                                            if (fieldValue == null || DBNull.Value.Equals(fieldValue))
                                            {
                                                xmlNode.Value = "";
                                            }
                                            else
                                            {
                                                xmlNode.Value = Convert.ToString(fieldValue);
                                            }
                                            result = true;
                                        }
                                        else
                                        {
                                            result = false;
                                        }
                                    }
                                    else
                                    {
                                        if (dataBoundItem is XmlNodeList)
                                        {
                                            XmlNodeList xmlNodeList = (XmlNodeList)dataBoundItem;
                                            if (xmlNodeList.Count > 0)
                                            {
                                                XmlNode rootNode = xmlNodeList[0];
                                                XmlNode xmlNode = XMLHelper.CreateXMLNodeByPath(rootNode, fieldName, 1, null);
                                                if (xmlNode == null)
                                                {
                                                    result = false;
                                                    return result;
                                                }
                                                if (fieldValue == null || DBNull.Value.Equals(fieldValue))
                                                {
                                                    xmlNode.Value = "";
                                                }
                                                else
                                                {
                                                    xmlNode.Value = Convert.ToString(fieldValue);
                                                }
                                                result = true;
                                                return result;
                                            }
                                        }
                                        if (dataBoundItem.GetType().IsArray)
                                        {
                                            Array array = (Array)dataBoundItem;
                                            if (array.GetLength(0) == 0)
                                            {
                                                result = false;
                                            }
                                            else
                                            {
                                                object value = array.GetValue(0);
                                                result = DCSingleDataSource.WriteValue(value, fieldName, fieldValue);
                                            }
                                        }
                                        else
                                        {
                                            result = SetPropertyValueMultiLayer(dataBoundItem, fieldName, fieldValue, false);
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
        public static object ReadValue(object dataBoundItem, string fieldName)
        {
            object result;
            if (dataBoundItem == null)
            {
                result = null;
            }
            else
            {
                if (dataBoundItem is IDataRecord)
                {
                    IDataRecord dataRecord = (IDataRecord)dataBoundItem;
                    result = dataRecord[fieldName];
                }
                else
                {
                    if (dataBoundItem is DataRow)
                    {
                        DataRow dataRow = (DataRow)dataBoundItem;
                        result = dataRow[fieldName];
                    }
                    else
                    {
                        if (dataBoundItem is DataRowView)
                        {
                            DataRowView dataRowView = (DataRowView)dataBoundItem;
                            result = dataRowView[fieldName];
                        }
                        else
                        {
                            if (dataBoundItem is DataTable)
                            {
                                DataTable dataTable = (DataTable)dataBoundItem;
                                if (dataTable.Rows.Count > 0)
                                {
                                    result = dataTable.Rows[0][fieldName];
                                }
                                else
                                {
                                    result = null;
                                }
                            }
                            else
                            {
                                if (dataBoundItem is DataView)
                                {
                                    DataView dataView = (DataView)dataBoundItem;
                                    if (dataView.Count > 0)
                                    {
                                        DataRowView dataRowView = dataView[0];
                                        result = dataRowView[fieldName];
                                    }
                                    else
                                    {
                                        result = null;
                                    }
                                }
                                else
                                {
                                    if (dataBoundItem is IDictionary)
                                    {
                                        IDictionary dictionary = (IDictionary)dataBoundItem;
                                        if (dictionary.Contains(fieldName))
                                        {
                                            result = dictionary[fieldName];
                                        }
                                        else
                                        {
                                            result = null;
                                        }
                                    }
                                    else
                                    {
                                        if (dataBoundItem is XmlNode)
                                        {
                                            XmlNode xmlNode = (XmlNode)dataBoundItem;
                                            XmlNode xmlNode2 = xmlNode.SelectSingleNode(fieldName);
                                            if (xmlNode2 == null)
                                            {
                                                result = null;
                                            }
                                            else
                                            {
                                                result = xmlNode2.Value;
                                            }
                                        }
                                        else
                                        {
                                            if (dataBoundItem is XmlNodeList)
                                            {
                                                XmlNodeList xmlNodeList = (XmlNodeList)dataBoundItem;
                                                if (xmlNodeList.Count > 0)
                                                {
                                                    XmlNode xmlNode = xmlNodeList[0];
                                                    XmlNode xmlNode2 = xmlNode.SelectSingleNode(fieldName);
                                                    if (xmlNode2 == null)
                                                    {
                                                        result = null;
                                                        return result;
                                                    }
                                                    result = xmlNode2.Value;
                                                    return result;
                                                }
                                            }
                                            if (dataBoundItem.GetType().IsArray)
                                            {
                                                Array array = (Array)dataBoundItem;
                                                if (array.GetLength(0) == 0)
                                                {
                                                    result = null;
                                                }
                                                else
                                                {
                                                    object value = array.GetValue(0);
                                                    result = DCSingleDataSource.ReadValue(value, fieldName);
                                                }
                                            }
                                            else
                                            {
                                                result = GetPropertyValue(dataBoundItem, fieldName, false);
                                            }
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
        public static string[] GetFieldNames(object dataBoundItem)
        {
            string[] result;
            if (dataBoundItem == null)
            {
                result = null;
            }
            else
            {
                List<string> list = new List<string>();
                if (dataBoundItem is IDataRecord)
                {
                    IDataRecord dataRecord = (IDataRecord)dataBoundItem;
                    for (int i = 0; i < dataRecord.FieldCount; i++)
                    {
                        list.Add(dataRecord.GetName(i));
                    }
                }
                else
                {
                    if (dataBoundItem is DataRow)
                    {
                        DataRow dataRow = (DataRow)dataBoundItem;
                        DataTable dataTable = dataRow.Table;
                        foreach (DataColumn dataColumn in dataTable.Columns)
                        {
                            list.Add(dataColumn.ColumnName);
                        }
                    }
                    else
                    {
                        if (dataBoundItem is DataRowView)
                        {
                            DataRowView dataRowView = (DataRowView)dataBoundItem;
                            foreach (DataColumn dataColumn in dataRowView.DataView.Table.Columns)
                            {
                                list.Add(dataColumn.ColumnName);
                            }
                        }
                        else
                        {
                            if (dataBoundItem is DataTable)
                            {
                                DataTable dataTable = (DataTable)dataBoundItem;
                                foreach (DataColumn dataColumn in dataTable.Columns)
                                {
                                    list.Add(dataColumn.ColumnName);
                                }
                            }
                            else
                            {
                                if (dataBoundItem is DataView)
                                {
                                    DataView dataView = (DataView)dataBoundItem;
                                    foreach (DataColumn dataColumn in dataView.Table.Columns)
                                    {
                                        list.Add(dataColumn.ColumnName);
                                    }
                                }
                                else
                                {
                                    if (dataBoundItem is IDictionary)
                                    {
                                        IDictionary dictionary = (IDictionary)dataBoundItem;
                                        foreach (object current in dictionary.Keys)
                                        {
                                            list.Add(Convert.ToString(current));
                                        }
                                    }
                                    else
                                    {
                                        if (dataBoundItem is XmlNode)
                                        {
                                            XmlNode xmlNode = (XmlNode)dataBoundItem;
                                            foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
                                            {
                                                if (xmlNode2 is XmlElement)
                                                {
                                                    list.Add(xmlNode2.Name);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (dataBoundItem is XmlNodeList)
                                            {
                                                XmlNodeList xmlNodeList = (XmlNodeList)dataBoundItem;
                                                if (xmlNodeList.Count > 0)
                                                {
                                                    XmlNode xmlNode = xmlNodeList[0];
                                                    foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
                                                    {
                                                        if (xmlNode2 is XmlElement)
                                                        {
                                                            list.Add(xmlNode2.Name);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (dataBoundItem.GetType().IsArray)
                                                {
                                                    Array array = (Array)dataBoundItem;
                                                    Type elementType = dataBoundItem.GetType().GetElementType();
                                                    PropertyInfo[] properties = elementType.GetProperties();
                                                    if (properties != null)
                                                    {
                                                        PropertyInfo[] array2 = properties;
                                                        for (int j = 0; j < array2.Length; j++)
                                                        {
                                                            PropertyInfo propertyInfo = array2[j];
                                                            list.Add(propertyInfo.Name);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    PropertyInfo[] properties = dataBoundItem.GetType().GetProperties();
                                                    if (properties != null)
                                                    {
                                                        PropertyInfo[] array2 = properties;
                                                        for (int j = 0; j < array2.Length; j++)
                                                        {
                                                            PropertyInfo propertyInfo = array2[j];
                                                            list.Add(propertyInfo.Name);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                result = list.ToArray();
            }
            return result;
        }

        public static object GetPropertyValue(object instance, string propertyName, bool throwException)
        {
            object result;
            if (instance == null)
            {
                if (throwException)
                {
                    throw new ArgumentNullException("instance");
                }
                result = null;
            }
            else
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    if (throwException)
                    {
                        throw new ArgumentNullException("propertyName");
                    }
                    result = null;
                }
                else
                {
                    Type type = instance.GetType();
                    Dictionary<string, PropertyInfo> dictionary;
                    if (properInfoCache.ContainsKey(type))
                    {
                        dictionary = properInfoCache[type];
                    }
                    else
                    {
                        dictionary = new Dictionary<string, PropertyInfo>();
                        properInfoCache[type] = dictionary;
                    }
                    PropertyInfo propertyInfo;
                    if (dictionary.ContainsKey(propertyName))
                    {
                        propertyInfo = dictionary[propertyName];
                    }
                    else
                    {
                        dictionary[propertyName] = null;
                        propertyInfo = instance.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                        if (propertyInfo == null)
                        {
                            if (throwException)
                            {
                                throw new Exception("未找到属性" + propertyName);
                            }
                            result = null;
                            return result;
                        }
                        else
                        {
                            if (!propertyInfo.CanRead)
                            {
                                if (throwException)
                                {
                                    throw new Exception("属性" + propertyName + "无法读取数据");
                                }
                                result = null;
                                return result;
                            }
                            else
                            {
                                ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
                                if (indexParameters != null && indexParameters.Length > 0)
                                {
                                    if (throwException)
                                    {
                                        throw new Exception("属性" + propertyName + "不得有参数");
                                    }
                                    result = null;
                                    return result;
                                }
                                else
                                {
                                    dictionary[propertyName] = propertyInfo;
                                }
                            }
                        }
                    }
                    if (propertyInfo == null)
                    {
                        if (throwException)
                        {
                            throw new Exception("没有合适的属性" + propertyName);
                        }
                        result = null;
                    }
                    else
                    {
                        if (throwException)
                        {
                            result = propertyInfo.GetValue(instance, null);
                        }
                        else
                        {
                            try
                            {
                                result = propertyInfo.GetValue(instance, null);
                            }
                            catch
                            {
                                result = null;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static bool SetPropertyValueMultiLayer(object instance, string propertyName, object Value, bool throwExecption)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }
            string[] array = propertyName.Split(new char[]
	{
		'.'
	});
            object obj = instance;
            bool result;
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i].Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (i == array.Length - 1)
                    {
                        result = SetPropertyValue(obj, text, Value, throwExecption);
                    }
                    else
                    {
                        PropertyInfo property = obj.GetType().GetProperty(text, BindingFlags.Instance | BindingFlags.Public);
                        if (property == null)
                        {
                            if (throwExecption)
                            {
                                throw new Exception("未找到属性" + obj.GetType().FullName + "." + text);
                            }
                        }
                        object value = property.GetValue(obj, null);
                        if (value != null)
                        {
                            obj = value;
                            goto IL_11A;
                        }
                        result = false;
                    }
                    return result;
                }
            IL_11A: ;
            }
            result = false;
            return result;
        }

        public static bool SetPropertyValue(object instance, string propertyName, object Value, bool throwException)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }
            bool result;
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(instance))
            {
                if (!propertyDescriptor.IsReadOnly)
                {
                    if (string.Compare(propertyDescriptor.Name, propertyName, true) == 0)
                    {
                        object obj = Value;
                        if (Value != null)
                        {
                            if (!propertyDescriptor.PropertyType.IsInstanceOfType(obj))
                            {
                                if (throwException)
                                {
                                    if (propertyDescriptor.Converter != null)
                                    {
                                        obj = propertyDescriptor.Converter.ConvertFrom(obj);
                                    }
                                    else
                                    {
                                        obj = Convert.ChangeType(obj, propertyDescriptor.PropertyType);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        if (propertyDescriptor.Converter != null)
                                        {
                                            obj = propertyDescriptor.Converter.ConvertFrom(obj);
                                        }
                                        else
                                        {
                                            if (propertyDescriptor.PropertyType.IsEnum)
                                            {
                                                if (obj is string)
                                                {
                                                    obj = Enum.Parse(propertyDescriptor.PropertyType, (string)obj);
                                                }
                                                else
                                                {
                                                    obj = Enum.ToObject(propertyDescriptor.PropertyType, obj);
                                                }
                                            }
                                            obj = Convert.ChangeType(obj, propertyDescriptor.PropertyType);
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        result = false;
                                        return result;
                                    }
                                }
                            }
                        }
                        if (throwException)
                        {
                            propertyDescriptor.SetValue(instance, obj);
                            result = true;
                            return result;
                        }
                        try
                        {
                            propertyDescriptor.SetValue(instance, obj);
                            result = true;
                            return result;
                        }
                        catch (Exception)
                        {
                            result = false;
                            return result;
                        }
                    }
                }
            }
            result = false;
            return result;
        }


    }
}
