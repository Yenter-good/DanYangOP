using System;
using System.Drawing;
using System.Windows.Forms;

namespace App_Sys.Menu
{
    public partial class frmTest : CIS.Core.BaseForm
    {
        public frmTest()
        {
            InitializeComponent();
            //ShortcutKey.Set(this.button1, CIS.Core.KeyModifiers.Ctrl, Keys.A);
            //ShortcutKey.Set(this.button1,Shortcut.CtrlA);
            this.textBoxX1.ComboPopup(null, v => {

                v.GetDataSource = filter => {
                    return CIS.Model.DBHelper.CIS.From<CIS.Model.IView_HIS_ICD>()
                        .Where(m=>m.Name.Contains(filter)).ToDataTable();
                };
                v.DisplayMember = CIS.Model.IView_HIS_ICD._.Name.Name;
                v.ValueMember = CIS.Model.IView_HIS_ICD._.Code.Name;
                v.FilterFields = new string[] { CIS.Model.IView_HIS_ICD._.Name.Name };
            }, null);
            //this.textBoxX3.ComboFindPopup(null, v =>
            //{
            //    v.GetDataSource = filter =>
            //    {
            //        return CIS.Model.DBHelper.CIS.From<CIS.Model.IView_HIS_ICD>()
            //            .Where(m => m.Name.Contains(filter)).ToDataTable();
            //    };
            //    v.DisplayMember = CIS.Model.IView_HIS_ICD._.Name.Name;
            //    v.ValueMember = CIS.Model.IView_HIS_ICD._.Code.Name;
            //    v.FilterFields = new string[] { CIS.Model.IView_HIS_ICD._.Name.Name };
            //}, null);

             this.findComboBox1.DisplayMember = CIS.Model.IView_HIS_ICD._.Name.Name;
             this.findComboBox1.ValueMember = CIS.Model.IView_HIS_ICD._.Code.Name;
             this.findComboBox1.FilterFields = new string[] { CIS.Model.IView_HIS_ICD._.Name.Name };
             this.findComboBox1.DataSource = CIS.Model.DBHelper.CIS.From<CIS.Model.IView_HIS_ICD>()
                         .ToDataTable();

            this.textBoxX2.GridPopup(null, v =>
            {
                var dt = CIS.Model.DBHelper.CIS.From<CIS.Model.IView_HIS_ICD>().ToDataTable();
                dt.AppendSpell(CIS.Model.IView_HIS_ICD._.Name.Name);
                v.DataSource = dt;
                v.TextFiled = CIS.Model.IView_HIS_ICD._.Name.Name;
                v.KeyFiled = CIS.Model.IView_HIS_ICD._.Code.Name;
                v.Columns = "{0}|编码|*;{1}|名称|*;{2}|拼音码|*".FormatWith(CIS.Model.IView_HIS_ICD._.Code.Name, CIS.Model.IView_HIS_ICD._.Name.Name, CIS.Model.IView_HIS_ICD._.Name.Name+"_Spell");
                v.FilterFields = new string[] { CIS.Model.IView_HIS_ICD._.Name.Name, CIS.Model.IView_HIS_ICD._.Name.Name + "_Spell" };
            }, null);
            var data = CIS.Model.DBHelper.CIS.From<CIS.Model.IView_HIS_ICD>().ToDataTable();
                data.AppendSpell(CIS.Model.IView_HIS_ICD._.Name.Name);
            this.comboTokenEditor1.PopupDataSource = data;
            this.comboTokenEditor1.DisplayMember = CIS.Model.IView_HIS_ICD._.Name.Name;
            this.comboTokenEditor1.ValueMember = CIS.Model.IView_HIS_ICD._.Code.Name;
            this.comboTokenEditor1.FilterFields = new string[] { CIS.Model.IView_HIS_ICD._.Name.Name };
            this.comboTokenEditor1.PopupSize = new Size(300, 200);
        }
        private void textBoxX3_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            //CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(button1.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_LBUTTONDOWN, 0, 0);
            //CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(button1.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_LBUTTONUP, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2");
        }

        private void advTree1_BeforeNodeDrop(object sender, DevComponents.AdvTree.TreeDragDropEventArgs e)
        {
            this.labelX1.Text = "{0}     {1}".FormatWith(e.InsertPosition, e.Node.Index);
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
        }

        private void frmTest_Click(object sender, EventArgs e)
        {
            this.comboTokenEditor1.Enabled = false;
            this.comboTokenEditor1.BackgroundStyle.BackColor = Color.Red;

        }
    }
}
