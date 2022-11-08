using System.Data;
using System.Collections;
using System.Xml;

namespace CIS.ControlLib.Controls.TemperatureChart.Data
{
    public class DCDataSource
    {
        internal enum DataType
        {
            Data,
            b,
            IEnumerable,
            XML,
            IDataReader
        }
        private object _DataSource = null;
        private string _RootXPath = null;
        private DCDataSourceFieldList _Fields = new DCDataSourceFieldList();
        private bool d = false;
        private int e = 0;
        private DCDataSource.DataType currentDataType = DCDataSource.DataType.IEnumerable;
        private IEnumerator currentEnumerator = null;
        public object DataSource
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
        public string RootXPath
        {
            get
            {
                return this._RootXPath;
            }
            set
            {
                this._RootXPath = value;
            }
        }
        public DCDataSourceFieldList Fields
        {
            get
            {
                return this._Fields;
            }
            set
            {
                this._Fields = value;
            }
        }
        public object Current
        {
            get
            {
                object result;
                if (this.DataSource is IDataReader)
                {
                    IDataReader dataReader = (IDataReader)this.DataSource;
                    result = dataReader;
                }
                else
                {
                    if (this.currentEnumerator == null)
                    {
                        result = null;
                    }
                    else
                    {
                        result = this.currentEnumerator.Current;
                    }
                }
                return result;
            }
        }
        public DCDataSource()
        {
        }
        public DCDataSource(object dataSource)
        {
            this.DataSource = dataSource;
        }
        private void a()
        {
            if (!this.d)
            {
                this.d = true;
                this.Start();
            }
        }
        public void Start()
        {
            this.e = 0;
            int num = 0;
            foreach (DCDataSourceField current in this.Fields)
            {
                current._Index = num++;
            }
            if (this.DataSource == null)
            {
                foreach (DCDataSourceField current in this.Fields)
                {
                    current._Invalidate = true;
                }
            }
            else
            {
                if (this.DataSource is IDataReader)
                {
                    IDataReader dataReader = (IDataReader)this.DataSource;
                    this.currentDataType = DCDataSource.DataType.IDataReader;
                    foreach (DCDataSourceField current in this.Fields)
                    {
                        current.c = dataReader.GetOrdinal(current.FieldName);
                        if (current.c >= 0)
                        {
                            current._DataType = DCDataSource.DataType.IDataReader;
                            current._Invalidate = false;
                        }
                        else
                        {
                            current._Invalidate = true;
                        }
                    }
                }
                else
                {
                    if (this.DataSource is DataTable)
                    {
                        DataTable dataTable = (DataTable)this.DataSource;
                        this.currentDataType = DCDataSource.DataType.Data;
                        this.currentEnumerator = dataTable.Rows.GetEnumerator();
                        foreach (DCDataSourceField current in this.Fields)
                        {
                            current.c = dataTable.Columns.IndexOf(current.FieldName);
                            if (current.c >= 0)
                            {
                                current._DataType = DCDataSource.DataType.Data;
                                current._Invalidate = false;
                            }
                            else
                            {
                                current._Invalidate = true;
                            }
                        }
                    }
                    else
                    {
                        if (this.DataSource is DataView)
                        {
                            DataView dataView = (DataView)this.DataSource;
                            this.currentDataType = DCDataSource.DataType.Data;
                            this.currentEnumerator = dataView.GetEnumerator();
                            foreach (DCDataSourceField current in this.Fields)
                            {
                                current.c = dataView.Table.Columns.IndexOf(current.FieldName);
                                if (current.c >= 0)
                                {
                                    current._DataType = DCDataSource.DataType.Data;
                                    current._Invalidate = false;
                                }
                                else
                                {
                                    current._Invalidate = true;
                                }
                            }
                        }
                        else
                        {
                            if (this.DataSource is XmlNode)
                            {
                                XmlNode xmlNode = (XmlNode)this.DataSource;
                                if (!string.IsNullOrEmpty(this.RootXPath))
                                {
                                    XmlNodeList xmlNodeList = xmlNode.SelectNodes(this.RootXPath);
                                    this.currentEnumerator = xmlNodeList.GetEnumerator();
                                }
                                else
                                {
                                    this.currentEnumerator = xmlNode.ChildNodes.GetEnumerator();
                                }
                                this.currentDataType = DCDataSource.DataType.XML;
                                foreach (DCDataSourceField current in this.Fields)
                                {
                                    current._Invalidate = false;
                                    current._DataType = DCDataSource.DataType.XML;
                                }
                            }
                            else
                            {
                                if (this.DataSource is XmlNodeList)
                                {
                                    XmlNodeList xmlNodeList = (XmlNodeList)this.DataSource;
                                    this.currentDataType = DCDataSource.DataType.XML;
                                    this.currentEnumerator = xmlNodeList.GetEnumerator();
                                    foreach (DCDataSourceField current in this.Fields)
                                    {
                                        current._Invalidate = false;
                                        current._DataType = DCDataSource.DataType.XML;
                                    }
                                }
                                else
                                {
                                    if (this.DataSource is IEnumerable)
                                    {
                                        IEnumerable enumerable = (IEnumerable)this.DataSource;
                                        this.currentEnumerator = enumerable.GetEnumerator();
                                        this.currentDataType = DCDataSource.DataType.IEnumerable;
                                        foreach (DCDataSourceField current in this.Fields)
                                        {
                                            current._Invalidate = false;
                                            current._DataType = DCDataSource.DataType.IEnumerable;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (DCDataSourceField current in this.Fields)
                {
                    if (string.IsNullOrEmpty(current.FieldName))
                    {
                        current._Invalidate = true;
                    }
                }
            }
        }
        public void Reset()
        {
            this.Start();
            if (this.DataSource is IDataReader)
            {
                IDataReader dataReader = (IDataReader)this.DataSource;
            }
            if (this.currentEnumerator != null)
            {
                this.currentEnumerator.Reset();
            }
        }
        public bool MoveNext()
        {
            bool result;
            if (this.DataSource is IDataReader)
            {
                IDataReader dataReader = (IDataReader)this.DataSource;
                result = dataReader.Read();
            }
            else
            {
                result = (this.currentEnumerator != null && this.currentEnumerator.MoveNext());
            }
            return result;
        }
        public object ReadValue(string fieldName)
        {
            DCSingleDataSource dCSingleDataSource = DCSingleDataSource.Package(this.Current);
            return dCSingleDataSource.ReadValue(fieldName);
        }
    }
}


