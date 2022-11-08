using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.AdvTree;
using CIS.Model;
using CIS.Utility;
using CIS.DAL.Template;

namespace App_Template.WordLIB
{
    public partial class FormWordLIB : Form
    {
        public FormWordLIB()
        {
            InitializeComponent();
        }

        List<IView_Dept> dept;

        #region 初始化操作
        private void InitData()
        {
            List<TP_WordLIB> Me = WordLIBDal.GetPerson(CIS.Core.SysContext.CurrUser.user.ID);
            this.nodeMe.Nodes.Clear();
            List<TreeModel1> list = new List<TreeModel1>();
            foreach (TP_WordLIB item in Me)
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0, Sort = item.No ?? 0 });
            CIS.Utility.TreeHelper.CreateChildsNode(nodeMe.Nodes, "", list, false, this.imageList1, true);

            this.tvPerson.ExpandAll();
            dept = CIS.Purview.Purview.GetDeptList();
        }

        /// <summary>
        /// 初始化界面的可用性
        /// </summary>
        /// <param name="enable"></param>
        private void InitUI(bool enable)
        {
            this.tbxSearchCode.Enabled = enable;
            this.radioIP.Enabled = enable;
            this.tbxDescript.Enabled = enable;
            this.radioOP.Enabled = enable;
            this.pictureBox1.Enabled = enable;
            this.pictureBox2.Enabled = enable;
            this.tokenTag.BackgroundStyle.BackColor = enable ? Color.White : Color.FromArgb(240, 240, 240);
            this.tokenTemplate.BackgroundStyle.BackColor = enable ? Color.White : Color.FromArgb(240, 240, 240);
            this.tokenDept.BackgroundStyle.BackColor = enable ? Color.White : Color.FromArgb(240, 240, 240);
            this.tokenDept.Enabled = enable;
            this.tokenTemplate.Enabled = enable;
            this.tokenTag.Enabled = enable;
            this.elementDesignControl1.InitUI(enable);
        }

        private Node GetTopParentNode(Node node)
        {
            if (node.Parent == nodeMe)
                return node;
            else
                return GetTopParentNode(node.Parent);
        }
        #endregion

        #region 元素增删改查
        /// <summary>
        /// 增加文件夹
        /// </summary>
        /// <param name="tree">科室树还是个人树</param>
        private void AddFolder(AdvTree tree, bool IsFolder)
        {
            this.elementDesignControl1.Write.XMLText = "";
            TP_WordLIB newLib;
            string Name = IsFolder ? "新组" : "新元素";
            Node node = new Node(Name);
            node.ImageIndex = IsFolder ? 0 : 1;
            Node Select = tree.SelectedNode;
            if (Select == null)
            {
                CIS.Core.AlertBox.Info("请先选中一个节点");
                return;
            }
            if (Select != nodeMe)
            {
                if ((Select.Tag as TP_WordLIB).NodeType == 1)
                {
                    CIS.Core.AlertBox.Info("必须在组内添加元素");
                    return;
                }
            }
            if (Select == nodeMe || Select != null)
            {
                TP_WordLIB lib = Select.Tag as TP_WordLIB;
                newLib = new TP_WordLIB() { ID = Guid.NewGuid().ToString(), Name = Name, SpellCode = Name.GetSpell(), ParentID = "", WubiCode = Name.GetWBM(), NodeType = IsFolder ? 0 : 1, Status = 1, UpdateTime = DateTime.Now, UpdatorID = CIS.Core.SysContext.CurrUser.user.ID };
                if (tree == tvPerson)
                {
                    newLib.UserID = CIS.Core.SysContext.CurrUser.user.ID;
                }
                else
                {
                    newLib.DTLimit = CIS.Core.SysContext.RunSysInfo.currDept.Code;
                }
                if (lib != null && lib.NodeType != 1)
                    newLib.ParentID = lib.ID;

                Select.Nodes.Add(node);
                newLib.No = node.Index;
                node.Tag = newLib;
                DBHelper.CIS.Insert<TP_WordLIB>(newLib);

                this.tbxName.Text = Name;
                this.tbxSpellCode.Text = Name.GetSpell();
                this.tbxWubiCode.Text = Name.GetWBM();
                if (IsFolder)
                    InitUI(false);
                else
                    InitUI(true);
                tree.SelectNode(node, eTreeAction.Code);
                tree.Focus();
            }
            else
                CIS.Core.AlertBox.Info("不能在非本人和本科室下添加内容");
        }

        #endregion

        #region 窗体事件
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureBox).Image = Properties.Resources.get;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).Image = Properties.Resources.lost;
        }

        private void btnMeAddFolder_Click(object sender, EventArgs e)
        {
            AddFolder(this.tvPerson, true);
        }

        private void btnDeptAddFolder_Click(object sender, EventArgs e)
        {
        }

        private void btnMeAddElement_Click(object sender, EventArgs e)
        {
            AddFolder(this.tvPerson, false);
        }

        private void btnDeptAddElement_Click(object sender, EventArgs e)
        {
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            this.tbxSpellCode.Text = this.tbxName.Text.GetSpell();
            this.tbxWubiCode.Text = this.tbxName.Text.GetWBM();
        }

        private void tvPerson_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            object obj = e.Node.Tag;
            if (obj == null)
                return;
            TP_WordLIB lib = obj as TP_WordLIB;
            if (lib.NodeType == 0)
                InitUI(false);
            else
                InitUI(true);
            this.tbxName.Text = lib.Name;
            this.tbxDescript.Text = lib.Description;
            this.tbxSearchCode.Text = lib.SearchCode;
            this.tbxSpellCode.Text = lib.SpellCode;
            this.tbxWubiCode.Text = lib.WubiCode;
            this.tokenTag.SelectedTokens.Clear();
            this.tokenDept.SelectedTokens.Clear();
            this.tokenTemplate.SelectedTokens.Clear();
            this.radioOP.Checked = lib.SystemSign == 1;
            this.elementDesignControl1.Write.XMLText = lib.Content;
            this.radioIP.Checked = lib.SystemSign == 0;
            if (lib.Tag != null)
            {
                string[] str = lib.Tag.Split(',');
                if (str[0] != "" && str[0] != "*")
                    foreach (string item in str)
                        this.tokenTag.SelectedTokens.Add(new DevComponents.DotNetBar.Controls.EditToken(item));

            }
            //if (lib.DTLimit != null)
            //{
            //    if (lib.DTLimit != "*")
            //    {
            //        this.tokenDept.Enabled = true;
            //        this.pictureBox1.Enabled = true;
            //        List<IView_Dept> deptTmp = dept.Where(p => p.Code.In(lib.DTLimit.Split(','))).ToList();
            //        foreach (IView_Dept item in deptTmp)
            //        {
            //            DevComponents.DotNetBar.Controls.EditToken token = new DevComponents.DotNetBar.Controls.EditToken(item.Name);
            //            token.Tag = item.Code;
            //            this.tokenTag.SelectedTokens.Add(token);
            //        }
            //    }
            //    else
            //    {
            //        this.tokenDept.Enabled = false;
            //        this.pictureBox1.Enabled = false;
            //    }
            //}

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Node node = this.tvPerson.SelectedNode;
            if (node != null)
            {
                TP_WordLIB lib = node.Tag as TP_WordLIB;
                if (lib == null) return;
                lib.Name = this.tbxName.Text;
                lib.No = node.Index;
                lib.ParentID = node.Level == 1 ? "" : (node.Parent.Tag as TP_WordLIB).ID;
                lib.SearchCode = this.tbxSearchCode.Text;
                lib.SpellCode = this.tbxSpellCode.Text;
                lib.Status = 1;
                lib.UpdateTime = DateTime.Now;
                lib.UpdatorID = CIS.Core.SysContext.CurrUser.user.ID;
                lib.WubiCode = this.tbxWubiCode.Text;
                lib.SystemSign = this.radioIP.Checked ? 0 : 1;
                lib.Description = this.tbxDescript.Text;
                lib.Content = this.elementDesignControl1.WriterControl.XMLTextUnFormatted;
                node.Text = lib.Name;
                List<string> list = new List<string>();
                foreach (DevComponents.DotNetBar.Controls.EditToken item in this.tokenTag.SelectedTokens)
                    list.Add(item.Value);
                lib.Tag = string.Join(",", list.ToArray());

                foreach (DevComponents.DotNetBar.Controls.EditToken item in this.tokenDept.SelectedTokens)
                    list.Add(item.Tag.ToString());
                lib.Tag = string.Join(",", list.ToArray());

                foreach (DevComponents.DotNetBar.Controls.EditToken item in this.tokenTemplate.SelectedTokens)
                    list.Add(item.Tag.ToString());
                lib.Tag = string.Join(",", list.ToArray());

                if (lib.ID == null)
                {
                    lib.ID = Guid.NewGuid().ToString();
                    DBHelper.CIS.Insert<TP_WordLIB>(lib);
                }
                else
                    DBHelper.CIS.Update<TP_WordLIB>(lib, p => p.ID == lib.ID);
                node.Tag = lib;
                CIS.Core.AlertBox.Info("保存成功");
            }

        }

        private void btnMeDel_Click(object sender, EventArgs e)
        {
            Node node = this.tvPerson.SelectedNode;
            if (node == null) return;
            string ID = (node.Tag as TP_WordLIB).ID;
            string sql = string.Format("WITH C AS(SELECT A.ID FROM TP_WordLIB AS A WHERE A.ParentID='{0}' UNION ALL SELECT T.ID FROM TP_WordLIB AS T INNER JOIN C ON T.ParentID=C.ID) DELETE from TP_WordLIB where ID in(select * from c) DELETE from TP_WordLIB where ID ='{0}'", ID);
            DBHelper.CIS.FromSql(sql).ExecuteNonQuery();
            node.Parent.Nodes.Remove(node);
        }

        private void btnDeptDel_Click(object sender, EventArgs e)
        {
            Node node = this.tvPerson.SelectedNode;
            if (node == null) return;
            if (this.tvPerson.SelectedNode.FullPath.Substring(0, 3) == "本科室")
            {
                string ID = (node.Tag as TP_WordLIB).ID;
                string sql = string.Format("WITH C AS(SELECT A.ID FROM TP_WordLIB AS A WHERE A.ParentID='{0}' UNION ALL SELECT T.ID FROM TP_WordLIB AS T INNER JOIN C ON T.ParentID=C.ID) DELETE from TP_WordLIB where ID in(select * from c) DELETE from TP_WordLIB where ID ='{0}'", ID);
                DBHelper.CIS.FromSql(sql).ExecuteNonQuery();
                node.Parent.Nodes.Remove(node);
            }
        }
        #endregion

        private void FormWordLIB_Shown(object sender, EventArgs e)
        {
            InitData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (DevComponents.DotNetBar.Controls.EditToken item in this.tokenDept.SelectedTokens)
                list.Add(item.Tag.ToString());

            FormSelectDept form = new FormSelectDept();
            form.DeptCode = list;
            form.ShowDialog();
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.elementDesignControl1.Write.ExecuteCommand("ElementProperties", false, null);
        }

        private void tvPerson_BeforeNodeDrop(object sender, TreeDragDropEventArgs e)
        {
            TP_WordLIB lib = e.Node.Tag as TP_WordLIB;
            TP_WordLIB newLib = e.NewParentNode.Tag as TP_WordLIB;
            if (newLib == null)
            {
                lib.ParentID = "";
            }
            else if (newLib.NodeType == 1)
            {
                CIS.Core.AlertBox.Info("不允许在词库下创建内容");
                e.Cancel = true;
                return;
            }
            else
                lib.ParentID = newLib.ID;
            DBHelper.CIS.Update<TP_WordLIB>(lib, p => p.ID == lib.ID);
        }
    }
}