// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.PurchaseManagement
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AQUA;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class PurchaseManagement
    {
        Logger log = new Logger();
        Data Oldb = new Data();
        public string InsertAQUAPurchaseDetails(Purchase AP)
        {
            //bool b = false;
            string s = "";
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("LotNumber", AP.lotNo));
                parameters.Add(new SqlParameter("SaudaNumberCode", AP.saudaNumberCode));
                parameters.Add(new SqlParameter("PurchaseDate", AP.purchaseDate));
                parameters.Add(new SqlParameter("PurchaseType", AP.purchaseType));
                parameters.Add(new SqlParameter("SupplierName", AP.supplierName));
                parameters.Add(new SqlParameter("FarmerName", AP.farmerName));
                parameters.Add(new SqlParameter("Village", AP.village));
                parameters.Add(new SqlParameter("Mandal", AP.mandal));
                parameters.Add(new SqlParameter("District", AP.district));
                parameters.Add(new SqlParameter("SaudaState", AP.saudaState));
                parameters.Add(new SqlParameter("HarvestStartTime", AP.harveststarttime));
                parameters.Add(new SqlParameter("HarvestEndTime", AP.harvestendtime));
                parameters.Add(new SqlParameter("PlantID", AP.plantID));
                parameters.Add(new SqlParameter("No_Of_Nets", AP.noOfNets));
                parameters.Add(new SqlParameter("Tare_Weight_Per_Net", AP.tareWeightPerNet));
                parameters.Add(new SqlParameter("GrossWeight", AP.grossWeight));
                parameters.Add(new SqlParameter("TotalWeight", AP.totalWeight));
                parameters.Add(new SqlParameter("SampleWeight", AP.sampleWeight));
                parameters.Add(new SqlParameter("No_of_Normal_Pieces", AP.noofNormalPieces));
                parameters.Add(new SqlParameter("No_Of_Small_pieces", AP.noOfSmallpieces));
                parameters.Add(new SqlParameter("No_Of_Small_Accounted_One", AP.noOfSmallAccountedOne));
                parameters.Add(new SqlParameter("Total_Number_Of_Pieces", AP.totalNumberOfPieces));
                parameters.Add(new SqlParameter("WeightDeduction", AP.weightDeduction));
                parameters.Add(new SqlParameter("CountAdjustment", AP.countAdjustment));
                parameters.Add(new SqlParameter("PurchaseCountPerKG", AP.purchaseCountPerKG));
                parameters.Add(new SqlParameter("NO_SoftPieces", AP.noOfSoftPieces));
                parameters.Add(new SqlParameter("No_PiecesWithBlackSpot", AP.noOfPiecesWithBlackSpot));
                parameters.Add(new SqlParameter("No_PiecesNecrosis", AP.noOfPiecesInNecrosis));
                parameters.Add(new SqlParameter("Discoloration", AP.discoloration));
                parameters.Add(new SqlParameter("NO_BrokenPieces", AP.noOfBrokenPieces));
                parameters.Add(new SqlParameter("CreatedBy", AP.createdBy));
                parameters.Add(new SqlParameter("CreatedDate", AP.createdDate));
                parameters.Add(new SqlParameter("Status", AP.status));
                s = ((!Oldb.ExecuteSP_new(parameters, "WSP_InsertPurchase")) ? "Fail" : "Success");
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
            return s;
        }

        public DataTable GetCount(string strLotNumber, string strStatus, string strTableName)
        {
            DataTable dt = new DataTable();
            string strQry = "";
            try
            {
                if (strStatus == "U" && strTableName == "Purchase")
                {
                    strQry = "select * from Purchase where LotNumber='" + strLotNumber + "' and SyncStatus ='U' ";
                }
                else if (strStatus == "" && strTableName == "Purchase")
                {
                    strQry = "select * from Purchase where LotNumber='" + strLotNumber + "' ";
                }
                else
                {
                    switch (strTableName)
                    {
                        case "WEIGHT":
                            strQry = " SELECT * FROM  [Weighment] WHERE  LotNumber = '" + strLotNumber + "' ";
                            break;
                        case "SAMPLE":
                            strQry = " SELECT * FROM  [RMPWeighmentNetSampling] WHERE  LotNumber = '" + strLotNumber + "' ";
                            break;
                        case "QUALITY":
                            strQry = "  SELECT * FROM  [RMPQuality] WHERE LotNumber = '" + strLotNumber + "'  ";
                            break;
                    }
                }
                return Oldb.GetDataTable(strQry);
            }
            catch (Exception)
            {
                return dt = null;
            }
        }

        public async Task<string> InsertAQUAPurchaseDetailsNew(List<Purchase> P)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            List<string> DuplstrQry = new List<string>();
            try
            {
                foreach (Purchase p1 in P)
                {
                    dt = GetCount(p1.lotNo, "", "Purchase");
                    if (dt.Rows.Count == 0)
                    {
                        if (p1.purchaseType.ToLower() == "pond purchase")
                        {
                            strQry = "Insert Into  [Purchase] (LotNumber, SaudaNumberCode, PurchaseDate,  PurchaseType, SupplierName, FarmerName, Village, Mandal, District, ";
                            strQry += " HarvestStartTime, HarvestEndTime, CreatedDate, CreatedBy, Status, ProcessStatus, SaudaState, noOfSoftPieces, noOfPiecesWithBlackSpot, ";
                            strQry += " noOfPiecesInNecrosis, discoloration, noOfBrokenPieces,SyncStatus,SyncDate) Values";
                            strQry = strQry + " ('" + p1.lotNo + "','" + p1.saudaNumberCode + "','" + p1.purchaseDate + "','" + p1.purchaseType + "','" + p1.supplierName + "', ";
                            strQry = strQry + "  '" + p1.farmerName + "','" + p1.village + "','" + p1.mandal + "','" + p1.district + "','" + p1.harveststarttime + "', ";
                            strQry = strQry + " '" + p1.harvestendtime + "','" + p1.createdDate + "','" + p1.createdBy + "','" + p1.status + "', ";
                            strQry = strQry + " 'PENDING','" + p1.saudaState + "','" + p1.noOfSoftPieces + "','" + p1.noOfPiecesWithBlackSpot + "', ";
                            strQry = strQry + " '" + p1.noOfPiecesInNecrosis + "','" + p1.discoloration + "','" + p1.noOfBrokenPieces + "','I',getdate()) ";
                            lstrQry.Add(strQry);
                        }
                        else if (p1.purchaseType.ToLower() == "factory purchase")
                        {
                            strQry = "Insert Into  [Purchase] (LotNumber, SaudaNumberCode, PurchaseDate,  PurchaseType, SupplierName, FarmerName, Village, Mandal, District, ";
                            strQry += " HarvestStartTime, HarvestEndTime, CreatedDate, CreatedBy, Status, ProcessStatus, SaudaState, noOfSoftPieces, noOfPiecesWithBlackSpot, ";
                            strQry += " noOfPiecesInNecrosis, discoloration, noOfBrokenPieces,SyncStatus,SyncDate) Values";
                            strQry = strQry + " ('" + p1.lotNo + "','" + p1.saudaNumberCode + "','" + p1.purchaseDate + "','" + p1.purchaseType + "','" + p1.supplierName + "', ";
                            strQry = strQry + "  '" + p1.farmerName + "','" + p1.village + "','" + p1.mandal + "','" + p1.district + "','" + p1.harveststarttime + "', ";
                            strQry = strQry + " '" + p1.harvestendtime + "','" + p1.createdDate + "','" + p1.createdBy + "','" + p1.status + "', ";
                            strQry = strQry + " 'PENDING','" + p1.saudaState + "','" + p1.noOfSoftPieces + "','" + p1.noOfPiecesWithBlackSpot + "', ";
                            strQry = strQry + " '" + p1.noOfPiecesInNecrosis + "','" + p1.discoloration + "','" + p1.noOfBrokenPieces + "','I',getdate()) ";
                            lstrQry.Add(strQry);
                        }
                    }
                    
                    dt = GetCount(p1.lotNo, "", "WEIGHT");
                    if (dt.Rows.Count == 0)
                    {
                        strQry = "  Insert Into  [Weighment] (LotNumber,PlantID,No_Of_Nets,Tare_Weight_Per_Net,  GrossWeight,SupplierName, ";
                        strQry += " TotalWeight,SaudaNumberCode,CreatedBy,CreatedDate,Status) values ";
                        strQry = strQry + " ('" + p1.lotNo + "', '" + p1.plantID + "', '" + p1.noOfNets + "','" + p1.tareWeightPerNet + "', ";
                        strQry = strQry + " '" + p1.grossWeight + "', '" + p1.supplierName + "','" + p1.totalWeight + "', '" + p1.saudaNumberCode + "', ";
                        strQry = strQry + " '" + p1.createdBy + "','" + p1.createdDate + "', '" + p1.status + "') ";
                        lstrQry.Add(strQry);
                    }
                    else
                    {
                        strQry = "  Insert Into  [Weighment] (LotNumber,PlantID,No_Of_Nets,Tare_Weight_Per_Net,  GrossWeight,SupplierName, ";
                        strQry += " TotalWeight,SaudaNumberCode,CreatedBy,CreatedDate,Status) values ";
                        strQry = strQry + " ('" + p1.lotNo + "', '" + p1.plantID + "', '" + p1.noOfNets + "','" + p1.tareWeightPerNet + "', ";
                        strQry = strQry + " '" + p1.grossWeight + "', '" + p1.supplierName + "','" + p1.totalWeight + "', '" + p1.saudaNumberCode + "', ";
                        strQry = strQry + " '" + p1.createdBy + "','" + p1.createdDate + "', '" + p1.status + "') ";
                        DuplstrQry.Add(strQry);
                    }
                    
                    dt = GetCount(p1.lotNo, "", "SAMPLE");
                    if (dt.Rows.Count == 0)
                    {
                        strQry = "  Insert Into  [RMPWeighmentNetSampling]  (SaudaNumberCode,SupplierName,SampleWeight,No_of_Normal_Pieces,No_Of_Small_pieces, ";
                        strQry += " No_Of_Small_Accounted_One,Total_Number_Of_Pieces,WeightDeduction,CountAdjustment, PurchaseCountPerKG,PlantID,CreatedBy,CreatedDate,Status, LotNumber) values ";
                        strQry = strQry + " ('" + p1.saudaNumberCode + "', '" + p1.supplierName + "', '" + p1.sampleWeight + "', '" + p1.noofNormalPieces + "', '" + p1.noOfSmallpieces + "' , ";
                        strQry = strQry + "  '" + p1.noOfSmallAccountedOne + "', '" + p1.totalNumberOfPieces + "', '" + p1.weightDeduction + "', '" + p1.countAdjustment + "', ";
                        strQry = strQry + " '" + p1.purchaseCountPerKG + "', '" + p1.plantID + "', '" + p1.createdBy + "','" + p1.createdDate + "', '" + p1.status + "', '" + p1.lotNo + "') ";
                        lstrQry.Add(strQry);
                    }
                    else
                    {
                        strQry = "  Insert Into  [RMPWeighmentNetSampling]  (SaudaNumberCode,SupplierName,SampleWeight,No_of_Normal_Pieces,No_Of_Small_pieces, ";
                        strQry += " No_Of_Small_Accounted_One,Total_Number_Of_Pieces,WeightDeduction,CountAdjustment, PurchaseCountPerKG,PlantID,CreatedBy,CreatedDate,Status, LotNumber) values ";
                        strQry = strQry + " ('" + p1.saudaNumberCode + "', '" + p1.supplierName + "', '" + p1.sampleWeight + "', '" + p1.noofNormalPieces + "', '" + p1.noOfSmallpieces + "' , ";
                        strQry = strQry + "  '" + p1.noOfSmallAccountedOne + "', '" + p1.totalNumberOfPieces + "', '" + p1.weightDeduction + "', '" + p1.countAdjustment + "', ";
                        strQry = strQry + " '" + p1.purchaseCountPerKG + "', '" + p1.plantID + "', '" + p1.createdBy + "','" + p1.createdDate + "', '" + p1.status + "', '" + p1.lotNo + "') ";                        
                        DuplstrQry.Add(strQry);
                    }
                    
                    dt = GetCount(p1.lotNo, "", "QUALITY");
                    if (dt.Rows.Count == 0)
                    {
                        strQry = "Insert Into  [RMPQuality] (SaudaNumberCode, NO_SoftPieces, No_PiecesWithBlackSpot, No_PiecesNecrosis, ";
                        strQry += " Discoloration, NO_BrokenPieces, LotNumber, CreatedBy,CreatedDate,Status) Values   ";
                        strQry = strQry + " ('" + p1.saudaNumberCode + "', '" + p1.noOfSoftPieces + "', '" + p1.noOfPiecesWithBlackSpot + "', '" + p1.noOfPiecesInNecrosis + "',  ";
                        strQry = strQry + "  '" + p1.discoloration + "', '" + p1.noOfBrokenPieces + "', '" + p1.lotNo + "', '" + p1.createdBy + "', '" + p1.createdDate + "', '" + p1.status + "' ) ";
                        lstrQry.Add(strQry);
                    }
                    else
                    {
                        strQry = "Insert Into  [RMPQuality] (SaudaNumberCode, NO_SoftPieces, No_PiecesWithBlackSpot, No_PiecesNecrosis, ";
                        strQry += " Discoloration, NO_BrokenPieces, LotNumber, CreatedBy,CreatedDate,Status) Values   ";
                        strQry = strQry + " ('" + p1.saudaNumberCode + "', '" + p1.noOfSoftPieces + "', '" + p1.noOfPiecesWithBlackSpot + "', '" + p1.noOfPiecesInNecrosis + "',  ";
                        strQry = strQry + "  '" + p1.discoloration + "', '" + p1.noOfBrokenPieces + "', '" + p1.lotNo + "', '" + p1.createdBy + "', '" + p1.createdDate + "', '" + p1.status + "' ) ";
                        DuplstrQry.Add(strQry);
                    }
                }
                try
                {
                    s = ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "Fail" : "Success");
                }
                catch (Exception)
                {
                    s = "Connection issue" + strQry;
                }
                
                if(DuplstrQry.Count > 0)
                {
                    foreach(var item in DuplstrQry)
                    {
                        var logTxt = DateTime.Now.ToString() + ":::" + "Duplicate Query Generated  ::: " + item;
                        log.writeDataLog(logTxt);
                    }
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