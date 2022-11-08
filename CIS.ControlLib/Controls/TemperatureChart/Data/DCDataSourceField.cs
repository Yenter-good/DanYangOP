namespace CIS.ControlLib.Controls.TemperatureChart.Data
{
    public class DCDataSourceField
    {
        internal bool _Invalidate = false;
        internal DCDataSource.DataType _DataType = DCDataSource.DataType.Data;
        internal int c = 0;
        private string _FieldName = null;
        private string _BindingPath = null;
        internal int _Index = 0;
        public bool Invalidate
        {
            get
            {
                return this._Invalidate;
            }
        }
        public string FieldName
        {
            get
            {
                return this._FieldName;
            }
            set
            {
                this._FieldName = value;
            }
        }
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
        public int Index
        {
            get
            {
                return this._Index;
            }
        }
    }
}
