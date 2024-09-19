// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.SoakingManagement
using System;
using System.Collections.Generic;
using System.Data;
using AQUA;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class SoakingManagement
    {
        Data Oldb = new Data();
        public List<Peeling> GetPeelingFinalData(string strStatus)
        {
            List<Peeling> lPeeling = new List<Peeling>();
            Peeling p = null;
            DataTable dt = new DataTable();
            int count = 0;
            try
            {
                count = 0;
                dt = null;
                string strqry = "";
                strqry = "SELECT [barcodeId],[syntaxTankNo],[batchNo],[grade],[productType],[targetGradingCount],[hlQtyAfterGrading],[nextProcess],[changeInProductType],[tableNoAllotedForPeeling],[contractorSelection],[peeledMaterialWeighted],[qualityIssue],[targetPeelingYield],[actualPeelingYield],[pdConvertToHlv],[ppcHlvDiff],[remarks],[dateAndTime],[status] FROM PeelingFinalData where Status='" + strStatus + "' ";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        p = new Peeling();
                        p.barcodeId = dt.Rows[i]["barcodeId"].ToString();
                        p.syntaxTankNo = dt.Rows[i]["syntaxTankNo"].ToString();
                        p.batchNo = dt.Rows[i]["batchNo"].ToString();
                        p.grade = dt.Rows[i]["grade"].ToString();
                        p.productType = dt.Rows[i]["productType"].ToString();
                        p.targetGradingCount = dt.Rows[i]["targetGradingCount"].ToString();
                        p.hlQtyAfterGrading = dt.Rows[i]["hlQtyAfterGrading"].ToString();
                        p.nextProcess = dt.Rows[i]["nextProcess"].ToString();
                        p.changeInProductType = dt.Rows[i]["changeInProductType"].ToString();
                        p.tableNoAllotedForPeeling = dt.Rows[i]["tableNoAllotedForPeeling"].ToString();
                        p.contractorSelection = dt.Rows[i]["contractorSelection"].ToString();
                        p.peeledMaterialWeighted = dt.Rows[i]["peeledMaterialWeighted"].ToString();
                        p.qualityIssue = dt.Rows[i]["qualityIssue"].ToString();
                        p.targetPeelingYield = dt.Rows[i]["targetPeelingYield"].ToString();
                        p.actualPeelingYield = dt.Rows[i]["actualPeelingYield"].ToString();
                        p.pdConvertToHlv = dt.Rows[i]["pdConvertToHlv"].ToString();
                        p.ppcHlvDiff = dt.Rows[i]["ppcHlvDiff"].ToString();
                        p.remarks = dt.Rows[i]["remarks"].ToString();
                        p.dateAndTime = dt.Rows[i]["dateAndTime"].ToString();
                        p.status = dt.Rows[i]["status"].ToString();
                        lPeeling.Add(p);
                    }
                }
            }
            catch (Exception)
            {
                lPeeling = null;
            }
            return lPeeling;
        }

        public string InsertSoakingFinalData(List<Soaking> soak)
        {
            //bool b = false;
            //bool b2 = false;
            string s = "";
            List<string> lstrQry = new List<string>();
            try
            {
                if (soak != null)
                {
                    foreach (Soaking so in soak)
                    {
                        string strQry = "";
                        string strQry2 = "";
                        string strQry3 = "";
                        DataTable dt = new DataTable();
                        strQry2 = "select * from SoakingFinalData where barcodeIdsOfCrate='" + so.barcodeIdsOfCrate + "'";
                        dt = Oldb.GetDataTable(strQry2);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "  Insert into SoakingFinalData(date, batchNo, soakingType, barcodeIdsOfCrate, ";
                            strQry += " preSoakingWeight, changeInGrade, changeInProduct, soakingTankBarcodeId, ";
                            strQry += " soakingTankSerialNo, soakingStartTime,soakingEndTime, soakingTime, ";
                            strQry += " totalMaterialWtInTank, soakOutWt, changeInGrade2,quantityGoneForDiffGrade, ";
                            strQry += "  flatCountCheck, bsRatio, remarks, chemicalStatus, dateAndTime,masterBarcodeId,SyncDate,status) Values ";
                            strQry = strQry + "  ('" + so.date + "','" + so.batchNo + "','" + so.soakingType + "','" + so.barcodeIdsOfCrate + "', ";
                            strQry = strQry + "  '" + so.preSoakingWeight + "', '" + so.changeInGrade + "', ";
                            strQry = strQry + "  '" + so.changeInProduct + "', '" + so.soakingTankBarcodeId + "', '" + so.soakingTankSerialNo + "' , ";
                            strQry = strQry + "  '" + so.soakingStartTime + "', '" + so.soakingEndTime + "' , ";
                            strQry = strQry + " '" + so.soakingTime + "' , '" + so.totalMaterialWtInTank + "','" + so.soakOutWt + "', ";
                            strQry = strQry + " '" + so.changeInGrade2 + "', '" + so.quantityGoneForDiffGrade + "' , ";
                            strQry = strQry + "  '" + so.flatCountCheck + "' , '" + so.bsRatio + "','" + so.remarks + "', '" + so.chemicalStatus + "', ";
                            strQry = strQry + " '" + so.dateAndTime + "','" + so.masterBarcodeId + "',getdate(),'pending') ";
                            lstrQry.Add(strQry);
                            strQry3 = " update PeelingFinalData set processstatus ='filled' where barcodeid = '" + so.barcodeIdsOfCrate + "' ";
                            lstrQry.Add(strQry3);
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
    }
}