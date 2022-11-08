using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CIS.Core
{
    public partial class DialogBase : DevComponents.DotNetBar.Office2007Form
    {
        private static object EVENT_OK = new object();
        private static object EVENT_OKING = new object();

        private bool _Modified = false;
        private DialogBottonType _ButtonType = DialogBottonType.OKCancel;
        /// <summary>
        /// 确定时发生 可取消事件
        /// </summary>
        public event EventHandler<CancelEventArgsExt> OKing
        {
            add { base.Events.AddHandler(EVENT_OKING, value); }
            remove { base.Events.RemoveHandler(EVENT_OKING, value); }
        }
        /// <summary>
        /// 确定后发生
        /// </summary>
        public event EventHandler OK
        {
            add { base.Events.AddHandler(EVENT_OK,value); }
            remove { base.Events.RemoveHandler(EVENT_OK,value); }
        }

        [Category("窗口样式"),Description("对话框按钮类型")]
        public DialogBottonType BottonType 
        {
            get { return _ButtonType; }
            set 
            {
                if (this._ButtonType != value)
                {
                    this.AdjustButtonStyle(value);
                }

                _ButtonType = value; 
            }
        }
        /// <summary>
        /// 判断是否发生过修改
        /// </summary>
        [Browsable(false)]
        public bool Modified
        {
            get { return _Modified; }
            set
            {
                if (_Modified != value)
                {
                    this.OnModifiedChanged(value);
                }
                _Modified = value;
            }
        }
        public DialogBase()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 调整按钮样式
        /// </summary>
        /// <param name="bottonType"></param>
        private void AdjustButtonStyle(DialogBottonType bottonType)
        {
            switch (bottonType)
            {
                case DialogBottonType.OKCancel:
                    this.btnOK.Text = "确定";
                    this.btnCancel.Text = "取消";
                    break;
                case DialogBottonType.SaveCancel:
                    this.btnOK.Text = "保存";
                    this.btnCancel.Text = "取消";
                    break;
                case DialogBottonType.AddClose:
                     this.btnOK.Text = "添加";
                     this.btnCancel.Text = "关闭";
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 窗体内容发生修改后
        /// </summary>
        protected virtual void OnModifiedChanged(bool modified)
        {
            this.btnOK.Enabled = modified;
        }
     
        /// <summary>
        /// 验证数据有效性
        /// </summary>
        /// <returns></returns>
        protected virtual new bool Validate()
        {
            return base.Validate();
        }
        protected virtual void OnOKingCancel(string cancelReason)
        {
 
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            //验证数据有效性
            if (!this.Validate()) return;
            
            if (base.Events[EVENT_OKING] != null)
            {
                CancelEventArgsExt cancelEventArgs = new CancelEventArgsExt();
                base.Events[EVENT_OKING].DynamicInvoke(this,cancelEventArgs);
                //判断是否取消
                if (cancelEventArgs.Cancel)
                {
                    //显示取消原因
                    this.OnOKingCancel(cancelEventArgs.CancelReason);
                    return;
                }
            }
            if (base.Events[EVENT_OK] != null)
            {
                base.Events[EVENT_OK].DynamicInvoke(this, EventArgs.Empty);
            }
            this.Modified = false;
            if (this.Modal)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Modified = false;
            if (this.Modal)
                this.DialogResult = DialogResult.Cancel;
            else
                this.Close();
        }
    }
}
