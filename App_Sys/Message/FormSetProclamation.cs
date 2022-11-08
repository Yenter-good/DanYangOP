using System;
using System.Data;
using System.Windows.Forms;
using CIS.Model;

namespace App_Sys
{
    public partial class FormSetProclamation : Form
    {
        public FormSetProclamation()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        private void FormSetProclamation_Shown(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            InitData();
        }

        private void InitData()
        {
            string sql = "SELECT TOP 20 * FROM MZYS_MSG ORDER BY TIME DESC";
            dt = DBHelper.CIS.FromSql(sql).ToDataTable();
            this.dataGridView1.DataSource = dt;
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (item.Cells["Status1"].Value.ToString() == "1")
                    item.Cells["Status"].Value = true;
                else
                    item.Cells["Status"].Value = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = this.fontDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (this.richTextBox1.SelectedText != "")
                {
                    this.richTextBox1.SelectionFont = this.fontDialog1.Font;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = this.colorDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (this.richTextBox1.SelectedText != "")
                {
                    this.richTextBox1.SelectionColor = this.colorDialog1.Color;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@TITLE", this.superText1.Text));
            //list.Add(new SqlParameter("@RTFCONTEXT", this.richTextBox1.Rtf));
            //list.Add(new SqlParameter("@TEXTCONTEXT", this.richTextBox1.Text));
            //list.Add(new SqlParameter("@TYPE", "1"));
            //list.Add(new SqlParameter("@TIME", DateTime.Now));
            //list.Add(new SqlParameter("@RELEASEPERPLE", SysInfo.currDoctor.GH));
            //list.Add(new SqlParameter("@STATUS", "0"));

            string sql = string.Format("INSERT INTO MZYS_MSG(Title,RTFContext,TextContext,Type,Time,ReleasePerple,Status) VALUES(@TITLE,@RTFCONTEXT,@TEXTCONTEXT,@TYPE,@TIME,@RELEASEPERPLE,@STATUS)");
            DBHelper.CIS.FromSql(sql).AddInParameter("@TITLE", DbType.String, this.superText1.Text == null ? (object)System.DBNull.Value : this.superText1.Text)
                .AddInParameter("@RTFCONTEXT", DbType.String, this.richTextBox1.Rtf == null ? (object)System.DBNull.Value : this.richTextBox1.Rtf)
                .AddInParameter("@TEXTCONTEXT", DbType.String, this.richTextBox1.Text == null ? (object)System.DBNull.Value : this.richTextBox1.Text)
                .AddInParameter("@TYPE", DbType.Int32, 1)
                .AddInParameter("@TIME", DbType.DateTime, DateTime.Now)
                .AddInParameter("@RELEASEPERPLE", DbType.String, CIS.Core.SysContext.CurrUser.user.ID)
                .AddInParameter("@STATUS", DbType.Int32, 0).ExecuteNonQuery();

            this.superText1.Text = "在此输入标题文本";
            this.richTextBox1.Text = "在此输入公告内容";
            CIS.Core.AlertBox.Info("保存公告成功");
            InitData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            this.superText1.Text = row.Cells["Title"].Value.ToString();
            this.richTextBox1.Rtf = row.Cells["RTFContext"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitData();
            if (this.dataGridView1.Rows.Count == 0)
            {
                CIS.Core.AlertBox.Info("当前没有公告");
                return;
            }
            else
            {
                string ID = this.dataGridView1.Rows[0].Cells["ID"].Value.ToString();
                string sql = string.Format("UPDATE MZYS_MSG SET STATUS='0' WHERE ID='{0}'", ID);
                DBHelper.CIS.FromSql(sql).ExecuteNonQuery();
            }
            InitData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitData();
            if (this.dataGridView1.Rows.Count == 0)
            {
                CIS.Core.AlertBox.Info("当前没有公告");
                return;
            }
            else
            {
                string ID = this.dataGridView1.Rows[0].Cells["ID"].Value.ToString();
                string sql = string.Format("UPDATE MZYS_MSG SET STATUS='1' WHERE ID='{0}'", ID);
                DBHelper.CIS.FromSql(sql).ExecuteNonQuery();
            }
            InitData();
        }
    }
}
