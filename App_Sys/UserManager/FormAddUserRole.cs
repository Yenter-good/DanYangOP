using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using CIS.Model;
using System.Windows.Forms;

namespace App_Sys
{
    public partial class FormAddUserRole : DevComponents.DotNetBar.Office2007RibbonForm
    {
        List<Sys_Role> role;
        List<Sys_User_Role> user_role;
        List<PictureBox> Pic = new List<PictureBox>();
        public string userID;

        struct MyStruct
        {
            public bool Select;
            public Sys_Role role;
        }
        public FormAddUserRole()
        {
            InitializeComponent();
            this.ControlBox = false;
            //this.groupPanel1.MouseWheel += groupBox1_MouseWheel;
            this.groupPanel1.MouseEnter += groupBox1_MouseEnter;
        }

        void groupBox1_MouseEnter(object sender, EventArgs e)
        {
            this.groupPanel1.Focus();
        }

        void groupBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (Pic[0].Top >= 20)
                    return;
                foreach (PictureBox item in Pic)
                    item.Top += 5;
            }
            else
            {
                if (Pic[Pic.Count - 1].Top <= this.groupPanel1.Height - 70)
                    return;
                foreach (PictureBox item in Pic)
                    item.Top -= 5;
            }
        }

        private void FormAddUserRole_Load(object sender, EventArgs e)
        {

        }

        private void InitData()
        {
            role = DBHelper.CIS.From<Sys_Role>().ToList();
            user_role = DBHelper.CIS.From<Sys_User_Role>().Where(p => p.UserID == userID).ToList();
        }

        private void InitUI()
        {
            this.groupPanel1.SuspendLayout();
            int Top = -50;
            int Left = -100;
            Graphics g;
            for (int i = 0; i < role.Count; i++)
            {
                MyStruct stru = new MyStruct();
                PictureBox p = new PictureBox();
                if (i % 4 == 0)
                {
                    Left = -100;
                    Top += 70;
                }
                Left += 130;
                p.Location = new Point(Left, Top);
                p.Size = new Size(100, 50);
                Bitmap b = new Bitmap(100, 50);
                g = Graphics.FromImage(b);
                g.Clear(Color.FromArgb(135, 207, 235));
                g.DrawString(role[i].Name, new Font("宋体", 12), Brushes.Black, new Point(5, 15));

                if (user_role.Where(pp => pp.RoleCode == role[i].Code).ToList().Count > 0)
                {
                    g.DrawImage(Properties.Resources._1, new Rectangle(new Point(0, 0), new Size(100, 50)));
                    stru.Select = true;
                }
                this.groupPanel1.Controls.Add(p);
                p.Image = b.Clone() as Bitmap;
                stru.role = role[i];
                p.Tag = stru;
                p.Click += p_Click;
                Pic.Add(p);
            }
            try
            {
                if (Pic[Pic.Count - 1].Top + Pic[Pic.Count - 1].Height > this.groupPanel1.Height)
                {
                    int Scroll = this.groupPanel1.Bounds.Width - this.groupPanel1.ClientRectangle.Width;
                    foreach (PictureBox item in Pic)
                        item.Left -= Scroll;
                }
            }
            catch
            {
            }

            this.groupPanel1.ResumeLayout();
        }

        void p_Click(object sender, EventArgs e)
        {
            MyStruct s = (MyStruct)(sender as PictureBox).Tag;
            Bitmap b = new Bitmap(100, 50);
            Graphics g = Graphics.FromImage(b);
            g.Clear(Color.FromArgb(135, 207, 235));
            g.DrawString(s.role.Name, new Font("宋体", 12), Brushes.Black, new Point(5, 15));
            s.Select = !s.Select;
            if (s.Select)
                g.DrawImage(Properties.Resources._1, new Rectangle(new Point(0, 0), new Size(100, 50)));
            (sender as PictureBox).Image = b;
            (sender as PictureBox).Tag = s;

        }

        private void FormAddUserRole_Shown(object sender, EventArgs e)
        {
            InitData();
            InitUI();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DBHelper.CIS.Delete<Sys_User_Role>(p => p.UserID == userID);
            foreach (PictureBox item in Pic)
            {
                MyStruct stru = (MyStruct)item.Tag;
                if (stru.Select)
                {
                    Sys_Role tmp = stru.role;
                    Sys_User_Role user = new Sys_User_Role();
                    user.UserID = userID;
                    user.RoleCode = tmp.Code;
                    DBHelper.CIS.Insert<Sys_User_Role>(user);
                }
            }
            CIS.Core.AlertBox.Info("保存成功");
            this.Close();
        }
    }
}
