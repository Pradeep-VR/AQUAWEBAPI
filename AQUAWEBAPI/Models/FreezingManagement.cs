// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.FreezingManagement
using System;
using System.Collections.Generic;
using System.Data;
using AQUA;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class FreezingManagement
    {
        Logger log = new Logger();
        Data Oldb = new Data();
        public string InsertIQFFinalData(List<Freezing> frLoad)
        {
            //bool b = false;
            string s = "";
            List<string> lstrQry = new List<string>();
            string strQry = "";
            try
            {
                if (frLoad != null)
                {
                    foreach (Freezing Pr in frLoad)
                    {
                        string strQry2 = "";
                        DataTable dt = new DataTable();
                        strQry2 = "select * from IQFFinalData where barcodeId='" + Pr.barcodeId + "' ";
                        dt = Oldb.GetDataTable(strQry2);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "";
                            strQry = " Insert into IQFFinalData(barcodeId, freezingType, machineNo, operation, batch, grade, productType, ";
                            strQry += " count, quantity, antibioticStatus, checkOfBsRatio, checkOfFlatCount, ";
                            strQry += " changeInGrade, balQtyFromBfToIqf,balQtyFromCookingToIqf, rejection, freezTemp, ";
                            strQry += " cookingTemp, cookingTime, packingAgainstCoNo, ";
                            strQry += "  packingStyle, noOfSlabsToBePacked, dc, broken, g2, big, small, ";
                            strQry += " remarks, monitoredBy, verifiedBy, dateAndTime,status,SyncDate) ";
                            strQry = strQry + "  Values('" + Pr.barcodeId + "', '" + Pr.freezingType + "', '" + Pr.machineNo + "', '" + Pr.operation + "', ";
                            strQry = strQry + " '" + Pr.batch + "', '" + Pr.grade + "', '" + Pr.productType + "', '" + Pr.count + "', '" + Pr.quantity + "', ";
                            strQry = strQry + "  '" + Pr.antibioticStatus + "', '" + Pr.checkOfBsRatio + "', '" + Pr.checkOfFlatCount + "', ";
                            strQry = strQry + " '" + Pr.changeInGrade + "',  ";
                            strQry = strQry + "  '" + Pr.balQtyFromBfToIqf + "', '" + Pr.balQtyFromCookingToIqf + "', '" + Pr.rejection + "', '" + Pr.freezTemp + "', ";
                            strQry = strQry + " '" + Pr.cookingTemp + "','" + Pr.cookingTime + "', '" + Pr.packingAgainstCoNo + "', ";
                            strQry = strQry + " '" + Pr.packingStyle + "', '" + Pr.noOfSlabsToBePacked + "','" + Pr.dc + "', '" + Pr.broken + "', '" + Pr.g2 + "', '" + Pr.big + "', ";
                            strQry = strQry + " '" + Pr.small + "', '" + Pr.remarks + "', '" + Pr.monitoredBy + "','" + Pr.verifiedBy + "', '" + Pr.dateAndTime + "','Pending',getdate()) ";
                            lstrQry.Add(strQry);
                            strQry = "";
                            strQry = " update SoakingFinalData set status ='filled' where soakingTankBarcodeId ='" + Pr.barcodeId + "' ";
                            lstrQry.Add(strQry);
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
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

        public string InsertBlockFinalData(List<FreezingBlock> frLoad)
        {
            //bool b = false;
            //bool b2 = false;
            string s = "";
            List<string> lstrQry = new List<string>();
            string strQry = "";
            try
            {
                if (frLoad != null)
                {
                    foreach (FreezingBlock Pr in frLoad)
                    {
                        DataTable dt = new DataTable();
                        string strQry2 = "select * from IQFFinalData where barcodeId='" + Pr.barcodeId + "' ";
                        dt = Oldb.GetDataTable(strQry2);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "";
                            strQry = " Insert into IQFFinalData(barcodeId, freezingType, machineNo, operation, batch, grade, productType, ";
                            strQry += " count, quantity, antibioticStatus, checkOfBsRatio, checkOfFlatCount, ";
                            strQry += " changeInGrade, balQtyFromBfToIqf,balQtyFromCookingToIqf, rejection, freezTemp, cookingTemp, cookingTime, packingAgainstCoNo, ";
                            strQry += "  packingStyle, noOfSlabsToBePacked, dc, broken, g2, big, small, ";
                            strQry += " remarks, monitoredBy, verifiedBy, dateAndTime, balQtyFromIqftoBF,packingType, gradeToBePacked, ";
                            strQry += " productTypeToBePacked,actualSlabsNeedToBeFreezed, noOfSlabsKeptInFreezer, freezingStartTime ,status,SyncDate) ";
                            strQry = strQry + "  Values('" + Pr.barcodeId + "', 'BLOCK', '" + Pr.freezerNo + "', '" + Pr.operation + "', ";
                            strQry = strQry + " '" + Pr.batch + "', '" + Pr.grade + "', '" + Pr.productType + "', '" + Pr.count + "', '" + Pr.quantity + "', ";
                            strQry = strQry + "  '" + Pr.antibioticStatus + "', '" + Pr.checkOfBsRatio + "', '" + Pr.checkOfFlatCount + "', ";
                            strQry = strQry + " '" + Pr.changeInGrade + "',  '0', '0', '" + Pr.rejection + "', '" + Pr.freezTemp + "', ";
                            strQry = strQry + " '0','', '" + Pr.packingAgainstCoNo + "', '" + Pr.blockPackingStyle + "', '" + Pr.noOfSlabsToBePacked + "','0', '0', '0', '0', ";
                            strQry = strQry + " '0', '" + Pr.remarks + "', '" + Pr.monitoredBy + "','" + Pr.verifiedBy + "', '" + Pr.dateAndTime + "' ,";
                            strQry = strQry + " '" + Pr.balQtyFromIqftoBF + "','" + Pr.packingType + "','" + Pr.gradeToBePacked + "','" + Pr.productTypeToBePacked + "',  ";
                            strQry = strQry + " '" + Pr.actualSlabsNeedToBeFreezed + "' , '" + Pr.noOfSlabsKeptInFreezer + "','" + Pr.freezingStartTime + "','Pending',getdate() ) ";
                            lstrQry.Add(strQry);
                            strQry = "";
                            strQry = " update SoakingFinalData set status ='filled' where soakingTankBarcodeId ='" + Pr.barcodeId + "' ";
                            lstrQry.Add(strQry);
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? strQry : "Success"));
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

        public string InsertMixedBatchData(List<Freezing> freeze)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (freeze != null)
                {
                    foreach (Freezing fr in freeze)
                    {
                        strQry = "select * from MixedBatchFinalData where barcodeId='" + fr.barcodeId + "'";
                        dt = Oldb.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry="";
                            strQry = " Insert into MixedBatchFinalData(barcodeId, mixedBatchNo, mixedBatchWt, totalQuantity, grade, ";
                            strQry += " variety, count, bsRatioBefFreezing, flatCountBefFreezing, gradeChange, dateAndTime, SyncDate,Flag,status) Values ";
                            strQry = strQry + " ('" + fr.barcodeId + "','" + fr.mixedBatchNo + "', '" + fr.mixedBatchWt + "', ";
                            strQry = strQry + " '" + fr.totalQuantity + "', '" + fr.grade + "', '" + fr.variety + "', '" + fr.count + "', '" + fr.bsRatioBefFreezing + "', ";
                            strQry = strQry + "  '" + fr.flatCountBefFreezing + "', '" + fr.gradeChange + "', '" + fr.dateAndTime + "',getdate(),1,'pending') ";
                            lstrQry.Add(strQry);
                            strQry = "";
                            strQry = strQry + " update SoakingFinalData set status='filled' where barcodeid='" + fr.barcodeId + "' ";
                            lstrQry.Add(strQry);
                        }
                    }
                }
                s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
            }
            catch (Exception ex)
            {
                return ex.Message + strQry;
            }
            return s;
        }

        public List<FreezingGet> GetFreezing()
        {
            var log_txt = "";
            List<FreezingGet> lFreezing = new List<FreezingGet>();
            FreezingGet fg = null;
            DataTable dt = new DataTable();
            int count = 0;
            try
            {
                count = 0;
                dt = null;
                string strqry = "";
                strqry =  "select distinct SoakingTankBarcodeID, TotalMaterialWtInTank, SoakingType, SoakOutWt, ChangeInGrade, sum(cast(presoakingWeight as float)) as presoakingWeight ,";
                strqry += "ChangeinGrade2,quantityGoneForDiffGrade,changeinProduct,  FlatCountCheck, BsRatio from SoakingFinalData where status = 'Pending' and SoakingType='Separate Tank Wise'";
                strqry += " group by SoakingTankBarcodeID,  SoakingType, FlatCountCheck, BsRatio, ChangeInGrade, changeinProduct,ChangeinGrade2,TotalMaterialWtInTank,SoakOutWt,quantityGoneForDiffGrade";

                DataTable dt2 = new DataTable();
                int ii = 0;
                dt = Oldb.GetDataTable(strqry);
                int count2 = dt.Rows.Count;
                if (count2 > 0)
                {
                    for (int ik = 0; ik < count2; ik++)
                    {
                        if (!(dt.Rows[ik]["soakingTankBarcodeID"].ToString() != ""))
                        {
                            continue;
                        }
                        string sss = "select distinct batchno from SoakingFinalData where soakingTankBarcodeId='" + dt.Rows[ik]["soakingTankBarcodeID"].ToString() + "'";
                        dt2 = Oldb.GetDataTable(sss);
                        int count3 = dt2.Rows.Count;
                        fg = new FreezingGet();
                        fg.soakingType = dt.Rows[ik]["soakingType"].ToString();
                        fg.soakingTankBarcodeID = dt.Rows[ik]["soakingTankBarcodeID"].ToString();
                        if (count3 > 0)
                        {
                            string strBatchNumber = "";
                            for (ii = 0; ii < count3; ii++)
                            {
                                strBatchNumber = ((!(strBatchNumber == "")) ? (strBatchNumber + "/" + dt2.Rows[ii]["batchno"].ToString()) : dt2.Rows[ii]["batchno"].ToString());
                            }
                            fg.batchNo = strBatchNumber;
                        }
                        fg.masterBarcodeID = dt.Rows[ik]["soakingTankBarcodeID"].ToString();
                        fg.presoakingWeight = dt.Rows[ik]["presoakingWeight"].ToString();
                        if (dt.Rows[ik]["changeinGrade2"].ToString() != "")
                        {
                            fg.grade = dt.Rows[ik]["changeinGrade2"].ToString();    
                        }
                        else
                        {
                            fg.grade = dt.Rows[ik]["ChangeInGrade"].ToString();
                        }
                        fg.changeinProduct = dt.Rows[ik]["changeinProduct"].ToString();
                        fg.soakOutWt = dt.Rows[ik]["soakOutWt"].ToString();
                        if (fg.soakOutWt != "")
                        {
                            fg.totalMaterialWtInTank = dt.Rows[ik]["soakOutWt"].ToString();
                        }
                        else
                        {
                            fg.totalMaterialWtInTank = dt.Rows[ik]["totalMaterialWtInTank"].ToString();
                        }
                        fg.quantityGoneForDiffGrade = dt.Rows[ik]["quantityGoneForDiffGrade"].ToString();
                        fg.flatCountCheck = dt.Rows[ik]["flatCountCheck"].ToString();
                        fg.bsRatio = dt.Rows[ik]["bsRatio"].ToString();
                        lFreezing.Add(fg);
                    }
                }
                strqry = "";
                strqry = "select distinct SoakingTankBarcodeID, TotalMaterialWtInTank, SoakingType, SoakOutWt, ChangeInGrade,BatchNo,barcodeIdsOfCrate, ";
                strqry += " sum(cast(presoakingWeight as float)) as presoakingWeight  ,ChangeinGrade2,  quantityGoneForDiffGrade,  ";
                strqry += " changeinProduct,  FlatCountCheck, BsRatio from SoakingFinalData   where status = 'Pending' and SoakingType = 'Separate Crate Wise' ";
                strqry += " group by SoakingTankBarcodeID,  SoakingType, FlatCountCheck, BsRatio,  ChangeInGrade, changeinProduct,ChangeinGrade2,TotalMaterialWtInTank,";
                strqry += " SoakOutWt,quantityGoneForDiffGrade,BatchNo,barcodeIdsOfCrate,BatchNo,barcodeIdsOfCrate ";
                DataTable dt3 = Oldb.GetDataTable(strqry);
                count = dt3.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string strSoakType = dt3.Rows[i]["soakingType"].ToString();
                        if (strSoakType == "Separate Crate Wise")
                        {
                            fg = new FreezingGet();
                            fg.soakingType = dt3.Rows[i]["soakingType"].ToString();
                            fg.soakingTankBarcodeID = dt3.Rows[i]["soakingTankBarcodeID"].ToString();
                            fg.masterBarcodeID = i.ToString();
                            string batch = dt3.Rows[i]["batchno"].ToString();
                            fg.batchNo = dt3.Rows[i]["BatchNo"].ToString();
                            fg.barcodeIdsofCrate = dt3.Rows[i]["barcodeIdsofCrate"].ToString();
                            fg.presoakingWeight = dt3.Rows[i]["presoakingWeight"].ToString();

                            if (dt3.Rows[i]["changeinGrade2"].ToString() != "")
                            {
                                fg.grade = dt3.Rows[i]["changeinGrade2"].ToString();
                            }
                            else
                            {
                                fg.grade = dt3.Rows[i]["ChangeInGrade"].ToString();
                            }
                            fg.changeinProduct = dt3.Rows[i]["changeinProduct"].ToString();
                            fg.soakOutWt = dt3.Rows[i]["soakOutWt"].ToString();

                            if (fg.soakOutWt != "")
                            {
                           
                                fg.totalMaterialWtInTank = dt3.Rows[i]["soakOutWt"].ToString();
                            }
                            else
                            {
                                fg.totalMaterialWtInTank = dt3.Rows[i]["totalMaterialWtInTank"].ToString();
                            }
                            fg.quantityGoneForDiffGrade = dt3.Rows[i]["quantityGoneForDiffGrade"].ToString();
                            fg.flatCountCheck = dt3.Rows[i]["flatCountCheck"].ToString();
                            fg.bsRatio = dt3.Rows[i]["bsRatio"].ToString();
                            lFreezing.Add(fg);
                        }
                    }
                }
                if(lFreezing.Count == 0)
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Get Frezing Data Failed.." + ":::" + fg;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Get Frezing Data Success !!" ;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                var log_txt_exc = DateTime.Now.ToString() + " ::: " + "Exception Catched on Get Frezing Data .." + ":::" + fg + ":::" + ex.ToString();
                log.writeLog(log_txt_exc);
                lFreezing = null;
            }
            return lFreezing;
        }
    }
}