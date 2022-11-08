using System;
using System.ComponentModel;
using System.Windows.Forms;
using CIS.Model;
using DCSoft.Writer.Dom;
using DevComponents.AdvTree;

namespace App_Template
{
    public partial class TemplateDesignControl : UserControl
    {
        public TemplateDesignControl()
        {
            InitializeComponent();
        }

        public event EventHandler btnSave_Click;
        DevComponents.DotNetBar.ButtonItem[] button;

        public string XMLText
        { get { return this.txWriterControl1.XMLTextUnFormatted; } set { this.txWriterControl1.XMLText = value; } }

        public CIS.DCWriter.Controls.TxWriterControl WriterControl
        {
            get { return this.txWriterControl1; }
        }

        [Browsable(true)]
        [Description("true显示元素库,false显示辅助词库")]
        public bool ShowElementTree
        {
            set
            {
                if (value)
                { this.superTabItem1.Visible = true; this.superTabItem2.Visible = false; }
                else
                { this.superTabItem1.Visible = false; this.superTabItem2.Visible = true; }
            }

        }

        public bool InsertVisible
        {
            get { return button[0].Visible; }
            set
            {
                button = new DevComponents.DotNetBar.ButtonItem[] { buttonItem29, buttonItem40, buttonItem41, buttonItem33, buttonItem34, buttonItem36 };
                foreach (var item in button)
                {
                    item.Visible = value;
                }
            }
        }

        public void SetMain(string XML)
        {
            this.txWriterControl1.XMLText = XML;
        }

        public void ShowElement()
        {
            this.elementTree1.ShowTree();
        }

        public void ShowWordLib()
        {
            this.wordLibTree1.InitTree();
        }

        private void elementTree1_NodeMouseDown(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            TP_ElementLIB lib = e.Node.Tag as TP_ElementLIB;
            this.elementTree1.Tree.SelectedNode = e.Node;
            if (e.Button == System.Windows.Forms.MouseButtons.Left && lib.NodeType == 1)
            {
                DataObject DO = new DataObject(e.Node);
                DoDragDrop(DO, DragDropEffects.Copy);
            }
        }

        private void txWriterControl1_DragDrop(object sender, DragEventArgs e)
        {
            string XML = null;
            Node node = e.Data.GetData(typeof(Node)) as Node;
            if (node.Tag.GetType() == typeof(TP_ElementLIB))
            {
                TP_ElementLIB lib = this.elementTree1.Tree.SelectedNode.Tag as TP_ElementLIB;
                XML = lib.Content;

            }
            else if (node.Tag.GetType() == typeof(TP_WordLIB))
            {
                TP_WordLIB lib = this.wordLibTree1.Tree.SelectedNode.Tag as TP_WordLIB;
                XML = lib.Content;
            }
            if (XML == null) return;
            XTextElementList list = this.txWriterControl1.ExecuteCommand("InsertXMLExt", false, XML) as XTextElementList;
        }

        private void TemplateDesignControl_Load(object sender, EventArgs e)
        {
            this.txWriterControl1.CommandControler = this.myCommandControler;
            this.txWriterControl1.CommandControler.Start();
        }

        private void biSave_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void wordLibTree1_NodeMouseDown(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            TP_WordLIB lib = e.Node.Tag as TP_WordLIB;
            this.wordLibTree1.Tree.SelectedNode = e.Node;
            if (lib == null) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Left && lib.NodeType == 1)
            {
                DataObject DO = new DataObject(e.Node);
                DoDragDrop(DO, DragDropEffects.Copy);
            }
        }

        private void wordLibTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            TP_ElementLIB lib = e.Node.Tag as TP_ElementLIB;
            string XML = lib.Content;
            if (XML == null) return;
            XTextElementList list = this.txWriterControl1.ExecuteCommand("InsertXMLExt", false, XML) as XTextElementList;
        }

        private void txWriterControl1_DocumentContentChanged(object eventSender, DCSoft.Writer.WriterEventArgs args)
        {

        }

        private void buttonItem41_Click(object sender, EventArgs e)
        {
            FormInsertComboList form = new FormInsertComboList();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txWriterControl1.ExecuteCommand("InsertInputField", false, form.input);
            }
        }

    }
}
