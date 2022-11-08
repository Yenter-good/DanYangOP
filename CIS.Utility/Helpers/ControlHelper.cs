using System;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using System.Reflection;


namespace CIS.Utility
{
    public static class ControlHelper
    {
        //清空表单值
        public static void ClearControlValue(Control form)
        {
            foreach (Control c in form.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox item = (TextBox)c;
                    item.Text = "";
                }
                if (c.GetType() == typeof(TextBoxX))
                {
                    TextBoxX item = (TextBoxX)c;
                    item.Text = "";
                }
                if (c.GetType() == typeof(ComboBox))
                {
                    ComboBox item = (ComboBox)c;
                    item.SelectedIndex = -1;
                }
                if (c.GetType() == typeof(ComboBoxEx))
                {
                    ComboBox item = (ComboBox)c;
                    item.SelectedIndex = -1;
                }

            }
        }

        /// <summary>
        /// 通过界面获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        /// <param name="controlPrefix"></param>
        /// <returns></returns>
        public static T GetValue<T>(Control form, string controlPrefix = "input_") where T : new()
        {
            T model = new T();
            PropertyInfo[] info = model.GetType().GetProperties();
            foreach (PropertyInfo item in info)
            {
                Control[] c = form.Controls.Find(controlPrefix + item.Name, true);
                if (c.Length == 0) continue;
                Type type = c[0].GetType();
                object value = c[0].Text;
                if (type == typeof(TextBox) || type == typeof(TextBoxX))
                {
                    value = ChangeType(c[0].Text, item.PropertyType);
                }
                else
                    if (type == typeof(ComboBox) || type == typeof(ComboBoxEx))
                    {
                        ComboBox control = (ComboBox)c[0];
                        if (!control.ValueMember.IsNullOrWhiteSpace())
                            value = ChangeType(control.SelectedValue, item.PropertyType);
                        else
                            value = ChangeType(control.SelectedItem, item.PropertyType);
                    }
                    else
                        if (type == typeof(DateTimePicker))
                        {
                            DateTimePicker control = (DateTimePicker)c[0];
                            value = ChangeType(control.Value, item.PropertyType);
                        }
                        else
                            if (type == typeof(DateTimeInput))
                            {
                                DateTimeInput control = (DateTimeInput)c[0];
                                value = ChangeType(control.ValueObject, item.PropertyType);
                            }
                            else if (type == typeof(CheckBoxX))
                            {
                                CheckBoxX control = (CheckBoxX)c[0];
                                value = ChangeType(control.Checked, item.PropertyType);
                            }
                            else if (type == typeof(CheckBox))
                            {
                                CheckBox control = (CheckBox)c[0];
                                value = ChangeType(control.Checked, item.PropertyType);
                            }
                item.SetValue(model, value, null);
            }
            return model;
        }

        /// <summary>
        /// 通过界面刷新model的数据值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        /// <param name="model"></param>
        /// <param name="controlPrefix"></param>
        public static void RefreshValue<T>(Control form, T model, string controlPrefix = "input_") where T : new()
        {
            if (model == null)
                model = new T();
            PropertyInfo[] info = model.GetType().GetProperties();
            foreach (PropertyInfo item in info)
            {
                Control[] c = form.Controls.Find(controlPrefix + item.Name, true);
                if (c.Length == 0) continue;
                Type type = c[0].GetType();


                object value = c[0].Text;
                if (type == typeof(TextBox) || type == typeof(TextBoxX))
                {
                    value = ChangeType(c[0].Text, item.PropertyType);
                }
                else
                    if (type == typeof(ComboBox) || type == typeof(ComboBoxEx))
                    {
                        ComboBox control = (ComboBox)c[0];
                        if (!control.ValueMember.IsNullOrWhiteSpace())
                            value = ChangeType(control.SelectedValue, item.PropertyType);
                        else
                            value = ChangeType(control.SelectedItem, item.PropertyType);
                    }
                    else
                        if (type == typeof(DateTimePicker))
                        {
                            DateTimePicker control = (DateTimePicker)c[0];
                            value = ChangeType(control.Value, item.PropertyType);
                        }
                        else
                            if (type == typeof(DateTimeInput))
                            {
                                DateTimeInput control = (DateTimeInput)c[0];
                                value = ChangeType(control.ValueObject, item.PropertyType);
                            }
                            else
                                if (type == typeof(CheckBoxX))
                                {
                                    CheckBoxX control = (CheckBoxX)c[0];
                                    value = ChangeType(control.Checked, item.PropertyType);
                                }
                                else if (type == typeof(CheckBox))
                                {
                                    CheckBox control = (CheckBox)c[0];
                                    value = ChangeType(control.Checked, item.PropertyType);
                                }
                object oldValue = item.GetValue(model, null);
                if (oldValue != value)
                    item.SetValue(model, value, null);
            }
        }
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object ChangeType(object obj, Type type)
        {
            if (type == typeof(string))
                return obj.AsString();
            if (type == typeof(int))
                return obj.AsInt(0);
            if (type == typeof(float))
                return obj.AsFloat(0);
            if (type == typeof(double))
                return obj.AsDouble(0);
            if (type == typeof(decimal))
                return obj.AsDecimal(0);
            if (type == typeof(DateTime))
                return obj.AsDateTime(DateTime.Now);
            if (type == typeof(Boolean))
                return obj.AsBoolean();
            if (type == typeof(int?))
                return obj.AsInt();
            if (type == typeof(float?))
                return obj.AsFloat();
            if (type == typeof(double?))
                return obj.AsDouble();
            if (type == typeof(decimal?))
                return obj.AsDecimal();
            if (type == typeof(DateTime?))
                return obj.AsDateTime();
            if (type.IsEnum)
            {
                try
                {
                    return Enum.ToObject(type, obj);
                }
                catch { }
            }
            try
            {
                return Convert.ChangeType(obj, type);
            }
            catch { return null; }
        }
        /// <summary>
        /// 通过实体更新界面数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        /// <param name="model"></param>
        /// <param name="SearchChild"></param>
        /// <param name="controlPrefix"></param>
        public static void SetValue<T>(Control form, T model, bool SearchChild, string controlPrefix = "input_")
        {
            if (model == null) return;
            PropertyInfo[] info = model.GetType().GetProperties();
            foreach (PropertyInfo item in info)
            {
                try
                {
                    object value = item.GetValue(model, null);
                    Control[] c = form.Controls.Find(controlPrefix + item.Name, SearchChild);
                    if (c.Length == 0) continue;
                    Type type = c[0].GetType();

                    if (type == typeof(TextBox) || type == typeof(TextBoxX))
                    {
                        c[0].Text = value.AsNotNullString();
                        continue;
                    }
                    if (type == typeof(ComboBox) || type == typeof(ComboBoxEx))
                    {
                        ComboBox control = (ComboBox)c[0];
                        if (control.ValueMember.IsNullOrWhiteSpace())
                        {
                            bool find = false;
                            foreach (var comboItem in control.Items)
                            {
                                if (comboItem == value)
                                {
                                    control.SelectedItem = comboItem;
                                    break;
                                }
                            }
                            if (!find)
                                control.Text = value.AsNotNullString();
                        }
                        else
                        {
                            control.SelectedValue = value;
                        }
                        continue;
                    }
                    if (type == typeof(DateTimePicker))
                    {
                        DateTimePicker control = (DateTimePicker)c[0];
                        control.Value = value.AsDateTime(DateTime.Now);
                        continue;
                    }
                    if (type == typeof(DateTimeInput))
                    {
                        DateTimeInput control = (DateTimeInput)c[0];
                        control.ValueObject = value.AsDateTime();
                        continue;
                    }
                    if (type == typeof(CheckBox))
                    {
                        CheckBox control = (CheckBox)c[0];
                        control.Checked = value.AsBoolean();
                        continue;
                    }
                    if (type == typeof(CheckBoxX))
                    {
                        CheckBoxX control = (CheckBoxX)c[0];
                        control.Checked = value.AsBoolean();
                        continue;
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 设置控件内部的修改变更事件
        /// </summary>
        /// <param name="form"></param>
        /// <param name="searchChild"></param>
        /// <param name="action">变更时行为</param>
        public static void SetModifiedChanged(Control form, bool searchChild, Action<Control> action)
        {
            if (form == null) return;
            if (action == null) return;
            foreach (Control ctl in form.Controls)
            {
                if (ctl is TextBoxBase)
                {
                    ctl.TextChanged += (sender, e) => { action(ctl); };
                }
                else
                    if (ctl is ListControl)
                    {
                        (ctl as ListControl).SelectedValueChanged += (sender, e) => { action(ctl); };
                    }
                    else
                        if (ctl is RadioButton)
                        {
                            (ctl as RadioButton).CheckedChanged += (sender, e) => { action(ctl); };
                        }
                        else
                            if (ctl is CheckBox)
                            {
                                (ctl as CheckBox).CheckedChanged += (sender, e) => { action(ctl); };
                            }
                            else
                                if (ctl is CheckBoxX)
                                {
                                    (ctl as CheckBoxX).CheckedChanged += (sender, e) => { action(ctl); };
                                }
                if (searchChild)
                {
                    SetModifiedChanged(ctl, searchChild, action);
                }
            }
        }

        /// <summary>
        /// 根据DataPropertyName,将DGV中的一行载入到Model中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <summary>
        public static T FillModel<T>(DataGridViewRow dr) where T : new()
        {
            if (dr == null)
            {
                return new T();
            }
            T model = new T();

            for (int i = 0; i < dr.Cells.Count; i++)
            {
                PropertyInfo propertyInfo = model.GetType().GetProperty(dr.Cells[i].OwningColumn.DataPropertyName);

                if (propertyInfo != null && dr.Cells[i].Value != DBNull.Value && !dr.Cells[i].Equals(""))
                {
                    if (propertyInfo.PropertyType == typeof(int?))
                        propertyInfo.SetValue(model, Convert.ToInt32(dr.Cells[i].Value), null);
                    else if (propertyInfo.PropertyType == typeof(float?))
                        propertyInfo.SetValue(model, Convert.ToSingle(dr.Cells[i].Value), null);
                    else if (propertyInfo.PropertyType == typeof(decimal?))
                        propertyInfo.SetValue(model, Convert.ToDecimal(dr.Cells[i].Value), null);
                    else if (propertyInfo.PropertyType == typeof(string))
                        propertyInfo.SetValue(model, dr.Cells[i].Value == null ? null : dr.Cells[i].Value.ToString().Trim(), null);
                }
                else
                    continue;
            }

            return model;
        }
    }
}
