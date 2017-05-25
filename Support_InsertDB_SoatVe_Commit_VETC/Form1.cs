using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Support_InsertDB_SoatVe_Commit_VETC
{
    public partial class Form1 : Form
    {
        private List<OUT_CheckTollTicket> lstTran;

        private List<OUT_CheckForceOpen> lstOut_ForceOpne;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstTran = new List<OUT_CheckTollTicket>();
        }

        private void btnbrowserpathfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtpathfile.Text = ofd.FileName;
            }
            if (ofd != null)
            {
                ofd.Dispose();
                ofd = null;
            }
        }

        private void btnreadfile_Click(object sender, EventArgs e)
        {
            try
            {
                DBView.Rows.Clear();
                if (string.IsNullOrEmpty(txtpathfile.Text))
                {
                    MessageBox.Show("Vui lòng chọn file trước !");
                    return;
                }
                if (!File.Exists(txtpathfile.Text))
                {
                    MessageBox.Show("File không tồn tại !");
                    return;
                }

                if (radCheckOutTollTicket.Checked == true)
                {
                    using (FileStream fs = File.Open(txtpathfile.Text, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            List<OUT_CheckTollTicket> lstTemp = new List<OUT_CheckTollTicket>();
                            string dataLine = null;
                            while ((dataLine = sr.ReadLine()) != null)
                            {
                                if (dataLine == "")
                                {
                                    break;
                                }
                                else
                                {
                                    OUT_CheckTollTicket item = OUT_CheckTollTicket.CreateCheckTollTicket(dataLine);
                                    if (OUT_CheckTollTicket.CheckOutStatus(item))
                                    {
                                        item.Status = true;
                                    }
                                    else
                                    {
                                        item.Status = false;
                                    }
                                    lstTemp.Add(item);
                                }
                            }
                            lstTran = lstTemp;
                        }
                        fs.Close();
                    }
                    if (lstTran != null)
                    {
                        if (lstTran.Count > 0)
                        {
                            for (int i = 0; i < lstTran.Count; i++)
                            {
                                DataGridViewRow row = (DataGridViewRow)DBView.Rows[0].Clone();
                                row.Cells[0].Value = lstTran[i].OutCheckTollTicketID.ToString();
                                row.Cells[1].Value = lstTran[i].TransactionID.ToString();
                                row.Cells[2].Value = lstTran[i].ReceiptNo.ToString();
                                row.Cells[3].Value = lstTran[i].TollTicketID.ToString();
                                row.Cells[4].Value = lstTran[i].CheckDate.ToString();
                                row.Cells[5].Value = lstTran[i].TicketTypeCode.ToString();
                                row.Cells[6].Value = lstTran[i].VehicleTypeCode.ToString();
                                row.Cells[7].Value = lstTran[i].RouteCode.ToString();
                                row.Cells[8].Value = lstTran[i].TollFee.ToString();
                                row.Cells[9].Value = lstTran[i].EmployeeCode.ToString();
                                row.Cells[10].Value = lstTran[i].ShiftCode.ToString();
                                row.Cells[11].Value = lstTran[i].LaneCode.ToString();
                                row.Cells[12].Value = lstTran[i].StationCode.ToString();
                                row.Cells[13].Value = lstTran[i].RecogPlateNumber.ToString();
                                row.Cells[14].Value = lstTran[i].TransactionStatus.ToString();
                                row.Cells[15].Value = lstTran[i].EntryTransactionID.ToString();
                                row.Cells[16].Value = lstTran[i].PassType.ToString();
                                row.Cells[17].Value = lstTran[i].Status.ToString();
                                DBView.Rows.Add(row);
                            }
                        }
                    }
                }
                else
                {
                    using (FileStream fs = File.Open(txtpathfile.Text, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            List<OUT_CheckForceOpen> lstTemp = new List<OUT_CheckForceOpen>();
                            string dataLine = null;
                            while ((dataLine = sr.ReadLine()) != null)
                            {
                                if (dataLine == "")
                                {
                                    break;
                                }
                                else
                                {
                                    OUT_CheckForceOpen item = OUT_CheckForceOpen.CreateCheckForceOpen(dataLine);
                                    if (OUT_CheckForceOpen.CheckOutStatus(item))
                                    {
                                        item.Status = true;
                                    }
                                    else
                                    {
                                        item.Status = false;
                                    }
                                    lstTemp.Add(item);
                                }
                            }
                            lstOut_ForceOpne = lstTemp;
                        }
                        fs.Close();
                    }
                    if (lstOut_ForceOpne != null)
                    {
                        if (lstOut_ForceOpne.Count > 0)
                        {
                            for (int i = 0; i < lstOut_ForceOpne.Count; i++)
                            {
                                DataGridViewRow row = (DataGridViewRow)DBView.Rows[0].Clone();
                                row.Cells[0].Value = lstOut_ForceOpne[i].OutCheckForceOpenID.ToString();
                                row.Cells[1].Value = lstOut_ForceOpne[i].TransactionID.ToString();
                                row.Cells[2].Value = lstOut_ForceOpne[i].CardID.ToString();
                                row.Cells[3].Value = lstOut_ForceOpne[i].TicketID.ToString();
                                row.Cells[4].Value = lstOut_ForceOpne[i].CheckDate.ToString();
                                row.Cells[5].Value = lstOut_ForceOpne[i].TicketTypeCode.ToString();
                                row.Cells[6].Value = lstOut_ForceOpne[i].VehicleTypeCode.ToString();
                                row.Cells[7].Value = lstOut_ForceOpne[i].EmployeeCode.ToString();
                                row.Cells[8].Value = lstOut_ForceOpne[i].ShiftCode.ToString();
                                row.Cells[9].Value = lstOut_ForceOpne[i].LaneCode.ToString();
                                row.Cells[10].Value = lstOut_ForceOpne[i].StationCode.ToString();
                                row.Cells[11].Value = lstOut_ForceOpne[i].RecogPlateNumber.ToString();
                                row.Cells[12].Value = lstOut_ForceOpne[i].TransactionStatus.ToString();
                                row.Cells[13].Value = lstOut_ForceOpne[i].ForceType.ToString();
                                row.Cells[14].Value = lstOut_ForceOpne[i].Status.ToString();
                                DBView.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn Insert dữ liệu này chứ!", "Informaton", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Cancel) return;
            DataBase.DAL da = new DataBase.DAL(@"SOFT-W\SQL_EX_2012", "sa", "123456", "HLDEP_NH51");
            if (da.IsconnectionSusses)
            {
                foreach (OUT_CheckTollTicket item in lstTran)
                {
                    item.InsertDB(ref da);
                }
            }
        }

        private void radCheckOutTollTicket_CheckedChanged(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader(@"C:\Users\ThanhNhan\Desktop\testFile.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("table"))
                    {
                        string nameValue = reader.GetAttribute("name");
                        if (nameValue.Equals("OUT_CheckTollTicket"))
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    if (reader.Value == "OutCheckForceOpenID")
                                    {
                                        break;
                                    }
                                    DBView.Columns.Add(reader.Value, reader.Value);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void radCheckForceOpen_CheckedChanged(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader(@"C:\Users\ThanhNhan\Desktop\testFile.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("table"))
                    {
                        string nameValue = reader.GetAttribute("name");
                        if (nameValue.Equals("OUT_CheckForceOpen"))
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    DBView.Columns.Add(reader.Value, reader.Value);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}