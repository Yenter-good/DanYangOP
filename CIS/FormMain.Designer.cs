namespace CIS
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.btnUserSet = new DevComponents.DotNetBar.ButtonX();
            this.btnDoctorInfo = new DevComponents.DotNetBar.ButtonItem();
            this.btnSetUserParameter = new DevComponents.DotNetBar.ButtonItem();
            this.btnSetPwd = new DevComponents.DotNetBar.ButtonItem();
            this.btnSwitchingUser = new DevComponents.DotNetBar.ButtonItem();
            this.btnExit = new DevComponents.DotNetBar.ButtonItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbxClinic = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxDept = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.AppButtonMain = new DevComponents.DotNetBar.ApplicationButton();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.epanlLeft = new DevComponents.DotNetBar.ExpandablePanel();
            this.ebarMain = new DevComponents.DotNetBar.ExplorerBar();
            this.contextMenu_tabMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeOthersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lblUser = new DevComponents.DotNetBar.LabelX();
            this.lblDept = new DevComponents.DotNetBar.LabelX();
            this.tabMain = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabItemProclamation = new DevComponents.DotNetBar.SuperTabItem();
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.epanlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ebarMain)).BeginInit();
            this.contextMenu_tabMain.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.ForeColor = System.Drawing.Color.Black;
            this.ribbonControl1.Images = this.imageList;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.AppButtonMain,
            this.ribbonTabItem1});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = resources.GetString("ribbonControl1.SystemText.MaximizeRibbonText");
            this.ribbonControl1.SystemText.MinimizeRibbonText = resources.GetString("ribbonControl1.SystemText.MinimizeRibbonText");
            this.ribbonControl1.SystemText.QatAddItemText = resources.GetString("ribbonControl1.SystemText.QatAddItemText");
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = resources.GetString("ribbonControl1.SystemText.QatCustomizeMenuLabel");
            this.ribbonControl1.SystemText.QatCustomizeText = resources.GetString("ribbonControl1.SystemText.QatCustomizeText");
            this.ribbonControl1.SystemText.QatDialogAddButton = resources.GetString("ribbonControl1.SystemText.QatDialogAddButton");
            this.ribbonControl1.SystemText.QatDialogCancelButton = resources.GetString("ribbonControl1.SystemText.QatDialogCancelButton");
            this.ribbonControl1.SystemText.QatDialogCaption = resources.GetString("ribbonControl1.SystemText.QatDialogCaption");
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = resources.GetString("ribbonControl1.SystemText.QatDialogCategoriesLabel");
            this.ribbonControl1.SystemText.QatDialogOkButton = resources.GetString("ribbonControl1.SystemText.QatDialogOkButton");
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = resources.GetString("ribbonControl1.SystemText.QatDialogPlacementCheckbox");
            this.ribbonControl1.SystemText.QatDialogRemoveButton = resources.GetString("ribbonControl1.SystemText.QatDialogRemoveButton");
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = resources.GetString("ribbonControl1.SystemText.QatPlaceAboveRibbonText");
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = resources.GetString("ribbonControl1.SystemText.QatPlaceBelowRibbonText");
            this.ribbonControl1.SystemText.QatRemoveItemText = resources.GetString("ribbonControl1.SystemText.QatRemoveItemText");
            this.ribbonControl1.TabGroupHeight = 14;
            // 
            // ribbonPanel1
            // 
            resources.ApplyResources(this.ribbonPanel1, "ribbonPanel1");
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.btnUserSet);
            this.ribbonPanel1.Controls.Add(this.labelX2);
            this.ribbonPanel1.Controls.Add(this.labelX1);
            this.ribbonPanel1.Controls.Add(this.cbxClinic);
            this.ribbonPanel1.Controls.Add(this.cbxDept);
            this.ribbonPanel1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ribbonPanel1.Name = "ribbonPanel1";
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnUserSet
            // 
            this.btnUserSet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUserSet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnUserSet, "btnUserSet");
            this.btnUserSet.Image = ((System.Drawing.Image)(resources.GetObject("btnUserSet.Image")));
            this.btnUserSet.Name = "btnUserSet";
            this.btnUserSet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUserSet.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDoctorInfo,
            this.btnSetUserParameter,
            this.btnSetPwd,
            this.btnSwitchingUser,
            this.btnExit});
            this.btnUserSet.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnUserSet.Click += new System.EventHandler(this.btnUserSet_Click);
            // 
            // btnDoctorInfo
            // 
            this.btnDoctorInfo.GlobalItem = false;
            this.btnDoctorInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnDoctorInfo.Image")));
            this.btnDoctorInfo.Name = "btnDoctorInfo";
            resources.ApplyResources(this.btnDoctorInfo, "btnDoctorInfo");
            this.btnDoctorInfo.Click += new System.EventHandler(this.btnDoctorInfo_Click);
            // 
            // btnSetUserParameter
            // 
            this.btnSetUserParameter.GlobalItem = false;
            this.btnSetUserParameter.Image = ((System.Drawing.Image)(resources.GetObject("btnSetUserParameter.Image")));
            this.btnSetUserParameter.Name = "btnSetUserParameter";
            resources.ApplyResources(this.btnSetUserParameter, "btnSetUserParameter");
            this.btnSetUserParameter.Click += new System.EventHandler(this.btnSetUserParameter_Click);
            // 
            // btnSetPwd
            // 
            this.btnSetPwd.GlobalItem = false;
            this.btnSetPwd.Image = ((System.Drawing.Image)(resources.GetObject("btnSetPwd.Image")));
            this.btnSetPwd.Name = "btnSetPwd";
            resources.ApplyResources(this.btnSetPwd, "btnSetPwd");
            this.btnSetPwd.Click += new System.EventHandler(this.btnSetPwd_Click);
            // 
            // btnSwitchingUser
            // 
            this.btnSwitchingUser.GlobalItem = false;
            this.btnSwitchingUser.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitchingUser.Image")));
            this.btnSwitchingUser.Name = "btnSwitchingUser";
            resources.ApplyResources(this.btnSwitchingUser, "btnSwitchingUser");
            this.btnSwitchingUser.Click += new System.EventHandler(this.btnSwitchingUser_Click);
            // 
            // btnExit
            // 
            this.btnExit.GlobalItem = false;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Name = "btnExit";
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelX2
            // 
            resources.ApplyResources(this.labelX2, "labelX2");
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Name = "labelX2";
            // 
            // labelX1
            // 
            resources.ApplyResources(this.labelX1, "labelX1");
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Name = "labelX1";
            // 
            // cbxClinic
            // 
            resources.ApplyResources(this.cbxClinic, "cbxClinic");
            this.cbxClinic.DisplayMember = "Text";
            this.cbxClinic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxClinic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClinic.FormattingEnabled = true;
            this.cbxClinic.Name = "cbxClinic";
            this.cbxClinic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxClinic.SelectedIndexChanged += new System.EventHandler(this.cbxClinic_SelectedIndexChanged);
            // 
            // cbxDept
            // 
            resources.ApplyResources(this.cbxDept, "cbxDept");
            this.cbxDept.DisplayMember = "Text";
            this.cbxDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDept.FormattingEnabled = true;
            this.cbxDept.Name = "cbxDept";
            this.cbxDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxDept.SelectedIndexChanged += new System.EventHandler(this.cbxDept_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "1.ico");
            this.imageList.Images.SetKeyName(1, "2.ico");
            this.imageList.Images.SetKeyName(2, "3.ico");
            this.imageList.Images.SetKeyName(3, "4.ico");
            this.imageList.Images.SetKeyName(4, "5.ico");
            this.imageList.Images.SetKeyName(5, "6.ico");
            this.imageList.Images.SetKeyName(6, "7.ico");
            this.imageList.Images.SetKeyName(7, "8.ico");
            this.imageList.Images.SetKeyName(8, "9.ico");
            this.imageList.Images.SetKeyName(9, "10.ico");
            this.imageList.Images.SetKeyName(10, "11.ico");
            this.imageList.Images.SetKeyName(11, "12.ico");
            this.imageList.Images.SetKeyName(12, "13.ico");
            this.imageList.Images.SetKeyName(13, "14.ico");
            this.imageList.Images.SetKeyName(14, "15.ico");
            this.imageList.Images.SetKeyName(15, "16.ico");
            this.imageList.Images.SetKeyName(16, "17.ico");
            this.imageList.Images.SetKeyName(17, "18.ico");
            this.imageList.Images.SetKeyName(18, "19.ico");
            this.imageList.Images.SetKeyName(19, "20.ico");
            this.imageList.Images.SetKeyName(20, "21.ico");
            this.imageList.Images.SetKeyName(21, "22.ico");
            this.imageList.Images.SetKeyName(22, "23.ico");
            this.imageList.Images.SetKeyName(23, "24.ico");
            this.imageList.Images.SetKeyName(24, "25.ico");
            this.imageList.Images.SetKeyName(25, "26.ico");
            this.imageList.Images.SetKeyName(26, "27.ico");
            this.imageList.Images.SetKeyName(27, "28.ico");
            this.imageList.Images.SetKeyName(28, "29.ico");
            this.imageList.Images.SetKeyName(29, "30.ico");
            this.imageList.Images.SetKeyName(30, "31.ico");
            this.imageList.Images.SetKeyName(31, "32.ico");
            this.imageList.Images.SetKeyName(32, "33.ico");
            this.imageList.Images.SetKeyName(33, "34.ico");
            this.imageList.Images.SetKeyName(34, "35.ico");
            this.imageList.Images.SetKeyName(35, "36.ico");
            this.imageList.Images.SetKeyName(36, "37.ico");
            this.imageList.Images.SetKeyName(37, "38.ico");
            this.imageList.Images.SetKeyName(38, "39.ico");
            this.imageList.Images.SetKeyName(39, "40.ico");
            this.imageList.Images.SetKeyName(40, "41.ico");
            this.imageList.Images.SetKeyName(41, "42.ico");
            this.imageList.Images.SetKeyName(42, "43.ico");
            this.imageList.Images.SetKeyName(43, "44.ico");
            this.imageList.Images.SetKeyName(44, "45.ico");
            this.imageList.Images.SetKeyName(45, "46.ico");
            this.imageList.Images.SetKeyName(46, "47.ico");
            this.imageList.Images.SetKeyName(47, "48.ico");
            this.imageList.Images.SetKeyName(48, "49.ico");
            this.imageList.Images.SetKeyName(49, "50.ico");
            this.imageList.Images.SetKeyName(50, "51.ico");
            this.imageList.Images.SetKeyName(51, "52.ico");
            this.imageList.Images.SetKeyName(52, "53.ico");
            this.imageList.Images.SetKeyName(53, "54.ico");
            this.imageList.Images.SetKeyName(54, "55.ico");
            this.imageList.Images.SetKeyName(55, "56.ico");
            this.imageList.Images.SetKeyName(56, "57.ico");
            this.imageList.Images.SetKeyName(57, "58.ico");
            this.imageList.Images.SetKeyName(58, "59.ico");
            this.imageList.Images.SetKeyName(59, "60.ico");
            this.imageList.Images.SetKeyName(60, "61.ico");
            this.imageList.Images.SetKeyName(61, "62.ico");
            this.imageList.Images.SetKeyName(62, "63.ico");
            this.imageList.Images.SetKeyName(63, "64.ico");
            this.imageList.Images.SetKeyName(64, "65.ico");
            this.imageList.Images.SetKeyName(65, "66.ico");
            this.imageList.Images.SetKeyName(66, "67.ico");
            this.imageList.Images.SetKeyName(67, "68.ico");
            this.imageList.Images.SetKeyName(68, "69.ico");
            this.imageList.Images.SetKeyName(69, "70.ico");
            this.imageList.Images.SetKeyName(70, "71.ico");
            this.imageList.Images.SetKeyName(71, "72.ico");
            this.imageList.Images.SetKeyName(72, "73.ico");
            this.imageList.Images.SetKeyName(73, "74.ico");
            this.imageList.Images.SetKeyName(74, "75.ico");
            this.imageList.Images.SetKeyName(75, "76.ico");
            this.imageList.Images.SetKeyName(76, "77.ico");
            this.imageList.Images.SetKeyName(77, "78.ico");
            this.imageList.Images.SetKeyName(78, "79.ico");
            this.imageList.Images.SetKeyName(79, "80.ico");
            this.imageList.Images.SetKeyName(80, "81.ico");
            this.imageList.Images.SetKeyName(81, "82.ico");
            this.imageList.Images.SetKeyName(82, "83.ico");
            this.imageList.Images.SetKeyName(83, "84.ico");
            this.imageList.Images.SetKeyName(84, "85.ico");
            this.imageList.Images.SetKeyName(85, "86.ico");
            this.imageList.Images.SetKeyName(86, "87.ico");
            this.imageList.Images.SetKeyName(87, "88.ico");
            this.imageList.Images.SetKeyName(88, "89.ico");
            this.imageList.Images.SetKeyName(89, "90.ico");
            this.imageList.Images.SetKeyName(90, "91.ico");
            this.imageList.Images.SetKeyName(91, "92.ico");
            this.imageList.Images.SetKeyName(92, "93.ico");
            this.imageList.Images.SetKeyName(93, "94.ico");
            this.imageList.Images.SetKeyName(94, "95.ico");
            this.imageList.Images.SetKeyName(95, "96.ico");
            this.imageList.Images.SetKeyName(96, "97.ico");
            this.imageList.Images.SetKeyName(97, "98.ico");
            this.imageList.Images.SetKeyName(98, "99.ico");
            this.imageList.Images.SetKeyName(99, "100.ico");
            this.imageList.Images.SetKeyName(100, "101.ico");
            this.imageList.Images.SetKeyName(101, "102.ico");
            this.imageList.Images.SetKeyName(102, "103.ico");
            this.imageList.Images.SetKeyName(103, "104.ico");
            this.imageList.Images.SetKeyName(104, "105.ico");
            this.imageList.Images.SetKeyName(105, "106.ico");
            this.imageList.Images.SetKeyName(106, "107.ico");
            this.imageList.Images.SetKeyName(107, "108.ico");
            this.imageList.Images.SetKeyName(108, "109.ico");
            this.imageList.Images.SetKeyName(109, "110.ico");
            this.imageList.Images.SetKeyName(110, "111.ico");
            this.imageList.Images.SetKeyName(111, "112.ico");
            this.imageList.Images.SetKeyName(112, "113.ico");
            this.imageList.Images.SetKeyName(113, "114.ico");
            this.imageList.Images.SetKeyName(114, "115.ico");
            this.imageList.Images.SetKeyName(115, "116.ico");
            this.imageList.Images.SetKeyName(116, "117.ico");
            this.imageList.Images.SetKeyName(117, "118.ico");
            this.imageList.Images.SetKeyName(118, "119.ico");
            this.imageList.Images.SetKeyName(119, "120.ico");
            this.imageList.Images.SetKeyName(120, "121.ico");
            this.imageList.Images.SetKeyName(121, "122.ico");
            this.imageList.Images.SetKeyName(122, "123.ico");
            this.imageList.Images.SetKeyName(123, "124.ico");
            this.imageList.Images.SetKeyName(124, "125.ico");
            this.imageList.Images.SetKeyName(125, "126.ico");
            this.imageList.Images.SetKeyName(126, "127.ico");
            this.imageList.Images.SetKeyName(127, "128.ico");
            this.imageList.Images.SetKeyName(128, "129.ico");
            this.imageList.Images.SetKeyName(129, "130.ico");
            this.imageList.Images.SetKeyName(130, "131.ico");
            this.imageList.Images.SetKeyName(131, "132.ico");
            this.imageList.Images.SetKeyName(132, "133.ico");
            this.imageList.Images.SetKeyName(133, "134.ico");
            this.imageList.Images.SetKeyName(134, "135.ico");
            this.imageList.Images.SetKeyName(135, "136.ico");
            this.imageList.Images.SetKeyName(136, "137.ico");
            // 
            // AppButtonMain
            // 
            this.AppButtonMain.AutoExpandOnClick = true;
            this.AppButtonMain.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.AppButtonMain.CanCustomize = false;
            this.AppButtonMain.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.AppButtonMain.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.AppButtonMain.ImagePaddingHorizontal = 0;
            this.AppButtonMain.ImagePaddingVertical = 0;
            this.AppButtonMain.Name = "AppButtonMain";
            this.AppButtonMain.ShowSubItems = false;
            resources.ApplyResources(this.AppButtonMain, "AppButtonMain");
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Checked = true;
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            resources.ApplyResources(this.ribbonTabItem1, "ribbonTabItem1");
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // epanlLeft
            // 
            this.epanlLeft.CanvasColor = System.Drawing.SystemColors.Control;
            this.epanlLeft.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.epanlLeft.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.epanlLeft.Controls.Add(this.ebarMain);
            this.epanlLeft.DisabledBackColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.epanlLeft, "epanlLeft");
            this.epanlLeft.ExpandOnTitleClick = true;
            this.epanlLeft.HideControlsWhenCollapsed = true;
            this.epanlLeft.Name = "epanlLeft";
            this.epanlLeft.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.epanlLeft.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epanlLeft.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.epanlLeft.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.epanlLeft.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.epanlLeft.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.epanlLeft.Style.GradientAngle = 90;
            this.epanlLeft.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.epanlLeft.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epanlLeft.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.epanlLeft.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.epanlLeft.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.epanlLeft.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.epanlLeft.TitleStyle.GradientAngle = 90;
            // 
            // ebarMain
            // 
            this.ebarMain.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.ebarMain.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.ebarMain.BackStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ExplorerBarBackground2;
            this.ebarMain.BackStyle.BackColorGradientAngle = 90;
            this.ebarMain.BackStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ExplorerBarBackground;
            this.ebarMain.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.ebarMain, "ebarMain");
            this.ebarMain.GroupImages = null;
            this.ebarMain.Images = null;
            this.ebarMain.Name = "ebarMain";
            this.ebarMain.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SystemColors;
            // 
            // contextMenu_tabMain
            // 
            this.contextMenu_tabMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeOthersMenuItem,
            this.closeAllTabMenuItem});
            this.contextMenu_tabMain.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenu_tabMain, "contextMenu_tabMain");
            // 
            // closeOthersMenuItem
            // 
            this.closeOthersMenuItem.Name = "closeOthersMenuItem";
            resources.ApplyResources(this.closeOthersMenuItem, "closeOthersMenuItem");
            this.closeOthersMenuItem.Click += new System.EventHandler(this.closeOthersMenuItem_Click);
            // 
            // closeAllTabMenuItem
            // 
            this.closeAllTabMenuItem.Name = "closeAllTabMenuItem";
            resources.ApplyResources(this.closeAllTabMenuItem, "closeAllTabMenuItem");
            this.closeAllTabMenuItem.Click += new System.EventHandler(this.closeAllTabMenuItem_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.lblUser);
            this.panelEx1.Controls.Add(this.lblDept);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.panelEx1, "panelEx1");
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // lblUser
            // 
            // 
            // 
            // 
            this.lblUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.Name = "lblUser";
            // 
            // lblDept
            // 
            // 
            // 
            // 
            this.lblDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.lblDept, "lblDept");
            this.lblDept.Name = "lblDept";
            // 
            // tabMain
            // 
            this.tabMain.CloseButtonOnTabsVisible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tabMain.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tabMain.ControlBox.MenuBox.Name = "";
            this.tabMain.ControlBox.Name = "";
            this.tabMain.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabMain.ControlBox.MenuBox,
            this.tabMain.ControlBox.CloseBox});
            this.tabMain.Controls.Add(this.superTabControlPanel1);
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Name = "tabMain";
            this.tabMain.ReorderTabsEnabled = true;
            this.tabMain.SelectedTabIndex = 0;
            this.tabMain.TabCloseButtonHot = ((System.Drawing.Image)(resources.GetObject("tabMain.TabCloseButtonHot")));
            this.tabMain.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabItemProclamation});
            this.tabMain.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.tabMain.TabRemoved += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripTabRemovedEventArgs>(this.tabMain_TabRemoved);
            // 
            // superTabControlPanel1
            // 
            resources.ApplyResources(this.superTabControlPanel1, "superTabControlPanel1");
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.TabItem = this.tabItemProclamation;
            // 
            // tabItemProclamation
            // 
            this.tabItemProclamation.AttachedControl = this.superTabControlPanel1;
            this.tabItemProclamation.CloseButtonVisible = false;
            this.tabItemProclamation.GlobalItem = false;
            this.tabItemProclamation.Name = "tabItemProclamation";
            resources.ApplyResources(this.tabItemProclamation, "tabItemProclamation");
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.epanlLeft);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.panelEx1);
            this.Name = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            this.epanlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ebarMain)).EndInit();
            this.contextMenu_tabMain.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.ApplicationButton AppButtonMain;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ImageList imageList;
        private DevComponents.DotNetBar.ExpandablePanel epanlLeft;
        private DevComponents.DotNetBar.ExplorerBar ebarMain;
        private System.Windows.Forms.ContextMenuStrip contextMenu_tabMain;
        private System.Windows.Forms.ToolStripMenuItem closeOthersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllTabMenuItem;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxDept;
        private DevComponents.DotNetBar.ButtonX btnUserSet;
        private DevComponents.DotNetBar.ButtonItem btnSwitchingUser;
        private DevComponents.DotNetBar.ButtonItem btnSetUserParameter;
        private DevComponents.DotNetBar.ButtonItem btnSetPwd;
        private DevComponents.DotNetBar.ButtonItem btnExit;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.SuperTabControl tabMain;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tabItemProclamation;
        private DevComponents.DotNetBar.LabelX lblUser;
        private DevComponents.DotNetBar.LabelX lblDept;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxClinic;
        private DevComponents.DotNetBar.ButtonItem btnDoctorInfo;
    }
}