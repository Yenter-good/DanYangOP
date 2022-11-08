using System;
using System.Data;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;
using System.Collections.Generic;

namespace CIS
{
    public partial class Login : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginWorkStation();
        }
        private void LoginWorkStation()
        {
            //if (SysContext.HMSocket.CreateDataBase() == 0)
            //{
            //    MessageBox.Show("叫号系统连接异常,请注意");
            //}
            string gh = this.tbxGh.Text.Trim();
            string pwd = this.tbxPwd.Text.Trim();
            if (string.IsNullOrWhiteSpace(gh))
            {
                this.lblMsg.Text = "系统消息：请输入工号！";
                this.tbxGh.Focus();
                return;
            }
            IView_User user = DBHelper.CIS.From<IView_User>().Where(p => p.Code == this.tbxGh.Text.Trim() && p.Pwd == this.tbxPwd.Text.Trim()).First();
            if (user == null)
            {
                this.lblMsg.Text = "系统消息：工号或者密码错误！";
                return;
            }
            else
            {
                SysContext.SetLoginUser(CIS.Purview.Purview.GetCurrUserForUserCode(this.tbxGh.Text));

                var dtNow = DBHelper.ServerTime;
                if (!DBHelper.CIS.Exists<OP_Log_InOut>(p => p.UserCode == this.tbxGh.Text.Trim() && p.OperationDate == dtNow.Date && p.OperationType == 0))
                {
                    OP_Log_InOut log = new OP_Log_InOut();
                    log.UserCode = this.tbxGh.Text.Trim();
                    log.OperationDate = dtNow.Date;
                    log.OperationTime = dtNow;
                    log.OperationType = 0;
                    log.IP = SysContext.ClientIP;

                    DBHelper.CIS.Insert(log);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            this.btnLogin.Parent = this.pictureBox1;
            this.btnExit.Parent = this.pictureBox1;
            this.lblGh.Parent = this.pictureBox1;
            this.lblMsg.Parent = this.pictureBox1;
            this.lblPwd.Parent = this.pictureBox1;
            this.Height = this.btnLogin.Top + this.btnLogin.Height + 21;

            Stack<string> a = new Stack<string>();
        }

        private class aaa
        {
            public string KSBH { get; set; }
            public string TCBH { get; set; }
            public string XH { get; set; }
            public string YPXMLX { get; set; }
            public string YPXMBM { get; set; }
            public string ZXKS { get; set; }
            public string YCYL { get; set; }
            public string YCYLDW { get; set; }
            public string YF { get; set; }
            public string ZL { get; set; }
            public string YYJG { get; set; }
            public string ZXTS { get; set; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //DataTable dt = DBHelper.CIS.FromSql("select * from mz_tcmc").ToDataTable();
            //foreach (DataRow item in dt.Rows)
            //{
            //    if (item["KSBH"].ToString().Trim() == "" || item["TCBH"].ToString().Trim() == "" || item["TCMC"].ToString().Trim() == "")
            //        continue;
            //    List<aaa> dt1 = new List<aaa>();
            //    dt1 = DBHelper.CIS.FromSql(string.Format("select b.code as YF,KSBH,TCBH,XH,YPXMLX,YPXMBM,ZXKS,dbo.Picknum(ycyl) AS YCYL,dbo.PickJL(ycyl) AS YCYLDW,ZL,YYJG,ZXTS from mz_tcmx a left join IView_HIS_DrugUsage b on a.yf=b.name where tcbh='{0}' AND KSBH='{1}'", item["TCBH"].ToString(), item["KSBH"].ToString())).ToList<aaa>();
            //    if (dt1.Count == 0)
            //        continue;
            //    List<string> list = dt1.Select(p => p.YPXMLX).Distinct().ToList();

            //    OP_DrugGroup tmp = new OP_DrugGroup();
            //    tmp.ID = Guid.NewGuid().ToString();
            //    tmp.ParentID = "0";
            //    tmp.GroupType = item["TCJB"].ToString() == "科室" ? 1 : 2;
            //    tmp.Owner = item["TCJB"].ToString() == "科室" ? item["KSBH"].ToString() : item["CZY"].ToString();
            //    tmp.Name = item["TCMC"].ToString();

            //    if (list.Contains("1") || list.Contains("2"))
            //    {
            //        tmp.DrugType = 1;
            //        DBHelper.CIS.Insert<OP_DrugGroup>(tmp);
            //        NewMethod(tmp.ID, dt1.Where(p => p.YPXMLX == "1" || p.YPXMLX == "2").ToList());
            //    }
            //    if (list.Contains("3"))
            //    {
            //        tmp.ID = Guid.NewGuid().ToString();
            //        tmp.DrugType = 2;
            //        DBHelper.CIS.Insert<OP_DrugGroup>(tmp);
            //        NewMethod(tmp.ID, dt1.Where(p => p.YPXMLX == "3").ToList());

            //    }

            //    if (list.Contains("4"))
            //    {
            //        OP_DearWithGroup tmp11 = new OP_DearWithGroup();
            //        tmp11.ID = Guid.NewGuid().ToString();
            //        tmp11.ParentID = "0";
            //        tmp11.GroupType = item["TCJB"].ToString() == "科室" ? 1 : 2;
            //        tmp11.Owner = item["TCJB"].ToString() == "科室" ? item["KSBH"].ToString() : item["CZY"].ToString();
            //        tmp11.Name = item["TCMC"].ToString();
            //        DBHelper.CIS.Insert<OP_DearWithGroup>(tmp11);
            //        NewMethod1(tmp.ID, dt1.Where(p => p.YPXMLX == "4").ToList());
            //    }
            //}

            //MessageBox.Show(dt.Rows.Count.ToString());

            Environment.Exit(0);
        }

        private static void NewMethod(string id, List<aaa> list)
        {
            foreach (aaa item in list)
            {
                OP_DrugGroup_Detail tmp1 = new OP_DrugGroup_Detail();
                tmp1.ID = Guid.NewGuid().ToString();
                tmp1.GroupID = id;
                tmp1.DrugID = item.YPXMBM;
                tmp1.Amount = decimal.Parse(item.YCYL);
                tmp1.DosageUnit = item.YCYLDW;
                tmp1.Usage = item.YF;
                tmp1.Frequency = (item.YYJG == "" ? "bid" : item.YYJG).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
                tmp1.Owner = item.KSBH;
                tmp1.Num = (int)float.Parse(item.ZL);
                tmp1.Days = (int)float.Parse((item.ZXTS ?? "") == "" ? "1" : item.ZXTS);
                tmp1.DrugDept = item.ZXKS;
                DBHelper.CIS.Insert<OP_DrugGroup_Detail>(tmp1);
            }
        }

        private static void NewMethod1(string id, List<aaa> list)
        {
            foreach (aaa item in list)
            {
                OP_DearWithGroup_Detail tmp1 = new OP_DearWithGroup_Detail();
                tmp1.ID = Guid.NewGuid().ToString();
                tmp1.GroupID = id;
                tmp1.ItemID = item.YPXMBM;
                tmp1.Owner = item.KSBH;
                tmp1.Number = (int)float.Parse(item.ZL);
                DBHelper.CIS.Insert<OP_DearWithGroup_Detail>(tmp1);
            }
        }

        private void tbxGh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.tbxPwd.Focus();
        }

        private void tbxPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnLogin.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        public void aa()
        {
            DataTable dt = DBHelper.CIS.FromSql("SELECT * FROM [Sheet1$]").ToDataTable();
            string str = System.IO.File.ReadAllText(@"D:\MyDesktop\1.txt");
            foreach (DataRow item in dt.Rows)
            {
                if (item["MBMC"] != null)
                {
                    OP_TemplateSample t = new OP_TemplateSample();
                    t.ID = Guid.NewGuid().ToString();
                    t.ParentID = "";
                    if (item["MBMC"].ToString() != "")
                        t.SampleName = item["MBMC"].ToString();
                    if (item["ZS"].ToString() != "")
                        t.ChiefComplaints = string.Format(str, item["ZS"].ToString());
                    if (item["XBS"].ToString() != "")
                        t.PresentIllness = string.Format(str, item["XBS"].ToString());
                    if (item["JWS"].ToString() != "")
                        t.Past = string.Format(str, item["JWS"].ToString());
                    if (item["TGJC"].ToString() != "")
                        t.PhysicalExamination = string.Format(str, item["TGJC"].ToString());
                    if (item["ZKJC"].ToString() != "")
                        t.Speciality = string.Format(str, item["ZKJC"].ToString());
                    t.DeptCode = item["ksbh"].ToString();
                    t.NodeType = 1;
                    t.UpdateTime = DateTime.Now;
                    DBHelper.CIS.Insert<OP_TemplateSample>(t);
                }
            }
        }
    }
}