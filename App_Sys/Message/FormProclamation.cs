using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using CIS.Utility;
using CIS.Model;

namespace App_Sys
{
    public partial class Proclamation : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Proclamation()
        {
            InitializeComponent();
        }
        string Context;
        string path;
        DataTable dt;
        List<ProclamationModel> list = new List<ProclamationModel>();

        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);

        private void Proclamation_Shown(object sender, EventArgs e)
        {
            string sql = "SELECT TOP 1 * FROM MZYS_MSG ORDER BY TIME DESC";
            dt = DBHelper.CIS.FromSql(sql).ToDataTable();
            if (dt.Rows.Count == 0)
            {
                this.Close();
                return;
            }
            Context = dt.Rows[0]["RTFContext"].ToString();
            path = System.IO.Directory.GetParent(Application.StartupPath).FullName;
            if (System.IO.File.Exists(path + @"\Msg.dat"))
            {
                string tmp = System.IO.File.ReadAllText(path + @"\Msg.dat", Encoding.Default);
                if (!CheckRead() && CheckStatus())
                {
                    this.richTextBox1.Rtf = Context;
                    this.lblTitle.Text = dt.Rows[0]["Title"].ToString();
                    this.lblTime.Text = "发布时间：" + GetTime();
                    this.Opacity = 1;
                }
                else
                {
                    this.Close();
                    return;
                }
            }
            this.richTextBox1.Rtf = Context;
            this.lblTitle.Text = dt.Rows[0]["Title"].ToString();
            this.lblTime.Text = "发布时间：" + GetTime();
            this.Opacity = 1;
        }

        /// <summary>
        /// false为没读,true为读过
        /// </summary>
        /// <returns></returns>
        private bool CheckRead()
        {
            string ReadText = System.IO.File.ReadAllText(path + @"\Msg.dat", Encoding.Default);
            if (ReadText == "")
                return false;
            else
            {
                list = SerializeHelper.BeginJsonDeserialize<List<ProclamationModel>>(ReadText);
                foreach (ProclamationModel item in list)
                {
                    if (item.GH == CIS.Core.SysContext.CurrUser.user.ID)
                    {
                        if (item.Time == dt.Rows[0]["Time"].ToString())
                            return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// false为停用,true为启用
        /// </summary>
        /// <returns></returns>
        private bool CheckStatus()
        {
            if (dt.Rows[0]["Status"].ToString() == "0")
                return true;
            else
                return false;
        }

        private string GetTime()
        {
            DateTime time = Convert.ToDateTime(dt.Rows[0]["Time"]);
            TimeSpan ts = DateTime.Now.Subtract(time);
            if (ts.TotalMinutes < 5)
                return "刚刚";
            else if (ts.TotalMinutes < 60)
                return Convert.ToInt32(ts.TotalMinutes) + "分钟前";
            else if (ts.TotalMinutes < 720)
                return Convert.ToInt32(ts.TotalHours) + "小时前";
            else
                return Convert.ToInt32(ts.TotalDays) + "天前";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string str = this.richTextBox1.Rtf;
            this.Close();
        }

        private void Proclamation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dt.Rows.Count != 0 && CheckStatus())
            {
                foreach (ProclamationModel item in list)
                {
                    if (item.GH == CIS.Core.SysContext.CurrUser.user.ID)
                    {
                        item.Time = dt.Rows[0]["Time"].ToString();
                        string tmp = SerializeHelper.BeginJsonSerializable(list);
                        System.IO.File.WriteAllText(path + @"\Msg.dat", tmp, Encoding.Default);
                        return;
                    }
                }
                ProclamationModel tmp1 = new ProclamationModel();
                tmp1.GH = CIS.Core.SysContext.CurrUser.user.ID;
                tmp1.Time = dt.Rows[0]["Time"].ToString();
                list.Add(tmp1);
                string str = SerializeHelper.BeginJsonSerializable(list);
                System.IO.File.WriteAllText(path + @"\Msg.dat", str, Encoding.Default);
            }

        }

        private void Proclamation_Load(object sender, EventArgs e)
        {
            this.richTextBox1.GotFocus += richTextBox1_GotFocus;
        }

        void richTextBox1_GotFocus(object sender, EventArgs e)
        {
            HideCaret(this.richTextBox1.Handle);
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(this.richTextBox1.Handle);
        }
    }
}
