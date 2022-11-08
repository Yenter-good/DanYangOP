using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Core;
using CIS.Model;
using System.Linq;

namespace CIS
{
    public partial class FormUserParameterSet : Form
    {
        public FormUserParameterSet()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> dic = new Dictionary<string, string>();
        private List<Sys_UserParameter_Value> resultList = new List<Sys_UserParameter_Value>();

        private List<IView_HIS_DrugUsage> usageList = new List<IView_HIS_DrugUsage>();
        private List<OP_Dic_Interval> IntervalList = new List<OP_Dic_Interval>();
        private List<OP_Dic_PrescriptionType> prescriptionType = new List<OP_Dic_PrescriptionType>();
        private void FormUserParameterSet_Shown(object sender, EventArgs e)
        {
            InitData();
            InitUI();


        }

        private void InitData()
        {
            //用户参数列表
            //List<Sys_UserParameter_Value> list = DBHelper.CIS.From<Sys_UserParameter_Value>().Where(Sys_UserParameter_Value._.UserID == SysContext.RunSysInfo.user.ID).ToList();
            //转成Dic 方便使用
            //dic = list.ToDictionary(k => k.ParameterCode, v => v.ParameterValue);

            dic = CIS.Purview.UserParameterDal.GetDict(SysContext.CurrUser.UserId);
            usageList = DBHelper.CIS.From<IView_HIS_DrugUsage>().OrderBy(IView_HIS_DrugUsage._.Number.Asc).ToList();
            IntervalList = DBHelper.CIS.From<OP_Dic_Interval>().OrderBy(OP_Dic_Interval._.Number.Asc).ToList();
            prescriptionType = DBHelper.CIS.From<OP_Dic_PrescriptionType>().Where(p => p.DrugType == 1).OrderBy(p => p.Code).ToList();

        }

        private void InitUI()
        {
            this.cbxU001.DataSource = SysContext.CurrUser.appList;
            this.cbxU001.ValueMember = "Code";
            this.cbxU001.DisplayMember = "Name";

            this.cbxU006.DataSource = usageList.Where(p => p.Type == "1").ToList();
            this.cbxU006.ValueMember = "Code";
            this.cbxU006.DisplayMember = "Name";

            this.cbxU011.DataSource = usageList.Where(p => p.Type == "2").ToList();
            this.cbxU011.ValueMember = "Code";
            this.cbxU011.DisplayMember = "Name";

            this.cbxU007.DataSource = IntervalList;
            this.cbxU007.ValueMember = "Code";
            this.cbxU007.DisplayMember = "Name";

            this.cbxU008.DataSource = prescriptionType;
            this.cbxU008.ValueMember = "Code";
            this.cbxU008.DisplayMember = "Name";

            Application.DoEvents();

            foreach (Control item in this.sideNavPanel2.Controls)
            {
                if (item.GetType() == typeof(DevComponents.DotNetBar.Controls.ComboBoxEx))
                    (item as DevComponents.DotNetBar.Controls.ComboBoxEx).SelectedIndex = 0;
            }
            foreach (Control item in this.sideGlobal.Controls)
            {
                if (item.GetType() == typeof(DevComponents.DotNetBar.Controls.ComboBoxEx))
                    (item as DevComponents.DotNetBar.Controls.ComboBoxEx).SelectedIndex = 0;
            }
            foreach (Control item in this.sideNavPanel3.Controls)
            {
                if (item.GetType() == typeof(DevComponents.DotNetBar.Controls.ComboBoxEx))
                    (item as DevComponents.DotNetBar.Controls.ComboBoxEx).SelectedIndex = 0;
            }
            SetValue();

            if (SysContext.CurrUser.roleList.Count != 0 && SysContext.CurrUser.roleList[0].Code != "admin")
            {
                this.sideNavItem2.Visible = false;
                this.sideOutpatient.Select();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveValue();
            this.Close();
        }

        private void SetValue()
        {
            foreach (Control item in sideNavPanel2.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control item1 in item.Controls)
                    {
                        if (item1 is DevComponents.DotNetBar.Controls.ComboBoxEx)
                        {
                            DevComponents.DotNetBar.Controls.ComboBoxEx combo = item1 as DevComponents.DotNetBar.Controls.ComboBoxEx;
                            if (combo.DataSource != null)
                            {
                                if (dic.ContainsKey(combo.Name.Replace("cbx", "")))
                                    combo.SelectedValue = dic[combo.Name.Replace("cbx", "")];
                            }
                            else
                            {
                                if (dic.ContainsKey(combo.Name.Replace("cbx", "")))
                                    SetValue(dic[combo.Name.Replace("cbx", "")], combo);
                            }
                        }
                    }
                }
            }
            foreach (Control item in sideGlobal.Controls)
            {
                if (item is DevComponents.DotNetBar.Controls.ComboBoxEx)
                {
                    DevComponents.DotNetBar.Controls.ComboBoxEx combo = item as DevComponents.DotNetBar.Controls.ComboBoxEx;
                    if (combo.DataSource != null)
                    {
                        if (dic.ContainsKey(combo.Name.Replace("cbx", "")))
                            combo.SelectedValue = dic[combo.Name.Replace("cbx", "")];
                    }
                    else
                    {
                        if (dic.ContainsKey(combo.Name.Replace("cbx", "")))
                            SetValue(dic[combo.Name.Replace("cbx", "")], combo);
                    }
                }
            }
        }

        private void SetValue(string value, DevComponents.DotNetBar.Controls.ComboBoxEx combo)
        {
            foreach (DevComponents.Editors.ComboItem item in combo.Items)
            {
                if (item.Text == value)
                    combo.SelectedItem = item;
            }
        }

        private void SaveValue()
        {
            resultList.Clear();
            BuildResult("U001", this.cbxU001.SelectedValue == null ? "" : this.cbxU001.SelectedValue.ToString(), true);
            BuildResult("U002", this.cbxU002.Text, false);
            BuildResult("U003", this.cbxU003.Text, false);
            BuildResult("U004", this.cbxU004.Text, false);
            BuildResult("U005", this.cbxU005.Text, false);
            BuildResult("U006", this.cbxU006.SelectedValue == null ? "" : this.cbxU006.SelectedValue.ToString(), false);
            BuildResult("U007", this.cbxU007.SelectedValue == null ? "" : this.cbxU007.SelectedValue.ToString(), false);
            BuildResult("U008", this.cbxU008.SelectedValue == null ? "" : this.cbxU008.SelectedValue.ToString(), false);
            BuildResult("U010", this.cbxU010.Text, false);
            BuildResult("U011", this.cbxU011.SelectedValue == null ? "" : this.cbxU011.SelectedValue.ToString(), false);
            BuildResult("U012", this.cbxU012.Text, false);
            BuildResult("U013", this.cbxU013.Text, true);
            BuildResult("U014", this.cbxU014.Text, false);
            BuildResult("U015", this.cbxU015.Text, false);
            BuildResult("U016", this.cbxU016.Text, false);
            BuildResult("U017", this.cbxU017.Text, true);
            BuildResult("U018", this.cbxU018.Text, true);
            BuildResult("U019", this.cbxU019.Text, true);
            BuildResult("U020", this.cbxU020.Text, true);
            BuildResult("U021", this.cbxU021.Text, true);

            //DbBatch batch = DBHelper.CIS.BeginBatchConnection();

            if (SysContext.CurrUser.roleList[0].Code == "admin")
                DBHelper.CIS.Delete<Sys_UserParameter_Value>(p => p.UserID == SysContext.CurrUser.UserId || p.UserID == "All");
            else
                DBHelper.CIS.Delete<Sys_UserParameter_Value>(p => p.UserID == SysContext.CurrUser.UserId);
            try
            {
                foreach (Sys_UserParameter_Value item in resultList)
                {
                    DBHelper.CIS.Insert<Sys_UserParameter_Value>(item);
                }
                //更新系统缓存数据
                // SysContext.CurrUser.Params.RefreshData();
                MessageBox.Show("更改用户配置信息后,需要重新启动本程序才生效");
                AlertBox.Info("保存成功");
            }
            catch (Exception ex)
            {
                AlertBox.Error(ex.Message);
            }
            finally
            {
            }
        }

        private void BuildResult(string key, string value, bool IsAll)
        {
            if (IsAll)
            {
                if (SysContext.CurrUser.roleList[0].Code == "admin")
                {
                    Sys_UserParameter_Value item = new Sys_UserParameter_Value();
                    item.UserID = "All";
                    item.ParameterCode = key;
                    item.ParameterValue = value;
                    resultList.Add(item);
                }
            }
            else
            {
                Sys_UserParameter_Value item = new Sys_UserParameter_Value();
                item.UserID = SysContext.CurrUser.user.ID;
                item.ParameterCode = key;
                item.ParameterValue = value;
                resultList.Add(item);
            }
        }

        private void sideExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sideSave_Click(object sender, EventArgs e)
        {
            SaveValue();
        }
    }
}