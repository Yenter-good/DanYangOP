using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;
using DevComponents.DotNetBar.SuperGrid;
using CIS.Core.EventBroker;
using App_OP.Examination;

namespace App_OP
{
    public partial class FormLISResult : Form
    {
        public FormLISResult(FormMain _formMain)
        {
            InitializeComponent();
            formMain = _formMain;
        }

        public bool search = false;
        public FormMain formMain;
        List<IView_HIS_LISResult> result = new List<IView_HIS_LISResult>();
        private List<vzd_tcsm> tcsm;

        private void FormLISResult_Load(object sender, EventArgs e)
        {
            tcsm = DBHelper.CIS.From<vzd_tcsm>().ToList();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.tbxSearch.Text == "")
                return;

            this.gridPatient.PrimaryGrid.Rows.Clear();
            result = DBHelper.LIS.From<IView_HIS_LISResult>().Where(p => p.IDCard == this.tbxSearch.Text || p.Cname == this.tbxSearch.Text).ToList();
            var date = result.Select(p => p.CheckDate.Value.Date).Distinct().OrderByDescending(p => p).ToList();
            foreach (var item in date)
            {
                var dateFormat = item.ToShortDateString();
                GridRow rowNo = new GridRow(dateFormat);
                List<IView_HIS_LISResult> tmp = result.Where(p => p.CheckDate >= (dateFormat + " 00:00:00").AsDateTime() && p.CheckDate <= (dateFormat + " 23:59:59").AsDateTime()).GroupBy(p => new { p.PatNo, p.IDCard, p.CheckDate, p.DeptName/*, p.HISXMNO*/ , p.Cname }).Select(p => new IView_HIS_LISResult() { /*HISXMNO = p.Key.HISXMNO, */CheckDate = p.Key.CheckDate, PatNo = p.Key.PatNo, IDCard = p.Key.IDCard, DeptName = p.Key.DeptName, Cname = p.Key.Cname }).OrderByDescending(p => p.CheckDate).ToList();
                foreach (IView_HIS_LISResult item1 in tmp)
                {
                    GridRow row = new GridRow(item1.CheckDate, item1.IDCard, item1.Cname, item1.PatNo, item1.DeptName);
                    row.Tag = item1;
                    rowNo.Rows.Add(row);
                }
                this.gridPatient.PrimaryGrid.Rows.Add(rowNo);
            }
            this.gridPatient.PrimaryGrid.ExpandAll();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridPatient_RowClick(object sender, GridRowClickEventArgs e)
        {
            this.gridResult.PrimaryGrid.Rows.Clear();
            SelectedElementCollection rows = gridPatient.GetSelectedRows();
            if (rows.Count == 0) return;
            GridRow row = rows[0] as GridRow;
            if (row.Rows.Count > 0) return;

            var tag = row.Tag as IView_HIS_LISResult;
            var treatmentNo = tag.PatNo;
            IView_HIS_LISResult Result = result.Where(p => p.PatNo == treatmentNo).First();

            this.labCheck.Text = @"审核人员：<b><font color=""#ED1C24"">{0}</font></b> ".FormatWith(Result.Checker);
            this.labTechnician.Text = @"检验人员：<b><font color=""#ED1C24"">{0}</font></b> ".FormatWith(Result.Technician);
            if (Result.SickType == "门诊")
            {
                List<IView_HIS_Outpatients_All> doctorName = DBHelper.CIS.From<IView_HIS_Outpatients_All>().Where(p => p.OutpatientNo == Result.PatNo).ToList();
                if (doctorName.Count != 0)
                {
                    this.labDoctorName.Text = @"医生姓名：<b><font color=""#ED1C24"">{0}</font></b> ".FormatWith(doctorName[0].DoctorName);
                    this.labAge.Text = @"病人年龄：<b><font color=""#ED1C24"">{0}</font></b> ".FormatWith(doctorName[0].Age);
                    this.labSex.Text = @"病人性别：<b><font color=""#ED1C24"">{0}</font></b> ".FormatWith(doctorName[0].Sex);
                }
            }
            else
            {
                var zybrzl = DBHelper.CIS.FromSql(string.Format("SELECT BRXM, SFZH, XB, CSRQ FROM ZY_BRZL WHERE BLH='{0}' UNION ALL SELECT BRXM, SFZH, XB, CSRQ FROM ZY_BRZLLS WHERE BLH='{0}'", Result.PatNo)).ToList<ZYBRZL>();

                if (zybrzl != null && zybrzl.Count > 0)
                {
                    if (!zybrzl[0].SFZH.IsNullOrWhiteSpace())
                    {
                        int year = zybrzl[0].SFZH.Substring(6, 4).AsInt(0);
                        var age = DateTime.Now.Year - year;
                        this.labAge.Text = @"病人年龄：<b><font color=""#ED1C24"">{0}</font></b> ".FormatWith(age + "岁");
                    }
                    else
                    {
                        int year = zybrzl[0].CSRQ.Substring(0, 4).AsInt(0);
                        var age = DateTime.Now.Year - year;
                        this.labAge.Text = @"病人年龄：<b><font color=""#ED1C24"">{0}</font></b> ".FormatWith(age + "岁");
                    }
                    this.labSex.Text = @"病人性别：<b><font color=""#ED1C24"">{0}</font></b> ".FormatWith(zybrzl[0].XB == "1" ? "男" : "女");
                }
                this.labDoctorName.Text = @"医生姓名：<b><font color=""#ED1C24"">{0}</font></b> ".FormatWith("");


            }


            var receiveDate = tag.CheckDate;
            List<IView_HIS_LISResult> tmp = result.Where(p => p.CheckDate == receiveDate.AsDateTime()).OrderBy(p => p.OrderBy).ToList();

            foreach (IView_HIS_LISResult item in tmp)
            {
                GridRow row1 = new GridRow(false, item.ItemName, item.ReportValue, item.Unit, item.ResultStatus == "H" ? "↑" : item.ResultStatus == "L" ? "↓" : "", item.RefRange);
                this.gridResult.PrimaryGrid.Rows.Add(row1);
            }

            Application.DoEvents();
            foreach (GridRow item in this.gridResult.PrimaryGrid.Rows)
            {
                if (item.Cells["Detail_Flag"].Value.AsString("") == "↑")
                    item.CellStyles.Default.TextColor = Color.Red;
                else if (item.Cells["Detail_Flag"].Value.AsString("") == "↓")
                    item.CellStyles.Default.TextColor = Color.Green;
            }
        }

        private void FormLISResult_Shown(object sender, EventArgs e)
        {
            if (search)
            {
                if (SysContext.Session.ContainsKey("CurrPatient"))
                {
                    IView_HIS_Outpatients patient = SysContext.Session["CurrPatient"] as IView_HIS_Outpatients;
                    this.tbxSearch.Text = patient.IDCard;
                    btnSearch_Click(null, null);
                    search = false;
                    this.gridResult.ContextMenuStrip = this.contextMenuStrip1;
                }
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (!SysContext.Session.ContainsKey("CurrPatient"))
                return;
            string str = "";
            foreach (GridRow item in this.gridResult.PrimaryGrid.Rows)
                if (item.Cells["Select"].Value.AsBoolean())
                    str += item.Cells["Detail_Name"].Value.ToString().Trim() + " " + item.Cells["Detail_Value"].Value.ToString().Trim() + item.Cells["Detail_Unit"].Value.ToString().Trim() + ";";

            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.ImportLISResult, Data = str });
            AlertBox.Info("导入成功");
            this.Close();
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridRow item in this.gridResult.PrimaryGrid.Rows)
            {
                item.Cells["Select"].Value = this.checkBoxX1.Checked;
            }
        }

        private void gridResult_CellClick(object sender, GridCellClickEventArgs e)
        {
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            buttonItem1_Click(null, null);
        }

        public class ZYBRZL
        {
            public string BRXM { get; set; }
            public string SFZH { get; set; }
            public string XB { get; set; }
            public string CSRQ { get; set; }
        }

        private void btnKnowlage_Click(object sender, EventArgs e)
        {
            //var selectedRows = this.gridPatient.GetSelectedRows();
            //if (selectedRows.Count == 0)
            //{
            //    return;
            //}

            //var selectedRow = selectedRows[0] as GridRow;
            //var tag = selectedRow.Tag as IView_HIS_LISResult;

            //var code = tag.HISXMNO;

            //var knowlage = tcsm.FirstOrDefault(p => p.ItemCode == code);
            //if (knowlage == null)
            //{
            //    AlertBox.Info("该项目没有知识库");
            //    return;
            //}

            //FormKnowlage form = new FormKnowlage();
            //form.IsLIS = true;
            //form.Init(knowlage);
            //form.ShowDialog();
        }
    }
}


