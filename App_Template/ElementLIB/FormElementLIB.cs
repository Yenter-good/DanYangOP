using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using CIS.Utility;
using DevComponents.AdvTree;

namespace App_Template.ElementLIB
{
    public partial class FormElementLIB : CIS.Core.BaseForm
    {
        public FormElementLIB()
        {
            InitializeComponent();
        }

        #region 变量

        private List<TP_ElementLIB> ElementLIB = new List<TP_ElementLIB>();

        #endregion 变量

        #region 初始化操作

        private void InitElement()
        {
            ElementLIB = DBHelper.CIS.From<TP_ElementLIB>().ToList();
            InitTree();
        }

        private void InitTree()
        {
            this.tvElementLIB.Nodes.Clear();
            List<TreeModel1> list = new List<TreeModel1>();
            foreach (TP_ElementLIB item in ElementLIB)
            {
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType, Sort = item.No ?? 0 });
            }
            CIS.Utility.TreeHelper.CreateChildsNode(this.tvElementLIB.Nodes, "", list, false, this.imageList1, true);
            this.tvElementLIB.ExpandAll();
        }

        private void InitTree(string FilterStr)
        {
            List<TP_ElementLIB> tmp = new List<TP_ElementLIB>();
            List<TreeModel1> list = new List<TreeModel1>();
            tmp = ElementLIB.Where(p => (p.SearchCode.Contains(FilterStr) || p.Name.Contains(FilterStr) || p.SpellCode.Contains(FilterStr)) && p.NodeType == 1).ToList();
            foreach (TP_ElementLIB item in tmp)
            {
                TP_ElementLIB lib = ElementLIB.Where(p => p.ID == item.ParentID).First();
                if (!tmp.Contains(lib))
                    tmp.Add(lib);
            }
            foreach (TP_ElementLIB item in tmp)
            {
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType, Sort = item.No ?? 0 });
            }
            this.tvElementLIB.Nodes.Clear();
            CIS.Utility.TreeHelper.CreateChildsNode(this.tvElementLIB.Nodes, "", list, false, this.imageList1, true);
            this.tvElementLIB.ExpandAll();
        }

        #endregion 初始化操作

        #region 元素增删改查

        /// <summary>
        /// 增加新的元素
        /// </summary>
        private void AddElement()
        {
            Node node = new Node("新元素");
            node.ImageIndex = 1;
            TP_ElementLIB lib = new TP_ElementLIB() { ID = Guid.NewGuid().ToString(), Name = "新元素", NodeType = 1, SpellCode = "新元素".GetSpell(), WubiCode = "新元素".GetWBM(), UpdatorID = CIS.Core.SysContext.CurrUser.user.ID, UpdateTime = DateTime.Now };
            node.Tag = lib;
            Node Select = this.tvElementLIB.SelectedNode;
            if (Select != null && (Select.Tag as TP_ElementLIB).NodeType == 0)
                Select.Nodes.Add(node);
            else
            {
                CIS.Core.AlertBox.Info("请将元素添加到组内");
                return;
            }
            this.WriteControl.Write.XMLText = "";
            lib.ParentID = Select == null ? "" : (Select.Tag as TP_ElementLIB).ID;
            DBHelper.CIS.Insert<TP_ElementLIB>(lib);
            this.tbxName.Text = "新元素";
            this.tbxSpellCode.Text = "新元素".GetSpell();
            this.tbxWubiCode.Text = "新元素".GetWBM();
            this.tokenTag.Enabled = true;
            this.tbxSearchCode.Enabled = true;
            this.tvElementLIB.SelectNode(node, eTreeAction.Code);
            this.tvElementLIB.Focus();
            if (!node.IsDisplayed)
                node.EnsureVisible();
        }

        /// <summary>
        /// 增加一个组
        /// </summary>
        private void AddFolder()
        {
            Node node = new Node("新组");
            node.ImageIndex = 0;

            TP_ElementLIB lib = new TP_ElementLIB() { ID = Guid.NewGuid().ToString(), Name = "新组", NodeType = 0, SpellCode = "新组".GetSpell(), WubiCode = "新组".GetWBM(), UpdateTime = DateTime.Now, UpdatorID = CIS.Core.SysContext.CurrUser.user.ID };
            node.Tag = lib;
            Node Select = this.tvElementLIB.SelectedNode;

            if (Select == null)
                this.tvElementLIB.Nodes.Add(node);
            else if ((Select.Tag as TP_ElementLIB).NodeType == 0)
                Select.Nodes.Add(node);
            else
            {
                CIS.Core.AlertBox.Info("元素下无法创建内容");
                return;
            }
            lib.ParentID = Select == null ? "" : (Select.Tag as TP_ElementLIB).ID;
            DBHelper.CIS.Insert<TP_ElementLIB>(lib);
            this.tbxName.Text = "新组";
            this.tbxSpellCode.Text = "新组".GetSpell();
            this.tbxWubiCode.Text = "新组".GetWBM();
            this.tokenTag.Enabled = false;
            this.tbxSearchCode.Enabled = false;
            this.tvElementLIB.SelectNode(node, eTreeAction.Code);
            this.tvElementLIB.Focus();
            if (!node.IsDisplayed)
                node.EnsureVisible();
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void DelElement()
        {
            TP_ElementLIB lib = new TP_ElementLIB();
            Node Select = this.tvElementLIB.SelectedNode;
            if (Select == null) return;
            if (Select.Tag != null)
            {
                lib = Select.Tag as TP_ElementLIB;
                DBHelper.CIS.Delete<TP_ElementLIB>(p => p.ID == lib.ID);
                DBHelper.CIS.Delete<TP_ElementLIB>(p => p.ParentID == lib.ID);
            }
            if (Select.Parent == null)
                this.tvElementLIB.Nodes.Remove(Select);
            else
                Select.Parent.Nodes.Remove(Select);
        }

        #endregion 元素增删改查

        #region 数据操作

        private bool CheckSave()
        {
            Node node = this.tvElementLIB.SelectedNode;
            if (node == null) return true;
            TP_ElementLIB lib = node.Tag as TP_ElementLIB;
            if (lib.ID == null)
                return false;
            else
                return true;
        }

        #endregion 数据操作

        #region 窗体事件

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            btnReset_Click(null, null);
            AddFolder();
        }

        private void btnAddElement_Click(object sender, EventArgs e)
        {
            btnReset_Click(null, null);
            AddElement();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            btnReset_Click(null, null);
            DelElement();
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            this.tbxSpellCode.Text = this.tbxName.Text.GetSpell();
            this.tbxWubiCode.Text = this.tbxName.Text.GetWBM();
        }

        private void tvElementLIB_BeforeNodeSelect(object sender, AdvTreeNodeCancelEventArgs e)
        {
            if (!CheckSave())
            {
                CIS.Core.AlertBox.Info("当前节点未保存,请先保存");
                e.Cancel = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Node node = this.tvElementLIB.SelectedNode;
            if (node != null)
            {
                TP_ElementLIB lib = node.Tag as TP_ElementLIB;
                lib.Name = this.tbxName.Text;
                lib.No = node.Index;
                lib.ParentID = node.Parent == null ? "" : (node.Parent.Tag as TP_ElementLIB).ID;
                lib.SearchCode = this.tbxSearchCode.Text;
                lib.SpellCode = this.tbxSpellCode.Text;
                lib.Status = 1;
                lib.UpdateTime = DateTime.Now;
                lib.UpdatorID = CIS.Core.SysContext.CurrUser.user.ID;
                lib.WubiCode = this.tbxWubiCode.Text;
                lib.SystemSign = this.radioIP.Checked ? 0 : 1;
                lib.Content = this.WriteControl.Write.XMLTextUnFormatted;
                node.Text = lib.Name;
                List<string> list = new List<string>();
                foreach (DevComponents.DotNetBar.Controls.EditToken item in this.tokenTag.SelectedTokens)
                    list.Add(item.Value);
                lib.Tag = string.Join(",", list.ToArray());

                if (lib.ID == null)
                {
                    lib.ID = Guid.NewGuid().ToString();
                    DBHelper.CIS.Insert<TP_ElementLIB>(lib);
                }
                else
                    DBHelper.CIS.Update<TP_ElementLIB>(lib, p => p.ID == lib.ID);
                node.Tag = lib;
                CIS.Core.AlertBox.Info("保存成功");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.panelEx2.Controls)
            {
                if (item.GetType() == typeof(DevComponents.DotNetBar.Controls.TextBoxX))
                    (item as TextBox).Text = "";
            }
            this.tokenTag.SelectedTokens.Clear();
        }

        private void tvElementLIB_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (this.tvElementLIB.SelectedNode == null) return;
            TP_ElementLIB lib = this.tvElementLIB.SelectedNode.Tag as TP_ElementLIB;
            this.tbxName.Text = lib.Name ?? "";
            this.tbxSearchCode.Text = lib.SearchCode ?? "";
            this.tbxSpellCode.Text = lib.SpellCode ?? "";
            this.tbxWubiCode.Text = lib.WubiCode ?? "";
            this.radioIP.Checked = lib.SystemSign == 0;
            this.radioOP.Checked = !this.radioIP.Checked;
            this.tokenTag.SelectedTokens.Clear();
            this.WriteControl.Write.XMLText = lib.Content;
            if (lib.Tag == null) return;
            string[] str = lib.Tag.Split(',');
            foreach (string item in str)
                this.tokenTag.SelectedTokens.Add(new DevComponents.DotNetBar.Controls.EditToken(item));
        }

        private void FormElementLIB_Shown(object sender, EventArgs e)
        {
            InitElement();
        }

        private void tvElementLIB_BeforeNodeDrop(object sender, TreeDragDropEventArgs e)
        {
            if (!CheckSave())
            {
                CIS.Core.AlertBox.Info("当前节点未保存,请先保存");
                e.Cancel = true;
                return;
            }

            TP_ElementLIB plib = e.NewParentNode == null ? new TP_ElementLIB() : e.NewParentNode.Tag as TP_ElementLIB;

            if (plib.NodeType != 0)
            {
                CIS.Core.AlertBox.Info("元素下无法创建内容");
                e.Cancel = true;
                return;
            }

            Dictionary<Node, int> dict = CIS.Utility.TreeHelper.GetBeforeNodeDragChangedIndex(this.tvElementLIB, e.OldParentNode, e.NewParentNode, e.Node.Index, e.InsertPosition);
            TP_ElementLIB lib = e.Node.Tag as TP_ElementLIB;
            string PID = e.NewParentNode == null ? "" : (e.NewParentNode.Tag as TP_ElementLIB).ID;
            foreach (Node item in dict.Keys)
            {
                string id = (item.Tag as TP_ElementLIB).ID;
                DBHelper.CIS.FromSql(string.Format("UPDATE TP_ELEMENTLIB SET NO={0} WHERE ID='{1}'", dict[item], id)).ExecuteNonQuery();
            }
            lib.ParentID = PID;
            DBHelper.CIS.Update<TP_ElementLIB>(lib, p => p.ID == lib.ID);
        }

        #endregion 窗体事件
    }
}