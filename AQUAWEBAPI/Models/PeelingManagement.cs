// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.PeelingManagement
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AQUA;
using AQUAWEBAPI.Models;



namespace AQUAWEBAPI
{

    public class PeelingManagement
    {
        Logger log = new Logger();
        Data Oldb = new Data();
        public async Task<string> InsertPeelingRejectionFinalData(List<PeelingRejection> peelRej)
        {
            //bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (peelRej != null)
                {
                    foreach (PeelingRejection p in peelRej)
                    {
                        if (p != null)
                        {
                            strQry = "select * from PeelingRejectionFinalData where barcodeId='" + p.barcodeId + "'";
                            dt = Oldb.GetDataTable(strQry);
                            if (dt.Rows.Count == 0)
                            {
                                strQry = "";
                                strQry = "  Insert into PeelingRejectionFinalData(barcodeId, batchNo, ";
                                strQry += " selectGrade, initialProductType,HLQtyRejForPeeling, ";
                                strQry += " newProductType, tableNo, peelingDate, peeledQty, peelingYield, ";
                                strQry += "  qualityIssue, remarks, dateAndTime, status,SyncDate)  Values  ";
                                strQry += " ('" + p.barcodeId + "', '" + p.batchNo + "', '" + p.selectGrade + "','" + p.initialProductType + "', ";
                                strQry += " '" + p.hlQtyRejForPeeling + "', '" + p.newProductType + "', '" + p.tableNo + "','" + p.peelingDate + "', ";
                                strQry += " '" + p.peeledQty + "','" + p.peelingYield + "','" + p.qualityIssue + "','" + p.remarks + "', ";
                                strQry += " '" + p.dateAndTime + "', '" + p.status + "' ,getdate()) ";
                                lstrQry.Add(strQry);
                            }
                            else
                            {
                                strQry = "";
                                strQry = "  update PeelingRejectionFinalData set  batchNo ='" + p.batchNo + "', ";
                                strQry += " selectGrade='" + p.selectGrade + "', initialProductType='" + p.initialProductType + "',HLQtyRejForPeeling='" + p.hlQtyRejForPeeling + "' , ";
                                strQry += " newProductType='" + p.newProductType + "', tableNo='" + p.tableNo + "', peelingDate='" + p.peelingDate + "', peeledQty='" + p.peeledQty + "', peelingYield='" + p.peelingYield + "', ";
                                strQry += "  qualityIssue='" + p.qualityIssue + "', remarks='" + p.remarks + "', dateAndTime='" + p.dateAndTime + "', status='" + p.status + "',SyncDate=getdate() ";
                                strQry += " where barcodeId='" + p.barcodeId + "' ";
                                lstrQry.Add(strQry);
                            }
                        }
                    }
                    if (lstrQry.Count > 0)
                    {
                        try
                        {
                            s = ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success");
                        }
                        catch (Exception ex2)
                        {
                            return "Check the connection" + strQry + ex2.ToString();
                        }
                    }
                    else
                    {
                        s = "Please contact admin";
                    }
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

        public async Task<string> InsertPeelingFinalData(List<Peeling> p1)
        {
            //bool b = false;
            string s = "";
            List<string> lstrQry = new List<string>();
            List<string> lstrQry2 = new List<string>();
            List<string> lstrQry3 = new List<string>();
            List<string> lstrQry4 = new List<string>();
            string strQry3 = "";
            string strBatchNo = "";
            try
            {
                if (p1 != null)
                {
                    foreach (Peeling p2 in p1)
                    {
                        string strQry = "";
                        string strQry2 = "";
                        string strQry4 = "";
                        DataTable dt = new DataTable();
                        strBatchNo = p2.batchNo.ToString();
                        if (p2.soakingProcess == "Required")
                        {
                            strQry2 = "select * from PeelingFinalData where barcodeId='" + p2.barcodeId + "' ";
                            dt = Oldb.GetDataTable(strQry2);

                            if (dt.Rows.Count == 0)
                            {
                                strQry = "  Insert into PeelingFinalData(barcodeId, syntaxTankNo, batchNo, grade, productType, ";
                                strQry += " targetGradingCount, hlQtyAfterGrading, nextProcess, changeInProductType, ";
                                strQry += " tableNoAllotedForPeeling,contractorSelection, peeledMaterialWeighted, qualityIssue, ";
                                strQry += " targetPeelingYield,actualPeelingYield, pdConvertToHlv, ppcHlvDiff, remarks, ";
                                strQry += " dateAndTime, status,SyncDate,processstatus,SoakingProcess) Values('" + p2.barcodeId + "', '" + p2.syntaxTankNo + "', '" + p2.batchNo + "', '" + p2.grade + "', ";
                                strQry += " '" + p2.productType + "', '" + p2.targetGradingCount + "', '" + p2.hlQtyAfterGrading + "',";
                                strQry += " '" + p2.nextProcess + "', '" + p2.changeInProductType + "', '" + p2.tableNoAllotedForPeeling + "', ";
                                strQry += " '" + p2.contractorSelection + "','" + p2.peeledMaterialWeighted + "', '" + p2.qualityIssue + "', ";
                                strQry += " '" + p2.targetPeelingYield + "', '" + p2.actualPeelingYield + "', '" + p2.pdConvertToHlv + "', ";
                                strQry += " '" + p2.ppcHlvDiff + "', '" + p2.remarks + "', '" + p2.dateAndTime + "','" + p2.status + "', ";
                                strQry += " getdate(),'filled','" + p2.soakingProcess + "') ";
                                lstrQry.Add(strQry);
                                strQry4 = "  update GradingScanningProcess set status = 'filled' where barcode = '" + p2.barcodeId + "' ";
                                lstrQry.Add(strQry4);
                            }
                            else
                            {
                                strQry = "";
                                strQry = "   update PeelingFinalData set  syntaxTankNo = '" + p2.syntaxTankNo + "', ";
                                strQry += "  batchNo = '" + p2.batchNo + "', grade = '" + p2.grade + "', productType = '" + p2.productType + "', ";
                                strQry += "  targetGradingCount = '" + p2.targetGradingCount + "', hlQtyAfterGrading = '" + p2.hlQtyAfterGrading + "', ";
                                strQry += "  nextProcess = '" + p2.nextProcess + "', changeInProductType = '" + p2.changeInProductType + "', ";
                                strQry += "  tableNoAllotedForPeeling = '" + p2.tableNoAllotedForPeeling + "', contractorSelection = '" + p2.contractorSelection + "', ";
                                strQry += "  peeledMaterialWeighted = '" + p2.peeledMaterialWeighted + "', qualityIssue = '" + p2.qualityIssue + "', ";
                                strQry += "  targetPeelingYield = '" + p2.targetPeelingYield + "', actualPeelingYield = '" + p2.actualPeelingYield + "', ";
                                strQry += "  pdConvertToHlv = '" + p2.pdConvertToHlv + "', ppcHlvDiff = '" + p2.ppcHlvDiff + "', remarks = '" + p2.remarks + "', ";
                                strQry += "  dateAndTime = '" + p2.dateAndTime + "', status = '" + p2.status + "', SyncDate = getdate() , SoakingProcess = '" + p2.soakingProcess + "' ";
                                strQry += "  where barcodeId = '" + p2.barcodeId + "' ";
                                lstrQry.Add(strQry);
                            }
                        }
                        else if (p2.soakingProcess == "Not Required")
                        {

                            strQry2 = "select * from PeelingFinalData where barcodeId='" + p2.barcodeId + "' ";
                            dt = Oldb.GetDataTable(strQry2);


                            if (dt.Rows.Count == 0)
                            {
                                strQry = "";
                                strQry = "  Insert into PeelingFinalData(barcodeId, syntaxTankNo, batchNo, grade, productType, ";
                                strQry += " targetGradingCount, hlQtyAfterGrading, nextProcess, changeInProductType, ";
                                strQry += " tableNoAllotedForPeeling,contractorSelection, peeledMaterialWeighted, qualityIssue, ";
                                strQry += " targetPeelingYield,actualPeelingYield, pdConvertToHlv, ppcHlvDiff, remarks, ";
                                strQry += " dateAndTime, status,SyncDate,processstatus,SoakingProcess) Values('" + p2.barcodeId + "', '" + p2.syntaxTankNo + "', '" + p2.batchNo + "', '" + p2.grade + "', ";
                                strQry += " '" + p2.productType + "', '" + p2.targetGradingCount + "', '" + p2.hlQtyAfterGrading + "',";
                                strQry += " '" + p2.nextProcess + "', '" + p2.changeInProductType + "', '" + p2.tableNoAllotedForPeeling + "', ";
                                strQry += " '" + p2.contractorSelection + "','" + p2.peeledMaterialWeighted + "', '" + p2.qualityIssue + "', ";
                                strQry += " '" + p2.targetPeelingYield + "', '" + p2.actualPeelingYield + "', '" + p2.pdConvertToHlv + "', ";
                                strQry += " '" + p2.ppcHlvDiff + "', '" + p2.remarks + "', '" + p2.dateAndTime + "','" + p2.status + "', ";
                                strQry += " getdate(),'filled','" + p2.soakingProcess + "') ";
                                lstrQry.Add(strQry);
                                strQry4 = "  update GradingScanningProcess set status = 'filled' where barcode = '" + p2.barcodeId + "' ";
                                lstrQry.Add(strQry4);

                                string strQry5 = "  Insert into SoakingFinalData(date, batchNo, soakingType, barcodeIdsOfCrate, ";
                                strQry5 += " preSoakingWeight, changeInGrade, changeInProduct, soakingTankBarcodeId, ";
                                strQry5 += " soakingTankSerialNo, soakingStartTime,soakingEndTime, soakingTime, ";
                                strQry5 += " totalMaterialWtInTank, soakOutWt, changeInGrade2,quantityGoneForDiffGrade, ";
                                strQry5 += "  flatCountCheck, bsRatio, remarks, chemicalStatus, dateAndTime,masterBarcodeId,SyncDate,status) Values ";
                                strQry5 += "  (getdate(),'" + p2.batchNo + "','Separate Crate Wise','" + p2.barcodeId + "', ";
                                strQry5 += "  '" + p2.peeledMaterialWeighted + "', '" + p2.grade + "', ";
                                strQry5 += "  '" + p2.changeInProductType + "', ' ', '' , ";
                                strQry5 += "  getdate(), getdate(), ";
                                strQry5 += " getdate() , '" + p2.peeledMaterialWeighted + "','" + p2.peeledMaterialWeighted + "', ";
                                strQry5 += " '', '' , ";
                                strQry5 += "  ' ' , ' ','" + p2.remarks + "', ' ', ";
                                strQry5 += " getdate(),'" + p2.barcodeId + "',getdate(),'pending') ";
                                lstrQry.Add(strQry5);
                            }
                            else
                            {
                                strQry = "   update PeelingFinalData set  syntaxTankNo = '" + p2.syntaxTankNo + "', ";
                                strQry += "  batchNo = '" + p2.batchNo + "', grade = '" + p2.grade + "', productType = '" + p2.productType + "', ";
                                strQry += "  targetGradingCount = '" + p2.targetGradingCount + "', hlQtyAfterGrading = '" + p2.hlQtyAfterGrading + "', ";
                                strQry += "  nextProcess = '" + p2.nextProcess + "', changeInProductType = '" + p2.changeInProductType + "', ";
                                strQry += "  tableNoAllotedForPeeling = '" + p2.tableNoAllotedForPeeling + "', contractorSelection = '" + p2.contractorSelection + "', ";
                                strQry += "  peeledMaterialWeighted = '" + p2.peeledMaterialWeighted + "', qualityIssue = '" + p2.qualityIssue + "', ";
                                strQry += "  targetPeelingYield = '" + p2.targetPeelingYield + "', actualPeelingYield = '" + p2.actualPeelingYield + "', ";
                                strQry += "  pdConvertToHlv = '" + p2.pdConvertToHlv + "', ppcHlvDiff = '" + p2.ppcHlvDiff + "', remarks = '" + p2.remarks + "', ";
                                strQry += "  dateAndTime = '" + p2.dateAndTime + "', status = '" + p2.status + "', SyncDate = getdate(), SoakingProcess = '" + p2.soakingProcess + "' ";
                                strQry += "  where barcodeId = '" + p2.barcodeId + "' ";
                                lstrQry.Add(strQry);
                            }
                        }
                    }
                    if (lstrQry.Count > 0)
                    {
                        try
                        {
                            if (Oldb.UpdateUsingExecuteNonQueryList(lstrQry))
                            {

                                string strq = "select * from PeelingFinalData where batchNo = '" + strBatchNo + "' ";
                                string strq2 = " select * from GradingScanningProcess where batchNo = '" + strBatchNo + "' ";
                                int peelingcount = 0;
                                int gradcount = 0;
                                DataTable dt2 = new DataTable();
                                DataTable dt3 = new DataTable();
                                dt2 = Oldb.GetDataTable(strq);
                                dt3 = Oldb.GetDataTable(strq2);

                                if (dt2.Rows.Count > 0)
                                {
                                    peelingcount = dt2.Rows.Count;
                                }
                                if (dt3.Rows.Count > 0)
                                {
                                    gradcount = dt3.Rows.Count;
                                }
                                if (gradcount == peelingcount)
                                {

                                    strQry3 = "update GradingProcess set status ='filled' where batchnumber ='" + strBatchNo + "' ";
                                    Oldb.ExecuteNonQuery(strQry3);

                                }
                                s = "Success";
                            }
                            else
                            {
                                s = "fail";

                            }
                        }
                        catch (Exception)
                        {
                            return "Check the connection";
                        }
                    }
                    else
                    {
                        s = "Please contact admin";
                    }
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

        public async Task<List<Peeling>> GetPeelingFinalData(string strStatus, string beforedays)
        {
            List<Peeling> lPeeling = new List<Peeling>();
            Peeling p = null;
            DataTable dt = new DataTable();
            int count = 0;
            var log_txt = "";
            try
            {

                count = 0;
                dt = null;
                string strqry = "";
                strqry = "SELECT [barcodeId],[syntaxTankNo],[batchNo],[grade],[productType],[targetGradingCount],[hlQtyAfterGrading],[nextProcess]," +
                    "[changeInProductType],[tableNoAllotedForPeeling],[contractorSelection],[peeledMaterialWeighted],[qualityIssue],[targetPeelingYield]," +
                    "[actualPeelingYield],[pdConvertToHlv],[ppcHlvDiff],[remarks],[dateAndTime],[status],[SoakingProcess] " +
                    "FROM PeelingFinalData where Status='" + strStatus + "' and [barcodeId] not in (select barcodeidsofcrate from SoakingFinalData) AND dateAndTime > DATEADD(DAY, " + beforedays + ", GETDATE())";
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
                        p.soakingProcess = dt.Rows[i]["SoakingProcess"].ToString();
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
                if (lPeeling.Count == 0)
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Get Peeling Final Data Failed.." + ":::" + p;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Get Peeling Final Data Success !!";
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                var log_exc = DateTime.Now.ToString() + " ::: " + "Exception Catched in Get Peeling Final Data .." + ":::" + p + ex.ToString();
                log.writeLog(log_exc);
                lPeeling = null;
            }
            return lPeeling;
        }

        public async Task<List<PeelingRejection>> GetPeelingRejFinalData(string strStatus, string beforedays)
        {
            List<PeelingRejection> lPeeling = new List<PeelingRejection>();
            PeelingRejection p = null;
            DataTable dt = new DataTable();
            int count = 0;
            var log_txt = "";
            try
            {
                count = 0;
                dt = null;

                string strqry = "SELECT [barcodeId],[batchNo],[selectGrade],[initialProductType],[HLQtyRejForPeeling],[newProductType],[tableNo],[peelingDate],[peeledQty]," +
                                "[peelingYield],[qualityIssue] ,[remarks] ,[dateAndTime],[status]  FROM [PeelingRejectionFinalData] WHERE dateAndTime > DATEADD(DAY, " + beforedays + ", GETDATE())";
                dt = Oldb.GetDataTable(strqry);

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        p = new PeelingRejection();
                        p.barcodeId = dt.Rows[i]["barcodeId"].ToString();
                        p.batchNo = dt.Rows[i]["batchNo"].ToString();
                        p.selectGrade = dt.Rows[i]["selectGrade"].ToString();
                        p.initialProductType = dt.Rows[i]["initialProductType"].ToString();
                        p.hlQtyRejForPeeling = dt.Rows[i]["HLQtyRejForPeeling"].ToString();
                        p.newProductType = dt.Rows[i]["newProductType"].ToString();
                        p.tableNo = dt.Rows[i]["tableNo"].ToString();
                        p.peelingDate = dt.Rows[i]["peelingDate"].ToString();
                        p.peeledQty = dt.Rows[i]["peeledQty"].ToString();
                        p.peelingYield = dt.Rows[i]["peelingYield"].ToString();
                        p.qualityIssue = dt.Rows[i]["qualityIssue"].ToString();
                        p.remarks = dt.Rows[i]["remarks"].ToString();
                        p.dateAndTime = dt.Rows[i]["dateAndTime"].ToString();
                        p.status = dt.Rows[i]["status"].ToString();
                        lPeeling.Add(p);
                    }
                }
                if (lPeeling.Count == 0)
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Get Peeling Rejection Final Data Failed.." + ":::" + p;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Get Peeling Rejection Final Data Success !!";
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                var log_exc = DateTime.Now.ToString() + " ::: " + "Exception Catched in Get Peeling Rejection Final Data .." + ":::" + p + ex.ToString();
                log.writeLog(log_exc);
                lPeeling = null;
            }
            return lPeeling;
        }

        public async Task<List<PeelingGet>> GetPeeling(string beforedays)
        {
            List<PeelingGet> lPeeling = new List<PeelingGet>();
            PeelingGet p = null;
            DataTable dt = new DataTable();
            int count = 0;
            var log_txt = "";
            try
            {
                count = 0;

                //string strqry = "select distinct A.barcode,A.batchNo,A.ProductType,A.Grade,A.TargetFlatCount,A.Weighment,A.dateAndTime, "+
                //        "A.BSRatio,A.crate from GradingScanningProcess A  where A.barcode not in (select barcodeId from  PeelingFinalData where processstatus = 'filled')";
                string strqry = "SELECT DISTINCT barcode,batchNo,ProductType,Grade,TargetFlatCount,Weighment,SyncDate,BSRatio,crate " +
                    "FROM GradingScanningProcess  WHERE barcode not in (SELECT barcodeId FROM  PeelingFinalData WHERE processstatus = 'filled') AND SyncDate > DATEADD(DAY, " + beforedays + ", GETDATE())";

                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        p = new PeelingGet();
                        p.barcode = dt.Rows[i]["barcode"].ToString();
                        p.batchNo = dt.Rows[i]["batchNo"].ToString();
                        p.grade = dt.Rows[i]["grade"].ToString();
                        p.productType = dt.Rows[i]["productType"].ToString();
                        p.targetFlatCount = dt.Rows[i]["TargetFlatCount"].ToString();
                        p.weighment = dt.Rows[i]["Weighment"].ToString();
                        p.dateAndTime = dt.Rows[i]["SyncDate"].ToString();
                        p.bsRatio = dt.Rows[i]["BSRatio"].ToString();
                        p.crate = dt.Rows[i]["crate"].ToString();
                        //p.infeedHeadOnWeight = dt.Rows[i]["InfeedHeadOnWeight"].ToString();
                        //p.inFeedCount = dt.Rows[i]["InFeedCount"].ToString();
                        //p.overallBeHeadingYield = dt.Rows[i]["OverallBeHeadingYield"].ToString();
                        lPeeling.Add(p);
                    }
                }
                if (lPeeling.Count == 0)
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Get Peeling Data Failed.." + ":::" + p;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Get Peeling Data Success !!";
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                var log_exc = DateTime.Now.ToString() + " ::: " + "Exception Catched in Get Peeling Data.." + ":::" + p + ex.ToString();
                log.writeLog(log_exc);
                lPeeling = null;
            }
            return lPeeling;
        }
    }
}