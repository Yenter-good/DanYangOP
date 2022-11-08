namespace App_Sys
{
    partial class FormAddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddUser));
            this.input_Pwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.input_Type = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.input_JobTitle = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.input_Name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbxUserCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.input_Code = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.input_EducationaBackground = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.input_Feature = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.input_Introduction = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.input_IDCard = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.input_Dept_Code = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.input_Birthday = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.input_Sex = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnAddOrUpdate = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_Birthday)).BeginInit();
            this.SuspendLayout();
            // 
            // input_Pwd
            // 
            // 
            // 
            // 
            this.input_Pwd.Border.Class = "TextBoxBorder";
            this.input_Pwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Pwd.Location = new System.Drawing.Point(256, 43);
            this.input_Pwd.Name = "input_Pwd";
            this.input_Pwd.PreventEnterBeep = true;
            this.input_Pwd.Size = new System.Drawing.Size(100, 21);
            this.input_Pwd.TabIndex = 2;
            this.input_Pwd.WatermarkColor = System.Drawing.Color.Gray;
            this.input_Pwd.WatermarkText = "输入用户密码";
            // 
            // input_Type
            // 
            this.input_Type.DisplayMember = "Value";
            this.input_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.input_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_Type.FormattingEnabled = true;
            this.input_Type.ItemHeight = 16;
            this.input_Type.Location = new System.Drawing.Point(379, 43);
            this.input_Type.Name = "input_Type";
            this.input_Type.Size = new System.Drawing.Size(121, 22);
            this.input_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.input_Type.TabIndex = 3;
            this.input_Type.ValueMember = "Code";
            this.input_Type.WatermarkColor = System.Drawing.Color.Gray;
            this.input_Type.WatermarkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.input_Type.WatermarkText = "选择用户类型";
            // 
            // input_JobTitle
            // 
            this.input_JobTitle.DisplayMember = "Value";
            this.input_JobTitle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.input_JobTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_JobTitle.FormattingEnabled = true;
            this.input_JobTitle.ItemHeight = 16;
            this.input_JobTitle.Location = new System.Drawing.Point(523, 43);
            this.input_JobTitle.Name = "input_JobTitle";
            this.input_JobTitle.Size = new System.Drawing.Size(121, 22);
            this.input_JobTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.input_JobTitle.TabIndex = 4;
            this.input_JobTitle.ValueMember = "Code";
            this.input_JobTitle.WatermarkColor = System.Drawing.Color.Gray;
            this.input_JobTitle.WatermarkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.input_JobTitle.WatermarkText = "选择用户职称";
            // 
            // input_Name
            // 
            // 
            // 
            // 
            this.input_Name.Border.Class = "TextBoxBorder";
            this.input_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Name.Location = new System.Drawing.Point(133, 43);
            this.input_Name.Name = "input_Name";
            this.input_Name.PreventEnterBeep = true;
            this.input_Name.Size = new System.Drawing.Size(100, 21);
            this.input_Name.TabIndex = 1;
            this.input_Name.WatermarkColor = System.Drawing.Color.Gray;
            this.input_Name.WatermarkText = "输入用户名称";
            // 
            // tbxUserCode
            // 
            // 
            // 
            // 
            this.tbxUserCode.Border.Class = "TextBoxBorder";
            this.tbxUserCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxUserCode.Location = new System.Drawing.Point(-98, 153);
            this.tbxUserCode.Name = "tbxUserCode";
            this.tbxUserCode.PreventEnterBeep = true;
            this.tbxUserCode.Size = new System.Drawing.Size(100, 21);
            this.tbxUserCode.TabIndex = 7;
            this.tbxUserCode.WatermarkText = "输入用户编码";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelX9);
            this.groupBox1.Controls.Add(this.input_Code);
            this.groupBox1.Controls.Add(this.labelX5);
            this.groupBox1.Controls.Add(this.labelX6);
            this.groupBox1.Controls.Add(this.labelX7);
            this.groupBox1.Controls.Add(this.labelX8);
            this.groupBox1.Controls.Add(this.input_JobTitle);
            this.groupBox1.Controls.Add(this.input_Name);
            this.groupBox1.Controls.Add(this.input_Pwd);
            this.groupBox1.Controls.Add(this.input_Type);
            this.groupBox1.Location = new System.Drawing.Point(17, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 74);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(32, 19);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(56, 18);
            this.labelX9.TabIndex = 27;
            this.labelX9.Text = "用户编码";
            // 
            // input_Code
            // 
            // 
            // 
            // 
            this.input_Code.Border.Class = "TextBoxBorder";
            this.input_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Code.Location = new System.Drawing.Point(10, 43);
            this.input_Code.Name = "input_Code";
            this.input_Code.PreventEnterBeep = true;
            this.input_Code.Size = new System.Drawing.Size(100, 21);
            this.input_Code.TabIndex = 0;
            this.input_Code.WatermarkColor = System.Drawing.Color.Gray;
            this.input_Code.WatermarkText = "输入用户编码";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(557, 19);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(56, 18);
            this.labelX5.TabIndex = 25;
            this.labelX5.Text = "用户职称";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(413, 19);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(56, 18);
            this.labelX6.TabIndex = 24;
            this.labelX6.Text = "用户类型";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(290, 19);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(31, 18);
            this.labelX7.TabIndex = 23;
            this.labelX7.Text = "密码";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(166, 19);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(31, 18);
            this.labelX8.TabIndex = 22;
            this.labelX8.Text = "姓名";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelX10);
            this.groupBox2.Controls.Add(this.labelX4);
            this.groupBox2.Controls.Add(this.input_EducationaBackground);
            this.groupBox2.Controls.Add(this.input_Feature);
            this.groupBox2.Controls.Add(this.input_Introduction);
            this.groupBox2.Controls.Add(this.input_IDCard);
            this.groupBox2.Controls.Add(this.labelX3);
            this.groupBox2.Controls.Add(this.input_Dept_Code);
            this.groupBox2.Controls.Add(this.labelX2);
            this.groupBox2.Controls.Add(this.labelX1);
            this.groupBox2.Controls.Add(this.input_Birthday);
            this.groupBox2.Controls.Add(this.input_Sex);
            this.groupBox2.Location = new System.Drawing.Point(17, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(655, 209);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详细信息";
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(557, 20);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(56, 18);
            this.labelX10.TabIndex = 22;
            this.labelX10.Text = "身份证号";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(413, 20);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(31, 18);
            this.labelX4.TabIndex = 21;
            this.labelX4.Text = "学历";
            // 
            // input_EducationaBackground
            // 
            this.input_EducationaBackground.DisplayMember = "Value";
            this.input_EducationaBackground.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.input_EducationaBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_EducationaBackground.FormattingEnabled = true;
            this.input_EducationaBackground.ItemHeight = 16;
            this.input_EducationaBackground.Location = new System.Drawing.Point(379, 44);
            this.input_EducationaBackground.Name = "input_EducationaBackground";
            this.input_EducationaBackground.Size = new System.Drawing.Size(121, 22);
            this.input_EducationaBackground.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.input_EducationaBackground.TabIndex = 8;
            this.input_EducationaBackground.ValueMember = "Code";
            this.input_EducationaBackground.WatermarkColor = System.Drawing.Color.Gray;
            this.input_EducationaBackground.WatermarkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.input_EducationaBackground.WatermarkText = "选择学历";
            // 
            // input_Feature
            // 
            // 
            // 
            // 
            this.input_Feature.Border.Class = "TextBoxBorder";
            this.input_Feature.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Feature.Location = new System.Drawing.Point(9, 154);
            this.input_Feature.Multiline = true;
            this.input_Feature.Name = "input_Feature";
            this.input_Feature.PreventEnterBeep = true;
            this.input_Feature.Size = new System.Drawing.Size(639, 33);
            this.input_Feature.TabIndex = 11;
            this.input_Feature.WatermarkColor = System.Drawing.Color.Gray;
            this.input_Feature.WatermarkText = "输入人员特长";
            // 
            // input_Introduction
            // 
            // 
            // 
            // 
            this.input_Introduction.Border.Class = "TextBoxBorder";
            this.input_Introduction.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Introduction.Location = new System.Drawing.Point(9, 85);
            this.input_Introduction.Multiline = true;
            this.input_Introduction.Name = "input_Introduction";
            this.input_Introduction.PreventEnterBeep = true;
            this.input_Introduction.Size = new System.Drawing.Size(639, 54);
            this.input_Introduction.TabIndex = 10;
            this.input_Introduction.WatermarkColor = System.Drawing.Color.Gray;
            this.input_Introduction.WatermarkText = "输入人员介绍";
            // 
            // input_IDCard
            // 
            // 
            // 
            // 
            this.input_IDCard.Border.Class = "TextBoxBorder";
            this.input_IDCard.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_IDCard.Location = new System.Drawing.Point(523, 44);
            this.input_IDCard.MaxLength = 18;
            this.input_IDCard.Name = "input_IDCard";
            this.input_IDCard.PreventEnterBeep = true;
            this.input_IDCard.Size = new System.Drawing.Size(126, 21);
            this.input_IDCard.TabIndex = 9;
            this.input_IDCard.WatermarkColor = System.Drawing.Color.Gray;
            this.input_IDCard.WatermarkText = "输入身份证号";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(265, 20);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 18);
            this.labelX3.TabIndex = 16;
            this.labelX3.Text = "所属科室";
            // 
            // input_Dept_Code
            // 
            this.input_Dept_Code.DisplayMember = "Name";
            this.input_Dept_Code.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.input_Dept_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_Dept_Code.FormattingEnabled = true;
            this.input_Dept_Code.ItemHeight = 16;
            this.input_Dept_Code.Location = new System.Drawing.Point(230, 44);
            this.input_Dept_Code.Name = "input_Dept_Code";
            this.input_Dept_Code.Size = new System.Drawing.Size(126, 22);
            this.input_Dept_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.input_Dept_Code.TabIndex = 7;
            this.input_Dept_Code.ValueMember = "Code";
            this.input_Dept_Code.WatermarkColor = System.Drawing.Color.Gray;
            this.input_Dept_Code.WatermarkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.input_Dept_Code.WatermarkText = "选择科室";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(143, 20);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(31, 18);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "生日";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(32, 20);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(31, 18);
            this.labelX1.TabIndex = 13;
            this.labelX1.Text = "性别";
            // 
            // input_Birthday
            // 
            // 
            // 
            // 
            this.input_Birthday.BackgroundStyle.Class = "DateTimeInputBackground";
            this.input_Birthday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Birthday.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.input_Birthday.ButtonDropDown.Visible = true;
            this.input_Birthday.IsPopupCalendarOpen = false;
            this.input_Birthday.Location = new System.Drawing.Point(108, 44);
            // 
            // 
            // 
            // 
            // 
            // 
            this.input_Birthday.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Birthday.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.input_Birthday.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.input_Birthday.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.input_Birthday.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.input_Birthday.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.input_Birthday.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.input_Birthday.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.input_Birthday.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.input_Birthday.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Birthday.MonthCalendar.DisplayMonth = new System.DateTime(2016, 8, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.input_Birthday.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.input_Birthday.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.input_Birthday.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.input_Birthday.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Birthday.MonthCalendar.TodayButtonVisible = true;
            this.input_Birthday.Name = "input_Birthday";
            this.input_Birthday.Size = new System.Drawing.Size(100, 21);
            this.input_Birthday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.input_Birthday.TabIndex = 6;
            this.input_Birthday.WatermarkText = "选择生日";
            // 
            // input_Sex
            // 
            this.input_Sex.DisplayMember = "Value";
            this.input_Sex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.input_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_Sex.FormattingEnabled = true;
            this.input_Sex.ItemHeight = 16;
            this.input_Sex.Location = new System.Drawing.Point(10, 44);
            this.input_Sex.Name = "input_Sex";
            this.input_Sex.Size = new System.Drawing.Size(78, 22);
            this.input_Sex.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.input_Sex.TabIndex = 5;
            this.input_Sex.ValueMember = "Code";
            this.input_Sex.WatermarkColor = System.Drawing.Color.Gray;
            this.input_Sex.WatermarkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.input_Sex.WatermarkText = "选择性别";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(597, 340);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddOrUpdate
            // 
            this.btnAddOrUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddOrUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOrUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddOrUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOrUpdate.Image")));
            this.btnAddOrUpdate.Location = new System.Drawing.Point(506, 340);
            this.btnAddOrUpdate.Name = "btnAddOrUpdate";
            this.btnAddOrUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnAddOrUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddOrUpdate.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnAddOrUpdate.TabIndex = 12;
            this.btnAddOrUpdate.Text = "保存";
            this.btnAddOrUpdate.Click += new System.EventHandler(this.btnAddOrUpdate_Click);
            // 
            // FormAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(681, 381);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddOrUpdate);
            this.Controls.Add(this.tbxUserCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddUser";
            this.Shown += new System.EventHandler(this.FormAddUser_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_Birthday)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX input_Pwd;
        private DevComponents.DotNetBar.Controls.ComboBoxEx input_Type;
        private DevComponents.DotNetBar.Controls.ComboBoxEx input_JobTitle;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Name;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxUserCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput input_Birthday;
        private DevComponents.DotNetBar.Controls.ComboBoxEx input_Sex;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx input_EducationaBackground;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Feature;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Introduction;
        private DevComponents.DotNetBar.Controls.TextBoxX input_IDCard;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx input_Dept_Code;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        public DevComponents.DotNetBar.ButtonX btnAddOrUpdate;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Code;
        private DevComponents.DotNetBar.LabelX labelX10;
    }
}