using System;
using CIS.DAL.Template;
using DevComponents.AdvTree;


namespace App_Template
{
    public partial class FormDataSource : CIS.Core.BaseForm
    {
        private TxDataSource m_DataSource = null;
        private bool m_InitializeSourceDetail = false;
        private bool m_InitializeFieldDetail = false;
        private TxDataField m_CurrentField = null;
        private TxDataSourceNode m_CurrentSource = null;

        public FormDataSource()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            m_DataSource =TxDataSource.Load();
            rootNode.Nodes.Clear();
            this.advTree1.BeginUpdate();
            foreach (var node in m_DataSource.Nodes)
            {
                //加载数据节点
                Node snd = new Node();
                this.UpdateNode(snd, node);
                foreach (var field in node.Fields)
                {
                    //加载字段节点
                    Node fnd = new Node();
                    this.UpdateNode(fnd,field);
                    snd.Nodes.Add(fnd);
                }
                rootNode.Nodes.Add(snd);
            }
            this.advTree1.EndUpdate();
            rootNode.ExpandAll();
            //默认选中 第一个数据源节点
            if (rootNode.Nodes.Count > 0)
                this.advTree1.SelectedNode = rootNode.Nodes[0];
            else
                this.advTree1.SelectedNode = rootNode;

        }
        /// <summary>
        /// 根据数据源节点更新树节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="sourceNode"></param>
        private void UpdateNode(Node node, TxDataSourceNode sourceNode)
        {
            if (node == null) return;
            node.Text = sourceNode.Name;
            node.Tooltip = sourceNode.Description;
            node.Name = sourceNode.ID;
            node.Image = this.ilNode.Images["Node"];
            node.Tag = sourceNode;
        }
        /// <summary>
        /// 根据字段节点更新树节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="field"></param>
        private void UpdateNode(Node node, TxDataField field)
        {
            if (node == null) return;
            node.Text = field.Name;
            node.Tooltip = field.Description;
            node.Name = field.ID;
            node.Image = this.ilNode.Images["Field"];
            node.Tag = field;
        }
        /// <summary>
        /// 添加新的数据源节点
        /// </summary>
        private void AddNewDataSourceNode()
        {
            TxDataSourceNode node = new TxDataSourceNode();
            node.Name = "新增数据源";
            m_DataSource.Nodes.Add(node);
           
            Node snd = new Node();
            this.UpdateNode(snd, node);
            rootNode.Nodes.Add(snd);

            if (!snd.IsDisplayed)
                snd.EnsureVisible(eEnsureVisibleOption.Bottom);
            this.advTree1.SelectedNode = snd;
            //snd.BeginEdit();
        }
      
        private void AddNewFieldNode()
        {
            var selectedNode = this.advTree1.SelectedNode;
            if (selectedNode == null || selectedNode == rootNode) return;
            Node snd = null;
            if (selectedNode.Level == 1)
                snd = selectedNode;
            else
                snd = selectedNode.Parent;
            var source = snd.Tag as TxDataSourceNode;
            TxDataField field = new TxDataField();
            field.Name = "新增字段";
            source.Fields.Add(field);
            source.FixDomState();

            Node fnd = new Node();
            this.UpdateNode(fnd,field);
            snd.Nodes.Add(fnd);

            if (!fnd.IsDisplayed)
                fnd.EnsureVisible(eEnsureVisibleOption.Bottom);
            this.advTree1.SelectedNode = fnd;
            //fnd.BeginEdit();
        }

        private void LoadSourceDetail(TxDataSourceNode source)
        {
            this.m_InitializeSourceDetail = true;

            this.txtSCode.Text = source.ID;
            this.txtSName.Text = source.Name;
            this.txtSDescription.Text = source.Description;
            this.rbtnSDisable.Checked = !(this.rbtnSEnable.Checked = source.Visible);

            this.m_InitializeSourceDetail = false;
        }

        private void LoadFieldDetail(TxDataField field)
        {
            this.m_InitializeFieldDetail = true;

            this.txtFCode.Text = field.ID;
            this.txtFName.Text = field.Name;
            this.txtSDescription.Text = field.Description;
            this.chkFReadOnly.Checked = field.ReadOnly;
            this.chkFRequired.Checked = field.Required;
            this.chkFVisible.Checked = field.Visible;
            this.comboFDataType.SelectedValue = (int)field.DataType;

            this.m_InitializeFieldDetail = false;
        }

        private void FormDataSource_Load(object sender, EventArgs e)
        {
            //var dbTypeDict = typeof(System.Data.DbType).EnumToDict();
            //this.comboFDataType.DataBind(dbTypeDict.ToList(), "Value", "Key", (int)System.Data.DbType.String);
            
            //this.RefreshData();
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void biSave_Click(object sender, EventArgs e)
        {
            if (m_DataSource != null)
            {
                m_DataSource.Save();
            }
        }

        private void biAddDataSourceNode_Click(object sender, EventArgs e)
        {
            this.AddNewDataSourceNode();
        }

        private void biAddDataField_Click(object sender, EventArgs e)
        {
            this.AddNewFieldNode();
        }

        private void advTree1_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (e.Node == null)
            {
                biDelete.Enabled = false;
                return;
            }
            biDelete.Enabled = e.Node.Level > 0;
            if (e.Node.Level == 0)
            {
                this.pnlIntruduction.BringToFront();
                this.pnlIntruduction.Visible = true;
            }
            else
            {
                if (this.pnlIntruduction.Visible)
                    this.pnlIntruduction.Visible = false;
                if (e.Node.Level == 1)
                {
                    this.stabSourceNode.Visible = true;
                    this.stabField.Visible = false;
                    this.superTabControl1.TabStrip.Invalidate();
                    this.superTabControl1.SelectedTab = this.stabSourceNode;

                    this.LoadSourceDetail(e.Node.Tag as TxDataSourceNode);
                }
                else
                {
                    this.stabSourceNode.Visible = false;
                    this.stabField.Visible = true;
                    this.superTabControl1.TabStrip.Invalidate();
                    this.superTabControl1.SelectedTab = this.stabField;

                    this.LoadFieldDetail(e.Node.Tag as TxDataField);
                }
            }
        }

        private void biDelete_Click(object sender, EventArgs e)
        {
            var selectedNode = this.advTree1.SelectedNode;
            if (selectedNode == null) return;
            if (selectedNode.Level == 0) return;
            if (selectedNode.Level == 1)
                m_DataSource.Nodes.Remove(selectedNode.Tag as TxDataSourceNode);
            else
                (selectedNode.Tag as TxDataField).Remove();
            if (selectedNode.PrevVisibleNode != null)
                this.advTree1.SelectedNode = selectedNode.PrevVisibleNode;
            else
                if (selectedNode.NextVisibleNode != null)
                    this.advTree1.SelectedNode = selectedNode.NextVisibleNode;
                else
                    if (selectedNode.Parent != null)
                        this.advTree1.SelectedNode = selectedNode.Parent;
            selectedNode.Remove();
        }

  

    }
}
