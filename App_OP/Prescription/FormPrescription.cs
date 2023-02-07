using App_OP.PrescriptionCirculation.PreAudit;
using App_OP.PrescriptionCirculation.Upload;
using App_OP.PrescriptionCirculation.UploadSign;
using CIS.Core;
using CIS.Core.EventBroker;
using CIS.Core.Interceptors;
using CIS.Model;
using CIS.Utility;
using DCSoftDotfuscate;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Dos.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_OP.Prescription
{
    public partial class FormPrescription : BaseForm
    {
        public FormPrescription(FormMain _formMain)
        {
            InitializeComponent();
            formMain = _formMain;
        }
        #region 变量


        private FormMain formMain;
        private const int MaxWMCount = 10;//最大西药数量
        private const int MaxHMCount = 100; //最大草药数量
        private const int MaxDiagnoseCount = 100; //最大治疗数量

        private PrescriptionType CurrentWesternMedicinePrescriptionType;
        private PrescriptionType CurrentHerbalMedicinePrescriptionType;
        private PrescriptionType CurrentDiagnosePrescriptionType;

        List<IView_HIS_DrugInfo> WesternMedicineInfo = new List<IView_HIS_DrugInfo>(); //全部西药
        List<IView_HIS_DrugInfo> HerbalMedicineDrugInfo = new List<IView_HIS_DrugInfo>(); //全部草药
        List<IView_HIS_DealWithItem> DiagnoseInfo = new List<IView_HIS_DealWithItem>(); //全部治疗
        List<OP_UserInterval> Interval;//间隔
        List<OP_Dic_Interval> AllInterval;
        List<IView_HIS_DrugUsage> Usage;//用法

        public List<OP_Prescription_Detail> CurrPatientPrescriptionDetail = new List<OP_Prescription_Detail>(); //当前病人的项目列表
        public OP_Prescription CurrPatientPrescription = new OP_Prescription(); //当前处方
        public string CurrentWMPrescriptionNo = ""; //当前西药处方编号
        public string CurrentHMPrescriptionNo = ""; //当前草药处方编号
        public string CurrentDiagnosePrescriptionNo = ""; //当前治疗处方编号
        public string CurrentPrescriptionNo = ""; //当前处方编号
        public int CurrentDiagnosisCount = 0; //当前诊断数量
        public string CurrentDiagnosisName = ""; //当前诊断名称

        public string ChronicCode = ""; //当前选择的慢性病编码
        public string ChronicName = ""; //当前选择的慢性病名称
        public string ChronicType = ""; //当前选择的慢性病类型

        List<OP_DearWithGroup> DearWithGroupList = new List<OP_DearWithGroup>();//处置分类
        List<OP_DrugGroup> DrugGroupList = new List<OP_DrugGroup>();//药品组套
        List<IView_Inside_DealWithItem> DealWithList = new List<IView_Inside_DealWithItem>();//处置分类明细
        List<IView_Inside_DrugDetail> DrugList = new List<IView_Inside_DrugDetail>();//药品组套明细

        public string HasHMDiagnosis = "";

        private List<OP_Dic_DrugPermission> listDrugLimit; //药品限制列表

        string[] WesternMedicineDept = System.Configuration.ConfigurationManager.AppSettings["WesternMedicineDept"].Split("|".ToCharArray());
        string[] HerbalMedicineDept = System.Configuration.ConfigurationManager.AppSettings["HerbalMedicineDept"].Split("|".ToCharArray());
        bool DrugAuthority = System.Configuration.ConfigurationManager.AppSettings["DrugAuthority"].AsBoolean();  //是否开启用药权限检查

        private bool WMKeyDown = false;
        private bool HMKeyDown = false;
        private bool TreatmentKeyDown = false;

        private BeforePrescriptionAudit _beforePrescriptionAudit;

        private string _herbsGroupName;
        //编码加数量
        private Dictionary<string, float?> _herbsGroupItems = new Dictionary<string, float?>();
        //当前选择的膏方药品数量
        private int _herbsGroupQuantity;
        #endregion

        private void FormPrescription_Shown(object sender, EventArgs e)
        {
            InitDrugType();
            InitDrugInfo();
            InitUI();
            InitDict();
            InitDrugLimit();
            InitGroupInfo();
            InitDearWithGroupTree(DearWithGroupList);
            InitDrugGroupTree(treeDrugGroup, DrugGroupList, 1);
            InitDrugGroupTree(treeHerbsGroup, DrugGroupList, 2);
            SetOffIme(this.dgvWesternMedicine, this.dgvDiagnose, this.dgvHerbalMedicine);
        }

        #region 初始化操作
        private void InitDrugLimit()
        {
            listDrugLimit = DBHelper.CIS.From<OP_Dic_DrugPermission>().ToList();
        }
        /// <summary>
        /// 清除所有选中的套餐节点
        /// </summary>
        /// <param name="nodes"></param>
        private void ClearGroupSelect(NodeCollection nodes)
        {
            foreach (Node item in nodes)
            {
                if (item.Nodes.Count > 0)
                {
                    ClearGroupSelect(item.Nodes);
                }

                if (item.Checked)
                {
                    item.Checked = false;
                }
            }
        }
        public void InitNormalPrescription(bool IsHM = false)
        {
            //if (IsDelete && (HasHMDiagnosis != "1"))
            //{
            //    InitCYBar(false);
            //    this.dgvCY.Rows.Clear();
            //    this.dgvCYDetail.Hide();
            //    return;
            //}
            if (IsHM)
            {
                btnCYNew_Click(null, null);
                return;
            }
            if (SysContext.CurrUser.Params.OP_DefaultPrescriptionType.IsNullOrWhiteSpace())
            {
                button_Click(new ButtonItem() { Tag = "1" }, null);
            }
            else
            {
                button_Click(new ButtonItem() { Tag = SysContext.CurrUser.Params.OP_DefaultPrescriptionType }, null);
            }

            btnZLNew_Click(null, null);

        }

        /// <summary>
        /// 初始化快捷键
        /// </summary>
        /// <param name="shortcutKey"></param>
        protected override void InitializeShortcutKeys(ShortcutKey shortcutKey)
        {
            shortcutKey.Set(Shortcut.CtrlS, new Action(() => Save()), "保存处方");
            shortcutKey.Set(Shortcut.Del, new Action(() => Delete()), "删除选中项");
            shortcutKey.Set(Shortcut.CtrlA, new Action(() => SelectAll()), "全选");
            shortcutKey.Set(Shortcut.CtrlN, new Action(() => AddRow()), "增加一行");
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        public void InitUI(bool ClearChronic = false, bool ClearHM = false)
        {
            _beforePrescriptionAudit = new BeforePrescriptionAudit();

            if (ClearHM)
            {
                InitCYBar(false);
                this.dgvHerbalMedicine.Rows.Clear();
                this.dgvHerbalMedicineDetail.Hide();
                HasHMDiagnosis = "0";
                CurrentHMPrescriptionNo = "";
                return;
            }
            this.biEcgQueryReport.Visible = SysContext.RunSysInfo.Params.OP_EcgRead;
            this.dgvWesternMedicine.AutoGenerateColumns = false;
            this.dgvWesternMedicineDetail.AutoGenerateColumns = false;
            this.dgvDiagnose.AutoGenerateColumns = false;
            this.dgvDiagnoseDetail.AutoGenerateColumns = false;
            this.dgvHerbalMedicine.AutoGenerateColumns = false;
            this.dgvHerbalMedicineDetail.AutoGenerateColumns = false;
            InitXYBar(false);
            InitCYBar(false);
            InitZLBar(false);
            this.dgvWesternMedicine.Rows.Clear();
            this.dgvHerbalMedicine.Rows.Clear();
            this.dgvDiagnose.Rows.Clear();
            this.dgvDiagnoseDetail.Hide();
            this.dgvHerbalMedicineDetail.Hide();
            this.dgvWesternMedicineDetail.Hide();
            if (SysContext.CurrUser.roleList.Find(p => p.Code == "hs") != null)
            {
                this.tabXY.Visible = false;
                this.tabCY.Visible = false;
                this.pnlDrugGroup.Visible = false;
                this.pnlHerbsGroup.Visible = false;
                this.tabPrescription.SelectedTab = tabZL;
            }
            else
            {
                this.tabPrescription.SelectedTab = tabXY;
            }
            CurrPatientPrescriptionDetail = null;
            CurrPatientPrescription = null;
            CurrentWMPrescriptionNo = "";
            HasHMDiagnosis = "0";
            if (ClearChronic)
            {
                ChronicCode = "";
                ChronicName = "";
                ChronicType = "";
            }

            //根据用户设置判断是否需要开草药和中药膏方套餐界面
            if (!SysContext.CurrUser.Params.OP_ShowHerbalMedicine)
            {
                this.pnlHerbsGroup.Visible = false;
                this.tabCY.Visible = false;
            }

            if (SysContext.UserPositionSetting != null && SysContext.UserPositionSetting.PrescriptionPosition > 0)
            {
                this.tabPrescription.Height = SysContext.UserPositionSetting.PrescriptionPosition;
            }
        }

        /// <summary>
        /// 读取药品信息
        /// </summary>
        public void InitDrugInfo()
        {
            try
            {
                new System.Threading.Thread(() =>
                {
                    WesternMedicineInfo = DBHelper.CIS.From<IView_HIS_DrugInfo>().Where(p => p.DrugDept.In(WesternMedicineDept)).ToList();
                    HerbalMedicineDrugInfo = DBHelper.CIS.From<IView_HIS_DrugInfo>().Where(p => p.DrugDept.In(HerbalMedicineDept)).ToList();
                    DiagnoseInfo = DBHelper.CIS.From<IView_HIS_DealWithItem>().ToList();
                }).Start();
            }
            catch
            {
                MessageBox.Show("读取药品信息时出现错误");
            }
        }

        /// <summary>
        /// 初始化处方类型
        /// </summary>
        private void InitDrugType()
        {
            List<OP_Dic_PrescriptionType> tmp = DBHelper.CIS.From<OP_Dic_PrescriptionType>().Where(p => p.Status == 1 && p.DrugType == 1).ToList();
            foreach (OP_Dic_PrescriptionType item in tmp)
            {
                ButtonItem button = new ButtonItem(item.Code, item.Name);
                button.Tag = item.Code;
                this.btnXYNew.SubItems.Add(button);
                button.Click += button_Click;
            }
        }

        /// <summary>
        /// 初始化用法和间隔字典
        /// </summary>
        private void InitDict()
        {
            Usage = DBHelper.CIS.From<IView_HIS_DrugUsage>().ToList();
            this.XY_colYF.DataSource = Usage.Where(p => p.Type == "1").ToList();
            this.XY_colYF.DisplayMember = "Name";
            this.XY_colYF.ValueMember = "Code";
            this.CY_colYF.DisplayMember = "Name";
            this.CY_colYF.ValueMember = "Code";
            this.CY_colYF.DataSource = Usage.Where(p => p.Type == "2").ToList();

            AllInterval = DBHelper.CIS.From<OP_Dic_Interval>().ToList();
            Interval = DBHelper.CIS.From<OP_UserInterval>().Where(p => p.UserID == SysContext.CurrUser.user.Code).OrderBy(p => p.No).ToList();
            if (Interval.Count == 0)
            {
                Interval = AllInterval.Where(p => p.IsWesternMedicine == 0).OrderBy(p => p.Code).ToList().Select(p => new OP_UserInterval { Code = p.Code, Name = p.Name, No = 0, UserID = SysContext.CurrUser.user.Code }).ToList<OP_UserInterval>();
            }


            this.XY_colJG.DataSource = Interval;
            this.XY_colJG.DisplayMember = "Name";
            this.XY_colJG.ValueMember = "Code";
            DataTable dt = DBHelper.CIS.FromSql(string.Format("SELECT DISTINCT * FROM (SELECT * FROM ZY_YFSM WHERE YSGH='{0}' UNION ALL SELECT * FROM ZY_YFSM WHERE YSGH='9999' )A ", SysContext.CurrUser.user.Code)).ToDataTable();
            this.cbxUsageTips.DataSource = dt;
            this.cbxUsageTips.DisplayMember = "YFSM";
            this.cbxUsageTips.ValueMember = "ID";

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("需皮试", "Y");
            dict.Add("已皮试", "N");
            dict.Add("不需皮试", "X");
            BindingSource PSBZ = new BindingSource();//皮试标志
            this.XY_colPS.DisplayMember = "Key";
            this.XY_colPS.ValueMember = "Value";
            PSBZ.DataSource = dict;
            this.XY_colPS.DataSource = PSBZ;
        }

        /// <summary>
        /// 初始化组套信息
        /// </summary>
        private void InitGroupInfo()
        {
            DearWithGroupList = DBHelper.CIS.From<OP_DearWithGroup>().Where(x => x.Owner == "*" || x.Owner.Contains(SysContext.RunSysInfo.currDept.Code) || x.Owner == SysContext.RunSysInfo.user.ID).ToList();
            DrugGroupList = DBHelper.CIS.From<OP_DrugGroup>().Where(x => x.Owner == "*" || x.Owner == SysContext.RunSysInfo.currDept.Code || x.Owner == SysContext.RunSysInfo.user.ID).ToList();
            DealWithList = DBHelper.CIS.From<IView_Inside_DealWithItem>().Where(x => x.Owner == "*" || x.Owner.Contains(SysContext.RunSysInfo.currDept.Code) || x.Owner == SysContext.RunSysInfo.user.ID).ToList();
            DrugList = DBHelper.CIS.From<IView_Inside_DrugDetail>().Where(x => x.Owner == "*" || x.Owner == SysContext.RunSysInfo.currDept.Code || x.Owner == SysContext.RunSysInfo.user.ID || x.Owner == "*").ToList();
        }
        #endregion

        #region 治疗与材料组套操作
        /// <summary>
        /// 初始化治疗与材料组套Tree
        /// </summary>
        /// <param name="list"></param>
        private void InitDearWithGroupTree(List<OP_DearWithGroup> list)
        {
            treeDearWithGroup.Nodes.Clear();

            Node rootHospital = new Node();
            rootHospital.Text = "全院套餐";
            rootHospital.Tag = null;
            rootHospital.Image = global::App_OP.Properties.Resources._152;
            treeDearWithGroup.Nodes.Add(rootHospital);
            CreateDearWithGroupNode(rootHospital, "0", list.Where(x => x.GroupType == 0).ToList());

            Node rootDept = new Node();
            rootDept.Text = "科室套餐";
            rootDept.Tag = null;
            rootDept.Image = global::App_OP.Properties.Resources._152;
            treeDearWithGroup.Nodes.Add(rootDept);
            CreateDearWithGroupNode(rootDept, "0", list.Where(x => x.GroupType == 1).ToList());

            Node rootUser = new Node();
            rootUser.Text = "个人套餐";
            rootUser.Tag = null;
            rootUser.Image = global::App_OP.Properties.Resources._152;
            treeDearWithGroup.Nodes.Add(rootUser);
            CreateDearWithGroupNode(rootUser, "0", list.Where(x => x.GroupType == 2).ToList());

            rootDept.Expand();
            rootUser.Expand();
        }
        /// <summary>
        /// 创建治疗与材料树的子节点
        /// </summary>
        /// <param name="ParentNode"></param>
        /// <param name="ParentID"></param>
        /// <param name="subList"></param>
        private void CreateDearWithGroupNode(Node ParentNode, string ParentID, List<OP_DearWithGroup> subList)
        {
            List<OP_DearWithGroup> list = subList.Where(x => x.ParentID == ParentID).OrderBy(x => x.No).ToList();
            if (list.Count < 1 && ParentNode.Tag != null)//list.Count<1 则代表这个节点是最终分类既套餐名称  ParentNode.Tag != null代表不是根节点
            {
                //如果这个节点是套餐名称并且没有明细 则不显示checkBox
                ParentNode.CheckBoxVisible = DealWithList.Where(x => x.GroupID == (ParentNode.Tag as OP_DearWithGroup).ID).ToList().Count > 0;
                return;
            }

            foreach (OP_DearWithGroup item in list)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                ParentNode.Nodes.Add(node);
                node.Image = global::App_OP.Properties.Resources._152;
                List<IView_Inside_DealWithItem> itemList = DealWithList.Where(x => x.GroupID == item.ID).ToList();
                foreach (IView_Inside_DealWithItem detail in itemList)
                {
                    Node detailNode = new Node();
                    detailNode.Text = detail.Name + " [" + detail.Number.ToString() + detail.PackingUnit.AsString("").Trim() + "]";
                    detailNode.Tag = detail;
                    detailNode.CheckBoxVisible = true;
                    node.Nodes.Add(detailNode);
                }
                CreateDearWithGroupNode(node, item.ID, subList);  //递归创建下一级树
            }

        }
        private void treeDearWithGroup_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            Node node = e.Node;
            int x = e.Node.Bounds.X;
            if ((node.Tag as IView_Inside_DealWithItem) != null)//如果是套餐明细 则不论选中字或者checkBox 都将改变checkBox选中状态
            {
                if (e.X > x + 10)
                {
                    e.Node.Checked = !e.Node.Checked;
                }
            }
            else
            {
                if (e.X > x + 10)//如果是套餐名称则选中字 节点进行伸缩操作
                {
                    node.Expanded = !node.Expanded;
                }
                else//如果选中checkBox则对子节点进行选中或不选中操作
                {
                    foreach (Node childNode in node.Nodes)
                    {
                        childNode.Checked = node.Checked;
                    }
                }
            }
        }
        private void tbxSearchDearWith_TextChanged(object sender, EventArgs e)
        {
            string text = tbxSearchDearWith.Text.Trim().ToUpper();
            if (text.Length == 0)
            {
                InitDearWithGroupTree(DearWithGroupList);
            }
            else
            {
                List<OP_DearWithGroup> subList = DearWithGroupList.Where(x => x.Name.GetSpellCode().Contains(text) || x.Name.Contains(text)).ToList();
                InitDearWithGroupTree(subList);
            }
        }

        #endregion

        #region 西药组套以及中药膏方操作
        private void treeDrugGroup_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (e.Action == eTreeAction.Mouse)
            {
                if (e.Cell == null)
                {
                    return;
                }

                if (e.Cell.Parent.Tag.GetType() != typeof(IView_Inside_DrugDetail))
                {
                    return;
                }

                Node parent = e.Cell.Parent.Parent;
                string tzbh = (e.Cell.Parent.Tag as IView_Inside_DrugDetail).GroupNo.AsString("0");
                if (tzbh == null || tzbh == "0" || tzbh == "")
                {
                    return;
                }

                foreach (Node item in parent.Nodes)
                {
                    if ((item.Tag as IView_Inside_DrugDetail).GroupNo == tzbh)
                    {
                        item.Checked = e.Cell.Parent.Checked;
                    }
                }
            }
        }

        /// <summary>
        /// 初始化医药组套Tree
        /// </summary>
        /// <param name="tree">操作的advTree</param>
        /// <param name="list">药品组套列表</param>
        /// <param name="drugType">药品类别 1西（成）药 2草药</param>
        private void InitDrugGroupTree(AdvTree tree, List<OP_DrugGroup> list, int drugType)
        {
            tree.Nodes.Clear();

            Node rootHospital = new Node();
            rootHospital.Text = "全院套餐";
            rootHospital.Tag = null;
            rootHospital.Image = global::App_OP.Properties.Resources._152;
            tree.Nodes.Add(rootHospital);
            CreateDrugGroupNode(rootHospital, "0", list.Where(x => x.GroupType == 0 && x.DrugType == drugType).ToList());

            Node rootDept = new Node();
            rootDept.Text = "科室套餐";
            rootDept.Tag = null;
            rootDept.Image = global::App_OP.Properties.Resources._152;
            tree.Nodes.Add(rootDept);
            CreateDrugGroupNode(rootDept, "0", list.Where(x => x.GroupType == 1 && x.DrugType == drugType).ToList());

            Node rootUser = new Node();
            rootUser.Text = "个人套餐";
            rootUser.Tag = null;
            rootUser.Image = global::App_OP.Properties.Resources._152;
            tree.Nodes.Add(rootUser);
            CreateDrugGroupNode(rootUser, "0", list.Where(x => x.GroupType == 2 && x.DrugType == drugType).ToList());

            rootDept.Expand();
            rootUser.Expand();
        }
        private void treeHerbsGroup_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            Node node = e.Node;
            int x = e.Node.Bounds.X;
            if ((node.Tag as IView_Inside_DrugDetail) != null)
            {
                if (e.X > x + 10)
                {
                    e.Node.Checked = !e.Node.Checked;
                }
            }
            else
            {
                if (e.X > x + 10)
                {
                    node.Expanded = !node.Expanded;
                }
                else
                {
                    foreach (Node childNode in node.Nodes)
                    {
                        childNode.Checked = node.Checked;
                    }
                }
            }
        }
        private void CreateDrugGroupNode(Node ParentNode, string ParentID, List<OP_DrugGroup> subList)
        {
            List<OP_DrugGroup> list = subList.Where(x => x.ParentID == ParentID).OrderBy(x => x.No).ToList();
            if (list.Count < 1 && ParentNode.Tag != null)//list.Count<1 则代表这个节点是最终分类既套餐名称  ParentNode.Tag != null代表不是根节点
            {
                //如果这个节点是套餐名称并且没有明细 则不显示checkBox
                ParentNode.CheckBoxVisible = DrugList.Where(x => x.GroupID == (ParentNode.Tag as OP_DrugGroup).ID).ToList().Count > 0;
                return;
            }

            foreach (OP_DrugGroup item in list)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                node.Image = Properties.Resources._152;
                ParentNode.Nodes.Add(node);
                List<IView_Inside_DrugDetail> itemList = DrugList.Where(x => x.GroupID == item.ID).OrderBy(p => p.No).ToList();
                foreach (IView_Inside_DrugDetail detail in itemList)
                {
                    Node detailNode = new Node();
                    detailNode.Text = detail.DrugName + " [" + detail.Specification.AsString("").Trim() + " × " + detail.Num.ToString() + detail.PackingUnit.AsString("").Trim() + "]";
                    detailNode.Tag = detail;
                    detailNode.CheckBoxVisible = true;
                    node.Nodes.Add(detailNode);
                }
                DrawTZLine(node);
                CreateDrugGroupNode(node, item.ID, subList);
            }

        }
        private void treeDrugGroup_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            Node node = e.Node;
            int x = e.Node.Bounds.X;
            if ((node.Tag as IView_Inside_DrugDetail) != null)
            {
                if (e.X > x + 10)
                {
                    e.Node.Checked = !e.Node.Checked;
                    treeDrugGroup_AfterCheck(node, new AdvTreeCellEventArgs(eTreeAction.Mouse, this.treeDrugGroup.GetCellAt(e.X, e.Y)));
                }
            }
            else
            {
                if (e.X > x + 10)
                {
                    node.Expanded = !node.Expanded;
                }
                else
                {
                    foreach (Node childNode in node.Nodes)
                    {
                        childNode.Checked = node.Checked;
                    }
                }
            }
        }
        private void tbxSearchDrug_TextChanged(object sender, EventArgs e)
        {
            string text = tbxSearchDrug.Text.Trim().ToUpper();
            SearchDrugGroup(treeDrugGroup, text, 1);
        }
        private void tbxSearchHerbs_TextChanged(object sender, EventArgs e)
        {
            string text = tbxSearchHerbs.Text.Trim().ToUpper();
            SearchDrugGroup(treeHerbsGroup, text, 2);
        }
        private void SearchDrugGroup(AdvTree tree, string text, int drugType)
        {
            if (text.Length == 0)
            {
                InitDrugGroupTree(tree, DrugGroupList, drugType);
            }
            else
            {
                List<OP_DrugGroup> subList = DrugGroupList.Where(x => x.Name.GetSpellCode().Contains(text) || x.Name.Contains(text)).ToList();
                InitDrugGroupTree(tree, subList, drugType);
            }
        }

        #endregion

        #region 西药处方操作
        private void dgvWesternMedicine_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int groupNo = this.dgvWesternMedicine.Rows[e.RowIndex].Cells["XY_colTZBH"].Value.AsInt(0);
            if (groupNo == 0)
            {
                return;
            }

            this.dgvWesternMedicine.ClearSelection();
            foreach (DataGridViewRow item in this.dgvWesternMedicine.Rows)
            {
                if (item.Cells["XY_colTZBH"].Value.AsInt(0) == groupNo)
                {
                    item.Selected = true;
                }
            }
        }

        /// <summary>
        /// 处方向上移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvWesternMedicine.SelectedRows;
            if (rows == null)
            {
                return;
            }

            int min = rows.Cast<DataGridViewRow>().Min(p => p.Index);
            int max = rows.Cast<DataGridViewRow>().Max(p => p.Index);
            if (min == 0)
            {
                return;
            }

            List<int> listGroup = rows.Cast<DataGridViewRow>().Select(p => p.Cells["XY_colTZBH"].Value.AsInt(0)).Distinct().ToList();
            //1.不是同组内,往上移就不能移动到组内
            if (listGroup.Where(p => p == 0).Count() == 1)
            {

                if (this.dgvWesternMedicine.Rows[min - 1].Cells["XY_colTZBH"].Value.AsInt(0) != 0)
                {
                    return;
                }

                DataGridViewRow row = this.dgvWesternMedicine.Rows[min - 1];

                this.dgvWesternMedicine.Rows.Remove(row);
                this.dgvWesternMedicine.Rows.Insert(max, row);
            }
            else if (listGroup.Where(p => p != 0).Count() == 1)
            {
                //2.是一个同组内的,往上移就不能移动到别的组内
                if (this.dgvWesternMedicine.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["XY_colTZBH"].Value.AsInt(0) == listGroup[0]).Count() != rows.Count)
                {
                    if (this.dgvWesternMedicine.Rows[min - 1].Cells["XY_colTZBH"].Value.AsInt(0) != this.dgvWesternMedicine.Rows[min].Cells["XY_colTZBH"].Value.AsInt(0))
                    {
                        return;
                    }

                    DataGridViewRow row = this.dgvWesternMedicine.Rows[min - 1];

                    this.dgvWesternMedicine.Rows.Remove(row);
                    this.dgvWesternMedicine.Rows.Insert(max, row);
                }
                //3.是同组内,并且是整个同组
                else
                {
                    DataGridViewRow row = this.dgvWesternMedicine.Rows[min - 1];
                    int groupNo = row.Cells["XY_colTZBH"].Value.AsInt(0);
                    if (groupNo == 0)
                    {
                        return;
                    }

                    List<DataGridViewRow> tmp = this.dgvWesternMedicine.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["XY_colTZBH"].Value.AsInt(0) == groupNo).ToList();

                    foreach (DataGridViewRow item in tmp)
                    {
                        this.dgvWesternMedicine.Rows.Remove(item);
                        this.dgvWesternMedicine.Rows.Insert(max, item);
                    }
                }
                DrawGroupLine();

            }
        }

        /// <summary>
        /// 处方向下移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvWesternMedicine.SelectedRows;
            if (rows == null)
            {
                return;
            }

            int min = rows.Cast<DataGridViewRow>().Min(p => p.Index);
            int max = rows.Cast<DataGridViewRow>().Max(p => p.Index);
            if (max == this.dgvWesternMedicine.Rows.Count - 1)
            {
                return;
            }

            List<int> listGroup = rows.Cast<DataGridViewRow>().Select(p => p.Cells["XY_colTZBH"].Value.AsInt(0)).Distinct().ToList();
            //1.不是同组内,往下移就不能移动到组内
            if (listGroup.Where(p => p == 0).Count() == 1)
            {

                if (this.dgvWesternMedicine.Rows[max + 1].Cells["XY_colTZBH"].Value.AsInt(0) != 0)
                {
                    return;
                }

                DataGridViewRow row = this.dgvWesternMedicine.Rows[max + 1];

                this.dgvWesternMedicine.Rows.Remove(row);
                this.dgvWesternMedicine.Rows.Insert(min, row);
            }
            else if (listGroup.Where(p => p != 0).Count() == 1)
            {
                //2.是一个同组内的,往下移就不能移动到别的组内
                if (this.dgvWesternMedicine.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["XY_colTZBH"].Value.AsInt(0) == listGroup[0]).Count() != rows.Count)
                {
                    if (this.dgvWesternMedicine.Rows[max + 1].Cells["XY_colTZBH"].Value.AsInt(0) != this.dgvWesternMedicine.Rows[max].Cells["XY_colTZBH"].Value.AsInt(0))
                    {
                        return;
                    }

                    DataGridViewRow row = this.dgvWesternMedicine.Rows[max + 1];

                    this.dgvWesternMedicine.Rows.Remove(row);
                    this.dgvWesternMedicine.Rows.Insert(min, row);
                }
                //3.是同组内,并且是整个同组
                else
                {
                    DataGridViewRow row = this.dgvWesternMedicine.Rows[max + 1];
                    int groupNo = row.Cells["XY_colTZBH"].Value.AsInt(0);
                    if (groupNo == 0)
                    {
                        return;
                    }

                    List<DataGridViewRow> tmp = this.dgvWesternMedicine.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["XY_colTZBH"].Value.AsInt(0) == groupNo).ToList();

                    foreach (DataGridViewRow item in tmp)
                    {
                        this.dgvWesternMedicine.Rows.Remove(item);
                        this.dgvWesternMedicine.Rows.Insert(min, item);
                    }
                }
                DrawGroupLine();
            }
        }

        /// <summary>
        /// 从同组中取消单项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSingleGroupCancel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvWesternMedicine.SelectedRows;
            if (rows == null)
            {
                return;
            }

            //获得所有不相同的同组编号,去除不同组的编号
            List<int> listGroupNo = new List<int>();
            listGroupNo.AddRange(this.dgvWesternMedicine.Rows.Cast<DataGridViewRow>().Select(p => p.Cells["XY_colTZBH"].Value.AsInt(0)).Distinct());
            listGroupNo.Remove(0);

            //将选中的行,同组编号设置为0
            foreach (DataGridViewRow item in rows)
            {
                item.Cells["XY_colTZBH"].Value = 0;
                this.dgvWesternMedicine.Rows.Remove(item);
                this.dgvWesternMedicine.Rows.Insert(this.dgvWesternMedicine.Rows.Count, item);
            }

            //如果一个组里面只剩一个项目,那么把它的同组编号也设置为0
            foreach (var item in listGroupNo)
            {
                List<DataGridViewRow> tmp = this.dgvWesternMedicine.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["XY_colTZBH"].Value.AsInt(0) == item).ToList();
                if (tmp.Count == 1)
                {
                    tmp[0].Cells["XY_colTZBH"].Value = 0;
                    this.dgvWesternMedicine.Rows.Remove(tmp[0]);
                    this.dgvWesternMedicine.Rows.Insert(this.dgvWesternMedicine.Rows.Count, tmp[0]);
                }
            }
            DrawGroupLine();
        }

        private void btnLisResult_Click(object sender, EventArgs e)
        {
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                AlertBox.Info("请先选择病人");
                return;
            }
            FormLISResult form = new FormLISResult(formMain);
            form.search = true;
            form.ShowDialog();
        }

        private void btnPacsResult_Click(object sender, EventArgs e)
        {
            //if (!CIS.Core.SysContext.Session.ContainsKey("CurrPatient"))
            //{
            //    CIS.Core.AlertBox.Info("请先选择病人");
            //    return;
            //}
            //string url = string.Format("http://192.168.1.233:8080/PacsWebDisplay/PacsWebDisplay/PacsWebDisplay.action?ClinicPatientID={0}", SysContext.GetCurrPatient.OutpatientNo);
            //Process.Start(url);
            FormRISResult result = new FormRISResult();
            result.ShowDialog();
        }

        private void dgvWesternMedicine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvWesternMedicineDetail.Visible || this.dgvHerbalMedicineDetail.Visible || this.dgvDiagnoseDetail.Visible)
            {
                this.dgvDiagnoseDetail.Hide();
                this.dgvHerbalMedicineDetail.Hide();
                this.dgvWesternMedicineDetail.Hide();
            }
            DataGridViewX dgv = sender as DataGridViewX;

            if (dgv == this.dgvWesternMedicine)
            {


                string tzbh = this.dgvWesternMedicine.Rows[e.RowIndex].Cells["XY_colTZBH"].Value.AsString("0");
                if (tzbh != "0")
                {
                    string JG = this.dgvWesternMedicine.Rows[e.RowIndex].Cells["XY_colJG"].Value.ToString();
                    string YF = this.dgvWesternMedicine.Rows[e.RowIndex].Cells["XY_colYF"].Value.ToString();
                    string TS = this.dgvWesternMedicine.Rows[e.RowIndex].Cells["XY_colTS"].Value.ToString();
                    if (e.ColumnIndex == this.XY_colJG.Index || e.ColumnIndex == this.XY_colYF.Index || e.ColumnIndex == this.XY_colTS.Index)
                    {
                        foreach (DataGridViewRow item in this.dgvWesternMedicine.Rows)
                        {
                            if (item.Cells["XY_colTZBH"].Value.ToString() == tzbh)
                            {
                                item.Cells["XY_colJG"].Value = JG;
                                item.Cells["XY_colYF"].Value = YF;
                                item.Cells["XY_colTS"].Value = TS;
                            }
                        }
                    }
                }
                if (e.ColumnIndex == this.XY_colSL.Index)
                {
                    dgv.Rows[e.RowIndex].Cells["XY_colZJE"].Value = dgv.Rows[e.RowIndex].Cells["XY_colSL"].Value.AsInt(0) * dgv.Rows[e.RowIndex].Cells["XY_colLSJ"].Value.AsFloat(0);
                    ColculateAllItemTotal();
                }
            }
            else if (dgv == this.dgvHerbalMedicine)
            {
                if (e.ColumnIndex == this.CY_colSL.Index)
                {
                    dgv.Rows[e.RowIndex].Cells["CY_colZJE"].Value = dgv.Rows[e.RowIndex].Cells["CY_colSL"].Value.AsInt(0) * dgv.Rows[e.RowIndex].Cells["CY_colLSJ"].Value.AsFloat(0);
                    ColculateAllItemTotal();
                }
                else if (e.ColumnIndex == this.CY_colYL11.Index || e.ColumnIndex == this.CY_colTS.Index)
                {
                    int num = this.inputHerbalMedicineNum.Text.AsInt(1) * this.dgvHerbalMedicine.Rows[e.RowIndex].Cells["CY_colYL11"].Value.AsInt(1); //ColculateCYSL(this.dgvCY.Rows[e.RowIndex].Cells["CY_colYL"].Value.ToString(), this.dgvCY.Rows[e.RowIndex].Cells["CY_colYL11"].Value.ToString());
                    this.dgvHerbalMedicine.Rows[e.RowIndex].Cells["CY_colSL"].Value = num;
                }
            }
            else
            {
                if (e.ColumnIndex == this.ZL_colSL.Index)
                {
                    dgv.Rows[e.RowIndex].Cells["ZL_colZJE"].Value = dgv.Rows[e.RowIndex].Cells["ZL_colSL"].Value.AsInt(0) * dgv.Rows[e.RowIndex].Cells["ZL_colLSJ"].Value.AsFloat(0);
                    ColculateAllItemTotal();
                }
            }
        }

        /// <summary>
        /// 西药处方 新增处方点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                AlertBox.Info("请先选择病人");
                return;
            }
            if (CurrentDiagnosisCount == 0)
            {
                AlertBox.Info("当前诊断为空,无法开处方");
                return;
            }
            var tag = (sender as ButtonItem).Tag.AsInt(0);
            if (tag == (int)PrescriptionType.Chronic)
            {
                if (ChronicCode == "")
                {
                    AlertBox.Info("当前慢性病诊断为空,无法开慢性病处方");
                    return;
                }
            }

            if (tag == (int)PrescriptionType.JingmaYi)
            {
                var agentName = DBHelper.CIS.From<OP_Journal>().Where(p => p.OutpatientNo == SysContext.GetCurrPatient.OutpatientNo).Select(p => p.AgentName).ToScalar<string>();
                if (agentName == null)
                {
                    FormAddAgent form = new FormAddAgent();
                    if (form.ShowDialog() != DialogResult.OK)
                    {
                        AlertBox.Info("未填写代办人信息，无法开立精麻一处方");
                        return;
                    }
                }
            }
            this.dgvWesternMedicine.Rows.Clear();
            int index = this.dgvWesternMedicine.Rows.Add();
            InitXYBar(true);
            CurrentWesternMedicinePrescriptionType = (PrescriptionType)tag;
            this.btnXYSave.Tag = tag;
            this.dgvWesternMedicine.CurrentCell = this.dgvWesternMedicine.Rows[index].Cells["XY_colName"];
            this.dgvWesternMedicine.BeginEdit(true);
            CurrentWMPrescriptionNo = "";
            CurrPatientPrescription = null;
            ColculateAllItemTotal();
        }

        /// <summary>
        /// 西药 展开处方类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXYNew_Click(object sender, EventArgs e)
        {
            (sender as ButtonItem).Expanded = true;
        }

        /// <summary>
        /// 西药 保存处方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private (OP_Prescription, List<OP_Prescription_Detail>) btnXYSave_Click(object sender, EventArgs e)
        {
            if (this.dgvWesternMedicine.Rows.Count == 0)
            {
                return (null, null);
            }

            string msg;
            this.dgvWesternMedicine.EndEdit();
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                AlertBox.Info("请先选择病人");
                return (null, null);
            }
            if (this.dgvWesternMedicine.Rows[this.dgvWesternMedicine.Rows.Count - 1].Cells["XY_colName"].Value == null && this.dgvWesternMedicine.Rows[this.dgvWesternMedicine.Rows.Count - 1].Cells["XY_colGG"].Value == null)
            {
                this.dgvWesternMedicine.Rows.RemoveAt(this.dgvWesternMedicine.Rows.Count - 1);
            }

            if (this.dgvWesternMedicine.Rows.Count == 0)
            {
                return (null, null);
            }

            foreach (DataGridViewRow item in this.dgvWesternMedicine.Rows)
            {
                if (item.Cells["XY_colGG"].Value == null)
                {
                    continue;
                }

                if (!XYValidate(item, out msg, true)) //进行西药的验证
                {
                    AlertBox.Info("在指定位置有数据验证失败" + msg);
                    return (null, null);
                }
                ColculateXYZJE(item);
            }
            if (SysContext.CurrUser.Params.OP_SwitchMedicalInsurance == "是")
            {
                string json = GetPatientMedicalInsuranceBasicJson(Guid.NewGuid().ToString(), ColculateAllItemTotal("XY").ToString(), this.dgvWesternMedicine, "0");

                Uri.EscapeUriString(json);

                string result = HTTPHelper.HttpPost("http://192.168.1.228:8080/MMAP/RuleEngine.do", json);
                MedicalInsuranceDrugResult DrugResult = SerializeHelper.BeginJsonDeserialize<MedicalInsuranceDrugResult>(result);
                if (DrugResult != null && DrugResult.code == "200" && DrugResult.showflag == "1")
                {
                    FormMedicalInsurance form = new FormMedicalInsurance();
                    form.result = DrugResult;
                    if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        CurrentWMPrescriptionNo = "";
                        return (null, null);
                    }
                }
            }

            bool IsHave = CurrentWMPrescriptionNo == "" ? false : true;
            if (CurrentWMPrescriptionNo == "")
            {
                CurrentWMPrescriptionNo = Guid.NewGuid().ToString();
            }

            int Count = 1;
            DateTime now = DateTime.Now;
            //if (!ShowPrescriptionAdditional(CurrentWMPrescriptionNo))
            //{
            //    CIS.Core.AlertBox.Info("用户手动退出加收项目列表,保存失败");
            //    return;
            //}

            List<OP_Prescription_Detail> detail = new List<OP_Prescription_Detail>();

            List<OP_Prescription_Detail> update = new List<OP_Prescription_Detail>();
            List<OP_Prescription_Detail> insert = new List<OP_Prescription_Detail>();

            foreach (DataGridViewRow item in this.dgvWesternMedicine.Rows)
            {
                //if (item.Cells["XY_colYPHH"].Value != null)
                //{
                //    string sql = string.Format("UPDATE YF_DTKC SET NYL=NYL+{0} WHERE YPHH='{1}' AND YPID='{2}'", item.Cells["XY_colSL"].Value.ToString(), item.Cells["XY_colYPHH"].Value.ToString(), item.Cells["XY_colYPID"].Value.ToString());
                //    DBHelper.CIS.FromSql(sql).ToScalar();
                //}

                if (item.Cells["XY_colGG"].Value == null)
                {
                    continue;
                }

                OP_Prescription_Detail Prescription = ControlHelper.FillModel<OP_Prescription_Detail>(item);
                if (item.Index + 1 > Count)
                    Count = item.Index + 1;

                string itemId = item.Cells[XY_colYPID.Index].Value.AsString();
                var tag = WesternMedicineInfo.Find(p => p.DrugID == itemId);
                InitPrescriptionDetail(ref Prescription, tag.DrugCategory.AsString("1").Contains("7") ? "2" : "1", CurrentWMPrescriptionNo, item.Index + 1, now);
                detail.Add(Prescription);
                if (Prescription.ID == null)
                {
                    Prescription.ID = Guid.NewGuid().ToString();
                    item.Cells["XY_colID"].Value = Prescription.ID;

                    insert.Add(Prescription);
                }
                else
                    update.Add(Prescription);
            }

            var details = insert.Union(update);

            string prescriptionType;
            if (sender == this.btnXYSave)
                prescriptionType = ((int)CurrentWesternMedicinePrescriptionType).ToString();
            else if (sender == this.btnCYSave)
                prescriptionType = ((int)CurrentHerbalMedicinePrescriptionType).ToString();
            else
                prescriptionType = ((int)CurrentDiagnosePrescriptionType).ToString();

            OP_Prescription tmp = InitPrescription(CurrentWMPrescriptionNo, prescriptionType, Count, now);
            tmp.Status = 1;

            if (SysContext.CurrUser.Params.OP_BeforePrescriptionAudit)
            {
                var audit = _beforePrescriptionAudit.FillPatientInfo();
                audit = _beforePrescriptionAudit.FillDiagnosis(audit, formMain.GEtDiagnosis());
                audit = _beforePrescriptionAudit.FillPrescription(audit, details, tmp);
                var auditResult = _beforePrescriptionAudit.Post(audit);
                if (auditResult == null)
                {
                    return (null, null);
                }
                else
                {
                    if (!auditResult.Success)
                    {
                        FormBeforePrescriptionAudit form = new FormBeforePrescriptionAudit();
                        form.Init(auditResult);
                        if (form.ShowDialog() != DialogResult.Abort)
                        {
                            return (null, null);
                        }
                    }
                }
            }

            using (var tran = DBHelper.CIS.BeginTransaction())
            {
                int data = 0;
                try
                {
                    if (IsHave)
                        data = tran.Update<OP_Prescription>(tmp, p => p.PrescriptionNo == CurrentWMPrescriptionNo && p.TreatmentNo == (SysContext.Session["CurrPatient"] as IView_HIS_Outpatients).OutpatientNo);
                    else
                        data = tran.Insert<OP_Prescription>(tmp);

                    tran.Update(update);
                    tran.Insert(insert);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存西药", SerializeHelper.BeginJsonSerializable(tmp), data > 0 ? "处方保存成功！" : "处方保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
                }

            }

            SavePrescriptionChronic(tmp.PrescriptionNo);


            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.Prescription });
            CurrentWMPrescriptionNo = "";
            CurrPatientPrescription = null;
            this.dgvWesternMedicine.Rows.Clear();

            return (tmp, details.ToList());
        }

        /// <summary>
        /// 生成处方从表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="PrescriptionType"></param>
        /// <param name="PrescriptionNo"></param>
        /// <param name="No"></param>
        private void InitPrescriptionDetail(ref OP_Prescription_Detail model, string PrescriptionType, string PrescriptionNo, int No, DateTime time)
        {
            if (model.ExecuteDept == null || model.ExecuteDept == "")
            {
                model.ExecuteDept = SysContext.RunSysInfo.currDept.Code;
            }

            model.PrescriptionNo = PrescriptionNo;
            var drugId = model.ItemCode;
            //if (PrescriptionType == "1" || PrescriptionType == "2")
            //{
            //    var tempDrug = WesternMedicineInfo.Where(p => p.DrugID == drugId).ToList();
            //    if (tempDrug.Count > 0)
            //    {
            //        if (tempDrug[0].DrugCategory.Contains("7") && PrescriptionType == "1")
            //        {
            //            Log4Helper.WriteLog(typeof(OP_Prescription_Detail), new CIS.Core.Interceptors.LogMessage("中成药药品属性配置错误", $"药品id{drugId},传入类别{PrescriptionType},转换前的itemType为{model.ItemType}", ""), Log4NetLevel.Warn);
            //            model.ItemType = "2";
            //        }
            //        else
            //        {
            //            model.ItemType = tempDrug[0].DrugCategory.Contains("7") ? "2" : "1";
            //        }

            //    }
            //    else
            //    {
            //        Log4Helper.WriteLog(typeof(OP_Prescription_Detail), new CIS.Core.Interceptors.LogMessage("无法搜索到药品，传递当前配置的参数", $"药品id{drugId},传入类别{PrescriptionType}", ""), Log4NetLevel.Warn);
            //        model.ItemType = PrescriptionType;
            //    }
            //}
            //else
            //{
            model.ItemType = PrescriptionType;
            //  }
            model.No = No;
            model.PatientID = (SysContext.Session["CurrPatient"] as IView_HIS_Outpatients).PatientID;
            model.TreatmentNo = (SysContext.Session["CurrPatient"] as IView_HIS_Outpatients).OutpatientNo;
            model.UpdateTime = time;
        }

        /// <summary>
        /// 生成处方主表
        /// </summary>
        /// <param name="PrescriptionNo">处方编号</param>
        /// <param name="PrescriptionType">处方类型</param>
        /// <param name="Count">处方数量</param>
        private OP_Prescription InitPrescription(string PrescriptionNo, string PrescriptionType, int Count, DateTime time)
        {
            OP_Prescription tmp = new OP_Prescription();
            tmp.DeptCode = SysContext.RunSysInfo.currDept.Code;
            tmp.PatientID = (SysContext.Session["CurrPatient"] as IView_HIS_Outpatients).PatientID;
            tmp.PrescriptionNo = PrescriptionNo;
            tmp.TreatmentNo = (SysContext.Session["CurrPatient"] as IView_HIS_Outpatients).OutpatientNo;
            tmp.UserID = SysContext.CurrUser.user.Code;
            tmp.ID = Guid.NewGuid().ToString();
            tmp.PrescriptionType = PrescriptionType;
            tmp.RecordNumber = Count;
            tmp.UpdateTime = time;
            tmp.DiagnosisName = CurrentDiagnosisName;
            tmp.PatientName = SysContext.GetCurrPatient.PatientName;
            tmp.IDCard = SysContext.GetCurrPatient.IDCard;
            tmp.CardNo = SysContext.GetCurrPatient.CardNo;
            tmp.UserName = SysContext.CurrUser.user.Name;
            tmp.PayType = SysContext.GetCurrPatient.PayType;
            tmp.Age = SysContext.GetCurrPatient.Age;
            tmp.Sex = SysContext.GetCurrPatient.Sex;
            tmp.UserName = SysContext.CurrUser.user.Name;

            //更新处方单号列表
            List<int> HISInterface_PrescriptionNo = DBHelper.CIS.From<OP_Prescription>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo).Select(p => p.HISInterface_PrescriptionNo).ToList<int>();
            if (HISInterface_PrescriptionNo.Count == 0)
            {
                tmp.HISInterface_PrescriptionNo = 1;
            }
            else
                tmp.HISInterface_PrescriptionNo = HISInterface_PrescriptionNo.Max() + 1;

            return tmp;
        }

        /// <summary>
        /// 保存该处方的慢性病信息
        /// </summary>
        /// <param name="PrescriptionNo">处方编号</param>
        private void SavePrescriptionChronic(string PrescriptionNo)
        {
            if (ChronicCode == "")
            {
                return;
            }

            OP_Prescription_Chronic tmp = new OP_Prescription_Chronic();
            tmp.ID = Guid.NewGuid().ToString();
            tmp.PrescriptionCode = PrescriptionNo;
            tmp.ChronicCode = ChronicCode;
            tmp.ChronicName = ChronicName;
            tmp.ChronicType = ChronicType;
            var data = DBHelper.CIS.Insert<OP_Prescription_Chronic>(tmp);
            CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存处方的慢性病信息", SerializeHelper.BeginJsonSerializable(tmp), data > 0 ? "保存成功！" : "保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
        }

        /// <summary>
        /// 西药 文本框改变时过滤药品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWesternMedicine_Text_Changed(object sender, EventArgs e)
        {
            if (this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colName")
            {
                string InputStr = (sender as TextBox).Text.ToUpper();
                if (InputStr == "")
                {
                    this.dgvWesternMedicineDetail.Hide();
                    return;
                }
                List<IView_HIS_DrugInfo> Tmp;
                //if (this.cbxShowReserveIsNotZero.Checked)
                Tmp = WesternMedicineInfo.Where(p => (p.SearchCode.Contains(InputStr) || p.DrugName.Contains(InputStr) || p.WubiCode.Contains(InputStr)) && p.Reserve > 0).ToList();
                Tmp = Tmp.OrderBy(p => p.NickName.Length).ToList();
                //else
                //Tmp = WesternMedicineInfo.Where(p => p.SearchCode.Contains(InputStr) || p.DrugName.Contains(InputStr) || p.WubiCode.Contains(InputStr)).ToList();

                ColculateDetailDGVTop();
                this.dgvWesternMedicineDetail.DataSource = Tmp;
                this.dgvWesternMedicineDetail.Show();
            }
        }

        private void ColculateDetailDGVTop()
        {
            Rectangle rect = this.dgvWesternMedicine.GetCellDisplayRectangle(this.dgvWesternMedicine.CurrentCell.ColumnIndex, this.dgvWesternMedicine.CurrentCell.RowIndex, false);
            Point p1 = this.dgvWesternMedicine.PointToScreen(new Point(rect.X, rect.Y));
            Point p2 = this.superTabControlPanel1.PointToClient(p1);

            ColculateDetailDGVTop(p2.Y, rect.Height, this.dgvWesternMedicineDetail);
        }

        private void ColculateDetailDGVTop(int CellTop, int CellHeight, DataGridViewX dgv)
        {
            int sub = this.superTabControlPanel1.Height - CellTop - CellHeight;
            if (sub > CellTop)
            {
                dgv.Top = CellTop + CellHeight;
                this.controlAmpoule1.Top = CellTop + CellHeight;
                dgv.Height = sub - 5;
            }
            else
            {
                dgv.Top = 0;
                this.controlAmpoule1.Top = CellTop - this.controlAmpoule1.Height;
                dgv.Height = CellTop;
            }

        }

        /// <summary>
        /// 西药 文本框按下键时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWesternMedicine_TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (this.dgvWesternMedicine.CurrentCell.IsInEditMode && this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colName")
                {
                    CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(this.dgvWesternMedicineDetail.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_KEYDOWN, e.KeyValue, 0);
                    e.SuppressKeyPress = false;
                }
                else if (e.KeyCode == Keys.Down && this.dgvWesternMedicine.CurrentCell.IsInEditMode && this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colYL")
                {
                    this.controlAmpoule1.BeginEdit();
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (WMKeyDown)
                    {
                        WMKeyDown = false;
                        e.SuppressKeyPress = false;
                    }
                    else
                    {
                        WMKeyDown = true;
                        DataGridViewCell cell = this.dgvWesternMedicine.CurrentCell;
                        if (cell.OwningRow.Index > 0 && e.KeyCode == Keys.Up)
                            this.dgvWesternMedicine.CurrentCell = this.dgvWesternMedicine.Rows[cell.OwningRow.Index - 1].Cells[cell.ColumnIndex];
                        else if (cell.OwningRow.Index < this.dgvWesternMedicine.Rows.Count - 1 && e.KeyCode == Keys.Down)
                            this.dgvWesternMedicine.CurrentCell = this.dgvWesternMedicine.Rows[cell.OwningRow.Index + 1].Cells[cell.ColumnIndex];
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colName" && this.dgvWesternMedicine.CurrentCell.EditedFormattedValue.AsString("") == "")
                {
                    return;
                }

                if (this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colName" && this.dgvWesternMedicine.CurrentCell.IsInEditMode && !this.dgvWesternMedicineDetail.Visible)
                {
                    return;
                }

                if (this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colName" && this.dgvWesternMedicineDetail.Visible)
                {
                    if (this.dgvWesternMedicineDetail.SelectedRows.Count == 0)
                    {
                        return;
                    }

                    ImportYPToDGV(this.dgvWesternMedicine.CurrentCell.OwningRow, this.dgvWesternMedicineDetail.SelectedRows[0], false, false);
                    this.dgvWesternMedicineDetail.Hide();
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (this.dgvWesternMedicine.CurrentCell != null || this.dgvWesternMedicine.CurrentCell.ColumnIndex < this.dgvWesternMedicine.ColumnCount)
                    {
                        //循环到下一个可编辑的单元格内
                        DataGridViewCell cell = this.dgvWesternMedicine.CurrentCell.OwningRow.Cells[this.dgvWesternMedicine.CurrentCell.ColumnIndex + 1];
                        while (cell.ReadOnly)
                        {
                            cell = cell.OwningRow.Cells[cell.ColumnIndex + 1];
                        }
                        //如果单元格不可见并且可以回车换行并且换行点为最后一列则加一行
                        if (!cell.Visible && SysContext.CurrUser.Params.OP_Enter_Position == "最后一列" && SysContext.CurrUser.Params.OP_CanEnter)
                        {
                            btnXYAdd_Click(null, null);
                            return;
                        }

                        if (!cell.Visible)
                        {
                            return;
                        }

                        this.dgvWesternMedicine.CurrentCell = cell;
                        this.dgvWesternMedicine.BeginEdit(true);
                        if (cell.OwningColumn.HeaderText == SysContext.CurrUser.Params.OP_Enter_Position && SysContext.CurrUser.Params.OP_CanEnter)
                        {
                            btnXYAdd_Click(null, null);
                        }
                    }
                }
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) && this.dgvWesternMedicineDetail.Visible)
            {
                this.dgvWesternMedicineDetail.Hide();
            }
        }

        private void btnXYAdd_Click(object sender, EventArgs e)
        {
            this.dgvWesternMedicine.EndEdit();
            string msg;
            foreach (DataGridViewRow item in this.dgvWesternMedicine.Rows)
            {
                if (!XYValidate(item, out msg))
                {
                    AlertBox.Info("在指定位置有数据验证失败" + msg);
                    return;
                }
                ColculateXYZJE(item);
            }
            if (this.dgvWesternMedicine.Rows.Count > MaxWMCount)
            {
                AlertBox.Info("西药处方已经超过大处方限制,只可开具" + MaxWMCount.ToString() + "个药");
                return;
            }
            int index = this.dgvWesternMedicine.Rows.Add();
            this.dgvWesternMedicine.CurrentCell = this.dgvWesternMedicine.Rows[index].Cells["XY_colName"];

            this.dgvWesternMedicine.BeginEdit(true);

        }

        private void btnXYDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvWesternMedicine.SelectedRows;
            int num = 0;
            foreach (DataGridViewRow item in rows)
            {
                if (item.Cells["XY_colGG"].Value == null)
                {
                    this.dgvWesternMedicine.Rows.Remove(item);
                    return;
                }
                if (item.Cells["XY_colTZBH"].Value.ToString() != "0")
                {
                    AlertBox.Info("欲删除的行中有已同组项目,请先解除同组");
                    return;
                }
                if (item.Cells["XY_colID"].Value != null)
                {
                    DBHelper.CIS.Delete<OP_Prescription_Detail>(p => p.ID == item.Cells["XY_colID"].Value.ToString());
                }

                this.dgvWesternMedicine.Rows.Remove(item);
            }

            foreach (DataGridViewRow item in this.dgvWesternMedicine.Rows)
            {
                if (item.Cells["XY_colGG"].Value != null)
                {
                    num++;
                }
            }
            DBHelper.CIS.FromSql(string.Format("UPDATE OP_PRESCRIPTION SET RECORDNUMBER='{0}' WHERE PRESCRIPTIONNO='{1}'", num, CurrentWMPrescriptionNo)).ExecuteNonQuery();
            if (this.dgvWesternMedicine.Rows.Count == 0)
            {
                DBHelper.CIS.Delete<OP_Prescription>(p => p.PrescriptionNo == CurrentWMPrescriptionNo);
                DBHelper.CIS.Delete<OP_Prescription_Detail>(p => p.PrescriptionNo == CurrentWMPrescriptionNo);
                CurrentWMPrescriptionNo = "";
            }
            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.Prescription });
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvWesternMedicine.SelectedRows;
            if (rows.Count < 2)
            {
                return;
            }

            if (!CheckTZ(rows))
            {
                return;
            }

            int MaxGroupNo = 0;
            MaxGroupNo = this.dgvWesternMedicine.Rows.Cast<DataGridViewRow>().Max(p => p.Cells["XY_colTZBH"].Value.AsInt(0));
            List<int> groupNo = rows.Cast<DataGridViewRow>().Select(p => p.Cells["XY_colTZBH"].Value.AsInt(0)).Distinct().ToList();
            foreach (DataGridViewRow item in rows)
            {
                int targetIndex = 0;
                if (groupNo.Count == 1)
                {
                    item.Cells["XY_colTZBH"].Value = MaxGroupNo + 1;
                }
                else
                {
                    if (item.Cells["XY_colTZBH"].Value.AsInt(0) != 0)
                    {
                        continue;
                    }

                    int tmp = groupNo.First(p => p != 0);
                    int index = this.dgvWesternMedicine.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["XY_colTZBH"].Value.AsInt(0) == tmp).Max(p => p.Index);
                    item.Cells["XY_colTZBH"].Value = tmp;
                    targetIndex = index + 1;
                }
                this.dgvWesternMedicine.Rows.Remove(item);
                this.dgvWesternMedicine.Rows.Insert(targetIndex, item);
            }

            DrawGroupLine();

        }

        private void btnGroupCancel_Click(object sender, EventArgs e)
        {

            List<int> list = new List<int>();
            DataGridViewSelectedRowCollection rows = this.dgvWesternMedicine.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                string tmp = row.Cells["XY_colTZBH"].Value.ToString();
                if (!list.Contains(Convert.ToInt32(tmp)))
                {
                    list.Add(Convert.ToInt32(tmp));
                }
            }
            foreach (DataGridViewRow item in this.dgvWesternMedicine.Rows)
            {
                string tmp = item.Cells["XY_colTZBH"].Value.AsString("0");
                if (list.Contains(Convert.ToInt32(tmp)))
                {
                    item.Cells["XY_colTZBH"].Value = "0";
                }
            }
            DrawGroupLine();
        }

        private void dgvWesternMedicine_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == this.XY_colYL.Index && SysContext.CurrUser.Params.OP_AssistDose == "是")
            {
                if (this.dgvWesternMedicine.Rows[e.RowIndex].Cells["XY_colYPID"].Value != null)
                {
                    ColculateDetailDGVTop();
                    this.controlAmpoule1.targetCell = this.dgvWesternMedicine.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    this.controlAmpoule1.minDose = WesternMedicineInfo.First(p => p.DrugID == this.dgvWesternMedicine.Rows[e.RowIndex].Cells["XY_colYPID"].Value.AsString("")).MinDose.AsFloat(0);
                    this.controlAmpoule1.Show();
                }
            }
            try
            {
                if (this.dgvWesternMedicine.Rows[e.RowIndex].Cells[e.ColumnIndex].EditType == typeof(DataGridViewComboBoxExEditingControl))
                {
                    SendKeys.Send("{F4}");
                }
            }
            catch
            {
            }

        }

        private void dgvXYDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvWesternMedicineDetail.SelectedRows;
            if (rows.Count < 1)
            {
                return;
            }

            if (this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colName" && this.dgvWesternMedicineDetail.Visible)
            {
                ImportYPToDGV(this.dgvWesternMedicine.CurrentCell.OwningRow, rows[0], false, false);
                this.dgvWesternMedicineDetail.Hide();
            }
        }

        private void dgvXYDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colName" && this.dgvWesternMedicineDetail.Visible)
                {
                    ImportYPToDGV(this.dgvWesternMedicine.CurrentCell.OwningRow, this.dgvWesternMedicineDetail.SelectedRows[0], false, false);
                }

                this.dgvWesternMedicineDetail.Hide();
            }
        }

        /// <summary>
        /// 初始化西药列表上的状态栏
        /// </summary>
        /// <param name="Status"></param>
        private void InitXYBar(bool Status)
        {
            this.dgvWesternMedicine.ReadOnly = !Status;
            foreach (DataGridViewColumn item in this.dgvWesternMedicine.Columns)
            {
                if (item.DefaultCellStyle.BackColor == Color.FromArgb(204, 206, 219))
                {
                    item.ReadOnly = true;
                }
            }

            this.btnXYSave.Enabled = Status;
            this.btnXYAdd.Enabled = Status;
            this.btnXYDel.Enabled = Status;
            this.btnGroupCollect.Enabled = Status;
            this.btnPosition.Enabled = Status;
        }

        /// <summary>
        /// 初始化草药列表上的状态栏
        /// </summary>
        /// <param name="Status"></param>
        private void InitCYBar(bool Status)
        {
            this.dgvHerbalMedicine.ReadOnly = !Status;
            foreach (DataGridViewColumn item in this.dgvHerbalMedicine.Columns)
            {
                if (item.DefaultCellStyle.BackColor == Color.FromArgb(204, 206, 219))
                {
                    item.ReadOnly = true;
                }
            }

            this.btnCYAdd.Enabled = Status;
            this.btnCYDel.Enabled = Status;
            this.btnCYSave.Enabled = Status;
            this.inputHerbalMedicineNum.Enabled = Status;

        }

        /// <summary>
        /// 初始化治疗列表上的状态栏
        /// </summary>
        /// <param name="Status"></param>
        private void InitZLBar(bool Status)
        {
            this.dgvDiagnose.ReadOnly = !Status;
            foreach (DataGridViewColumn item in this.dgvDiagnose.Columns)
            {
                if (item.DefaultCellStyle.BackColor == Color.FromArgb(204, 206, 219))
                {
                    item.ReadOnly = true;
                }
            }

            this.btnZLAdd.Enabled = Status;
            this.btnZLDel.Enabled = Status;
            this.btnZLSave.Enabled = Status;
        }
        #endregion

        #region 草药处方操作
        private void dgvHerbalMedicine_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                using (SolidBrush b = new SolidBrush(Color.Black))
                {
                    int linen = 0;
                    linen = e.RowIndex + 1;
                    string line = linen.ToString();
                    e.Graphics.DrawString(line, e.InheritedRowStyle.Font, b, e.RowBounds.Location.X, e.RowBounds.Location.Y + 5);
                }
            }
        }

        private void dgvHerbalMedicine_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (this.dgvWesternMedicine.Rows[e.RowIndex].Cells[e.ColumnIndex].EditType == typeof(DataGridViewComboBoxExEditingControl))
                {
                    SendKeys.Send("{F4}");
                }
            }
            catch
            {
            }

        }

        private void dgvHerbalMedicine_Text_Changed(object sender, EventArgs e)
        {
            if (this.dgvHerbalMedicine.CurrentCell.OwningColumn.Name == "CY_colName")
            {
                string InputStr = (sender as TextBox).Text.AsString("").Trim().ToUpper();
                if (InputStr == "")
                {
                    this.dgvHerbalMedicineDetail.Hide();
                    return;
                }
                List<IView_HIS_DrugInfo> Tmp;
                //if (this.cbxShowReserveIsNotZero.Checked)
                Tmp = HerbalMedicineDrugInfo.Where(p => (p.SearchCode.Contains(InputStr) || p.DrugName.Contains(InputStr)) && p.Reserve > 0).ToList();
                //else
                //Tmp = HerbalMedicineDrugInfo.Where(p => p.SearchCode.Contains(InputStr) || p.DrugName.Contains(InputStr)).ToList();

                Rectangle rect = this.dgvHerbalMedicine.GetCellDisplayRectangle(this.dgvHerbalMedicine.CurrentCell.ColumnIndex, this.dgvHerbalMedicine.CurrentCell.RowIndex, false);
                Tmp = Tmp.OrderBy(p => p.NickName.AsString("").Length).ToList();

                Point p1 = this.dgvHerbalMedicine.PointToScreen(new Point(rect.X, rect.Y));
                Point p2 = this.superTabControlPanel3.PointToClient(p1);

                ColculateDetailDGVTop(p2.Y, rect.Height, this.dgvHerbalMedicineDetail);

                this.dgvHerbalMedicineDetail.DataSource = Tmp;
                this.dgvHerbalMedicineDetail.Show();
            }
        }

        private void btnCYNew_Click(object sender, EventArgs e)
        {
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                AlertBox.Info("请先选择病人");
                return;
            }

            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.GetHMDiagnosis });

            if (HasHMDiagnosis != "1")
            {
                AlertBox.Info("当前中医诊断或症候为空,无法开处方");
                return;
            }
            this.dgvHerbalMedicine.Rows.Clear();
            CurrentHMPrescriptionNo = "";
            CurrPatientPrescription = null;
            int index = this.dgvHerbalMedicine.Rows.Add();
            CurrentHerbalMedicinePrescriptionType = PrescriptionType.Herbal;
            this.btnCYSave.Tag = "2";
            InitCYBar(true);
            this.inputHerbalMedicineNum.Text = "1";
            this.dgvHerbalMedicine.CurrentCell = this.dgvHerbalMedicine.Rows[index].Cells["CY_colName"];
            this.dgvHerbalMedicine.BeginEdit(true);
            ColculateAllItemTotal();
        }

        private void btnCYAdd_Click(object sender, EventArgs e)
        {
            this.dgvHerbalMedicine.EndEdit();
            string msg;
            foreach (DataGridViewRow item in this.dgvHerbalMedicine.Rows)
            {
                if (!CYValidate(item, out msg))
                {
                    AlertBox.Info("在指定位置有数据验证失败" + msg);
                    return;
                }
                ColculateCYZJE(item);
            }
            if (this.dgvHerbalMedicine.Rows.Count > MaxHMCount)
            {
                AlertBox.Info("草药处方已经超过大处方限制,只可开具" + MaxHMCount.ToString() + "个药");
                return;
            }
            int index = this.dgvHerbalMedicine.Rows.Add();
            this.dgvHerbalMedicine.CurrentCell = this.dgvHerbalMedicine.Rows[index].Cells["CY_colName"];
            this.dgvHerbalMedicine.BeginEdit(true);
        }

        private void dgvHerbalMedicine_TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (this.dgvHerbalMedicine.CurrentCell.IsInEditMode && this.dgvHerbalMedicine.CurrentCell.OwningColumn.Name == "CY_colName")
                {
                    CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(this.dgvHerbalMedicineDetail.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_KEYDOWN, e.KeyValue, 0);
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (HMKeyDown)
                    {
                        HMKeyDown = false;
                        e.SuppressKeyPress = false;
                    }
                    else
                    {
                        HMKeyDown = true;
                        if (this.dgvHerbalMedicine.CurrentCell.OwningRow.Index > 0 && e.KeyCode == Keys.Up)
                        {
                            this.dgvHerbalMedicine.CurrentCell = this.dgvHerbalMedicine.Rows[this.dgvHerbalMedicine.CurrentCell.OwningRow.Index - 1].Cells[this.dgvHerbalMedicine.CurrentCell.ColumnIndex];
                        }
                        else if (this.dgvHerbalMedicine.CurrentCell.OwningRow.Index < this.dgvHerbalMedicine.Rows.Count - 1 && e.KeyCode == Keys.Down)
                        {
                            this.dgvHerbalMedicine.CurrentCell = this.dgvHerbalMedicine.Rows[this.dgvHerbalMedicine.CurrentCell.OwningRow.Index + 1].Cells[this.dgvHerbalMedicine.CurrentCell.ColumnIndex];
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (this.dgvHerbalMedicine.CurrentCell.OwningColumn.Name == "CY_colName" && this.dgvHerbalMedicine.CurrentCell.EditedFormattedValue.AsString("") == "")
                {
                    return;
                }

                if (this.dgvHerbalMedicine.CurrentCell.OwningColumn.Name == "CY_colName" && this.dgvHerbalMedicine.CurrentCell.IsInEditMode && !this.dgvHerbalMedicineDetail.Visible)
                {
                    return;
                }

                if (this.dgvHerbalMedicine.CurrentCell.OwningColumn.Name == "CY_colName" && this.dgvHerbalMedicineDetail.Visible)
                {
                    if (this.dgvHerbalMedicineDetail.SelectedRows.Count == 0)
                    {
                        return;
                    }

                    ImportYPToDGV(this.dgvHerbalMedicine.CurrentCell.OwningRow, this.dgvHerbalMedicineDetail.SelectedRows[0], true, false);
                    this.dgvHerbalMedicineDetail.Hide();
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (this.dgvHerbalMedicine.CurrentCell != null || this.dgvHerbalMedicine.CurrentCell.ColumnIndex < this.dgvHerbalMedicine.ColumnCount)
                    {
                        //循环到下一个可编辑的单元格内
                        DataGridViewCell cell = this.dgvHerbalMedicine.CurrentCell.OwningRow.Cells[this.dgvHerbalMedicine.CurrentCell.ColumnIndex + 1];
                        while (cell.ReadOnly)
                        {
                            cell = cell.OwningRow.Cells[cell.ColumnIndex + 1];
                        }
                        //如果单元格不可见并且可以回车换行并且换行点为最后一列则加一行
                        if (!cell.Visible)
                        {
                            btnCYAdd_Click(null, null);
                            return;
                        }

                        if (!cell.Visible)
                        {
                            return;
                        }

                        this.dgvHerbalMedicine.CurrentCell = cell;
                        this.dgvHerbalMedicine.BeginEdit(true);
                    }
                }
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) && this.dgvHerbalMedicineDetail.Visible)
            {
                this.dgvHerbalMedicineDetail.Hide();
            }
        }

        private void dgvCYDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvHerbalMedicineDetail.SelectedRows;
            if (rows.Count < 1)
            {
                return;
            }

            if (this.dgvHerbalMedicine.CurrentCell.OwningColumn.Name == "CY_colName" && this.dgvHerbalMedicineDetail.Visible)
            {
                ImportYPToDGV(this.dgvHerbalMedicine.CurrentCell.OwningRow, rows[0], true, false);
                this.dgvHerbalMedicineDetail.Hide();
            }
        }

        private void dgvCYDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dgvHerbalMedicine.CurrentCell.OwningColumn.Name == "CY_colName" && this.dgvHerbalMedicineDetail.Visible)
                {
                    ImportYPToDGV(this.dgvHerbalMedicine.CurrentCell.OwningRow, this.dgvHerbalMedicineDetail.SelectedRows[0], true, false);
                }

                this.dgvHerbalMedicineDetail.Hide();
            }
        }

        private void btnCYDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvHerbalMedicine.SelectedRows;
            foreach (DataGridViewRow item in rows)
            {
                if (item.Cells["CY_colGG"].Value == null)
                {
                    this.dgvHerbalMedicine.Rows.Remove(item);
                    return;
                }
                if (item.Cells["CY_colID"].Value != null)
                {
                    DBHelper.CIS.Delete<OP_Prescription_Detail>(p => p.ID == item.Cells["CY_colID"].Value.ToString());
                }

                this.dgvHerbalMedicine.Rows.Remove(item);
            }
            if (this.dgvHerbalMedicine.Rows.Count == 0)
            {
                DBHelper.CIS.Delete<OP_Prescription>(p => p.PrescriptionNo == CurrentHMPrescriptionNo);
                CurrentHMPrescriptionNo = "";
                formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.Prescription });
            }
        }

        private (OP_Prescription, List<OP_Prescription_Detail>) btnCYSave_Click(object sender, EventArgs e)
        {
            if (this.dgvHerbalMedicine.Rows.Count == 0)
            {
                return (null, null);
            }

            string msg;
            this.dgvHerbalMedicine.EndEdit();
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                AlertBox.Info("请先选择病人");
                return (null, null);
            }
            if (this.dgvHerbalMedicine.Rows[this.dgvHerbalMedicine.Rows.Count - 1].Cells["CY_colName"].Value == null && this.dgvHerbalMedicine.Rows[this.dgvHerbalMedicine.Rows.Count - 1].Cells["CY_colGG"].Value == null)
            {
                this.dgvHerbalMedicine.Rows.RemoveAt(this.dgvHerbalMedicine.Rows.Count - 1);
            }

            if (this.dgvHerbalMedicine.Rows.Count == 0)
            {
                return (null, null);
            }

            foreach (DataGridViewRow item in this.dgvHerbalMedicine.Rows)
            {
                if (item.Cells["CY_colGG"].Value == null)
                {
                    continue;
                }

                if (!CYValidate(item, out msg, true))
                {
                    AlertBox.Info("在指定位置有数据验证失败" + msg);
                    return (null, null);
                }
                ColculateCYZJE(item);
            }

            if (SysContext.CurrUser.Params.OP_SwitchMedicalInsurance == "是")
            {
                string json = GetPatientMedicalInsuranceBasicJson(Guid.NewGuid().ToString(), ColculateAllItemTotal("CY").ToString(), this.dgvHerbalMedicine, "2");
                string result = HTTPHelper.HttpPost("http://192.168.1.228:8080/MMAP/RuleEngine.do", json);
                MedicalInsuranceDrugResult DrugResult = SerializeHelper.BeginJsonDeserialize<MedicalInsuranceDrugResult>(result);

                if (DrugResult != null && DrugResult.code == "200" && DrugResult.showflag == "1")
                {
                    FormMedicalInsurance form = new FormMedicalInsurance();
                    form.result = DrugResult;
                    if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        return (null, null);
                    }
                }
            }
            bool IsHave = CurrentHMPrescriptionNo == "" ? false : true;
            if (CurrentHMPrescriptionNo == "")
            {
                CurrentHMPrescriptionNo = Guid.NewGuid().ToString();
            }

            int Count = 1;
            DateTime now = DateTime.Now;

            List<OP_Prescription_Detail> update = new List<OP_Prescription_Detail>();
            List<OP_Prescription_Detail> insert = new List<OP_Prescription_Detail>();
            foreach (DataGridViewRow item in this.dgvHerbalMedicine.Rows)
            {
                //if (item.Cells["CY_colYPHH"].Value != null)
                //{
                //    string sql = string.Format("UPDATE YF_DTKC SET NYL=NYL+{0} WHERE YPHH='{1}' AND YPID='{2}'", item.Cells["CY_colSL"].Value.ToString(), item.Cells["CY_colYPHH"].Value.ToString(), item.Cells["CY_colYPID"].Value.ToString());
                //    DBHelper.CIS.FromSql(sql).ToScalar();
                //}
                if (item.Cells["CY_colGG"].Value == null)
                {
                    continue;
                }

                OP_Prescription_Detail Prescription = ControlHelper.FillModel<OP_Prescription_Detail>(item);
                if (item.Index + 1 > Count)
                {
                    Count = item.Index + 1;
                }

                InitPrescriptionDetail(ref Prescription, "3", CurrentHMPrescriptionNo, item.Index + 1, now);
                //Prescription.Usage = this.comboUsage.SelectedValue.ToString();
                if (Prescription.ID == null)
                {
                    Prescription.ID = Guid.NewGuid().ToString();
                    item.Cells["CY_colID"].Value = Prescription.ID;
                    insert.Add(Prescription);
                }
                else
                {
                    update.Add(Prescription);
                }
            }

            OP_Prescription tmp = InitPrescription(CurrentHMPrescriptionNo, ((int)CurrentHerbalMedicinePrescriptionType).ToString(), Count, now);
            tmp.ConditionSummary = this.cbxUsageTips.Text;
            tmp.HerbalMedicineNum = this.inputHerbalMedicineNum.Text.AsInt(0);
            tmp.Status = 1;

            bool flag = true;
            if (!string.IsNullOrWhiteSpace(_herbsGroupName))
            {
                var allDetail = insert.Union(update);
                if (allDetail.Count() != _herbsGroupQuantity)
                    flag = false;
                else
                {
                    var herbeGroupItemCodes = _herbsGroupItems.Select(p => p.Key).ToList();
                    var exists = herbeGroupItemCodes.Except(allDetail.Select(p => p.ItemCode));
                    if (exists.Count() != 0)
                        flag = false;
                    else
                    {
                        foreach (var detail in allDetail)
                        {

                            if (_herbsGroupItems.ContainsKey(detail.ItemCode))
                            {
                                if (_herbsGroupItems[detail.ItemCode] != detail.Amount)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                }
            }

            if (flag)
                tmp.HerbsGroupName = _herbsGroupName;
            else
                tmp.HerbsGroupName = null;

            var details = insert.Union(update);

            if (SysContext.CurrUser.Params.OP_BeforePrescriptionAudit)
            {
                var audit = _beforePrescriptionAudit.FillPatientInfo();
                audit = _beforePrescriptionAudit.FillDiagnosis(audit, formMain.GEtDiagnosis());
                audit = _beforePrescriptionAudit.FillPrescription(audit, details, tmp);
                var auditResult = _beforePrescriptionAudit.Post(audit);
                if (auditResult == null)
                {
                    return (null, null);
                }
                else
                {
                    if (!auditResult.Success)
                    {
                        FormBeforePrescriptionAudit form = new FormBeforePrescriptionAudit();
                        form.Init(auditResult);
                        if (form.ShowDialog() != DialogResult.Abort)
                        {
                            return (null, null);
                        }
                    }
                }
            }

            using (var tran = DBHelper.CIS.BeginTransaction())
            {
                int data = 0;
                try
                {
                    if (IsHave)
                        data = tran.Update<OP_Prescription>(tmp, p => p.PrescriptionNo == CurrentHMPrescriptionNo && p.TreatmentNo == (SysContext.Session["CurrPatient"] as IView_HIS_Outpatients).OutpatientNo);
                    else
                        data = tran.Insert<OP_Prescription>(tmp);

                    tran.Update(update);
                    tran.Insert(insert);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存草药", SerializeHelper.BeginJsonSerializable(tmp), data > 0 ? "处方保存成功！" : "处方保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
                }

            }

            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.Prescription });

            CurrentHMPrescriptionNo = "";
            this.inputHerbalMedicineNum.Text = "";
            CurrPatientPrescription = null;
            this.dgvHerbalMedicine.Rows.Clear();
            _herbsGroupName = null;
            _herbsGroupItems.Clear();

            return (tmp, details.ToList());
        }
        #endregion

        #region 治疗处方操作
        private void dgvDiagnose_Text_Changed(object sender, EventArgs e)
        {
            if (this.dgvDiagnose.CurrentCell.OwningColumn.Name == "ZL_colName")
            {
                string InputStr = (sender as TextBox).Text.ToUpper();
                if (InputStr == "")
                {
                    this.dgvDiagnoseDetail.Hide();
                    return;
                }
                List<IView_HIS_DealWithItem> Tmp;
                Tmp = DiagnoseInfo.Where(p => p.SearchCode.AsString("").Contains(InputStr) || p.Name.AsString("").Contains(InputStr)).ToList();

                Rectangle rect = this.dgvDiagnose.GetCellDisplayRectangle(this.dgvDiagnose.CurrentCell.ColumnIndex, this.dgvDiagnose.CurrentCell.RowIndex, false);
                Tmp = Tmp.OrderBy(p => p.Name.Length).ToList();

                Point p1 = this.dgvDiagnose.PointToScreen(new Point(rect.X, rect.Y));
                Point p2 = this.superTabControlPanel2.PointToClient(p1);

                ColculateDetailDGVTop(p2.Y, rect.Height, this.dgvDiagnoseDetail);

                this.dgvDiagnoseDetail.DataSource = Tmp;
                this.dgvDiagnoseDetail.Show();
            }
        }

        private void btnZLNew_Click(object sender, EventArgs e)
        {
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                AlertBox.Info("请先选择病人");
                return;
            }
            if (CurrentDiagnosisCount == 0)
            {
                AlertBox.Info("当前诊断为空,无法开处方");
                return;
            }
            this.dgvDiagnose.Rows.Clear();
            int index = this.dgvDiagnose.Rows.Add();
            CurrentDiagnosePrescriptionType = PrescriptionType.Treatment;
            this.btnZLSave.Tag = "9";
            InitZLBar(true);
            this.dgvDiagnose.CurrentCell = this.dgvDiagnose.Rows[index].Cells["ZL_colName"];
            this.dgvDiagnose.BeginEdit(true);
            CurrentDiagnosePrescriptionNo = "";
            CurrPatientPrescription = null;
            ColculateAllItemTotal();
        }

        private void btnZLAdd_Click(object sender, EventArgs e)
        {
            this.dgvDiagnose.EndEdit();
            string msg;
            foreach (DataGridViewRow item in this.dgvDiagnose.Rows)
            {
                if (!ZLValidate(item, out msg))
                {
                    AlertBox.Info("在指定位置有数据验证失败" + msg);
                    return;
                }
                ColculateZLZJE(item);
            }
            if (this.dgvDiagnose.Rows.Count > MaxDiagnoseCount)
            {
                AlertBox.Info("治疗处方已经超过大处方限制,只可开具" + MaxDiagnoseCount.ToString() + "个项目");
                return;
            }
            int index = this.dgvDiagnose.Rows.Add();
            this.dgvDiagnose.CurrentCell = this.dgvDiagnose.Rows[index].Cells["ZL_colName"];
            this.dgvDiagnose.BeginEdit(true);
        }

        private void dgvDiagnose_TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (this.dgvDiagnose.CurrentCell.IsInEditMode && this.dgvDiagnose.CurrentCell.OwningColumn.Name == "ZL_colName")
                {
                    CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(this.dgvDiagnoseDetail.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_KEYDOWN, e.KeyValue, 0);
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (TreatmentKeyDown)
                    {
                        TreatmentKeyDown = false;
                        e.SuppressKeyPress = false;
                    }
                    else
                    {
                        TreatmentKeyDown = true;
                        if (this.dgvDiagnose.CurrentCell.OwningRow.Index > 0 && e.KeyCode == Keys.Up)
                        {
                            this.dgvDiagnose.CurrentCell = this.dgvDiagnose.Rows[this.dgvDiagnose.CurrentCell.OwningRow.Index - 1].Cells[this.dgvDiagnose.CurrentCell.ColumnIndex];
                        }
                        else if (this.dgvDiagnose.CurrentCell.OwningRow.Index < this.dgvDiagnose.Rows.Count - 1 && e.KeyCode == Keys.Down)
                        {
                            this.dgvDiagnose.CurrentCell = this.dgvDiagnose.Rows[this.dgvDiagnose.CurrentCell.OwningRow.Index + 1].Cells[this.dgvDiagnose.CurrentCell.ColumnIndex];
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (this.dgvDiagnose.CurrentCell.OwningColumn.Name == "ZL_colName" && this.dgvDiagnose.CurrentCell.EditedFormattedValue.AsString("") == "")
                {
                    return;
                }

                if (this.dgvDiagnose.CurrentCell.OwningColumn.Name == "ZL_colName" && this.dgvDiagnose.CurrentCell.IsInEditMode && !this.dgvDiagnoseDetail.Visible)
                {
                    return;
                }

                if (this.dgvDiagnose.CurrentCell.OwningColumn.Name == "ZL_colName" && this.dgvDiagnoseDetail.Visible)
                {
                    if (this.dgvDiagnoseDetail.SelectedRows.Count == 0)
                    {
                        return;
                    }

                    ImportYPToDGV(this.dgvDiagnose.CurrentCell.OwningRow, this.dgvDiagnoseDetail.SelectedRows[0], false, true);
                    this.dgvDiagnoseDetail.Hide();
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (this.dgvDiagnose.CurrentCell != null || this.dgvDiagnose.CurrentCell.ColumnIndex < this.dgvDiagnose.ColumnCount)
                    {
                        //循环到下一个可编辑的单元格内
                        DataGridViewCell cell = this.dgvDiagnose.CurrentCell.OwningRow.Cells[this.dgvDiagnose.CurrentCell.ColumnIndex + 1];
                        while (cell.ReadOnly)
                        {
                            cell = cell.OwningRow.Cells[cell.ColumnIndex + 1];
                        }
                        //如果单元格不可见并且可以回车换行并且换行点为最后一列则加一行
                        if (!cell.Visible)
                        {
                            btnZLAdd_Click(null, null);
                            return;
                        }

                        if (!cell.Visible)
                        {
                            return;
                        }

                        this.dgvDiagnose.CurrentCell = cell;
                        this.dgvDiagnose.BeginEdit(true);
                    }

                    //if (this.dgvZL.CurrentCell != null || this.dgvZL.CurrentCell.ColumnIndex < this.dgvZL.ColumnCount)
                    //{
                    //    this.dgvZL.CurrentCell = this.dgvZL.CurrentCell.OwningRow.Cells[this.dgvZL.CurrentCell.ColumnIndex + 1];
                    //    this.dgvZL.BeginEdit(true);
                    //}
                }
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) && this.dgvDiagnoseDetail.Visible)
            {
                this.dgvDiagnoseDetail.Hide();
            }
        }

        private void dgvZLDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvDiagnoseDetail.SelectedRows;
            if (rows.Count < 1)
            {
                return;
            }

            if (this.dgvDiagnose.CurrentCell.OwningColumn.Name == "ZL_colName" && this.dgvDiagnoseDetail.Visible)
            {
                ImportYPToDGV(this.dgvDiagnose.CurrentCell.OwningRow, rows[0], false, true);
                this.dgvDiagnoseDetail.Hide();
            }
        }

        private void dgvZLDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dgvDiagnose.CurrentCell.OwningColumn.Name == "ZL_colName" && this.dgvDiagnoseDetail.Visible)
                {
                    ImportYPToDGV(this.dgvDiagnose.CurrentCell.OwningRow, this.dgvDiagnoseDetail.SelectedRows[0], false, true);
                }

                this.dgvDiagnoseDetail.Hide();
            }
        }

        private void btnZLDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvDiagnose.SelectedRows;
            foreach (DataGridViewRow item in rows)
            {
                if (item.Cells["ZL_colGG"].Value == null)
                {
                    this.dgvDiagnose.Rows.Remove(item);
                    return;
                }
                if (item.Cells["ZL_colID"].Value != null)
                {
                    DBHelper.CIS.Delete<OP_Prescription_Detail>(p => p.ID == item.Cells["ZL_colID"].Value.ToString());
                }

                this.dgvDiagnose.Rows.Remove(item);
            }
            if (this.dgvDiagnose.Rows.Count == 0)
            {
                DBHelper.CIS.Delete<OP_Prescription>(p => p.PrescriptionNo == CurrentDiagnosePrescriptionNo);
                CurrentDiagnosePrescriptionNo = "";
                formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.Prescription });
            }
        }

        private (OP_Prescription, List<OP_Prescription_Detail>) btnZLSave_Click(object sender, EventArgs e)
        {
            if (this.dgvDiagnose.Rows.Count == 0)
            {
                return (null, null);
            }

            string msg;
            this.dgvDiagnose.EndEdit();
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                AlertBox.Info("请先选择病人");
                return (null, null);
            }
            if (this.dgvDiagnose.Rows[this.dgvDiagnose.Rows.Count - 1].Cells["ZL_colName"].Value == null && this.dgvDiagnose.Rows[this.dgvDiagnose.Rows.Count - 1].Cells["ZL_colGG"].Value == null)
            {
                this.dgvDiagnose.Rows.RemoveAt(this.dgvDiagnose.Rows.Count - 1);
            }

            if (this.dgvDiagnose.Rows.Count == 0)
            {
                return (null, null);
            }

            foreach (DataGridViewRow item in this.dgvDiagnose.Rows)
            {
                if (item.Cells["ZL_colGG"].Value == null)
                {
                    continue;
                }

                if (!ZLValidate(item, out msg))
                {
                    AlertBox.Info("在指定位置有数据验证失败" + msg);
                    return (null, null);
                }
                ColculateZLZJE(item);
            }

            if (SysContext.CurrUser.Params.OP_SwitchMedicalInsurance == "是")
            {
                string json = GetPatientMedicalInsuranceBasicJson(Guid.NewGuid().ToString(), ColculateAllItemTotal("ZL").ToString(), this.dgvDiagnose, "13");
                string result = HTTPHelper.HttpPost("http://192.168.1.228:8080/MMAP/RuleEngine.do", json);
                MedicalInsuranceDrugResult DrugResult = SerializeHelper.BeginJsonDeserialize<MedicalInsuranceDrugResult>(result);

                if (DrugResult != null && DrugResult.code == "200" && DrugResult.showflag == "1")
                {
                    FormMedicalInsurance form = new FormMedicalInsurance();
                    form.result = DrugResult;
                    if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        return (null, null);
                    }
                }
            }
            bool IsHave = CurrentDiagnosePrescriptionNo == "" ? false : true;
            if (CurrentDiagnosePrescriptionNo == "")
            {
                CurrentDiagnosePrescriptionNo = Guid.NewGuid().ToString();
            }

            int Count = 1;
            DateTime now = DateTime.Now;

            List<OP_Prescription_Detail> update = new List<OP_Prescription_Detail>();
            List<OP_Prescription_Detail> insert = new List<OP_Prescription_Detail>();
            foreach (DataGridViewRow item in this.dgvDiagnose.Rows)
            {
                if (item.Cells["ZL_colGG"].Value == null)
                {
                    continue;
                }

                OP_Prescription_Detail Prescription = ControlHelper.FillModel<OP_Prescription_Detail>(item);

                if (item.Index + 1 > Count)
                {
                    Count = item.Index + 1;
                }

                InitPrescriptionDetail(ref Prescription, "4", CurrentDiagnosePrescriptionNo, item.Index + 1, now);
                if (Prescription.ID == null)
                {
                    Prescription.ID = Guid.NewGuid().ToString();
                    item.Cells["ZL_colID"].Value = Prescription.ID;
                    insert.Add(Prescription);
                }
                else
                {
                    update.Add(Prescription);
                }
            }

            OP_Prescription tmp = InitPrescription(CurrentDiagnosePrescriptionNo, ((int)CurrentDiagnosePrescriptionType).ToString(), Count, now);
            tmp.Status = 1;

            var details = insert.Union(update);

            if (SysContext.CurrUser.Params.OP_BeforePrescriptionAudit)
            {
                var audit = _beforePrescriptionAudit.FillPatientInfo();
                audit = _beforePrescriptionAudit.FillDiagnosis(audit, formMain.GEtDiagnosis());
                audit = _beforePrescriptionAudit.FillPrescription(audit, details, tmp);
                var auditResult = _beforePrescriptionAudit.Post(audit);
                if (auditResult == null)
                {
                    return (null, null);
                }
                else
                {
                    if (!auditResult.Success)
                    {
                        FormBeforePrescriptionAudit form = new FormBeforePrescriptionAudit();
                        form.Init(auditResult);
                        if (form.ShowDialog() != DialogResult.Abort)
                        {
                            return (null, null);
                        }
                    }
                }
            }

            using (var tran = DBHelper.CIS.BeginTransaction())
            {
                int data = 0;
                try
                {
                    if (IsHave)
                        data = tran.Update<OP_Prescription>(tmp, p => p.PrescriptionNo == CurrentDiagnosePrescriptionNo && p.TreatmentNo == (SysContext.Session["CurrPatient"] as IView_HIS_Outpatients).OutpatientNo);
                    else
                        data = tran.Insert<OP_Prescription>(tmp);

                    tran.Update(update);
                    tran.Insert(insert);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存治疗项目", SerializeHelper.BeginJsonSerializable(tmp), data > 0 ? "治疗项目保存成功！" : "治疗项目保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
                    CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存草药", SerializeHelper.BeginJsonSerializable(tmp), data > 0 ? "处方保存成功！" : "处方保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
                }

            }

            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.Prescription });

            CurrentDiagnosePrescriptionNo = "";
            CurrPatientPrescription = null;
            this.dgvDiagnose.Rows.Clear();

            return (tmp, details.ToList());
        }
        #endregion

        #region 数据操作
        /// <summary>
        /// 检查用药权限
        /// </summary>
        /// <returns></returns>
        private bool CheckDrugAuthority(string DrugName, string DrugSerial, string DrugProperties)
        {
            if (!DrugAuthority)
            {
                return true;
            }

            string sql = string.Format("EXEC YP_YYGL '{0}','{1}','{2}','1'", SysContext.CurrUser.user.Code, DrugSerial, DrugProperties);
            DataTable dt = DBHelper.CIS.FromSql(sql).ToDataTable();
            if (dt.Rows[0]["FLAG"].ToString() != "0")
            {
                MessageBox.Show(DrugName + ":" + dt.Rows[0]["Msg"].ToString());
                return false;
            }
            return true;
        }
        public void AddDrugNum(string DrugID, string DrugSerial, int Num, string Type)
        {
            List<IView_HIS_DrugInfo> druginfo = (Type == "3" ? HerbalMedicineDrugInfo : WesternMedicineInfo).Where(p => p.DrugSerial == DrugSerial && p.DrugID == DrugID).ToList();
            druginfo.ForEach(p => p.Reserve += Num);
        }
        private bool CheckSave()
        {
            if (!DBHelper.CIS.Exists<IView_HIS_Outpatients>(p => p.OutpatientNo == SysContext.GetCurrPatient.OutpatientNo))
            {
                MsgBox.OK("该患者状态已改变,可能已经退号，无法保存处方");
                SysContext.Session[SysContext.Session_CurrPatient] = null;
                this.InitUI();
                formMain.ClearPatientInfo();
                return false;
            }

            if (!formMain.GetRecordHasPersonel())
            {
                if (SysContext.CurrUser.Params.OP_ForcePersonel.AsBoolean())
                {
                    var dialog = MessageBox.Show("病历中个人史未填写，无法保存", "", MessageBoxButtons.OK);
                    return false;
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
                    return false;
                }
            }

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
                    if (!Infect.CheckInfection(Name, ICD))
                    {
                        var count = DBHelper.HNIMIS.FromSql($"select count(*) from Card_infect_Interface where sfzh='{SysContext.GetCurrPatient.IDCard}'").ToScalar<int>();
                        if (count == 0)
                        {
                            Infect.Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "0");
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        #region 医保控费JSON生成
        /// <summary>
        /// 生成医保控费基本JSON格式
        /// </summary>
        /// <returns></returns>
        private string GetPatientMedicalInsuranceBasicJson(string PrescriptionNo, string Total, DataGridViewX dgv, string Type)
        {
            DataTable dt = DBHelper.CIS.FromProc("YbApi_Mz").AddInParameter("@JZH", DbType.String, SysContext.GetCurrPatient.OutpatientNo).ToDataTable();
            if (dt.Rows.Count == 0)
            {
                return "";
            }

            patient send = new patient();
            send = GetPatientMedicalInsuranceBasicJson(send, dt) as patient;

            List<OP_PatientDiagnosis> diagnosis = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo).OrderByDescending(p => p.IsMain).ToList();
            List<diagnoses> list = new List<diagnoses>();
            for (int i = 0; i < 2; i++)
            {
                if (i >= diagnosis.Count)
                {
                    list.Add(new diagnoses());
                }
                else
                {
                    list.Add(new diagnoses() { code = diagnosis[i].Code, name = diagnosis[i].Name });
                }
            }
            send.encountersExt[0].diagnoses = list;
            send.encountersExt[0].diagnosis = string.Join(",", diagnosis.Select(p => p.Name).ToArray());
            send.encountersExt[0].diagnosisCode = string.Join(",", diagnosis.Select(p => p.Code).ToArray());
            send.encountersExt[0].ordersExt = GetPatientMedicalInsuranceOrdersExt(PrescriptionNo, dgv, Type);
            send.encountersExt[0].cost = Total;
            send.encountersExt[0].doctorName = SysContext.CurrUser.user.Name;

            string json = SerializeHelper.BeginJsonSerializable(send);
            List<string> list1 = new List<string>();
            list1.Add("hospitalID=321181010003");
            list1.Add("clientIP=" + SysContext.ClientIP);
            list1.Add("clientMac=" + SysContext.ClientMAC);
            list1.Add("callType=104");
            list1.Add("companyCode=50-7B-9D-62-80-10");
            list1.Add("ruleIDs=0");
            list1.Add("patient=" + json);


            MedicalInsuranceDrugSend result = new MedicalInsuranceDrugSend();
            result.patient = send;
            result.hospitalID = "";
            result.callType = "104";
            result.ruleIDs = "0";
            result.hospitalID = "321181010003";
            result.clientIP = SysContext.ClientIP;
            result.clientMac = SysContext.ClientMAC;
            result.companyCode = "danyang";

            return string.Join("&", list1.ToArray());
        }

        /// <summary>
        /// 生成医保控费基本JSON格式
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        private object GetPatientMedicalInsuranceBasicJson(object model, DataTable dt)
        {
            Type p = model.GetType();
            PropertyInfo[] info = p.GetProperties();
            foreach (PropertyInfo item in info)
            {

                if (item.PropertyType.Name != "String")
                {
                    Type t = item.PropertyType;
                    if (t.Namespace == "System.Collections.Generic")
                    {
                        Type argType = t.GetGenericArguments()[0];
                        if (argType == typeof(encountersExt))
                        {
                            List<encountersExt> tmp = new List<encountersExt>();
                            tmp.Add(GetPatientMedicalInsuranceBasicJson(Assembly.Load(argType.Namespace).CreateInstance(argType.FullName), dt) as encountersExt);
                            item.SetValue(model, tmp, null);
                        }
                        else if (argType == typeof(ordersExt))
                        {
                            List<ordersExt> tmp = new List<ordersExt>();
                            tmp.Add(GetPatientMedicalInsuranceBasicJson(Assembly.Load(argType.Namespace).CreateInstance(argType.FullName), dt) as ordersExt);
                            item.SetValue(model, tmp, null);
                        }
                        continue;
                    }
                    object obj = Assembly.Load(t.Namespace).CreateInstance(t.FullName);
                    item.SetValue(model, GetPatientMedicalInsuranceBasicJson(obj, dt), null);
                }
                if (dt.Columns.Contains(item.Name) && item.PropertyType.Name == "String")
                {
                    item.SetValue(model, dt.Rows[0][item.Name].ToString(), null);
                }
            }

            return model;
        }

        /// <summary>
        /// 生成医保控费药品序列
        /// </summary>
        /// <param name="PrescriptionNo"></param>
        /// <returns></returns>
        private List<ordersExt> GetPatientMedicalInsuranceOrdersExt(string PrescriptionNo, DataGridViewX dgv, string Type)
        {
            List<ordersExt> resule = new List<ordersExt>();
            foreach (DataGridViewRow item1 in dgv.Rows)
            {
                ordersExt order = new ordersExt();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (column.GetType() != typeof(DataGridViewTextBoxExtColumn))
                    {
                        continue;
                    }

                    DataGridViewTextBoxExtColumn item = column as DataGridViewTextBoxExtColumn;
                    if (item.Tag1 != null && item.Tag1 != "")
                    {
                        PropertyInfo p = order.GetType().GetProperty(item.Tag1);
                        if (item1.Cells[item.Name].Value == null)
                        {
                            continue;
                        }

                        p.SetValue(order, item1.Cells[item.Name].Value.ToString(), null);
                    }
                    if (item.Tag2 != null && item.Tag2 != "")
                    {
                        PropertyInfo p = order.GetType().GetProperty(item.Tag2);
                        if (item1.Cells[item.Name].Value == null)
                        {
                            continue;
                        }

                        p.SetValue(order, item1.Cells[item.Name].Value.ToString(), null);
                    }
                }
                order.orderType = Type == "0" ? "0" : Type == "2" ? "0" : "7";
                order.detailTypeExt = Type;
                order.deductibleCost = "0";
                order.startDateExt = DateTime.Now.ToString("yyyyMMddhhmmss");
                order.issueOrderDeptId = SysContext.RunSysInfo.currDept.Code;
                order.issueOrderDeptName = SysContext.RunSysInfo.currDept.Name;
                order.selfCost = "0";
                order.isRepeat = "0";
                order.outId = Guid.NewGuid().ToString();
                order.stopDateExt = DateTime.Now.ToString("yyyyMMddhhmmss"); ;
                order.doctorId = SysContext.CurrUser.user.Code;
                order.prescriptionCode = PrescriptionNo;
                order.doctorName = SysContext.CurrUser.user.Name;
                order.transactionType = "1";
                resule.Add(order);
            }

            return resule;
        }
        #endregion
        /// <summary>
        /// 选项卡在哪个页面就保存那个页面的数据
        /// </summary>
        private void Save()
        {
            if (!CheckSave())
            {
                return;
            }

            (OP_Prescription, List<OP_Prescription_Detail>) save = (null, null);

            if (this.tabCY.IsSelected)
                save = this.btnCYSave_Click(this.btnCYSave, null);
            else if (this.tabXY.IsSelected)
                save = this.btnXYSave_Click(this.btnXYSave, null);
            else
                save = this.btnZLSave_Click(this.btnZLSave, null);

            //if (save.Item1 == null)
            //    return;

            //var diagnosis = formMain.GEtDiagnosis();
            //var preAudit = new UploadPreAuditHelper();
            //var auditResult = preAudit.Handler(save.Item1, save.Item2, WesternMedicineInfo, Usage, diagnosis, AllInterval);
            //if (auditResult != null)
            //{
            //    var sign = new UploadPrescriptionSignHelper();
            //    var signResult = sign.Handler(auditResult, save.Item1, save.Item2.Count.ToString());
            //    if (signResult.Item1 != null)
            //    {
            //        var upload = new UploadPrescriptionHelper();
            //        var uploadResult = upload.Handler(signResult.Item1, signResult.Item2);
            //    }
            //}
        }

        /// <summary>
        /// 选项卡在哪个页面就删除那个页面的选中项
        /// </summary>
        private void Delete()
        {
            if (this.tabCY.IsSelected)
            {
                this.btnCYDel_Click(null, null);
            }
            else if (this.tabXY.IsSelected)
            {
                this.btnXYDel_Click(null, null);
            }
            else
            {
                this.btnZLDel_Click(null, null);
            }
        }

        /// <summary>
        /// 选项卡在哪个页面就全选那个页面
        /// </summary>
        private void SelectAll()
        {
            if (this.tabCY.IsSelected)
            {
                this.btnCYSelectAll_Click(null, null);
            }
            else if (this.tabXY.IsSelected)
            {
                this.btnXYSelectAll_Click(null, null);
            }
            else
            {
                this.btnZLSelectAll_Click(null, null);
            }
        }

        private void AddRow()
        {
            if (this.tabCY.IsSelected)
            {
                this.btnCYAdd_Click(null, null);
            }
            else if (this.tabXY.IsSelected)
            {
                this.btnXYAdd_Click(null, null);
            }
            else
            {
                this.btnZLAdd_Click(null, null);
            }
        }

        /// <summary>
        /// 将数据录入到处方DGV中
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        private void ImportYPToDGV(DataGridViewRow target, DataGridViewRow source, bool IsCY, bool IsZL)
        {
            this.dgvWesternMedicine.EndEdit();
            this.dgvHerbalMedicine.EndEdit();
            this.dgvDiagnose.EndEdit();

            IView_HIS_DrugInfo sourceDrugInfo = source.DataBoundItem as IView_HIS_DrugInfo;
            target.Tag = sourceDrugInfo;

            if (!IsZL)
            {
                if (!IsCY)
                {
                    if (!CheckDrugAuthority(source.Cells["XY_colName1"].Value.AsString(""), source.Cells["XY_colYPHH1"].Value.AsString(""), source.Cells["XY_colYPSX1"].Value.AsString("")))
                        return;
                    //如果是慢性病并且判断药品限制
                    if (!DrugLimit(sourceDrugInfo.DrugID.AsString(""), sourceDrugInfo.DrugName.AsString(""), CurrentWesternMedicinePrescriptionType))
                        return;
                }
                else
                { //如果是慢性病并且判断药品限制
                    if (!DrugLimit(sourceDrugInfo.DrugID.AsString(""), sourceDrugInfo.DrugName.AsString(""), CurrentHerbalMedicinePrescriptionType))
                        return;
                }
            }
            DataGridView targetDGV = IsCY ? this.dgvHerbalMedicine : IsZL ? this.dgvDiagnose : null;
            string targetDGV1 = IsCY ? "CY_colName" : IsZL ? "ZL_colName" : null; ;
            string targetDGV2 = IsCY ? "CY_colGG" : IsZL ? "ZL_colGG" : null; ; ;
            if (targetDGV != null)
            {
                foreach (DataGridViewRow item in targetDGV.Rows)
                {
                    if (item.Cells[targetDGV1].Value.AsString("") == source.Cells[targetDGV1 + "1"].Value.AsString("") && item.Cells[targetDGV2].Value.AsString("") == source.Cells[targetDGV2 + "1"].Value.AsString(""))
                    {
                        AlertBox.Info(string.Format("已经添加了相同的项目 {0}", item.Cells[targetDGV1].Value.AsString("")));
                        return;
                    }
                }
            }

            foreach (DataGridViewCell item in source.Cells)
            {
                try
                {
                    target.Cells[(item.OwningColumn.Name).Substring(0, item.OwningColumn.Name.Length - 1)].Value = item.Value;
                }
                catch
                {
                }
            }

            if (IsCY)
            {
                string MinDoseUnit = target.Cells["CY_colYLDW"].Value.AsString("");
                target.Cells["CY_colSL"].Value = "1";
                target.Cells["CY_colTS"].Value = "1";
                target.Cells["CY_colYF"].Value = Usage.Where(p => p.Name == source.Cells["CY_colYF1"].Value.AsString("煎服")).First().Code;// MinDoseUnit.Contains("颗粒") ? "cf" : SysContext.CurrUser.Params.OP_DefaultHMUsage;
                                                                                                                                         //target.Cells["CY_colYF"].Value = MinDoseUnit.Contains("颗粒") ? "cf" : SysContext.CurrUser.Params.OP_DefaultHMUsage;
                target.Cells["CY_colYL11"].Value = "1";

                return;
            }
            if (IsZL)
            {
                target.Cells["ZL_colSL"].Value = "1";
                if (target.Cells["ZL_colLSJ"].Value.AsFloat(0) == 0)
                {
                    target.Cells["ZL_colLSJ"].ReadOnly = false;
                    target.Cells["ZL_colLSJ"].Style.BackColor = Color.White;
                }
                else
                {
                    target.Cells["ZL_colLSJ"].ReadOnly = true;
                }

                return;
            }
            target.Cells["XY_colTZBH"].Value = "0";
            if (source.Cells["XY_colYPSX1"].Value.ToString().Contains('Y'))
            {
                if (formMain.GetPrescriptionDetail == null || formMain.GetPrescriptionDetail.Count(p => p.Specification == source.Cells["XY_colGG1"].Value.ToString() && p.ItemName == source.Cells["XY_colName1"].Value.ToString() && p.SkinTestFlag == "Y") == 0)
                {
                    if (MessageBox.Show(string.Format("当前药品 {0} 需要皮试,是否皮试", source.Cells["XY_colName1"].Value.ToString()), "系统提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        target.Cells["XY_colPS"].Value = "Y";
                    }
                    else
                    {
                        target.Cells["XY_colPS"].Value = "N";
                    }
                }
                else
                {
                    target.Cells["XY_colPS"].Value = "N";
                }
            }
            else
            {
                target.Cells["XY_colPS"].Value = "X";
            }

            target.Cells["XY_colJG"].Value = Interval.First().Code;
            string DrugForm = target.Cells["XY_colJXMC"].Value.AsString("");
            target.Cells["XY_colYF"].Value = target.Cells["XY_colYF"].Value.AsString("") == "" ? SysContext.CurrUser.Params.OP_DefaultUsage : target.Cells["XY_colYF"].Value;
            //target.Cells["XY_colYF"].Value = DrugForm.Contains("注射") ? "ivd" : DrugForm.Contains("眼") ? "dsy" : CIS.Core.SysContext.CurrUser.Params.OP_DefaultUsage;
            target.Cells["XY_colTS"].Value = "1";
            target.Cells["XY_colSL"].Value = "1";

        }

        /// <summary>
        /// 计算所有项目的总金额
        /// </summary>
        private float ColculateAllItemTotal(string str = "")
        {
            float XYTatal = 0;
            float CYTatal = 0;
            float ZLTatal = 0;
            if (this.tabXY.IsSelected)
            {
                foreach (DataGridViewRow item in this.dgvWesternMedicine.Rows)
                {
                    if (item.Cells["XY_colZJE"].Value != null)
                    {
                        XYTatal += item.Cells["XY_colZJE"].Value.AsFloat(0);
                    }
                }
                this.panelEx1.Text = string.Format("西药：{0}元 ", XYTatal);
            }

            if (this.tabCY.IsSelected)
            {
                foreach (DataGridViewRow item in this.dgvHerbalMedicine.Rows)
                {
                    if (item.Cells["CY_colZJE"].Value != null)
                    {
                        CYTatal += item.Cells["CY_colZJE"].Value.AsFloat(0);
                    }
                }
                this.panelEx1.Text = string.Format("草药：{0}元", CYTatal);
            }

            if (this.tabZL.IsSelected)
            {
                foreach (DataGridViewRow item in this.dgvDiagnose.Rows)
                {
                    if (item.Cells["ZL_colZJE"].Value != null)
                    {
                        ZLTatal += item.Cells["ZL_colZJE"].Value.AsFloat(0);
                    }
                }
                this.panelEx1.Text = string.Format("治疗：{0}元", ZLTatal);
            }
            if (str == "XY")
            {
                return XYTatal;
            }
            else if (str == "CY")
            {
                return CYTatal;
            }
            else if (str == "ZL")
            {
                return ZLTatal;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 画出同组项目之间的连线
        /// </summary>
        private void DrawGroupLine()
        {
            string[] zbf = new string[] { "┓", "┫", "┛", "┃" };
            string currTZBH = "";
            for (int i = 0; i < this.dgvWesternMedicine.Rows.Count; i++)
            {
                //得到当前处理行的同组编号和下一行的同组编号,如果已经是最后一行,那么下一行的同组编号为-1
                if (this.dgvWesternMedicine.Rows[i].Cells["XY_colTZBH"].Value == null)
                {
                    continue;
                }

                string currRowValue = this.dgvWesternMedicine.Rows[i].Cells["XY_colTZBH"].Value.ToString();
                string nextRowValue = i != this.dgvWesternMedicine.Rows.Count - 1 ? this.dgvWesternMedicine.Rows[i + 1].Cells["XY_colTZBH"].Value == null ? "-1" : this.dgvWesternMedicine.Rows[i + 1].Cells["XY_colTZBH"].Value.ToString() : "-1";

                if (currRowValue == "0")
                {
                    this.dgvWesternMedicine.Rows[i].Cells["XY_colTZ"].Value = "";
                    continue;   //如果没有同组编号则跳过
                }

                //如果当前行等于上一次的同组编号并且已经是最后一行
                if (currRowValue == currTZBH && nextRowValue == "-1")
                {
                    this.dgvWesternMedicine.Rows[i].Cells["XY_colTZ"].Value = zbf[2];
                    this.dgvWesternMedicine.Rows[i].Cells["XY_colTZ"].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                }
                //如果当前行不等于上一次的同组编号并且和下一行一样
                else if (currRowValue != currTZBH && nextRowValue == currRowValue)
                {
                    this.dgvWesternMedicine.Rows[i].Cells["XY_colTZ"].Value = zbf[0];
                    this.dgvWesternMedicine.Rows[i].Cells["XY_colTZ"].Style.Alignment = DataGridViewContentAlignment.BottomLeft;
                    currTZBH = currRowValue;
                }
                //如果当前行等于上一次的同组编号并且和下一行一样
                else if (currRowValue == currTZBH && nextRowValue == currRowValue)
                {
                    this.dgvWesternMedicine.Rows[i].Cells["XY_colTZ"].Value = zbf[3];
                    this.dgvWesternMedicine.Rows[i].Cells["XY_colTZ"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                //如果当前行等于上一次的同组编号并且和下一行不一样
                else if (currRowValue == currTZBH && nextRowValue != currRowValue)
                {
                    this.dgvWesternMedicine.Rows[i].Cells["XY_colTZ"].Value = zbf[2];
                    this.dgvWesternMedicine.Rows[i].Cells["XY_colTZ"].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                }
            }
        }
        /// <summary>
        /// 给套餐的树状节点画出同组线
        /// </summary>
        /// <param name="node"></param>
        private void DrawTZLine(Node node)
        {
            string[] zbf = new string[] { "┏", "┣", "┗", "┃" };
            string currTZBH = "";
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                //得到当前处理行的同组编号和下一行的同组编号,如果已经是最后一行,那么下一行的同组编号为-1
                string currRowValue = (node.Nodes[i].Tag as IView_Inside_DrugDetail).GroupNo.AsString("0");
                if (currRowValue == null)
                {
                    continue;
                }

                string nextRowValue = i != node.Nodes.Count - 1 ? (node.Nodes[i + 1].Tag as IView_Inside_DrugDetail).GroupNo == null ? "-1" : (node.Nodes[i + 1].Tag as IView_Inside_DrugDetail).GroupNo : "-1";

                if (currRowValue == "0")
                {
                    continue;   //如果没有同组编号则跳过
                }

                //如果当前行等于上一次的同组编号并且已经是最后一行
                if (currRowValue == currTZBH && nextRowValue == "-1")
                {
                    node.Nodes[i].Text = zbf[2] + node.Nodes[i].Text;
                }
                //如果当前行不等于上一次的同组编号并且和下一行一样
                else if (currRowValue != currTZBH && nextRowValue == currRowValue)
                {
                    node.Nodes[i].Text = zbf[0] + node.Nodes[i].Text;
                    currTZBH = currRowValue;
                }
                //如果当前行等于上一次的同组编号并且和下一行一样
                else if (currRowValue == currTZBH && nextRowValue == currRowValue)
                {
                    node.Nodes[i].Text = zbf[3] + node.Nodes[i].Text;
                }
                //如果当前行等于上一次的同组编号并且和下一行不一样
                else if (currRowValue == currTZBH && nextRowValue != currRowValue)
                {
                    node.Nodes[i].Text = zbf[2] + node.Nodes[i].Text;
                }
            }
        }

        /// <summary>
        /// 西药行数据校验
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private bool XYValidate(DataGridViewRow source, out string msg, bool IsSave = false)
        {
            string[] MustHaveDataColName = new string[] { "XY_colName", "XY_colSL", "XY_colYL", "XY_colYF", "XY_colJG", "XY_colTS" }; //必须有值得列
            string[] MustIntColName = new string[] { "XY_colTS", "XY_colSL" }; //必须是int的列
            string[] MustNumColName = new string[] { "XY_colYL" };
            string tmpMsg = "";
            foreach (DataGridViewCell item in source.Cells)
            {
                if (MustHaveDataColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || item.Value.ToString() == "")
                    {
                        tmpMsg = ",此处不能为空";
                    }
                }
                if (MustIntColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || !item.Value.AsInt().HasValue || item.Value.AsInt(0) <= 0)
                    {
                        tmpMsg = ",此处必须为整数且大于零";
                    }
                }
                if (MustNumColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || !item.Value.AsFloat().HasValue || item.Value.AsFloat(0) <= 0)
                    {
                        tmpMsg = ",此处必须为数字且大于零";
                    }
                }
                if (tmpMsg != "")
                {
                    source.DataGridView.CurrentCell = item;
                    this.dgvWesternMedicine.BeginEdit(true);
                    msg = tmpMsg;
                    return false;
                }
            }

            //string DrugSerial = (source.Cells["XY_colYPHH"].Value ?? "").ToString();
            //if (this.btnXYSave.Tag.ToString() == "3") //如果是慢性病处方的话
            //{
            //    DataTable dt = DBHelper.CIS.FromSql(string.Format("SELECT * FROM YB_MXB_YP WHERE JBBM='{0}' AND YPHH='{1}'", ChronicCode, DrugSerial)).ToDataTable();
            //    if (dt.Rows.Count == 0)
            //    {
            //        source.DataGridView.CurrentCell = source.Cells["XY_colName"];
            //        this.dgvXY.BeginEdit(true);
            //        msg = ",当前药品不在该慢性病许可的药品内";
            //        return false;
            //    }
            //}

            if (source.Cells["XY_colYPID"].Value != null)
            {
                List<IView_HIS_DrugInfo> druginfo = new List<IView_HIS_DrugInfo>();
                if (source.Cells["XY_colYPHH"].Value == null)
                {
                    druginfo = WesternMedicineInfo.Where(p => p.DrugID == source.Cells["XY_colYPID"].Value.ToString()).ToList();
                }
                else
                {
                    druginfo = WesternMedicineInfo.Where(p => p.DrugSerial == source.Cells["XY_colYPHH"].Value.ToString() && p.DrugID == source.Cells["XY_colYPID"].Value.ToString()).ToList();
                }

                if (druginfo.Count == 0)
                {
                    source.DataGridView.CurrentCell = source.Cells["XY_colName"];
                    this.dgvWesternMedicine.BeginEdit(true);
                    msg = ",该药品ID未能在药库找到,请检查";
                    return false;
                }
                else
                {
                    if (druginfo[0].Reserve - source.Cells["XY_colSL"].Value.AsInt(0) < 0)
                    {
                        source.DataGridView.CurrentCell = source.Cells["XY_colName"];
                        this.dgvWesternMedicine.BeginEdit(true);
                        msg = $",{ source.Cells["XY_colName"].Value} { source.Cells["XY_colGG"].Value} 库存不足";
                        return false;
                    }
                    //else
                    //{
                    //    if (IsSave)
                    //        druginfo.ForEach(p => p.Reserve -= source.Cells["XY_colSL"].Value.AsInt(0));
                    //}
                }

                if (!DrugLimit(source.Cells["XY_colYPID"].Value.ToString(), source.Cells["XY_colName"].Value.ToString().Trim(), source.Cells["XY_colSL"].Value.AsInt(0), CurrentWesternMedicinePrescriptionType))
                {
                    source.DataGridView.CurrentCell = source.Cells["XY_colName"];
                    this.dgvWesternMedicine.BeginEdit(true);
                    msg = "";
                    return false;
                }

                foreach (IView_HIS_DrugInfo item in druginfo)
                {
                    if ((item.DrugName.Trim() == source.Cells["XY_colName"].Value.ToString().Trim() || item.NickName.Trim() == source.Cells["XY_colName"].Value.ToString().Trim()) && item.Specification.Trim() == source.Cells["XY_colGG"].Value.ToString().Trim())
                    {
                        msg = "";
                        if (!IsSave && SysContext.CurrUser.Params.OP_AutoColculateWMNum.Contains("是"))
                        {
                            string interval = Interval.Where(p => p.Code == source.Cells["XY_colJG"].Value.ToString()).First().Count.ToString();
                            if (source.Cells["XY_colBZS"].Value != null)
                            {
                                int num = ColculateXYSL(druginfo[0].MinDose, source.Cells["XY_colTS"].Value.ToString(), source.Cells["XY_colYL"].Value.ToString(), interval, source.Cells["XY_colBZS"].Value.ToString());
                                if (source.Cells["XY_colSL"].Value.AsInt(0) != num)
                                {
                                    if (SysContext.CurrUser.Params.OP_AutoColculateWMNum == "是,显示提示")
                                    {
                                        DialogResult result = MessageBox.Show(string.Format("当前药品 {0} 所输入的数量和系统计算的不一致,是否继续使用当前数量", source.Cells["XY_colName"].Value.ToString().Trim()), "", MessageBoxButtons.YesNo);
                                        if (result == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            return true;
                                        }
                                    }
                                    source.Cells["XY_colSL"].Value = num;
                                }
                            }
                        }
                        return true;
                    }
                }

            }

            source.DataGridView.CurrentCell = source.Cells["XY_colName"];
            this.dgvWesternMedicine.BeginEdit(true);
            msg = ",名称和规格不匹配";
            return false;
        }

        private bool CYValidate(DataGridViewRow source, out string msg, bool IsSave = false)
        {
            string[] MustHaveDataColName = new string[] { "CY_colName", "CY_colSL", "CY_colYL11", "CY_colTS" }; //必须有值得列
            string[] MustIntColName = new string[] { "CY_colTS", "CY_colSL" }; //必须是int的列
            string[] MustNumColName = new string[] { "CY_colYL11" };
            string tmpMsg = "";
            foreach (DataGridViewCell item in source.Cells)
            {
                if (MustHaveDataColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || item.Value.ToString() == "")
                    {
                        tmpMsg = ",此处不能为空";
                    }
                }
                if (MustIntColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || !Regex.IsMatch(item.Value.ToString(), @"^\d*$") || item.Value.AsInt(0) <= 0)
                    {
                        tmpMsg = ",此处必须为整数且大于零";
                    }
                }
                if (MustNumColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || !item.Value.AsFloat().HasValue || item.Value.AsFloat(0) <= 0)
                    {
                        tmpMsg = ",此处必须为数字且大于零";
                    }
                }
                if (tmpMsg != "")
                {
                    source.DataGridView.CurrentCell = item;
                    this.dgvHerbalMedicine.BeginEdit(true);
                    msg = tmpMsg;
                    return false;
                }
            }

            if (!DrugLimit(source.Cells["CY_colYPID"].Value.ToString(), source.Cells["CY_colName"].Value.ToString().Trim(), source.Cells["CY_colSL"].Value.AsInt(0), CurrentWesternMedicinePrescriptionType))
            {
                source.DataGridView.CurrentCell = source.Cells["CY_colName"];
                this.dgvWesternMedicine.BeginEdit(true);
                msg = "";
                return false;
            }

            if (!Regex.IsMatch(this.inputHerbalMedicineNum.Text, @"^\d*$") || this.inputHerbalMedicineNum.Text.AsInt(0) <= 0)
            {
                msg = ",剂数必须为数字且大于零";
                this.inputHerbalMedicineNum.Focus();
                this.inputHerbalMedicineNum.SelectionStart = 0;
                this.inputHerbalMedicineNum.SelectionLength = this.inputHerbalMedicineNum.Text.Length;
                return false;
            }

            if (source.Cells["CY_colYPID"].Value != null)
            {
                List<IView_HIS_DrugInfo> druginfo;
                if (source.Cells["CY_colYPHH"].Value != null)
                {
                    druginfo = HerbalMedicineDrugInfo.Where(p => p.DrugSerial == source.Cells["CY_colYPHH"].Value.ToString() && p.DrugID == source.Cells["CY_colYPID"].Value.ToString()).ToList();
                }
                else
                {
                    druginfo = HerbalMedicineDrugInfo.Where(p => p.DrugID == source.Cells["CY_colYPID"].Value.ToString()).ToList();
                }

                if (druginfo.Count == 0)
                {
                    source.DataGridView.CurrentCell = source.Cells["CY_colName"];
                    this.dgvHerbalMedicine.BeginEdit(true);
                    msg = ",该药品ID未能在药库找到,请检查";
                    return false;
                }
                else
                {
                    if (druginfo[0].Reserve - source.Cells["CY_colSL"].Value.AsInt(0) < 0)
                    {
                        source.DataGridView.CurrentCell = source.Cells["CY_colName"];
                        this.dgvHerbalMedicine.BeginEdit(true);
                        msg = ",该药品已经用完或者不够开";
                        return false;
                    }
                    //else
                    //{
                    //    if (IsSave)
                    //        druginfo.ForEach(p => p.Reserve -= source.Cells["CY_colSL"].Value.AsInt(0));
                    //}
                }

                if (druginfo[0].DrugName.Trim() == source.Cells["CY_colName"].Value.AsString("").Trim() && druginfo[0].Specification.Trim() == source.Cells["CY_colGG"].Value.AsString("").Trim())
                {
                    msg = "";
                    if (IsSave)
                    {
                        float f = source.Cells["CY_colYL11"].Value.AsFloat(1);
                        int num = this.inputHerbalMedicineNum.Text.AsInt(1) * f.AsInt(1);
                        source.Cells["CY_colSL"].Value = num;
                    }
                    return true;
                }
            }

            source.DataGridView.CurrentCell = source.Cells["CY_colName"];
            this.dgvHerbalMedicine.BeginEdit(true);
            msg = ",名称和规格不匹配";
            return false;
        }

        private bool ZLValidate(DataGridViewRow source, out string msg)
        {
            string[] MustHaveDataColName = new string[] { "ZL_colName", "ZL_colSL" }; //必须有值得列
            string[] MustIntColName = new string[] { "ZL_colSL" };
            string[] MustNumColName = new string[] { "ZL_colLSJ" };
            string tmpMsg = "";
            foreach (DataGridViewCell item in source.Cells)
            {
                if (MustHaveDataColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || item.Value.ToString() == "")
                    {
                        tmpMsg = ",此处不能为空";
                    }
                }
                if (MustIntColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || !Regex.IsMatch(item.Value.ToString(), @"^\d*$") || item.Value.AsInt(0) <= 0)
                    {
                        tmpMsg = ",此处必须为整数且大于零";
                    }
                }
                if (MustNumColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || !item.Value.AsFloat().HasValue || item.Value.AsFloat(0) <= 0)
                    {
                        tmpMsg = ",此处必须为数字且大于零";
                    }
                }
                if (tmpMsg != "")
                {
                    source.DataGridView.CurrentCell = item;
                    this.dgvDiagnose.BeginEdit(true);
                    msg = tmpMsg;
                    return false;
                }
            }

            if (source.Cells["ZL_colCode"].Value != null)
            {
                List<IView_HIS_DealWithItem> druginfo = DiagnoseInfo.Where(p => p.Code == source.Cells["ZL_colCode"].Value.ToString()).ToList();
                if (druginfo[0].Name.Trim() == source.Cells["ZL_colName"].Value.ToString().Trim())
                {
                    msg = "";
                    return true;
                }
            }

            source.DataGridView.CurrentCell = source.Cells["ZL_colName"];
            this.dgvDiagnose.BeginEdit(true);
            msg = ",名称和规格不匹配";
            return false;
        }

        private void ColculateXYZJE(DataGridViewRow source)
        {
            double LSJ = source.Cells["XY_colLSJ"].Value.AsDouble(0);
            int SL = source.Cells["XY_colSL"].Value.AsInt(0);
            source.Cells["XY_colZJE"].Value = LSJ * SL;
            ColculateAllItemTotal();
        }

        /// <summary>
        /// 计算药品的数量
        /// </summary>
        /// <param name="MinDose">最小剂量</param>
        /// <param name="Day">天数</param>
        /// <param name="Dose">一次使用剂量</param>
        /// <param name="interval">间隔</param>
        /// <returns></returns>
        private int ColculateXYSL(decimal? MinDose, string Day, string Dose, string interval, string PackingNumber)
        {
            double ThrowawayTaking = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(Dose) / Convert.ToDouble(MinDose)));
            double DayTaking = ThrowawayTaking * Convert.ToInt32(interval);
            double AllTaking = DayTaking * Convert.ToInt32(Day);
            double Num = Math.Ceiling(AllTaking / Convert.ToInt32(PackingNumber));
            return Convert.ToInt32(Num);
            //double result = Math.Ceiling(Convert.ToDouble((Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Convert.ToInt32(Dose) / Convert.ToInt32(MinDose))) * Convert.ToInt32(interval) * Convert.ToInt32(Day)) / Convert.ToInt32(PackingNumber))));
        }

        /// <summary>
        /// 计算草药的数量
        /// </summary>
        /// <param name="MinDose">最小剂量</param>
        /// <param name="Day">天数</param>
        /// <param name="Dose">一次使用剂量</param>
        /// <returns></returns>
        private int ColculateCYSL(string MinDose, string Dose)
        {
            double ThrowawayTaking = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(Dose) / Convert.ToDouble(MinDose)));
            double Num = this.inputHerbalMedicineNum.Text.AsInt(1) * ThrowawayTaking;
            return Convert.ToInt32(Num);
        }

        private void ColculateCYZJE(DataGridViewRow source)
        {
            double LSJ = source.Cells["CY_colLSJ"].Value.AsDouble(0);
            int SL = source.Cells["CY_colSL"].Value.AsInt(0);
            source.Cells["CY_colZJE"].Value = LSJ * SL;
            ColculateAllItemTotal();
        }

        private void ColculateZLZJE(DataGridViewRow source)
        {
            double LSJ = source.Cells["ZL_colLSJ"].Value.AsDouble(0);
            int SL = source.Cells["ZL_colSL"].Value.AsInt(0);
            source.Cells["ZL_colZJE"].Value = LSJ * SL;
            ColculateAllItemTotal();
        }

        private bool CheckTZ(DataGridViewSelectedRowCollection rows)
        {
            string[] MustCommonColName = new string[] { "XY_colYF", "XY_colJG", "XY_colTS" };
            string tmp = "";
            string msg = "";

            List<int> groupNo = rows.Cast<DataGridViewRow>().Where(p => p.Cells["XY_colTZBH"].Value.AsInt(0) != 0).Select(p => p.Cells["XY_colTZBH"].Value.AsInt(0)).Distinct().ToList();
            if (groupNo.Count > 1)
            {
                AlertBox.Info("无法将两个组进行同组操作");
                return false;
            }

            foreach (DataGridViewRow item in rows)
            {
                if (!XYValidate(item, out msg))
                {
                    AlertBox.Info("在指定位置有数据验证失败," + msg);
                    return false;
                }
            }

            foreach (DataGridViewRow item in rows)
            {
                if (tmp == "")
                {
                    foreach (string item1 in MustCommonColName)
                    {
                        tmp += item.Cells[item1].Value.ToString();
                    }
                }
                else
                {
                    string tmp1 = "";
                    foreach (string item1 in MustCommonColName)
                    {
                        tmp1 += item.Cells[item1].Value.ToString();
                    }

                    if (tmp != tmp1)
                    {
                        AlertBox.Info("同组项必须用法、间隔和天数相同");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 从处方主表调取药品详细
        /// </summary>
        public void InitCFFromItemCode()
        {
            List<OP_Prescription_Detail> currPrescription = CurrPatientPrescriptionDetail.Where(p => p.PrescriptionNo == CurrentPrescriptionNo).OrderBy(p => p.No).ToList();
            DataGridView dgv;
            this._herbsGroupName = CurrPatientPrescription.HerbsGroupName;
            if (!string.IsNullOrWhiteSpace(_herbsGroupName))
            {
                _herbsGroupItems.Clear();
                currPrescription.ForEach(p => _herbsGroupItems[p.ItemCode] = p.Amount);
            }
            if (CurrPatientPrescription.PrescriptionType == "2")
            {
                dgv = this.dgvHerbalMedicine;
                CurrentHMPrescriptionNo = CurrentPrescriptionNo;
                CurrentHerbalMedicinePrescriptionType = (PrescriptionType)CurrPatientPrescription.PrescriptionType.AsInt();
                this.btnCYSave.Tag = CurrPatientPrescription.PrescriptionType;
                this.inputHerbalMedicineNum.Text = CurrPatientPrescription.HerbalMedicineNum.ToString();
                if (currPrescription.Count > 0)
                {
                    //this.comboUsage.SelectedValue = currPrescription[0].Usage;
                    this.cbxUsageTips.Text = CurrPatientPrescription.ConditionSummary;
                }
                this.tabPrescription.SelectedTab = this.tabCY;
                if (CurrPatientPrescription.Status != 0)
                {
                    InitCYBar(false);
                }
                else
                {
                    InitCYBar(true);
                }
            }

            else if (CurrPatientPrescription.PrescriptionType == "9")
            {
                dgv = this.dgvDiagnose;
                CurrentDiagnosePrescriptionNo = CurrentPrescriptionNo;
                CurrentDiagnosePrescriptionType = (PrescriptionType)CurrPatientPrescription.PrescriptionType.AsInt();
                this.btnZLSave.Tag = CurrPatientPrescription.PrescriptionType;
                this.tabPrescription.SelectedTab = this.tabZL;
                if (CurrPatientPrescription.Status != 0)
                {
                    InitZLBar(false);
                }
                else
                {
                    InitZLBar(true);
                }
            }
            else
            {
                dgv = this.dgvWesternMedicine;
                CurrentWMPrescriptionNo = CurrentPrescriptionNo;
                CurrentWesternMedicinePrescriptionType = (PrescriptionType)CurrPatientPrescription.PrescriptionType.AsInt();
                this.btnXYSave.Tag = CurrPatientPrescription.PrescriptionType;
                this.tabPrescription.SelectedTab = this.tabXY;
                if (CurrPatientPrescription.Status != 0)
                    InitXYBar(false);
                else
                    InitXYBar(true);
            }

            dgv.Rows.Clear();
            ImportItemFromPrescriptionList(currPrescription, dgv, true);
        }

        public void CopyPrescription(OP_Prescription prescription)
        {
            List<OP_Prescription_Detail> currDetails = CurrPatientPrescriptionDetail.Where(p => p.PrescriptionNo == prescription.PrescriptionNo).OrderBy(p => p.No).ToList();

            currDetails.ForEach(p =>
            {
                p.ID = null;
                p.PrescriptionNo = null;
            });

            this.CurrPatientPrescription = null;
            this.CurrentDiagnosePrescriptionNo = "";
            this.CurrentPrescriptionNo = "";
            this.CurrentWMPrescriptionNo = "";
            this.CurrentHMPrescriptionNo = "";

            DataGridView dgv;
            if (prescription.PrescriptionType == "2")
            {
                dgv = this.dgvHerbalMedicine;
                CurrentHerbalMedicinePrescriptionType = (PrescriptionType)prescription.PrescriptionType.AsInt();
                this.btnCYSave.Tag = prescription.PrescriptionType;
                this.inputHerbalMedicineNum.Text = prescription.HerbalMedicineNum.ToString();
                if (currDetails.Count > 0)
                {
                    //this.comboUsage.SelectedValue = currPrescription[0].Usage;
                    this.cbxUsageTips.Text = prescription.ConditionSummary;
                }
                this.tabPrescription.SelectedTab = this.tabCY;
                InitCYBar(true);
            }

            else if (prescription.PrescriptionType == "9")
            {
                dgv = this.dgvDiagnose;
                CurrentDiagnosePrescriptionType = (PrescriptionType)prescription.PrescriptionType.AsInt();
                this.btnZLSave.Tag = prescription.PrescriptionType;
                this.tabPrescription.SelectedTab = this.tabZL;
                InitZLBar(true);
            }
            else
            {
                dgv = this.dgvWesternMedicine;
                CurrentWesternMedicinePrescriptionType = (PrescriptionType)prescription.PrescriptionType.AsInt();
                this.btnXYSave.Tag = prescription.PrescriptionType;
                this.tabPrescription.SelectedTab = this.tabXY;
                InitXYBar(true);
            }

            dgv.Rows.Clear();
            ImportItemFromPrescriptionList(currDetails, dgv, true);
        }

        /// <summary>
        /// 将项目列表导入到指定的DGV中
        /// </summary>
        /// <param name="currPrescription"></param>
        /// <param name="dgv"></param>
        private void ImportItemFromPrescriptionList(List<OP_Prescription_Detail> currPrescription, DataGridView dgv, bool FromPrescription = false)
        {
            int index = 0;
            if (currPrescription.Count == 0)
            {
                return;
            }

            string targetDGV1 = dgv == this.dgvHerbalMedicine ? "CY_colName" : dgv == this.dgvDiagnose ? "ZL_colName" : null; ;
            string targetDGV2 = dgv == this.dgvHerbalMedicine ? "CY_colGG" : dgv == this.dgvDiagnose ? "ZL_colGG" : null; ; ;
            foreach (OP_Prescription_Detail item in currPrescription)
            {
                bool isSame = false;

                if (dgv == dgvHerbalMedicine)
                {
                    foreach (DataGridViewRow item1 in dgv.Rows)
                    {
                        if (item1.Cells[targetDGV1].Value.AsString("") == item.ItemName.AsString("") && item1.Cells[targetDGV2].Value.AsString("") == item.Specification.AsString(""))
                        {
                            //DialogResult result = MessageBox.Show("已经添加了相同的项目" + Environment.NewLine + "是否录入", "", MessageBoxButtons.YesNo);
                            //if (result == System.Windows.Forms.DialogResult.No)
                            //{
                            //    target.Cells[targetDGV1].Value = "";
                            //    return;
                            //}
                            AlertBox.Info(string.Format("已经添加了相同的项目 {0}", item.ItemName.AsString("")));
                            isSame = true;
                            break;
                        }
                    }
                }

                if (isSame)
                {
                    continue;
                }

                if (dgv == this.dgvWesternMedicine)
                {
                    if (!CheckDrugAuthority(item.ItemName, item.DrugSerial, item.DrugProperties))
                    {
                        continue;
                    }

                    if (this.dgvWesternMedicine.Rows.Count >= MaxWMCount)
                    {
                        AlertBox.Info("西药处方已经超过大处方限制,只可开具" + MaxWMCount.ToString() + "个药");
                        this.tabPrescription.SelectedTab = (dgv.Parent as SuperTabControlPanel).TabItem;
                        return;
                    }
                    if (dgv.Rows.Count == 0 || dgv.Rows[dgv.Rows.Count - 1].Cells[1].Value != null)
                    {
                        index = dgv.Rows.Add();
                    }
                    else
                    {
                        index = dgv.Rows.Count - 1;
                    }

                    if (Usage.Where(p => p.Type == "1" && p.Code == item.Usage.Trim()).Count() == 0)
                    {
                        item.Usage = "po";
                    }

                    if (!FromPrescription)
                    {
                        if (item.DrugProperties.AsString("").Contains('Y'))
                        {

                            if (MessageBox.Show(string.Format("当前药品 {0} 需要皮试,是否皮试", item.ItemName), "系统提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                dgv.Rows[index].Cells["XY_colPS"].Value = "Y";
                                item.SkinTestFlag = "Y";
                            }
                            else
                            {
                                dgv.Rows[index].Cells["XY_colPS"].Value = "N";
                                item.SkinTestFlag = "N";
                            }
                        }
                        //else
                        //{
                        //    dgv.Rows[index].Cells["XY_colPS"].Value = "Y";
                        //    item.SkinTestFlag = "Y";
                        //}
                        else
                        {
                            dgv.Rows[index].Cells["XY_colPS"].Value = "X";
                            item.SkinTestFlag = "X";
                        }
                    }

                }
                else if (dgv == this.dgvHerbalMedicine)
                {
                    if (Usage.Where(p => p.Type == "2" && p.Code == item.Usage.AsString("").Trim()).Count() == 0)
                    {
                        item.Usage = "jf";
                    }

                    if (this.dgvHerbalMedicine.Rows.Count >= MaxHMCount)
                    {
                        AlertBox.Info("草药处方已经超过大处方限制,只可开具" + MaxHMCount.ToString() + "个药");
                        this.tabPrescription.SelectedTab = (dgv.Parent as SuperTabControlPanel).TabItem;
                        return;
                    }

                    if (dgv.Rows.Count == 0 || dgv.Rows[dgv.Rows.Count - 1].Cells[1].Value != null)
                    {
                        index = dgv.Rows.Add();
                    }
                    else
                    {
                        index = dgv.Rows.Count - 1;
                    }

                    if (!FromPrescription)
                    {
                        this.inputHerbalMedicineNum.Text = "1";
                    }
                }
                else
                {
                    if (this.dgvDiagnose.Rows.Count >= MaxDiagnoseCount)
                    {
                        AlertBox.Info("治疗处方已经超过大处方限制,只可开具" + MaxDiagnoseCount.ToString() + "个项目");
                        this.tabPrescription.SelectedTab = (dgv.Parent as SuperTabControlPanel).TabItem;
                        return;
                    }
                    if (dgv.Rows.Count == 0 || dgv.Rows[dgv.Rows.Count - 1].Cells[1].Value != null)
                    {
                        index = dgv.Rows.Add();
                    }
                    else
                    {
                        index = dgv.Rows.Count - 1;
                    }

                    if (item.Price.AsFloat(0) == 0)
                    {
                        dgv.Rows[index].Cells["ZL_colLSJ"].Style.BackColor = Color.White;
                        dgv.Rows[index].Cells["ZL_colLSJ"].ReadOnly = false;
                    }
                    else
                    {
                        dgv.Rows[index].Cells["ZL_colLSJ"].ReadOnly = true;
                    }
                }
                ImportItemFromPrescription(item, dgv, index);

            }
            if (dgv == this.dgvWesternMedicine)
            {
                DrawGroupLine();
            }

            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (dgv == this.dgvWesternMedicine)
                {
                    ColculateXYZJE(item);
                }
                else if (dgv == this.dgvHerbalMedicine)
                {
                    float f = item.Cells["CY_colYL11"].Value.AsFloat(1);
                    int num = this.inputHerbalMedicineNum.Text.AsInt(1) * f.AsInt(1);
                    item.Cells["CY_colSL"].Value = num;
                    ColculateCYZJE(item);
                }
                else
                {
                    ColculateZLZJE(item);
                }
            }
            this.tabPrescription.SelectedTab = (dgv.Parent as SuperTabControlPanel).TabItem;
            dgv.EndEdit();
        }

        private void ImportItemFromPrescription(Dos.ORM.Entity obj, DataGridView dgv, int index)
        {

            var fileds = obj.GetFields().ToList();

            foreach (DataGridViewColumn item1 in dgv.Columns)
            {
                var filed = fileds.Find(p => p.Name == item1.DataPropertyName);
                if (obj.GetFields().Contains(filed))
                {
                    dgv.Rows[index].Cells[item1.Name].Value = obj.GetValues()[fileds.IndexOf(filed)];
                }
            }
        }

        private bool ShowPrescriptionAdditional(string PrescriptionNo)
        {
            string[] IV = new string[] { "IV", "IVD", "IH", "IM" };   //静脉注射的用法列表
            string[] XR = new string[] { "WH" };   //吸入的用法列表
            List<string> list = new List<string>();
            FormPrescriptionAdditional form = new FormPrescriptionAdditional(PrescriptionNo);
            foreach (DataGridViewRow item in this.dgvWesternMedicine.Rows)
            {
                if (IV.Contains(item.Cells["XY_colYF"].Value.ToString().ToUpper().Trim()))
                {
                    if (list.Where(p => p.Contains("1静脉输液,")).Count() == 0)
                    {
                        list.Add("1静脉输液," + item.Cells["XY_colSL"].Value.AsString("1"));
                    }
                }
                if (XR.Contains(item.Cells["XY_colYF"].Value.ToString().ToUpper().Trim()))
                {
                    if (list.Where(p => p.Contains("2氧化雾化吸入,")).Count() == 0)
                    {
                        list.Add("2氧化雾化吸入," + item.Cells["XY_colSL"].Value.AsString("1"));
                    }
                }
                if (item.Cells["XY_colPS"].Value.ToString() == "Y")
                {
                    if (list.Where(p => p.Contains("3皮试,") || p.Contains("4皮肤电极,")).Count() == 0)
                    {
                        list.Add("3皮试," + item.Cells["XY_colSL"].Value.AsString("1"));
                        list.Add("4皮肤电极," + item.Cells["XY_colSL"].Value.AsString("1"));
                    }
                }
            }
            if (list.Count == 0)
            {
                return true;
            }

            form.ShowControl(list);
            return form.IsSave;
        }
        #endregion

        #region 药品及项目导入操作
        private void btnImportHerbs_Click(object sender, EventArgs e)
        {
            if (this.btnCYAdd.Enabled)
            {
                ImportDrug(treeHerbsGroup, dgvHerbalMedicine);
                ClearGroupSelect(this.treeHerbsGroup.Nodes);
            }
            else
            {
                AlertBox.Info("请先添加药方");
            }
        }
        private void btnImportDrug_Click(object sender, EventArgs e)
        {
            if (this.btnXYAdd.Enabled)
            {
                ImportDrug(treeDrugGroup, dgvWesternMedicine);
                ClearGroupSelect(this.treeDrugGroup.Nodes);
            }
            else
            {
                AlertBox.Info("请先添加处方");
            }
        }
        /// <summary>
        /// 导入药品
        /// </summary>
        private void ImportDrug(AdvTree tree, DataGridView dgv)
        {
            List<OP_Prescription_Detail> list = new List<OP_Prescription_Detail>();
            List<Node> nodes = tree.CheckedNodes;

            if (tree == this.treeHerbsGroup)
            {
                foreach (var node in nodes)
                {
                    if (node.Parent.Tag is OP_DrugGroup group)
                    {
                        if (group.GroupType == 0)
                        {
                            _herbsGroupName = group.Name;
                            break;
                        }
                    }
                }
            }

            string groupDetailId = "";
            foreach (Node node in nodes)
            {
                IView_Inside_DrugDetail item = node.Tag as IView_Inside_DrugDetail;
                groupDetailId = item.GroupID;
                if (!CheckDrugAuthority(item.DrugName, item.DrugSerial, item.DrugProperties))
                {
                    continue;
                }

                if (item != null)
                {
                    OP_Prescription_Detail detail = new OP_Prescription_Detail();
                    detail.ItemCode = item.DrugID;
                    detail.ItemName = item.DrugName;
                    detail.Specification = item.Specification;
                    detail.Number = item.Num;
                    detail.PackingUnit = item.PackingUnit;
                    detail.PackingNumber = item.PackingNumber;
                    detail.Amount = item.Amount;
                    //detail.Amount = item.PackingUnit == "袋" ? 1 : item.Amount;
                    detail.DrugSerial = item.DrugSerial;
                    detail.DosageUnit = item.DosageUnit;
                    detail.Usage = item.Usage;
                    detail.Frequency = item.Frequency;
                    detail.Days = item.Days;
                    detail.ProductionSites = item.ProductionSites;
                    detail.DrugProperties = item.DrugProperties;
                    detail.Price = item.DrugPrice;
                    detail.ExecuteDept = item.DrugDept;
                    detail.ItemType = item.DrugCategory;
                    detail.GroupNo = 0;
                    detail.Doses = null;
                    detail.GroupNo = item.GroupNo.AsInt(0);
                    list.Add(detail);

                    if (tree == this.treeHerbsGroup)
                        _herbsGroupItems[detail.ItemCode] = item.Amount;
                }
            }
            if (_herbsGroupItems.Count > 0)
                _herbsGroupQuantity = DBHelper.CIS.FromSql($"select count(*) from op_druggroup_detail where groupid='{groupDetailId}'").ToScalar<int>();

            if (list.Count > 0)
            {
                ImportItemFromPrescriptionList(list, dgv);
            }
        }

        /// <summary>
        /// 从历史处方导入药品
        /// </summary>
        /// <param name="HistoryDGV"></param>
        /// <param name="DGV"></param>
        public void ImportDrug(DataGridView HistoryDGV, string DGV, string HerbalMedicineNum = "")
        {

            List<OP_Prescription_Detail> list = new List<OP_Prescription_Detail>();
            for (int i = 0; i < HistoryDGV.Rows.Count; i++)
            {
                if (DGV != "ZL")
                {
                    string DrugID = HistoryDGV.Rows[i].Cells[DGV + "_colYPID"].Value.AsString("");
                    string DrugName = HistoryDGV.Rows[i].Cells[DGV + "_colName"].Value.AsString("");
                    List<IView_HIS_DrugInfo> info1 = (DGV == "XY" ? WesternMedicineInfo : HerbalMedicineDrugInfo).Where(p => p.DrugID == DrugID).ToList();
                    if (info1.Count == 0)
                    {
                        AlertBox.Info(DrugName + " 该药品ID无法在药品库中搜索到,无法导入");
                        continue;
                    }
                    if (info1[0].Reserve <= 0)
                    {
                        AlertBox.Info(DrugName + " 该药品库存为0,无法导入");
                        continue;
                    }
                }
                if ((bool)(HistoryDGV.Rows[i].Cells[0].Value ?? false))
                {
                    OP_Prescription_Detail detail = new OP_Prescription_Detail();
                    for (int j = 0; j < HistoryDGV.Columns.Count; j++)
                    {
                        var value = HistoryDGV.Rows[i].Cells[j].Value;
                        string name = HistoryDGV.Columns[j].DataPropertyName;
                        PropertyInfo info = detail.GetType().GetProperty(name);
                        if (info != null)
                        {
                            if (info.PropertyType == typeof(int?))
                            {
                                info.SetValue(detail, Convert.ToInt32(value), null);
                            }
                            else if (info.PropertyType == typeof(decimal?))
                            {
                                info.SetValue(detail, Convert.ToDecimal(value), null);
                            }
                            else if (info.PropertyType == typeof(float?))
                            {
                                info.SetValue(detail, Convert.ToSingle(value), null);
                            }
                            else if (info.PropertyType == typeof(string))
                            {
                                info.SetValue(detail, value == null ? null : value.ToString(), null);
                            }
                        }
                    }
                    detail.GroupNo = 0;
                    if (DGV != "ZL")
                    {
                        List<IView_HIS_DrugInfo> info1 = (DGV == "XY" ? WesternMedicineInfo : HerbalMedicineDrugInfo).Where(p => p.DrugID == detail.ItemCode).ToList();
                        if (info1.Count > 0)
                        {
                            detail.ItemType = info1[0].DrugCategory;
                        }
                    }

                    list.Add(detail);

                }
            }
            if (list.Count != 0)
            {
                if ((DGV == "XY" && !this.btnXYAdd.Enabled) || (DGV == "CY" && !this.btnCYAdd.Enabled) || (DGV == "ZL" && !this.btnZLAdd.Enabled))
                {
                    AlertBox.Info("处方未添加,请先添加处方后导入");
                    return;
                }
            }



            if (DGV == "XY")
            {
                ImportItemFromPrescriptionList(list, dgvWesternMedicine);
                this.tabPrescription.SelectedTab = this.tabXY;
                //this.tabPrescription.SelectedTabIndex = 0;
            }
            else if (DGV == "CY")
            {
                ImportItemFromPrescriptionList(list, dgvHerbalMedicine);
                this.inputHerbalMedicineNum.Text = HerbalMedicineNum;
                this.tabPrescription.SelectedTab = this.tabCY;
                //this.tabPrescription.SelectedTabIndex = 2;
            }
            else if (DGV == "ZL")
            {
                ImportItemFromPrescriptionList(list, dgvDiagnose);
                this.tabPrescription.SelectedTab = this.tabZL;
                //this.tabPrescription.SelectedTabIndex = 1;
            }
            this.dgvWesternMedicine.EndEdit();
            this.dgvHerbalMedicine.EndEdit();
            this.dgvDiagnose.EndEdit();

        }

        private void btnImportDearWith_Click(object sender, EventArgs e)
        {
            if (this.btnZLAdd.Enabled)
            {
                ImportDearWith();
                ClearGroupSelect(this.treeDearWithGroup.Nodes);
            }
            else
            {
                AlertBox.Info("请先添加治疗单");
            }
        }
        /// <summary>
        /// 导入治疗与材料套餐上选中的项目
        /// </summary>
        private void ImportDearWith()
        {
            List<OP_Prescription_Detail> list = new List<OP_Prescription_Detail>();
            foreach (Node node in treeDearWithGroup.CheckedNodes)
            {
                IView_Inside_DealWithItem item = node.Tag as IView_Inside_DealWithItem;
                if (item != null)
                {
                    OP_Prescription_Detail detail = new OP_Prescription_Detail();
                    detail.ItemCode = item.Code;
                    detail.ItemName = item.Name;
                    detail.Specification = item.Specification;
                    detail.Number = item.Number;
                    detail.PackingUnit = item.PackingUnit;
                    detail.ExecuteDept = item.ExecuteDept;
                    detail.ItemType = "4";
                    detail.Price = item.Price;
                    detail.GroupNo = 0;
                    detail.Total = item.Price * item.Number;
                    list.Add(detail);
                }
            }

            if (list.Count > 0)
            {
                ImportItemFromPrescriptionList(list, dgvDiagnose);
            }
        }

        private void btnImportDrug_R_Click(object sender, EventArgs e)
        {
            ImportDrug(treeDrugGroup, dgvWesternMedicine);
        }

        private void btnImportDearWith_R_Click(object sender, EventArgs e)
        {
            ImportDearWith();
        }

        private void btnImportHerbs_R_Click(object sender, EventArgs e)
        {
            ImportDrug(treeHerbsGroup, dgvHerbalMedicine);
        }

        #endregion

        #region 窗体事件
        private void controlAmpoule1_Complate(object sender, EventArgs e)
        {
            this.dgvWesternMedicine.CurrentCell = this.dgvWesternMedicine.CurrentRow.Cells["XY_colYF"];
            this.dgvWesternMedicine.BeginEdit(true);
        }
        private void dgvWesternMedicine_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != this.XY_colYL.Index)
            {
                this.controlAmpoule1.Hide();
            }
        }
        private void btnRefreshDrug_Click(object sender, EventArgs e)
        {
            try
            {
                WesternMedicineInfo = DBHelper.CIS.From<IView_HIS_DrugInfo>().Where(p => p.DrugDept == "30000001" || p.DrugDept == "30000002").ToList();
                HerbalMedicineDrugInfo = DBHelper.CIS.From<IView_HIS_DrugInfo>().Where(p => p.DrugDept == "30000003").ToList();
                DiagnoseInfo = DBHelper.CIS.From<IView_HIS_DealWithItem>().ToList();
                AlertBox.Info("药品信息刷新完成,请重新输入药品检索");
            }
            catch
            {
                MessageBox.Show("读取药品信息时出现错误");
            }
        }

        private void btnSaveCheck(object sender, EventArgs e)
        {
            if (!CheckSave())
                return;

            (OP_Prescription, List<OP_Prescription_Detail>) save = (null, null);

            if (sender == this.btnSave)
                save = this.btnXYSave_Click(sender, e);
            else if (this.tabCY.IsSelected)
                save = this.btnCYSave_Click(this.btnCYSave, null);
            else if (this.tabXY.IsSelected)
                save = this.btnXYSave_Click(this.btnXYSave, null);
            else
                save = this.btnZLSave_Click(this.btnZLSave, null);

            if (save.Item1 == null)
                return;


            //formMain.AddPrescriptionCirculationTask();
            //Task.Factory.StartNew(() =>
            //{
            //    var diagnosis = formMain.GEtDiagnosis();
            //    var preAudit = new UploadPreAuditHelper();
            //    var auditResult = preAudit.Handler(save.Item1, save.Item2, WesternMedicineInfo, Usage, diagnosis, AllInterval);
            //    if (auditResult != null)
            //    {
            //        var sign = new UploadPrescriptionSignHelper();
            //        var signResult = sign.Handler(auditResult, save.Item1, save.Item2.Count.ToString());
            //        if (signResult.Item1 != null)
            //        {
            //            var upload = new UploadPrescriptionHelper();
            //            var uploadResult = upload.Handler(signResult.Item1, signResult.Item2);
            //            if (uploadResult != null)
            //            {
            //                DBHelper.CIS.FromSql($"update op_prescription set PrescriptionCirculation_PrescriptionNo='{uploadResult.hiRxno}' where   PrescriptionNo='{save.Item1.PrescriptionNo}'").ExecuteNonQuery();
            //            }
            //        }
            //    }
            //}).ContinueWith(p =>
            //{
            //    formMain.RemovePrescriptionCirculationTask();
            //}, TaskScheduler.Current);
        }

        private void inputHerbalMedicineNum_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvHerbalMedicine.Rows)
            {
                float f = item.Cells["CY_colYL11"].Value.AsFloat(1);
                int num = this.inputHerbalMedicineNum.Text.AsInt(1) * f.AsInt(1);
                item.Cells["CY_colSL"].Value = num;
                ColculateCYZJE(item);
            }
        }
        private void SplitterBottom_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (SysContext.UserPositionSetting == null)
            {
                SysContext.UserPositionSetting = new UserPositionSetting();
            }

            SysContext.UserPositionSetting.PrescriptionPosition = this.tabPrescription.Height;
        }

        private void dgvCY_MouseMove(object sender, MouseEventArgs e)
        {
            this.cbxUsageTips.Text = this.dgvHerbalMedicine.PointToClient(MousePosition).ToString();
        }
        private void btnHistoryPriscription_Click(object sender, EventArgs e)
        {
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                AlertBox.Info("请先选择病人");
                return;
            }
            HistoryPrescription form = new HistoryPrescription();
            form.InitData();
            this.flyout1.Content = form;
            this.flyout1.PointerSide = ePointerSide.Top;
            this.flyout1.TargetControl = sender as LabelX;
            form.form = this;
            this.flyout1.Show();
            this.flyout1.TargetControl = null;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.contextMenuStrip1.Items[0].Enabled = this.btnXYAdd.Enabled;
            this.contextMenuStrip1.Items[1].Enabled = this.btnXYDel.Enabled;
            this.contextMenuStrip1.Items[2].Enabled = this.btnGroupCollect.Enabled;
            this.contextMenuStrip1.Items[3].Enabled = this.btnGroupCollect.Enabled;
            this.contextMenuStrip1.Items[4].Enabled = this.btnXYSave.Enabled;
        }

        private void btnRefreshWM_Click(object sender, EventArgs e)
        {
            InitGroupInfo();
            InitDrugGroupTree(treeDrugGroup, DrugGroupList, 1);
        }

        private void btnRefreshDiagnose_Click(object sender, EventArgs e)
        {
            InitGroupInfo();
            InitDearWithGroupTree(DearWithGroupList);
        }

        private void btnRefreshHM_Click(object sender, EventArgs e)
        {
            InitGroupInfo();
            InitDrugGroupTree(treeHerbsGroup, DrugGroupList, 2);
        }
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.dgvWesternMedicine.SelectAll();
        }
        private void btnXYSelectAll_Click(object sender, EventArgs e)
        {
            btnSelectAll_Click(null, null);
        }

        private void btnZLSelectAll_Click(object sender, EventArgs e)
        {
            this.dgvDiagnose.SelectAll();
        }

        private void btnCYSelectAll_Click(object sender, EventArgs e)
        {
            this.dgvHerbalMedicine.SelectAll();
        }
        private void tabPrescription_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            ColculateAllItemTotal();
        }


        #endregion

        #region 药品限制
        /// <summary>
        /// 药品限制
        /// </summary>
        /// <param name="DrugID"></param>
        /// <param name="DrugName"></param>
        /// <returns></returns>
        private bool DrugLimit(string DrugID, string DrugName, PrescriptionType prescriptionType)
        {
            OP_Dic_DrugPermission drugLimit = listDrugLimit.Find(p => p.DrugID == DrugID);
            if (drugLimit != null)
            {
                if (drugLimit.PrescriptionType == DrugLimitPrescriptionTypeEnum.Normal && prescriptionType != PrescriptionType.Normal)
                    return true;
                else if (drugLimit.PrescriptionType == DrugLimitPrescriptionTypeEnum.Chronic && prescriptionType != PrescriptionType.Chronic)
                    return true;

                bool limitResult = false;

                var deptCode = SysContext.RunSysInfo.currDept.Code;
                var userCode = SysContext.CurrUser.user.Code;
                var jobTitle = SysContext.CurrUser.user.JobTitle;

                var limitDeptCode = drugLimit.DeptCode ?? "";
                var limitUserCode = drugLimit.DoctorCode ?? "";
                var limitTitleName = drugLimit.TitleName ?? "";

                if (limitDeptCode == "" && limitUserCode == "" && limitTitleName == "")
                    return true;

                string msg = "";

                if (drugLimit.Flag == 0)
                {
                    if (!string.IsNullOrEmpty(drugLimit.DeptCode) && !limitResult)
                    {
                        limitResult |= !limitDeptCode.Contains(deptCode);
                        msg = limitResult ? "该药品{0}不在当前科室的使用权限内" : "";
                    }
                    if (!string.IsNullOrEmpty(drugLimit.DoctorCode) && !limitResult)
                    {
                        limitResult |= !limitUserCode.Contains(userCode);
                        msg = limitResult ? "该药品{0}不在当前医生的使用权限内" : "";
                    }
                    if (!string.IsNullOrEmpty(drugLimit.TitleName) && !limitResult)
                    {
                        limitResult |= !limitTitleName.Contains(jobTitle);
                        msg = limitResult ? "该药品{0}不在当前职称的使用权限内" : "";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(drugLimit.DeptCode) && !limitResult)
                    {
                        limitResult |= limitDeptCode.Contains(deptCode);
                        msg = limitResult ? "该药品{0}在当前科室禁止使用" : "";
                    }
                    if (!string.IsNullOrEmpty(drugLimit.DoctorCode) && !limitResult)
                    {
                        limitResult |= limitUserCode.Contains(userCode);
                        msg = limitResult ? "该药品{0}在当前医生禁止使用" : "";
                    }
                    if (!string.IsNullOrEmpty(drugLimit.TitleName) && !limitResult)
                    {
                        limitResult |= limitTitleName.Contains(jobTitle);
                        msg = limitResult ? "该药品{0}在当前职称禁止使用" : "";
                    }
                }


                if (limitResult)
                {
                    msg = string.Format(msg, DrugName);
                    MessageBox.Show(msg);
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// 药品数量限制
        /// </summary>
        /// <param name="DrugID"></param>
        /// <param name="DrugName"></param>
        /// <param name="NowNumber"></param>
        /// <returns></returns>
        private bool DrugLimit(string DrugID, string DrugName, int NowNumber, PrescriptionType prescriptionType)
        {
            OP_Dic_DrugPermission permission = listDrugLimit.Find(p => p.DrugID == DrugID);
            string idCard = SysContext.GetCurrPatient.IDCard;
            string cardNo = SysContext.GetCurrPatient.CardNo;
            string userID = SysContext.CurrUser.user.Code;

            //如果没有身份证号,那么就不判断数量
            if (idCard == null || idCard == "")
                return true;

            if (permission != null)
            {
                if (permission.PrescriptionType == DrugLimitPrescriptionTypeEnum.Normal && prescriptionType != PrescriptionType.Normal)
                    return true;
                else if (permission.PrescriptionType == DrugLimitPrescriptionTypeEnum.Chronic && prescriptionType != PrescriptionType.Chronic)
                    return true;

                int? patientNumber = permission.PatientNumber;
                int? doctorNumber = permission.DoctorNumber;
                //这里判断病人是否超过了指定数量
                if (patientNumber != null && patientNumber != 0)
                {
                    string time = "";
                    if (permission.PatientNumberInterval == "月")
                        time = string.Format("{0:yyyy-MM-01}", DateTime.Now);
                    else
                        time = string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(-1));


                    int sum = DBHelper.CIS.FromSql($@"SELECT ISNULL(SUM(NUMBER),0) FROM (
                                                    SELECT SUM(B.NUMBER) AS NUMBER FROM OP_Prescription A
                                                    LEFT JOIN OP_Prescription_Detail B ON A.PrescriptionNo = B.PrescriptionNo AND B.ItemCode = '{DrugID}'
                                                    WHERE (A.IDCARD = '{idCard}' OR A.CardNo='{cardNo}') AND A.UPDATETIME >= '{time}' AND A.Status < 3
                                                    UNION ALL
                                                    SELECT SUM(B.NUMBER) AS NUMBER FROM OP_Prescription_History A
                                                    LEFT JOIN OP_Prescription_Detail_History B ON A.PrescriptionNo = B.PrescriptionNo AND B.ItemCode = '{DrugID}'
                                                    WHERE (A.IDCARD = '{idCard}' OR A.CardNo='{cardNo}') AND A.UPDATETIME >= '{time}' AND A.Status < 3) A").ToScalar<int>();
                    if (sum + NowNumber > patientNumber)
                    {
                        MessageBox.Show(string.Format($"药品<{DrugName}>限制病人数量使用,限制数量为：{patientNumber},已经开具数量为：{sum + NowNumber}"));
                        return false;
                    }
                }

                //这里判断医生是否超过了指定数量
                if (doctorNumber != null && doctorNumber != 0)
                {
                    string time = "";
                    if (permission.DoctorNumberInterval == "月")
                        time = string.Format("{0:yyyy-MM-01}", DateTime.Now);
                    else
                        time = string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(-1));

                    int sum = DBHelper.CIS.FromSql($@"SELECT ISNULL(SUM(NUMBER),0) FROM (
                                                      SELECT SUM(B.NUMBER) AS NUMBER
                                                      FROM OP_PRESCRIPTION A
                                                      LEFT JOIN OP_PRESCRIPTION_DETAIL B ON A.PRESCRIPTIONNO = B.PRESCRIPTIONNO
                                                      WHERE A.USERID = '{userID}' AND B.ITEMCODE = '{DrugID}' AND A.UPDATETIME >= '{time}' AND A.Status < 3
                                                      UNION ALL
                                                      SELECT SUM(B.NUMBER) AS NUMBER
                                                      FROM OP_PRESCRIPTION_HISTORY A
                                                      LEFT JOIN OP_PRESCRIPTION_DETAIL_HISTORY B ON A.PRESCRIPTIONNO = B.PRESCRIPTIONNO
                                                      WHERE A.USERID = '{userID}' AND B.ITEMCODE = '{DrugID}' AND A.UPDATETIME >= '{time}' AND A.Status < 3) C").ToScalar<int>();

                    if (sum + NowNumber > doctorNumber)
                    {
                        MessageBox.Show(string.Format($"药品<{DrugName}>限制医生数量使用,限制数量为：{doctorNumber},已经开具数量为：{sum + NowNumber}"));
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 控制基药检索背景颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWesternMedicineDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string intGrade = this.dgvWesternMedicineDetail.Rows[e.RowIndex].Cells["IsJY"].Value.ToString();
                if (intGrade == "1")
                {
                    dgvWesternMedicineDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
        }
        /// <summary>
        /// 心电调阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void biEcgQueryReport_Click(object sender, EventArgs e)
        {
            if (SysContext.RunSysInfo.Params.OP_EcgRead)
            {
                string Url = SysContext.RunSysInfo.Params.OP_EcgReadUrl;
                if (Url.IsNullOrWhiteSpace())
                    return;
                if (SysContext.GetCurrPatient == null)
                {
                    AlertBox.Error("请先选择患者！");
                    return;
                }
                Url += SysContext.GetCurrPatient.OutpatientNo;
                //调用IE浏览器
                System.Diagnostics.Process.Start("iexplore.exe", Url);
            }
        }

        private void 药品说明书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedRows = this.dgvWesternMedicine.SelectedRows;
            if (selectedRows.Count == 0)
            {
                return;
            }

            var selectedRow = selectedRows[0];
            var item = selectedRow.Tag as IView_HIS_DrugInfo;
            if (item == null)
                return;

            var xml = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<HisDrugMsg>
    <ipAddr>{SysContext.ClientIP}</ipAddr>
    <DrugHisId>{item.reyphh.ToString()}</DrugHisId>
    <HospitalId>a5a1b0a1-f27a-4ac1-96db-dc7308e278e7</HospitalId>
</HisDrugMsg> ";
            Clipboard.SetText(xml);

            var drugAudit = new MedOrdersAudit.IPrescriptionAuditToHospitalWSI1_1Service();
            var result = drugAudit.HisDrugManualByAuditClient(SysContext.CurrUser.user.Code, xml);
        }

    }

    public class DataGridViewTextBoxExtColumn : DataGridViewTextBoxColumn
    {
        public DataGridViewTextBoxExtColumn()
        {
            this.CellTemplate = new DataGridViewTextBoxCell();
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                base.CellTemplate = value;
            }
        }

        [Category("附加"), Description("附加属性1")]
        public string Tag1 { get; set; }
        [Category("附加"), Description("附加属性2")]
        public string Tag2 { get; set; }
        [Category("附加"), Description("附加属性3")]
        public string Tag3 { get; set; }
        [Category("附加"), Description("附加属性4")]
        public string Tag4 { get; set; }

        public override object Clone()
        {
            DataGridViewTextBoxExtColumn col = (DataGridViewTextBoxExtColumn)base.Clone();
            col.Tag1 = Tag1;
            col.Tag2 = Tag2;
            col.Tag3 = Tag3;
            col.Tag4 = Tag4;
            return col;
        }

    }
}

