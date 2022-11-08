using System;
using System.Windows.Forms;

namespace App_Template.Common
{
    /// <summary>
    /// 模板设计控件
    /// </summary>
    public partial class ElementDesignControl : UserControl
    {
        /// <summary>
        /// 获取编辑器
        /// </summary>
        public CIS.DCWriter.Controls.TxWriterControl WriterControl
        {
            get { return this.txWriterControl1; }
        }

        public void InitUI(bool enable)
        {
            this.bar1.Enabled = enable;
        }

        public ElementDesignControl()
        {
            InitializeComponent();
        }

        private void ElementDesignControl_Load(object sender, EventArgs e)
        {
            this.txWriterControl1.CommandControler = this.writerCommandControler1;
            this.txWriterControl1.CommandControler.Start();//启用编辑器
        }

        public CIS.DCWriter.Controls.TxWriterControl Write
        { get { return this.txWriterControl1; } private set { } }
    }
}
