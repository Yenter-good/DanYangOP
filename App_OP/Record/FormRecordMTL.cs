using CIS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mandala.EPR.Com.Interfaces;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace App_OP.Record
{
    public partial class FormRecordMTL : BaseForm
    {
        private IOutRecordController _controller;

        public FormRecordMTL()
        {
            InitializeComponent();
        }

        private IOutRecordController CreateOutRecordManager(params object[] args)
        {
            string assemblyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mandala", "Mandala.EPR.Com.Achieve.dll");
            Assembly assembly = Assembly.LoadFrom(assemblyFile);
            Type type = assembly.GetType("Mandala.EPR.Com.Achieve.OutPatientRecordController", false, true);
            return Activator.CreateInstance(type, args) as IOutRecordController;
        }

        public void Init()
        {
            _controller = CreateOutRecordManager(new object[]
            {
                new Dictionary<string, string>
                {
                    {
                        "HosCode",
                        "12321181468778299Y"
                    },
                    {
                        "UserCode",
                        SysContext.CurrUser.user.Code
                    },



                    {
                        "DeptCode",
                        SysContext.RunSysInfo.currDept.Code
                    },
                    {
                        "DeptName",
                        SysContext.RunSysInfo.currDept.Name
                    }
                }
            });

            var control = _controller.GetMainControl();
            control.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(control);
        }

        public void ChangedPatient()
        {
            _controller.SetPatient(SysContext.GetCurrPatient.OutpatientNo);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            _controller.DoSave();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            _controller.DoSubmit();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _controller.DoPrint();
        }

        private void btnSpecialSymbol_Click(object sender, EventArgs e)
        {
            Process p = Process.Start(Application.StartupPath + @"\SpecialSymbol\QuickInput.exe");
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                AlertBox.Info("请先选择病人");
                return;
            }
            FormLISResult form = new FormLISResult(null);
            form.search = true;
            form.ShowDialog();
        }

        private void btnPacsResult_Click(object sender, EventArgs e)
        {
            FormRISResult result = new FormRISResult();
            result.ShowDialog();
        }

        private void biEcgQueryReport_Click(object sender, EventArgs e)
        {
            if (SysContext.RunSysInfo.Params.OP_EcgRead)
            {
                string Url = SysContext.RunSysInfo.Params.OP_EcgReadUrl;
                if (Url.IsNullOrWhiteSpace())
                    return;
                if (SysContext.GetCurrPatient == null)
                {
                    AlertBox.Error("请先选择患者！");
                    return;
                }
                Url += SysContext.GetCurrPatient.OutpatientNo;
                //调用IE浏览器
                System.Diagnostics.Process.Start("iexplore.exe", Url);
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            _controller.DoDelete();
        }

        public override void OnClose()
        {
            base.OnClose();
            _controller.IsOnClosing();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            _controller.DoEdit();
        }
    }
}
