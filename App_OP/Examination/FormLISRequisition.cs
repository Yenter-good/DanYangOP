using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.SuperGrid;
using CIS.Model;
using CIS.Core;
using CIS.Core.EventBroker;
using DCSoftDotfuscate;
using CIS.Core.Interceptors;
using CIS.Utility;
using App_OP.Examination;
using DevComponents.Editors;

namespace App_OP
{
    public partial class FormLISRequisition : Form
    {
        public FormLISRequisition(FormMain _formMain)
        {
            InitializeComponent();
            formMain = _formMain;
        }

        List<IView_Inside_ExamineGroup> groupList = new List<IView_Inside_ExamineGroup>();//分类列表
        List<IView_Inside_ExamineDetail> relList = new List<IView_Inside_ExamineDetail>();//分类关系表
        List<IView_HIS_ExamineItem_Detail> relDetail = new List<IView_HIS_ExamineItem_Detail>();//检验明细
        List<vzd_tcsm> tcsm = new List<vzd_tcsm>();//套餐说明
        IView_HIS_Outpatients patient = new IView_HIS_Outpatients();
        List<OP_Prescription_Detail> subList = new List<OP_Prescription_Detail>();

        List<IView_Inside_ExamineDetail> relSubList = new List<IView_Inside_ExamineDetail>();//当前节点下的分类关系表
        public OP_Prescription currPrescription = null;
        public List<OP_Prescription_Detail> hasList = new List<OP_Prescription_Detail>();
        public int CurrentDiagnosisCount = 0;
        private FormMain formMain;
        private List<string> _specimens=new List<string>();

        private GridRow _selectedRow;

        private void FormLisRequisition_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SysContext.RunSysInfo.user.ID) || string.IsNullOrWhiteSpace(SysContext.RunSysInfo.currDept.Code))
            {
                MsgBox.OK("系统未加载到当前科室或当前操作员请联系管理员！");
                return;
            }
            InitData();
            InitUI();
            InitTree(treeGroup);
            InitPrescription();
        }

        #region 加载界面及数据
        //供主界面调用加载相应信息
        public void InitPrescription()
        {
            if (currPrescription == null) return;
            subList = hasList.Where(x => x.PrescriptionNo == currPrescription.PrescriptionNo).OrderBy(p => p.No).ToList();
            gridSubList.PrimaryGrid.DataSource = subList;
            tbxExplanation.Text = currPrescription.Explanation;
            this.cbxSpecimen.SelectedIndex = _specimens.IndexOf(currPrescription.Specimen);
            if (currPrescription.Status != 0)
            {
                this.btnSave.Enabled = false;
                this.btnAdd.Enabled = false;
                this.btnDel.Enabled = false;
                this.gridList.Enabled = false;
                this.contextMenuStrip2.Enabled = false;
            }
        }

        public void CopyPrescription(OP_Prescription prescription)
        {
            subList = hasList.Where(x => x.PrescriptionNo == prescription.PrescriptionNo).OrderBy(p => p.No).ToList();
            subList.ForEach(p => {
                p.ID = null;
                p.PrescriptionNo = null;
                p.AttachAll();
                var index = prescription.Burette.IndexOf('(') + 1;
                p.Frequency =prescription.Burette.Substring(index,prescription.Burette.Length-index-1);
            });
            gridSubList.PrimaryGrid.DataSource = subList;
            this.currPrescription = null;
            tbxExplanation.Text = prescription.Explanation;
                this.btnSave.Enabled = true;
                this.btnAdd.Enabled = true;
                this.btnDel.Enabled = true;
                this.gridList.Enabled = true;
                this.contextMenuStrip2.Enabled = true;
        }

        private void InitData()
        {
            groupList = DBHelper.CIS.From<IView_Inside_ExamineGroup>().Where(x => x.GroupType == "jy").ToList();//所有分类包含个人和科室
            new System.Threading.Tasks.Task(() =>
            {
                try
                {
                    relList = DBHelper.CIS.From<IView_Inside_ExamineDetail>().Where(p => p.ItemType == "jy").ToList();
                    relDetail = DBHelper.CIS.From<IView_HIS_ExamineItem_Detail>().ToList();
                    tcsm = DBHelper.CIS.From<vzd_tcsm>().ToList();

                    _specimens = DBHelper.CIS.FromSql("SELECT MC FROM ZD_BBLX ORDER BY XH").ToList<string>();
                    this.cbxSpecimen.Items.Clear();
                    foreach (var specimen in _specimens)
                    {
                        ComboItem item = new ComboItem(specimen);
                        this.cbxSpecimen.Items.Add(item);
                    }
                    this.cbxSpecimen.SelectedIndex = 0;
                }
                catch { }
            }).Start();

        }

        public void InitUI()
        {
            gridDetail.PrimaryGrid.AutoGenerateColumns = false;
            gridSubList.PrimaryGrid.AutoGenerateColumns = false;
            gridTCSM.PrimaryGrid.AutoGenerateColumns = false;
            currPrescription = null;
            subList.Clear();
            gridSubList.PrimaryGrid.DataSource = subList;
            tbxExplanation.Text = "";
            gridSubList.PrimaryGrid.Columns["gridSubList_Name"].ReadOnly = true;


            this.btnSave.Enabled = true;
            this.btnAdd.Enabled = true;
            this.btnDel.Enabled = true;
            this.gridList.Enabled = true;
            this.contextMenuStrip2.Enabled = true;
        }

        private void InitTree(AdvTree tree)
        {
            tree.Nodes.Clear();
            List<IView_Inside_ExamineGroup> rootList = groupList.Where(x => x.ParentID == "0").OrderBy(x => x.No).ToList();
            //List<IView_Inside_ExamineGroup> rootList = groupList.OrderBy(x => x.No).ToList();
            foreach (IView_Inside_ExamineGroup item in rootList)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                tree.Nodes.Add(node);
                CreateChildNode(node, item.ID);
            }
            tree.ExpandAll();
        }

        private void CreateChildNode(Node parentNode, string parentCode)
        {
            List<IView_Inside_ExamineGroup> list = groupList.Where(x => x.ParentID == parentCode).OrderBy(x => x.No).ToList();
            if (list.Count < 1) return;
            foreach (IView_Inside_ExamineGroup item in list)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                parentNode.Nodes.Add(node);
                CreateChildNode(node, item.ID);
            }

        }

        private void NodeSelect(Node node, SuperGridControl grid, List<IView_Inside_ExamineDetail> list)
        {
            IView_Inside_ExamineGroup group = node.Tag as IView_Inside_ExamineGroup;
            relSubList = list.Where(x => x.GroupID == group.GroupID).ToList();
            grid.PrimaryGrid.DataSource = relSubList;
            grid.PrimaryGrid.AutoGenerateColumns = false;

            Application.DoEvents();//处理消息队列 清除界面堵塞
            grid.PrimaryGrid.SetSelectedRows(0, 1, true);
        }

        #endregion

        private void treeGroup_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            NodeSelect(e.Node, gridList, relList);
        }

        private void gridList_RowClick(object sender, GridRowClickEventArgs e)
        {
            _selectedRow = e.GridRow as GridRow;
            string code = (e.GridRow as GridRow)[0].Value.ToString();
            List<IView_HIS_ExamineItem_Detail> detail = relDetail.Where(x => x.ItemCode == code).ToList();
            gridDetail.PrimaryGrid.DataSource = detail;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemAdd();
        }

        private void ItemAdd()
        {
            SelectedElementCollection rows = gridList.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }
            foreach (GridRow row in rows)
            {
                IView_Inside_ExamineDetail examine = row.DataItem as IView_Inside_ExamineDetail;
                if (subList.Where(x => x.ItemCode == examine.Code).ToList().Count > 0) continue;

                OP_Prescription_Detail item = new OP_Prescription_Detail();
                item.ItemType = "5";//OP_Dic_ItemType 中对应的 检验
                item.ItemCode = examine.Code;
                item.ItemName = examine.Name;
                item.Number = 1;
                item.Price = examine.Price;
                item.ExecuteDept = examine.DeptCode;
                item.SkinTestFlag = examine.Specimen;
                item.Frequency = examine.Category;
                subList.Add(item);
            }

            gridSubList.PrimaryGrid.DataSource = subList;
        }

        private void btnAdd_R_Click(object sender, EventArgs e)
        {
            ItemAdd();
        }

        private void gridList_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            //GridRow row = e.GridRow as GridRow;
            //IView_Inside_ExamineDetail examine = row.DataItem as IView_Inside_ExamineDetail;
            //if (subList.Where(x => x.ItemCode == examine.Code).ToList().Count > 0) return;

            //OP_Prescription_Detail item = new OP_Prescription_Detail();
            //item.ItemType = "5";//OP_Dic_ItemType 中对应的 检验
            //item.ItemCode = examine.Code;
            //item.ItemName = examine.Name;
            //item.Number = 1;
            //item.Price = examine.Price;
            //item.ExecuteDept = examine.DeptCode;
            //item.SkinTestFlag = examine.Specimen;
            //item.Frequency = examine.Category;
            //subList.Add(item);

            //gridSubList.PrimaryGrid.DataSource = subList;
            ItemAdd();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ItemDel();
        }

        private void ItemDel()
        {
            SelectedElementCollection rows = gridSubList.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }
            foreach (GridRow row in rows)
            {
                OP_Prescription_Detail item = row.DataItem as OP_Prescription_Detail;
                if (!string.IsNullOrWhiteSpace(item.ID))
                {
                    subList.Remove(subList.Where(x => x.ID == item.ID).Single());
                    DBHelper.CIS.Delete<OP_Prescription_Detail>(OP_Prescription_Detail._.ID == item.ID);
                }
                else
                {
                    subList.Remove(subList.Where(x => x.ItemCode == item.ItemCode).Single());
                }
            }

            gridSubList.PrimaryGrid.DataSource = subList;
            if (subList.Count == 0 && currPrescription != null)
            {
                DBHelper.CIS.Delete<OP_Prescription>(p => p.PrescriptionNo == currPrescription.PrescriptionNo);
                formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.Prescription });
            }
        }

        private void btnDel_R_Click(object sender, EventArgs e)
        {
            ItemDel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Save();
        }

        private void btnSave_R_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            patient = SysContext.GetCurrPatient;
            if (formMain.GetDiagnosisNumber() == 0)
            {
                AlertBox.Info("当前诊断为空,无法开检验申请");
                return;
            }
            if (SysContext.GetCurrPatient == null)
            {
                MsgBox.OK("没有选择患者，无法保存！");
                return;
            }
            if (gridSubList.PrimaryGrid.Rows.Count == 0)
            {
                AlertBox.Error("没有任何检验项目，无法保存");
                return;
            }
            if (!formMain.GetRecordHasPersonel())
            {
                if (SysContext.CurrUser.Params.OP_ForcePersonel.AsBoolean())
                {
                    var dialog = MessageBox.Show("病历中个人史未填写，无法保存", "", MessageBoxButtons.OK);
                    return;
                }
                else
                    MessageBox.Show("病历中个人史未填写，请注意");
            }
            //根据病人身份证查，如果这个人之前开过核酸检测，就提醒，如果没开过就不提醒，只在开核酸检测检验的时候有用
            if (SysContext.CurrUser.Params.OP_NATTips && patient.IDCard.AsString("") != "")
            {
                var codes = this.gridSubList.PrimaryGrid.Rows.Cast<GridRow>().Select(p => p.Cells[1].Value.AsString());
                if (codes.Contains("007991") || codes.Contains("008259"))
                {
                    var result = DBHelper.CIS.FromProc("Por_MzZyHsCheck").AddInParameter("@Sfzh", DbType.String, patient.IDCard).ToDataTable();
                    if (result.Rows.Count > 0)
                    {
                        var code = result.Rows[0]["Code"].ToString();
                        if (code == "2" && codes.Contains("008259"))
                        {
                            MessageBox.Show("已经开过免费的核酸检测,无法再次开具");
                            return;
                        }
                        else if (code != "0")
                            MessageBox.Show(result.Rows[0]["Msg"].ToString());
                    }
                }
            }

            var autoSave = DBHelper.CIS.From<OP_Journal>().Where(p => p.OutpatientNo == SysContext.GetCurrPatient.OutpatientNo).Select(p => p.IsAutoSave).ToScalar<int?>();
            if (autoSave != 1)
            {
                FormWriteJournal j = new FormWriteJournal();
                j.currPatient = SysContext.GetCurrPatient;
                if (j.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    AlertBox.Info("用户已手动退出患者资料,无法保存处方");
                    return;
                }
            }
            List<OP_PatientDiagnosis> tmp1 = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo).ToList();
            foreach (OP_PatientDiagnosis item in tmp1)
            {
                if (item.Type != 2) continue;
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
                        var sql = $"select count(*) from Card_Mxb_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}' and hisxm='{SysContext.GetCurrPatient.PatientName}' and zllx is not null and czjc<>'f' and left(zlbm,3)='{ICD.Substring(0, 3)}'";
                        var count = DBHelper.HNIMIS.FromSql(sql).ToScalar<int>();
                        Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("查询患者慢性病信息", sql, $"查询到的数量是{count}"), Log4NetLevel.Info);
                        if (count == 0)
                            flag = 1;
                    }
                    else if (specialType == "12")
                    {
                        var sql = $"select count(*) from Card_Mxb_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}' and hisxm='{SysContext.GetCurrPatient.PatientName}' and gxblx<>'00' and czjc<>'f'";
                        var count = DBHelper.HNIMIS.FromSql(sql).ToScalar<int>();
                        Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("查询患者慢性病信息", sql, $"查询到的数量是{count}"), Log4NetLevel.Info);
                        if (count == 0)
                            flag = 1;
                    }
                    else if (specialType == "13")
                    {
                        var sql = $"select count(*) from Card_Mxb_Interface where sfzh = '{SysContext.GetCurrPatient.IDCard}' and hisxm = '{SysContext.GetCurrPatient.PatientName}' and nczlx<>'00' and czjc<>'f' and czrq> '{SysContext.GetCurrPatient.RegisterTime.AddDays(-28)}'";
                        var count = DBHelper.HNIMIS.FromSql(sql).ToScalar<int>();
                        Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("查询患者慢性病信息", sql, $"查询到的数量是{count}"), Log4NetLevel.Info);
                        if (count == 0)
                            flag = 1;
                    }
                    else if (specialType == "14")
                    {
                        var sql = $"select count(*) from MZF_INTERFACE where sfzh='{SysContext.GetCurrPatient.IDCard}' and brxm='{SysContext.GetCurrPatient.PatientName}' and czjc<>'f'";
                        var count = DBHelper.HNIMIS.FromSql(sql).ToScalar<int>();
                        Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("查询患者慢性病信息", sql, $"查询到的数量是{count}"), Log4NetLevel.Info);
                        if (count == 0)
                            flag = 2;
                    }
                    if (flag == 1)
                    {
                        Infect.Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "15");
                        return;
                    }
                    else if (flag == 2)
                    {
                        Infect.Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "16");
                        return;
                    }
                }
                else if (specialType.Trim() == "2") //如果是传染病
                {
                    if (!Infect.CheckInfection(Name, ICD))
                    {
                        var sql = $"select count(*) from Card_infect_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}'";
                        var count = DBHelper.HNIMIS.FromSql(sql).ToScalar<int>();
                        Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("查询患者慢性病信息", sql, $"查询到的数量是{count}"), Log4NetLevel.Info);
                        if (count == 0)
                        {
                            Infect.Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "0");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }

            //保存申请单
            bool successPrescription = false;//标记是否有申请单或申请单保存成功;

            List<OP_Prescription_Detail> Detail = new List<OP_Prescription_Detail>();
            foreach (GridRow item in this.gridSubList.PrimaryGrid.Rows)
            {
                OP_Prescription_Detail tmp = item.DataItem as OP_Prescription_Detail;
                Detail.Add(tmp);
            }

            List<string> Frequency = Detail.Select(p => p.Frequency).Distinct().ToList();
            string msg = "本次检验单将拆分为：";
            foreach (string item in Frequency)
            {
                string guid = currPrescription == null ? Guid.NewGuid().ToString() : currPrescription.ID;
                List<OP_Prescription_Detail> detail1 = Detail.Where(p => p.Frequency == item).ToList();
                //if (item.Contains("血"))
                //{
                //    FormLISAdditional form = new FormLISAdditional();
                //    form.PrescriptionNo = guid;
                //    if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                //    {
                //        CIS.Core.AlertBox.Info("用户手动退出加收项目列表,保存失败");
                //        return;
                //    }
                //}
                if (currPrescription == null)
                {
                    BuildPrescription(detail1.Count, guid, item);
                    successPrescription = DBHelper.CIS.Insert<OP_Prescription>(currPrescription) > 0;
                    currPrescription = null;
                }
                else
                {
                    currPrescription.Explanation = tbxExplanation.Text;
                    currPrescription.RecordNumber = gridSubList.PrimaryGrid.Rows.Count;
                    currPrescription.UpdateTime = DBHelper.ServerTime;
                    currPrescription.Status = 1;
                    successPrescription = DBHelper.CIS.Update<OP_Prescription>(currPrescription, OP_Prescription._.ID == currPrescription.ID) > 0;
                }
                int index = 1;
                foreach (OP_Prescription_Detail item1 in detail1)
                {
                    if (string.IsNullOrWhiteSpace(item1.ID))
                    {
                        BuildDetail(guid, index++, item1);
                        var data = DBHelper.CIS.Insert<OP_Prescription_Detail>(item1);
                        CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存检验项目", SerializeHelper.BeginJsonSerializable(item1), data > 0 ? "检验项目保存成功！" : "检验项目保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
                    }
                    else
                    {
                        var data = DBHelper.CIS.Update<OP_Prescription_Detail>(item1, OP_Prescription_Detail._.ID == item1.ID);
                        CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存检验项目", SerializeHelper.BeginJsonSerializable(item1), data > 0 ? "检验项目保存成功！" : "检验项目保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);

                    }
                }
                DBHelper.CIS.FromSql(string.Format("UPDATE GHBRZL SET CZJC='1' WHERE JZH='{0}'", SysContext.GetCurrPatient.OutpatientNo)).ExecuteNonQuery();
                DBHelper.CIS.FromSql(string.Format("UPDATE GHBRZL SET YSBM=(CASE WHEN YSBM IS NULL OR RTRIM(YSBM)='' THEN '{0}' ELSE YSBM END),YSXM=(CASE WHEN YSXM IS NULL OR RTRIM(YSXM)='' THEN '{1}' ELSE YSXM END) WHERE JZH='{2}'", SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.GetCurrPatient.OutpatientNo)).ExecuteNonQuery();
                msg += Environment.NewLine + item;
            }
            msg += Environment.NewLine + "请确认";
            if (Frequency.Count > 1)
                MessageBox.Show(msg);

            //保存申请单明细


            //if (errorNumber > 0)
            //    AlertBox.Error("有" + errorNumber + "条明细保存失败具体原因请联系管理员！");
            //else
            //{
            //    if (CIS.Core.SysContext.RunSysInfo.Params.OP_SplitLISOrder)
            //    {
            //        DataTable dt = DBHelper.CIS.FromProc("Proc_OP_SplitLIS").AddInParameter("PrescriptionNo", DbType.String, currPrescription.PrescriptionNo).ToDataTable();

            //    }
            AlertBox.Info("保存成功");
            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.Prescription });
            InitUI();
            //}
        }

        private int GetAge()
        {
            char[] str = new char[] { '岁', '月', '日', '天' };
            string age = SysContext.GetCurrPatient.Age;
            char[] chr = age.ToCharArray();
            for (int i = 0; i < chr.Length; i++)
            {
                if (str.Contains(chr[i]))
                {
                    string s = new string(chr, 0, i);
                    return (int)float.Parse(s);
                }

            }
            return 0;
        }

        private void BuildPrescription(int count, string guid, string Frequency)
        {
            currPrescription = new OP_Prescription();

            currPrescription.ID = guid;
            currPrescription.TreatmentNo = patient.OutpatientNo;
            currPrescription.PatientID = patient.PatientID;
            currPrescription.PrescriptionNo = guid;
            currPrescription.RecordNumber = count;
            currPrescription.PrescriptionType = "11";//OP_Dic_PrescriptionType 对应
            currPrescription.Explanation = tbxExplanation.Text;
            currPrescription.ConditionSummary = null;
            currPrescription.Specimen = (this.cbxSpecimen.SelectedItem as ComboItem).Text;
            currPrescription.Burette = Frequency;
            currPrescription.Parts = null;
            currPrescription.DeptCode = SysContext.RunSysInfo.currDept.Code;
            currPrescription.UserID = SysContext.RunSysInfo.user.ID;
            currPrescription.UpdateTime = DateTime.Now;
            currPrescription.Status = 1;
            currPrescription.IsExpedited = 0;
            currPrescription.PatientName = SysContext.GetCurrPatient.PatientName;
            currPrescription.DoctorPhone = SysContext.CurrUser.user.DoctorPhone;
            currPrescription.UserName = SysContext.CurrUser.user.Name;
            currPrescription.Age = SysContext.GetCurrPatient.Age;
            currPrescription.Sex = SysContext.GetCurrPatient.Sex;
            currPrescription.IDCard = SysContext.GetCurrPatient.IDCard;
            currPrescription.HISInterface_PrescriptionNo = DBHelper.CIS.FromProc("Mzys_GetMaxCfdh").AddInParameter("Jzh", DbType.String, SysContext.GetCurrPatient.OutpatientNo).ToScalar<int>();
        }

        private void BuildDetail(string guid, int No, OP_Prescription_Detail detail)
        {
            //detail.ItemCode	
            //detail.ItemName	
            //detail.Price
            //detail.Number	
            //detail.ItemType
            //detail.ExecuteDept
            detail.ID = Guid.NewGuid().ToString();
            detail.TreatmentNo = patient.OutpatientNo;
            detail.PatientID = patient.PatientID;
            detail.PrescriptionNo = guid;
            detail.No = No;
            detail.Specification = null;
            detail.PackingUnit = null;
            detail.Amount = null;
            detail.DosageUnit = null;
            detail.Usage = null;
            detail.Frequency = null;
            detail.SkinTestFlag = null;
            detail.UpdateTime = DBHelper.ServerTime;
            detail.GroupNo = null;
            detail.Days = null;
            detail.Total = detail.Number * detail.Price;

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string text = tbxSearch.Text.Trim();
            if (text.Length == 0)
                gridList.PrimaryGrid.DataSource = relSubList;
            else
                gridList.PrimaryGrid.DataSource = relList.Where(x => x.SearchCode.AsNotNullString().ToUpper().Contains(text.ToUpper()) ||
                    x.Name.AsNotNullString().Contains(text) ||
                    x.WubiCode.AsNotNullString().ToUpper().ToUpper().Contains(text.ToUpper())).ToList();
            Application.DoEvents();//处理消息队列 清除界面堵塞
            gridList.PrimaryGrid.ClearSelectedCells();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitUI();
        }

        private void btnKnowlage_Click(object sender, EventArgs e)
        {
            if (_selectedRow == null)
                return;

            var code = _selectedRow.Cells[0].Value.AsString("");

            var knowlage = tcsm.FirstOrDefault(p => p.ItemCode == code);
            if (knowlage == null)
            {
                AlertBox.Info("该项目没有知识库");
                return;
            }

            FormKnowlage form = new FormKnowlage();
            form.IsLIS = true;
            form.Init(knowlage);
            form.ShowDialog();
        }
    }
}
