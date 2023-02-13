using CIS.Core;
using CIS.Model;
using CIS.Utility;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CIS
{
    public partial class FormMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        [DllImport("CRMS_UI.dll", EntryPoint = "CRMS_UI")]
        public static extern int CRMS_UI(uint nMsg, string strBaseXml, string strDetailsXml, ref string strResults);

        [DllImport("kernel32.dll")]
        private static extern bool SetLocalTime(ref Systemtime time);
        [StructLayout(LayoutKind.Sequential)]
        private struct Systemtime
        {
            public short year;
            public short month;
            public short dayOfWeek;
            public short day;
            public short hour;
            public short minute;
            public short second;
            public short milliseconds;
        }

        //窗体打开模式
        public const string Sys_Form_OpenStyle_Model = "Model";
        public const string Sys_Form_OpenStyle_Dialog = "Dialog";
        public const string Sys_Form_OpenStyle_Tab = "Tab";
        public const string Sys_Form_OpenStyle_URL = "URL";
        public const string Sys_Form_OpenStyle_Method = "Method";
        bool FirstStart = true;

        #region 全局交互事件

        //主系统页面加载操作
        private void FormMain_Load(object sender, EventArgs e)
        {
            //Login form = new Login();
            //if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    this.Opacity = 1;
            //else
            //    this.Close();
            //this.ShowInTaskbar = true;
            InitUI();
        }

        private void SwitchApp(Sys_App app)
        {
            if (SysContext.SwitchSystem(app.Code))
            {
                this.epanlLeft.TitleText = app.Name;
                this.ebarMain.Groups.Clear();
                if (this.cbxDept.DataSource == null)
                {
                    this.cbxDept.DataSource = SysContext.CurrUser.deptList;
                }

                Application.DoEvents();
                CrateLeftMenu(SysContext.RunSysInfo.currAppMenuList);
                lblDept.Text = "科室：" + cbxDept.Text.ToString();
                this.ebarMain.Refresh();
            }
        }

        //切换科室
        private void cbxDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDept.Text.Trim() == "")
            {
                return;
            }

            SysContext.RunSysInfo.clinic = null;
            if (!FirstStart)
            {
                if (tabMain.Tabs.Count > 1)
                {
                    if (MsgBox.OKCancel("选择‘是’将关闭所有选项卡页面 如果有未完成的工作请先保存后再切换科室") == DialogResult.OK)
                    {
                        this.CloseAllDocuments();
                        this.epanlLeft.Expanded = true;
                    }
                }
            }
            else
            {
                FirstStart = false;
            }

            string deptCode = this.cbxDept.SelectedValue.ToString();
            List<IView_Dept> deptList = SysContext.CurrUser.deptList.Where(x => x.Code == deptCode).ToList<IView_Dept>();
            List<Clinic> tmp = SysContext.Clinic.Where(p => p.DeptCode == deptCode).ToList();
            tmp.Insert(0, new Clinic() { ClinicName = "" });
            this.cbxClinic.DataSource = tmp;
            if (deptList.Count > 0)
            {
                SysContext.RunSysInfo.currDept = deptList[0];
                lblDept.Text = "科室：" + cbxDept.Text.ToString();
            }
        }

        private void cbxClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            //HMSocket.SocketClient HMSocket = new HMSocket.SocketClient();
            if (this.cbxClinic.SelectedValue != null)
            {
                string ClinicCode = this.cbxClinic.SelectedValue.ToString();
                List<Clinic> tmp = SysContext.Clinic.Where(p => p.ClinicCode == ClinicCode).ToList();
                if (tmp.Count > 0)
                {
                    string str = string.Format("P|{0}|{1}|{2}|{3}||||{4}", SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, tmp[0].ClinicCode, SysContext.RunSysInfo.currDept.Name, tmp[0].ClinicName);
                    LogHelper.Debug("排队叫号接口登录：" + str, "排队叫号接口", new System.IO.DirectoryInfo(Application.StartupPath).Parent.FullName + @"\门诊医生Log\");
                    if (SysContext.HMSocket.InsertData(tmp[0].ClinicCode, str) != 1)
                    {
                        AlertBox.Error("排队叫号诊区信息登录失败,请重新选择诊区");
                        return;
                    }
                    SysContext.RunSysInfo.clinic = tmp[0];
                }
            }
        }

        #endregion 全局交互事件

        #region 初始化界面

        private void InitUI()
        {
            this.cbxDept.DisplayMember = "Name";
            this.cbxDept.ValueMember = "Code";
            this.cbxClinic.DisplayMember = "ClinicName";
            this.cbxClinic.ValueMember = "ClinicCode";
            this.btnUserSet.Text = "当前用户：" + SysContext.CurrUser.user.Name + $"({SysContext.CurrUser.user.HealthCareCode})";
            CreateAppButton(SysContext.CurrUser.appList);
            if (SysContext.CurrUser.appList.Count == 0 || SysContext.CurrUser.menuList.Count == 0 || SysContext.CurrUser.roleList.Count == 0)
            {
                AlertBox.Error("用户信息加载错误请联系管理员");
                return;
            }
            if (!string.IsNullOrWhiteSpace(SysContext.CurrUser.Params.Sys_DefaultAppCode))//如果用户设置了默认APP 则加载APP相关信息
            {
                List<Sys_App> temApp = SysContext.CurrUser.appList.Where<Sys_App>(x => x.Code == SysContext.CurrUser.Params.Sys_DefaultAppCode).ToList();
                Sys_App defaultApp = temApp[0];
                SwitchApp(defaultApp);
            }
            this.cbxDept.DataSource = SysContext.CurrUser.deptList;

            lblDept.Text = "科室：" + cbxDept.Text.ToString();
            lblUser.Text = "用户：" + SysContext.CurrUser.user.Name.ToString();

            if (SysContext.CurrUser.Params.OP_AutoCalibrationTime == "否")
            {
                return;
            }

            DateTime dt = DBHelper.CIS.FromSql("SELECT GETDATE()").ToScalar<DateTime>();
            Systemtime st = new Systemtime();
            st.year = (short)dt.Year;
            st.month = (short)dt.Month;
            st.dayOfWeek = (short)dt.DayOfWeek;
            st.day = (short)dt.Day;
            st.hour = (short)dt.Hour;
            st.minute = (short)dt.Minute;
            st.second = (short)dt.Second;
            st.milliseconds = (short)dt.Millisecond;
            SetLocalTime(ref st);

        }


        //创建该用户所拥有的系统模块
        private void CreateAppButton(List<Sys_App> appList)
        {
            foreach (Sys_App app in appList)
            {
                ButtonItem item = new ButtonItem();
                item.Text = app.Name;
                item.Tag = app;
                item.Click += new EventHandler(AppBtnItemClick);
                try
                {
                    item.ImageIndex = Convert.ToInt32(app.IconCls);
                }
                catch { }
                this.AppButtonMain.SubItems.Add(item);
            }
        }

        /// <summary>
        /// 创建左侧菜单组
        /// </summary>
        /// <param name="menuList"></param>
        private void CrateLeftMenu(List<Sys_Menu> menuList)
        {
            this.ebarMain.Images = this.imageList;
            this.ebarMain.GroupImages = this.imageList;
            if (menuList.Count < 1)
            {
                return;
            }
            List<Sys_Menu> groupMenus = menuList.Where(x => x.MenuPCode == "0").ToList<Sys_Menu>();
            if (groupMenus.Count == 0)  //递归终止，区域不包含子区域时
            {
                return;
            }

            foreach (Sys_Menu menu in groupMenus)
            {
                ExplorerBarGroupItem group = new ExplorerBarGroupItem();
                group.Name = "ebarGroup" + menu.MenuCode;
                group.Text = menu.Text;
                group.SetDefaultAppearance();
                group.Expanded = true;
                try
                {
                    if (!string.IsNullOrWhiteSpace(menu.IconCls))
                    {
                        group.ImageIndex = Convert.ToInt32(menu.IconCls);
                    }
                }
                catch { }

                this.ebarMain.Groups.Add(group);
                CreateChildsButton(group, menu.MenuCode, menuList);

            }
        }

        /// <summary>
        /// 创建左侧菜单组子菜单
        /// </summary>
        /// <param name="MenuCode">父节点ID</param>
        /// <param name="menuList">数据</param>
        public void CreateChildsButton(ExplorerBarGroupItem group, String MenuCode, List<Sys_Menu> menuList)
        {
            List<Sys_Menu> menus = menuList.Where(x => x.MenuPCode == MenuCode).ToList<Sys_Menu>();
            if (menus.Count == 0)  //递归终止，区域不包含子区域时
            {
                return;
            }

            foreach (Sys_Menu menu in menus)
            {
                ButtonItem btn = new ButtonItem();
                btn.Name = "btnItem" + menu.MenuCode;
                btn.Text = menu.Text;
                btn.HotFontUnderline = true;
                btn.ForeColor = Color.Black;
                //btn.FontBold = true;
                btn.HotTrackingStyle = eHotTrackingStyle.None;
                btn.ImagePosition = eImagePosition.Left;
                btn.ButtonStyle = eButtonStyle.ImageAndText;
                btn.Cursor = Cursors.Hand;
                btn.Tag = menu;
                btn.Click += new EventHandler(BtnItemClick);
                try
                {
                    if (!string.IsNullOrWhiteSpace(menu.IconCls))
                    {
                        btn.ImageIndex = Convert.ToInt32(menu.IconCls);
                    }
                }
                catch { }
                group.SubItems.Add(btn);
                if (menu.FName == "App_OP.FormMain")
                {
                    BtnItemClick(new ButtonItem() { Tag = menu }, null);
                }
            }


        }

        // 菜单按钮单击事件
        private void BtnItemClick(object sender, EventArgs e)
        {
            ButtonItem btn = (ButtonItem)sender;
            Sys_Menu menu = (Sys_Menu)btn.Tag;
            string openStyle = menu.OpenStyle;
            if (openStyle != Sys_Form_OpenStyle_Method && openStyle != Sys_Form_OpenStyle_URL && openStyle != Sys_Form_OpenStyle_Tab && openStyle != Sys_Form_OpenStyle_Dialog && openStyle != Sys_Form_OpenStyle_Model)
            {
                MsgBox.OK("该功能显示模式定义错误 请联系管理员");
                return;
            }

            if (openStyle == Sys_Form_OpenStyle_Method)
            {
                string[] str = menu.FName.Split('_');
                Assembly a = Assembly.Load(menu.RNO);
                Type t = a.GetType(menu.RNO + "." + str[0]);
                t.RunFunction(str[1], new object[] { });
                return;
            }

            Form form = SysContext.CreateForm(menu);

            if (form == null)
            {
                return;
            }

            if (openStyle == Sys_Form_OpenStyle_Model)//以模态窗口打开窗体
            {
                ShowDialog(menu.Text, form);
            }

            if (openStyle == Sys_Form_OpenStyle_Tab)//以Tab页模式打开窗体
            {
                ShowTab(menu.Text, form);
            }

            if (openStyle == Sys_Form_OpenStyle_Dialog)//以对话框模式打开窗体
            {
                ShowForm(menu.Text, form);
            }

            Application.DoEvents();
            this.Invalidate();
            this.Refresh();
        }

        //系统按钮单击事件
        private void AppBtnItemClick(object sender, EventArgs e)
        {
            ButtonItem btn = (ButtonItem)sender;
            Sys_App app = (Sys_App)btn.Tag;
            try
            {
                SwitchApp(app);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 创建一个模态窗口(Model 页)
        /// </summary>
        /// <param name="caption">对话框标题名称</param>
        /// <param name="formType">要显示的窗体内容</param>
        public void ShowDialog(string caption, Control formType)
        {
            Form form = formType as Form;
            form.ShowDialog();
        }

        /// <summary>
        /// 创建或者显示一个多文档界面页面(Tab 页)
        /// </summary>
        /// <param name="caption">对话框标题名称</param>
        /// <param name="formType">要显示的窗体内容</param>
        public void ShowTab(string caption, Control formType)
        {
            bool IsOpened = false;

            //遍历现有的Tab页面，如果存在，那么设置为选中即可
            foreach (SuperTabItem tabitem in tabMain.Tabs)
            {
                if (tabitem.Name == caption)
                {
                    tabMain.SelectedTab = tabitem;
                    IsOpened = true;
                    break;
                }
            }

            //如果在现有Tab页面中没有找到，那么就要初始化了Tab页面了
            if (!IsOpened)
            {
                Form form = formType as Form;
                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.Visible = true;
                form.Dock = DockStyle.Fill;
                SuperTabItem tabItem = tabMain.CreateTab(caption);
                tabItem.Name = caption;
                tabItem.Text = caption;
                tabItem.CloseButtonVisible = true;
                tabItem.AttachedControl.Controls.Add(form);
                tabMain.SelectedTab = tabItem;
            }

            this.epanlLeft.Expanded = false;
        }

        /// <summary>
        /// 创建或者显示一个普通窗体(Form页)
        /// </summary>
        /// <param name="caption">对话框标题名称</param>
        /// <param name="formType">要显示的窗体内容</param>
        public void ShowForm(string caption, Control formType)
        {
            bool isShow = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == caption)
                {
                    isShow = true;
                    f.Activate();
                    break;
                }
            }

            if (!isShow)
            {
                Form form = formType as Form;
                form.Show();
            }
        }

        private void closeAllTabMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllDocuments();
        }

        private void closeOthersMenuItem_Click(object sender, EventArgs e)
        {
            CloseOthers();
        }

        /// <summary>
        /// 关闭所有tab页
        /// </summary>
        private void CloseAllDocuments()
        {
            for (int i = tabMain.Tabs.Count - 1; i >= 0; i--)
            {
                SuperTabItem tabitem = tabMain.Tabs[i] as SuperTabItem;
                if (tabitem != null && tabitem.CloseButtonVisible == true)
                {
                    tabitem.Close();
                }
            }
        }

        /// <summary>
        /// 关闭其他tab 页（除了当前显示的页面）
        /// </summary>
        private void CloseOthers()
        {
            if (tabMain.Tabs.Count > 1)
            {
                for (int i = tabMain.Tabs.Count - 1; i >= 0; i--)
                {
                    SuperTabItem tabitem = tabMain.Tabs[i] as SuperTabItem;
                    if (tabitem != null && tabitem != tabMain.SelectedTab && tabitem.CloseButtonVisible == true)
                    {
                        tabitem.Close();
                    }
                }
            }
        }

        #endregion 初始化界面

        #region 通用功能

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUserSet_Click(object sender, EventArgs e)
        {
            this.btnUserSet.Expanded = true;
        }

        #endregion 通用功能

        #region 窗口事件
        private void btnSetUserParameter_Click(object sender, EventArgs e)
        {
            FormUserParameterSet form = new FormUserParameterSet();
            form.ShowDialog();
        }

        private void btnSwitchingUser_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            Login form = new Login();
            this.AppButtonMain.SubItems.Clear();
            FirstStart = true;
            CloseAllDocuments();
            this.Opacity = 0;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Opacity = 1;
            }
            else
            {
                this.Close();
            }

            this.ShowInTaskbar = true;
            InitUI();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            this.btnUserSet.Left = this.ribbonPanel1.Width - this.btnUserSet.Width - 10;

            this.cbxClinic.Left = this.btnUserSet.Left - this.cbxClinic.Width - 10;
            this.labelX2.Left = this.cbxClinic.Left - this.labelX2.Width;

            this.cbxDept.Left = this.labelX2.Left - this.cbxDept.Width - 10;
            this.labelX1.Left = this.cbxDept.Left - this.labelX1.Width;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (SuperTabItem item in this.tabMain.Tabs)
            {
                if (item.AttachedControl.Controls.Count == 0)
                    continue;
                var control = item.AttachedControl.Controls[0];
                if (control is BaseForm baseForm)
                    baseForm.OnClose();
            }

            var dtNow = DBHelper.ServerTime;
            if (!DBHelper.CIS.Exists<OP_Log_InOut>(p => p.UserCode == SysContext.CurrUser.user.Code && p.OperationDate == dtNow.Date && p.OperationType == 1))
            {
                OP_Log_InOut log = new OP_Log_InOut();
                log.UserCode = SysContext.CurrUser.user.Code;
                log.OperationDate = dtNow.Date;
                log.OperationTime = dtNow;
                log.OperationType = 1;
                log.IP = SysContext.ClientIP;

                DBHelper.CIS.Insert(log);
            }


            if (SysContext.UserPositionSetting == null)
            {
                return;
            }

            string json = SysContext.UserPositionSetting.BeginJsonSerializable();
            DBHelper.CIS.Delete<Sys_UserParameter_Value>(p => p.ParameterCode == "U009" && p.UserID == SysContext.CurrUser.user.Code);
            Sys_UserParameter_Value value = new Sys_UserParameter_Value();
            value.ParameterCode = "U009";
            value.ParameterValue = json;
            value.UserID = SysContext.CurrUser.user.Code;
            DBHelper.CIS.Insert<Sys_UserParameter_Value>(value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string publicXML = Purview.Purview.GetRationalUsePublicArgs(SysContext.CurrUser.user, SysContext.RunSysInfo.currDept, "1243");
            string result = "";
            //Purview.Purview.CRMS_UI(2, publicXML, "<details_xml></details_xml>", ref result);
            int str = CRMS_UI(1, publicXML, string.Format("<details_xml><doct_pwd>{0}</doct_pwd></details_xml>", SysContext.CurrUser.user.Pwd), ref result);
            //这里就是调用接口  1是登录
        }

        private void btnSetPwd_Click(object sender, EventArgs e)
        {
            FormEditPwd form = new FormEditPwd();
            form.ShowDialog();
        }

        private void btnDoctorInfo_Click(object sender, EventArgs e)
        {
            App_OP.FormDoctorInfo form = new App_OP.FormDoctorInfo();
            form.ShowDialog();
        }
        #endregion

        private void tabMain_TabRemoved(object sender, SuperTabStripTabRemovedEventArgs e)
        {
            var tab = e.Tab as SuperTabItem;
            if (tab.AttachedControl.Controls.Count > 0)
            {
                if (tab.AttachedControl.Controls[0] is BaseForm baseForm)
                    baseForm.OnClose();
            }
        }
    }
}