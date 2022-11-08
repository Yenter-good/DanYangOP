namespace CIS
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.tbxGh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblGh = new DevComponents.DotNetBar.LabelX();
            this.lblPwd = new DevComponents.DotNetBar.LabelX();
            this.tbxPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.lblMsg = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxGh
            // 
            // 
            // 
            // 
            this.tbxGh.Border.Class = "TextBoxBorder";
            this.tbxGh.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxGh.Location = new System.Drawing.Point(538, 288);
            this.tbxGh.Name = "tbxGh";
            this.tbxGh.Size = new System.Drawing.Size(172, 21);
            this.tbxGh.TabIndex = 0;
            this.tbxGh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxGh_KeyDown);
            // 
            // lblGh
            // 
            this.lblGh.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblGh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGh.Font = new System.Drawing.Font("ËÎÌå", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGh.Location = new System.Drawing.Point(452, 288);
            this.lblGh.Name = "lblGh";
            this.lblGh.Size = new System.Drawing.Size(80, 23);
            this.lblGh.TabIndex = 1;
            this.lblGh.Text = "¹¤  ºÅ£º";
            // 
            // lblPwd
            // 
            this.lblPwd.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblPwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPwd.Font = new System.Drawing.Font("ËÎÌå", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPwd.Location = new System.Drawing.Point(452, 328);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(80, 23);
            this.lblPwd.TabIndex = 3;
            this.lblPwd.Text = "ÃÜ  Âë£º";
            // 
            // tbxPwd
            // 
            // 
            // 
            // 
            this.tbxPwd.Border.Class = "TextBoxBorder";
            this.tbxPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxPwd.Location = new System.Drawing.Point(538, 328);
            this.tbxPwd.Name = "tbxPwd";
            this.tbxPwd.PasswordChar = '*';
            this.tbxPwd.Size = new System.Drawing.Size(172, 23);
            this.tbxPwd.TabIndex = 2;
            this.tbxPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPwd_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnLogin.Location = new System.Drawing.Point(538, 357);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnLogin.Size = new System.Drawing.Size(75, 60);
            this.btnLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "µÇÂ¼";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnExit.Location = new System.Drawing.Point(635, 357);
            this.btnExit.Name = "btnExit";
            this.btnExit.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnExit.Size = new System.Drawing.Size(75, 60);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "ÍË³ö";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(457, 259);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(253, 23);
            this.lblMsg.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(752, 438);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(752, 444);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.tbxPwd);
            this.Controls.Add(this.lblGh);
            this.Controls.Add(this.tbxGh);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX tbxGh;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxPwd;
        private DevComponents.DotNetBar.LabelX lblGh;
        private DevComponents.DotNetBar.LabelX lblPwd;
        private DevComponents.DotNetBar.ButtonX btnLogin;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.LabelX lblMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}