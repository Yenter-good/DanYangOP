using System.Collections.Generic;

namespace CIS.ControlLib.Controls.TemperatureChart.Data
{
    public class DCDataSourceFieldList : List<DCDataSourceField>
    {
        public DCDataSourceField this[string fieldName]
        {
            get
            {
                DCDataSourceField result;
                foreach (DCDataSourceField current in this)
                {
                    if (string.Compare(current.FieldName, fieldName, true) == 0)
                    {
                        result = current;
                        return result;
                    }
                }
                result = null;
                return result;
            }
        }
        public DCDataSourceField AddField(string fieldName)
        {
            DCDataSourceField dCDataSourceField = new DCDataSourceField();
            dCDataSourceField.FieldName = fieldName;
            base.Add(dCDataSourceField);
            return dCDataSourceField;
        }
        public DCDataSourceField AddField(string fieldName, string bindingPath)
        {
            DCDataSourceField dCDataSourceField = new DCDataSourceField();
            dCDataSourceField.FieldName = fieldName;
            dCDataSourceField.BindingPath = bindingPath;
            base.Add(dCDataSourceField);
            return dCDataSourceField;
        }
    }
}
