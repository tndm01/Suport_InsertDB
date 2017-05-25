using System;
using System.Data;

namespace Support_InsertDB_SoatVe_Commit_VETC
{
    public class OUT_CheckTollTicket
    {
        public Guid OutCheckTollTicketID { set; get; }
        public string TransactionID { set; get; }
        public string ReceiptNo { set; get; }
        public string TollTicketID { set; get; }
        public string CheckDate { set; get; }
        public string TicketTypeCode { set; get; }
        public string VehicleTypeCode { set; get; }
        public string RouteCode { set; get; }
        public string TollFee { set; get; }
        public string EmployeeCode { set; get; }
        public string ShiftCode { set; get; }
        public string LaneCode { set; get; }
        public string StationCode { set; get; }
        public string RecogPlateNumber { set; get; }
        public string TransactionStatus { set; get; }
        public string EntryTransactionID { set; get; }
        public string PassType { set; get; }
        public bool Status { set; get; }// Nếu Status == 0 là chưa có, == 1 có rồi.

        public static OUT_CheckTollTicket CreateCheckTollTicket(string CheckTollTicketViewModel)
        {
            return new OUT_CheckTollTicket()
            {
                OutCheckTollTicketID = Guid.NewGuid(),
                TransactionID = CheckTollTicketViewModel.Split('|')[1].Substring(14),
                ReceiptNo = CheckTollTicketViewModel.Split('|')[2].Substring(10),
                TollTicketID = CheckTollTicketViewModel.Split('|')[3].Substring(13),
                CheckDate = Support.Ultinity.CONVERTddMMyyyyHHmmssTOyyyyMMddHHmmss(CheckTollTicketViewModel.Replace("/", "-")),
                TicketTypeCode = CheckTollTicketViewModel.Split('|')[5].Substring(15),
                VehicleTypeCode = CheckTollTicketViewModel.Split('|')[6].Substring(16),
                RouteCode = CheckTollTicketViewModel.Split('|')[7].Substring(10),
                TollFee = CheckTollTicketViewModel.Split('|')[8].Substring(8),
                EmployeeCode = CheckTollTicketViewModel.Split('|')[9].Substring(13),
                ShiftCode = CheckTollTicketViewModel.Split('|')[10].Substring(10),
                LaneCode = CheckTollTicketViewModel.Split('|')[11].Substring(9),
                StationCode = CheckTollTicketViewModel.Split('|')[12].Substring(12),
                RecogPlateNumber = CheckTollTicketViewModel.Split('|')[13].Substring(17),
                TransactionStatus = CheckTollTicketViewModel.Split('|')[14].Substring(18),
                EntryTransactionID = CheckTollTicketViewModel.Split('|')[15].Substring(19),
                PassType = CheckTollTicketViewModel.Split('|')[16].Substring(9),
            };
        }

        public static bool CheckOutStatus(OUT_CheckTollTicket out_checkTicket)//Kiểm tra có tồn tại hay không?
        {
            DataBase.DAL da = new DataBase.DAL(@"SOFT-W\SQL_EX_2012", "sa", "123456", "HLDEP_NH51");
            using (DataTable dt = da.selectDataBase("OUT_CheckTollTicket", "count(*)", "TransactionID = '" + out_checkTicket.TransactionID + "' and LaneCode = '" + out_checkTicket.LaneCode + "'"))
            {
                if (dt.Rows[0][0].ToString().Equals("0"))
                {
                    return false;
                }
                return true;
            }
        }

        public void InsertDB(ref DataBase.DAL da)
        {
            using (DataTable dt = da.selectDataBase("OUT_CheckTollTicket", "count(*)", "TransactionID = '" + this.TransactionID + "' and LaneCode = '" + LaneCode + "'"))
            {
                if (dt.Rows[0][0].ToString().Equals("0"))
                {
                    da.insertDataBase("OUT_CheckTollTicket",
                        "([OutCheckTollTicketID],[TransactionID],[ReceiptNo],[TollTicketID]" +
                        ",[CheckDate],[TicketTypeCode],[VehicleTypeCode],[RouteCode],[TollFee]" +
                        ",[EmployeeCode],[ShiftCode],[LaneCode],[StationCode],[RecogPlateNumber]" +
                        ",[TransactionStatus],[EntryTransactionID],[PassType])",

                        "('" + this.OutCheckTollTicketID + "'," +
                        "'" + this.TransactionID + "'," +
                        "'" + this.ReceiptNo + "'," +
                        "'" + this.TollTicketID + "'," +
                        "'" + this.CheckDate + "'," +
                        "'" + this.TicketTypeCode + "'," +
                        "'" + this.VehicleTypeCode + "'," +
                        "'" + this.RouteCode + "'," +
                        "'" + this.TollFee + "'," +
                        "'" + this.EmployeeCode + "'," +
                        "'" + this.ShiftCode + "'," +
                        "'" + this.LaneCode + "'," +
                        "'" + this.StationCode + "'," +
                        "'" + this.RecogPlateNumber + "'," +
                        "'" + this.TransactionStatus + "'," +
                        "'" + this.EntryTransactionID + "'," +
                        "'" + this.PassType + "')"
                        );
                }
                else
                {
                    Log.LogFile.writeLog(Log.LogFile.DIR, "SQLInsertMessage_" + Log.LogFile.getTimeStringNow() + ".txt", Log.LogFile.Filemode.GHIDE, "TransactionID = '" + this.TransactionID + "' and LaneCode = '" + LaneCode + "' Đã tồn tại trong hệ thống");
                }
            }
        }
    }
}