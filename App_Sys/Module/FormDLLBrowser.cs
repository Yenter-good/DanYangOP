using DevComponents.AdvTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace App_Sys
{
    /// <summary>
    /// Dll浏览器
    /// </summary>
    public partial class FormDLLBrowser : CIS.Core.DialogBase
    {
        public string Dll
        {
            get
            {
                if (this.advTree1.Nodes.Count == 0) return "";
                return System.IO.Path.GetFileNameWithoutExtension(this.advTree1.Nodes[0].Text);
            }
        }
        /// <summary>
        /// 获取选择的全命名空间
        /// </summary>
        public string FullName
        {
            get
            {
                if (!this.Validate()) return "";
                return this.advTree1.SelectedNode.Text;
            }
        }
        /// <summary>
        /// 获取选择的窗体名称
        /// </summary>
        public string FormTitle
        {
            get
            {
                if (!this.Validate()) return "";
                return this.advTree1.SelectedNode.Cells[1].Text;
            }
        }

        public FormDLLBrowser()
        {
            InitializeComponent();
        }


        private List<Node> AssemblyNodes(string fileName)
        {
            List<Node> nodes = new List<Node>();
            var ass = System.Reflection.Assembly.LoadFile(fileName);
            foreach (var item in ass.GetExportedTypes())
            {
                if (item.BaseType == typeof(Form))
                {
                    try
                    {
                        var c = item.GetConstructor(new Type[0]);
                        if (c == null) continue;

                        Node node = new Node();
                        node.Text = item.FullName;
                        var form = ass.CreateInstance(item.FullName) as Form;
                        node.Cells.Add(new Cell(item.FullName));
                        node.Cells.Add(new Cell(form.Text));
                        nodes.Add(node);
                    }
                    catch { }
                }
            }
            return nodes;
        }

        public void Reflection(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
                throw new ArgumentException("路径{0}不存在".FormatWith(fileName));
            string fileExt = System.IO.Path.GetExtension(fileName).ToUpper();
            if (!new string[] { ".DLL", ".EXE" }.Contains(fileExt))
                throw new ArgumentException("非法文件");

            this.advTree1.Nodes.Clear();
            Node rootNode = new Node();
            rootNode.Text = fileName;
            this.advTree1.Nodes.Add(rootNode);

            CIS.Utility.LoadHelper.LoadAsync<List<Node>>(this.advTree1,
                () => this.AssemblyNodes(fileName)
                , data => {
                    if (data == null || data.Count == 0) return;
                    this.advTree1.BeginUpdate();
                    rootNode.Nodes.AddRange(data.ToArray());
                    this.advTree1.EndUpdate();
                    this.advTree1.ExpandAll();
                });
        }

        protected override bool Validate()
        {
            if (this.advTree1.SelectedNode == null) return false;
            if (this.advTree1.SelectedNode.Level == 0) return false;
            return true;
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            this.btnOK.PerformClick();
        }
    }
}
