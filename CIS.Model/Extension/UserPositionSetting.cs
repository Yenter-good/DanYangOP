using System;

namespace CIS.Model
{
    [Serializable]
    public class UserPositionSetting
    {
        public int PrescriptionPosition { get; set; }

        public int PatientInfoPosition { get; set; }
    }
}
