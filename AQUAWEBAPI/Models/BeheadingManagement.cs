// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.BeheadingManagement
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AQUA;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class BeheadingManagement
    {
        Data Oldb = new Data();
        public async Task<List<BeheadingGet>> GetBeheadingDetails()
        {
            DataTable dt = new DataTable();
            int count = 0;
            List<BeheadingGet> bhList = new List<BeheadingGet>();
            BeheadingGet bh = null;
            try
            {
                dt = new DataTable();
                string strqry = " select SaudaNumber, batchNo, BatchWiseLotNo, farmerName, CONVERT(varchar, CONVERT(dateTIME, purchaseDate, 103), 120) AS  purchaseDate, ";
                strqry += " purchaseType,SupplierName  from UnloadFinalProcess  where BeheadingStatus = 'pending'  ";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        bh = new BeheadingGet();
                        bh.batchNumber = dt.Rows[i]["batchNo"].ToString();
                        bh.batchWiseLotNo = dt.Rows[i]["BatchWiseLotNo"].ToString();
                        bh.farmerName = dt.Rows[i]["farmerName"].ToString();
                        bh.purchaseDate = dt.Rows[i]["purchaseDate"].ToString();
                        bh.purchaseType = dt.Rows[i]["purchaseType"].ToString();
                        bh.supplierName = dt.Rows[i]["SupplierName"].ToString();
                        bhList.Add(bh);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return bhList = null;
            }
            return bhList;
        }

        public async Task<string> InsertBaheadingTableAllocation(List<BeHeadingTableAllocation> beHead)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                foreach (BeHeadingTableAllocation BH in beHead)
                {
                    strQry = "select * from BaheadingTableAllocation where BatchLotNumber='" + BH.batchNumber + "'";
                    dt = Oldb.GetDataTable(strQry);
                    if (dt.Rows.Count == 0)
                    {
                        strQry = " insert into BaheadingTableAllocation (batchNumber, BatchLotNumber, tableNumber, ";
                        strQry += " totalNoOfCrates, noOfCratesAllocated, cratesRemaining, dateTime, SyncDate) ";
                        strQry += "  values('" + BH.batchParent + "', '" + BH.batchNumber + "','" + BH.tableNumber + "',  ";
                        strQry += " '" + BH.totalNoOfCrates + "', '" + BH.noOfCratesAllocated + "', ";
                        strQry += "  '" + BH.cratesRemaining + "', '" + BH.datetime + "',getdate()) ";
                        lstrQry.Add(strQry);
                    }
                }
                s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public async Task<string> InsertBeheadingFinalData(List<Beheading> behead)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            string strQry1 = "";
            string strQry2 = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            List<string> lstrQry2 = new List<string>();
            try
            {
                foreach (Beheading BH in behead)
                {
                    strQry1 = "select * from BeheadingFinalData  where BatchLotNumber='" + BH.batchNumber + "'";
                    dt = Oldb.GetDataTable(strQry1);

                    if (dt.Rows.Count == 0)
                    {
                        strQry = " Insert into BeheadingFinalData (batchNumber,BatchLotNumber, startDate, purchaseType, supplierName, ";
                        strQry += " cratesAllocatedForBeheading, materialTempBeforeBeheading, materialTempDuringBeheading, ";
                        strQry += " materialTempAfterBeheading, headOnCountPerKg, beheadingStartTime, beheadingEndTime, ";
                        strQry += " chillWaterTemperature, calibration, sampleHeadOnWeight, sampleHeadlessWeight, sampleBeheadingYieldPercentage, bsRatio, remarks, ";
                        strQry += " monitoredBy, verifiedBy, dateAndTime,CreatedBy,SyncDate,Flag,status,ProcessStatus) values ( ";
                        strQry += " '" + BH.batchParent + "','" + BH.batchNumber + "', '" + BH.startDate + "','" + BH.purchaseType + "' , ";
                        strQry += " '" + BH.supplierName + "','" + BH.cratesAllocatedForBeheading + "' , '" + BH.materialTempBeforeBeheading + "' , ";
                        strQry += " '" + BH.materialTempDuringBeheading + "','" + BH.materialTempAfterBeheading + "' , '" + BH.headOnCountPerKg + "' , ";
                        strQry += " '" + BH.beheadingStartTime + "','" + BH.beheadingEndTime + "' , '" + BH.chillWaterTemperature + "' , ";
                        strQry += " '" + BH.calibration + "','" + BH.sampleHeadOnWeight + "' , '" + BH.sampleHeadlessWeight + "' , ";
                        strQry += " '" + BH.sampleBeheadingYieldPercentage + "','" + BH.weightOfBatchAfterBeheading + "' , '" + BH.remarks + "' , ";
                        strQry += " '" + BH.monitoredBy + "','" + BH.verifiedBy + "' , '" + BH.dateAndTime + "' , ";
                        strQry += " '" + BH.createdBy + "', getdate(),1,'pending','Open') ";
                        lstrQry.Add(strQry);

                        strQry2 = "update UnloadFinalProcess  set BeheadingStatus = 'filled'  where batchwiselotno = '" + BH.batchNumber + "' ";
                        lstrQry.Add(strQry2);
                    }
                }
                s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? strQry : "Success"));
            }
            catch (Exception ex)
            {
                return ex.Message + strQry;
            }
            return s;
        }

        public async Task<string> InsertBeheadingTablewise(List<BeHeadingTableWise> beHead)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                foreach (BeHeadingTableWise BH in beHead)
                {
                    strQry = "select * from BeheadingTablewise where BatchLotNumber='" + BH.batchNumber + "'";
                    dt = Oldb.GetDataTable(strQry);
                    if (dt.Rows.Count == 0)
                    {
                        strQry = " insert into BeheadingTablewise(batchNumber,BatchLotNumber, tableNo, totalNoOfPieces, ";
                        strQry += " noOfCuttingPieces,noOfBlackMeatPieces, cuttingPercentage, blackMeatPercentage, dateTime,SyncDate) ";
                        strQry += " values('" + BH.batchParent + "','" + BH.batchNumber + "', '" + BH.tableNumber + "', '" + BH.totalNoOfPieces + "', '" + BH.noOfCuttingPieces + "', ";
                        strQry += " '" + BH.noOfBlackMeatPieces + "', '" + BH.noOfBlackMeatPieces + "','" + BH.cuttingPercentage + "','" + BH.blackMeatPercentage + "', '" + BH.datetime + "',getdate()) ";
                        lstrQry.Add(strQry);
                    }
                }
                s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        /* New Api Function's */
        public async Task<string> InsertBeheadingTablewiseNew(BeHeadingTableWiseNew BH)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {

                strQry = "select * from BeheadingTablewise where BatchLotNumber='" + BH.batchNumber + "'";
                dt = Oldb.GetDataTable(strQry);
                if (dt.Rows.Count == 0)
                {
                    strQry = " insert into BeheadingTablewise(batchNumber,BatchLotNumber, tableNo, totalNoOfPieces, ";
                    strQry += " noOfCuttingPieces,noOfBlackMeatPieces, cuttingPercentage, blackMeatPercentage, dateTime,SyncDate) ";
                    strQry += " values('" + BH.batchParent + "','" + BH.batchNumber + "', '" + BH.tableNumber + "', '" + BH.totalNoOfPieces + "', '" + BH.noOfCuttingPieces + "', ";
                    strQry += " '" + BH.noOfBlackMeatPieces + "', '" + BH.noOfBlackMeatPieces + "','" + BH.cuttingPercentage + "','" + BH.blackMeatPercentage + "', '" + BH.datetime + "',getdate()) ";
                    lstrQry.Add(strQry);
                }

                s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }
        public async Task<string> InsertBeheadingFinalDataNew(BeheadingNew BH)
        {
            string s = "";
            string strQry = "";
            string strQry1 = "";
            string strQry2 = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            List<string> lstrQry2 = new List<string>();
            try
            {
                strQry1 = "select * from BeheadingFinalData  where BatchLotNumber='" + BH.batchNumber + "'";
                dt = Oldb.GetDataTable(strQry1);

                if (dt.Rows.Count == 0)
                {
                    strQry = " Insert into BeheadingFinalData (batchNumber,BatchLotNumber, startDate, purchaseType, supplierName, ";
                    strQry += " cratesAllocatedForBeheading, materialTempBeforeBeheading, materialTempDuringBeheading, ";
                    strQry += " materialTempAfterBeheading, headOnCountPerKg, beheadingStartTime, beheadingEndTime, ";
                    strQry += " chillWaterTemperature, calibration, sampleHeadOnWeight, sampleHeadlessWeight, sampleBeheadingYieldPercentage, bsRatio, remarks, ";
                    strQry += " monitoredBy, verifiedBy, dateAndTime,CreatedBy,SyncDate,Flag,status,ProcessStatus) values ( ";
                    strQry += " '" + BH.batchParent + "','" + BH.batchNumber + "', '" + BH.startDate + "','" + BH.purchaseType + "' , ";
                    strQry += " '" + BH.supplierName + "','" + BH.cratesAllocatedForBeheading + "' , '" + BH.materialTempBeforeBeheading + "' , ";
                    strQry += " '" + BH.materialTempDuringBeheading + "','" + BH.materialTempAfterBeheading + "' , '" + BH.headOnCountPerKg + "' , ";
                    strQry += " '" + BH.beheadingStartTime + "','" + BH.beheadingEndTime + "' , '" + BH.chillWaterTemperature + "' , ";
                    strQry += " '" + BH.calibration + "','" + BH.sampleHeadOnWeight + "' , '" + BH.sampleHeadlessWeight + "' , ";
                    strQry += " '" + BH.sampleBeheadingYieldPercentage + "','" + BH.weightOfBatchAfterBeheading + "' , '" + BH.remarks + "' , ";
                    strQry += " '" + BH.monitoredBy + "','" + BH.verifiedBy + "' , '" + BH.dateAndTime + "' , ";
                    strQry += " '" + BH.createdBy + "', getdate(),1,'pending','Open') ";
                    lstrQry.Add(strQry);

                    strQry2 = "update UnloadFinalProcess  set BeheadingStatus = 'filled'  where batchwiselotno = '" + BH.batchNumber + "' ";
                    lstrQry.Add(strQry2);
                }

                s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? strQry : "Success"));
            }
            catch (Exception ex)
            {
                return ex.Message + strQry;
            }
            return s;
        }
        public async Task<string> InsertBaheadingTableAllocationNew(BeHeadingTableAllocationNew BH)
        {
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (BH != null)
                {
                    strQry = "SELECT * FROM BaheadingTableAllocation WHERE BatchLotNumber='" + BH.batchNumber + "'";
                    dt = Oldb.GetDataTable(strQry);
                    if (dt.Rows.Count == 0)
                    {
                        strQry = " INSERT INTO BaheadingTableAllocation (batchNumber, BatchLotNumber, tableNumber, ";
                        strQry += " totalNoOfCrates, noOfCratesAllocated, cratesRemaining, dateTime, SyncDate) ";
                        strQry += "  VALUES('" + BH.batchParent + "', '" + BH.batchNumber + "','" + BH.tableNumber + "',  ";
                        strQry += " '" + BH.totalNoOfCrates + "', '" + BH.noOfCratesAllocated + "', ";
                        strQry += "  '" + BH.cratesRemaining + "', '" + BH.dateTime + "',getdate()) ";
                        lstrQry.Add(strQry);
                    }

                    s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
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