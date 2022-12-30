using CIS.Core;
using CIS.Model;
using FastReport;
using FastReport.Export.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace App_OP
{
    public class Print
    {
        static List<IView_HIS_DrugUsage> Usage = DBHelper.CIS.From<IView_HIS_DrugUsage>().ToList(); //用法字典
        static FastReport.EnvironmentSettings environment = new EnvironmentSettings();

        /// <summary>
        /// 处方打印
        /// </summary>
        public static void PrescriptionPrint(string PrescriptionNo, string PrescriptionType, string PrescriptionNum, bool IsView = false, bool IsSpecialPrite = false, string OutpatientNo = "", bool selectAll = false)
        {
            //获取路径
            string frxPath = System.IO.Path.Combine(Application.StartupPath, "FRX");
            FastReport.Report report = new FastReport.Report();
            if (!IsSpecialPrite)
            {
                if (PrescriptionType == "1" || PrescriptionType == "3" || PrescriptionType == "5" || PrescriptionType == "6" || PrescriptionType == "8")
                    report.Load(frxPath + "\\mzcf.frx");
                //report.Load(frxPath + "\\mzcf-QR.frx");
                else if (PrescriptionType == "2")
                    report.Load(frxPath + "\\mzcycf.frx");
                else if (PrescriptionType == "9")
                    report.Load(frxPath + "\\mzcz.frx");
                else if (PrescriptionType == "11")
                    report.Load(frxPath + "\\jysq.frx");
                else if (PrescriptionType == "12")
                    report.Load(frxPath + "\\jcsq.frx");
                //else if (PrescriptionType == "7")
                //    report.Load(frxPath + "\\mzjmycf.frx");
                else if (PrescriptionType == "13")//门诊外购处方
                    report.Load(frxPath + "\\mzwgcf.frx");
                else if (PrescriptionType == "4" || PrescriptionType == "7")
                    report.Load(frxPath + "\\mzmzcf.frx");
            }
            else
                report.Load(frxPath + "\\mzcygf.frx");


            string TreatmentNo = OutpatientNo == "" ? SysContext.GetCurrPatient.OutpatientNo : OutpatientNo;
            DataTable dt = BuildPrescription(PrescriptionNo, TreatmentNo, PrescriptionType, PrescriptionNum, selectAll);

            report.RegisterData(dt, "Table4");
            //report.SetParameterValue("PayWX", GetPayRequest(dt.Rows[0]["Total"].ToString()));
            //report.SetParameterValue("PayAlipay", GetPayRequest(dt.Rows[0]["Total"].ToString(), false));
            environment.ReportSettings.ShowProgress = false;
            report.PrintSettings.ShowDialog = false;
            //var previewButtons = FastReport.Utils.Config.PreviewSettings.Buttons;
            FastReport.Utils.Config.PreviewSettings.Buttons = PreviewButtons.Save | PreviewButtons.Print;
            if (IsView)
                report.Show(true);
            else
                report.Print();

            //FastReport.Utils.Config.PreviewSettings.Buttons = previewButtons;
        }

        public static string PrescriptionBase64(long PrescriptionNo, string prescriptionCirculationNo, string PrescriptionNum)
        {
            //获取路径
            string frxPath = System.IO.Path.Combine(Application.StartupPath, "FRX");
            FastReport.Report report = new FastReport.Report();
            report.Load(frxPath + "\\stdlz.frx");

            DataTable dt = BuildPrescriptionCirculation(PrescriptionNo, prescriptionCirculationNo, SysContext.GetCurrPatient.OutpatientNo);

            report.RegisterData(dt, "Table4");

            environment.ReportSettings.ShowProgress = false;
            report.PrintSettings.ShowDialog = false;
            report.Prepare();

            PDFExport export = new PDFExport();
            using (var stream = new MemoryStream())
            {
                report.Export(export, stream);
                var buffer = stream.ToArray();

                return Convert.ToBase64String(buffer);
            }
        }

        public static void PrescriptionPrint(long PrescriptionNo, string prescriptionCirculationNo, string treatmentNo)
        {
            //获取路径
            string frxPath = System.IO.Path.Combine(Application.StartupPath, "FRX");
            FastReport.Report report = new FastReport.Report();
            report.Load(frxPath + "\\stdlz.frx");

            DataTable dt = BuildPrescriptionCirculation(PrescriptionNo, prescriptionCirculationNo, treatmentNo);

            report.RegisterData(dt, "Table4");

            environment.ReportSettings.ShowProgress = false;
            report.PrintSettings.ShowDialog = false;
            FastReport.Utils.Config.PreviewSettings.Buttons = PreviewButtons.Save | PreviewButtons.Print;
            report.Show(true);
        }

        private static Bitmap GetPayRequest(string Total, bool isWX = true)
        {
            PayRequest result = new PayRequest();
            result.FOUNCTIONID = "A1001";
            result.PAYMODE = isWX ? "weixinpay" : "alipay";
            result.FEE = Total;
            result.SPONSOR = SysContext.CurrUser.user.Code;
            result.HOLDERNAME = SysContext.GetCurrPatient.PatientName; ;
            result.ACTUALCHARGE = Total;
            result.KEY = "9004F327C987E86C967A1E21194658DA";
            result.TERMINALSN = "szjmz";

            return QRImage.GetPayImage(result);
        }

        public static DataTable BuildPrescription(string PrescriptionNo, string TreatmentNo, string PrescriptionType, string PrescriptionNum, bool selectAll = false)
        {
            DataTable dt = new DataTable();
            dt = GetPrintDataTableStru().Clone();
            List<OP_PatientDiagnosis> diagnosis = new List<OP_PatientDiagnosis>();

            if (selectAll)
                diagnosis = DBHelper.CIS.From<OP_PatientDiagnosis>().UnionAll(DBHelper.CIS.From<OP_PatientDiagnosis_History>()).Where(p => p.TreatmentNo == TreatmentNo).Select(p => new { p.Name, p.Status }).OrderBy(p => new { p.Type, p.Index }).ToList<OP_PatientDiagnosis>();
            else
                diagnosis = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.TreatmentNo == TreatmentNo).Select(p => new { p.Name, p.Status }).OrderBy(p => new { p.Type, p.Index }).ToList<OP_PatientDiagnosis>();


            diagnosis.ForEach(p => p.Name += p.Status == 2 ? "(待查)" : "");

            string diagnosisString = string.Join(",", diagnosis.Select(p => p.Name).ToArray()); //获得诊断信息

            List<CIS.Model.Prescription> list = new List<CIS.Model.Prescription>();
            if (selectAll)
                list = DBHelper.CIS.FromProc("Proc_OP_GetPrintPrescription_All").AddInParameter("PrescriptionNo", DbType.String, PrescriptionNo).AddInParameter("TreatmentNo", DbType.String, TreatmentNo).ToList<CIS.Model.Prescription>();
            else
                list = DBHelper.CIS.FromProc("Proc_OP_GetPrintPrescription").AddInParameter("PrescriptionNo", DbType.String, PrescriptionNo).AddInParameter("TreatmentNo", DbType.String, TreatmentNo).ToList<CIS.Model.Prescription>();

            list = list.OrderBy(p => p.No).ToList();
            list.ForEach(p => p.DiagnosisName = diagnosisString);

            DataTable result = new DataTable();

            if (PrescriptionType == "1" || PrescriptionType == "3" || PrescriptionType == "4" || PrescriptionType == "5" || PrescriptionType == "6" || PrescriptionType == "7" || PrescriptionType == "8" || PrescriptionType == "13")
                result = BuildWesternMedicine(dt, list, PrescriptionNum);
            else if (PrescriptionType == "9")
                result = BuildItem(dt, list);
            else if (PrescriptionType == "2")
                result = BuildHerbalMedicine(dt, list, PrescriptionNum);
            else
                result = BuildInspection(dt, list);


            return result;
        }

        public static DataTable BuildPrescriptionCirculation(long prescriptionNo, string prescriptionCirculationNo, string treatmentNo)
        {
            DataTable dt = new DataTable();
            dt = GetPrintDataTableStru().Clone();
            List<OP_PatientDiagnosis> diagnosis = new List<OP_PatientDiagnosis>();

            diagnosis = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.TreatmentNo == treatmentNo).Select(p => new { p.Name, p.Status }).OrderBy(p => new { p.Type, p.Index }).ToList<OP_PatientDiagnosis>();

            diagnosis.ForEach(p => p.Name += p.Status == 2 ? "(待查)" : "");

            string diagnosisString = string.Join(",", diagnosis.Select(p => p.Name).ToArray()); //获得诊断信息

            List<CIS.Model.Prescription> list = new List<CIS.Model.Prescription>();

            list = DBHelper.CIS.FromProc("Proc_OP_GetPrintPrescriptionCirculation").AddInParameter("PrescriptionNo", DbType.Int64, prescriptionNo).AddInParameter("TreatmentNo", DbType.String, treatmentNo).ToList<CIS.Model.Prescription>();

            return BuildCirculationWesternMedicine(dt, list, prescriptionNo, prescriptionCirculationNo);
        }

        private static DataTable GetPrintDataTableStru()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DrugName"); //药品名称
            dt.Columns.Add("DrugUsage"); //药品用法
            dt.Columns.Add("PatientID"); //患者ID
            dt.Columns.Add("Total"); //总额
            dt.Columns.Add("DeptName"); //科室名称
            dt.Columns.Add("DiagnosisName"); //诊断名称
            dt.Columns.Add("PatientName"); //患者姓名
            dt.Columns.Add("Sex"); //患者性别
            dt.Columns.Add("Age"); //患者年龄
            dt.Columns.Add("DoctorName"); //医生姓名
            dt.Columns.Add("UpdateTime"); //更新时间
            dt.Columns.Add("PrescriptionType"); //处方类别
            dt.Columns.Add("Group"); //同组编号
            dt.Columns.Add("PayType"); //支付类型
            dt.Columns.Add("ConditionSummary"); //病史摘要
            dt.Columns.Add("Explanation"); //
            dt.Columns.Add("Specimen"); //规格
            dt.Columns.Add("TreatmentNo"); //就诊号
            dt.Columns.Add("HerbalMedicineNum"); //剂数
            dt.Columns.Add("PrescriptionNo"); //处方号
            dt.Columns.Add("PatientPhone"); //病人手机
            dt.Columns.Add("DoctorPhone"); //医生手机
            dt.Columns.Add("IDCard"); //身份证号
            dt.Columns.Add("AgentName"); //经办人姓名
            dt.Columns.Add("AgentIDCard"); //经办人身份证号
            dt.Columns.Add("AgentAge"); //经办人年龄
            dt.Columns.Add("AgentSex"); //经办人性别
            dt.Columns.Add("HerbsGroupName"); //膏方名称
            dt.Columns.Add("PatientAddress"); //病人地址
            dt.Columns.Add("DrugPurpose"); //用药目的
            dt.Columns.Add("PrescriptionCirculationNo"); //医保处方追溯码
            return dt;
        }

        /// <summary>
        /// 组装西药处方
        /// </summary>
        /// <param name="dt">DataTable结构体</param>
        /// <param name="list">数据源</param>
        /// <returns></returns>
        private static DataTable BuildWesternMedicine(DataTable dt, List<CIS.Model.Prescription> list, string PrescriptionNo)
        {
            List<CIS.Model.Prescription> listGroup = list.Where(p => p.GroupNo != 0 && p.IsAdditional != 1).ToList();    //找到同组的药品
            List<int?> listGroupNo = listGroup.Select(p => p.GroupNo).Distinct().ToList();    //找到同组编号
            List<CIS.Model.Prescription> listNoGroup = list.Where(p => p.GroupNo == 0 && p.IsAdditional != 1).ToList();    //找到没有同组的药品
            string Total;
            if (listGroupNo == null)
                listGroupNo = new List<int?>();
            Total = string.Format("{0:f2}", list.Sum(p => p.Total));
            //生成同组的处方格式
            foreach (int? item1 in listGroupNo)
            {
                List<CIS.Model.Prescription> tmp = listGroup.Where(p => p.GroupNo == item1).ToList();
                string ItemName = "";
                string ItemUsage = "";
                foreach (CIS.Model.Prescription item in tmp)
                {
                    ItemName += item.ItemName + " " + item.Specification + " " + " " + item.Number + item.PackingUnit + Environment.NewLine;
                    string usage = "用法：" + item.Amount.AsFloat() + item.DosageUnit + " " + Usage.Where(p => p.Code == item.Usage).First().Name + " " + item.Frequency + (item.SkinTestFlag == "Y" ? "  需皮试" : item.SkinTestFlag == "N" ? "  已皮试" : "") + Environment.NewLine + Environment.NewLine;
                    ItemName += usage;
                    //ItemUsage = Usage.Where(p => p.Code == item.Usage).First().Name + Environment.NewLine + item.Frequency + " " + "×" + " " + item.Days + "天";
                    //ItemUsage = "口服" + Environment.NewLine + item.Frequency + " " + "×" + " " + item.Days + "天";
                }
                ItemName = ItemName.TrimEnd((char[])"\r\n".ToCharArray());
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { ItemName, ItemUsage, list[0].TreatmentNo.AsString(""), Total, list[0].DeptName?.Trim(), list[0].DiagnosisName?.Trim(), list[0].PatientName?.Trim(), list[0].Sex?.Trim(), list[0].Age?.Trim(), list[0].DoctorName?.Trim(), list[0].UpdateTime, list[0].PrescriptionType?.Trim(), "1", list[0].PayType?.Trim(), "", "", "", list[0].TreatmentNo?.Trim(), list[0].HerbalMedicineNum?.Trim(), PrescriptionNo, list[0]?.PatientPhone?.Trim(), "", list[0].IDCard?.Trim(), list[0].AgentName?.Trim(), list[0].AgentIDCard?.Trim(), list[0].AgentAge?.Trim(), list[0].AgentSex?.Trim(), "", list[0].PatientAddress?.Trim(), list[0].DrugPurpose?.Trim() };
                dt.Rows.Add(row);
            }

            //生成非同组的处方格式
            foreach (CIS.Model.Prescription item in listNoGroup)
            {
                string ItemName = item.ItemName + " " + item.Specification + " " + "×" + " " + item.Number + item.PackingUnit + Environment.NewLine;
                string ItemUsage = "   Sig." + " " + item.Amount.AsFloat() + item.DosageUnit + " " + Usage.Where(p => p.Code == item.Usage).First().Name + " " + item.Frequency + (item.SkinTestFlag == "Y" ? "  需皮试" : item.SkinTestFlag == "N" ? "  已皮试" : "") + Environment.NewLine;
                //string ItemUsage = "   Sig." + " " + item.Amount.AsFloat() + " " + "口服" + " " + item.Frequency;
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { ItemName + ItemUsage, "", list[0].TreatmentNo.AsString(""), Total, list[0].DeptName?.Trim(), list[0].DiagnosisName?.Trim(), list[0].PatientName?.Trim(), list[0].Sex?.Trim(), list[0].Age?.Trim(), list[0].DoctorName?.Trim(), list[0].UpdateTime, list[0].PrescriptionType?.Trim(), "0", list[0].PayType?.Trim(), item.ConditionSummary?.Trim(), "", "", list[0].TreatmentNo, list[0].HerbalMedicineNum, PrescriptionNo, list[0]?.PatientPhone?.Trim(), "", list[0].IDCard?.Trim(), list[0].AgentName?.Trim(), list[0].AgentIDCard?.Trim(), list[0].AgentAge?.Trim(), list[0].AgentSex?.Trim(), "", list[0].PatientAddress?.Trim(), list[0].DrugPurpose?.Trim() };
                dt.Rows.Add(row);
            }

            return dt;
        }

        /// <summary>
        /// 组装双流转西药处方
        /// </summary>
        /// <param name="dt">DataTable结构体</param>
        /// <param name="list">数据源</param>
        /// <returns></returns>
        private static DataTable BuildCirculationWesternMedicine(DataTable dt, List<CIS.Model.Prescription> list, long prescriptionNo, string prescriptionCirculationNo)
        {
            List<CIS.Model.Prescription> listGroup = list.Where(p => p.GroupNo != 0 && p.IsAdditional != 1).ToList();    //找到同组的药品
            List<int?> listGroupNo = listGroup.Select(p => p.GroupNo).Distinct().ToList();    //找到同组编号
            List<CIS.Model.Prescription> listNoGroup = list.Where(p => p.GroupNo == 0 && p.IsAdditional != 1).ToList();    //找到没有同组的药品
            if (listGroupNo == null)
                listGroupNo = new List<int?>();
            //生成同组的处方格式
            foreach (int? item1 in listGroupNo)
            {
                List<CIS.Model.Prescription> tmp = listGroup.Where(p => p.GroupNo == item1).ToList();
                string ItemName = "";
                string ItemUsage = "";
                foreach (CIS.Model.Prescription item in tmp)
                {
                    ItemName += item.ItemName + " " + item.Specification + " " + " " + item.Number + item.PackingUnit + Environment.NewLine;
                    string usage = "用法：" + item.Amount.AsFloat() + item.DosageUnit + " " + Usage.Where(p => p.Code == item.Usage).First().Name + " " + item.Frequency + (item.SkinTestFlag == "Y" ? "  需皮试" : item.SkinTestFlag == "N" ? "  已皮试" : "") + Environment.NewLine + Environment.NewLine;
                    ItemName += usage;
                    //ItemUsage = Usage.Where(p => p.Code == item.Usage).First().Name + Environment.NewLine + item.Frequency + " " + "×" + " " + item.Days + "天";
                    //ItemUsage = "口服" + Environment.NewLine + item.Frequency + " " + "×" + " " + item.Days + "天";
                }
                ItemName = ItemName.TrimEnd((char[])"\r\n".ToCharArray());
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { ItemName, ItemUsage, list[0].TreatmentNo.AsString(""), "", list[0].DeptName?.Trim(), list[0].DiagnosisName?.Trim(), list[0].PatientName?.Trim(), list[0].Sex?.Trim(), list[0].Age?.Trim(), list[0].DoctorName?.Trim(), list[0].UpdateTime, list[0].PrescriptionType?.Trim(), "1", list[0].PayType?.Trim(), "", "", "", list[0].TreatmentNo?.Trim(), list[0].HerbalMedicineNum?.Trim(), prescriptionNo, list[0]?.PatientPhone?.Trim(), "", list[0].IDCard?.Trim(), list[0].AgentName?.Trim(), list[0].AgentIDCard?.Trim(), list[0].AgentAge?.Trim(), list[0].AgentSex?.Trim(), "", list[0].PatientAddress?.Trim(), list[0].DrugPurpose?.Trim(), prescriptionCirculationNo };
                dt.Rows.Add(row);
            }

            //生成非同组的处方格式
            foreach (CIS.Model.Prescription item in listNoGroup)
            {
                string ItemName = item.ItemName + " " + item.Specification + " " + "×" + " " + item.Number + item.PackingUnit + Environment.NewLine;
                string ItemUsage = "   Sig." + " " + item.Amount.AsFloat() + item.DosageUnit + " " + Usage.Where(p => p.Code == item.Usage).First().Name + " " + item.Frequency + (item.SkinTestFlag == "Y" ? "  需皮试" : item.SkinTestFlag == "N" ? "  已皮试" : "") + Environment.NewLine;
                //string ItemUsage = "   Sig." + " " + item.Amount.AsFloat() + " " + "口服" + " " + item.Frequency;
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { ItemName + ItemUsage, "", list[0].TreatmentNo.AsString(""), "", list[0].DeptName?.Trim(), list[0].DiagnosisName?.Trim(), list[0].PatientName?.Trim(), list[0].Sex?.Trim(), list[0].Age?.Trim(), list[0].DoctorName?.Trim(), list[0].UpdateTime, list[0].PrescriptionType?.Trim(), "0", list[0].PayType?.Trim(), item.ConditionSummary?.Trim(), "", "", list[0].TreatmentNo, list[0].HerbalMedicineNum, prescriptionNo, list[0]?.PatientPhone?.Trim(), "", list[0].IDCard?.Trim(), list[0].AgentName?.Trim(), list[0].AgentIDCard?.Trim(), list[0].AgentAge?.Trim(), list[0].AgentSex?.Trim(), "", list[0].PatientAddress?.Trim(), list[0].DrugPurpose?.Trim(), prescriptionCirculationNo };
                dt.Rows.Add(row);
            }

            return dt;
        }

        /// <summary>
        /// 组装西药处方(老处方格式)
        /// </summary>
        /// <param name="dt">DataTable结构体</param>
        /// <param name="list">数据源</param>
        /// <returns></returns>
        private static DataTable BuildWesternMedicineOld(DataTable dt, List<CIS.Model.Prescription> list)
        {
            List<CIS.Model.Prescription> listGroup = list.Where(p => p.GroupNo != 0 && p.IsAdditional != 1).ToList();    //找到同组的药品
            List<int?> listGroupNo = listGroup.Select(p => p.GroupNo).Distinct().ToList();    //找到同组编号
            List<CIS.Model.Prescription> listNoGroup = list.Where(p => p.GroupNo == 0 && p.IsAdditional != 1).ToList();    //找到没有同组的药品

            string Total;
            if (listGroupNo == null)
                listGroupNo = new List<int?>();
            Total = string.Format("{0:f2}", list.Sum(p => p.Total));
            foreach (int? item1 in listGroupNo)
            {
                List<CIS.Model.Prescription> tmp = listGroup.Where(p => p.GroupNo == item1).ToList();
                string ItemName = "";
                string ItemUsage = "";
                foreach (CIS.Model.Prescription item in tmp)
                {
                    ItemName += item.ItemName + " " + item.Specification + " " + item.Number + item.PackingUnit + Environment.NewLine + "     用法：" + float.Parse(item.Amount.ToString()) + item.DosageUnit + " " + item.Frequency + " " + Usage.Where(p => p.Code == item.Usage.ToLower()).First().Name + " " + (item.Usage.ToUpper().Trim() == "IVD" ? (item.Days + "天") : "") + (item.SkinTestFlag == "Y" ? " 需皮试" : "") + item.ConditionSummary.AsString("") + Environment.NewLine; //+ item.Amount + item.DosageUnit + " " + item.Number + item.PackingUnit + (item.SkinTestFlag == "Y" ? "  需皮试" : "") + Environment.NewLine + Environment.NewLine;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       //ItemUsage = Usage.Where(p => p.Code == item.Usage).First().Name + Environment.NewLine + item.Frequency + " " + "×" + " " + item.Days + "天";
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       //ItemUsage = "口服" + Environment.NewLine + item.Frequency + " " + "×" + " " + item.Days + "天";
                }
                ItemName = ItemName.TrimEnd((char[])"\r\n".ToCharArray());
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { ItemName, ItemUsage, list[0].TreatmentNo.AsString(""), Total, list[0].DeptName, list[0].DiagnosisName, list[0].PatientName, list[0].Sex, list[0].Age, list[0].DoctorName, list[0].UpdateTime, list[0].PrescriptionType, "1", list[0].PayType };
                dt.Rows.Add(row);
            }
            foreach (CIS.Model.Prescription item in listNoGroup)
            {
                string ItemName = item.ItemName + " " + item.Specification + " " + item.Number + item.PackingUnit + Environment.NewLine;
                string ItemUsage = "     用法：" + float.Parse(item.Amount.ToString()) + item.DosageUnit + " " + item.Frequency + " " + Usage.Where(p => p.Code == item.Usage.ToLower()).First().Name + " " + (item.Usage.ToUpper().Trim() == "IVD" ? (item.Days + "天") : "") + (item.SkinTestFlag == "Y" ? " 需皮试" : "") + item.ConditionSummary.AsString("") + Environment.NewLine;
                //string ItemUsage = "   Sig." + " " + item.Amount.AsFloat() + " " + "口服" + " " + item.Frequency;
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { ItemName + ItemUsage, "", list[0].TreatmentNo.AsString(""), Total, list[0].DeptName, list[0].DiagnosisName, list[0].PatientName, list[0].Sex, list[0].Age, list[0].DoctorName, list[0].UpdateTime, list[0].PrescriptionType, "0", list[0].PayType };
                dt.Rows.Add(row);
            }

            return dt;
        }
        /// <summary>
        /// 组装项目和材料
        /// </summary>
        /// <param name="dt">DataTable结构体</param>
        /// <param name="list">数据源</param>
        /// <returns></returns>
        private static DataTable BuildItem(DataTable dt, List<CIS.Model.Prescription> list)
        {
            float Total = 0;
            string ItemUsage = "";
            Total = (float)list.Sum(p => p.Total).AsFloat();
            foreach (CIS.Model.Prescription item in list)
            {
                //ItemUsage = "口服" + Environment.NewLine + item.Frequency + " " + "×" + " " + item.Days + "天";
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { item.ItemName + " × " + item.Number.ToString(), ItemUsage, list[0].TreatmentNo.AsString(""), Total.ToString("f2"), list[0].DeptName, list[0].DiagnosisName, list[0].PatientName, list[0].Sex, list[0].Age, list[0].DoctorName, list[0].UpdateTime, list[0].PrescriptionType, "0", list[0].PayType };
                dt.Rows.Add(row);
            }


            return dt;
        }
        /// <summary>
        /// 组装草药
        /// </summary>
        /// <param name="dt">DataTable结构体</param>
        /// <param name="list">数据源</param>
        /// <returns></returns>
        private static DataTable BuildHerbalMedicine(DataTable dt, List<CIS.Model.Prescription> list, string PrescriptionNo)
        {
            string ItemName = "";
            string ItemUsage = "";
            int num = 0;
            string Total;
            Total = string.Format("{0:f2}", list.Sum(p => p.Total));
            foreach (CIS.Model.Prescription item in list)
            {
                //if (num > 3)
                //{
                //num = 1;
                ItemName = ItemName.TrimEnd((char[])" ".ToCharArray());
                DataRow row = dt.NewRow();
                string dosageUnit = "";
                if (item.DosageUnit == "颗粒" && item.PackingUnit == "袋")
                    dosageUnit = "[颗粒]";
                else if (item.DosageUnit != "颗粒" && item.PackingUnit == "袋")
                    dosageUnit = "[" + item.Specification + "]";
                List<IView_HIS_DrugUsage> tmp = Usage.Where(p => p.Code == item.Usage.Trim()).ToList();
                string UsageName = "";
                if (tmp.Count == 0)
                    UsageName = "JF";
                else
                    UsageName = tmp[0].Name;
                ItemName = item.ItemName + dosageUnit + " " + item.Amount.AsFloat(1) + item.PackingUnit + ((item.Usage.ToUpper() == "JF" || item.Usage.ToUpper() == "CF") ? " " : string.Format(" ({0})", UsageName).PadRight(5, ' '));
                row.ItemArray = new object[] { ItemName, ItemUsage, list[0].TreatmentNo.AsString(""), Total, list[0].DeptName, list[0].DiagnosisName, list[0].PatientName, list[0].Sex, list[0].Age, list[0].DoctorName, list[0].UpdateTime, list[0].PrescriptionType, "0", list[0].PayType, item.ConditionSummary, "", "", list[0].TreatmentNo, list[0].HerbalMedicineNum, PrescriptionNo };
                row["HerbsGroupName"] = item.HerbsGroupName;
                dt.Rows.Add(row);
                num++;
                //}

                //ItemUsage = "口服" + Environment.NewLine + item.Frequency + " " + "×" + " " + item.Days + "天";
            }

            //if (ItemName != "")
            //{
            //    ItemName = ItemName.TrimEnd((char[])"     ".ToCharArray());
            //    DataRow row = dt.NewRow();
            //    row.ItemArray = new object[] { ItemName, ItemUsage, list[0].TreatmentNo.AsString(""), Total, list[0].DeptName, list[0].DiagnosisName, list[0].PatientName, list[0].Sex, list[0].Age, list[0].DoctorName, list[0].UpdateTime, list[0].PrescriptionType, "0", list[0].PayType, list[0].ConditionSummary, "", "", list[0].TreatmentNo, list[0].HerbalMedicineNum };
            //    dt.Rows.Add(row);
            //}

            return dt;
        }
        /// <summary>
        /// 组装检验检查
        /// </summary>
        /// <param name="dt">DataTable结构体</param>
        /// <param name="list">数据源</param>
        /// <returns></returns> 
        private static DataTable BuildInspection(DataTable dt, List<CIS.Model.Prescription> list)
        {
            string ItemUsage = "";
            string Total;
            Total = string.Format("{0:f2}", list.Sum(p => p.Total));
            list = list.Where(p => p.IsAdditional != 1).ToList();

            string Phone = DBHelper.CIS.From<OP_Journal>().Where(p => p.OutpatientNo == SysContext.GetCurrPatient.OutpatientNo).Select(p => p.PhoneNumber).ToFirst<string>();

            int index = 1;
            //string itemName = "";
            foreach (CIS.Model.Prescription item in list)
            {
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { index.ToString() + "." + item.ItemName, ItemUsage, list[0].TreatmentNo.AsString(""), Total, list[0].DeptName, list[0].DiagnosisName, list[0].PatientName, list[0].Sex, list[0].Age, list[0].DoctorName, list[0].UpdateTime, list[0].PrescriptionType, "0", list[0].PayType, list[0].ConditionSummary, list[0].Explanation, list[0].Specimen, list[0].TreatmentNo, list[0].HerbalMedicineNum, "", Phone, list[0].DoctorPhone == null ? "" : string.Format("[{0}]", list[0].DoctorPhone) };
                dt.Rows.Add(row);
                index++;

            }



            return dt;
        }
    }
}
