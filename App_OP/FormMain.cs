using App_OP.Examination;
using App_OP.Examination.PACSShare;
using App_OP.HealthRecords;
using App_OP.PatientInfo;
using App_OP.Prescription;
using App_OP.PrescriptionCirculation;
using App_OP.PrescriptionCirculation.AuditResult;
using App_OP.PrescriptionCirculation.TakeDrugResult;
using App_OP.PrescriptionCirculation.Undo;
using App_OP.PrescriptionCirculation.ViewPrescription;
using App_OP.Record;
using App_OP.Surgery;
using CIS.Core;
using CIS.Core.EventBroker;
using CIS.Core.Interceptors;
using CIS.Model;
using CIS.Utility;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dos.ORM;
using FastReport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App_OP
{
    public partial class FormMain : BaseForm
    {
        public FormMain()
        {
            InitializeComponent();
            //broker.Register(this);
            //broker.Register(CIS.Core.SysContext.Publisher);
        }

        FormRecord formRecord;//病历界面
        FormLISRequisition formLisRequisition;//检验申请界面
        FormRISRequisition formPacsRequisition;//检查申请界面
        FormReportManage1 formReportManage;//报卡日志管理界面
        //CIS.Core.EventBroker.EventBroker broker = new CIS.Core.EventBroker.EventBroker();
        List<OP_Prescription_Detail> Prescription_Detail = new List<OP_Prescription_Detail>(); //当前病人处方明细列表
        public FormPrescription formPrescription;//处方界面
        FormSurgery formSurgery = new FormSurgery();//手术界面
        List<IView_HIS_ICD> ICD = new List<IView_HIS_ICD>();  //所有ICD
        List<IView_HIS_ICD> CommonICD = new List<IView_HIS_ICD>();  //常用诊断
        List<OP_Dic_PrescriptionType> prescriptionType = new List<OP_Dic_PrescriptionType>();
        FastReport.EnvironmentSettings environment = new EnvironmentSettings();
        private int _prescriptionCirculationCount;

        private DataTable _emergency;
        private HealthRecordsURLHelper _healthRecords;

        #region 构建页面
        private void FormMain_Shown(object sender, EventArgs e)
        {
            //aa();
            _healthRecords = new HealthRecordsURLHelper();

            if (!SysContext.RunSysInfo.Params.OP_FreeRegistered)
            {
                btnQAdd.Visible = false;
            }
            if (SysContext.RunSysInfo.currDept.Code == "21000500")
                this.btnSEMR.Visible = true;

            formRecord = new FormRecord(this);
            formLisRequisition = new FormLISRequisition(this);
            formPacsRequisition = new FormRISRequisition(this);
            formPrescription = new FormPrescription(this);
            formReportManage = new FormReportManage1(this);
            if (SysContext.CurrUser.roleList.Find(p => p.Code == "hs") != null)
            {
                ShowTab("病历", formRecord, "clipboard");
                ShowTab("处方", formPrescription, "capsule");
                ShowTab("报卡", formReportManage, "prescription");
            }
            else
            {
                ShowTab("病历", formRecord, "clipboard");
                ShowTab("处方", formPrescription, "capsule");
                ShowTab("检验", formLisRequisition, "blood");
                ShowTab("检查", formPacsRequisition, "ecg");
                ShowTab("报卡", formReportManage, "prescription");
            }
            //ShowTab("手术", formSurgery, "clamp");

            tabMain.SelectedTab = tabMain.Tabs["处方"] as SuperTabItem;//选中处方
            //tabMain.SelectedTabIndex = 0;
            InitDict();
            InitUI();

            InitICD();
        }

        private void InitUI()
        {
            this.dgvZDDetail.Parent = this;
            this.dgvZDDetail.BringToFront();
            this.dgvZDDetail.AutoGenerateColumns = false;

            DataTable dtSFQZ = new DataTable();
            dtSFQZ.Columns.Add("MC");
            dtSFQZ.Columns.Add("Value");
            dtSFQZ.Rows.Add(new object[] { "确诊", "1" });
            dtSFQZ.Rows.Add(new object[] { "待查", "2" });
            CIS.ControlLib.Controls.MyComboBox combo = new CIS.ControlLib.Controls.MyComboBox(dtSFQZ, "MC", "Value");
            GridPanel panel = this.dgvZD.PrimaryGrid;
            panel.Columns["Status"].EditorType = typeof(CIS.ControlLib.Controls.MyComboBox);
            panel.Columns["Status"].EditorParams = new object[] { dtSFQZ, "MC", "Value" };

            if (SysContext.UserPositionSetting != null && SysContext.UserPositionSetting.PatientInfoPosition > 0)
            {
                this.dgvZD.Height = SysContext.UserPositionSetting.PatientInfoPosition;
            }

            PrescriptionCirculationHandler.PatientDiagnosis += PrescriptionCirculationHandler_PatientDiagnosis;
        }

        private void PrescriptionCirculationHandler_PatientDiagnosis(object sender, PatientDiagnosisEventArgs e)
        {
            e.Diagnosis = this.GEtDiagnosis();
        }

        public void ShowTab(string caption, Control formType, string imageName)
        {
            Form form = formType as Form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Visible = true;
            form.Dock = DockStyle.Fill;
            SuperTabItem tabItem = tabMain.CreateTab(caption);
            tabItem.Name = caption;
            tabItem.Text = caption;
            tabItem.Tag = imageName;
            tabItem.CloseButtonVisible = false;
            tabItem.Image = Properties.Resources.ResourceManager.GetObject(imageName) as Image;
            tabItem.AttachedControl.Controls.Add(form);
            //SysContext.EventBroker.Register(form);
        }
        #endregion

        #region 初始化操作
        private void LoadPatientInfo()
        {
            if (SysContext.Session.ContainsKey("CurrPatient"))
            {
                IView_HIS_Outpatients patient = SysContext.Session["CurrPatient"] as IView_HIS_Outpatients;
                lblName.Text = string.Format(@"姓名：<b><font color=""#FF0000"">{0}</font></b>", patient.PatientName.Trim());
                lblSex.Text = string.Format(@"  性别：<b><font color=""#FF0000"">{0}</font></b>", patient.Sex.Trim());
                lblAge.Text = string.Format(@"  年龄：<b><font color=""#FF0000"">{0}</font></b>", patient.Age.Trim());
                lblIdentity.Text = string.Format(@"  身份：<b><font color=""#FF0000"">{0}</font></b>", patient.PayType.Trim());
                lblCategory.Text = string.Format(@"  号别：<b><font color=""#FF0000"">{0}</font></b>", patient.Category.Trim());
            }
        }

        public void ClearPatientInfo()
        {
            lblName.Text = string.Format(@"姓名：");
            lblSex.Text = string.Format(@"  性别：");
            lblAge.Text = string.Format(@"  年龄：");
            lblIdentity.Text = string.Format(@"  身份：");
            lblCategory.Text = string.Format(@"  号别：");

            this.dgvPrescription.PrimaryGrid.Rows.Clear();
            this.dgvZD.PrimaryGrid.Rows.Clear();
        }

        /// <summary>
        /// 初始化字典信息
        /// </summary>
        private void InitDict()
        {
            //var pCode = this.dgvPrescription.PrimaryGrid.Columns["col_Name"];
            //pCode.EditorType = typeof(CIS.ControlLib.Controls.MyComboBox);
            prescriptionType = DBHelper.CIS.From<OP_Dic_PrescriptionType>().ToList();

            PrescriptionCirculation.PrescriptionCirculationHandler.Init();
            PACSShareHelper.Init();
            //pCode.EditorParams = new object[] { list, "Name", "Code" };
        }

        /// <summary>
        /// 初始化处方
        /// </summary>
        private void InitPrescription()
        {
            if (SysContext.GetCurrPatient != null)
            {
                IView_HIS_Outpatients patient = SysContext.GetCurrPatient;
                List<OP_Prescription> Prescription = DBHelper.CIS.From<OP_Prescription>().Where(p => p.TreatmentNo == patient.OutpatientNo).OrderByDescending(p => p.HISInterface_PrescriptionNo).ToList();
                foreach (OP_Prescription item in Prescription)
                {
                    if (item.Burette == null)
                    {
                        item.Burette = prescriptionType.Where(p => p.Code == item.PrescriptionType).First().Name;
                    }
                    else
                    {
                        item.Burette = prescriptionType.Where(p => p.Code == item.PrescriptionType).First().Name + string.Format("({0})", item.Burette);
                    }
                }
                this.dgvPrescription.PrimaryGrid.DataSource = Prescription;
                Application.DoEvents();
                //if (Prescription.Count > 0)
                //{
                if (this.dgvPrescription.PrimaryGrid.Rows.Count != 0)
                {
                    this.dgvPrescription.PrimaryGrid.ClearSelectedRows();
                    this.dgvPrescription.PrimaryGrid.SetActiveRow(this.dgvPrescription.PrimaryGrid.Rows[0] as GridContainer);
                    this.dgvPrescription.PrimaryGrid.SetSelectedRows(0, 1, true);
                }
                //}
                InitColorFromPrescriptionStatus();
                Prescription_Detail = DBHelper.CIS.From<OP_Prescription_Detail>().Where(p => p.TreatmentNo == patient.OutpatientNo && p.IsAdditional == 0).ToList();
            }
        }

        /// <summary>
        /// 初始化慢性病
        /// </summary>
        private void InitChronic()
        {
            List<Chronic> list = DBHelper.CIS.FromProc("Proc_OP_PatientChronic").AddInParameter("@OutpatientNo", DbType.String, SysContext.GetCurrPatient.OutpatientNo).ToList<Chronic>();
            this.dgvChronic.PrimaryGrid.DataSource = list;
            Application.DoEvents();
            this.dgvChronic.PrimaryGrid.SetSelectedRows(0, 1, true);
        }

        private void InitColorFromPrescriptionStatus()
        {
            foreach (GridRow item in this.dgvPrescription.PrimaryGrid.Rows)
            {
                Background background;
                string Status = item.Cells["col_Status"].Value.ToString();
                if (Status == "0")
                {
                    item.Cells["col_StatusName"].Value = "未";
                    background = new Background(Color.FromArgb(255, 255, 255));
                }
                else if (Status == "1")
                {
                    item.Cells["col_StatusName"].Value = "发";
                    background = new Background(Color.FromArgb(80, 0, 255, 0));
                }
                else if (Status == "2")
                {
                    item.Cells["col_StatusName"].Value = "收";
                    background = new Background(Color.FromArgb(80, 255, 0, 0));
                }
                else if (Status == "3")
                {
                    item.Cells["col_StatusName"].Value = "废";
                    background = new Background(Color.FromArgb(80, 214, 219, 233));
                }
                else
                {
                    background = new Background(Color.FromArgb(255, 255, 255));
                }

                foreach (GridCell item1 in item.Cells)
                {
                    item1.CellStyles.Default.Background = background;
                }
            }
            this.dgvPrescription.PrimaryGrid.ClearSelectedCells();
        }
        #endregion

        #region 上部bar代码
        private void btnQChange_Click(object sender, EventArgs e)
        {
            FormSearchPatient form = new FormSearchPatient();
            form.type = "changeDept";
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SysContext.Session[SysContext.Session_CurrPatient] = null;
                formPrescription.InitUI();
                ClearPatientInfo();
            }
        }

        private void btnQAdd_Click(object sender, EventArgs e)
        {
            FormSearchPatient form = new FormSearchPatient();
            form.type = "registered";
            form.ShowDialog();
        }

        private void btnChoosePatient_Click(object sender, EventArgs e)
        {
            FormPatientList form = new FormPatientList();
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            if (SysContext.CurrUser.Params.OP_SelectPatientWithCall == "是")
            {
                btnCallPatient_Click(null, null);
            }



            formPrescription.InitDrugInfo();
            LoadPatientInfo();
            InitPrescription();

            var dt = DBHelper.CIS.FromSql($"select * from v_wjz where BLH='{SysContext.GetCurrPatient.OutpatientNo}' and ReadFlag=0").ToDataTable();
            if (dt.Rows.Count > 0)
            {
                _emergency = dt;
                this.btnExistsEmergency.Visible = true;
                FormEmergency formEmergency = new FormEmergency();
                formEmergency.Init(dt);
                formEmergency.ShowDialog();
            }
            else
            {
                _emergency = null;
                this.btnExistsEmergency.Visible = false;
            }

            PrescriptionCirculationHandler.NewPatient();

            formPrescription.InitUI(true);
            formLisRequisition.InitUI();
            formPacsRequisition.InitUI(true);
            formRecord.InitUI();

            formReportManage.InitTabs();
            //InitChronic();
            InitZD();
            CommonICD = DBHelper.CIS.From<OP_Dic_CommonICD>().InnerJoin<IView_HIS_ICD>((a, b) => a.Code == b.Code).Where(p => p.DeptCode == SysContext.RunSysInfo.currDept.Code).Select(IView_HIS_ICD._.All).ToList<IView_HIS_ICD>().ToList().Where(p => p.Name != null).ToList();
            Application.DoEvents();

            if (this.dgvZD.PrimaryGrid.Rows.Count == 0)
            {
                this.tbxZDFilter.Focus();
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (SysContext.GetCurrPatient == null)
            {
                return;
            }

            string treatmentNo = SysContext.GetCurrPatient.OutpatientNo;
            DBHelper.CIS.FromSql(string.Format("UPDATE GHBRZL SET CZJC = '2' WHERE JZH='{0}'", treatmentNo)).ExecuteNonQuery();
            DBHelper.CIS.FromSql(string.Format("UPDATE GHBRZL SET YSBM=(CASE WHEN YSBM IS NULL OR RTRIM(YSBM)='' THEN '{0}' ELSE YSBM END),YSXM=(CASE WHEN YSXM IS NULL OR RTRIM(YSXM)='' THEN '{1}' ELSE YSXM END) WHERE JZH='{2}'", SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, treatmentNo)).ExecuteNonQuery();
            DBHelper.CIS.FromSql(string.Format("UPDATE MZ_SFDJB SET YSDM=(CASE WHEN YSDM IS NULL OR RTRIM(YSDM)='' THEN '{0}' ELSE YSDM END) WHERE JZH='{1}' AND CFDH='0'", SysContext.CurrUser.user.Code, treatmentNo)).ExecuteNonQuery();
            DBHelper.CIS.FromSql(string.Format("UPDATE MZ_SFMXB SET YSBM=(CASE WHEN YSBM IS NULL OR RTRIM(YSBM)='' THEN '{0}' ELSE YSBM END) ,YSXM=(CASE WHEN YSXM IS NULL OR RTRIM(YSXM)='' THEN '{1}' ELSE YSXM END) WHERE JZH='{2}' AND CFDH='0'", SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.GetCurrPatient.OutpatientNo)).ExecuteNonQuery();

            SysContext.Session[SysContext.Session_CurrPatient] = null;
            formPrescription.InitUI();
            ClearPatientInfo();
            AlertBox.Info("该病人已经更改为就诊结束状态");
        }
        #endregion

        #region 诊断信息

        private void dgvZDDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (this.dgvZDDetail.Rows[e.RowIndex].Cells["DiagnosisType"].Value.ToString() == "ICD")
                {
                    e.Value = "西医";
                }
                else if (this.dgvZDDetail.Rows[e.RowIndex].Cells["DiagnosisType"].Value.ToString() == "HMSymptom")
                {
                    e.Value = "症候";
                }
                else
                {
                    e.Value = "中医";
                }
            }
        }
        private void dgvZD_RowAdded(bool IsHM)
        {
            InsertDiagnosisInRecord();
            formPrescription.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            formLisRequisition.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            formPacsRequisition.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            if (this.formPrescription.btnXYAdd.Enabled == false)
            {
                formPrescription.InitNormalPrescription();
            }

            if (!this.formPrescription.btnCYAdd.Enabled && IsHM)
            {
                formPrescription.InitNormalPrescription(IsHM);
            }
        }
        private void dgvZD_RowDeleted()
        {
            //HandleRefreshPatient(null, new PatientEventArgs() { Mode = new PatientEventArgs.UpdateMode() { GetHMDiagnosis = true } });
            //formPrescription.InitNormalPrescription(false, true);
            bool HasHM = false;
            foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
            {
                if (item.Cells["Type"].Value.AsString("2") != "2")
                {
                    HasHM = true;
                }
            }
            InsertDiagnosisInRecord();
            formPrescription.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            formLisRequisition.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            formPacsRequisition.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            if (this.dgvZD.PrimaryGrid.Rows.Count == 0)
            {
                formPrescription.InitUI();
            }

            if (!HasHM)
            {
                formPrescription.InitUI(ClearHM: true);
            }
        }

        private void dgvZDDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tbxZDFilter_KeyDown(null, new KeyEventArgs(Keys.Enter));
        }

        private void dgvZDDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxZDFilter_KeyDown(null, e);
            }
        }

        private void dgvZD_EndEdit(object sender, GridEditEventArgs e)
        {
            if (e.GridCell.GridColumn.Name == "Status")
            {
                InsertDiagnosisInRecord();
            }
        }


        /// <summary>
        /// 初始化ICD诊断
        /// </summary>
        private void InitICD()
        {
            ICD = DBHelper.CIS.From<IView_HIS_ICD>().ToList();
            CommonICD = DBHelper.CIS.From<OP_Dic_CommonICD>().InnerJoin<IView_HIS_ICD>((a, b) => a.Code == b.Code).Where(p => p.DeptCode == SysContext.RunSysInfo.currDept.Code).Select(IView_HIS_ICD._.All).ToList<IView_HIS_ICD>().ToList().Where(p => p.Name != null).ToList();
        }

        /// <summary>
        /// 初始化病人诊断
        /// </summary>
        private void InitZD()
        {
            this.dgvZD.PrimaryGrid.Rows.Clear();
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                return;
            }

            List<OP_PatientDiagnosis> diagnosis = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.TreatmentNo == (SysContext.Session["CurrPatient"] as IView_HIS_Outpatients).OutpatientNo).OrderBy(p => new { p.Type, p.Index }).ToList();
            bool HasHM = false;
            foreach (OP_PatientDiagnosis item in diagnosis)
            {
                object[] obj = new object[] { item.ID, item.Name, item.Status.ToString(), item.IsMain, item.Code, item.IsHMDiagnosis, item.Type };
                GridRow row = new GridRow(obj);
                row.Tag = item;
                this.dgvZD.PrimaryGrid.Rows.Add(row);
                if (item.Type != 2)
                {
                    HasHM = true;
                }
                //SelectChronicFromDiagnosis(item.Code);
            }
            formPrescription.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            formLisRequisition.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            formPacsRequisition.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            InsertDiagnosisInRecord();

            if (this.formPrescription.btnXYAdd.Enabled == false && this.dgvZD.PrimaryGrid.Rows.Count > 0)
            {
                formPrescription.InitNormalPrescription();
            }

            if (this.formPrescription.btnCYAdd.Enabled == false && HasHM)
            {
                formPrescription.InitNormalPrescription(HasHM);
            }
        }

        private void SelectChronicFromDiagnosis(string ChronicCode)
        {
            foreach (GridRow item in this.dgvChronic.PrimaryGrid.Rows)
            {
                if (item.Cells["MXB_Code"].Value.ToString() == ChronicCode)
                {
                    item.Cells["MXB_Select"].Value = true;
                    formPrescription.ChronicCode = item.Cells["MXB_Code"].Value.ToString();
                    formPrescription.ChronicName = item.Cells["MXB_Name"].Value.ToString();
                    formPrescription.ChronicType = item.Cells["MXB_Type"].Value.ToString();
                }
            }
        }

        private void tbxZDFilter_TextChanged(object sender, EventArgs e)
        {
            if (this.tbxZDFilter.Text == "")
            {
                this.dgvZDDetail.Hide();
                return;
            }
            object obj = new List<IView_HIS_ICD>();
            if (this.btnCommonICD.Checked)
            {
                try
                {
                    obj = CommonICD.Where(p => p.SearchCode != null && p.Name != null).Where(p => p.SearchCode != null && p.Name != null && (p.SearchCode.Contains(this.tbxZDFilter.Text.ToUpper()) || p.Name.Contains(this.tbxZDFilter.Text))).OrderBy(p => p.Name.Length).ToList();
                }
                catch
                {

                }

            }
            else if (this.btnICD.Checked)
            {
                obj = ICD.Where(p => (p.SearchCode.Contains(this.tbxZDFilter.Text.ToUpper()) || p.Name.Contains(this.tbxZDFilter.Text)) && p.Type == "ICD").OrderBy(p => p.Name.Length).ToList();
            }
            else if (this.btnHMDiagnosis.Checked)
            {
                obj = ICD.Where(p => (p.SearchCode.Contains(this.tbxZDFilter.Text.ToUpper()) || p.Name.Contains(this.tbxZDFilter.Text)) && p.Type == "HMDiagnosis").OrderBy(p => p.Name.Length).ToList();
            }
            else
            {
                obj = ICD.Where(p => (p.SearchCode.Contains(this.tbxZDFilter.Text.ToUpper()) || p.Name.Contains(this.tbxZDFilter.Text)) && p.Type == "HMSymptom").OrderBy(p => p.Name.Length).ToList();
            }

            this.dgvZDDetail.DataSource = obj;
            //Application.DoEvents();
            //foreach (DataGridViewRow item in this.dgvZDDetail.Rows)
            //{
            //    if (item.Cells["DiagnosisType"].Value.AsString("") == "ICD")
            //        item.Cells["Column1"].Value = "ICD";
            //    else if (item.Cells["DiagnosisType"].Value.AsString("") == "HMSymptom")
            //        item.Cells["Column1"].Value = "中医症候";
            //    else
            //        item.Cells["Column1"].Value = "中医诊断";
            //}
            this.dgvZDDetail.Show();
        }

        private void dgvZDDetail_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.dgvZDDetail.Visible)
            {
                return;
            }

            Point p = this.PointToClient(this.pnlRight.PointToScreen(this.tbxZDFilter.Location));
            this.dgvZDDetail.Location = new Point(p.X - this.dgvZDDetail.Width - 10, p.Y);
        }

        private void btnICD_Click(object sender, EventArgs e)
        {
            this.btnICD.Checked = false;
            this.btnCommonICD.Checked = false;
            this.btnHMDiagnosis.Checked = false;
            this.btnHMSymptom.Checked = false;

            (sender as ButtonItem).Checked = true;

            this.tbxZDFilter_TextChanged(null, null);
        }

        private void tbxZDFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.dgvZDDetail.Visible)
                {
                    return;
                }

                if (SysContext.GetCurrPatient == null)
                {
                    AlertBox.Info("请先选择病人");
                    return;
                }
                if (this.tbxZDFilter.Text == "")
                {
                    return;
                }

                DataGridViewSelectedRowCollection rows = this.dgvZDDetail.SelectedRows;
                bool HasMain = true;
                foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
                {
                    if (item.Cells["IsMain"].Value.AsBoolean())
                    {
                        HasMain = false;
                    }
                }
                OP_PatientDiagnosis diagnosis;
                string Name;
                string ID;
                string ICD;
                string diagnosisType;
                string specialType;
                if (rows.Count == 0)
                {
                    return;
                }
                else
                {
                    Name = rows[0].Cells["colName"].Value.ToString();
                    ICD = rows[0].Cells["colCode"].Value.ToString();
                    diagnosisType = rows[0].Cells["DiagnosisType"].Value.ToString();
                    specialType = rows[0].Cells[DiagnosisSpecialFlag.Index].Value.ToString();
                    diagnosis = InitPatientDiagnosis(rows[0].Cells["colCode"].Value.ToString(), rows[0].Cells["colName"].Value.ToString(), 1, diagnosisType, HasMain, out ID);
                    diagnosis.SpecialType = specialType;
                }
                foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
                {
                    if (item.Cells["ICD"].Value.ToString() == ICD && item.Cells["ZDMC"].Value.ToString() == Name)
                    {
                        AlertBox.Info("已经添加了相同的诊断");
                        return;
                    }
                }

                if (specialType.Trim().Substring(0, 1) == "1") //如果是慢病
                {
                    int flag = 0;//0不调用 1调用慢性病报卡 2调用慢阻病报卡
                    if (specialType == "11")
                    {
                        string sql = $"select count(*) from Card_Mxb_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}' and hisxm='{SysContext.GetCurrPatient.PatientName}' and zllx is not null and czjc<>'f' and left(zlbm,3)='{ICD.Substring(0, 3)}'";

                        var count = DBHelper.HNIMIS.FromSql(sql).ToScalar<int>();
                        Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("查询患者慢性病信息", sql, $"查询到的数量是{count}"), Log4NetLevel.Info);
                        if (count == 0)
                            flag = 1;
                    }
                    else if (specialType == "12")
                    {
                        string sql = $"select count(*) from Card_Mxb_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}' and hisxm='{SysContext.GetCurrPatient.PatientName}' and gxblx<>'00' and czjc<>'f'";
                        var count = DBHelper.HNIMIS.FromSql(sql).ToScalar<int>();
                        Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("查询患者慢性病信息", sql, $"查询到的数量是{count}"), Log4NetLevel.Info);
                        if (count == 0)
                            flag = 1;
                    }
                    else if (specialType == "13")
                    {
                        string sql = $"select count(*) from Card_Mxb_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}' and hisxm='{SysContext.GetCurrPatient.PatientName}' and nczlx<>'00' and czjc<>'f' and czrq>'{SysContext.GetCurrPatient.RegisterTime.AddDays(-28)}'";

                        var count = DBHelper.HNIMIS.FromSql(sql).ToScalar<int>();
                        Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("查询患者慢性病信息", sql, $"查询到的数量是{count}"), Log4NetLevel.Info);
                        if (count == 0)
                            flag = 1;
                    }
                    else if (specialType == "14")
                    {
                        string sql = $"select count(*) from MZF_INTERFACE where sfzh='{SysContext.GetCurrPatient.IDCard}' and brxm='{SysContext.GetCurrPatient.PatientName}' and czjc<>'f'";
                        var count = DBHelper.HNIMIS.FromSql(sql).ToScalar<int>();
                        Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("查询患者慢性病信息", sql, $"查询到的数量是{count}"), Log4NetLevel.Info);
                        if (count == 0)
                            flag = 2;
                    }
                    if (flag == 1)
                    {
                        Infect.Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "15");
                    }
                    else if (flag == 2)
                        Infect.Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "16");
                }
                else if (specialType.Trim() == "2") //如果是传染病
                {
                    if (!Infect.CheckInfection(Name, ICD))
                    {
                        string sql = $"select count(*) from Card_infect_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}'";
                        var count = DBHelper.HNIMIS.FromSql(sql).ToScalar<int>();
                        Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("查询患者传染病信息", sql, $"查询到的数量是{count}"), Log4NetLevel.Info);
                        if (count == 0)
                            Infect.Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "0");
                    }
                }
                var data = DBHelper.CIS.Insert<OP_PatientDiagnosis>(diagnosis);
                CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存诊断", SerializeHelper.BeginJsonSerializable(diagnosis), data > 0 ? "保存诊断成功！" : "保存诊断失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
                if (data > 0)
                {
                    //object[] obj = new object[] { ID, Name, "1", HasMain, ICD, diagnosis.IsHMDiagnosis };
                    //GridRow row = new GridRow(obj);
                    //this.dgvZD.PrimaryGrid.Rows.Add(row);
                    this.dgvZDDetail.Hide();
                    this.tbxZDFilter.Clear();
                    InitZD();
                    dgvZD_RowAdded(diagnosisType != "ICD" ? true : false);
                }

                formPrescription.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
                formLisRequisition.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
                formPacsRequisition.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
                InsertDiagnosisInRecord();
                DBHelper.CIS.FromSql(string.Format("UPDATE GHBRZL SET CZJC='1' WHERE JZH='{0}'", SysContext.GetCurrPatient.OutpatientNo)).ExecuteNonQuery();
                DBHelper.CIS.FromSql(string.Format("UPDATE GHBRZL SET YSBM=(CASE WHEN YSBM IS NULL OR RTRIM(YSBM)='' THEN '{0}' ELSE YSBM END),YSXM=(CASE WHEN YSXM IS NULL OR RTRIM(YSXM)='' THEN '{1}' ELSE YSXM END) WHERE JZH='{2}'", SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.GetCurrPatient.OutpatientNo)).ExecuteNonQuery();
                if (diagnosis.IsMain == 1)
                {
                    var sql = string.Format(" UPDATE GHBRZL SET ILL_CODE='{0}',ILL_NAME='{1}' WHERE JZH='{2}'", diagnosis.Code, diagnosis.Name, SysContext.GetCurrPatient.OutpatientNo);
                    DBHelper.CIS.FromSql(sql).ExecuteNonQuery();
                }
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(this.dgvZDDetail.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_KEYDOWN, e.KeyValue, 0);
            }
        }

        /// <summary>
        /// 组装病人的诊断信息
        /// </summary>
        /// <param name="Code">ICD码</param>
        /// <param name="Name">诊断名称</param>
        /// <param name="Status">是否确诊</param>
        /// <param name="IsMain">是否主诊断</param>
        /// <param name="ID">诊断ID</param>
        /// <returns></returns>
        private OP_PatientDiagnosis InitPatientDiagnosis(string Code, string Name, int Status, string IsHMDiagnosis, bool IsMain, out string ID)
        {
            OP_PatientDiagnosis diagnosis = new OP_PatientDiagnosis();
            diagnosis.Code = Code;
            diagnosis.DeptCode = SysContext.RunSysInfo.currDept.Code;
            diagnosis.ID = Guid.NewGuid().ToString();
            diagnosis.IsMain = Convert.ToInt32(IsMain);
            diagnosis.Name = Name;
            diagnosis.PatientID = ((SysContext.Session[SysContext.Session_CurrPatient] as IView_HIS_Outpatients).PatientID ?? "").ToString();
            diagnosis.Status = Status;
            diagnosis.TreatmentNo = (SysContext.Session[SysContext.Session_CurrPatient] as IView_HIS_Outpatients).OutpatientNo.ToString();
            diagnosis.Updater = SysContext.RunSysInfo.user.Name;
            diagnosis.UpdateTime = DateTime.Now;
            diagnosis.IsHMDiagnosis = IsHMDiagnosis == "ICD" ? 0 : 1;
            diagnosis.Type = IsHMDiagnosis == "HMDiagnosis" ? 0 : IsHMDiagnosis == "HMSymptom" ? 1 : 2;
            diagnosis.DoctorCode = SysContext.CurrUser.user.Code;
            diagnosis.PatientName = SysContext.GetCurrPatient.PatientName;
            int count = this.dgvZD.PrimaryGrid.Rows.Where(p => (p as GridRow).Cells["Type"].Value.AsString("") == diagnosis.Type.ToString()).Count();

            diagnosis.Index = count + 1;
            ID = diagnosis.ID;
            return diagnosis;
        }

        private void dgvZD_CellClick(object sender, GridCellClickEventArgs e)
        {
            if (e.GridCell.GridColumn.Name == "IsMain")
            {
                foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
                {
                    item.Cells["IsMain"].Value = false;
                }

                e.GridCell.Value = true;
                var name = e.GridCell.GridRow.Cells["ZDMC"].Value.AsString();
                var code = e.GridCell.GridRow.Cells["ICD"].Value.AsString();

                string sql = string.Format("UPDATE OP_PatientDiagnosis SET ISMAIN=0 WHERE TreatmentNo='{0}'", SysContext.GetCurrPatient.OutpatientNo);
                DBHelper.CIS.FromSql(sql).ExecuteNonQuery();

                sql = string.Format(" UPDATE OP_PatientDiagnosis SET ISMAIN=1 WHERE ID='{0}'", e.GridCell.GridRow.Cells["ID"].Value.ToString());
                DBHelper.CIS.FromSql(sql).ExecuteNonQuery();

                if (name != null || code != null)
                {
                    sql = string.Format(" UPDATE GHBRZL SET ILL_CODE='{0}',ILL_NAME='{1}' WHERE JZH='{2}'", code, name, SysContext.GetCurrPatient.OutpatientNo);
                    DBHelper.CIS.FromSql(sql).ExecuteNonQuery();
                }
            }
        }

        private void dgvZD_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            if (e.GridCell.GridColumn.Name == "Status")
            {
                DBHelper.CIS.FromSql(string.Format("UPDATE OP_PatientDiagnosis SET STATUS={0} WHERE ID='{1}'", e.NewValue.AsInt(0), e.GridCell.GridRow.Cells["ID"].Value.ToString())).ExecuteNonQuery();

                var name = e.GridCell.GridRow.Cells["ZDMC"].Value.AsString();
                var code = e.GridCell.GridRow.Cells["ICD"].Value.AsString();


            }
        }

        private void btnDelDiagnosis_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = this.dgvZD.GetSelectedRows();
            if (!CheckZD(rows))
            {
                return;
            }

            if (rows.Count > 0)
            {
                List<GridRow> list = new List<GridRow>();
                foreach (GridRow item in rows)
                {
                    list.Add(item);
                }

                foreach (GridRow item in list)
                {
                    string ICD = item.Cells["ICD"].Value.ToString();
                    foreach (GridRow item1 in this.dgvChronic.PrimaryGrid.Rows)
                    {
                        if (item1.Cells["MXB_Code"].Value.ToString() == ICD)
                        {
                            item1.Cells["MXB_Select"].Value = false;
                        }
                    }
                    var data = DBHelper.CIS.Delete<OP_PatientDiagnosis>(p => p.ID == item.Cells["ID"].Value.ToString());
                    CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("删除诊断", SerializeHelper.BeginJsonSerializable(item.Cells["ID"].Value.ToString()), data > 0 ? "删除诊断成功！" : "删除诊断失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
                    this.dgvZD.PrimaryGrid.Rows.Remove(item);
                }
            }
            dgvZD_RowDeleted();
            formPrescription.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            formLisRequisition.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            formPacsRequisition.CurrentDiagnosisCount = this.dgvZD.PrimaryGrid.Rows.Count;
            InsertDiagnosisInRecord();
        }

        private bool CheckZD(SelectedElementCollection select)
        {
            if (this.dgvPrescription.PrimaryGrid.Rows.Count > 0 && select.Count == this.dgvZD.PrimaryGrid.Rows.Count)
            {
                AlertBox.Info("您已经开过处方,无法删除所有诊断");
                return false;
            }
            bool hasHMPrescription = false;
            foreach (GridRow item in this.dgvPrescription.PrimaryGrid.Rows)
            {
                if (item.Cells["col_PrescriptionType"].Value.ToString() == "2")
                {
                    hasHMPrescription = true;
                }
            }
            int hasHMNum = 0;
            foreach (GridRow item in select)
            {
                if (item.Cells["Type"].Value.AsString("1") != "2")
                {
                    hasHMNum++;
                }
            }
            foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
            {
                if (item.Cells["Type"].Value.AsString("1") != "2")
                {
                    hasHMNum--;
                }
            }
            if (hasHMPrescription && hasHMNum == 0)
            {
                AlertBox.Info("您已经开过中药,无法删除中医诊断");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获得当前病人的诊断数量
        /// </summary>
        /// <returns></returns>
        public int GetDiagnosisNumber()
        {
            return this.dgvZD.PrimaryGrid.Rows.Count;
        }
        #endregion

        #region 处方操作
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!CheckSave()) return;
            SelectedElementCollection selectRows = this.dgvPrescription.PrimaryGrid.GetSelectedRows();
            int count = this.dgvPrescription.PrimaryGrid.Rows.Count;
            foreach (GridRow item in selectRows)
            {
                Print.PrescriptionPrint(item.Cells["col_ItemCode"].Value.ToString(), item.Cells["col_PrescriptionType"].Value.ToString(), item.Cells["col_HISInterface_PrescriptionNo"].Value.ToString(), true);
            }
        }

        private bool CheckSave()
        {
            List<OP_PatientDiagnosis> tmp = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo).ToList();
            foreach (OP_PatientDiagnosis item in tmp)
            {
                if (item.Type != 2)
                {
                    continue;
                }
                var specialType = item.SpecialType;
                var ICD = item.Code;
                var Name = item.Name;
                if (specialType == null || specialType.Trim() == "")
                    continue;
                if (specialType.Trim().Substring(0, 1) == "1") //如果是慢病
                {
                    int flag = 0;//0不调用 1调用慢性病报卡 2调用慢阻病报卡
                    if (specialType == "11")
                    {
                        var count = DBHelper.HNIMIS.FromSql($"select count(*) from Card_Mxb_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}' and hisxm='{SysContext.GetCurrPatient.PatientName}' and zllx is not null and czjc<>'f' and left(zlbm,3)='{ICD.Substring(0, 3)}'").ToScalar<int>();
                        if (count == 0)
                            flag = 1;
                    }
                    else if (specialType == "12")
                    {
                        var count = DBHelper.HNIMIS.FromSql($"select count(*) from Card_Mxb_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}' and hisxm='{SysContext.GetCurrPatient.PatientName}' and gxblx<>'00' and czjc<>'f'").ToScalar<int>();
                        if (count == 0)
                            flag = 1;
                    }
                    else if (specialType == "13")
                    {
                        var count = DBHelper.HNIMIS.FromSql($"select count(*) from Card_Mxb_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}' and hisxm='{SysContext.GetCurrPatient.PatientName}' and nczlx<>'00' and czjc<>'f' and czrq>'{SysContext.GetCurrPatient.RegisterTime.AddDays(-28)}'").ToScalar<int>();
                        if (count == 0)
                            flag = 1;
                    }
                    else if (specialType == "14")
                    {
                        var count = DBHelper.HNIMIS.FromSql($"select count(*) from MZF_INTERFACE where sfzh='{SysContext.GetCurrPatient.IDCard}' and brxm='{SysContext.GetCurrPatient.PatientName}' and czjc<>'f'").ToScalar<int>();
                        if (count == 0)
                            flag = 2;
                    }
                    if (flag == 1)
                    {
                        Infect.Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "15");
                        return false;
                    }
                    else if (flag == 2)
                    {
                        Infect.Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "16");
                        return false;
                    }
                }
                else if (specialType.Trim() == "2") //如果是传染病
                {
                    var count = DBHelper.HNIMIS.FromSql($"select count(*) from Card_infect_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}'").ToScalar<int>();
                    if (count == 0)
                    {
                        Infect.Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "0");
                        return false;
                    }
                }

            }

            return true;
        }

        private void btnNormalPrint_Click(object sender, EventArgs e)
        {
            SelectedElementCollection selectRows = this.dgvPrescription.PrimaryGrid.GetSelectedRows();
            foreach (GridRow item in selectRows)
            {
                Print.PrescriptionPrint(item.Cells["col_ItemCode"].Value.ToString(), item.Cells["col_PrescriptionType"].Value.ToString(), item.Cells["col_HISInterface_PrescriptionNo"].Value.ToString(), true);
            }
        }

        private void btnSpecialPrint_Click(object sender, EventArgs e)
        {
            SelectedElementCollection selectRows = this.dgvPrescription.PrimaryGrid.GetSelectedRows();
            foreach (GridRow item in selectRows)
            {
                Print.PrescriptionPrint(item.Cells["col_ItemCode"].Value.ToString(), item.Cells["col_PrescriptionType"].Value.ToString(), item.Cells["col_HISInterface_PrescriptionNo"].Value.ToString(), true, true);
            }
        }

        private void dgvPrescription_RowMouseEnter(object sender, GridRowEventArgs e)
        {
            string ItemCode = (e.GridRow as GridRow).Cells["col_ItemCode"].Value.ToString();
            List<string> prescriptionList = Prescription_Detail.Where(p => p.PrescriptionNo == ItemCode).Select(p => p.ItemName).ToList();
            Point P = this.dgvPrescription.PointToClient(MousePosition);
            this.toolTip1.Show(string.Join(Environment.NewLine, prescriptionList.ToArray()), this.dgvPrescription, P.X + 5, P.Y + 5, 2000);



        }
        private void btnDelPrescription_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = this.dgvPrescription.GetSelectedRows();
            foreach (GridRow item in rows)
            {
                string ID = item.Cells["col_ID"].Value.ToString();
                string ItemCode = item.Cells["col_ItemCode"].Value.ToString();
                OP_Prescription tmp = DBHelper.CIS.From<OP_Prescription>().Where(p => p.ID == ID).First();
                if (tmp == null)
                {
                    InitPrescription();
                    return;
                }
                if (tmp.Status != 0)
                {
                    AlertBox.Info("该处方已更新状态,无法操作");
                    InitPrescription();
                    return;
                }
                if (DBHelper.CIS.Delete<OP_Prescription>(p => p.ID == ID) > 0)
                {
                    if (DBHelper.CIS.Delete<OP_Prescription_Detail>(p => p.PrescriptionNo == ItemCode) > 0)
                    {
                        this.dgvPrescription.PrimaryGrid.Rows.Remove(item);
                        CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("删除处方明细", "处方编号:" + ItemCode, "删除处方明细成功！"), Log4NetLevel.Info);
                    }
                    else
                    {
                        CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("删除处方明细", "处方编号:" + ItemCode, "删除处方明细失败！"), Log4NetLevel.Error);
                    }
                    CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("删除处方", "处方ID" + ID, "删除处方成功！"), Log4NetLevel.Info);
                }
                else
                {
                    CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("删除处方", "处方ID" + ID, "删除处方失败！"), Log4NetLevel.Error);
                }
            }
            this.formLisRequisition.InitUI();
            this.formPacsRequisition.InitUI();
            this.formPrescription.InitUI();
        }
        private void btnUndoPrescription_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = this.dgvPrescription.GetSelectedRows();
            var prescriptionNos = rows.Cast<GridRow>().Select(p => p.Cells["col_ItemCode"].Value.ToString()).ToList();
            var prescriptions = DBHelper.CIS.From<OP_Prescription>().Where(p => p.PrescriptionNo.In(prescriptionNos)).ToList();

            var successPrescription = new List<OP_Prescription>();

            foreach (GridRow item in rows)
            {
                string ID = item.Cells["col_ID"].Value.ToString();
                string prescriptionNo = item.Cells["col_ItemCode"].Value.ToString();
                string prescriptionType = item.Cells["col_PrescriptionType"].Value.ToString();
                var prescription = prescriptions.FirstOrDefault(p => p.PrescriptionNo == prescriptionNo);
                var status = prescription.Status.AsString();
                string DoctorCode = item.Cells["col_DoctorCode"].Value.ToString();
                if (DoctorCode != SysContext.CurrUser.user.Code)
                {
                    AlertBox.Error(string.Format("第{0}条处方召回失败,该处方不是您开具的", item.Index + 1), 3);
                    continue;
                }
                if (status == "2" || status == "3")
                {
                    AlertBox.Error(string.Format("第{0}条处方召回失败,可能已经收费或者退费", item.Index + 1), 3);
                    continue;
                }
                //int? status = DBHelper.CIS.From<OP_Prescription>().Where(p => p.ID == ID).First().Status;
                if (status == "1")
                {
                    var DataStatus = DBHelper.CIS.FromSql(string.Format("UPDATE OP_Prescription SET STATUS=0 WHERE ID='{0}'", ID)).ExecuteNonQuery();
                    if (DataStatus > 0)
                        successPrescription.Add(prescription);

                    var data = DBHelper.CIS.Delete<OP_Prescription_Chronic>(p => p.PrescriptionCode == prescriptionNo);
                    List<OP_Prescription_Detail> detail = Prescription_Detail.Where(p => p.PrescriptionNo == prescriptionNo).ToList();
                }
                if (item.Cells["col_PrescriptionType"].Value.ToString() == "9")
                {
                    this.formPrescription.dgvDiagnose.Rows.Clear();
                }
                else if (item.Cells["col_PrescriptionType"].Value.ToString() == "2")
                {
                    this.formPrescription.dgvHerbalMedicine.Rows.Clear();
                }
                else if (item.Cells["col_PrescriptionType"].Value.ToString() == "11")
                {
                    this.formLisRequisition.InitUI();
                }
                else if (item.Cells["col_PrescriptionType"].Value.ToString() == "12")
                {
                    this.formPacsRequisition.InitUI();
                }
                else
                {
                    this.formPrescription.dgvWesternMedicine.Rows.Clear();
                }
            }

            //if (successPrescription.Any(p => !string.IsNullOrWhiteSpace(p.PrescriptionCirculation_PrescriptionNo)))
            //{
            //    UndoPrescriptionHelper helper = new UndoPrescriptionHelper();
            //    FormPrescriptionCirculationUndo form = new FormPrescriptionCirculationUndo();
            //    if (form.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(form.Reason))
            //    {
            //        foreach (var prescription in successPrescription)
            //        {
            //            if (!string.IsNullOrWhiteSpace(prescription.PrescriptionCirculation_PrescriptionNo))
            //                helper.Handler(prescription, form.Reason);
            //        }
            //    }
            //}


            InitPrescription();
        }
        private void dgvPrescription_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            GridRow row = e.GridRow as GridRow;
            OP_Prescription prescription = row.DataItem as OP_Prescription;
            if (Convert.ToInt32(prescription.PrescriptionType) < 10)
            {
                tabMain.SelectedTab = tabMain.Tabs["处方"] as SuperTabItem;//选中处方
                formPrescription.CurrentPrescriptionNo = prescription.PrescriptionNo;
                formPrescription.CurrPatientPrescriptionDetail = Prescription_Detail;
                formPrescription.CurrPatientPrescription = prescription;
                formPrescription.InitCFFromItemCode();
            }
            if (prescription.PrescriptionType == "11")
            {
                tabMain.SelectedTab = tabMain.Tabs["检验"] as SuperTabItem; //选中检验
                formLisRequisition.currPrescription = prescription;
                formLisRequisition.hasList = Prescription_Detail;
                formLisRequisition.InitPrescription();
            }
            if (prescription.PrescriptionType == "12")
            {
                tabMain.SelectedTab = tabMain.Tabs["检查"] as SuperTabItem;//选中检查
                formPacsRequisition.currPrescription = prescription;
                formPacsRequisition.hasList = Prescription_Detail;
                formPacsRequisition.InitPrescription();
            }

        }

        //private struct MatchFieldPairType
        //{
        //    public IGRField grField;
        //    public int MatchColumnIndex;
        //}

        //private void FillRecordToReport(IGridppReport Report, DataTable dt)
        //{
        //    MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

        //    //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
        //    int MatchFieldCount = 0;
        //    for (int i = 0; i < dt.Columns.Count; ++i)
        //    {
        //        foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
        //        {
        //            if (String.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
        //            {
        //                MatchFieldPairs[MatchFieldCount].grField = fld;
        //                MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
        //                ++MatchFieldCount;
        //                break;
        //            }
        //        }
        //    }
        //    Report.PrepareRecordset();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        //Report.PrepareRecordset();
        //        Report.DetailGrid.Recordset.Append();

        //        for (int i = 0; i < MatchFieldCount; ++i)
        //        {
        //            if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
        //                MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
        //        }
        //        Report.DetailGrid.Recordset.Post();
        //    }
        //}

        private void 打印选中处方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedElementCollection selectRows = this.dgvPrescription.PrimaryGrid.GetSelectedRows();
            foreach (GridRow item in selectRows)
            {
                Print.PrescriptionPrint(item.Cells["col_ItemCode"].Value.ToString(), item.Cells["col_PrescriptionType"].Value.ToString(), item.Cells["col_HISInterface_PrescriptionNo"].Value.ToString());
            }
        }

        private void 打印膏方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedElementCollection selectRows = this.dgvPrescription.PrimaryGrid.GetSelectedRows();
            foreach (GridRow item in selectRows)
            {
                Print.PrescriptionPrint(item.Cells["col_ItemCode"].Value.ToString(), item.Cells["col_PrescriptionType"].Value.ToString(), item.Cells["col_HISInterface_PrescriptionNo"].Value.ToString(), true, true);
            }
        }
        private void 预览选中处方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedElementCollection selectRows = this.dgvPrescription.PrimaryGrid.GetSelectedRows();
            foreach (GridRow item in selectRows)
            {
                Print.PrescriptionPrint(item.Cells["col_ItemCode"].Value.ToString(), item.Cells["col_PrescriptionType"].Value.ToString(), item.Cells["col_HISInterface_PrescriptionNo"].Value.ToString(), true);
            }
        }
        private void 召回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnUndoPrescription_Click(null, null);
        }
        private void 删除选中处方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnDelPrescription_Click(null, null);
        }
        #endregion

        #region 病历操作
        /// <summary>
        /// 将诊断插入到病历内
        /// </summary>
        private void InsertDiagnosisInRecord()
        {
            List<string> zd = BuildDiagnosisString("WM");
            List<string> zd1 = BuildDiagnosisString("HM");
            formRecord.InsertDiagnosisInRecord(string.Join(Environment.NewLine, zd.ToArray()), true);
            formRecord.InsertDiagnosisInRecord(string.Join(Environment.NewLine, zd1.ToArray()), false);
            formPrescription.CurrentDiagnosisName = string.Join(";", zd.ToArray());
        }

        private List<string> BuildDiagnosisString(string IsHM)
        {
            List<string> zd = new List<string>();
            foreach (GridRow item in dgvZD.PrimaryGrid.Rows)
            {
                if (IsHM == "HM")
                {
                    if (item.Cells["IsHMDiagnosis"].Value.AsString("") == "1")
                    {
                        if (Convert.ToBoolean(item.Cells["IsMain"].Value))
                        {
                            zd.Insert(0, item.Cells["ZDMC"].Value.ToString() + (item.Cells["Status"].Value.ToString() == "2" ? " 待查" : ""));
                        }
                        else
                        {
                            zd.Add(item.Cells["ZDMC"].Value.ToString() + (item.Cells["Status"].Value.ToString() == "2" ? " 待查" : ""));
                        }
                    }
                }
                else if (IsHM == "WM")
                {
                    if (item.Cells["IsHMDiagnosis"].Value.AsString("") != "1")
                    {
                        if (Convert.ToBoolean(item.Cells["IsMain"].Value))
                        {
                            zd.Insert(0, item.Cells["ZDMC"].Value.ToString() + (item.Cells["Status"].Value.ToString() == "2" ? " 待查" : ""));
                        }
                        else
                        {
                            zd.Add(item.Cells["ZDMC"].Value.ToString() + (item.Cells["Status"].Value.ToString() == "2" ? " 待查" : ""));
                        }
                    }
                }
                else
                {
                    if (Convert.ToBoolean(item.Cells["IsMain"].Value))
                    {
                        zd.Insert(0, item.Cells["ZDMC"].Value.ToString() + (item.Cells["Status"].Value.ToString() == "2" ? " 待查" : ""));
                    }
                    else
                    {
                        zd.Add(item.Cells["ZDMC"].Value.ToString() + (item.Cells["Status"].Value.ToString() == "2" ? " 待查" : ""));
                    }
                }
            }
            return zd;
        }

        #endregion

        #region 外部事件接口
        /// <summary>
        /// 外部事件接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleRefreshPatient(PatientEventArgs e)
        {
            if (e.Mode == PatientEventArgs.UpdateMode.Prescription)
            {
                RefreshPrescription();
            }
            else if (e.Mode == PatientEventArgs.UpdateMode.ImportLISResult)
            {
                this.formRecord.ImportLISResult(e.Data.ToString());
            }
            else if (e.Mode == PatientEventArgs.UpdateMode.ImportDrugInfoToRecord)
            {
                ImportDrugInfoToRecord();
            }
            else if (e.Mode == PatientEventArgs.UpdateMode.ImportPresentIllness)
            {
                string str = formRecord.GetPresentIllness();
                formPacsRequisition.ImportPresentIllness(str);
            }
            else if (e.Mode == PatientEventArgs.UpdateMode.GetHMDiagnosis)
            {
                foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
                {
                    if (item.Cells["IsHMDiagnosis"].Value.AsString("") == "1")
                    {
                        formPrescription.HasHMDiagnosis = "1";
                        return;
                    }
                }
            }
            else if (e.Mode == PatientEventArgs.UpdateMode.ImportXMLToRecode)
            {
                formRecord.ImportXMLToRecord(e.Data.ToString());
            }
            else if (e.Mode == PatientEventArgs.UpdateMode.ShowInfection)
            {
                foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
                {
                    Infect.CheckInfection(item.Cells["ZDMC"].Value.ToString(), item.Cells["ICD"].Value.ToString());
                }
            }
            else if (e.Mode == PatientEventArgs.UpdateMode.ShowChronic)
            {
                foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
                {
                    Infect.CheckChronicFirstCome(item.Cells["ZDMC"].Value.ToString(), item.Cells["ICD"].Value.ToString());
                }
            }
            else if (e.Mode == PatientEventArgs.UpdateMode.ShowMZ)
            {
                foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
                {
                    Infect.CheckMZ(item.Cells["ZDMC"].Value.ToString(), item.Cells["ICD"].Value.ToString());
                }
            }
            else if (e.Mode == PatientEventArgs.UpdateMode.Diagnosis)
            {

            }
        }
        public List<OP_PatientDiagnosis> GEtDiagnosis()
        {
            return this.dgvZD.PrimaryGrid.Rows.Cast<GridRow>().Select(p => p.Tag as OP_PatientDiagnosis).ToList();
        }

        public bool GetRecordHasPersonel()
        {
            return this.formRecord.HasPersonel();
        }
        private void RefreshPrescription()
        {
            InitPrescription();
            string Diagnosis = "";
            foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
            {
                if (Convert.ToBoolean(item.Cells["IsMain"].Value))
                {
                    Diagnosis = item.Cells["ZDMC"].Value.ToString();
                }
            }
        }

        private void ImportDrugInfoToRecord()
        {
            if (SysContext.GetCurrPatient == null)
            {
                AlertBox.Info("还未选择患者,请先选择患者");
                return;
            }
            List<OP_Prescription> prescription = new List<OP_Prescription>();

            FormSelectDealWith formSelectDealWith = new FormSelectDealWith();
            if (formSelectDealWith.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            else
            {
                prescription = formSelectDealWith.result;
            }

            List<OP_Prescription> WesternMedicine = prescription.Where(p => p.PrescriptionType != "2" && p.PrescriptionType != "11" && p.PrescriptionType != "12" && p.PrescriptionType != "9").ToList();
            List<OP_Prescription> HerbalMedicine = prescription.Where(p => p.PrescriptionType == "2").ToList();
            List<OP_Prescription> inspection = prescription.Where(p => p.PrescriptionType == "11" || p.PrescriptionType == "12").ToList();
            List<OP_Prescription> Item = prescription.Where(p => p.PrescriptionType == "9").ToList();

            formRecord.ClearDiagnosis();
            WesternMedicine = WesternMedicine.OrderBy(p => p.UpdateTime).ToList();
            HerbalMedicine = HerbalMedicine.OrderBy(p => p.UpdateTime).ToList();
            Item = Item.OrderBy(p => p.UpdateTime).ToList();

            inspection = inspection.OrderByDescending(p => p.PrescriptionType).ThenBy(p => p.UpdateTime).ToList();

            foreach (OP_Prescription item in inspection)
            {
                DataTable tmp = Print.BuildPrescription(item.PrescriptionNo, item.TreatmentNo, item.PrescriptionType, "");
                formRecord.ImportDrugInfo(tmp, "1");
            }
            foreach (OP_Prescription item in HerbalMedicine)
            {
                DataTable tmp = Print.BuildPrescription(item.PrescriptionNo, item.TreatmentNo, item.PrescriptionType, "");
                formRecord.ImportDrugInfo(tmp, "2");
            }
            foreach (OP_Prescription item in WesternMedicine)
            {
                DataTable tmp = Print.BuildPrescription(item.PrescriptionNo, item.TreatmentNo, item.PrescriptionType, "");
                formRecord.ImportDrugInfo(tmp, "3");
            }
            foreach (OP_Prescription item in Item)
            {
                DataTable tmp = Print.BuildPrescription(item.PrescriptionNo, item.TreatmentNo, item.PrescriptionType, "");
                formRecord.ImportDrugInfo(tmp, "4");
            }
        }

        public List<OP_Prescription_Detail> GetPrescriptionDetail { get { return Prescription_Detail; } }
        #endregion

        #region 慢性病操作
        private bool selectTmp;
        private void dgvChronic_CellMouseUp(object sender, GridCellMouseEventArgs e)
        {
            if (e.GridCell.GridColumn.Name == "MXB_Select")
            {
                if (e.GridCell.Value == null || selectTmp == (bool)(e.GridCell.Value ?? false))
                {
                    return;
                }

                ClearChronicFromDiagnosis();
                if (!(bool)e.GridCell.Value)
                {
                    formPrescription.ChronicCode = "";
                    formPrescription.ChronicName = "";
                    formPrescription.ChronicType = "";
                    return;
                }
                foreach (GridRow item in this.dgvChronic.PrimaryGrid.Rows)
                {
                    item.Cells["MXB_Select"].Value = false;
                }

                e.GridCell.Value = true;

                formPrescription.ChronicCode = e.GridCell.GridRow.Cells["MXB_Code"].Value.ToString();
                formPrescription.ChronicName = e.GridCell.GridRow.Cells["MXB_Name"].Value.ToString();
                formPrescription.ChronicType = e.GridCell.GridRow.Cells["MXB_Type"].Value.ToString();

                //InsertChronicToDiagnosis();
            }
        }
        private void dgvChronic_CellMouseDown(object sender, GridCellMouseEventArgs e)
        {
            //List<OP_Prescription_Detail> detail = DBHelper.CIS.From<OP_Prescription_Detail>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo && p.ItemType.In("1", "2", "3")).ToList();
            //if (detail.Count > 0)
            //{
            //    MessageBox.Show("您已经给当前病人下过处方,无法在进行慢性病的操作" + Environment.NewLine + "如果想选择当前慢性病,请将之前的药品处方全部删除后在操作");
            //    return;
            //}

            if (e.GridCell.GridColumn.Name == "MXB_Select")
            {
                selectTmp = (bool)(e.GridCell.Value ?? false);
            }
        }
        private void InsertChronicToDiagnosis()
        {
            //bool HasMain = true;
            //foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
            //{
            //    if (item.Cells["IsMain"].Value.AsBoolean())
            //        HasMain = false;
            //}
            //OP_PatientDiagnosis diagnosis;
            //string ID;

            //diagnosis = InitPatientDiagnosis(formPrescription.ChronicCode, formPrescription.ChronicName, 1, HasMain, out ID);

            //if (DBHelper.CIS.Insert<OP_PatientDiagnosis>(diagnosis) > 0)
            //{
            //    object[] obj = new object[] { ID, formPrescription.ChronicName, "1", HasMain, formPrescription.ChronicCode };
            //    GridRow row = new GridRow(obj);
            //    this.dgvZD.PrimaryGrid.Rows.Add(row);
            //    this.dgvZDDetail.Hide();
            //    this.tbxZDFilter.Clear();
            //    dgvZD_RowAdded();
            //}
        }
        private void ClearChronicFromDiagnosis()
        {
            string ChronicCode = formPrescription.ChronicCode;
            string PatientID = (SysContext.Session[SysContext.Session_CurrPatient] as IView_HIS_Outpatients).PatientID.ToString();

            DBHelper.CIS.Delete<OP_PatientDiagnosis>(p => p.PatientID == PatientID && p.Code == ChronicCode);
            foreach (GridRow item in this.dgvZD.PrimaryGrid.Rows)
            {
                if (item.Cells["ICD"].Value.ToString() == ChronicCode)
                {
                    this.dgvZD.PrimaryGrid.Rows.Remove(item);
                    dgvZD_RowDeleted();
                    return;
                }
            }
        }
        #endregion

        #region 窗体事件

        private void tabMain_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (SysContext.CurrUser.roleList.Find(p => p.Code == "hs") == null && e.EventSource == eEventSource.Mouse && this.tabMain.SelectedTab == this.tabMain.Tabs["检查"])
            {
                string str = formRecord.GetPresentIllness();
                formPacsRequisition.ImportPresentIllness(str);
            }

            if (e.EventSource == eEventSource.Mouse && this.tabMain.SelectedTab == this.tabMain.Tabs["报卡"])
            {
                this.pnlRight.Hide();
            }
            else
            {
                this.pnlRight.Show();
            }
        }

        private void SplitterBottom_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (SysContext.UserPositionSetting == null)
            {
                SysContext.UserPositionSetting = new UserPositionSetting();
            }

            SysContext.UserPositionSetting.PatientInfoPosition = this.dgvZD.Height;
        }

        private void btnCallPatient_Click(object sender, EventArgs e)
        {
            if (SysContext.GetCurrPatient == null)
            {
                AlertBox.Info("未选择病人无法叫号");
                return;
            }
            if (SysContext.RunSysInfo.clinic == null)
            {
                AlertBox.Info("未选择诊区信息,无法叫号");
                return;
            }

            //HMSocket.SocketClient HMSocket = new HMSocket.SocketClient();
            List<IView_HIS_Outpatients> list = DBHelper.CIS.From<IView_HIS_Outpatients>().Where(p => p.RegisterTime >= DateTime.Parse(DateTime.Now.ToShortDateString()) && p.RegisterNo > SysContext.GetCurrPatient.RegisterNo && p.DeptCode == SysContext.RunSysInfo.currDept.Code && p.State == "0").OrderBy(p => p.RegisterNo).Top(2).ToList();
            string tmp;
            if (list.Count == 2)
            {
                tmp = string.Format("{0}({1})&{2}({3})", list[0].RegisterNo, list[0].PatientName, list[1].RegisterNo, list[1].PatientName);
            }
            else if (list.Count == 1)
            {
                tmp = string.Format("{0}({1})", list[0].RegisterNo, list[0].PatientName);
            }
            else
            {
                tmp = "";
            }

            string str = string.Format("P|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.clinic.ClinicCode, SysContext.RunSysInfo.currDept.Name, SysContext.GetCurrPatient.RegisterNo, SysContext.GetCurrPatient.PatientName, tmp, SysContext.RunSysInfo.clinic.ClinicName);
            CIS.Utility.LogHelper.Debug("排队叫号接口叫号：" + str, "排队叫号接口", new System.IO.DirectoryInfo(Application.StartupPath).Parent.FullName + @"\门诊医生Log\");
            if (SysContext.HMSocket.InsertData(SysContext.RunSysInfo.clinic.ClinicCode, str) != 1)
            {
                AlertBox.Error("叫号失败,叫号接口调用失败");
            }
        }

        public void AddPrescriptionCirculationTask()
        {
            _prescriptionCirculationCount++;
            this.expandablePanel1.TitleText = "已开处方信息" + $"({_prescriptionCirculationCount}份正在上传)";
        }

        public void RemovePrescriptionCirculationTask()
        {
            _prescriptionCirculationCount--;
            if (_prescriptionCirculationCount == 0)
                this.expandablePanel1.TitleText = "已开处方信息";
            else
                this.expandablePanel1.TitleText = "已开处方信息" + $"({_prescriptionCirculationCount}份正在上传)";
        }
        #endregion

        private void btnSEMR_Click(object sender, EventArgs e)
        {
            if (SysContext.GetCurrPatient == null)
            {
                MessageBox.Show("当前没有选择病人");
                return;
            }
            if (SysContext.GetCurrPatient.DeptCode == "21000500")
            {
                if (SysContext.GetCurrPatient.IDCard == null || SysContext.GetCurrPatient.IDCard == "")
                {
                    MessageBox.Show("当前病人没有身份证号,无法使用专科病历,请先填写");
                    FormWriteJournal form = new FormWriteJournal();
                    form.currPatient = SysContext.GetCurrPatient;
                    form.ShowDialog();
                    return;
                }

                SEMRRecord.CallSEMRRecord(SysContext.CurrUser.user.Code, SysContext.GetCurrPatient.RegisterTime.ToShortDateString(), SysContext.GetCurrPatient.OutpatientNo, SysContext.GetCurrPatient.PatientName, SysContext.GetCurrPatient.Birthday.AsDateTime(DateTime.Now).ToShortDateString());
            }
        }

        private void stripCopyPrescription_Click(object sender, EventArgs e)
        {
            if (SysContext.GetCurrPatient == null)
            {
                MessageBox.Show("当前没有选择病人");
                return;
            }

            SelectedElementCollection selectRows = this.dgvPrescription.PrimaryGrid.GetSelectedRows();
            if (selectRows.Count == 0)
            {
                MessageBox.Show("未选择处方");
                return;
            }

            var selectedRow = selectRows[0] as GridRow;
            OP_Prescription prescription = selectedRow.DataItem as OP_Prescription;
            if (Convert.ToInt32(prescription.PrescriptionType) < 10)
            {
                tabMain.SelectedTab = tabMain.Tabs["处方"] as SuperTabItem;//选中处方
                formPrescription.CurrPatientPrescriptionDetail = Prescription_Detail;
                formPrescription.CopyPrescription(prescription);
            }
            if (prescription.PrescriptionType == "11")
            {
                tabMain.SelectedTab = tabMain.Tabs["检验"] as SuperTabItem; //选中检验
                formLisRequisition.hasList = Prescription_Detail;
                formLisRequisition.CopyPrescription(prescription);
            }
            if (prescription.PrescriptionType == "12")
            {
                tabMain.SelectedTab = tabMain.Tabs["检查"] as SuperTabItem;//选中检查
                formPacsRequisition.hasList = Prescription_Detail;
                formPacsRequisition.CopyPrescription(prescription);
            }

            //var prescriptionNo = selectedRow.Cells["col_ItemCode"].Value.ToString();

            //var result = DBHelper.CIS.FromProc("Proc_OP_CopyPrescription")
            //.AddInParameter("PrescriptionNo", DbType.String, prescriptionNo)
            //.AddInParameter("TreatmentNo", DbType.String, SysContext.GetCurrPatient.OutpatientNo)
            //.ToDataTable();

            //if (result.Rows.Count > 0)
            //{
            //    if(result.Rows[0][0].ToString()=="0")
            //        MessageBox.Show(result.Rows[0][1].ToString());
            //    else
            //        InitPrescription();
            //}
        }

        private void btnIPRecordView_Click(object sender, EventArgs e)
        {
            if (SysContext.GetCurrPatient == null)
            {
                AlertBox.Info("请先选择病人");
                return;
            }

            Process.Start($"http://192.168.1.203:8100/#/lcBlviewer?orgCode=485124457&idCard={SysContext.GetCurrPatient.IDCard}");
        }

        private void btnExistsEmergency_Click(object sender, EventArgs e)
        {
            FormEmergency formEmergency = new FormEmergency();
            formEmergency.Init(_emergency);
            formEmergency.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            var dt = DBHelper.CIS.FromSql($"select * from v_zyinfo where 身份证号='{SysContext.GetCurrPatient.IDCard}'").ToDataTable();

            if (dt.Rows.Count == 0)
            {
                AlertBox.Info("未找到该病人的住院信息");
                return;
            }

            var row = dt.Rows[0];

            var url = $"http://192.168.1.216:8089/Emr/ViewFrom?PatientID={row["住院号"]}&VisitID={row["住院次数"]}&MrClass=ALL&StartDate={row["入院时间"]}&EndDate={row["出院时间"]}";
            Process.Start(url);
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (SysContext.GetCurrPatient == null)
            {
                AlertBox.Info("请先选择病人");
                return;
            }

            Process.Start($"http://192.168.0.221/#/print?code=CARE_DOCUMENT&sort=1&wardCode=22001300&timePoint=2022-08-23&idCard={SysContext.GetCurrPatient.IDCard}");
        }

        private void 查看双流转处方信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var selectedRows = this.dgvPrescription.GetSelectedRows();
            //if (selectedRows.Count == 0)
            //    return;

            //var selectedRow = selectedRows[0] as GridRow;
            //var prescription = selectedRow.DataItem as OP_Prescription;

            //var circulationCode = DBHelper.CIS.From<OP_Prescription>().Where(p => p.PrescriptionNo == prescription.PrescriptionNo).Select(p => p.PrescriptionCirculation_PrescriptionNo).First<string>();
            //prescription.PrescriptionCirculation_PrescriptionNo = circulationCode;

            //ViewPrescriptionHelper viewPrescription = new ViewPrescriptionHelper();
            //var data = viewPrescription.Handler(prescription);
            //if (data == null)
            //    return;
            //FormPrescriptionCirculationPreview preview = new FormPrescriptionCirculationPreview();
            //preview.Init(data);
            //preview.ShowDialog();
        }

        private void 查看双流转处方审核结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var selectedRows = this.dgvPrescription.GetSelectedRows();
            //if (selectedRows.Count == 0)
            //    return;

            //var selectedRow = selectedRows[0] as GridRow;
            //var prescription = selectedRow.DataItem as OP_Prescription;

            //var circulationCode = DBHelper.CIS.From<OP_Prescription>().Where(p => p.PrescriptionNo == prescription.PrescriptionNo).Select(p => p.PrescriptionCirculation_PrescriptionNo).First<string>();
            //prescription.PrescriptionCirculation_PrescriptionNo = circulationCode;

            //AuditResultHelper auditResult = new AuditResultHelper();
            //var data = auditResult.Handler(prescription);
            //if (data == null)
            //    return;
            //FormAuditResult preview = new FormAuditResult();
            //preview.Init(data);
            //preview.ShowDialog();
        }

        private void 查看双流转取药结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var selectedRows = this.dgvPrescription.GetSelectedRows();
            //if (selectedRows.Count == 0)
            //    return;

            //var selectedRow = selectedRows[0] as GridRow;
            //var prescription = selectedRow.DataItem as OP_Prescription;

            //var circulationCode = DBHelper.CIS.From<OP_Prescription>().Where(p => p.PrescriptionNo == prescription.PrescriptionNo).Select(p => p.PrescriptionCirculation_PrescriptionNo).First<string>();
            //prescription.PrescriptionCirculation_PrescriptionNo = circulationCode;

            //TakeDrugResultHelper takeDrug = new TakeDrugResultHelper();
            //var data = takeDrug.Handler(prescription);
            //if (data == null)
            //    return;
            //FormTakeDrugResultPreview preview = new FormTakeDrugResultPreview();
            //preview.Init(data);
            //preview.ShowDialog();
        }

        private void btnHealthRecords_Click(object sender, EventArgs e)
        {
            _healthRecords.Handler();
        }
    }
}