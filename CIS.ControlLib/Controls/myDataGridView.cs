using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using System.Reflection;

namespace CIS.ControlLib.Controls
{
    public class myDataGridView : DataGridViewX
    {
        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                (e.Control as TextBox).TextChanged += new EventHandler(OnTextChanged);
                e.Control.ContextMenu = new ContextMenu();

            }
            else if (e.Control is ComboBoxEx)
            {
                (e.Control as ComboBoxEx).KeyDown += myDataGridView_KeyDown;
            }
            base.OnEditingControlShowing(e);
        }

        int tick = 0;

        void myDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (ComboBoxText.Length == 0)
                tick = Environment.TickCount;
            int sub = Environment.TickCount - tick;

            if (sub > 1000)
                ComboBoxText = "";

            if (ComboBoxText.Length != 0 && sub < 10)
                return;

            tick = Environment.TickCount;

            if (e.KeyData == Keys.F4)
                return;
            if ((e.KeyValue >= 65 && e.KeyValue <= 90) || (e.KeyValue >= 97 && e.KeyValue <= 122))
            {
                ComboBoxText += System.Text.Encoding.UTF8.GetString(new byte[] { (byte)e.KeyValue }).ToLower();
                ComboBoxEx c = sender as ComboBoxEx;
                if ((c.DataSource as IEnumerable<Object>) == null) return;
                Object[] datalist = (c.DataSource as IEnumerable<Object>).ToArray();

                foreach (var item in datalist)
                {
                    PropertyInfo info = item.GetType().GetProperty("SearchCode");
                    if (info == null)
                        info = item.GetType().GetProperty("Name");
                    if (info == null)
                        return;
                    string tmp = info.GetValue(item, null).AsString("");
                    if (tmp.Contains(ComboBoxText))
                    {
                        c.SelectedItem = item;
                        return;
                    }
                }
            }
        }

        string ComboBoxText = "";
        double Tick = 0;
        int delay = 200;
        private System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        object Sender;
        EventArgs E;

        public int Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (Tick >= delay / 10)
            {
                this.Text_Changed(Sender, E);
                t.Enabled = false;
            }
            Tick++;
        }

        [Browsable(true), Description("单元格值发生变化时"), Category("操作")]
        public event EventHandler Text_Changed;
        protected virtual void OnTextChanged(object sender, EventArgs e)
        {
            TextBox box = (sender as TextBox);
            int index = box.SelectionStart;
            box.Text = box.Text.ToDBC();
            box.SelectionStart = index;
            Sender = sender;
            E = e;
            Tick = 0;
            t.Enabled = true;
        }
        public event KeyEventHandler TextKeyDown;
        public myDataGridView()
        {
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 10;
        }
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                TextKeyDown(this, e);
                return false;
            }
            else
                try
                {
                    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape || e.KeyCode == Keys.F1)
                        return false;
                    else
                        return base.ProcessDataGridViewKey(e);
                }
                catch (Exception)
                {
                    return true;
                }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Escape || keyData == Keys.F1)
            {
                TextKeyDown(this, new KeyEventArgs(keyData));
                return false;
            }
            else
            {
                if (keyData == Keys.Up || keyData == Keys.Down)
                    return false;
                else
                    return base.ProcessDialogKey(keyData);

            }
        }
    }
}
