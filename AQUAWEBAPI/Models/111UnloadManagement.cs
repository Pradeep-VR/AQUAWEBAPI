// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.UnloadManagement
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AQUA;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class UnloadManagement
    {
        private List<Unload> lUnload = new List<Unload>();

        private Unload UnloadData = new Unload();

        private ICE ICEData = new ICE();

        private DataTable dt = new DataTable();

        private SaudNumber s = null;

        private ICECond ic = null;

        private string Strsql = string.Empty;

        private int count = 0;

        public Unload unloaddetails()
        {
            List<SaudNumber> UnloadL = new List<SaudNumber>();
            try
            {
                dt = new DataTable();
                string strqry = " select a.SaudaNumberCode,a.LotNumber,a.PurchaseDate,a.PurchaseType,a.SupplierName,a.FarmerName,a.PondNumber,a.SealNo,";
                strqry += " a.DriverName,a.VehicleNumber,b.No_of_Nets as PurchaseCount,b.Totalweight as PondWeight,a.ProcessStatus as ProcessStatus from Purchase a,Weighment b";
                strqry += " where a.SaudaNumberCode = b.SaudaNumberCode and a.LotNumber = b.Lotnumber and (a.ProcessStatus = 'PURCHASE COMPLETE' or a.ProcessStatus = 'PENDING') ";
                dt = Data.Instance.GetDataTable(strqry);
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

        public UnloadMaster unloaddetailsNew()
        {
            List<UnloadNew> UnloadL = new List<UnloadNew>();
            UnloadMaster ulM = new UnloadMaster();
            UnloadNew uL = null;
            try
            {
                dt = new DataTable();
                string strqry = "   select a.SaudaNumberCode,a.LotNumber,convert(varchar,a.PurchaseDate,120) as PurchaseDate ,a.PurchaseType,a.SupplierName,a.FarmerName,a.PondNumber,a.SealNo, ";
                strqry += " a.DriverName,a.VehicleNumber,C.PurchaseCountPerKG as PurchaseCount,b.Totalweight as PondWeight,a.ProcessStatus as ProcessStatus ";
                strqry += " from Purchase a,Weighment b, RMPWeighmentNetSampling C ";
                strqry += " where a.SaudaNumberCode = b.SaudaNumberCode and a.LotNumber = b.Lotnumber and ";
                strqry += " a.LotNumber = C.LotNumber and (a.ProcessStatus = 'PURCHASE COMPLETE' or a.ProcessStatus = 'PENDING') ";
                dt = Data.Instance.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        uL = new UnloadNew();
                        uL.supplierName = dt.Rows[i]["SupplierName"].ToString();
                        uL.saudaNumberCode = dt.Rows[i]["SaudaNumberCode"].ToString();
                        uL.purchaseDate = dt.Rows[i]["PurchaseDate"].ToString();
                        uL.purchaseType = dt.Rows[i]["PurchaseType"].ToString();
                        uL.farmerName = dt.Rows[i]["FarmerName"].ToString();
                        uL.pondNumber = dt.Rows[i]["PondNumber"].ToString();
                        uL.sealNo = dt.Rows[i]["SealNo"].ToString();
                        uL.driverName = dt.Rows[i]["DriverName"].ToString();
                        uL.vehicleNumber = dt.Rows[i]["VehicleNumber"].ToString();
                        uL.purchaseCount = dt.Rows[i]["PurchaseCount"].ToString();
                        uL.pondWeight = dt.Rows[i]["PondWeight"].ToString();
                        uL.processStatus = dt.Rows[i]["ProcessStatus"].ToString();
                        uL.lotNumber = dt.Rows[i]["LotNumber"].ToString();
                        UnloadL.Add(uL);
                    }
                    ulM.unload = UnloadL;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
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
                dt = Data.Instance.GetDataTable(strqry);
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
                strqry += ",[TableWiseStatus] FROM[DBAQUA].[dbo].[UnloadFinalProcess] where QualityStatus ='Filled' ";
                dt = Data.Instance.GetDataTable(strqry);
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

        public string InsertUnloadData(List<Unloading> U)
        {
            bool b = false;
            string s = "";
            string strQry2 = "";
            string strQry = " ";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (U != null)
                {
                    foreach (Unloading unload in U)
                    {
                        strQry2 = "select * from UnloadFinalProcess where BatchWiseLotNo='" + unload.batchWiseLotNo + "'";
                        dt = Data.Instance.GetDataTable(strQry2);
                        strQry2 = "";
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "  INSERT INTO[dbo].[UnloadFinalProcess] ([saudaNumber] ,[batchNo],[Crates],[reachedDateTime] ";
                            strQry += " ,[unloadDateTime],[sealNo],[receivedRmTemp],[icCondition] ,[nextProcess] ,[farmerName] ";
                            strQry += " ,[supplierName] ,[purchaseDate],[purchaseType] ,[driverName],[vehicleNo],[TotalWeight] ";
                            strQry += " ,[purchaseCount],[BatchWiseLotNo],[dateTime],[UnloadingStatus] ,[DrainTimeCalStatus] ";
                            strQry += " ,[WeighmentStatus],[QualityStatus],[NetSamplingStatus] ,[BeheadingStatus],[TableAllocationStatus] ";
                            strQry += " ,[TableWiseStatus],[createdBy],syncDate,Flag) VALUES ( ";
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
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Data.Instance.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
                }
                else
                {
                    s = "No data found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public string InsertBatchAllocation(List<UnloadBatchAllocation> U)
        {
            bool b = false;
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
                        dt = Data.Instance.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "Insert into UnloadBatchAllocation ([BatchNumber],[BatchParent],[SaudaNumber],[DateandTime] , ";
                            strQry = strQry + " [NoofCrates] ,[Status] ,[CreatedBy],[CreatedDate],[Flag],SyncDate,Lotnumber) values ('" + uba.batchNo + "', '" + uba.batchParent + "', ";
                            strQry = strQry + " '" + uba.saudaNo + "','" + uba.dateTime + "', '" + uba.noOfCrates + "','" + uba.status + "' , ";
                            strQry = strQry + " '" + uba.createdBy + "','" + uba.createdDate + "' , 1,getdate(),'" + uba.batchNoActLot + "' ) ";
                            lstrQry.Add(strQry);
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Data.Instance.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
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

        public string InsertUnloadWashingDrainTime(List<UnloadWashingDrainTime> DTTime)
        {
            bool b = false;
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
                        dt = Data.Instance.GetDataTable(strQry);
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
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Data.Instance.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
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
            bool b = false;
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
                        dt = Data.Instance.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "Insert into [UnloadWashingWeighnment]([lotNo],[crateNo], ";
                            strQry += " [crateWt],[saudaNo],[dateTime],[BatchNo],[GrossWeight],[TotalWeight]";
                            strQry += " ,[Status],[CreatedBy],[CreatedDate],[Flag],[SyncDate]) values ( ";
                            strQry = strQry + " '" + uww.lotWiseBatch + "','" + uww.noOfCrates + "' ";
                            strQry = strQry + " , '" + uww.crateWt + "', ";
                            strQry = strQry + " '" + uww.saudaNo + "' ,'" + uww.dateTime + "','" + uww.batchParent + "' , ";
                            strQry = strQry + " '" + uww.grossWeight + "' ,'" + uww.totalRmWeight + "', '" + uww.status + "', ";
                            strQry = strQry + " '" + uww.createdBy + "','" + uww.createdDate + "' , 1,getdate() ) ";
                            lstrQry.Add(strQry);
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Data.Instance.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
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

        public string InsertUnloadNetSampling(List<UnloadRMNetSample> unloadNet)
        {
            bool b = false;
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
                        dt = Data.Instance.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = " INSERT INTO UnloadNetSampling ([LotWiseBatch],[Batchparent],[SaudaNo] ";
                            strQry += " ,[NoodNets] ,[TareWtPerNt],[GrossWeight],[TotalWeight],[SampleWeight] ";
                            strQry += " ,[NoofNormalPieces],[noOfSmallPieces],[noOfSmallPiecesAccAsOne] ";
                            strQry += " ,[TotalNoOfpieces],[PlantCount],[weightDifference],[countDifference] ";
                            strQry += " ,[CreatedBy] ,[CreatedDate],[SyncDate],[Flag]) values ( ";
                            strQry = strQry + " '" + net.lotWiseBatch + "','" + net.batchparent + "' ";
                            strQry = strQry + " , '" + net.saudaNumber + "', ";
                            strQry = strQry + " '" + net.noOfNets + "' ,'" + net.tareWtPerNet + "','" + net.grossWeight + "' , ";
                            strQry = strQry + " '" + net.totalWeight + "' ,'" + net.sampleWeight + "', '" + net.noOfnormalpieces + "', '" + net.noOfSmallPieces + "', ";
                            strQry = strQry + " '" + net.noOfSmallPiecesAccAsOne + "' ,'" + net.totalNoOfpieces + "', '" + net.plantCount + "', ";
                            strQry = strQry + " '" + net.weightDifference + "' ,'" + net.countDifference + "' , ";
                            strQry = strQry + " '" + net.createdBy + "','" + net.dateTime + "' ,getdate(), 1 ) ";
                            lstrQry.Add(strQry);
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Data.Instance.UpdateUsingExecuteNonQueryList(lstrQry)) ? strQry : "Success"));
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

        public string InsertUnloadRMQuality(List<UnloadRMQuality> unloadQty)
        {
            bool b = false;
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
                        dt = Data.Instance.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = " INSERT INTO[dbo].[UnloadRMQuality]([SaudaNumberCode],[NO_SoftPieces],[SoftPercentage], ";
                            strQry += " [No_PiecesWithBlackSpot],[PercentageOfBlackSpot],[No_PiecesNecrosis],[NecrosisPercentage], ";
                            strQry += " [Discoloration],[DiscolorationPercentage],[ColorOfShrimp],[GILLS] ,[Texture] ,[MuddySmell], ";
                            strQry += " [CleanlinessOfVehicle],[CleanlinessOfBoxes],[NO_BrokenPieces],";
                            strQry += "[BrokenPercentage], [CreatedBy],[CreatedDate] ,[Status],";
                            strQry += " [batchLotWise],[Remarks],  [SyncDate],[Flag], [WeightAllocatedForBeheading],Grader) VALUES ( ";
                            strQry = strQry + " '" + quality.saudaNo + "','" + quality.noOfSoftPieces + "','" + quality.softPercentage + "', ";
                            strQry = strQry + " '" + quality.piecesWithBlackSpot + "', ";
                            strQry = strQry + " '" + quality.percentageOfBlackSpot + "','" + quality.piecesInNecrosis + "','" + quality.necrosisPercentage + "', ";
                            strQry = strQry + " '" + quality.disColouration + "','" + quality.disColourationPercentage + "','" + quality.colorOfShrimp + "', ";
                            strQry = strQry + " '" + quality.gills + "','" + quality.freshnessTexture + "','" + quality.muddySmell + "', ";
                            strQry = strQry + " '" + quality.cleanlinessOfVehicle + "','" + quality.cleanlinessOfBoxes + "', ";
                            strQry = strQry + " '" + quality.noOfBrokenPieces + "','" + quality.brokenPercentage + "', ";
                            strQry = strQry + " '" + quality.createdBy + "','" + quality.dateAndTime + "','1','" + quality.batchLotWise + "', ";
                            strQry = strQry + " '" + quality.remarks + "',getdate(),1,'" + quality.weightAllocatedForBeheading + "','" + quality.grader + "' ) ";
                            lstrQry.Add(strQry);
                        }
                    }
                    if (lstrQry.Count > 0)
                    {
                        try
                        {
                            s = ((!Data.Instance.UpdateUsingExecuteNonQueryList(lstrQry)) ? strQry : "Success");
                        }
                        catch (Exception)
                        {
                            s = "Connection Error";
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
    }
}