using System;

namespace CIS.Core.EventBroker
{
    /// <summary>
    /// 为刷新患者的事件提供数据
    /// </summary>
    public class PatientEventArgs : EventArgs
    {
        public enum UpdateMode
        {
            Prescription,
            ImportLISResult,
            ImportDrugInfoToRecord,
            ImportPresentIllness,
            GetHMDiagnosis,
            ImportXMLToRecode,
            ShowInfection,
            ShowChronic,
            ShowMZ,
            Diagnosis
        }


        /// <summary>
        /// 通用数据
        /// </summary>
        public object Data
        { get; set; }

        public string PatientCode
        { get; set; }

        public UpdateMode Mode
        { get; set; }
    }

}