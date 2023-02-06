using CIS.ControlLib.Win32;
using CIS.Core;
using CIS.Core.EventBroker;
using CIS.Core.Interceptors;
using CIS.Model;
using CIS.Purview;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using DevComponents.AdvTree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CIS.Core.Interceptors;
using CIS.Utility;

namespace App_OP.Record
{
    public partial class FormRecord : BaseForm
    {
        public FormRecord(FormMain _formMain)
        {
            InitializeComponent();
            formMain = _formMain;
        }
        #region 变量
        List<OP_Dic_TemplateNode> TemplateNodeType = new List<OP_Dic_TemplateNode>();
        ContentStyle rowStyle;
        private FormMain formMain;
        string RecodeID = "";
        int SaveRecordStatus = 0;
        public const int IME_CMODE_FULLSHAPE = 0x8;
        public const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;
        #endregion

        #region 窗体事件
        private void btnFirst_Click(object sender, EventArgs e)
        {
            SysContext.IsFirstRecord = 0;
        }
        private void btnSecond_Click(object sender, EventArgs e)
        {
            SysContext.IsFirstRecord = 1;
        }
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            this.btnSwitch.Expanded = !this.btnSwitch.Expanded;
        }
        private void 保存到我的收藏夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSaveFavorite favorite = new FormSaveFavorite();
            favorite.RecodeID = this.txWriterControl1.XMLTextForSave;
            favorite.ShowDialog();
        }
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Process p = Process.Start(Application.StartupPath + @"\SpecialSymbol\QuickInput.exe");
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
        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand("Cut", false, null);
        }
        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand("Copy", false, null);
            AlertBox.Info("复制成功");
        }
        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand("PasteAsText", false, null);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            InitTemplate();
            InitPatientInfo(true);
        }
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement input = this.txWriterControl1.GetElementById("myDealWith") as XTextInputFieldElement;
            if (input == null)
            {
                InsertTemplateNode("处理", "myDealWith");
                input = this.txWriterControl1.GetElementById("myDealWith") as XTextInputFieldElement;
            }
            //input.Text = "";
            ImportDrugInfo();
        }
        private void buttonItem2_Click(object sender, EventArgs e)
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
        private void btnFont_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand("Font", true, null);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.HiddenTempStyle();
            //ImportDrugInfo();
            this.txWriterControl1.RefreshDocument();
            SaveRecord();
            this.txWriterControl1.ExecuteCommand(DCSoft.Writer.StandardCommandNames.FilePrintPreview, true, null);
            this.ShowTempStyle();
        }
        private void 删除当前节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTempalteNode(this.txWriterControl1.CurrentInputField);
        }
        private void 主诉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            InsertTemplateNode(item.Text, item.Tag.ToString());
        }
        private void childTemplateTree1_NodeMouseDown(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            //OP_SubTemplate lib = e.Node.Tag as OP_SubTemplate;
            //this.childTemplateTree1.Tree.SelectedNode = e.Node;
            //if (e.Button == System.Windows.Forms.MouseButtons.Left && lib.NodeType == 1)
            //{
            //    DataObject DO = new DataObject(e.Node);
            //    DoDragDrop(DO, DragDropEffects.Copy);
            //}
        }
        private void txWriterControl1_DragDrop(object sender, DragEventArgs e)
        {
            Node node = e.Data.GetData(typeof(Node)) as Node;
            if (node.Tag.GetType() == typeof(OP_SubTemplate))
            {
                OP_SubTemplate lib = node.Tag as OP_SubTemplate;
                string XML = null;
                XML = lib.Content;
                InsertXMLToFoucedXTextElement(XML);

            }
            else if (node.Tag.GetType() == typeof(TP_WordLIB))
            {
                TP_WordLIB lib = node.Tag as TP_WordLIB;
                this.txWriterControl1.ExecuteCommand("InsertXML", false, lib.Content);
                XTextElement element = this.txWriterControl1.GetCurrentElement(typeof(XTextInputFieldElement));
                if (element != null)
                {
                    element.Elements.DeleteRedundant(true, true, true, true, true);
                }
            }
            else
            {
                InsertTemplateSample(node);
                return;
            }
            //XTextInputFieldElement input = this.txWriterControl1.GetCurrentElement(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
            foreach (OP_Dic_TemplateNode item in TemplateNodeType)
            {
                XTextInputFieldElement input = this.txWriterControl1.GetElementById(item.Code) as XTextInputFieldElement;
                if (input != null)
                {
                    input.Enumerate((a, c) => { c.Element.StyleIndex = input.StyleIndex; });
                    SetInputElementStyle(input, 2);
                }
                XTextTableElement table = this.txWriterControl1.GetElementById("tableContext") as XTextTableElement;
                table.EditorRefreshView();
            }

            //input = input.GetTopInputField() as XTextInputFieldElement;
            //if (input != null)
            //{
            //    input.Enumerate((a, c) => { c.Element.StyleIndex = input.StyleIndex; });
            //    SetInputElementStyle(input, 2);
            //}
            //XTextTableElement table = this.txWriterControl1.GetElementById("tableContext") as XTextTableElement;
            //table.EditorRefreshView();
        }
        private void childTemplateTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Disable;
            OP_SubTemplate template = e.Node.Tag as OP_SubTemplate;
            if (template.NodeType == 0)
            {
                return;
            }

            string tag = template.Tag;
            if (tag == null)
            {
                return;
            }

            XTextElementList list = this.txWriterControl1.GetSpecifyElements(typeof(XTextInputFieldElement));
            XTextInputFieldElement input = this.txWriterControl1.GetElementById(tag) as XTextInputFieldElement;
            if (input == null)
            {
                input = this.txWriterControl1.Document.CreateElementByType(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
                InsertInputElementToTable(input, template.TagName);
            }

            //DialogResult result = MessageBox.Show("是否用追加的方式载入子模板" + Environment.NewLine + "点击(是)则追加,点击(否)则替换", "", MessageBoxButtons.YesNo);
            if (SysContext.CurrUser.Params.OP_DefaultSubTemplateAppend == "否")
            {
                input.Text = "";
            }

            input.ID = tag;
            input.AppendXML(template.Content);
            input = input.GetTopInputField() as XTextInputFieldElement;
            input.Enumerate((a, c) => { c.Element.StyleIndex = input.StyleIndex; });
            SetInputElementStyle(input, 2);
            XTextTableElement table = this.txWriterControl1.GetElementById("tableContext") as XTextTableElement;
            table.EditorRefreshView();
            XTextTableElement table1 = this.txWriterControl1.GetElementById("tableContext1") as XTextTableElement;
            table1.EditorRefreshView();
            this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;
        }
        private void templateSample1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            InsertTemplateSample(e.Node);
        }
        private void templateSample1_NodeDragStart(object sender, TreeNodeMouseEventArgs e)
        {
            this.templateSample1.Tree.SelectedNode = e.Node;
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Node.Level != 0)
            {
                DataObject DO = new DataObject(e.Node);
                DoDragDrop(DO, DragDropEffects.Copy);
            }
        }
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            //ImportDrugInfo();
            SaveRecord();
        }
        private void 另存为范文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsSample();
        }
        private void txWriterControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //foreach (InputLanguage item in InputLanguage.InstalledInputLanguages)
                //{
                //    if (item.LayoutName.Contains("搜狗") || item.LayoutName.Contains("百度"))
                //    {
                //        InputLanguage.CurrentInputLanguage = item;
                //        break;
                //    }
                //}
                IntPtr HIme = UnsafeNativeMethods.ImmGetContext(this.Handle);
                if (UnsafeNativeMethods.ImmGetOpenStatus(HIme))     //如果输入法处于打开状态   
                {
                    int iMode = 0;
                    int iSentence = 0;
                    bool bSuccess = UnsafeNativeMethods.ImmGetConversionStatus(HIme, ref iMode, ref iSentence);     //检索输入法信息   
                    if (bSuccess)
                    {
                        if ((iMode & IME_CMODE_FULLSHAPE) > 0)       //如果是全角   
                        {
                            UnsafeNativeMethods.ImmSimulateHotKey(this.Handle, IME_CHOTKEY_SHAPE_TOGGLE);     //转换成半角   
                        }
                    }

                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(MousePosition);
            }
        }
        #endregion

        #region 初始化操作
        private void 刷新工具箱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.templateSample1.InitSample();
            this.childTemplateTree1.InitTemplate();
            this.historyRecordTree1.InitRecord();
            this.knowlageTree1.InitData();
        }

        /// <summary>
        /// 初始化快捷键
        /// </summary>
        /// <param name="shortcutKey"></param>
        protected override void InitializeShortcutKeys(ShortcutKey shortcutKey)
        {
            shortcutKey.Set(Shortcut.CtrlV, new Action(() => 粘贴ToolStripMenuItem_Click(null, null)), "复制");
        }

        /// <summary>
        /// 初始化页眉页脚
        /// </summary>
        private void InitTemplate()
        {
            //this.txWriterControl1.XMLText = SysParams.GetTemplateHeaderAndFooter;
            //this.txWriterControl1.ExecuteCommand("InsertXML", false, SysParams.GetTemplateHeaderAndFooter);
            this.txWriterControl1.LoadDocumentFromString(SysParams.GetTemplateHeaderAndFooter, "XML");
            XTextInputFieldElement input = this.txWriterControl1.GetInputFieldElementById("RecordType");
            if (input != null)
            {
                if (SysContext.RunSysInfo.currDept.Name.Contains("急诊"))
                    input.Text = "急诊病历";
                else
                    input.Text = "门诊病历";
            }
        }

        /// <summary>
        /// 初始化病历节点信息
        /// </summary>
        private void InitTempalteNodeMenu()
        {
            foreach (OP_Dic_TemplateNode item in TemplateNodeType)
            {
                ToolStripMenuItem menu = new ToolStripMenuItem(item.Name);
                menu.Tag = item.Code;
                menu.Click += 主诉ToolStripMenuItem_Click;
                插入节点ToolStripMenuItem.DropDownItems.Add(menu);
            }
        }

        /// <summary>
        /// 初始化病历编辑器
        /// </summary>
        private void InitWriteControl()
        {
            this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;
            this.txWriterControl1.DocumentOptions.ViewOptions.FieldBackColor = Color.White;
            this.txWriterControl1.DocumentOptions.ViewOptions.FieldBorderColor = Color.Blue;
            this.txWriterControl1.DocumentOptions.ViewOptions.FieldFocusedBackColor = Color.White;
            this.txWriterControl1.DocumentOptions.ViewOptions.FieldHoverBackColor = Color.White;
            this.txWriterControl1.DocumentOptions.ViewOptions.HiddenFieldBorderWhenLostFocus = true;
        }

        private void InitPatientInfo(bool refreshDateTime)
        {
            try
            {
                IView_HIS_Outpatients patient = SysContext.GetCurrPatient;
                if (patient == null)
                {
                    return;
                }

                XTextInputFieldElement tmp = (XTextInputFieldElement)this.txWriterControl1.Document.GetElementById("日期");
                if (refreshDateTime)
                    tmp.Text = string.Format("{0:yyyy-MM-dd HH:mm}", DateTime.Now);
                if (patient == null || patient.PatientName == null)
                {
                    return;
                }

                tmp = (XTextInputFieldElement)this.txWriterControl1.Document.GetElementById("姓名");
                tmp.Text = patient.PatientName.Trim();
                tmp = (XTextInputFieldElement)this.txWriterControl1.Document.GetElementById("性别");
                tmp.Text = patient.Sex.Trim();
                tmp = (XTextInputFieldElement)this.txWriterControl1.Document.GetElementById("年龄");
                tmp.Text = patient.Age.Trim();
                tmp = (XTextInputFieldElement)this.txWriterControl1.Document.GetElementById("就诊号");
                tmp.Text = patient.OutpatientNo.Trim();
                tmp = (XTextInputFieldElement)this.txWriterControl1.Document.GetElementById("科室");
                tmp.Text = patient.DeptName.Trim();
                tmp = (XTextInputFieldElement)this.txWriterControl1.Document.GetElementById("身份");
                tmp.Text = patient.PayType.Trim();
                tmp = (XTextInputFieldElement)this.txWriterControl1.Document.GetElementById("门诊号");
                tmp.Text = patient.PatientID.AsString("").Trim();
                tmp = (XTextInputFieldElement)this.txWriterControl1.Document.GetElementById("签名");
                tmp.Elements.Clear();
                tmp.Text = "";
                if (SysContext.CurrUser.user.NameImage == null)
                {
                    tmp.Text = SysContext.CurrUser.user.Name;
                }
                else
                {
                    XTextImageElement image = new XTextImageElement();
                    XImageValue value = new XImageValue(SysContext.CurrUser.user.NameImage);
                    image.Image = value;
                    image.OwnerDocument = tmp.OwnerDocument;
                    image.SmoothZoom = true;
                    image.Width = 200;
                    image.Height = 80;
                    tmp.ContentBuilder.Append(image);
                    tmp.EditorRefreshView();
                }
                //tmp.Text = SysContext.CurrUser.user.Name;
            }
            catch
            {
            }

        }
        public void InitUI()
        {

            try
            {
                InitTemplate();
                bool HasRecord = InitPatientRecord();
                if (!HasRecord)
                    InitPatientInfo(true);
                else
                    InitPatientInfo(false);

                this.historyRecordTree1.InitRecord();
                this.txWriterControl1.Document.DefaultFont = new XFontValue(this.txWriterControl1.Document.DefaultFont.Name, 10);
                RecodeID = "";
            }
            catch
            {
            }
            //InitPatientRecord(patient.PatientID);
        }

        /// <summary>
        /// 初始化病人资料
        /// </summary>
        /// <param name="TreatmentNo">就诊号</param>
        private bool InitPatientRecord()
        {
            List<OP_MedicalRecords> record = DBHelper.CIS.From<OP_MedicalRecords>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo && p.UserID == SysContext.CurrUser.UserId).OrderByDescending(p => p.UpdateTime).ToList();

            if (record.Count > 0)
            {
                record[0].XML = record[0].XML.Replace("DrugInfo", "DealWith");
                record[0].XML = record[0].XML.Replace("table1", "tableContext1");
                SysContext.IsFirstRecord = record[0].Type.AsInt(0);
                this.txWriterControl1.LoadDocumentFromString(record[0].XML, "XML");
                return true;
            }
            return false;
        }

        #endregion

        #region 病历相关操作
        private void ImportDrugInfo()
        {
            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.ImportDrugInfoToRecord });
        }
        /// <summary>
        /// 删除病历内的指定节点
        /// </summary>
        /// <param name="input"></param>
        private void DeleteTempalteNode(XTextInputFieldElement input)
        {
            string name = input.ID;
            if (TemplateNodeType.FindIndex(p => p.Code == name) < 0)
            {
                AlertBox.Info("当前节点无法删除");
                return;
            }
            XTextTableRowElement row = input.GetOwnerParent(typeof(XTextTableRowElement), false) as XTextTableRowElement;
            XTextTableElement table = this.txWriterControl1.GetElementById("tableContext") as XTextTableElement;
            table.Rows.Remove(row);
            this.txWriterControl1.RefreshDocument();
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
                    {
                        break;
                    }

                    xmlList.Add(new MyStruct { XML = inputTmp.InnerXML, Type = inputTmp.ID });
                }
                xmlList.Insert(i + 1, new MyStruct { XML = "", Type = NodeType });

                table.Rows.Clear();
                InsertRowDownFromTable(table);
                foreach (MyStruct item in xmlList)
                {
                    OP_Dic_TemplateNode nodeType = TemplateNodeType.Where(p => p.Code == item.Type).First();
                    input = this.txWriterControl1.Document.CreateElementByType(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
                    if (item.XML != "")
                    {
                        input.AppendXML(item.XML);
                    }

                    input.ID = nodeType.Code;
                    this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Disable;
                    InsertInputElementToTable(input, nodeType.Name);
                    SetInputElementStyle(inputs, 2);
                }
            }
            else
            {
                input.Focus();
            }
        }
        /// <summary>
        /// 插入范文
        /// </summary>
        /// <param name="node"></param>
        private void InsertTemplateSample(Node node)
        {
            if (node.Tag == null)
            {
                return;
            }

            OP_TemplateSample lib = node.Tag as OP_TemplateSample;
            PropertyInfo[] propertyInfo = lib.GetType().GetProperties();
            XTextTableElement table = this.txWriterControl1.GetElementById("tableContext") as XTextTableElement;
            rowStyle = table.Rows[0].Style.Clone();
            table.Rows.Clear();

            InsertRowDownFromTable(table);
            foreach (PropertyInfo item in propertyInfo)
            {
                XTextInputFieldElement input = this.txWriterControl1.GetElementById(item.Name) as XTextInputFieldElement;
                OP_Dic_TemplateNode nodeType = TemplateNodeType.Find(p => p.Code == item.Name);
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
                    SetInputElementStyle(input, 2);
                }
            }
            XTextTableElement table1 = this.txWriterControl1.GetElementById("tableContext1") as XTextTableElement;
            table.EditorRefreshView();
            table1.EditorRefreshView();
        }
        /// <summary>
        /// 将XML插入到当前焦点的输入域当中
        /// </summary>
        /// <param name="XML"></param>
        private void InsertXMLToFoucedXTextElement(string XML)
        {
            XTextInputFieldElement input = this.txWriterControl1.GetCurrentElement(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
            if (input == null || TemplateNodeType.FindIndex(p => p.Code == input.ID) < 0)
            {
                AlertBox.Info("您必须在指定的输入域位置放置内容");
                return;
            }

            //XTextElementList list = this.txWriterControl1.ExecuteCommand("InsertXML", false, XML) as XTextElementList;


            input = input.GetTopInputField() as XTextInputFieldElement;
            if (SysContext.CurrUser.Params.OP_DefaultSubTemplateAppend == "否")
            {
                input.Text = "";
            }
            ////input.Text = "";
            this.txWriterControl1.Document.InsertXml(XML);
            input.EditorRefreshView();

            SetInputElementStyle(input, 2);
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
            {
                table.EditorRefreshView();
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
        /// 将输入域插入到表格最后一行中
        /// </summary>
        /// <param name="input"></param>
        /// <param name="tag"></param>
        private void InsertInputElementToTable(List<XTextInputFieldElement> inputs, List<string> tag)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                InsertInputElementToTable(inputs[i], tag[i]);
            }
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
            {
                input.EditorRefreshView();
            }
        }
        private void SetInputElementStyle(List<XTextInputFieldElement> inputs, int BorderWidth, bool updateUI = false)
        {
            foreach (XTextInputFieldElement item in inputs)
            {
                SetInputElementStyle(item, BorderWidth, updateUI);
            }
        }
        /// <summary>
        /// 清除临时样式
        /// </summary>
        private void ClearTempStyle()
        {
            var inputFields = this.txWriterControl1.Document.Body.GetElementsByType(typeof(XTextInputFieldElement));
            foreach (XTextInputFieldElement item in inputFields)
            {
                if (item.GetAttribute("IsTempStyle").AsBoolean())
                {
                    var style = item.Style.Clone() as DocumentContentStyle;
                    style.BorderBottom = false;
                    item.Style = style;
                    item.Attributes.RemoveByName("IsTempStyle");
                }
            }
        }
        /// <summary>
        /// 隐藏临时样式
        /// </summary>
        private void HiddenTempStyle()
        {
            var inputFields = this.txWriterControl1.Document.Body.GetElementsByType(typeof(XTextInputFieldElement));
            foreach (XTextInputFieldElement item in inputFields)
            {
                if (item.GetAttribute("IsTempStyle").AsBoolean())
                {
                    var style = item.Style.Clone() as DocumentContentStyle;
                    style.BorderBottom = false;
                    item.Style = style;
                }
            }
        }
        /// <summary>
        /// 显示临时样式
        /// </summary>
        private void ShowTempStyle()
        {
            var inputFields = this.txWriterControl1.Document.Body.GetElementsByType(typeof(XTextInputFieldElement));
            foreach (XTextInputFieldElement item in inputFields)
            {
                if (item.GetAttribute("IsTempStyle").AsBoolean())
                {
                    var style = item.Style.Clone() as DocumentContentStyle;
                    style.BorderBottom = true;
                    item.Style = style;
                }
            }
        }
        /// <summary>
        /// 获得病历的所有内容
        /// </summary>
        /// <returns></returns>
        private OP_MedicalRecords GetRecordDate()
        {
            OP_MedicalRecords result = new OP_MedicalRecords();
            foreach (OP_Dic_TemplateNode item in TemplateNodeType)
            {
                XTextInputFieldElement input = this.txWriterControl1.GetElementById(item.Code) as XTextInputFieldElement;
                if (input != null)
                {
                    PropertyInfo propertyInfo = result.GetType().GetProperty(item.Code);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(result, input.Text == "" ? null : input.Text, null);
                    }
                }
            }
            XTextInputFieldElement inputDT = this.txWriterControl1.GetElementById("日期") as XTextInputFieldElement;
            DateTime dt = DBHelper.ServerTime;
            if (inputDT != null)
            {
                DateTime.TryParse(inputDT.Text, out dt);
            }

            result.ID = Guid.NewGuid().ToString();
            result.TreatmentNo = SysContext.GetCurrPatient.OutpatientNo.ToString();
            result.PatientID = (SysContext.GetCurrPatient.PatientID ?? "").ToString();
            result.UserID = SysContext.CurrUser.user.Code;
            result.DeptCode = SysContext.RunSysInfo.currDept.Code;
            result.UpdateTime = dt;
            result.XML = this.txWriterControl1.XMLTextUnFormatted;
            return result;
        }

        private void SaveRecord()
        {
            if (!SysContext.Session.ContainsKey(SysContext.Session_CurrPatient))
            {
                AlertBox.Error("没有选中患者");
                return;
            }

            string TreatmentNo = SysContext.GetCurrPatient.OutpatientNo.ToString();
            string UserID = SysContext.CurrUser.user.Code;
            var data = DBHelper.CIS.Delete<OP_MedicalRecords>(p => p.TreatmentNo == TreatmentNo && p.UserID == UserID);
            CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存前删除对应原病历", "就诊号:" + TreatmentNo + " 操作id:" + UserID, data > 0 ? "病历删除成功！" : "病历删除失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
            OP_MedicalRecords record = GetRecordDate();
            record.PatientName = SysContext.GetCurrPatient.PatientName;
            record.Type = SysContext.IsFirstRecord;
            var dataInsert = DBHelper.CIS.Insert<OP_MedicalRecords>(record);
            CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存病历", SerializeHelper.BeginJsonSerializable(record), dataInsert > 0 ? "病历保存成功！" : "病历保存失败！"), dataInsert > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
            RecodeID = record.ID;
            AlertBox.Info("保存成功");

        }
        private void SaveAsSample()
        {
            FormRecordSample form = new FormRecordSample();
            form.form = this;
            form.ShowDialog();
        }
        public void InsertDiagnosisInRecord(string diagnosis, bool IsHM)
        {
            if (IsHM)
            {
                XTextInputFieldElement input = this.txWriterControl1.GetElementById("西医诊断") as XTextInputFieldElement;
                if (input != null)
                {
                    input.Text = diagnosis;
                }
            }
            else
            {
                XTextInputFieldElement input = this.txWriterControl1.GetElementById("中医诊断") as XTextInputFieldElement;
                if (input != null)
                {
                    input.Text = diagnosis;
                }
            }
        }
        #endregion

        #region 被外部调用的接口
        public bool HasPersonel()
        {
            var input = this.txWriterControl1.GetInputFieldElementById("Personal");
            if (input == null)
                return false;

            if (input.Text.AsString("") == "")
                return false;

            return true;
        }
        /// <summary>
        /// 获得病历的主要内容
        /// </summary>
        /// <returns></returns>
        public RecordDate GetRecordContext()
        {
            RecordDate result = new RecordDate();
            foreach (OP_Dic_TemplateNode item in TemplateNodeType)
            {
                XTextInputFieldElement input = this.txWriterControl1.GetElementById(item.Code) as XTextInputFieldElement;
                if (input != null)
                {
                    PropertyInfo propertyInfo = result.GetType().GetProperty(item.Code);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(result, input.Text + "%%%$$$CIS999" + input.InnerXML, null);
                    }
                }
            }
            return result;
        }
        public void ImportDrugInfo(DataTable dt, string PrescriptionType)
        {
            XTextInputFieldElement input = this.txWriterControl1.GetElementById("myDealWith") as XTextInputFieldElement;
            if (input == null)
            {
                InsertTemplateNode("处理", "myDealWith");
                input = this.txWriterControl1.GetElementById("myDealWith") as XTextInputFieldElement;
            }
            if (PrescriptionType == "2")
            {
                string LineText = "";

                int lineNum = dt.Rows.Count / 3; //总共有多少行,一行有3个

                int[] lineLength = new int[3];
                for (int i = 0; i < dt.Rows.Count; i += 3)
                {
                    if (dt.Rows.Count > i && lineLength[0] < dt.Rows[i]["DrugName"].AsString("").Trim().Length)
                        lineLength[0] = dt.Rows[i]["DrugName"].AsString("").Trim().Length;  //找出当前草药中第一列中最长的一个药品的长度
                    if (dt.Rows.Count > i + 1 && lineLength[1] < dt.Rows[i + 1]["DrugName"].AsString("").Trim().Length)
                        lineLength[1] = dt.Rows[i + 1]["DrugName"].AsString("").Trim().Length;  //找出当前草药中第二列中最长的一个药品的长度
                    if (dt.Rows.Count > i + 2 && lineLength[2] < dt.Rows[i + 2]["DrugName"].AsString("").Trim().Length)
                        lineLength[2] = dt.Rows[i + 2]["DrugName"].AsString("").Trim().Length;  //找出当前草药中第三列中最长的一个药品的长度
                }

                lineLength[0] += 2;
                lineLength[1] += 2;
                lineLength[2] += 2;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LineText += dt.Rows[i]["DrugName"].AsString("").Trim().PadRight(lineLength[i % 3], '　');
                    if ((i + 1) % 3 == 0)
                        LineText += Environment.NewLine;
                }

                if (LineText != "")
                    input.Text += Environment.NewLine + LineText;

                input.Text += Environment.NewLine + "共 " + dt.Rows[0]["HerbalMedicineNum"].AsString("") + " 剂  用法：" + dt.Rows[0]["ConditionSummary"].AsString("");
            }
            else
            {
                foreach (DataRow item in dt.Rows)
                {
                    if ((item["Group"] ?? "").ToString() == "1")
                    {
                        List<string> str = item["DrugName"].ToString().Split(Environment.NewLine.ToCharArray()).ToList();
                        str.RemoveAll(p => p == "");
                        for (int i = 0; i < str.Count; i++)
                        {
                            if (i == 0)
                            {
                                str[i] = "┏ " + str[i];
                            }
                            else if (i == str.Count - 1)
                            {
                                str[i] = "┗ " + str[i];
                            }
                            else
                            {
                                str[i] = "┃ " + str[i];
                            }
                        }
                        input.Text += Environment.NewLine + string.Join(Environment.NewLine, str);
                    }
                    else
                    {
                        //if (item["DrugName"].ToString().Substring(0, 2) == "1.")
                        //    input.Text += Environment.NewLine + item["DrugName"].ToString().Substring(2, item["DrugName"].ToString().Length - 2).TrimEnd(Environment.NewLine.ToCharArray());
                        //else
                        input.Text += Environment.NewLine + item["DrugName"].ToString().TrimEnd(Environment.NewLine.ToCharArray());
                    }

                }
            }
            input.Text.TrimStart(Environment.NewLine.ToCharArray());
            //input.Text = str1.TrimEnd((Environment.NewLine + Environment.NewLine).ToCharArray());
        }

        public void ClearDiagnosis()
        {
            XTextInputFieldElement input = this.txWriterControl1.GetElementById("DrugInfo") as XTextInputFieldElement;
            if (input == null)
            {
                return;
            }

            input.Text = "";
        }
        public void ImportLISResult(string result)
        {
            XTextElement input = this.txWriterControl1.GetElementById("ExaminationResult");
            if (input == null)
            {
                return;
            } (input as XTextInputFieldElement).Text += result;
        }
        public string GetPresentIllness()
        {
            string str = "";
            XTextElementList list = this.txWriterControl1.GetSpecifyElements(typeof(XTextInputFieldElement));
            List<OP_Dic_TemplateNode> tmp = TemplateNodeType.OrderBy(p => p.No).ToList();
            foreach (OP_Dic_TemplateNode item in tmp)
            {
                XTextInputFieldElement temp = list.Find(p => p.ID == item.Code) as XTextInputFieldElement;
                if (temp == null || temp.Text == "")
                {
                    continue;
                }

                str += item.Name + "：" + temp.Text + Environment.NewLine;
            }
            return str;
        }
        public void ImportXMLToRecord(string XML)
        {
            this.txWriterControl1.LoadDocumentFromString(XML, "XML");
            InitPatientInfo(true);
        }
        #endregion
        private void FormMedical_Shown(object sender, EventArgs e)
        {
            this.biEcgQueryReport.Visible = SysContext.RunSysInfo.Params.OP_EcgRead;
            TemplateNodeType = DBHelper.CIS.From<OP_Dic_TemplateNode>().OrderBy(p => p.No).ToList();
            this.childTemplateTree1.InitTemplate();
            this.templateSample1.InitSample();
            this.knowlageTree1.InitData();
            InitTemplate();
            InitTempalteNodeMenu();
            InitWriteControl();
            this.txWriterControl1.SetZoomRate((float)1.25);
            this.historyRecordTree1.formMain = formMain;
            this.txWriterControl1.DocumentOptions.BehaviorOptions.ParagraphFlagFollowTableOrSection = true;
        }

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

        public override void OnClose()
        {
            base.OnClose();
        }
    }
}
