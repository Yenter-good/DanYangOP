using CIS.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CIS.Model;
using System.Linq;

namespace App_OP.UserSetting
{
    public partial class FormSettingInterval : BaseForm
    {
        public FormSettingInterval()
        {
            InitializeComponent();
        }
        #region 行拖拽
        int selectionIdx;
        //下方为鼠标拖动表格事件  
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Clicks < 2) && (e.Button == MouseButtons.Left))
            {
                dataGridViewX1.DoDragDrop(dataGridViewX1.Rows[e.RowIndex], DragDropEffects.Move);
            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            int idx = GetRowFromPoint(e.X, e.Y);

            if (idx < 0) return;

            if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
            {
                DataGridViewRow row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                selectionIdx = idx;
                dataGridViewX1.Rows.Remove(row);
                dataGridViewX1.Rows.Insert(idx, row);
                this.dataGridViewX1.ClearSelection();
                this.dataGridViewX1.CurrentCell = row.Cells[0];
            }
        }
        //添加获取行坐标方法  
        private int GetRowFromPoint(int x, int y)
        {
            for (int i = 0; i < dataGridViewX1.RowCount; i++)
            {
                Rectangle rec = dataGridViewX1.GetRowDisplayRectangle(i, false);

                if (dataGridViewX1.RectangleToScreen(rec).Contains(x, y))
                    return i;
            }

            return -1;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectionIdx = e.RowIndex;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if ((dataGridViewX1.Rows.Count > 0) && (dataGridViewX1.SelectedRows.Count > 0) && (dataGridViewX1.SelectedRows[0].Index != selectionIdx))
            //{
            //    if (dataGridViewX1.Rows.Count <= selectionIdx)
            //        selectionIdx = dataGridViewX1.Rows.Count - 1;
            //    dataGridViewX1.Rows[selectionIdx].Selected = true;
            //    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[selectionIdx].Cells[0];
            //}
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        #endregion

        private void InitData()
        {
            this.dataGridViewX1.Rows.Clear();
            List<OP_UserInterval> list = DBHelper.CIS.From<OP_UserInterval>().Where(p => p.UserID == SysContext.CurrUser.user.Code).OrderBy(p => p.No).ToList();
            if (list.Count == 0)
                list = DBHelper.CIS.From<OP_Dic_Interval>().Where(p => p.IsWesternMedicine == 0).OrderBy(p => p.Code).ToList().Select(p => new OP_UserInterval { Code = p.Code, Name = p.Name, No = 0, UserID = SysContext.CurrUser.user.Code }).ToList<OP_UserInterval>();
            foreach (OP_UserInterval item in list)
            {
                int index = this.dataGridViewX1.Rows.Add();
                this.dataGridViewX1.Rows[index].Cells[0].Value = item.Name;
                this.dataGridViewX1.Rows[index].Cells[1].Value = item.Code;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DBHelper.CIS.Delete<OP_UserInterval>(p => p.UserID == SysContext.CurrUser.user.Code);
            foreach (DataGridViewRow item in this.dataGridViewX1.Rows)
            {
                OP_UserInterval tmp = new OP_UserInterval();
                tmp.ID = Guid.NewGuid().ToString();
                tmp.No = item.Index;
                tmp.Name = item.Cells[0].Value.ToString();
                tmp.Code = item.Cells[1].Value.ToString();
                tmp.Count = item.Cells[2].Value.AsInt();
                tmp.UserID = SysContext.CurrUser.user.Code;
                DBHelper.CIS.Insert<OP_UserInterval>(tmp);
            }
            CIS.Core.AlertBox.Info("保存成功,需要重启医生工作站选项卡生效");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection rows = this.dataGridViewX1.SelectedCells;
            if (rows.Count == 0) return;
            DataGridViewRow row = this.dataGridViewX1.Rows[rows[0].RowIndex];
            int index;
            if (sender == btnUp)
            {
                if (row.Index == 0) return;
                index = row.Index - 1;
            }
            else
            {
                if (row.Index >= this.dataGridViewX1.Rows.Count - 1) return;
                index = row.Index + 1;
            }
            this.dataGridViewX1.Rows.Remove(row);
            this.dataGridViewX1.Rows.Insert(index, row);
            this.dataGridViewX1.ClearSelection();
            this.dataGridViewX1.CurrentCell = rows[0];
        }

        private void FormSettingInterval_Shown(object sender, EventArgs e)
        {
            this.dataGridViewX1.AutoGenerateColumns = false;
            InitData();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
