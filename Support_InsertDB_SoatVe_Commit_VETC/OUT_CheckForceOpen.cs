using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_InsertDB_SoatVe_Commit_VETC
{
    public class OUT_CheckForceOpen
    {
        public Guid OutCheckForceOpenID { set; get; }
        public string TransactionID { set; get; }
        public string CardID { set; get; }
        public string TicketID { set; get; }
        public string CheckDate { set; get; }
        public string TicketTypeCode { set; get; }
        public string VehicleTypeCode { set; get; }
        public string EmployeeCode { set; get; }
        public string ShiftCode { set; get; }
        public string LaneCode { set; get; }
        public string StationCode { set; get; }
        public string RecogPlateNumber { set; get; }
        public string TransactionStatus { set; get; }
        public string ForceType { set; get; }
        public bool Status { set; get; }// Nếu Status == 0 là chưa có, == 1 có rồi.

        public static OUT_CheckForceOpen CreateCheckForceOpen(string CheckForceOpenViewModel)
        {
            return new OUT_CheckForceOpen()
            {
                OutCheckForceOpenID = Guid.NewGuid(),
                TransactionID = CheckForceOpenViewModel.Split('|')[0],
                CardID = CheckForceOpenViewModel.Split('|')[1],
                TicketID = CheckForceOpenViewModel.Split('|')[2],
                CheckDate = Support.Ultinity.CONVERTddMMyyyyHHmmssTOyyyyMMddHHmmss(CheckForceOpenViewModel.Replace("/", "-")),
                TicketTypeCode = CheckForceOpenViewModel.Split('|')[4],
                VehicleTypeCode = CheckForceOpenViewModel.Split('|')[5],
                EmployeeCode = CheckForceOpenViewModel.Split('|')[6],
                ShiftCode = CheckForceOpenViewModel.Split('|')[7],
                LaneCode = CheckForceOpenViewModel.Split('|')[8],
                StationCode = CheckForceOpenViewModel.Split('|')[9],
                RecogPlateNumber = CheckForceOpenViewModel.Split('|')[10],
                TransactionStatus = CheckForceOpenViewModel.Split('|')[11],
                ForceType = CheckForceOpenViewModel.Split('|')[12]
            };
        }

        public static bool CheckOutStatus(OUT_CheckForceOpen out_checkForceOpen)//Kiểm tra có tồn tại hay không?
        {
            DataBase.DAL da = new DataBase.DAL(@"SOFT-W\SQL_EX_2012", "sa", "123456", "HLDEP_NH51");
            using (DataTable dt = da.selectDataBase("OUT_CheckForceOpen", "count(*)", "TransactionID = '" + out_checkForceOpen.TransactionID + "' and LaneCode = '" + out_checkForceOpen.LaneCode + "'"))
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
            using (DataTable dt = da.selectDataBase("OUT_CheckForceOpen", "count(*)", "TransactionID = '" + this.TransactionID + "' and LaneCode = '" + LaneCode + "'"))
            {
                if (dt.Rows[0][0].ToString().Equals("0"))
                {
                    da.insertDataBase("OUT_CheckForceOpen",
                        "([OutCheckForceOpenID],[TransactionID],[CardID],[CheckDate]" +
                        ",[TicketTypeCode],[VehicleTypeCode],[EmployeeCode],[ShiftCode],[LaneCode]" +
                        ",[StationCode],[RecogPlateNumber],[TransactionStatus],[ForceType]",

                        "('" + this.OutCheckForceOpenID + "'," +
                        "'" + this.TransactionID + "'," +
                        "'" + this.CardID + "'," +
                        "'" + this.TicketID + "'," +
                        "'" + this.CheckDate + "'," +
                        "'" + this.TicketTypeCode + "'," +
                        "'" + this.VehicleTypeCode + "'," +
                        "'" + this.EmployeeCode + "'," +
                        "'" + this.ShiftCode + "'," +
                        "'" + this.LaneCode + "'," +
                        "'" + this.StationCode + "'," +
                        "'" + this.RecogPlateNumber + "'," +
                        "'" + this.TransactionStatus + "'," +
                        "'" + this.ForceType + "')"
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
