// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.GradingManagement
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AQUA;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{

    public class GradingManagement
    {
        public List<Grading> GetGradingDetails()
        {
            DataTable dt = new DataTable();
            int count = 0;
            Grading g = null;
            List<Grading> grade = new List<Grading>();
            try
            {
                string strqry = "SELECT[saudaNumber],[batchNo],[Crates],[reachedDateTime],[unloadDateTime],[sealNo],[receivedRmTemp], ";
                strqry += "[icCondition],[nextProcess],[farmerName] ,[supplierName] ,[purchaseDate],[purchaseType],[driverName] ";
                strqry += " ,[vehicleNo],[TotalWeight],[purchaseCount],[BatchWiseLotNo],[UnloadingStatus],[DrainTimeCalStatus] ";
                strqry += ",[WeighmentStatus],[QualityStatus],[NetSamplingStatus],[BeheadingStatus],[TableAllocationStatus] ";
                strqry += ",[TableWiseStatus] FROM [UnloadFinalProcess] where QualityStatus ='Filled' ";
                dt = Data.Instance.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        g = new Grading();
                        grade.Add(g);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return grade = null;
            }
            return grade;
        }

        public List<GradingNew> GetGrading()
        {
            DataTable dt = new DataTable();
            int count = 0;
            DataTable dt1 = new DataTable();
            int count1 = 0;
            GradingNew g = null;
            List<GradingNew> grade = new List<GradingNew>();
            try
            {
                string sql = "select * from BeheadingFinalData where ProcessStatus='Processing' ";

                dt1 = Data.Instance.GetDataTable(sql);
                count1 = dt.Rows.Count;
                if (count1 == 0)
                {
                    string strqry = " select  top(1) A.batchno,A.BatchWiseLotNo,A.saudaNumber,A.nextprocess,A.purchaseType,BH.dateandTime  ";
                    strqry += "  from [UnloadFinalProcess] A  join BeheadingFinalData BH on A.BatchWiseLotNo =BH.BatchLotNumber and BH.Status='pending' join[UnloadBatchAllocation] c  ";
                    strqry += " on A.BatchNo = C.BatchParent where BH.ProcessStatus='Open' order by BH.dateandTime desc ";
                    dt = Data.Instance.GetDataTable(strqry);
                    count = dt.Rows.Count;
                    if (count > 0)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            g = new GradingNew();
                            if (dt.Rows[i]["purchaseType"].ToString() == "factory purchase")
                            {
                                string s3 = "select sum(cast(TotalWeight as float)) as TotalWeight  from [dbo].[UnloadWashingWeighnment] where batchNo = '" + dt.Rows[i]["batchno"].ToString() + "' ";
                                DataTable dt4 = Data.Instance.GetDataTable(s3);
                                int count2 = dt4.Rows.Count;
                                if (count2 > 0)
                                {
                                    g.inFeedHeadOnWeight = dt4.Rows[0]["TotalWeight"].ToString();
                                }
                                g.batchNumber = dt.Rows[i]["batchno"].ToString();
                                g.batchLotNumber = dt.Rows[i]["BatchWiseLotNo"].ToString();
                            }
                            else if (dt.Rows[i]["purchaseType"].ToString() == "pond purchase")
                            {
                                if (dt.Rows[i]["nextprocess"].ToString() == "washing/beheading")
                                {
                                    string s2 = "select sum(cast(TotalWeight as float)) as TotalWeight from [dbo].[UnloadWashingWeighnment] where batchNo = '" + dt.Rows[i]["batchno"].ToString() + "' ";
                                    DataTable dt3 = Data.Instance.GetDataTable(s2);
                                    int count3 = dt3.Rows.Count;
                                    if (count3 > 0)
                                    {
                                        g.inFeedHeadOnWeight = dt3.Rows[0]["TotalWeight"].ToString();
                                    }
                                    g.batchNumber = dt.Rows[i]["batchno"].ToString();
                                    g.batchLotNumber = dt.Rows[i]["BatchWiseLotNo"].ToString();
                                }
                                else if (dt.Rows[i]["nextprocess"].ToString() == "beheading")
                                {
                                    string s = "select TotalWeight from[dbo].[Weighment] where LotNumber =  ";
                                    s += " (select LotNumber from UnloadBatchAllocation where  ";
                                    s = s + " BatchNumber = '" + dt.Rows[i]["BatchWiseLotNo"].ToString() + "') ";
                                    DataTable dt2 = Data.Instance.GetDataTable(s);
                                    int count4 = dt2.Rows.Count;
                                    if (count4 > 0)
                                    {
                                        g.inFeedHeadOnWeight = dt2.Rows[0]["TotalWeight"].ToString();
                                    }
                                    g.batchNumber = dt.Rows[i]["batchno"].ToString();
                                    g.batchLotNumber = dt.Rows[i]["BatchWiseLotNo"].ToString();
                                }
                            }
                            grade.Add(g);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return grade = null;
            }
            return grade;
        }

        public string InsertGradingDetails(Grading Pr)
        {
            bool b = false;
            string s = "";
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("batchNumber", Pr.batchNumber));
                parameters.Add(new SqlParameter("gradingDateTime", Pr.gradingDateTime));
                parameters.Add(new SqlParameter("inFeedHeadOnWeight", Pr.inFeedHeadOnWeight));
                parameters.Add(new SqlParameter("inFeedCount", Pr.inFeedCount));
                parameters.Add(new SqlParameter("recMaterialTemp", Pr.recMaterialTemp));
                parameters.Add(new SqlParameter("gradingStartTime", Pr.gradingStartTime));
                parameters.Add(new SqlParameter("gradingEndTime", Pr.gradingEndTime));
                parameters.Add(new SqlParameter("overallBeheadingYield", Pr.overallBeheadingYield));
                parameters.Add(new SqlParameter("remarks", Pr.remarks));
                parameters.Add(new SqlParameter("monitoredBy", Pr.monitoredBy));
                parameters.Add(new SqlParameter("ApprovedBy", Pr.ApprovedBy));
                parameters.Add(new SqlParameter("dateAndTime", Pr.dateAndTime));
                s = ((!Data.Instance.ExecuteSP_new(parameters, "InsertGradingDetails")) ? "Fail" : "Success");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public string InsertFinalGrading(List<Grading> Grade)
        {
            bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (Grade != null)
                {
                    foreach (Grading g in Grade)
                    {
                        strQry = "select * from GradingProcess where batchNumber='" + g.batchNumber + "'";
                        dt = Data.Instance.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = " Insert into dbo.GradingProcess(batchNumber, gradingDateTime, inFeedHeadOnWeight, inFeedCount, ";
                            strQry += " recMaterialTemp, gradingStartTime, gradingEndTime, overallBeheadingYield, remarks, ";
                            strQry = strQry + "monitoredBy, ApprovedBy, dateAndTime,SyncDate,status) values('" + g.batchNumber + "', '" + g.gradingDateTime + "', ";
                            strQry = strQry + " '" + g.inFeedHeadOnWeight + "' ,'" + g.inFeedCount + "', '" + g.recMaterialTemp + "', ";
                            strQry = strQry + " '" + g.gradingStartTime + "' , '" + g.gradingEndTime + "', ";
                            strQry = strQry + " '" + g.overallBeheadingYield + "', '" + g.remarks + "', '" + g.monitoredBy + "','" + g.ApprovedBy + "', '" + g.dateAndTime + "',getdate(),'pending') ";
                            lstrQry.Add(strQry);
                            string strQry2 = " ";
                            strQry2 = strQry2 + " update BeheadingFinalData set status ='filled',ProcessStatus='Closed' where batchnumber ='" + g.batchNumber + "' ";
                            lstrQry.Add(strQry2);
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Data.Instance.UpdateUsingExecuteNonQueryList(lstrQry)) ? strQry : "Success"));
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }

        public string InsertFinalGradingScan(List<GradingScan> Grade)
        {
            bool b = false;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (Grade != null)
                {
                    foreach (GradingScan g in Grade)
                    {
                        strQry = "select * from GradingScanningProcess where barcode='" + g.barcode + "'";
                        dt = Data.Instance.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = " Insert into dbo.GradingScanningProcess(barcode, batchNo, ";
                            strQry += " productType, grade,   targetFlatCount, weighment, dateAndTime, BSRatio, ";
                            strQry = strQry + " Crate,status, SyncDate) values('" + g.barcode + "', '" + g.batchNo + "', ";
                            strQry = strQry + "  '" + g.productType + "', '" + g.grade + "','" + g.targetFlatCount + "' , ";
                            strQry = strQry + "  '" + g.weighment + "', '" + g.dateAndTime + "', '" + g.BSRatio + "', ";
                            strQry = strQry + "  '" + g.Crate + "','" + g.status + "',getdate()) ";
                            lstrQry.Add(strQry);

                            string strQry2 = " ";
                            strQry2 = strQry2 + " update BeheadingFinalData set ProcessStatus='Processing' where batchNumber ='" + g.batchNo + "' ";
                            lstrQry.Add(strQry2);

                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Data.Instance.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
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