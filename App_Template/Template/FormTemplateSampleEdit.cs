using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using CIS.Model;
using System.Reflection;
using DevComponents.AdvTree;
using DCSoft.Drawing;

namespace App_Template
{
    public partial class FormTemplateSampleEdit : Form
    {
        public FormTemplateSampleEdit()
        {
            InitializeComponent();
        }

        List<OP_Dic_TemplateNode> TemplateNode;
        Node selectNode;
        ContentStyle rowStyle;
        Node selectNodeFolder;

        #region 初始化操作
        /// <summary>
        /// 初始化页眉页脚
        /// </summary>
        private void InitTemplateFootAndHeader()
        {
            this.txWriterControl1.XMLText = CIS.Purview.SysParams.GetTemplateHeaderAndFooter;
        }

        /// <summary>
        /// 初始化模板节点
        /// </summary>
        private void InitTemplateNode()
        {
            TemplateNode = DBHelper.CIS.From<OP_Dic_TemplateNode>().OrderBy(p => p.No).ToList();
            foreach (OP_Dic_TemplateNode item in TemplateNode)
            {
                DevComponents.DotNetBar.ButtonItem btn = new DevComponents.DotNetBar.ButtonItem(item.Code, item.Name);
                btn.Tag = item;
                ToolStripMenuItem menu = new ToolStripMenuItem(item.Name);
                menu.Tag = item;
                this.btnInsertNode.SubItems.Add(btn);
                插入节点ToolStripMenuItem.DropDownItems.Add(menu);
                btn.Click += InsertNode_Click;
                menu.Click += InsertNode_Click;
            }
            this.bar3.Refresh();
        }
        #endregion
        private void InsertNode_Click(object sender, EventArgs e)
        {
            OP_Dic_TemplateNode templateNode;
            if (sender.GetType() == typeof(ToolStripMenuItem))
                templateNode = (sender as ToolStripMenuItem).Tag as OP_Dic_TemplateNode;
            else
                templateNode = (sender as DevComponents.DotNetBar.ButtonItem).Tag as OP_Dic_TemplateNode;
            InsertTemplateNode(templateNode.Name, templateNode.Code);
        }

        #region 模版操作
        /// <summary>
        /// 获得病历的主要内容
        /// </summary>
        /// <returns></returns>
        public RecordDate GetRecordContext()
        {
            RecordDate result = new RecordDate();
            foreach (OP_Dic_TemplateNode item in TemplateNode)
            {
                XTextInputFieldElement input = this.txWriterControl1.GetElementById(item.Code) as XTextInputFieldElement;
                if (input != null)
                {
                    PropertyInfo propertyInfo = result.GetType().GetProperty(item.Code);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(result, input.InnerXML, null);
                    }
                }
            }
            return result;
        }
        struct MyStruct
        {
            public string XML;
            public string Type;
        }

        /// <summary>
        /// 插入节点
        /// </summary>
        /// <param name="NodeName">节点文本名称</param>
        /// <param name="NodeType">节点类型</param>
        private void InsertTemplateNode(string NodeName, string NodeType)
        {
            //XTextInputFieldElement input = this.txWriterControl1.GetElementById(NodeType) as XTextInputFieldElement;
            //if (input == null)
            //{
            //    input = this.txWriterControl1.Document.CreateElementByType(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
            //    input.ID = NodeType;
            //    this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Disable;
            //    InsertInputElementToTable(input, NodeName);
            //    SetInputElementStyle(input);
            //}
            //else
            //    input.Focus();

            XTextInputFieldElement input = this.txWriterControl1.GetElementById(NodeType) as XTextInputFieldElement;
            XTextInputFieldElement selectInput = (this.txWriterControl1.GetCurrentElement(typeof(XTextInputFieldElement)) as XTextInputFieldElement).GetTopInputField() as XTextInputFieldElement;
            List<XTextInputFieldElement> inputs = new List<XTextInputFieldElement>();
            if (input == null)
            {
                XTextTableElement table = this.txWriterControl1.GetElementById("tableContext") as XTextTableElement;
                int i = this.txWriterControl1.Document.CurrentTableCell.RowIndex;
                XTextElementList list = table.Elements;
                List<MyStruct> xmlList = new List<MyStruct>();
                foreach (XTextTableRowElement item in list)
                {
                    XTextTableCellElement cell = item.Cells[0] as XTextTableCellElement;
                    XTextInputFieldElement inputTmp = cell.GetFirstElementByType(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
                    if (inputTmp == null)
                        break;
                    xmlList.Add(new MyStruct { XML = inputTmp.InnerXML, Type = inputTmp.ID });
                }
                xmlList.Insert(i + 1, new MyStruct { XML = "", Type = NodeType });

                table.Rows.Clear();
                InsertRowDownFromTable(table);
                foreach (MyStruct item in xmlList)
                {
                    OP_Dic_TemplateNode nodeType = TemplateNode.Where(p => p.Code == item.Type).First();
                    input = this.txWriterControl1.Document.CreateElementByType(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
                    if (item.XML != "")
                        input.AppendXML(item.XML);
                    input.ID = nodeType.Code;
                    this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Disable;
                    InsertInputElementToTable(input, nodeType.Name);
                    SetInputElementStyle(inputs, 2);
                }
            }
            else
                input.Focus();
        }

        /// <summary>
        /// 设置指定输入域的样式
        /// </summary>
        /// <param name="input"></param>
        private void SetInputElementStyle(XTextInputFieldElement input, int BorderWidth, bool updateUI = false)
        {
            XTextElementList list = input.GetElementsByType(typeof(XTextInputFieldElement));
            foreach (XTextInputFieldElement item in list)
            {
                var style = item.Style.Clone();
                //判断是否为临时样式
                bool isTempStyle = item.GetAttribute("IsTempStyle").AsBoolean();
                //如果元素不存在边框 则启用临时样式
                if (!isTempStyle && !style.BorderBottom && BorderWidth > 0)
                {
                    item.SetAttribute("IsTempStyle", "true");
                }
                if (item.GetAttribute("IsTempStyle").AsBoolean())
                {
                    style.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    style.BorderBottom = BorderWidth == 0 ? false : true;
                    style.BorderBottomColor = Color.Black;
                    style.BorderWidth = BorderWidth;
                    item.Style = style as DocumentContentStyle;
                }
            }
            if (updateUI)
                input.EditorRefreshView();
        }
        private void SetInputElementStyle(List<XTextInputFieldElement> inputs, int BorderWidth, bool updateUI = false)
        {
            foreach (XTextInputFieldElement item in inputs)
            {
                SetInputElementStyle(item, BorderWidth, updateUI);
            }
        }
        /// <summary>
        /// 将输入域插入到表格最后一行中
        /// </summary>
        /// <param name="input"></param>
        /// <param name="tag"></param>
        private void InsertInputElementToTable(XTextInputFieldElement input, string tag)
        {
            var headerStyle = new DocumentContentStyle() { FontStyle = FontStyle.Bold, FontSize = 10, FontName = "宋体" };
            var contentStyle = new DocumentContentStyle() { FontSize = 10, FontName = "宋体" };
            XTextTableElement table = this.txWriterControl1.GetElementById("tableContext") as XTextTableElement;
            //表格必须为1列
            var cell = table.LastCell;
            cell.ContentBuilder.AppendTextWithStyle(tag + ":", headerStyle);
            cell.ContentBuilder.AppendWithStyle(input, contentStyle);
            cell.EditorRefreshView();
            InsertRowDownFromTable(table);
            this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;
            input.Focus();
        }

        /// <summary>
        /// 设置指定输入域的样式
        /// </summary>
        /// <param name="input"></param>
        private void SetInputElementStyle(XTextInputFieldElement input)
        {
            XTextElementList list = input.GetElementsByType(typeof(XTextInputFieldElement));
            foreach (XTextInputFieldElement item in list)
            {
                var style = item.Style.Clone();
                style.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                style.BorderBottom = true;
                style.BorderBottomColor = Color.Black;
                style.BorderWidth = 2;
                item.EditorSetContentStyleFast(style as DocumentContentStyle);
            }
            input.EditorRefreshView();
        }

        /// <summary>
        /// 在表格下添加一个新行
        /// </summary>
        /// <param name="table"></param>
        private void InsertRowDownFromTable(XTextTableElement table, bool updateUI = false)
        {
            table.Style.Font = new DCSoft.Drawing.XFontValue(new Font("宋体", 6));
            DocumentContentStyle dataCellStyle = new DocumentContentStyle();
            dataCellStyle.PaddingLeft = 15;
            dataCellStyle.PaddingTop = 0;
            dataCellStyle.PaddingRight = 15;
            dataCellStyle.PaddingBottom = 0;
            XTextTableRowElement row = table.CreateRowInstance();
            XTextTableCellElement cell = table.CreateCellInstance();
            row.Style = rowStyle as DocumentContentStyle;
            cell.Style = dataCellStyle;
            table.AppendChildElement(row);
            row.AppendChildElement(cell);
            if (updateUI)
                table.EditorRefreshView();
        }

        /// <summary>
        /// 将XML插入到当前焦点的输入域当中
        /// </summary>
        /// <param name="XML"></param>
        private void InsertXMLToFoucedXTextElement(string XML, bool IsClear)
        {
            XTextInputFieldElement input = this.txWriterControl1.GetCurrentElement(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
            if (IsClear)
            {
                if (input == null || TemplateNode.FindIndex(p => p.Code == input.ID) < 0)
                {
                    CIS.Core.AlertBox.Info("您必须在指定的输入域位置放置内容");
                    return;
                }
            }
            input = input.GetTopInputField() as XTextInputFieldElement;
            if (IsClear)
                input.Text = "";
            input.AppendXML(XML);
            input.EditorRefreshView();
            SetInputElementStyle(input);
        }
        #endregion

        private void FormTemplateSampleEdit_Shown(object sender, EventArgs e)
        {
            InitTemplateNode();
            this.templateSample1.InitSample();
            this.wordLibTree1.InitTree();
            this.childTemplateTree1.InitTemplate();
            this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;
            this.txWriterControl1.SetZoomRate((float)1.25);
            Application.DoEvents();
            InitTemplateFootAndHeader();
            Application.DoEvents();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            this.templateSample1.AddFolder();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.templateSample1.DeleteTemplateSample();
        }

        private void biSave_Click(object sender, EventArgs e)
        {
            RecordDate date = GetRecordContext();
            if (selectNode != null && selectNode.Tag != null)
            {
                OP_TemplateSample tmp = new OP_TemplateSample();
                OP_TemplateSample tmp1 = selectNode.Tag as OP_TemplateSample;
                PropertyInfo[] pp = tmp1.GetType().GetProperties();
                foreach (PropertyInfo item in pp)
                    tmp.GetType().GetProperty(item.Name).SetValue(tmp, item.GetValue(tmp1, null), null);

                //foreach (OP_Dic_TemplateNode item in TemplateNode)
                //{
                //    PropertyInfo propertyInfo = date.GetType().GetProperty(item.Code);
                //    PropertyInfo propertyInfo1 = tmp.GetType().GetProperty(item.Code);
                //    if (propertyInfo != null && propertyInfo1 != null)
                //        propertyInfo1.SetValue(tmp, propertyInfo.GetValue(date, null), null);
                //}
                PropertyInfo[] info = date.GetType().GetProperties();
                foreach (var item in info)
                {
                    PropertyInfo info1 = tmp.GetType().GetProperty(item.Name);
                    if (info1 != null)
                    {
                        info1.SetValue(tmp, item.GetValue(date, null), null);
                    }
                }

                tmp.NodeType = 1;
                selectNode.Tag = tmp;
                selectNode = null;
                DBHelper.CIS.Update<OP_TemplateSample>(tmp, p => p.ID == tmp1.ID);
                CIS.Core.AlertBox.Info("保存成功");
            }
            else
            {
                //FormTemplateSampleSave form = new FormTemplateSampleSave();
                //form.Folder = selectNodeFolder;
                //form.TemplateNode = TemplateNode;
                //form.date = date;
                //if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                //    this.templateSample1.InitSample();
                //}
                //else
                //    return;
                CIS.Core.AlertBox.Info("请先选择要保存到哪个模板里");
                return;
            }
            InitTemplateFootAndHeader();
        }

        private void templateSample1_AfterEdit(object sender, DevComponents.AdvTree.CellEditEventArgs e)
        {
            OP_TemplateSample tmp = e.Cell.Parent.Tag as OP_TemplateSample;
            tmp.SampleName = e.NewText;
            DBHelper.CIS.Update<OP_TemplateSample>(tmp, p => p.ID == tmp.ID);
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Node selectNode = this.templateSample1.Tree.SelectedNode;
            if (selectNode == null)
            {
                CIS.Core.AlertBox.Info("未选中任何一个节点,无法修改");
                return;
            }
            else
            {
                selectNode.BeginEdit();
            }
        }

        private void childTemplateTree1_NodeDragStart(object sender, TreeNodeMouseEventArgs e)
        {

        }

        private void wordLibTree1_NodeDragStart(object sender, TreeNodeMouseEventArgs e)
        {

        }

        private void txWriterControl1_DragDrop(object sender, DragEventArgs e)
        {
            Node node = e.Data.GetData(typeof(Node)) as Node;
            string XML = null;
            if (node.Tag == null) return;
            if (node.Tag.GetType() == typeof(OP_SubTemplate))
            {
                OP_SubTemplate lib = node.Tag as OP_SubTemplate;
                if (lib.NodeType == 0) return;
                XML = lib.Content;
                InsertXMLToFoucedXTextElement(XML, true);
            }
            else
            {
                TP_WordLIB lib = node.Tag as TP_WordLIB;
                if (lib.NodeType == 0) return;
                XML = lib.Content;
                this.txWriterControl1.ExecuteCommand("InsertXMLExt", false, XML);
            }
        }

        private void txWriterControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                this.contextMenuStrip1.Show(MousePosition);
        }

        private void btnInsertNode_Click(object sender, EventArgs e)
        {
            this.btnInsertNode.Expanded = true;
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement inputFieldElement = new XTextInputFieldElement();
            inputFieldElement.FieldSettings = new InputFieldSettings();
            inputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DateTime;
            inputFieldElement.Text = string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);
            this.txWriterControl1.ExecuteCommand("InsertDateTimeField", false, inputFieldElement);
        }

        private void btnCheckBox_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand("InsertCheckBoxes", true, null);
        }

        private void btnMedicial_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand("InsertMedicalExpression", true, null);
        }

        private void btnComboBox_Click(object sender, EventArgs e)
        {
            this.btnComboBox.Expanded = true;
        }

        private void templateSample1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Level == 0) return;
            if ((e.Node.Tag as OP_TemplateSample).NodeType == 1)
            {
                InsertTemplateSample(e.Node);
                selectNode = e.Node;
            }
        }

        /// <summary>
        /// 插入模板
        /// </summary>
        /// <param name="node"></param>
        private void InsertTemplateSample(Node node)
        {
            OP_TemplateSample lib = node.Tag as OP_TemplateSample;
            PropertyInfo[] propertyInfo = lib.GetType().GetProperties();
            XTextTableElement table = this.txWriterControl1.GetElementById("tableContext") as XTextTableElement;
            XTextTableElement table1 = this.txWriterControl1.GetElementById("tableContext1") as XTextTableElement;
            table.Rows.Clear();
            InsertRowDownFromTable(table);
            int index = 0;
            foreach (PropertyInfo item in propertyInfo)
            {
                XTextInputFieldElement input = this.txWriterControl1.GetElementById(item.Name) as XTextInputFieldElement;
                OP_Dic_TemplateNode nodeType = TemplateNode.Find(p => p.Code == item.Name);
                var XML = item.GetValue(lib, null);
                if (XML != null && nodeType != null)
                {
                    if (input == null)
                    {
                        input = this.txWriterControl1.Document.CreateElementByType(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
                        this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Disable;
                        InsertInputElementToTable(input, nodeType.Name);
                    }
                    input.ID = item.Name;
                    input.ContentBuilder.Clear();
                    input.AppendXML(XML.ToString());
                    input.Enumerate((a, e) => { e.Element.StyleIndex = input.StyleIndex; });
                    SetInputElementStyle(input);
                    index++;
                }
            }
            table1.EditorRefreshView();
            if (index == 0)
                InitTemplateFootAndHeader();
        }

        private void 删除当前节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTempalteNode(this.txWriterControl1.CurrentInputField);
        }

        /// <summary>
        /// 删除病历内的指定节点
        /// </summary>
        /// <param name="input"></param>
        private void DeleteTempalteNode(XTextInputFieldElement input)
        {
            string name = input.ID;
            if (TemplateNode.FindIndex(p => p.Code == name) < 0)
            {
                CIS.Core.AlertBox.Info("当前节点无法删除");
                return;
            }
            XTextTableRowElement row = input.GetOwnerParent(typeof(XTextTableRowElement), false) as XTextTableRowElement;
            XTextTableElement table = this.txWriterControl1.GetElementById("tableContext") as XTextTableElement;
            table.Rows.Remove(row);
            this.txWriterControl1.RefreshDocument();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.templateSample1.InitSample();
            this.wordLibTree1.InitTree();
            this.childTemplateTree1.InitTemplate();
        }

        private void 保存成辅助词库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement input = this.txWriterControl1.CurrentInputField;
            if (input != null)
            {
                XTextInputFieldElement input1 = input.GetLastElementByType(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
                if (input1 != null)
                {
                    CIS.Core.AlertBox.Info("选择的输入域内还有输入域,无法保存成辅助词库");
                    return;
                }
                else
                {
                    FormWordLIBSave form = new FormWordLIBSave();
                    form.XML = input.OuterXML;
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        CIS.Core.AlertBox.Info("保存成功");
                        this.wordLibTree1.InitTree();
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitTemplateFootAndHeader();
            selectNode = null;
        }

        private void templateSample1_BeforeDrop(object sender, TreeDragDropEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Cancel = true;
                return;
            }
            Node topNode = GetParentNode(e.Node);
            Node topNewNode = GetParentNode(e.NewParentNode);
            if (topNode != topNewNode)
            {
                CIS.Core.AlertBox.Info("科室和个人之间的无法直接转换");
                e.Cancel = true;
                return;
            }
            OP_TemplateSample newLib = e.NewParentNode.Tag as OP_TemplateSample;
            OP_TemplateSample lib = e.Node.Tag as OP_TemplateSample;
            if (newLib == null)
            {
                lib.ParentID = "";
            }
            else if (newLib.NodeType == 1)
            {
                CIS.Core.AlertBox.Info("不允许在模板下创建内容");
                e.Cancel = true;
                return;
            }
            else
                lib.ParentID = newLib.ID;
            DBHelper.CIS.Update<OP_TemplateSample>(lib, p => p.ID == lib.ID);


        }

        private Node GetParentNode(Node node)
        {
            if (node.Parent == null)
                return node;
            else
                return GetParentNode(node.Parent);
        }

        private void 增加组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.templateSample1.AddFolder();
        }

        private void 修改模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonItem2_Click(null, null);
        }

        private void 删除模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.templateSample1.DeleteTemplateSample();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnRefresh_Click(null, null);
        }

        private void 展开全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.templateSample1.Tree.ExpandAll();
        }

        private void 闭合全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.templateSample1.Tree.CollapseAll();
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand("ElementProperties", false, null);
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand("Font", true, null);
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand("InsertListField", true, null);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            FormInsertComboList form = new FormInsertComboList();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txWriterControl1.ExecuteCommand("InsertInputField", false, form.input);
            }
        }

        private void 保存成子模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement input = this.txWriterControl1.CurrentInputField;
            if (input != null)
            {
                XTextInputFieldElement input1 = input.GetTopInputField() as XTextInputFieldElement;
                string type = input1.ID;
                string typeName = TemplateNode.Where(p => p.Code == type).First().Name;
                FormChildTemplateSaveAs form = new FormChildTemplateSaveAs();
                form.TypeName = typeName;
                form.Type = type;
                form.XML = input1.InnerXML;
                form.InitTree();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CIS.Core.AlertBox.Info("保存成功");
                    return;
                }
            }
        }

        private void templateSample1_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Level != 0)
            {
                selectNodeFolder = e.Node;
                return;
            }
            selectNodeFolder = FindFolder(e.Node);
        }

        private Node FindFolder(Node node)
        {
            if (node.Tag == null)
                return node;
            OP_TemplateSample sample = node.Tag as OP_TemplateSample;
            if (sample.NodeType == 0)
                return node;
            else
                return FindFolder(node.Parent);
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            InitTemplateFootAndHeader();
            this.templateSample1.AddTemplate();

        }

        private void templateSample1_NodeMouseDown(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                OP_TemplateSample sample = e.Node.Tag == null ? new OP_TemplateSample() { NodeType = 3 } : e.Node.Tag as OP_TemplateSample;
                foreach (ToolStripItem item in this.contextMenuStrip2.Items)
                {
                    if (item.Tag.ToString().Contains(sample.NodeType.ToString()))
                        item.Visible = true;
                    else
                        item.Visible = false;
                }
                this.contextMenuStrip2.Show(MousePosition);
            }
        }

        private void 增加模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitTemplateFootAndHeader();
            this.templateSample1.AddTemplate();
        }

        private void 删除组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.buttonItem4_Click(null, null);
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            Node selectNode = this.templateSample1.Tree.SelectedNode;
            if (selectNode == null)
            {
                CIS.Core.AlertBox.Info("未选中任何一个节点,无法修改");
                return;
            }
            else
            {
                OP_TemplateSample sample = (selectNode.Tag as OP_TemplateSample);
                sample.ID = Guid.NewGuid().ToString();
                sample.UserID = "";
                sample.DeptCode = CIS.Core.SysContext.RunSysInfo.currDept.Code;
                sample.ParentID = "";
                sample.AttachAll();
                DBHelper.CIS.Insert<OP_TemplateSample>(sample);
                this.templateSample1.InitSample();
            }
        }
    }
}
