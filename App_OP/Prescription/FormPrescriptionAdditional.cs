using CIS.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;


namespace App_OP.Prescription
{
    public partial class FormPrescriptionAdditional : FormCancelUnenabled
    {
        Panel[] panel = new Panel[6];
        private string _PrescriptionNo
        { get; set; }

        public bool IsSave
        { get; set; }

        public FormPrescriptionAdditional(string PrescriptionNo)
        {
            InitializeComponent();
            _PrescriptionNo = PrescriptionNo;
        }

        /// <summary>
        /// 指定要显示的控件
        /// </summary>
        /// <param name="itemName">指定项目显示,以下选项   静脉输液, 氧化雾化吸入, 皮试</param>
        /// <param name="itemNum"></param>
        public void ShowControl(List<string> itemName)
        {
            this.Show();
            int LastTop = 80;
            InitPanel();
            itemName = itemName.Distinct().ToList();
            itemName = itemName.OrderBy(p => p).ToList();
            for (int i = 0; i < itemName.Count; i++)
            {
                string str = itemName[i].Split(",".ToCharArray())[0];
                string num = itemName[i].Split(",".ToCharArray())[1];
                int index = Name1.ToList().IndexOf(str);
                string controlName = ComName[index];
                foreach (Panel item in panel)
                {
                    if (item.Controls.IndexOfKey(controlName) > -1)
                    {
                        ComboBox combo = (item.Controls.Find(controlName, false)[0] as ComboBox);
                        combo.Text = num;
                        item.Top = LastTop;
                        item.Show();
                        LastTop += 34;
                        if (Extensions.GetAge(SysContext.GetCurrPatient.Age) < 7 && str != "3皮试")
                        {
                            int panelIndex = panel.ToList().IndexOf(item) + 1;
                            if (panelIndex >= this.panel.Length)
                                continue;
                            panel[panelIndex].Show();
                            panel[panelIndex].Top = LastTop;
                            ComboBox combo1 = (panel[panelIndex].Controls.Find(ComName[index + 1], false)[0] as ComboBox);
                            combo1.Text = num;
                            LastTop += 34;
                        }
                    }
                }
            }

            InitRadio();
            this.Visible = false;
            this.ShowDialog();
        }

        /// <summary>
        /// 初始化下拉列表最多到几次
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="num"></param>
        private void InitControlNum(ComboBox comboBox, int num)
        {
            for (int i = 0; i <= num; i++)
            {
                comboBox.Items.Add(i);
            }
        }

        private void InitRadio()
        {
            try
            {
                if (Extensions.GetAge(SysContext.GetCurrPatient.Age) < 7)
                    this.radioChildCF.Checked = true;
                else
                    this.radioNormalCF.Checked = true;
            }
            catch (Exception)
            {
                this.radioNormalCF.Checked = true;
            }
        }

        string[] Name1 = new string[] { "1静脉输液", "静脉输液儿童加收", "2氧化雾化吸入", "氧化雾化吸入儿童加收", "3皮试", "4皮肤电极" };
        string[] ComName = new string[] { "comboBox1", "comboBox2", "comboBox3", "comboBox6", "comboBox4", "comboBox5" };
        //int[] Value = new int[] { 0, 3, 4, 5 };

        //private int GetAge()
        //{
        //    char[] str = new char[] { '岁', '月', '日', '天' };
        //    string age = SysContext.GetCurrPatient.Age;
        //    char[] chr = age.ToCharArray();
        //    for (int i = 0; i < chr.Length; i++)
        //    {
        //        if (str.Contains(chr[i]))
        //        {
        //            string s = new string(chr, 0, i);
        //            return (int)float.Parse(s);
        //        }

        //    }
        //    return 0;
        //}


        private void FormSendCF_Load(object sender, EventArgs e)
        {

        }

        private void InitPanel()
        {
            panel[0] = this.panel1;
            panel[1] = this.panel2;
            panel[2] = this.panel3;
            panel[3] = this.panel6;
            panel[4] = this.panel4;
            panel[5] = this.panel5;
            //this.comboBox1.Parent = this.panel1;
            //this.comboBox2.Parent = this.panel2;
            //this.comboBox3.Parent = this.panel3;
            //this.comboBox4.Parent = this.panel4;
            //this.comboBox5.Parent = this.panel5;
            //this.comboBox6.Parent = this.panel6;


            //第一个元素成人,第二个儿童
            panel[0].Tag = "414313";
            panel[1].Tag = "414314";
            panel[2].Tag = "120075";
            panel[3].Tag = "120244";
            panel[4].Tag = "414311";
            panel[5].Tag = "041039";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            InitPrescriptionDetail();
        }

        private void InitPrescriptionDetail()
        {
            DBHelper.CIS.Delete<OP_Prescription_Detail>(p => p.PrescriptionNo == this._PrescriptionNo && p.ItemType == "9");
            foreach (Panel item in panel)
            {
                if (item.Visible)
                {
                    if (GetNumInComboFromPanel(item) == 0) continue;
                    string itemCode = item.Tag.ToString();
                    IView_HIS_DealWithItem Deal = DBHelper.CIS.From<IView_HIS_DealWithItem>().Where(p => p.Code == itemCode).First();
                    OP_Prescription_Detail detail = new OP_Prescription_Detail();
                    detail.ID = Guid.NewGuid().ToString();
                    detail.TreatmentNo = SysContext.GetCurrPatient.OutpatientNo;
                    detail.PatientID = SysContext.GetCurrPatient.PatientID;
                    detail.PrescriptionNo = _PrescriptionNo;
                    detail.ItemType = "9";
                    detail.No = 99;
                    detail.IsAdditional = 1;
                    detail.ItemCode = itemCode;
                    detail.ItemName = Deal.Name;
                    detail.UpdateTime = DateTime.Now;
                    detail.PackingUnit = Deal.PackingUnit;
                    detail.Specification = Deal.Specification;
                    detail.Price = Deal.Price;
                    detail.Number = GetNumInComboFromPanel(item);
                    detail.Total = Deal.Price * detail.Number;
                    DBHelper.CIS.Insert<OP_Prescription_Detail>(detail);
                }
            }
            this.IsSave = true;
            this.Close();
        }

        private int GetNumInComboFromPanel(Panel panel)
        {
            foreach (Control item in panel.Controls)
            {
                if (item is ComboBox)
                {
                    string str = (item as ComboBox).Text;
                    int num = 0;
                    if (int.TryParse(str, out num))
                        return num;
                }
            }
            return 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.IsSave = false;
            this.Close();
        }

    }
}
