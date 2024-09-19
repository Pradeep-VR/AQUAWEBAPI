// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.UnloadManagement
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AQUA;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class UnloadManagement
    {
        Data Oldb = new Data();

        private List<Unload> lUnload = new List<Unload>();

        private Unload UnloadData = new Unload();

        private ICE ICEData = new ICE();

        private DataTable dt = new DataTable();

        private SaudNumber s = null;

        private ICECond ic = null;

        private string Strsql = string.Empty;

        private int count = 0;

        Logger log = new Logger();
        public Unload unloaddetails()
        {
            List<SaudNumber> UnloadL = new List<SaudNumber>();
            try
            {
                dt = new DataTable();
                string strqry = " select a.SaudaNumberCode,a.LotNumber,a.PurchaseDate,a.PurchaseType,a.SupplierName,a.FarmerName,a.PondNumber,a.SealNo,";
                strqry += " a.DriverName,a.VehicleNumber,b.No_of_Nets as PurchaseCount,b.Totalweight as PondWeight,a.ProcessStatus as ProcessStatus from Purchase a,Weighment b";
                strqry += " where a.SaudaNumberCode = b.SaudaNumberCode and a.LotNumber = b.Lotnumber and (a.ProcessStatus = 'PURCHASE COMPLETE' or a.ProcessStatus = 'PENDING') ";
                strqry += " and a.SaudaNumberCode not in (select saudaNumber from UnloadFinalProcess) ";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    UnloadData.Unloading = test(dt);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return UnloadData = null;
            }
            return UnloadData;
        }

        public async Task<UnloadMaster> unloaddetailsNew()
        {
            List<UnloadNew> UnloadL = new List<UnloadNew>();
            UnloadMaster ulM = new UnloadMaster();
            UnloadNew uL = null;
            var log_txt = "";
            try
            {
                dt = new DataTable();
                string strqry = "   SELECT A.SAUDANUMBERCODE,A.LOTNUMBER,CONVERT(VARCHAR,A.PURCHASEDATE,120) AS PURCHASEDATE ,A.PURCHASETYPE,A.SUPPLIERNAME,A.FARMERNAME,A.PONDNUMBER,A.SEALNO, ";
                strqry += " A.DRIVERNAME,A.VEHICLENUMBER,C.PURCHASECOUNTPERKG AS PURCHASECOUNT,B.TOTALWEIGHT AS PONDWEIGHT,A.PROCESSSTATUS AS PROCESSSTATUS ";
                strqry += " FROM PURCHASE A,WEIGHMENT B, RMPWEIGHMENTNETSAMPLING C ";
                strqry += " WHERE A.SAUDANUMBERCODE = B.SAUDANUMBERCODE AND A.LOTNUMBER = B.LOTNUMBER AND ";
                strqry += " A.LOTNUMBER = C.LOTNUMBER AND (A.PROCESSSTATUS = 'PURCHASE COMPLETE' OR A.PROCESSSTATUS = 'PENDING') ";
                strqry += " AND A.SAUDANUMBERCODE NOT IN (SELECT SAUDANUMBER FROM UNLOADFINALPROCESS) ";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        uL = new UnloadNew();
                        uL.supplierName = dt.Rows[i]["SUPPLIERNAME"].ToString();
                        uL.saudaNumberCode = dt.Rows[i]["SAUDANUMBERCODE"].ToString();
                        uL.purchaseDate = dt.Rows[i]["PURCHASEDATE"].ToString();
                        uL.purchaseType = dt.Rows[i]["PURCHASETYPE"].ToString();
                        uL.farmerName = dt.Rows[i]["FARMERNAME"].ToString();
                        uL.pondNumber = dt.Rows[i]["PONDNUMBER"].ToString();
                        uL.sealNo = dt.Rows[i]["SEALNO"].ToString();
                        uL.driverName = dt.Rows[i]["DRIVERNAME"].ToString();
                        uL.vehicleNumber = dt.Rows[i]["VEHICLENUMBER"].ToString();
                        uL.purchaseCount = dt.Rows[i]["PURCHASECOUNT"].ToString();
                        uL.pondWeight = dt.Rows[i]["PONDWEIGHT"].ToString();
                        uL.processStatus = dt.Rows[i]["PROCESSSTATUS"].ToString();
                        uL.lotNumber = dt.Rows[i]["LOTNUMBER"].ToString();
                        UnloadL.Add(uL);
                    }
                    ulM.unload = UnloadL;
                }
                if (UnloadL.Count == 0)
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Get Unloading_new Details is Failed.." + uL;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Get Unloading_new Details is Success..";
                }
                await log.writeLog(log_txt);

            }
            catch (Exception ex)
            {
                ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched in Unloading_new Details .." + ex.ToString();
                await log.writeLog(log_exc);
                return ulM = null;
            }
            return ulM;
        }

        public ICE getICECond()
        {
            try
            {
                dt = new DataTable();
                ICE ICECond = new ICE();
                List<ICECond> ICECon = new List<ICECond>();
                string strqry = "Select Distinct valuefield from General WHERE TableName='ICCondition'";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        ic = new ICECond();
                        ic.ICECondition = dt.Rows[i]["valuefield"].ToString();
                        ICECon.Add(ic);
                    }
                    ICEData.ICECondition = ICECon;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return ICEData = null;
            }
            return ICEData;
        }

        private List<SaudNumber> test(DataTable dt)
        {
            return (from rw in dt.AsEnumerable()
                    select new SaudNumber
                    {
                        Saudanumber = rw["SaudaNumberCode"].ToString(),
                        LotNumber = rw["LotNumber"].ToString(),
                        PurchaseDate = Convert.ToString(rw["PurchaseDate"]),
                        PurchaseType = rw["PurchaseType"].ToString(),
                        SupplierName = Convert.ToString(rw["SupplierName"]),
                        FarmerName = rw["FarmerName"].ToString(),
                        PondNumber = rw["PondNumber"].ToString(),
                        SealNo = Convert.ToString(rw["SealNo"]),
                        DriverName = rw["DriverName"].ToString(),
                        VehicleNumber = Convert.ToString(rw["VehicleNumber"]),
                        PurchaseCount = rw["PurchaseCount"].ToString(),
                        PondWeight = Convert.ToString(rw["PondWeight"]),
                        ProcessStatus = Convert.ToString(rw["ProcessStatus"])
                    }).ToList();
        }

        public List<Unloading> GetUnloadDetails()
        {
            DataTable dt = new DataTable();
            int count = 0;
            Unloading u = null;
            List<Unloading> unload = new List<Unloading>();
            try
            {
                string strqry = "SELECT[saudaNumber],[batchNo],[Crates],[reachedDateTime],[unloadDateTime],[sealNo],[receivedRmTemp], ";
                strqry += "[icCondition],[nextProcess],[farmerName] ,[supplierName] ,[purchaseDate],[purchaseType],[driverName] ";
                strqry += " ,[vehicleNo],[TotalWeight],[purchaseCount],[BatchWiseLotNo],[UnloadingStatus],[DrainTimeCalStatus] ";
                strqry += ",[WeighmentStatus],[QualityStatus],[NetSamplingStatus],[BeheadingStatus],[TableAllocationStatus] ";
                strqry += ",[TableWiseStatus] FROM[DBAQUA]. [UnloadFinalProcess] where QualityStatus ='Filled' ";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        u = new Unloading();
                        u.batchParent = dt.Rows[i]["batchNo"].ToString();
                        u.crates = dt.Rows[i]["Crates"].ToString();
                        u.reachedDateTime = dt.Rows[i]["reachedDateTime"].ToString();
                        u.unloadDateTime = dt.Rows[i]["unloadDateTime"].ToString();
                        u.sealNo = dt.Rows[i]["sealNo"].ToString();
                        u.receivedRmTemp = dt.Rows[i]["receivedRmTemp"].ToString();
                        u.icCondition = dt.Rows[i]["icCondition"].ToString();
                        u.nextProcess = dt.Rows[i]["nextProcess"].ToString();
                        u.farmerName = dt.Rows[i]["farmerName"].ToString();
                        u.purchaseDate = dt.Rows[i]["purchaseDate"].ToString();
                        u.purchaseType = dt.Rows[i]["purchaseType"].ToString();
                        u.driverName = dt.Rows[i]["driverName"].ToString();
                        u.vehicleNo = dt.Rows[i]["vehicleNo"].ToString();
                        u.totalWeight = dt.Rows[i]["TotalWeight"].ToString();
                        u.purchaseCount = dt.Rows[i]["purchaseCount"].ToString();
                        u.batchWiseLotNo = dt.Rows[i]["BatchWiseLotNo"].ToString();
                        u.rmUnloadingStatus = dt.Rows[i]["UnloadingStatus"].ToString();
                        u.rmDrainTimeCalculationStatus = dt.Rows[i]["DrainTimeCalStatus"].ToString();
                        u.rmWeighmentStatus = dt.Rows[i]["WeighmentStatus"].ToString();
                        u.rmQualityStatus = dt.Rows[i]["QualityStatus"].ToString();
                        u.rmNetSamplingStatus = dt.Rows[i]["NetSamplingStatus"].ToString();
                        u.rmBeheadingStatus = dt.Rows[i]["BeheadingStatus"].ToString();
                        u.rmTableAllocationStatus = dt.Rows[i]["TableAllocationStatus"].ToString();
                        u.rmTableWiseStatus = dt.Rows[i]["TableWiseStatus"].ToString();
                        unload.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return unload = null;
            }
            return unload;
        }

        public async Task<string> InsertUnloadData(List<Unloading> U)
        {
            string s = "";
            string strQry2 = "";
            string strQry = " ";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            List<Unloading> _failData = new List<Unloading>();
            try
            {
                if (U != null)
                {
                    foreach (Unloading unload in U)
                    {
                        strQry2 = "select * from UnloadFinalProcess where BatchWiseLotNo='" + unload.batchWiseLotNo + "'";

                        dt = Oldb.GetDataTable(strQry2);
                        strQry2 = "";
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "  INSERT INTO [UnloadFinalProcess] ([saudaNumber] ,[batchNo],[Crates],[reachedDateTime] ";
                            strQry += " ,[unloadDateTime],[sealNo],[receivedRmTemp],[icCondition] ,[nextProcess] ,[farmerName] ";
                            strQry += " ,[supplierName] ,[purchaseDate],[purchaseType] ,[driverName],[vehicleNo],[TotalWeight] ";
                            strQry += " ,[purchaseCount],[BatchWiseLotNo],[dateTime],[UnloadingStatus] ,[DrainTimeCalStatus]   ";
                            strQry += " ,[WeighmentStatus],[QualityStatus],[NetSamplingStatus] ,[BeheadingStatus],[TableAllocationStatus] ";
                            strQry += " ,[TableWiseStatus],[createdBy],[syncDate],[Flag]) VALUES ( ";
                            strQry = strQry + " '" + unload.saudaNumber + "','" + unload.batchParent + "','" + unload.crates + "', ";
                            strQry = strQry + " '" + unload.reachedDateTime + "', ";
                            strQry = strQry + " '" + unload.unloadDateTime + "','" + unload.sealNo + "','" + unload.receivedRmTemp + "', ";
                            strQry = strQry + " '" + unload.icCondition + "','" + unload.nextProcess + "','" + unload.farmerName + "', ";
                            strQry = strQry + " '" + unload.supplierName + "','" + unload.purchaseDate + "','" + unload.purchaseType + "', ";
                            strQry = strQry + " '" + unload.driverName + "','" + unload.vehicleNo + "', ";
                            strQry = strQry + " '" + unload.totalWeight + "','" + unload.purchaseCount + "', ";
                            strQry = strQry + " '" + unload.batchWiseLotNo + "','" + unload.dateTime + "','" + unload.rmUnloadingStatus + "', ";
                            strQry = strQry + " '" + unload.rmDrainTimeCalculationStatus + "', '" + unload.rmWeighmentStatus + "' , '" + unload.rmQualityStatus + "' , ";
                            strQry = strQry + " '" + unload.rmNetSamplingStatus + "', '" + unload.rmBeheadingStatus + "' , ";
                            strQry = strQry + " '" + unload.rmTableAllocationStatus + "', '" + unload.rmTableWiseStatus + "','" + unload.createdBy + "',getdate(),1 ) ";

                            lstrQry.Add(strQry);
                        }
                        else
                        {
                            strQry = "  INSERT INTO [UnloadFinalProcess] ([saudaNumber] ,[batchNo],[Crates],[reachedDateTime] ";
                            strQry += " ,[unloadDateTime],[sealNo],[receivedRmTemp],[icCondition] ,[nextProcess] ,[farmerName] ";
                            strQry += " ,[supplierName] ,[purchaseDate],[purchaseType] ,[driverName],[vehicleNo],[TotalWeight] ";
                            strQry += " ,[purchaseCount],[BatchWiseLotNo],[dateTime],[UnloadingStatus] ,[DrainTimeCalStatus] ";
                            strQry += " ,[WeighmentStatus],[QualityStatus],[NetSamplingStatus] ,[BeheadingStatus],[TableAllocationStatus] ";
                            strQry += " ,[TableWiseStatus],[createdBy],[syncDate],[Flag]) VALUES ( ";
                            strQry = strQry + " '" + unload.saudaNumber + "','" + unload.batchParent + "','" + unload.crates + "', ";
                            strQry = strQry + " '" + unload.reachedDateTime + "', ";
                            strQry = strQry + " '" + unload.unloadDateTime + "','" + unload.sealNo + "','" + unload.receivedRmTemp + "', ";
                            strQry = strQry + " '" + unload.icCondition + "','" + unload.nextProcess + "','" + unload.farmerName + "', ";
                            strQry = strQry + " '" + unload.supplierName + "','" + unload.purchaseDate + "','" + unload.purchaseType + "', ";
                            strQry = strQry + " '" + unload.driverName + "','" + unload.vehicleNo + "', ";
                            strQry = strQry + " '" + unload.totalWeight + "','" + unload.purchaseCount + "', ";
                            strQry = strQry + " '" + unload.batchWiseLotNo + "','" + unload.dateTime + "','" + unload.rmUnloadingStatus + "', ";
                            strQry = strQry + " '" + unload.rmDrainTimeCalculationStatus + "', '" + unload.rmWeighmentStatus + "' , '" + unload.rmQualityStatus + "' , ";
                            strQry = strQry + " '" + unload.rmNetSamplingStatus + "', '" + unload.rmBeheadingStatus + "' , ";
                            strQry = strQry + " '" + unload.rmTableAllocationStatus + "', '" + unload.rmTableWiseStatus + "','" + unload.createdBy + "',getdate(),1 ) ";

                            string querrys = strQry + "::Q2::" + strQry2;

                            var txtlog = DateTime.Now.ToString() + ":::" + "Duplicate Querrys" + querrys.ToString();
                            log.writeDataLog(txtlog);
                            s = "Duplicate data Loged Success";
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "Fail" : "Success"));
                }
                else
                {
                    s = "No data found!";
                }
            }
            catch (Exception ex)
            {
                return s + ex.Message;
            }
            return s;
        }

        public async Task<string> InsertBatchAllocation(List<UnloadBatchAllocation> U)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (U != null)
                {
                    foreach (UnloadBatchAllocation uba in U)
                    {
                        strQry = "select * from UnloadBatchAllocation where BatchNumber='" + uba.batchNo + "'  ";
                        dt = Oldb.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "Insert into UnloadBatchAllocation ([BatchNumber],[BatchParent],[SaudaNumber],[DateandTime] , ";
                            strQry = strQry + " [NoofCrates] ,[Status] ,[CreatedBy],[CreatedDate],[Flag],SyncDate,Lotnumber) values ('" + uba.batchNo + "', '" + uba.batchParent + "', ";
                            strQry = strQry + " '" + uba.saudaNo + "','" + uba.dateTime + "', '" + uba.noOfCrates + "','" + uba.status + "' , ";
                            strQry = strQry + " '" + uba.createdBy + "','" + uba.createdDate + "' , 1,getdate(),'" + uba.batchNoActLot + "' ) ";
                            lstrQry.Add(strQry);
                        }
                        else
                        {
                            strQry = "Insert into UnloadBatchAllocation ([BatchNumber],[BatchParent],[SaudaNumber],[DateandTime] , ";
                            strQry = strQry + " [NoofCrates] ,[Status] ,[CreatedBy],[CreatedDate],[Flag],SyncDate,Lotnumber) values ('" + uba.batchNo + "', '" + uba.batchParent + "', ";
                            strQry = strQry + " '" + uba.saudaNo + "','" + uba.dateTime + "', '" + uba.noOfCrates + "','" + uba.status + "' , ";
                            strQry = strQry + " '" + uba.createdBy + "','" + uba.createdDate + "' , 1,getdate(),'" + uba.batchNoActLot + "' ) ";

                            string querrys = strQry;

                            var txtlog = DateTime.Now.ToString() + ":::" + "Duplicate Querrys" + querrys.ToString();
                            log.writeDataLog(txtlog);
                            s = "Duplicate data Loged Success";
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
                }
                else
                {
                    s = "No Data found!";
                }
            }
            catch (Exception)
            {
                return strQry;
            }
            return s;
        }

        public async Task<string> InsertBatchAllocationNew(UnloadBatchAllocation uba)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (uba != null)
                {

                    string strQry2 = "select * from UnloadBatchAllocation where BatchNumber='" + uba.batchNo + "'  ";
                    dt = Oldb.GetDataTable(strQry2);
                    if (dt.Rows.Count == 0)
                    {
                        strQry = "Insert into UnloadBatchAllocation ([BatchNumber],[BatchParent],[SaudaNumber],[DateandTime] ,[NoofCrates] ,[Status] ,[CreatedBy], ";
                        strQry = strQry + " [CreatedDate],[Flag],SyncDate,Lotnumber) values ('" + uba.batchNo + "', '" + uba.batchParent + "', ";
                        strQry = strQry + " '" + uba.saudaNo + "','" + uba.dateTime + "', '" + uba.noOfCrates + "','" + uba.status + "' , ";
                        strQry = strQry + " '" + uba.createdBy + "','" + uba.createdDate + "' , 1,getdate(),'" + uba.batchNoActLot + "' ) ";
                        lstrQry.Add(strQry);
                    }
                    else
                    {
                        strQry = "Insert into UnloadBatchAllocation ([BatchNumber],[BatchParent],[SaudaNumber],[DateandTime] ,[NoofCrates] ,[Status] ,[CreatedBy], ";
                        strQry = strQry + " [CreatedDate],[Flag],SyncDate,Lotnumber) values ('" + uba.batchNo + "', '" + uba.batchParent + "', ";
                        strQry = strQry + " '" + uba.saudaNo + "','" + uba.dateTime + "', '" + uba.noOfCrates + "','" + uba.status + "' , ";
                        strQry = strQry + " '" + uba.createdBy + "','" + uba.createdDate + "' , 1,getdate(),'" + uba.batchNoActLot + "' ) ";

                        string querrys = strQry + " :: Q2 :: " + strQry2;

                        var txtlog = DateTime.Now.ToString() + ":::" + "Duplicate Querrys" + querrys.ToString();
                        log.writeDataLog(txtlog);
                        s = "Duplicate data Loged Success";
                    }

                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
                }
                else
                {
                    s = "No Data found!";
                }
            }
            catch (Exception)
            {
                return strQry;
            }
            return s;
        }

        public async Task<string> InsertBatchAllocationNew2(UnloadBatchAllocationNew uba)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (uba != null)
                {

                    string strQry2 = "select * from UnloadBatchAllocation where BatchNumber='" + uba.batchNo + "'  ";
                    dt = Oldb.GetDataTable(strQry2);
                    if (dt.Rows.Count == 0)
                    {
                        strQry = "Insert into UnloadBatchAllocation ([BatchNumber],[BatchParent],[SaudaNumber],[DateandTime] ,[NoofCrates] ,[Status] ,[CreatedBy], ";
                        strQry = strQry + " [CreatedDate],[Flag],SyncDate,Lotnumber) values ('" + uba.batchNo + "', '" + uba.batchParent + "', ";
                        strQry = strQry + " '" + uba.saudaNo + "','" + uba.dateTime + "', '" + uba.noOfCrates + "','" + uba.status + "' , ";
                        strQry = strQry + " '" + uba.createdBy + "','" + uba.createdDate + "' , 1,getdate(),'" + uba.batchNoActLot + "' ) ";
                        lstrQry.Add(strQry);
                    }
                    else
                    {
                        strQry = "Insert into UnloadBatchAllocation ([BatchNumber],[BatchParent],[SaudaNumber],[DateandTime] ,[NoofCrates] ,[Status] ,[CreatedBy], ";
                        strQry = strQry + " [CreatedDate],[Flag],SyncDate,Lotnumber) values ('" + uba.batchNo + "', '" + uba.batchParent + "', ";
                        strQry = strQry + " '" + uba.saudaNo + "','" + uba.dateTime + "', '" + uba.noOfCrates + "','" + uba.status + "' , ";
                        strQry = strQry + " '" + uba.createdBy + "','" + uba.createdDate + "' , 1,getdate(),'" + uba.batchNoActLot + "' ) ";

                        string querrys = strQry + " :: Q2 :: " + strQry2;

                        var txtlog = DateTime.Now.ToString() + ":::" + "Duplicate Querrys" + querrys.ToString();
                        log.writeDataLog(txtlog);
                        s = "Duplicate data Loged Success";
                    }

                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
                }
                else
                {
                    s = "No Data found!";
                }
            }
            catch (Exception)
            {
                return strQry;
            }
            return s;
        }
        public async Task<string> InsertUnloadWashingDrainTime(List<UnloadWashingDrainTime> DTTime)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (DTTime != null)
                {
                    foreach (UnloadWashingDrainTime uwd in DTTime)
                    {
                        strQry = "select * from UnloadWashingDrainedTime where LotNo='" + uwd.lotWiseBatchNo + "'";
                        dt = Oldb.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "Insert into UnloadWashingDrainedTime ([saudaNumber],[LotNo],[noOfCrates],[washingStartTime] , ";
                            strQry += " [washingEndTime] ,[weighmentStartTime] , ";
                            strQry += " [weighmentEndTime],[drainedTime],[drainedTimeMillis],[dateTime], [CreatedBy], ";
                            strQry = strQry + " [CreatedDate],[Flag],SyncDate,status) values ('" + uwd.saudaNumber + "', '" + uwd.lotWiseBatchNo + "', ";
                            strQry = strQry + " '" + uwd.noOfCrates + "','" + uwd.washingStartTime + "', '" + uwd.washingEndTime + "', ";
                            strQry = strQry + " '" + uwd.weighmentStartTime + "' ,'" + uwd.weighmentEndTime + "','" + uwd.drainedTime + "' , ";
                            strQry = strQry + " '" + uwd.drainedTimeMillis + "' ,'" + uwd.dateTime + "', ";
                            strQry = strQry + " '" + uwd.createdBy + "','" + uwd.createdDate + "' , 1,getdate(),'" + uwd.status + "' ) ";
                            lstrQry.Add(strQry);
                        }
                        else
                        {
                            strQry = "Insert into UnloadWashingDrainedTime ([saudaNumber],[LotNo],[noOfCrates],[washingStartTime] , ";
                            strQry += " [washingEndTime] ,[weighmentStartTime] , ";
                            strQry += " [weighmentEndTime],[drainedTime],[drainedTimeMillis],[dateTime], [CreatedBy], ";
                            strQry = strQry + " [CreatedDate],[Flag],SyncDate,status) values ('" + uwd.saudaNumber + "', '" + uwd.lotWiseBatchNo + "', ";
                            strQry = strQry + " '" + uwd.noOfCrates + "','" + uwd.washingStartTime + "', '" + uwd.washingEndTime + "', ";
                            strQry = strQry + " '" + uwd.weighmentStartTime + "' ,'" + uwd.weighmentEndTime + "','" + uwd.drainedTime + "' , ";
                            strQry = strQry + " '" + uwd.drainedTimeMillis + "' ,'" + uwd.dateTime + "', ";
                            strQry = strQry + " '" + uwd.createdBy + "','" + uwd.createdDate + "' , 1,getdate(),'" + uwd.status + "' ) ";

                            string querrys = strQry;

                            var txtlog = DateTime.Now.ToString() + ":::" + "Duplicate Querrys" + querrys.ToString();
                            log.writeDataLog(txtlog);
                            s = "Duplicate data Loged Success";
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
                }
                else
                {
                    s = "No Data found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public async Task<string> InsertUnloadWashingDrainTimeNew(UnloadWashingDrainTimeNew uwd)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (uwd != null)
                {

                    strQry = "select * from UnloadWashingDrainedTime where LotNo='" + uwd.lotWiseBatchNo + "'";
                    dt = Oldb.GetDataTable(strQry);
                    if (dt.Rows.Count == 0)
                    {
                        strQry = "Insert into UnloadWashingDrainedTime ([saudaNumber],[LotNo],[noOfCrates],[washingStartTime] , ";
                        strQry += " [washingEndTime] ,[weighmentStartTime] , ";
                        strQry += " [weighmentEndTime],[drainedTime],[drainedTimeMillis],[dateTime], [CreatedBy], ";
                        strQry = strQry + " [CreatedDate],[Flag],SyncDate,status) values ('" + uwd.saudaNumber + "', '" + uwd.lotWiseBatchNo + "', ";
                        strQry = strQry + " '" + uwd.noOfCrates + "','" + uwd.washingStartTime + "', '" + uwd.washingEndTime + "', ";
                        strQry = strQry + " '" + uwd.weighmentStartTime + "' ,'" + uwd.weighmentEndTime + "','" + uwd.drainedTime + "' , ";
                        strQry = strQry + " '" + uwd.drainedTimeMillis + "' ,'" + uwd.dateTime + "', ";
                        strQry = strQry + " '" + uwd.createdBy + "','" + uwd.createdDate + "' , 1,getdate(),'" + uwd.status + "' ) ";
                        lstrQry.Add(strQry);
                    }
                    else
                    {
                        strQry = "Insert into UnloadWashingDrainedTime ([saudaNumber],[LotNo],[noOfCrates],[washingStartTime] , ";
                        strQry += " [washingEndTime] ,[weighmentStartTime] , ";
                        strQry += " [weighmentEndTime],[drainedTime],[drainedTimeMillis],[dateTime], [CreatedBy], ";
                        strQry = strQry + " [CreatedDate],[Flag],SyncDate,status) values ('" + uwd.saudaNumber + "', '" + uwd.lotWiseBatchNo + "', ";
                        strQry = strQry + " '" + uwd.noOfCrates + "','" + uwd.washingStartTime + "', '" + uwd.washingEndTime + "', ";
                        strQry = strQry + " '" + uwd.weighmentStartTime + "' ,'" + uwd.weighmentEndTime + "','" + uwd.drainedTime + "' , ";
                        strQry = strQry + " '" + uwd.drainedTimeMillis + "' ,'" + uwd.dateTime + "', ";
                        strQry = strQry + " '" + uwd.createdBy + "','" + uwd.createdDate + "' , 1,getdate(),'" + uwd.status + "' ) ";

                        string querrys = strQry;

                        var txtlog = DateTime.Now.ToString() + ":::" + "Duplicate Querrys" + querrys.ToString();
                        log.writeDataLog(txtlog);
                        s = "Duplicate data Loged Success";
                    }

                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
                }
                else
                {
                    s = "No Data found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public string InsertUnloadWashingWeightment(List<UnloadWashingWeightment> UWeight)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (UWeight != null)
                {
                    foreach (UnloadWashingWeightment uww in UWeight)
                    {
                        strQry = "select * from UnloadWashingWeighnment where LotNo='" + uww.lotWiseBatch + "'";
                        dt = Oldb.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "Insert into [UnloadWashingWeighnment]([lotNo],[crateNo], ";
                            strQry += " [crateWt],[saudaNo],[dateTime],[BatchNo],[GrossWeight],[TotalWeight]";
                            strQry += " ,[Status],[CreatedBy],[CreatedDate],[Flag],[SyncDate]) values ( ";
                            strQry = strQry + " '" + uww.lotWiseBatch + "','" + uww.noOfCrates + "',  '" + uww.crateWt + "', ";
                            strQry = strQry + " '" + uww.saudaNo + "' ,'" + uww.dateTime + "','" + uww.batchParent + "' , ";
                            strQry = strQry + " '" + uww.grossWeight + "' ,'" + uww.totalRmWeight + "', '" + uww.status + "', ";
                            strQry = strQry + " '" + uww.createdBy + "','" + uww.createdDate + "' , 1,getdate() ) ";
                            lstrQry.Add(strQry);
                        }
                        else
                        {
                            strQry = "Insert into [UnloadWashingWeighnment]([lotNo],[crateNo], ";
                            strQry += " [crateWt],[saudaNo],[dateTime],[BatchNo],[GrossWeight],[TotalWeight]";
                            strQry += " ,[Status],[CreatedBy],[CreatedDate],[Flag],[SyncDate]) values ( ";
                            strQry = strQry + " '" + uww.lotWiseBatch + "','" + uww.noOfCrates + "',  '" + uww.crateWt + "', ";
                            strQry = strQry + " '" + uww.saudaNo + "' ,'" + uww.dateTime + "','" + uww.batchParent + "' , ";
                            strQry = strQry + " '" + uww.grossWeight + "' ,'" + uww.totalRmWeight + "', '" + uww.status + "', ";
                            strQry = strQry + " '" + uww.createdBy + "','" + uww.createdDate + "' , 1,getdate() ) ";


                            var txtlog = DateTime.Now.ToString() + ":::" + "Duplicate Querrys" + strQry.ToString();
                            log.writeDataLog(txtlog);
                            s = "Duplicate data Loged Success";
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "Fail" : "Success"));
                }
                else
                {
                    s = "No Data Found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public string InsertUnloadWashingWeightmentNew(UnloadWashingWeightmentNew uww)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (uww != null)
                {

                    strQry = "select * from UnloadWashingWeighnment where LotNo='" + uww.lotWiseBatch + "'";
                    dt = Oldb.GetDataTable(strQry);
                    if (dt.Rows.Count == 0)
                    {
                        strQry = "Insert into [UnloadWashingWeighnment]([lotNo],[crateNo], ";
                        strQry += " [crateWt],[saudaNo],[dateTime],[BatchNo],[GrossWeight],[TotalWeight]";
                        strQry += " ,[Status],[CreatedBy],[CreatedDate],[Flag],[SyncDate]) values ( ";
                        strQry = strQry + " '" + uww.lotWiseBatch + "','" + uww.noOfCrates + "',  '" + uww.crateWt + "', ";
                        strQry = strQry + " '" + uww.saudaNo + "' ,'" + uww.dateTime + "','" + uww.batchParent + "' , ";
                        strQry = strQry + " '" + uww.grossWeight + "' ,'" + uww.totalRmWeight + "', '" + uww.status + "', ";
                        strQry = strQry + " '" + uww.createdBy + "','" + uww.createdDate + "' , 1,getdate() ) ";
                        lstrQry.Add(strQry);
                    }
                    else
                    {
                        strQry = "Insert into [UnloadWashingWeighnment]([lotNo],[crateNo], ";
                        strQry += " [crateWt],[saudaNo],[dateTime],[BatchNo],[GrossWeight],[TotalWeight]";
                        strQry += " ,[Status],[CreatedBy],[CreatedDate],[Flag],[SyncDate]) values ( ";
                        strQry = strQry + " '" + uww.lotWiseBatch + "','" + uww.noOfCrates + "',  '" + uww.crateWt + "', ";
                        strQry = strQry + " '" + uww.saudaNo + "' ,'" + uww.dateTime + "','" + uww.batchParent + "' , ";
                        strQry = strQry + " '" + uww.grossWeight + "' ,'" + uww.totalRmWeight + "', '" + uww.status + "', ";
                        strQry = strQry + " '" + uww.createdBy + "','" + uww.createdDate + "' , 1,getdate() ) ";


                        var txtlog = DateTime.Now.ToString() + ":::" + "Duplicate Querrys" + strQry.ToString();
                        log.writeDataLog(txtlog);
                        s = "Duplicate data Loged Success";
                    }

                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "Fail" : "Success"));
                }
                else
                {
                    s = "No Data Found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public async Task<string> InsertUnloadNetSampling(List<UnloadRMNetSample> unloadNet)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (unloadNet != null)
                {
                    foreach (UnloadRMNetSample net in unloadNet)
                    {
                        strQry = "select * from UnloadNetSampling where LotWiseBatch='" + net.lotWiseBatch + "'";
                        dt = Oldb.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "";
                            strQry = " INSERT INTO UnloadNetSampling ([LotWiseBatch],[Batchparent],[SaudaNo] ";
                            strQry += " ,[NoodNets] ,[TareWtPerNt],[GrossWeight],[TotalWeight],[SampleWeight] ";
                            strQry += " ,[NoofNormalPieces],[noOfSmallPieces],[noOfSmallPiecesAccAsOne] ";
                            strQry += " ,[TotalNoOfpieces],[PlantCount],[weightDifference],[countDifference] ";
                            strQry += " ,[CreatedBy] ,[CreatedDate],[SyncDate],[Flag]) values ( ";
                            strQry = strQry + " '" + net.lotWiseBatch + "','" + net.batchparent + "'  , '" + net.saudaNumber + "', ";
                            strQry = strQry + " '" + net.noOfNets + "' ,'" + net.tareWtPerNet + "','" + net.grossWeight + "' , ";
                            strQry = strQry + " '" + net.totalWeight + "' ,'" + net.sampleWeight + "', '" + net.noOfnormalpieces + "', '" + net.noOfSmallPieces + "', ";
                            strQry = strQry + " '" + net.noOfSmallPiecesAccAsOne + "' ,'" + net.totalNoOfpieces + "', '" + net.plantCount + "', ";
                            strQry = strQry + " '" + net.weightDifference + "' ,'" + net.countDifference + "' , ";
                            strQry = strQry + " '" + net.createdBy + "','" + net.dateTime + "' ,getdate(), 1 ) ";
                            lstrQry.Add(strQry);
                        }
                        else
                        {
                            s = " Already this Data Available ";
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? strQry : "Success"));
                }
                else
                {
                    s = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public async Task<string> InsertUnloadNetSamplingNew(UnloadRMNetSampleNew net)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (net != null)
                {

                    strQry = "select * from UnloadNetSampling where LotWiseBatch='" + net.lotWiseBatch + "'";
                    dt = Oldb.GetDataTable(strQry);
                    if (dt.Rows.Count == 0)
                    {
                        strQry = "";
                        strQry = " INSERT INTO UnloadNetSampling ([LotWiseBatch],[Batchparent],[SaudaNo] ";
                        strQry += " ,[NoodNets] ,[TareWtPerNt],[GrossWeight],[TotalWeight],[SampleWeight] ";
                        strQry += " ,[NoofNormalPieces],[noOfSmallPieces],[noOfSmallPiecesAccAsOne] ";
                        strQry += " ,[TotalNoOfpieces],[PlantCount],[weightDifference],[countDifference] ";
                        strQry += " ,[CreatedBy] ,[CreatedDate],[SyncDate],[Flag]) values ( ";
                        strQry = strQry + " '" + net.lotWiseBatch + "','" + net.batchparent + "'  , '" + net.saudaNumber + "', ";
                        strQry = strQry + " '" + net.noOfNets + "' ,'" + net.tareWtPerNet + "','" + net.grossWeight + "' , ";
                        strQry = strQry + " '" + net.totalWeight + "' ,'" + net.sampleWeight + "', '" + net.noOfnormalpieces + "', '" + net.noOfSmallPieces + "', ";
                        strQry = strQry + " '" + net.noOfSmallPiecesAccAsOne + "' ,'" + net.totalNoOfpieces + "', '" + net.plantCount + "', ";
                        strQry = strQry + " '" + net.weightDifference + "' ,'" + net.countDifference + "' , ";
                        strQry = strQry + " '" + net.createdBy + "','" + net.dateTime + "' ,getdate(), 1 ) ";
                        lstrQry.Add(strQry);
                    }
                    else
                    {
                        s = " Already this Data Available ";
                    }

                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? strQry : "Success"));
                }
                else
                {
                    s = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public async Task<string> InsertUnloadRMQuality(List<UnloadRMQuality> unloadQty)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (unloadQty != null)
                {
                    foreach (UnloadRMQuality quality in unloadQty)
                    {
                        strQry = "select * from UnloadRMQuality where batchLotWise='" + quality.batchLotWise + "'";
                        dt = Oldb.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            string softPer = quality.softPercentage == "∞" ? "0" : quality.softPercentage;
                            string necrosisPer = quality.necrosisPercentage == "NaN" ? "0" : quality.necrosisPercentage;
                            string discolerationPer = quality.disColourationPercentage == "NaN" ? "0" : quality.disColourationPercentage;
                            string brokenPer = quality.brokenPercentage == "NaN" ? "0" : quality.brokenPercentage;

                            strQry = " INSERT INTO UnloadRMQuality ([SaudaNumberCode],[NO_SoftPieces],[SoftPercentage], ";
                            strQry += " [No_PiecesWithBlackSpot],[PercentageOfBlackSpot],[No_PiecesNecrosis],[NecrosisPercentage], ";
                            strQry += " [Discoloration],[DiscolorationPercentage],[ColorOfShrimp],[GILLS] ,[Texture] ,[MuddySmell], ";
                            strQry += " [CleanlinessOfVehicle],[CleanlinessOfBoxes],[NO_BrokenPieces],[BrokenPercentage], [CreatedBy],[CreatedDate] ,[Status],";
                            strQry += " [batchLotWise],[Remarks],  [SyncDate],[Flag], [WeightAllocatedForBeheading],Grader) VALUES ( ";
                            strQry = strQry + " '" + quality.saudaNo + "','" + quality.noOfSoftPieces + "','" + softPer + "', '" + quality.piecesWithBlackSpot + "',  ";
                            strQry = strQry + " '" + quality.percentageOfBlackSpot + "','" + quality.piecesInNecrosis + "','" + necrosisPer + "', ";
                            strQry = strQry + " '" + quality.disColouration + "','" + discolerationPer + "','" + quality.colorOfShrimp + "', ";
                            strQry = strQry + " '" + quality.gills + "','" + quality.freshnessTexture + "','" + quality.muddySmell + "', ";
                            strQry = strQry + " '" + quality.cleanlinessOfVehicle + "','" + quality.cleanlinessOfBoxes + "', ";
                            strQry = strQry + " '" + quality.noOfBrokenPieces + "','" + brokenPer + "', ";
                            strQry = strQry + " '" + quality.createdBy + "','" + quality.dateAndTime + "','1','" + quality.batchLotWise + "', ";
                            strQry = strQry + " '" + quality.remarks + "',getdate(),1,'" + quality.weightAllocatedForBeheading + "','" + quality.grader + "' ) ";
                            lstrQry.Add(strQry);
                        }
                        else
                        {
                            string softPer = quality.softPercentage == "∞" ? "0" : quality.softPercentage;
                            string necrosisPer = quality.necrosisPercentage == "NaN" ? "0" : quality.necrosisPercentage;
                            string discolerationPer = quality.disColourationPercentage == "NaN" ? "0" : quality.disColourationPercentage;
                            string brokenPer = quality.brokenPercentage == "NaN" ? "0" : quality.brokenPercentage;

                            strQry = " INSERT INTO UnloadRMQuality ([SaudaNumberCode],[NO_SoftPieces],[SoftPercentage], ";
                            strQry += " [No_PiecesWithBlackSpot],[PercentageOfBlackSpot],[No_PiecesNecrosis],[NecrosisPercentage], ";
                            strQry += " [Discoloration],[DiscolorationPercentage],[ColorOfShrimp],[GILLS] ,[Texture] ,[MuddySmell], ";
                            strQry += " [CleanlinessOfVehicle],[CleanlinessOfBoxes],[NO_BrokenPieces],[BrokenPercentage], [CreatedBy],[CreatedDate] ,[Status],";
                            strQry += " [batchLotWise],[Remarks],  [SyncDate],[Flag], [WeightAllocatedForBeheading],Grader) VALUES ( ";
                            strQry = strQry + " '" + quality.saudaNo + "','" + quality.noOfSoftPieces + "','" + softPer + "', '" + quality.piecesWithBlackSpot + "',  ";
                            strQry = strQry + " '" + quality.percentageOfBlackSpot + "','" + quality.piecesInNecrosis + "','" + necrosisPer + "', ";
                            strQry = strQry + " '" + quality.disColouration + "','" + discolerationPer + "','" + quality.colorOfShrimp + "', ";
                            strQry = strQry + " '" + quality.gills + "','" + quality.freshnessTexture + "','" + quality.muddySmell + "', ";
                            strQry = strQry + " '" + quality.cleanlinessOfVehicle + "','" + quality.cleanlinessOfBoxes + "', '" + quality.noOfBrokenPieces + "','" + brokenPer + "',";
                            strQry = strQry + " '" + quality.createdBy + "','" + quality.dateAndTime + "','1','" + quality.batchLotWise + "', ";
                            strQry = strQry + " '" + quality.remarks + "',getdate(),1,'" + quality.weightAllocatedForBeheading + "','" + quality.grader + "' ) ";

                            var txt = DateTime.Now.ToString() + " ::: " + "Duplicate Query Generate " + " ::: " + strQry;
                            log.writeDataLog(txt);
                        }
                    }
                    if (lstrQry.Count > 0)
                    {
                        try
                        {
                            s = ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "Fail" : "Success");
                        }
                        catch (Exception)
                        {
                            s = "Connection Error";
                        }

                        if (s == "Fail")
                        {
                            var txt = DateTime.Now.ToString() + " ::: " + "Query " + s + " ::: " + strQry;
                            log.writeDataLog(txt);
                        }
                    }
                    else
                    {
                        s = "Please contact Admin";
                    }
                }
                else
                {
                    s = "No data found...";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public async Task<string> InsertUnloadRMQualityNew(UnloadRMQualityNew quality)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (quality != null)
                {

                    strQry = "select * from UnloadRMQuality where batchLotWise='" + quality.batchLotWise + "'";
                    dt = Oldb.GetDataTable(strQry);
                    if (dt.Rows.Count == 0)
                    {
                        string softPer = quality.softPercentage == "∞" ? "0" : quality.softPercentage;
                        string necrosisPer = quality.necrosisPercentage == "NaN" ? "0" : quality.necrosisPercentage;
                        string discolerationPer = quality.disColourationPercentage == "NaN" ? "0" : quality.disColourationPercentage;
                        string brokenPer = quality.brokenPercentage == "NaN" ? "0" : quality.brokenPercentage;

                        strQry = " INSERT INTO UnloadRMQuality ([SaudaNumberCode],[NO_SoftPieces],[SoftPercentage], ";
                        strQry += " [No_PiecesWithBlackSpot],[PercentageOfBlackSpot],[No_PiecesNecrosis],[NecrosisPercentage], ";
                        strQry += " [Discoloration],[DiscolorationPercentage],[ColorOfShrimp],[GILLS] ,[Texture] ,[MuddySmell], ";
                        strQry += " [CleanlinessOfVehicle],[CleanlinessOfBoxes],[NO_BrokenPieces],[BrokenPercentage], [CreatedBy],[CreatedDate] ,[Status],";
                        strQry += " [batchLotWise],[Remarks],  [SyncDate],[Flag], [WeightAllocatedForBeheading],Grader) VALUES ( ";
                        strQry = strQry + " '" + quality.saudaNo + "','" + quality.noOfSoftPieces + "','" + softPer + "', '" + quality.piecesWithBlackSpot + "',  ";
                        strQry = strQry + " '" + quality.percentageOfBlackSpot + "','" + quality.piecesInNecrosis + "','" + necrosisPer + "', ";
                        strQry = strQry + " '" + quality.disColouration + "','" + discolerationPer + "','" + quality.colorOfShrimp + "', ";
                        strQry = strQry + " '" + quality.gills + "','" + quality.freshnessTexture + "','" + quality.muddySmell + "', ";
                        strQry = strQry + " '" + quality.cleanlinessOfVehicle + "','" + quality.cleanlinessOfBoxes + "', ";
                        strQry = strQry + " '" + quality.noOfBrokenPieces + "','" + brokenPer + "', ";
                        strQry = strQry + " '" + quality.createdBy + "','" + quality.dateAndTime + "','1','" + quality.batchLotWise + "', ";
                        strQry = strQry + " '" + quality.remarks + "',getdate(),1,'" + quality.weightAllocatedForBeheading + "','" + quality.grader + "' ) ";
                        lstrQry.Add(strQry);
                    }
                    else
                    {
                        string softPer = quality.softPercentage == "∞" ? "0" : quality.softPercentage;
                        string necrosisPer = quality.necrosisPercentage == "NaN" ? "0" : quality.necrosisPercentage;
                        string discolerationPer = quality.disColourationPercentage == "NaN" ? "0" : quality.disColourationPercentage;
                        string brokenPer = quality.brokenPercentage == "NaN" ? "0" : quality.brokenPercentage;

                        strQry = " INSERT INTO UnloadRMQuality ([SaudaNumberCode],[NO_SoftPieces],[SoftPercentage], ";
                        strQry += " [No_PiecesWithBlackSpot],[PercentageOfBlackSpot],[No_PiecesNecrosis],[NecrosisPercentage], ";
                        strQry += " [Discoloration],[DiscolorationPercentage],[ColorOfShrimp],[GILLS] ,[Texture] ,[MuddySmell], ";
                        strQry += " [CleanlinessOfVehicle],[CleanlinessOfBoxes],[NO_BrokenPieces],[BrokenPercentage], [CreatedBy],[CreatedDate] ,[Status],";
                        strQry += " [batchLotWise],[Remarks],  [SyncDate],[Flag], [WeightAllocatedForBeheading],Grader) VALUES ( ";
                        strQry = strQry + " '" + quality.saudaNo + "','" + quality.noOfSoftPieces + "','" + softPer + "', '" + quality.piecesWithBlackSpot + "',  ";
                        strQry = strQry + " '" + quality.percentageOfBlackSpot + "','" + quality.piecesInNecrosis + "','" + necrosisPer + "', ";
                        strQry = strQry + " '" + quality.disColouration + "','" + discolerationPer + "','" + quality.colorOfShrimp + "', ";
                        strQry = strQry + " '" + quality.gills + "','" + quality.freshnessTexture + "','" + quality.muddySmell + "', ";
                        strQry = strQry + " '" + quality.cleanlinessOfVehicle + "','" + quality.cleanlinessOfBoxes + "', '" + quality.noOfBrokenPieces + "','" + brokenPer + "',";
                        strQry = strQry + " '" + quality.createdBy + "','" + quality.dateAndTime + "','1','" + quality.batchLotWise + "', ";
                        strQry = strQry + " '" + quality.remarks + "',getdate(),1,'" + quality.weightAllocatedForBeheading + "','" + quality.grader + "' ) ";

                        var txt = DateTime.Now.ToString() + " ::: " + "Duplicate Query Generate " + " ::: " + strQry;
                        log.writeDataLog(txt);
                    }

                    if (lstrQry.Count > 0)
                    {
                        try
                        {
                            s = ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "Fail" : "Success");
                        }
                        catch (Exception)
                        {
                            s = "Connection Error";
                        }

                        if (s == "Fail")
                        {
                            var txt = DateTime.Now.ToString() + " ::: " + "Query " + s + " ::: " + strQry;
                            log.writeDataLog(txt);
                        }
                    }
                    else
                    {
                        s = "Please contact Admin";
                    }
                }
                else
                {
                    s = "No data found...";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }


        /** New Functions **/

        public async Task<string> InsrtBatchAllocation(List<UnloadBatchAllocation> U)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (U != null)
                {
                    foreach (UnloadBatchAllocation uba in U)
                    {
                        strQry = "select * from UnloadBatchAllocation where BatchNumber='" + uba.batchNo + "'  ";
                        dt = Oldb.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "Insert into UnloadBatchAllocation ([BatchNumber],[BatchParent],[SaudaNumber],[DateandTime] , ";
                            strQry = strQry + " [NoofCrates] ,[Status] ,[CreatedBy],[CreatedDate],[Flag],SyncDate,Lotnumber) values ('" + uba.batchNo + "', '" + uba.batchParent + "', ";
                            strQry = strQry + " '" + uba.saudaNo + "','" + uba.dateTime + "', '" + uba.noOfCrates + "','" + uba.status + "' , ";
                            strQry = strQry + " '" + uba.createdBy + "','" + uba.createdDate + "' , 1,getdate(),'" + uba.batchNoActLot + "' ) ";
                            lstrQry.Add(strQry);
                        }
                        else
                        {
                            strQry = "Insert into UnloadBatchAllocation ([BatchNumber],[BatchParent],[SaudaNumber],[DateandTime] , ";
                            strQry = strQry + " [NoofCrates] ,[Status] ,[CreatedBy],[CreatedDate],[Flag],SyncDate,Lotnumber) values ('" + uba.batchNo + "', '" + uba.batchParent + "', ";
                            strQry = strQry + " '" + uba.saudaNo + "','" + uba.dateTime + "', '" + uba.noOfCrates + "','" + uba.status + "' , ";
                            strQry = strQry + " '" + uba.createdBy + "','" + uba.createdDate + "' , 1,getdate(),'" + uba.batchNoActLot + "' ) ";

                            string querrys = strQry;

                            var txtlog = DateTime.Now.ToString() + ":::" + "Duplicate Querrys" + querrys.ToString();
                            log.writeDataLog(txtlog);
                            s = "Duplicate data Loged Success";
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
                }
                else
                {
                    s = "No Data found!";
                }
            }
            catch (Exception)
            {
                return strQry;
            }
            return s;
        }

        public async Task<string> InsertUnloadDataNew(UnloadingNew unload)
        {
            string s = "";
            string strQry2 = "";
            string strQry = " ";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            List<Unloading> _failData = new List<Unloading>();
            try
            {
                if (unload != null)
                {
                    strQry2 = "select * from UnloadFinalProcess where BatchWiseLotNo='" + unload.batchWiseLotNo + "'";
                    dt = Oldb.GetDataTable(strQry2);
                    strQry2 = "";
                    if (dt.Rows.Count == 0)
                    {
                        strQry = "  INSERT INTO [UnloadFinalProcess] ([saudaNumber] ,[batchNo],[Crates],[reachedDateTime] ";
                        strQry += " ,[unloadDateTime],[sealNo],[receivedRmTemp],[icCondition] ,[nextProcess] ,[farmerName] ";
                        strQry += " ,[supplierName] ,[purchaseDate],[purchaseType] ,[driverName],[vehicleNo],[TotalWeight] ";
                        strQry += " ,[purchaseCount],[BatchWiseLotNo],[dateTime],[UnloadingStatus] ,[DrainTimeCalStatus]   ";
                        strQry += " ,[WeighmentStatus],[QualityStatus],[NetSamplingStatus] ,[BeheadingStatus],[TableAllocationStatus] ";
                        strQry += " ,[TableWiseStatus],[createdBy],[syncDate],[Flag]) VALUES ( ";
                        strQry = strQry + " '" + unload.saudaNumber + "','" + unload.batchParent + "','" + unload.crates + "', ";
                        strQry = strQry + " '" + unload.reachedDateTime + "', ";
                        strQry = strQry + " '" + unload.unloadDateTime + "','" + unload.sealNo + "','" + unload.receivedRmTemp + "', ";
                        strQry = strQry + " '" + unload.icCondition + "','" + unload.nextProcess + "','" + unload.farmerName + "', ";
                        strQry = strQry + " '" + unload.supplierName + "','" + unload.purchaseDate + "','" + unload.purchaseType + "', ";
                        strQry = strQry + " '" + unload.driverName + "','" + unload.vehicleNo + "', ";
                        strQry = strQry + " '" + unload.totalWeight + "','" + unload.purchaseCount + "', ";
                        strQry = strQry + " '" + unload.batchWiseLotNo + "','" + unload.dateTime + "','" + unload.rmUnloadingStatus + "', ";
                        strQry = strQry + " '" + unload.rmDrainTimeCalculationStatus + "', '" + unload.rmWeighmentStatus + "' , '" + unload.rmQualityStatus + "' , ";
                        strQry = strQry + " '" + unload.rmNetSamplingStatus + "', '" + unload.rmBeheadingStatus + "' , ";
                        strQry = strQry + " '" + unload.rmTableAllocationStatus + "', '" + unload.rmTableWiseStatus + "','" + unload.createdBy + "',getdate(),1 ) ";

                        lstrQry.Add(strQry);
                    }
                    else
                    {
                        strQry = "  INSERT INTO [UnloadFinalProcess] ([saudaNumber] ,[batchNo],[Crates],[reachedDateTime] ";
                        strQry += " ,[unloadDateTime],[sealNo],[receivedRmTemp],[icCondition] ,[nextProcess] ,[farmerName] ";
                        strQry += " ,[supplierName] ,[purchaseDate],[purchaseType] ,[driverName],[vehicleNo],[TotalWeight] ";
                        strQry += " ,[purchaseCount],[BatchWiseLotNo],[dateTime],[UnloadingStatus] ,[DrainTimeCalStatus] ";
                        strQry += " ,[WeighmentStatus],[QualityStatus],[NetSamplingStatus] ,[BeheadingStatus],[TableAllocationStatus] ";
                        strQry += " ,[TableWiseStatus],[createdBy],[syncDate],[Flag]) VALUES ( ";
                        strQry = strQry + " '" + unload.saudaNumber + "','" + unload.batchParent + "','" + unload.crates + "', ";
                        strQry = strQry + " '" + unload.reachedDateTime + "', ";
                        strQry = strQry + " '" + unload.unloadDateTime + "','" + unload.sealNo + "','" + unload.receivedRmTemp + "', ";
                        strQry = strQry + " '" + unload.icCondition + "','" + unload.nextProcess + "','" + unload.farmerName + "', ";
                        strQry = strQry + " '" + unload.supplierName + "','" + unload.purchaseDate + "','" + unload.purchaseType + "', ";
                        strQry = strQry + " '" + unload.driverName + "','" + unload.vehicleNo + "', ";
                        strQry = strQry + " '" + unload.totalWeight + "','" + unload.purchaseCount + "', ";
                        strQry = strQry + " '" + unload.batchWiseLotNo + "','" + unload.dateTime + "','" + unload.rmUnloadingStatus + "', ";
                        strQry = strQry + " '" + unload.rmDrainTimeCalculationStatus + "', '" + unload.rmWeighmentStatus + "' , '" + unload.rmQualityStatus + "' , ";
                        strQry = strQry + " '" + unload.rmNetSamplingStatus + "', '" + unload.rmBeheadingStatus + "' , ";
                        strQry = strQry + " '" + unload.rmTableAllocationStatus + "', '" + unload.rmTableWiseStatus + "','" + unload.createdBy + "',getdate(),1 ) ";

                        string querrys = strQry + "::Q2::" + strQry2;

                        var txtlog = DateTime.Now.ToString() + ":::" + "Duplicate Querrys" + querrys.ToString();
                        log.writeDataLog(txtlog);
                        s = "Duplicate data Loged Success";
                    }
                    if (lstrQry.Count > 0)
                    {
                        s = Oldb.UpdateUsingExecuteNonQueryList(lstrQry) ? "Success" : "Fail";
                    }
                    else
                    {
                        s = "Please contact Admin";
                    }
                }
                else
                {
                    s = "No data found!";
                }
            }
            catch (Exception ex)
            {
                return s + ex.Message;
            }
            return s;
        }
    }
}