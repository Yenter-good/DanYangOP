using App_OP.PrescriptionCirculation.AuditResult;
using App_OP.PrescriptionCirculation.Inventory;
using App_OP.PrescriptionCirculation.PreAudit;
using App_OP.PrescriptionCirculation.TakeDrugResult;
using App_OP.PrescriptionCirculation.Undo;
using App_OP.PrescriptionCirculation.Upload;
using App_OP.PrescriptionCirculation.UploadSign;
using App_OP.PrescriptionCirculation.ViewPrescription;
using CIS.Core;
using CIS.Model;
using CIS.Utility;
using CIS.Utility.Helpers;
using DevComponents.DotNetBar.Controls;
using Dos.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_OP.PrescriptionCirculation
{
    public partial class FormPrescriptionCirculation : BaseForm
    {
        private bool WMKeyDown = false;
        private DataGridViewColumn[] _nextColumns;
        private List<IView_HIS_DrugUsage> usage;
        private List<OP_Dic_Interval> interval;

        private OP_PrescriptionCirculation _currentPrescriptionCirculation;
        private List<OP_PrescriptionCirculation_Detail> _currentPrescriptionCirculationDetails;

        public FormPrescriptionCirculation()
        {
            InitializeComponent();
        }

        private void Init()
        {
            if (PrescriptionCirculationHandler.DrugInfos == null)
                PrescriptionCirculationHandler.DrugInfos = DBHelper.CIS.From<IView_PrescriptionCirculation_DrugInfo>().ToList();

            PrescriptionCirculationHandler.NewPatientHandler += PrescriptionCirculationHandler_NewPatientHandler;

            this.dgvWesternMedicine.AutoGenerateColumns = false;
            this.dgvWesternMedicineDetail.AutoGenerateColumns = false;

            _nextColumns = new DataGridViewColumn[] { XY_colName, XY_colYL, XY_colYF, XY_colJG, colDay, XY_colSL };

            usage = DBHelper.CIS.From<IView_HIS_DrugUsage>().ToList();
            this.XY_colYF.DataSource = usage.Where(p => p.Type == "1").ToList();
            this.XY_colYF.DisplayMember = "Name";
            this.XY_colYF.ValueMember = "Code";

            interval = DBHelper.CIS.From<OP_Dic_Interval>().ToList();
            this.XY_colJG.DataSource = interval;
            this.XY_colJG.DisplayMember = "Name";
            this.XY_colJG.ValueMember = "Code";

            this.InitPrescription();
        }

        private void PrescriptionCirculationHandler_NewPatientHandler(object sender, EventArgs e)
        {
            this.dgvPrescription.Rows.Clear();
            this.dgvWesternMedicine.Rows.Clear();
            _currentPrescriptionCirculation = null;
            btnXYAdd.Enabled = false;
            btnXYDel.Enabled = false;
            btnXYSave.Enabled = false;

            this.InitPrescription();
        }

        private void FormPrescriptionCirculation_Shown(object sender, EventArgs e)
        {
            this.Init();
        }

        private void NewPrescription()
        {
            if (SysContext.GetCurrPatient == null)
            {
                AlertBox.Error("未选择病人,无法新建");
                return;
            }
            btnXYAdd.Enabled = true;
            btnXYDel.Enabled = true;
            btnXYSave.Enabled = true;

            this.dgvWesternMedicine.Rows.Clear();
            this.dgvWesternMedicine.Rows.Add();
            this.dgvWesternMedicine.CurrentCell = this.dgvWesternMedicine.Rows[0].Cells[XY_colName.Index];
            this.dgvWesternMedicine.BeginEdit(true);
        }

        private void NewLine()
        {
            this.dgvWesternMedicine.EndEdit();
            if (!this.ValidationLine(this.dgvWesternMedicine.CurrentRow))
                return;

            foreach (DataGridViewRow row in this.dgvWesternMedicine.Rows)
            {
                if (row.Tag == null)
                {
                    this.dgvWesternMedicine.CurrentCell = row.Cells[XY_colName.Index];
                    this.dgvWesternMedicine.BeginEdit(true);
                    return;
                }
            }

            var newRow = this.dgvWesternMedicine.Rows[this.dgvWesternMedicine.Rows.Add()];

            this.dgvWesternMedicine.CurrentCell = newRow.Cells[XY_colName.Index];
            this.dgvWesternMedicine.BeginEdit(true);
        }

        private void InitPrescription()
        {
            if (SysContext.GetCurrPatient == null)
            {
                AlertBox.Error("未选择病人");
                return;
            }

            var prescriptions = DBHelper.CIS.From<OP_PrescriptionCirculation>().Where(p => p.IDCard == SysContext.GetCurrPatient.IDCard).OrderByDescending(p => p.UpdateTime).ToList();

            this.dgvPrescription.Rows.Clear();
            foreach (var prescription in prescriptions)
            {
                var newRow = this.dgvPrescription.Rows[this.dgvPrescription.Rows.Add()];
                newRow.Cells[colPrescriptionId.Index].Value = prescription.PrescriptionNo;
                var state = (PrescriptionCirculationState)prescription.Status;
                if (state == 0)
                    newRow.Cells[colState.Index].Value = "未上传";
                else
                    newRow.Cells[colState.Index].Value = state.GetDescription();

                newRow.Tag = prescription;
            }
        }

        private bool ValidationLine(DataGridViewRow row)
        {
            if (row == null || row.Tag == null)
                return true;

            var dosage = row.Cells[XY_colYL.Index].Value.AsString("");
            if (!decimal.TryParse(dosage, out _))
            {
                AlertBox.Info("一次用量必须为数字");
                this.dgvWesternMedicine.CurrentCell = row.Cells[XY_colYL.Index];
                this.dgvWesternMedicine.BeginEdit(true);
                return false;
            }

            var day = row.Cells[colDay.Index].Value.AsString("");
            var quantity = row.Cells[XY_colSL.Index].Value.AsString("");

            if (!int.TryParse(day, out var rightDay) || rightDay <= 0)
            {
                AlertBox.Info("天数必须为正整数");
                this.dgvWesternMedicine.CurrentCell = row.Cells[colDay.Index];
                this.dgvWesternMedicine.BeginEdit(true);
                return false;
            }

            if (!int.TryParse(quantity, out var rightQuantity) || rightQuantity <= 0)
            {
                AlertBox.Info("数量必须为正整数");
                this.dgvWesternMedicine.CurrentCell = row.Cells[XY_colSL.Index];
                this.dgvWesternMedicine.BeginEdit(true);
                return false;
            }

            return true;
        }

        private void btnXYDel_Click(object sender, EventArgs e)
        {
            var selectedRow = this.dgvWesternMedicine.CurrentCell?.OwningRow;
            if (selectedRow == null)
                return;

            this.dgvWesternMedicine.Rows.Remove(selectedRow);
        }

        private void btnXYNew_Click(object sender, EventArgs e)
        {

            this.NewPrescription();
        }

        private void btnXYAdd_Click(object sender, EventArgs e)
        {
            this.NewLine();
        }

        private void dgvWesternMedicine_Text_Changed(object sender, EventArgs e)
        {
            if (this.dgvWesternMedicine.CurrentCell.ColumnIndex == this.XY_colName.Index)
            {
                if (this.dgvWesternMedicine.CurrentCell.OwningRow.Tag != null)
                {
                    this.dgvWesternMedicine.CurrentCell.OwningRow.Tag = null;
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colGG.Index].Value = "";
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colYLDW.Index].Value = "";
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colGGDW.Index].Value = "";
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colYPCD.Index].Value = "";
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colSL.Index].Value = "";
                    this.dgvWesternMedicine.CurrentRow.Cells[colDay.Index].Value = "";
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colYF.Index].Value = "";
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colYL.Index].Value = "";
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colJG.Index].Value = "";
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colYF.Index].Value = "";
                }
                string InputStr = (sender as TextBox).Text.ToUpper();
                if (InputStr == "")
                {
                    this.dgvWesternMedicineDetail.Hide();
                    return;
                }
                var Tmp = PrescriptionCirculationHandler.DrugInfos.Where(p => p.SpellCode.Contains(InputStr) || p.DrugName.Contains(InputStr)).Take(40).ToList();
                Tmp = Tmp.OrderBy(p => p.NickName.Length).ToList();

                ColculateDetailDGVTop();
                this.dgvWesternMedicineDetail.DataSource = Tmp;
                this.dgvWesternMedicineDetail.Show();
            }
        }

        private void ColculateDetailDGVTop()
        {
            Rectangle rect = this.dgvWesternMedicine.GetCellDisplayRectangle(this.dgvWesternMedicine.CurrentCell.ColumnIndex, this.dgvWesternMedicine.CurrentCell.RowIndex, false);
            Point p1 = this.dgvWesternMedicine.PointToScreen(new Point(rect.X, rect.Y));
            Point p2 = this.panel1.PointToClient(p1);

            ColculateDetailDGVTop(p2.Y, rect.Height, this.dgvWesternMedicineDetail);
        }

        private void ColculateDetailDGVTop(int CellTop, int CellHeight, DataGridViewX dgv)
        {
            int sub = this.panel1.Height - CellTop - CellHeight;
            if (sub > CellTop)
            {
                dgv.Top = CellTop + CellHeight;
                dgv.Height = sub - 5;
            }
            else
            {
                dgv.Top = 0;
                dgv.Height = CellTop;
            }

        }

        private void dgvWesternMedicine_TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (this.dgvWesternMedicine.CurrentCell.IsInEditMode && this.dgvWesternMedicine.CurrentCell.ColumnIndex == this.XY_colName.Index)
                {
                    CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(this.dgvWesternMedicineDetail.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_KEYDOWN, e.KeyValue, 0);
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (WMKeyDown)
                    {
                        WMKeyDown = false;
                        e.SuppressKeyPress = false;
                    }
                    else
                    {
                        WMKeyDown = true;
                        DataGridViewCell cell = this.dgvWesternMedicine.CurrentCell;
                        if (cell.OwningRow.Index > 0 && e.KeyCode == Keys.Up)
                            this.dgvWesternMedicine.CurrentCell = this.dgvWesternMedicine.Rows[cell.OwningRow.Index - 1].Cells[cell.ColumnIndex];
                        else if (cell.OwningRow.Index < this.dgvWesternMedicine.Rows.Count - 1 && e.KeyCode == Keys.Down)
                            this.dgvWesternMedicine.CurrentCell = this.dgvWesternMedicine.Rows[cell.OwningRow.Index + 1].Cells[cell.ColumnIndex];
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colName" && this.dgvWesternMedicine.CurrentCell.EditedFormattedValue.AsString("") == "")
                {
                    return;
                }

                if (this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colName" && this.dgvWesternMedicine.CurrentCell.IsInEditMode && !this.dgvWesternMedicineDetail.Visible)
                {
                    return;
                }

                if (this.dgvWesternMedicine.CurrentCell.OwningColumn.Name == "XY_colName" && this.dgvWesternMedicineDetail.Visible)
                {
                    if (this.dgvWesternMedicineDetail.SelectedRows.Count == 0)
                    {
                        return;
                    }
                    this.dgvWesternMedicine.EndEdit();
                    var drug = this.dgvWesternMedicineDetail.SelectedRows[0].DataBoundItem as IView_PrescriptionCirculation_DrugInfo;

                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colName.Index].Value = drug.DrugName;
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colGG.Index].Value = drug.Specification;
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colYLDW.Index].Value = drug.MinDoseUnit;
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colGGDW.Index].Value = drug.PackingUnit;
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colYPCD.Index].Value = drug.ProductionSites;
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colSL.Index].Value = 1;
                    this.dgvWesternMedicine.CurrentRow.Cells[colDay.Index].Value = 1;
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colYF.Index].Value = 1;
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colYL.Index].Value = 1;
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colJG.Index].Value = interval.First().Code;
                    this.dgvWesternMedicine.CurrentRow.Cells[XY_colYF.Index].Value = usage.First().Code;

                    this.dgvWesternMedicine.CurrentRow.Tag = drug;
                    this.dgvWesternMedicineDetail.Hide();
                    e.SuppressKeyPress = false;
                    Application.DoEvents();

                    this.dgvWesternMedicine.CurrentCell = this.dgvWesternMedicine.CurrentRow.Cells[XY_colYL.Index];
                    this.dgvWesternMedicine.BeginEdit(true);
                }
                else
                {
                    var index = Array.IndexOf(_nextColumns, this.dgvWesternMedicine.CurrentCell.OwningColumn);
                    if (index != -1)
                    {
                        if (index == _nextColumns.Length - 1)
                        {
                            this.NewLine();
                        }
                        else
                        {
                            this.dgvWesternMedicine.CurrentCell = this.dgvWesternMedicine.CurrentRow.Cells[_nextColumns[index + 1].Index];
                            Application.DoEvents();
                            this.dgvWesternMedicine.BeginEdit(true);
                        }
                    }
                }
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) && this.dgvWesternMedicineDetail.Visible)
            {
                this.dgvWesternMedicineDetail.Hide();
            }
        }

        private void dgvWesternMedicine_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (this.dgvWesternMedicine.Rows[e.RowIndex].Cells[e.ColumnIndex].EditType == typeof(DataGridViewComboBoxExEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void btnXYSave_Click(object sender, EventArgs e)
        {
            int index = 0;
            this.dgvWesternMedicine.EndEdit();

            long? prescriptionNo = null;
            var isNewPrescription = (_currentPrescriptionCirculation == null);

            if (isNewPrescription)
                prescriptionNo = IdHelper.GuidToLongID();
            else
                prescriptionNo = _currentPrescriptionCirculation.PrescriptionNo;

            List<OP_PrescriptionCirculation_Detail> insertDetails = new List<OP_PrescriptionCirculation_Detail>();
            List<OP_PrescriptionCirculation_Detail> updateDetails = new List<OP_PrescriptionCirculation_Detail>();
            IEnumerable<OP_PrescriptionCirculation_Detail> deleteDetails = null;
            foreach (DataGridViewRow row in this.dgvWesternMedicine.Rows)
            {
                var valid = this.ValidationLine(row);
                if (!valid)
                    return;

                if (row.Tag == null)
                    continue;
                OP_PrescriptionCirculation_Detail detail = null;

                if (row.Tag is OP_PrescriptionCirculation_Detail tag)
                {
                    detail = this.OldDetail(tag, row, index++);
                    updateDetails.Add(detail);
                }
                else if (row.Tag is IView_PrescriptionCirculation_DrugInfo drug)
                {
                    detail = this.NewDetail(drug, row, prescriptionNo.Value, index++);
                    insertDetails.Add(detail);
                }
            }

            if (isNewPrescription)
            {
                _currentPrescriptionCirculation = new OP_PrescriptionCirculation()
                {
                    Age = SysContext.GetCurrPatient.Age,
                    CardNo = SysContext.GetCurrPatient.CardNo,
                    DeptCode = SysContext.GetCurrPatient.DeptCode,
                    DoctorPhone = SysContext.CurrUser.user.DoctorPhone,
                    IDCard = SysContext.GetCurrPatient.IDCard,
                    PatientID = SysContext.GetCurrPatient.PatientID,
                    PatientName = SysContext.GetCurrPatient.PatientName,
                    PayType = SysContext.GetCurrPatient.PayType,
                    PrescriptionNo = prescriptionNo.Value,
                    RecordNumber = insertDetails.Count + updateDetails.Count,
                    Sex = SysContext.GetCurrPatient.Sex,
                    Status = 0,
                    TreatmentNo = SysContext.GetCurrPatient.OutpatientNo,
                    UpdateTime = DateTime.Now,
                    UserID = SysContext.CurrUser.UserId,
                    UserName = SysContext.CurrUser.UserName,
                    UploadFlag = false
                };
            }
            else
            {
                _currentPrescriptionCirculation.RecordNumber = insertDetails.Count + updateDetails.Count;
                _currentPrescriptionCirculation.UpdateTime = DateTime.Now;
                if (_currentPrescriptionCirculationDetails == null)
                    deleteDetails = null;
                else
                    deleteDetails = _currentPrescriptionCirculationDetails.Except(insertDetails.Union(updateDetails), new PrescriptionEqu());
            }

            InventoryHelper inventoryHelper = new InventoryHelper();
            var result = inventoryHelper.Handler(PrescriptionCirculationHandler.DrugInfos, _currentPrescriptionCirculation, insertDetails.Union(updateDetails).ToList());
            if (!result.pass)
            {
                AlertBox.Error("药品库存校验失败:" + result.msg);
                return;
            }

            using (var tran = DBHelper.CIS.BeginTransaction())
            {
                try
                {
                    if (isNewPrescription)
                        tran.Insert(_currentPrescriptionCirculation);
                    else
                        tran.Update(_currentPrescriptionCirculation);

                    tran.Insert(insertDetails);
                    tran.Update(updateDetails);

                    if (deleteDetails != null)
                        tran.Delete(deleteDetails);

                    tran.Commit();
                    AlertBox.Info("保存成功");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    AlertBox.Error("保存失败\r\n" + ex.Message);
                    return;
                }
            }

            this.InitPrescription();

            //var prescriptionClone = SerializeHelper.BeginJsonDeserialize<OP_PrescriptionCirculation>(SerializeHelper.BeginJsonSerializable(_currentPrescriptionCirculation));
            //UploadPrescription(prescriptionClone, insertDetails.Union(updateDetails).ToList());

            this.dgvWesternMedicine.Rows.Clear();
            _currentPrescriptionCirculation = null;

        }

        /// <summary>
        /// 0上传中 1上传完成 2上传失败 3撤回
        /// </summary>
        /// <param name="prescriptionNo"></param>
        /// <param name="state"></param>
        private void ChangePrescriptionUploadState(long prescriptionNo, int state, string hiRxno = "")
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                string text = "";
                text = ((PrescriptionCirculationState)state).GetDescription();

                foreach (DataGridViewRow row in this.dgvPrescription.Rows)
                {
                    if (row.Tag is OP_PrescriptionCirculation prescription && prescription.PrescriptionNo == prescriptionNo)
                    {
                        row.Cells[colState.Index].Value = text;
                        if (state == (int)PrescriptionCirculationState.Complete)
                            prescription.PrescriptionCirculationNo = hiRxno;
                        return;
                    }
                }
            });
        }

        private OP_PrescriptionCirculation_Detail NewDetail(IView_PrescriptionCirculation_DrugInfo drug, DataGridViewRow row, long prescriptionNo, int index)
        {
            OP_PrescriptionCirculation_Detail detail = new OP_PrescriptionCirculation_Detail()
            {
                ID = Guid.NewGuid().ToString(),
                Amount = Convert.ToDecimal(row.Cells[XY_colYL.Index].Value),
                Days = Convert.ToInt32(row.Cells[colDay.Index].Value),
                DosageUnit = drug.MinDoseUnit,
                Frequency = row.Cells[XY_colJG.Index].Value.AsString(""),
                ItemCode = drug.CityCode,
                ItemName = drug.DrugName,
                ItemType = drug.DrugCategory,
                ItemTypeName = drug.DrugForm,
                No = index++,
                Number = Convert.ToInt32(row.Cells[XY_colSL.Index].Value),
                PackingUnit = drug.PackingUnit,
                PatientID = SysContext.GetCurrPatient.PatientID,
                PrescriptionNo = prescriptionNo,
                ProductionSites = drug.ProductionSites,
                Specification = drug.Specification,
                TreatmentNo = SysContext.GetCurrPatient.OutpatientNo,
                UpdateTime = DateTime.Now,
                Usage = row.Cells[XY_colYF.Index].Value.AsString("")
            };

            return detail;
        }

        private OP_PrescriptionCirculation_Detail OldDetail(OP_PrescriptionCirculation_Detail detail, DataGridViewRow row, int index)
        {
            detail.Amount = Convert.ToDecimal(row.Cells[XY_colYL.Index].Value);
            detail.Days = Convert.ToInt32(row.Cells[colDay.Index].Value);
            detail.Frequency = row.Cells[XY_colJG.Index].Value.AsString("");
            detail.Number = Convert.ToInt32(row.Cells[XY_colSL.Index].Value);
            detail.Usage = row.Cells[XY_colYF.Index].Value.AsString("");
            detail.No = index;

            return detail;
        }

        private void 查看双流转处方信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedRows = this.dgvPrescription.SelectedRows;
            if (selectedRows.Count == 0)
                return;

            var selectedRow = selectedRows[0];
            var prescription = selectedRow.Tag as OP_PrescriptionCirculation;

            ViewPrescriptionHelper viewPrescription = new ViewPrescriptionHelper();
            var data = viewPrescription.Handler(prescription);
            if (data == null)
                return;
            FormPrescriptionCirculationPreview preview = new FormPrescriptionCirculationPreview();
            preview.Init(data);
            preview.ShowDialog();
        }

        private void 查看双流转处方审核结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedRows = this.dgvPrescription.SelectedRows;
            if (selectedRows.Count == 0)
                return;

            var selectedRow = selectedRows[0];
            var prescription = selectedRow.Tag as OP_PrescriptionCirculation;

            AuditResultHelper auditResult = new AuditResultHelper();
            var data = auditResult.Handler(prescription);
            if (data == null)
                return;
            FormAuditResult preview = new FormAuditResult();
            preview.Init(data);
            preview.ShowDialog();
        }

        private void 查看双流转取药结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedRows = this.dgvPrescription.SelectedRows;
            if (selectedRows.Count == 0)
                return;

            var selectedRow = selectedRows[0];
            var prescription = selectedRow.Tag as OP_PrescriptionCirculation;

            TakeDrugResultHelper takeDrug = new TakeDrugResultHelper();
            var data = takeDrug.Handler(prescription);
            if (data == null)
                return;
            FormTakeDrugResultPreview preview = new FormTakeDrugResultPreview();
            preview.Init(data);
            preview.ShowDialog();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var selectedRows = this.dgvPrescription.SelectedRows;
            if (selectedRows.Count == 0)
                return;

            var selectedRow = selectedRows[0];
            var prescription = selectedRow.Tag as OP_PrescriptionCirculation;
            var state = DBHelper.CIS.From<OP_PrescriptionCirculation>().Where(p => p.PrescriptionNo == prescription.PrescriptionNo).Select(p => p.Status).ToScalar<int>();
            if (state == 1)
            {
                MessageBox.Show("该处方已经上传");
                return;
            }

            var allDetails = DBHelper.CIS.From<OP_PrescriptionCirculation_Detail>().Where(p => p.PrescriptionNo == prescription.PrescriptionNo).ToList();

            UploadPrescription(prescription, allDetails);
        }

        private void UploadPrescription(OP_PrescriptionCirculation prescription, List<OP_PrescriptionCirculation_Detail> allDetails)
        {
            new System.Threading.Thread(() =>
            {
                bool success = false;

                ChangePrescriptionUploadState(prescription.PrescriptionNo, 0);

                var diagnosis = PrescriptionCirculationHandler.GetPatientDiagnoses();
                var preAudit = new UploadPreAuditHelper();
                var auditResult = preAudit.Handler(prescription, allDetails, PrescriptionCirculationHandler.DrugInfos, usage, diagnosis, interval);
                if (auditResult != null)
                {
                    var sign = new UploadPrescriptionSignHelper();
                    var signResult = sign.Handler(auditResult, prescription, allDetails.Count.ToString());
                    if (signResult.Item1 != null)
                    {
                        var upload = new UploadPrescriptionHelper();
                        var uploadResult = upload.Handler(signResult.Item1, signResult.Item2);
                        if (uploadResult != null)
                            success = true;
                    }
                }

                if (success)
                {
                    Dictionary<Dos.ORM.Field, object> update = new Dictionary<Dos.ORM.Field, object>();
                    update[OP_PrescriptionCirculation._.UploadFlag] = true;
                    update[OP_PrescriptionCirculation._.PrescriptionCirculationNo] = auditResult.hiRxno;
                    update[OP_PrescriptionCirculation._.Status] = 1;
                    DBHelper.CIS.Update<OP_PrescriptionCirculation>(update, d => d.PrescriptionNo == prescription.PrescriptionNo);

                    this.ChangePrescriptionUploadState(prescription.PrescriptionNo, 1, auditResult.hiRxno);

                }
                else
                {
                    this.ChangePrescriptionUploadState(prescription.PrescriptionNo, 2);
                    Dictionary<Dos.ORM.Field, object> update = new Dictionary<Dos.ORM.Field, object>();
                    update[OP_PrescriptionCirculation._.Status] = 2;
                    DBHelper.CIS.Update<OP_PrescriptionCirculation>(update, d => d.PrescriptionNo == prescription.PrescriptionNo);
                }
            }).Start();
        }

        private void btnUndoPrescription_Click(object sender, EventArgs e)
        {
            var selectedRows = this.dgvPrescription.SelectedRows;
            if (selectedRows.Count == 0)
                return;

            var prescriptions = selectedRows.Cast<DataGridViewRow>().Select(p => p.Tag as OP_PrescriptionCirculation).ToList();
            var prescriptionNos = prescriptions.Select(p => p.PrescriptionNo).ToList();
            List<long> successPrescriptionNo = new List<long>();
            var successPrescription = DBHelper.CIS.From<OP_PrescriptionCirculation>().Where(p => p.Status == 1 && p.PrescriptionNo.In(prescriptionNos)).Select(p => new
            {
                p.PrescriptionNo,
                p.PrescriptionCirculationNo
            }).ToList();

            UndoPrescriptionHelper helper = new UndoPrescriptionHelper();
            FormPrescriptionCirculationUndo form = new FormPrescriptionCirculationUndo();
            if (form.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(form.Reason))
            {
                foreach (var prescription in successPrescription)
                {
                    if (!string.IsNullOrWhiteSpace(prescription.PrescriptionCirculationNo))
                    {
                        var result = helper.Handler(prescription, form.Reason);
                        if (result != null)
                            successPrescriptionNo.Add(prescription.PrescriptionNo);
                    }
                }
            }

            Dictionary<Dos.ORM.Field, object> update = new Dictionary<Dos.ORM.Field, object>();
            update[OP_PrescriptionCirculation._.UploadFlag] = false;
            update[OP_PrescriptionCirculation._.Status] = 3;
            update[OP_PrescriptionCirculation._.PrescriptionCirculationNo] = null;
            DBHelper.CIS.Update<OP_PrescriptionCirculation>(update, d => d.PrescriptionNo.In(successPrescriptionNo));
            foreach (var prescriptionNo in successPrescriptionNo)
                this.ChangePrescriptionUploadState(prescriptionNo, 3);

            if (successPrescriptionNo.Count > 0)
                AlertBox.Info("召回成功");
        }

        private void btnDelPrescription_Click(object sender, EventArgs e)
        {
            var selectedRows = this.dgvPrescription.SelectedRows;
            if (selectedRows.Count == 0)
                return;

            var prescriptions = selectedRows.Cast<DataGridViewRow>().ToDictionary(p => (p.Tag as OP_PrescriptionCirculation).PrescriptionNo, v => v);
            var prescriptionNos = prescriptions.Select(p => p.Key).ToList();
            var canDeletePrescriptionNos = DBHelper.CIS.From<OP_PrescriptionCirculation>().Where(p => p.PrescriptionNo.In(prescriptionNos) && p.Status != 1).Select(p => p.PrescriptionNo).ToList<long>();

            foreach (var prescriptionNo in canDeletePrescriptionNos)
                this.dgvPrescription.Rows.Remove(prescriptions[prescriptionNo]);

            DBHelper.CIS.Delete<OP_PrescriptionCirculation>(p => p.PrescriptionNo.In(canDeletePrescriptionNos));
            DBHelper.CIS.Delete<OP_PrescriptionCirculation_Detail>(p => p.PrescriptionNo.In(canDeletePrescriptionNos));

            if (canDeletePrescriptionNos.Count == selectedRows.Count)
                AlertBox.Info("删除成功");
            else
            {
                AlertBox.Info("删除成功，但存在已经更改了状态的处方无法删除");
                this.InitPrescription();
            }
        }

        private void FormPrescriptionCirculation_FormClosing(object sender, FormClosingEventArgs e)
        {
            PrescriptionCirculationHandler.NewPatientHandler -= PrescriptionCirculationHandler_NewPatientHandler;
        }

        private void dgvPrescription_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _currentPrescriptionCirculation = this.dgvPrescription.Rows[e.RowIndex].Tag as OP_PrescriptionCirculation;
            if (_currentPrescriptionCirculation == null)
                return;

            _currentPrescriptionCirculationDetails = DBHelper.CIS.From<OP_PrescriptionCirculation_Detail>().Where(p => p.PrescriptionNo == _currentPrescriptionCirculation.PrescriptionNo).ToList();

            this.dgvWesternMedicine.Rows.Clear();
            foreach (var detail in _currentPrescriptionCirculationDetails)
            {
                var newRow = this.dgvWesternMedicine.Rows[this.dgvWesternMedicine.Rows.Add()];
                newRow.Cells[XY_colName.Index].Value = detail.ItemName;
                newRow.Cells[XY_colGG.Index].Value = detail.Specification;
                newRow.Cells[XY_colYL.Index].Value = detail.Amount;
                newRow.Cells[XY_colYLDW.Index].Value = detail.DosageUnit;
                newRow.Cells[XY_colYF.Index].Value = usage.FirstOrDefault(p => p.Code == detail.Usage)?.Name;
                newRow.Cells[XY_colJG.Index].Value = interval.FirstOrDefault(p => p.Code == detail.Frequency)?.Name;
                newRow.Cells[colDay.Index].Value = detail.Days;
                newRow.Cells[XY_colSL.Index].Value = detail.Number;
                newRow.Cells[XY_colGGDW.Index].Value = detail.PackingUnit;
                newRow.Cells[XY_colYPCD.Index].Value = detail.ProductionSites;

                newRow.Tag = detail;
            }

            btnXYAdd.Enabled = true;
            btnXYDel.Enabled = true;
            btnXYSave.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var selectRows = this.dgvPrescription.SelectedRows;
            foreach (DataGridViewRow item in selectRows)
            {
                var prescription = item.Tag as OP_PrescriptionCirculation;
                Print.PrescriptionPrint(prescription.PrescriptionNo, prescription.PrescriptionCirculationNo, prescription.TreatmentNo);
            }
        }
    }

    internal enum PrescriptionCirculationState
    {
        [EnumDescription("上传中")]
        Uploading,
        [EnumDescription("上传完成")]
        Complete,
        [EnumDescription("上传失败")]
        Error,
        [EnumDescription("撤回")]
        Undo,
    }

    internal class PrescriptionEqu : IEqualityComparer<OP_PrescriptionCirculation_Detail>
    {
        public bool Equals(OP_PrescriptionCirculation_Detail x, OP_PrescriptionCirculation_Detail y)
        {
            if (x.ID == y.ID)
                return true;

            return false;
        }

        public int GetHashCode(OP_PrescriptionCirculation_Detail obj)
        {
            return obj.ID.GetHashCode();
        }
    }
}
