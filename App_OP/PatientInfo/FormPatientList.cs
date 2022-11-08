using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CIS.Core;
using CIS.Model;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar;

namespace App_OP.PatientInfo
{
    public partial class FormPatientList : BaseForm
    {
        public FormPatientList()
        {
            InitializeComponent();
        }
        public string PayTypeSql { get; set; } = System.Configuration.ConfigurationManager.AppSettings["PayType"].ToString();

        List<IView_HIS_Outpatients> patientList = new List<IView_HIS_Outpatients>();

        /// <summary>
        /// 当天科室的就诊病人
        /// </summary>
        List<IView_HIS_Outpatients> deptHasList = new List<IView_HIS_Outpatients>();
        /// <summary>
        /// 当天个人的就诊病人
        /// </summary>
        List<IView_HIS_Outpatients> personnelHasList = new List<IView_HIS_Outpatients>();
        /// <summary>
        /// 三天内科室的就诊病人
        /// </summary>
        List<IView_HIS_Outpatients> deptHasListTmp = new List<IView_HIS_Outpatients>();
        /// <summary>
        /// 三天内个人的就诊病人
        /// </summary>
        List<IView_HIS_Outpatients> personnelHasListTmp = new List<IView_HIS_Outpatients>();
        private void FormPatientList_Shown(object sender, EventArgs e)
        {
            InitData();
            InitUI();
        }

        private void InitData()
        {
            if (SysContext.CurrUser.Params.OP_EmergencyPatientInfo)
                patientList = DBHelper.CIS.From<IView_HIS_Outpatients_Emergency>().Where(x => x.RegisterTime >= DateTime.Parse(DateTime.Now.AddDays(-2).ToYMD())).ToList<IView_HIS_Outpatients>();
            else
            {
                patientList = DBHelper.CIS.From<IView_HIS_Outpatients>().Where(x => x.RegisterTime >= DateTime.Parse(DateTime.Now.AddDays(-2).ToYMD())).ToList();
                var payTypeCodeNullList = patientList.Where(p => p.PayTypeCode.IsNullOrWhiteSpace() && p.PayType != "自费").Select(p => p.OutpatientNo).ToList();
                var jzhSql = "'" + string.Join("','", payTypeCodeNullList) + "'";
                DataTable table = DBHelper.CIS.FromSql($@"select DISTINCT JZH,{PayTypeSql} from YB_MZJSLS as d  where jzh in({jzhSql})").ToDataTable();

                foreach (var patient in patientList)
                {
                    if (payTypeCodeNullList.Contains(patient.OutpatientNo))
                    {
                        var value = table.Select($"JZH = '{patient.OutpatientNo}'");
                        if (value.Count() > 0 && value[0]["PayType"].AsString("") != "")
                        {
                            patient.PayType = value[0]["PayType"].AsString("");
                        }
                        else
                        {
                            patient.PayType = "医保";
                        }
                    }
                }
            }

            deptHasListTmp = patientList.Where(x => x.DeptCode == SysContext.RunSysInfo.currDept.Code && x.DoctorNo != SysContext.CurrUser.user.Code).ToList();
            personnelHasListTmp = patientList.Where(x => x.DeptCode == SysContext.RunSysInfo.currDept.Code && (x.DoctorNo.AsString("").Trim() == SysContext.CurrUser.user.Code.Trim() || (SysContext.CurrUser.user.Code.Trim() == "9999" && x.DoctorNo.AsString("").Trim() != ""))).ToList();
        }

        private void InitUI()
        {
            gridDept.PrimaryGrid.AutoGenerateColumns = false;
            gridPersonnel.PrimaryGrid.AutoGenerateColumns = false;
            //radioButton1_Click(this.radioButton1, null);
            RefreshData();
            Application.DoEvents();
            this.tbxSearch.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTabIndex == 0)
            {
                SelectPatient(gridDept);
            }
            else
            {
                SelectPatient(gridPersonnel);
            }
        }

        private void SelectPatient(SuperGridControl grid)
        {
            SelectedElementCollection rows = grid.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }
            SysContext.HasRemindChronic = false;
            GridRow row = rows[0] as GridRow;

            IView_HIS_Outpatients patient = new IView_HIS_Outpatients();
            List<IView_HIS_Outpatients> tmp = patientList.Where(p => p.OutpatientNo == row.Cells["gridDept_OutpatientNo"].Value.ToString()).ToList();
            if (tmp.Count == 0)
                return;
            patient = tmp[0];

            if (patient.PatientName == null)
                return;

            if (patient.DeptCode != SysContext.RunSysInfo.currDept.Code)
            {
                DialogResult result = MessageBox.Show(string.Format("该患者不是当前您的科室的患者,属于({0}),是否就诊???", patient.DeptName), "", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                    return;
            }
            SysContext.Session["CurrPatient"] = patient;

            var journal = DBHelper.CIS.From<OP_Journal>().Where(p => p.OutpatientNo == patient.OutpatientNo).First();
            if (journal == null)
                DBHelper.CIS.Insert(GetAutoSaveJournal(patient));

            if (journal == null || journal.IsAutoSave == 0)
            {
                FormWriteJournal j = new FormWriteJournal();
                j.currPatient = patient;
                j.ShowDialog();
            }

            SysContext.IsFirstRecord = 0;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private OP_Journal GetAutoSaveJournal(IView_HIS_Outpatients patient)
        {
            OP_Journal result = new OP_Journal();
            var propertyInfos = result.GetType().GetProperties();
            var propertyInfos1 = patient.GetType().GetProperties().ToList();
            foreach (var propertyInfo in propertyInfos)
            {
                var match = propertyInfos1.Find(p => p.Name == propertyInfo.Name);
                if (match != null)
                    propertyInfo.SetValue(result, match.GetValue(patient, null), null);
            }
            result.ID = Guid.NewGuid().ToString();

            DateTime dtNow = DateTime.Now;

            result.UpdateDate = dtNow;
            result.DeptCode = SysContext.RunSysInfo.currDept.Code;
            result.ProcessTime = dtNow;
            result.IsAutoSave = 0;
            result.DA = DateTime.Now.ToString();
            result.FirstOrMany = "初诊";
            result.DoctorNo = SysContext.CurrUser.user.Code;
            result.DoctorName = SysContext.CurrUser.user.Name;
            result.Sex = patient.Sex;
            result.Birthday = patient.Birthday;
            result.OutpatientNo = patient.OutpatientNo;
            result.OutpatientNo = patient.OutpatientNo;
            result.Age = patient.Age;
            result.PatientName = patient.PatientName;
            result.PatientID = patient.PatientID;

            return result;
        }

        private void SelectPatient(IView_HIS_Outpatients patient)
        {
            if (patient.PatientName == null)
                return;

            SysContext.Session["CurrPatient"] = patient;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridDept_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            SelectPatient(gridDept);
        }

        private void gridPersonnel_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            SelectPatient(gridPersonnel);
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string text = tbxSearch.Text.Trim();
            List<IView_HIS_Outpatients> tmp = new List<IView_HIS_Outpatients>();
            List<IView_HIS_Outpatients> tmp1 = new List<IView_HIS_Outpatients>();
            List<IView_HIS_Outpatients> tmp2 = new List<IView_HIS_Outpatients>();
            if (text.Length == 0)
            {
                RefreshData();
                return;
            }
            else
            {
                tmp = deptHasListTmp.Where(x => x.PatientName.AsNotNullString().Contains(text) || x.SearchCode.AsNotNullString().Contains(text.ToUpper()) || x.OutpatientNo.AsNotNullString().Contains(text) || x.IDCard.AsNotNullString().Contains(text)).ToList();
                tmp1 = personnelHasListTmp.Where(x => x.PatientName.AsNotNullString().Contains(text) || x.SearchCode.AsNotNullString().Contains(text.ToUpper()) || x.OutpatientNo.AsNotNullString().Contains(text) || x.IDCard.AsNotNullString().Contains(text)).ToList();



                if (tmp.Count == 0 && tmp1.Count == 0)
                    tmp = patientList.Where(x => x.PatientName.AsNotNullString().Contains(text) || x.SearchCode.AsNotNullString().Contains(text.ToUpper()) || x.OutpatientNo.AsNotNullString().Contains(text) || x.IDCard.AsNotNullString().Contains(text)).ToList();

                //if (tmp.Count != 0 && tmp1.Count != 0)
                //{
                InsertData(tmp, this.gridDept);
                InsertData(tmp1, this.gridPersonnel);
                //    return;
                //}

                //if (tmp.Count != 0)
                //    InsertData(tmp, this.gridDept);
                //else
                //    InsertData(tmp1, this.gridPersonnel);
            }

            Application.DoEvents();//处理消息队列 清除界面堵塞
            gridDept.PrimaryGrid.SetSelectedRows(0, 1, true);
            gridPersonnel.PrimaryGrid.SetSelectedRows(0, 1, true);

        }

        private void FormPatientList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(this.gridDept.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_KEYDOWN, (int)e.KeyValue, 0);
                e.SuppressKeyPress = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.btnOK_Click(null, null);
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            (sender as RadioButton).Checked = true;
            RefreshData();
        }

        private void RefreshData()
        {

            deptHasList = deptHasListTmp.Where(p => p.RegisterTime >= DateTime.Parse(DateTime.Now.ToShortDateString())).OrderBy(p => p.RegisterNo).ThenBy(p => p.State).ToList();
            personnelHasList = personnelHasListTmp.Where(p => p.RegisterTime >= DateTime.Parse(DateTime.Now.ToShortDateString())).OrderBy(p => p.RegisterNo).ThenBy(p => p.State).ToList();


            //this.gridDept.PrimaryGrid.DataSource = deptHasList;
            //this.gridPersonnel.PrimaryGrid.DataSource = personnelHasList;

            InsertData(deptHasList, this.gridDept);
            Application.DoEvents();
            InsertData(personnelHasList, this.gridPersonnel);
            Application.DoEvents();
            this.tbxSearch.Focus();
        }

        private void InsertData(List<IView_HIS_Outpatients> list, SuperGridControl grid)
        {
            grid.PrimaryGrid.Rows.Clear();

            List<IView_HIS_Outpatients> no = list.Where(p => p.State != "1" && p.State != "2").ToList();
            GridRow rowNo = new GridRow("未就诊：{0}人".FormatWith(no.Count));
            rowNo.CellStyles.Default.Font = new Font(this.Font, FontStyle.Bold);
            foreach (IView_HIS_Outpatients item in no)
            {
                if (grid == this.gridDept)
                {
                    GridRow tmp = new GridRow(new object[] { item.OutpatientNo, item.DoctorName, item.PayType, item.PatientName, item.Age, item.Sex, item.RegisterNo, item.Category, item.EmerencyFlag, item.DeptName, item.SearchCode, item.IDCard });
                    rowNo.Rows.Add(tmp);
                }
                else
                {
                    GridRow tmp = new GridRow(new object[] { item.OutpatientNo, item.PayType, item.PatientName, item.Age, item.Sex, item.RegisterNo, item.Category, item.EmerencyFlag, item.DeptName, item.SearchCode, item.IDCard });
                    rowNo.Rows.Add(tmp);
                }
            }
            List<IView_HIS_Outpatients> yes = list.Where(p => p.State == "1").ToList();
            GridRow rowYes = new GridRow("就诊中：{0}人".FormatWith(yes.Count));
            rowYes.CellStyles.Default.Font = new Font(this.Font, FontStyle.Bold);
            foreach (IView_HIS_Outpatients item in yes)
            {
                if (grid == this.gridDept)
                {
                    GridRow tmp = new GridRow(new object[] { item.OutpatientNo, item.DoctorName, item.PayType, item.PatientName, item.Age, item.Sex, item.RegisterNo, item.Category, item.EmerencyFlag, item.DeptName, item.SearchCode, item.IDCard });
                    rowYes.Rows.Add(tmp);
                }
                else
                {
                    GridRow tmp = new GridRow(new object[] { item.OutpatientNo, item.PayType, item.PatientName, item.Age, item.Sex, item.RegisterNo, item.Category, item.EmerencyFlag, item.DeptName, item.SearchCode, item.IDCard });
                    rowYes.Rows.Add(tmp);
                }
            }
            List<IView_HIS_Outpatients> finish = list.Where(p => p.State == "2").ToList();
            GridRow rowFinishs = new GridRow("就诊结束：{0}人".FormatWith(finish.Count));
            rowFinishs.CellStyles.Default.Font = new Font(this.Font, FontStyle.Bold);
            foreach (IView_HIS_Outpatients item in finish)
            {
                if (grid == this.gridDept)
                {
                    GridRow tmp = new GridRow(new object[] { item.OutpatientNo, item.DoctorName, item.PayType, item.PatientName, item.Age, item.Sex, item.RegisterNo, item.Category, item.EmerencyFlag, item.DeptName, item.SearchCode, item.IDCard });
                    rowFinishs.Rows.Add(tmp);
                }
                else
                {
                    GridRow tmp = new GridRow(new object[] { item.OutpatientNo, item.PayType, item.PatientName, item.Age, item.Sex, item.RegisterNo, item.Category, item.EmerencyFlag, item.DeptName, item.SearchCode, item.IDCard });
                    rowFinishs.Rows.Add(tmp);
                }
            }

            grid.PrimaryGrid.Rows.Add(rowNo);
            grid.PrimaryGrid.Rows.Add(rowYes);
            grid.PrimaryGrid.Rows.Add(rowFinishs);
            Application.DoEvents();
            grid.Refresh();
            grid.PrimaryGrid.ExpandAll();
        }

        private void tabMain_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            string text = tbxSearch.Text.Trim();
            List<IView_HIS_Outpatients> tmp = new List<IView_HIS_Outpatients>();
            List<IView_HIS_Outpatients> tmp1 = new List<IView_HIS_Outpatients>();
            List<IView_HIS_Outpatients> tmp2 = new List<IView_HIS_Outpatients>();
            if (text.Length == 0)
            {
                InsertData(deptHasList, this.gridDept);
                InsertData(personnelHasList, this.gridPersonnel);
                return;
            }
            tmp = deptHasListTmp.Where(x => x.PatientName.AsNotNullString().Contains(text) || x.SearchCode.AsNotNullString().Contains(text.ToUpper()) || x.OutpatientNo.AsNotNullString().Contains(text) || x.IDCard.AsNotNullString().Contains(text)).ToList();
            tmp1 = personnelHasListTmp.Where(x => x.PatientName.AsNotNullString().Contains(text) || x.SearchCode.AsNotNullString().Contains(text.ToUpper()) || x.OutpatientNo.AsNotNullString().Contains(text) || x.IDCard.AsNotNullString().Contains(text)).ToList();

            if (tmp.Count == 0 && tmp1.Count == 0)
                tmp = patientList.Where(x => x.PatientName.AsNotNullString().Contains(text) || x.SearchCode.AsNotNullString().Contains(text.ToUpper()) || x.OutpatientNo.AsNotNullString().Contains(text) || x.IDCard.AsNotNullString().Contains(text)).ToList();

            //if (tmp.Count != 0 && tmp1.Count != 0)
            //{
            InsertData(tmp, this.gridDept);
            InsertData(tmp1, this.gridPersonnel);
            //    return;
            //}

            //if (tmp.Count != 0)
            //    InsertData(tmp, this.gridDept);
            //else
            //    InsertData(tmp1, this.gridPersonnel);


            //InsertData(deptHasList, this.gridDept);
            //InsertData(personnelHasList, this.gridPersonnel);
            //Application.DoEvents();
            //this.tbxSearch.Focus();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            InitData();
            InitUI();
        }

        private void 选择此病人ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabDept.IsSelected)
                SelectPatient(gridDept);
            else
                SelectPatient(gridPersonnel);
        }

        private void 复制姓名ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows;
            if (this.tabDept.IsSelected)
                rows = this.gridDept.GetSelectedRows();
            else
                rows = this.gridPersonnel.GetSelectedRows();

            if (rows.Count > 0)
            {
                GridRow row = rows[0] as GridRow;
                Clipboard.SetText(row.Cells["gridDept_PatientName"].Value.AsString(""));
            }
        }

        private void 复制就诊号ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows;
            if (this.tabDept.IsSelected)
                rows = this.gridDept.GetSelectedRows();
            else
                rows = this.gridPersonnel.GetSelectedRows();

            if (rows.Count > 0)
            {
                GridRow row = rows[0] as GridRow;
                Clipboard.SetText(row.Cells["gridDept_OutpatientNo"].Value.AsString(""));
            }
        }
    }
}
