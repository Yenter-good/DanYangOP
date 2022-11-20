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
using CIS.Utility;
using CIS.Core.Interceptors;
using App_OP.Examination.PACSShare.Token;
using App_OP.Examination.PACSShare.Number;
using App_OP.Examination.PACSShare.Notice;
using System.Diagnostics;
using App_OP.Examination.PACSShare.Submit;

namespace App_OP.Examination
{
    public partial class FormRISRequisition : Form
    {
        public FormRISRequisition(FormMain _formMain)
        {

            InitializeComponent();
            formMain = _formMain;
        }
        List<IView_Inside_ExamineGroup> groupList = new List<IView_Inside_ExamineGroup>();//分类列表
        List<IView_Inside_ExamineDetail> relList = new List<IView_Inside_ExamineDetail>();//分类关系表
        List<vzd_tcsm> tcsm = new List<vzd_tcsm>();//套餐说明
        private bool relListIsLoaded = false;
        private FormMain formMain;

        private GridRow _selectedRow;

        private List<IView_Inside_ExamineDetail> RelList
        {
            get
            {
                while (!relListIsLoaded)
                {
                    Application.DoEvents();
                }
                return relList;
            }
            set { relList = value; }
        }
        List<IView_Inside_ExamineDetail> relSubList = new List<IView_Inside_ExamineDetail>();//当前节点下的分类关系表

        IView_HIS_Outpatients patient = new IView_HIS_Outpatients();
        List<OP_Prescription_Detail> subList = new List<OP_Prescription_Detail>();

        public OP_Prescription currPrescription = null;
        public List<OP_Prescription_Detail> hasList = new List<OP_Prescription_Detail>();
        public int CurrentDiagnosisCount = 0;
        string[] Additional = new string[] { "805388", "806225" };

        private void FormPacsRequisition_Shown(object sender, EventArgs e)
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
        /// <summary>
        /// 供主界面调用加载相应信息
        /// </summary>
        public void InitPrescription()
        {
            if (currPrescription == null) return;
            subList = hasList.Where(x => x.PrescriptionNo == currPrescription.PrescriptionNo && x.ItemType != "1").OrderBy(p => p.No).ToList();
            gridSubList.PrimaryGrid.DataSource = subList;
            tbxExplanation.Text = currPrescription.Explanation;
            tbxConditionSummary.Text = currPrescription.ConditionSummary;

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
            subList.ForEach(p =>
            {
                p.ID = null;
                p.PrescriptionNo = null;
                p.AttachAll();
                var index = prescription.Burette.IndexOf('(') + 1;
                p.Frequency = prescription.Burette.Substring(index, prescription.Burette.Length - index - 1);
            });
            gridSubList.PrimaryGrid.DataSource = subList;
            tbxExplanation.Text = prescription.Explanation;
            tbxConditionSummary.Text = prescription.ConditionSummary;
            this.currPrescription = null;

            this.btnSave.Enabled = true;
            this.btnAdd.Enabled = true;
            this.btnDel.Enabled = true;
            this.gridList.Enabled = true;
            this.contextMenuStrip2.Enabled = true;
        }
        private void InitData()
        {
            groupList = DBHelper.CIS.From<IView_Inside_ExamineGroup>().Where(x => x.GroupType == "jc").ToList();//所有分类包含个人和科室
            tcsm = DBHelper.CIS.From<vzd_tcsm>().ToList();

            #region 后台加载数据
            new System.Threading.Tasks.Task(() =>
            {
                try
                {
                    relList = DBHelper.CIS.From<IView_Inside_ExamineDetail>().Where(p => p.ItemType == "jc").ToList();
                }
                catch { }
                relListIsLoaded = true;
            }).Start();
            #endregion

        }
        public void InitUI(bool ClearConditionSummary = false)
        {
            gridSubList.PrimaryGrid.AutoGenerateColumns = false;
            gridTCSM.PrimaryGrid.AutoGenerateColumns = false;
            currPrescription = null;
            subList.Clear();
            gridSubList.PrimaryGrid.DataSource = subList;
            tbxExplanation.Text = "";
            gridSubList.PrimaryGrid.Columns["gridSubList_Name"].ReadOnly = true;

            if (ClearConditionSummary)
                this.tbxConditionSummary.Text = "";

            this.btnSave.Enabled = true;
            this.btnAdd.Enabled = true;
            this.btnDel.Enabled = true;
            this.gridList.Enabled = true;
            this.contextMenuStrip2.Enabled = true;
        }
        private void InitTree(AdvTree tree)
        {
            tree.Nodes.Clear();
            //List<IView_Inside_ExamineGroup> rootList = groupList.OrderBy(x => x.No).ToList();
            List<IView_Inside_ExamineGroup> rootList = groupList.Where(x => x.ParentID == "0").OrderBy(x => x.No).ToList();
            foreach (IView_Inside_ExamineGroup item in rootList)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                tree.Nodes.Add(node);
                CreateChildNode(node, item.ID, item.NickName);
            }
            tree.ExpandAll();
        }
        private void CreateChildNode(Node parentNode, string parentCode, string NickName)
        {
            List<IView_Inside_ExamineGroup> list = groupList.Where(x => x.ParentID == parentCode).OrderBy(x => x.No).ToList();
            if (list.Count < 1) return;
            foreach (IView_Inside_ExamineGroup item in list)
            {
                Node node = new Node();
                node.Text = item.Name;
                item.NickName = NickName;
                node.Tag = item;
                node.Name = item.ID;
                parentNode.Nodes.Add(node);
                CreateChildNode(node, item.ID, item.NickName);
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
            NodeSelect(e.Node, gridList, RelList);
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
                List<IView_Inside_ExamineGroup> group = groupList.Where(p => p.GroupID == examine.GroupID).ToList();
                if (group.Count > 0)
                {
                    string ID = group[0].ID;
                    Node node = this.treeGroup.FindNodeByName(ID);
                    if (node != null)
                        this.treeGroup.SelectedNode = node;
                }
                item.ItemType = "6";//OP_Dic_ItemType 中对应的 检查
                item.ItemCode = examine.Code;
                item.ItemName = examine.Name;
                item.Number = 1;
                item.Price = examine.Price;
                item.ExecuteDept = examine.DeptCode;
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
            //item.ItemType = "6";//OP_Dic_ItemType 中对应的 检查
            //item.ItemCode = examine.Code;
            //item.ItemName = examine.Name;
            //item.Number = 1;
            //item.Price = examine.Price;
            //item.ExecuteDept = examine.DeptCode;
            //subList.Add(item);

            //gridSubList.PrimaryGrid.DataSource = subList;
            ItemAdd();
        }

        private Node GetParent(Node node)
        {
            if (node.Parent != null)
                return GetParent(node.Parent);
            else
                return node;
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
            if (formMain.GetDiagnosisNumber() == 0)
            {
                AlertBox.Info("当前诊断为空,无法开检查申请");
                return;
            }
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                MsgBox.OK("没有选择患者，无法保存！");
                return;
            }
            if (gridSubList.PrimaryGrid.Rows.Count == 0)
            {
                AlertBox.Error("没有任何检查项目，无法保存");
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
            patient = SysContext.GetCurrPatient;
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
                        var sql = $"select count(*) from Card_Mxb_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}' and hisxm='{SysContext.GetCurrPatient.PatientName}' and nczlx<>'00' and czjc<>'f' and czrq>'{SysContext.GetCurrPatient.RegisterTime.AddDays(-28)}'";
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
                    if (Infect.CheckInfection(Name, ICD))
                    {
                        return;

                    }
                    else
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
                }
            }
            //保存申请单
            string guid = currPrescription == null ? Guid.NewGuid().ToString() : currPrescription.ID;
            bool successPrescription = false;//标记是否有申请单或申请单保存成功;

            Node node = this.treeGroup.SelectedNode;
            if (node == null) return;
            node = GetParent(node);
            IView_Inside_ExamineGroup group = node.Tag as IView_Inside_ExamineGroup;

            if (currPrescription == null)
            {
                BuildPrescription(gridSubList.PrimaryGrid.Rows.Count, guid);
                currPrescription.Specimen = group.NickName;
                successPrescription = DBHelper.CIS.Insert<OP_Prescription>(currPrescription) > 0;
            }
            else
            {
                currPrescription.Explanation = tbxExplanation.Text;
                currPrescription.ConditionSummary = tbxConditionSummary.Text;
                currPrescription.UpdateTime = DBHelper.ServerTime;
                currPrescription.RecordNumber = gridSubList.PrimaryGrid.Rows.Count;
                currPrescription.Status = 1;
                currPrescription.Specimen = group.NickName;
                DBHelper.CIS.Update<OP_Prescription>(currPrescription, OP_Prescription._.ID == currPrescription.ID);
                successPrescription = true;
            }
            if (!successPrescription)
            {
                AlertBox.Error("申请单保存失败！");
                return;
            }

            int errorNumber = 0;
            DBHelper.CIS.Delete<OP_Prescription_Detail>(p => p.PrescriptionNo == guid && p.ItemType == "9");

            List<OP_Prescription_Detail> details = new List<OP_Prescription_Detail>();
            //保存申请单明细
            foreach (GridRow row in gridSubList.PrimaryGrid.Rows)
            {
                OP_Prescription_Detail detail = row.DataItem as OP_Prescription_Detail;
                details.Add(detail);
                //if (Additional.Contains(row.Cells["gridSubList_Code"].Value.ToString().Trim()))
                //{

                if (string.IsNullOrWhiteSpace(detail.ID))
                {
                    BuildDetail(guid, row, detail);
                    var data = DBHelper.CIS.Insert<OP_Prescription_Detail>(detail);
                    if (data < 1)
                        errorNumber++;
                    CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存检查项目", SerializeHelper.BeginJsonSerializable(detail), data > 0 ? "检查项目保存成功！" : "检查项目保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
                }
                else
                {
                    var data = DBHelper.CIS.Update<OP_Prescription_Detail>(detail, OP_Prescription_Detail._.ID == detail.ID);
                    CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存检查项目", SerializeHelper.BeginJsonSerializable(detail), data > 0 ? "检查项目保存成功！" : "检查项目保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
                }
                //}
            }
            //if (HaveGastroscope)
            //    BuildAdditional("003509", guid);

            //if (errorNumber > 0)
            //    AlertBox.Error("有" + errorNumber + "条明细保存失败具体原因请联系管理员！");
            //else
            //{
            //    if (CIS.Core.SysContext.RunSysInfo.Params.OP_SplitRISOrder)
            //    {
            //        DataTable dt = DBHelper.CIS.FromProc("Proc_OP_SplitRIS").AddInParameter("PrescriptionNo", DbType.String, currPrescription.PrescriptionNo).ToDataTable();
            //    }
            AlertBox.Info("保存成功");
            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.Prescription });
            string prescriptionNo = currPrescription.PrescriptionNo;
            InitUI();
            DBHelper.CIS.FromSql(string.Format("UPDATE GHBRZL SET CZJC='1' WHERE JZH='{0}'", SysContext.GetCurrPatient.OutpatientNo)).ExecuteNonQuery();
            DBHelper.CIS.FromSql(string.Format("UPDATE GHBRZL SET YSBM=(CASE WHEN YSBM IS NULL OR RTRIM(YSBM)='' THEN '{0}' ELSE YSBM END),YSXM=(CASE WHEN YSXM IS NULL OR RTRIM(YSXM)='' THEN '{1}' ELSE YSXM END) WHERE JZH='{2}'", SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.GetCurrPatient.OutpatientNo)).ExecuteNonQuery();
            //}

            if (SysContext.CurrUser.Params.OP_PACSShare)
            {
                bool hasToken = false;
                if (details.Any())
                {
                    hasToken = new TokenHelper().Handler();
                    if (hasToken)
                    {
                        var number = new NumberHelper().Handler();
                        var data = new NoticeHelper().Handler(details);
                        DialogResult dresult = DialogResult.No;
                        if (number > 0)
                        {
                            if (!string.IsNullOrEmpty(data.url))
                            {
                                var result = MessageBox.Show("该患者近期有类似检查项目，是否跳转至云影像平台查看", "", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    Process.Start(data.url);
                                }
                            }

                            dresult = DialogResult.Yes;
                        }
                        else
                            dresult = MessageBox.Show("云影像平台提示该患者近期类似检查项目数量为0，是否提交回执", "", MessageBoxButtons.YesNo);

                        if (dresult == DialogResult.Yes && !string.IsNullOrEmpty(data.serialNumber))
                        {
                            var msg = new SubmitHelper().Handler(data.serialNumber, details);
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show("提交云影像平台失败：" + msg);
                            else
                                AlertBox.Info("云影像平台回执提交成功");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 生成一条加收项目项   
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="PrescriptionNo"></param>
        private void BuildAdditional(string itemCode, string PrescriptionNo)
        {
            List<IView_HIS_DrugInfo> drugs = DBHelper.CIS.From<IView_HIS_DrugInfo>().Where(p => p.DrugID == itemCode).ToList();
            if (drugs.Count == 0)
                return;
            IView_HIS_DrugInfo drug = drugs[0];
            OP_Prescription_Detail detail = new OP_Prescription_Detail();
            detail.ID = Guid.NewGuid().ToString();
            detail.TreatmentNo = SysContext.GetCurrPatient.OutpatientNo;
            detail.PrescriptionNo = PrescriptionNo;
            detail.PatientID = SysContext.GetCurrPatient.PatientID;
            detail.ItemType = "1";
            detail.IsAdditional = 1;
            detail.No = 99;
            detail.ItemCode = itemCode;
            detail.ItemName = drug.DrugName;
            detail.Specification = drug.Specification;
            detail.Number = 1;
            detail.PackingUnit = drug.PackingUnit;
            detail.Amount = drug.MinDose.AsFloat(1);
            detail.DosageUnit = drug.MinDoseUnit;
            detail.ExecuteDept = drug.DrugDept;
            detail.UpdateTime = DateTime.Now;
            detail.Days = 1;
            detail.Total = drug.DrugPrice;
            detail.PackingNumber = drug.PackingNumber;
            detail.Price = drug.DrugPrice;
            DBHelper.CIS.Insert<OP_Prescription_Detail>(detail);
        }

        private void BuildPrescription(int count, string guid)
        {
            currPrescription = new OP_Prescription();

            currPrescription.ID = guid;
            currPrescription.TreatmentNo = patient.OutpatientNo;
            currPrescription.PatientID = patient.PatientID;
            currPrescription.PrescriptionNo = guid;
            currPrescription.RecordNumber = count;
            currPrescription.PrescriptionType = "12";//OP_Dic_PrescriptionType 对应
            currPrescription.Explanation = tbxExplanation.Text;
            currPrescription.ConditionSummary = this.tbxConditionSummary.Text;
            currPrescription.Specimen = null;
            currPrescription.Burette = null;
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

        private void BuildDetail(string guid, GridRow row, OP_Prescription_Detail detail)
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
            detail.No = row.Index + 1;
            detail.Specification = null;
            detail.PackingUnit = null;
            detail.Amount = null;
            detail.DosageUnit = null;
            detail.Usage = null;
            detail.Frequency = null;
            detail.SkinTestFlag = null;
            detail.GroupNo = null;
            detail.Days = null;
            detail.Total = row.Cells["gridSubList_Number"].Value.AsDecimal() * row.Cells["gridSubList_Price"].Value.AsDecimal();
            detail.UpdateTime = DBHelper.ServerTime;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitUI();
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

        /// <summary>
        /// 导入现病史到检查摘要
        /// </summary>
        /// <param name="str"></param>
        public void ImportPresentIllness(string str)
        {
            this.tbxConditionSummary.Text = str;
        }

        private void gridList_RowClick(object sender, GridRowClickEventArgs e)
        {
            _selectedRow = e.GridRow as GridRow;
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
            form.IsLIS = false;
            form.Init(knowlage);
            form.ShowDialog();
        }
    }
}
