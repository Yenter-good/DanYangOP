using CIS.Core;
using System.Diagnostics;

namespace App_OP
{
    public static class ElectrocardiogramResult
    {
        private static void ShowElectrocardiogramResult()
        {
            string url = @"http://192.168.0.7/MedExECGWebSetup/buss/PatientByOneself.aspx?OutPatientNo={0}&InPatientNo=";
            if (SysContext.GetCurrPatient == null)
            {
                AlertBox.Info("您未选择患者,无法调取心电结果报告");
                return;
            }
            url = string.Format(url, SysContext.GetCurrPatient.OutpatientNo);
            Process.Start(url);
        }
    }
}
