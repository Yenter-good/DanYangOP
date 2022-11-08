using CIS.Core;
using CIS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_OP.Examination
{
    public partial class FormKnowlage : BaseForm
    {
        private const int PacsHeight = 535;
        private const int LISHeight = 580;

        public FormKnowlage()
        {
            InitializeComponent();
        }

        public bool IsLIS
        {
            set
            {
                if (value)
                {
                    this.labelX5.Show();
                    this.Height = LISHeight;
                }
                else
                {
                    this.labelX5.Hide();
                    this.Height = PacsHeight;
                }
            }
        }

        public void Init(vzd_tcsm note)
        {
            this.textBoxX1.Text = note.适应症;
            this.textBoxX2.Text = note.采集要求;
            this.textBoxX3.Text = note.套餐说明;
            this.textBoxX4.Text = note.准备内容;
            this.labelX5.Text = "标本名称:" + note.标本名称;
        }

        private void FormKnowlage_Shown(object sender, EventArgs e)
        {
            this.textBoxX1.DeselectAll();
            this.textBoxX2.DeselectAll();
            this.textBoxX3.DeselectAll();
            this.textBoxX4.DeselectAll();
        }
    }
}
