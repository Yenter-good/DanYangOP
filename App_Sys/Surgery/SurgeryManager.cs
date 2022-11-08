using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.SuperGrid;
using CIS.Core;

namespace App_Sys.Surgery
{
    public partial class SurgeryManager : Form
    {
        public SurgeryManager()
        {
            InitializeComponent();
        }

        private List<Sys_Dic_Surgery> SurgeryList = new List<Sys_Dic_Surgery>();//手术列表
        private List<Sys_Dic_SurgeryCategory> CategoryList = new List<Sys_Dic_SurgeryCategory>();//字典  手术归类
        private List<Sys_Dic_SurgeryIncision> IncisionList = new List<Sys_Dic_SurgeryIncision>();//字典  手术切口
        private List<Sys_Dic_SurgeryLevel> LevelList = new List<Sys_Dic_SurgeryLevel>();//         字典  手术等级
        private List<IView_Dept> DeptList = new List<IView_Dept>();
        private String EditType = "Edit";
        private Sys_Dic_Surgery CurrSurgery = new Sys_Dic_Surgery();

        private void SurgeryManager_Shown(object sender, EventArgs e)
        {
            InitData();
            InitUI();
            InitTree();
        }


        private void InitData()
        {
            SurgeryList = DBHelper.CIS.From<Sys_Dic_Surgery>().ToList();
            CategoryList = DBHelper.CIS.From<Sys_Dic_SurgeryCategory>().ToList();
            IncisionList = DBHelper.CIS.From<Sys_Dic_SurgeryIncision>().ToList();
            LevelList = DBHelper.CIS.From<Sys_Dic_SurgeryLevel>().ToList();
            DeptList = DBHelper.CIS.From<IView_Dept>().Where(x => x.Type == 1 || x.Type == 3).ToList();//取门诊和住院临床科室
        }

        private void InitUI()
        {
            pnlDetail.Enabled = false;

            cbxCategory.DataSource = CategoryList;
            cbxCategory.DisplayMember = "Name";
            cbxCategory.ValueMember = "Name";
            cbxCategory.SelectedIndex = -1;

            cbxIncisionType.DataSource = IncisionList;
            cbxIncisionType.DisplayMember = "Name";
            cbxIncisionType.ValueMember = "Code";
            cbxIncisionType.SelectedIndex = -1;

            cbxLevel_GB.DataSource = LevelList;
            cbxLevel_GB.DisplayMember = "Name";
            cbxLevel_GB.ValueMember = "Code";
            cbxLevel_GB.SelectedIndex = -1;

            cbxLevel_Inside.DataSource = LevelList;
            cbxLevel_Inside.DisplayMember = "Name";
            cbxLevel_Inside.ValueMember = "Code";
            cbxLevel_Inside.SelectedIndex = -1;

            gridSurgery.PrimaryGrid.DataSource = SurgeryList;
            gridSurgery.PrimaryGrid.AutoGenerateColumns = false;


            Application.DoEvents();//处理消息队列 清除界面堵塞
            gridSurgery.PrimaryGrid.ClearSelectedCells();//默认不选择行

        }

        private void InitTree()
        {
            foreach (IView_Dept dept in DeptList)
            {
                Node node = new Node();
                node.CheckBoxVisible = true;
                node.Text = dept.Name;
                node.Tag = dept;
                if (dept.Type == 1)
                    nodeMZ.Nodes.Add(node);
                else
                    nodeZY.Nodes.Add(node);
            }
        }


        private void ClearForm()
        {
            txtCode.Text = "";
            txtDoctorNumber.Text = "";
            txtName.Text = "";
            txtSearchCode.Text = "";
            cbxCategory.SelectedIndex = -1;
            cbxIncisionType.SelectedIndex = -1;
            cbxLevel_GB.SelectedIndex = -1;
            cbxLevel_Inside.SelectedIndex = -1;
            cbxStatus.SelectedIndex = -1;
            checkDept.Checked = false;

            CurrSurgery = new Sys_Dic_Surgery();
        }


        //给详细信息赋值
        private void SetValue(Sys_Dic_Surgery surgery)
        {
            txtCode.Text = surgery.Code;
            txtDoctorNumber.Text = surgery.DoctorNumber.ToString();
            txtName.Text = surgery.Name;
            txtSearchCode.Text = surgery.SearchCode;
            cbxCategory.SelectedValue = surgery.Category;
            cbxIncisionType.SelectedValue = surgery.IncisionType;
            cbxLevel_GB.SelectedValue = surgery.Level_GB;
            cbxLevel_Inside.SelectedValue = surgery.Level_Inside;
            cbxStatus.SelectedIndex = surgery.Status.AsInt(0);
            if (surgery.DeptCode == "*")
                checkDept.Checked = true;
            else
                checkDept.Checked = false;
                SetDeptValue(surgery);
        }
        //获取手术信息
        private Sys_Dic_Surgery GetValue()
        {
            Sys_Dic_Surgery surgery = new Sys_Dic_Surgery();
            surgery.Code=txtCode.Text;
            surgery.DoctorNumber = Convert.ToInt32(txtDoctorNumber.Text);
            surgery.Name = txtName.Text;
            surgery.SearchCode = txtSearchCode.Text;
            surgery.Category = cbxCategory.SelectedValue.ToString();
            surgery.IncisionType = Convert.ToInt32(cbxIncisionType.SelectedValue);
            surgery.Level_GB = Convert.ToInt32(cbxLevel_GB.SelectedValue);
            surgery.Level_Inside = Convert.ToInt32(cbxLevel_Inside.SelectedValue);
            surgery.Status = cbxStatus.SelectedIndex;
            if (checkDept.Checked == true)
                surgery.DeptCode = "*";
            else
                surgery.DeptCode = GetDeptValue();

            return surgery;
        }
        //设置科室是否开展该手术
        private void SetDeptValue(Sys_Dic_Surgery surgery)
        {
            foreach (Node node in nodeMZ.Nodes)
            {
                IView_Dept dept = node.Tag as IView_Dept;
                String deptStr = surgery.DeptCode;
                if (deptStr.IndexOf(dept.Code.Trim()) >= 0)
                {
                    node.Checked = true;
                    break;
                }
            } 
            foreach (Node node in nodeZY.Nodes)
            {
                IView_Dept dept = node.Tag as IView_Dept;
                String deptStr = surgery.DeptCode;
                if (deptStr.IndexOf(dept.Code.Trim()) >= 0)
                {
                    node.Checked = true;
                    break;
                }
            }

        }
        //获取开展该手术的科室
        private String GetDeptValue()
        {
            StringBuilder deptStr = new StringBuilder();
            foreach (Node node in nodeMZ.Nodes)
            {
                if (node.Checked == false) continue;
                IView_Dept dept = node.Tag as IView_Dept;
                deptStr.Append(dept.Code+";");
            }
            foreach (Node node in nodeZY.Nodes)
            {
                if (node.Checked == false) continue;
                IView_Dept dept = node.Tag as IView_Dept;
                deptStr.Append(dept.Code + ";");
            }
            return  deptStr.ToString().Substring(0,deptStr.ToString().Length -1);
        }

        private void checkDept_CheckedChanged(object sender, EventArgs e)
        {
            CheckedNodes(checkDept.Checked);
        }

        //全选
        private void CheckedNodes(bool f)
        {
            foreach (Node node in nodeMZ.Nodes)
            {
                node.Checked = f;
            } 
            foreach (Node node in nodeZY.Nodes)
            {
                node.Checked = f;
            }
        }

        private void gridSurgery_RowClick(object sender, DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs e)
        {
            SelectedElementCollection rows = gridSurgery.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一行手术");
                return;
            }
            GridRow row = rows[0] as GridRow;
            Sys_Dic_Surgery surgery = row.DataItem as Sys_Dic_Surgery;
            CurrSurgery = surgery;
            SetValue(surgery);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pnlDetail.Enabled = true;
            txtCode.Enabled = true;
            EditType = "Add";
            ClearForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnlDetail.Enabled = true;
            txtCode.Enabled = false;
            EditType = "Edit";
        }

        private void gridSurgery_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            pnlDetail.Enabled = true;
            txtCode.Enabled = false;
            EditType = "Edit";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = gridSurgery.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一行");
                return;
            }
            Sys_Dic_Surgery surgery = GetValue();
            int i = 0;

            if (EditType == "Edit")
                i = DBHelper.CIS.Update<Sys_Dic_Surgery>(surgery, Sys_Dic_Surgery._.Code == surgery.Code);
            else
                i = DBHelper.CIS.Insert(surgery);

            if (i > 0)
            {
                SurgeryList.Remove(CurrSurgery);
                SurgeryList.Insert(0, surgery);
                gridSurgery.PrimaryGrid.DataSource = SurgeryList;
                Application.DoEvents();//处理消息队列 清除界面堵塞
                gridSurgery.PrimaryGrid.ClearSelectedCells();//默认不选择行
                AlertBox.Info("保存成功!");
            }
            else
                AlertBox.Error("保存失败!");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txtSearch.Text.Trim();
            if (text.Trim().Length < 1)
                gridSurgery.PrimaryGrid.DataSource = SurgeryList;
            List<Sys_Dic_Surgery> subList = SurgeryList.Where(x =>  x.SearchCode.AsNotNullString().ToUpper().Contains(text.ToUpper()) || x.Name.AsNotNullString().ToUpper().Contains(text.ToUpper())).ToList();
            gridSurgery.PrimaryGrid.DataSource = subList;
        }


    }
}
