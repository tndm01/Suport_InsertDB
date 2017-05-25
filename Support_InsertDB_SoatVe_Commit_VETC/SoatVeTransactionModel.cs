using System;
using System.Data;

namespace Support_InsertDB_SoatVe_Commit_VETC
{
    public class SoatVeTransactionModel
    {
        public Guid ID { set; get; }
        public string ObuID { set; get; }
        public string CheckDate { set; get; }
        public string CheckTime { set; get; }
        public string BeginBalance { set; get; }
        public string ChargeAmount { set; get; }
        public string Balance { set; get; }
        public string VehicleClassID { set; get; }
        public string LoginID { set; get; }
        public string LaneID { set; get; }
        public string ShiftID { set; get; }
        public string StationID { set; get; }
        public string RegisPlateNumber { set; get; }
        public string PlateType { set; get; }
        public string RecogPlateNumber { set; get; }
        public string IsIntelligentVeriField { set; get; }
        public string IntelVerifyResult { set; get; }
        public string ImageID { set; get; }
        public string ImageStatus { set; get; }
        public string IsOnlineCheck { set; get; }
        public string PeriodTicket { set; get; }
        public string Checker { set; get; }
        public string F0 { set; get; }
        public string F1 { set; get; }
        public string F2 { set; get; }
        public string TransactionStatus { set; get; }
        public string TicketID { set; get; }
        public string CheckInDate { set; get; }
        public string CommitDate { set; get; }
        public string ETCStatus { set; get; }

        public static SoatVeTransactionModel CreateTransactionbyString(string SoatVeTransactionModelString)
        {
            return new SoatVeTransactionModel()
            {
                ID = Guid.NewGuid(),
                ObuID = SoatVeTransactionModelString.Split('|')[0],
                CheckDate = Support.Ultinity.CONVERTddMMyyyyHHmmssTOyyyyMMddHHmmss(SoatVeTransactionModelString.Split('|')[1].Replace("/", "-")),
                CheckTime = SoatVeTransactionModelString.Split('|')[2],
                BeginBalance = "0",
                ChargeAmount = SoatVeTransactionModelString.Split('|')[3],
                Balance = SoatVeTransactionModelString.Split('|')[4],
                VehicleClassID = SoatVeTransactionModelString.Split('|')[5],
                LoginID = SoatVeTransactionModelString.Split('|')[6],
                LaneID = SoatVeTransactionModelString.Split('|')[7],
                ShiftID = SoatVeTransactionModelString.Split('|')[8],
                StationID = SoatVeTransactionModelString.Split('|')[9],
                RegisPlateNumber = SoatVeTransactionModelString.Split('|')[10],
                PlateType = SoatVeTransactionModelString.Split('|')[11],
                RecogPlateNumber = SoatVeTransactionModelString.Split('|')[12],
                IsIntelligentVeriField = SoatVeTransactionModelString.Split('|')[13],
                IntelVerifyResult = SoatVeTransactionModelString.Split('|')[14],
                ImageID = SoatVeTransactionModelString.Split('|')[15],
                ImageStatus = SoatVeTransactionModelString.Split('|')[16],
                IsOnlineCheck = SoatVeTransactionModelString.Split('|')[17],
                PeriodTicket = SoatVeTransactionModelString.Split('|')[18],
                Checker = Support.Ultinity.CONVERTddMMyyyyHHmmssTOyyyyMMddHHmmss(SoatVeTransactionModelString.Split('|')[19].Replace("/", "-")),
                F0 = SoatVeTransactionModelString.Split('|')[20],
                F1 = SoatVeTransactionModelString.Split('|')[21],
                F2 = SoatVeTransactionModelString.Split('|')[22],
                TransactionStatus = SoatVeTransactionModelString.Split('|')[23],
                TicketID = SoatVeTransactionModelString.Split('|')[24],
                CheckInDate = Support.Ultinity.CONVERTddMMyyyyHHmmssTOyyyyMMddHHmmss(SoatVeTransactionModelString.Split('|')[25].Replace("/", "-")),
                CommitDate = Support.Ultinity.CONVERTddMMyyyyHHmmssTOyyyyMMddHHmmss(SoatVeTransactionModelString.Split('|')[26].Replace("/", "-")),
                ETCStatus = SoatVeTransactionModelString.Split('|')[27]
            };
        }

        public void InsertDB(ref DataBase.DAL da)
        {
            using (DataTable dt = da.selectDataBase("TRP_tblCheckObuAccount_RFID", "count(*)", "ImageID = '" + this.ImageID + "' and LaneID = '" + LaneID + "'"))
            {
                if (dt.Rows[0][0].ToString().Equals("0"))
                {
                    da.insertDataBase("TRP_tblCheckObuAccount_RFID",

                        "([ObuID],[PrepaidAccountID],[CheckDate],[CheckTime],[BeginBalance],[ChargeAmount],[Balance],[VehicleClassID],[LoginID]" +
                        ",[LaneID],[ShiftID],[StationID] ,[RegisPlateNumber] ,[PlateType],[RecogPlateNumber],[IsIntelligentVerified],[IntelVerifyResult]" +
                        ",[ImageID],[ImageStatus],[PeriodTicket],[Checker],[SupervisionStatus],[PreSupervisionStatus],[F0],[F1],[F2],[SyncStatus]" +
                        ",[ModifyDate],[SyncReturnMsg],[FP],[FC],[TransactionStatus],[TicketID],[CheckInDate],[CommitDate],[ETCStatus],[FeeType]" +
                        ",[FeeChargeType],[FeeChargeInfo],[Notes],[SyncEtcMtc],[SyncFeBe],[IsOnlineCheck])",

                        "('" + this.ObuID + "'," +
                        "N''," +
                        "'" + this.CheckDate + "'," +
                        "'" + this.CheckTime + "'," +
                        "'" + this.BeginBalance + "'," +
                        "'" + this.ChargeAmount + "'," +
                        "'" + this.Balance + "'," +
                        "'" + this.VehicleClassID + "'," +
                        "'" + this.LoginID + "'," +
                        "'" + this.LaneID + "'," +
                        "'" + this.ShiftID + "'," +
                        "'" + this.StationID + "'," +
                        "'" + this.RegisPlateNumber + "'," +
                        "'" + this.PlateType + "'," +
                        "'" + this.RecogPlateNumber + "'," +
                        "'" + this.IsIntelligentVeriField + "'," +
                        "'" + this.IntelVerifyResult + "'," +
                        "'" + this.ImageID + "'," +
                        "'" + this.ImageStatus + "'," +
                        "'" + this.PeriodTicket + "'," +
                        "'" + this.Checker + "'," +
                        "N''," +
                        "N''," +
                        "'" + this.F0 + "'," +
                        "'" + this.F1 + "'," +
                        "'" + this.F2 + "'," +
                        "'" + 0 + "'," +
                        "'" + this.CheckInDate + "'," +
                        "N''," +
                        "N''," +
                        "N''," +
                        "'" + this.TransactionStatus + "'," +
                        "'" + this.TicketID + "'," +
                        "'" + this.CheckInDate + "'," +
                        "'" + this.CommitDate + "'," +
                        "'" + this.ETCStatus + "'," +
                        "N''," +
                        "'0'," +
                        "N''," +
                        "'" + string.Empty + "'," +
                        "'" + 0 + "'," +
                        "'" + 0 + "'," +
                        "'" + this.IsOnlineCheck + "')"
                        );
                }
                else
                {
                    Log.LogFile.writeLog(Log.LogFile.DIR, "SQLInsertMessage_" + Log.LogFile.getTimeStringNow() + ".txt", Log.LogFile.Filemode.GHIDE, "ImageID = '" + this.ImageID + "' and LaneID = '" + LaneID + "' Đã tồn tại trong hệ thống");
                }
            }
        }
    }
}