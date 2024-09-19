using AQUA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AQUAWEBAPI.Models
{
    public class GradingManagement
    {
        Logger log = new Logger();
        Data Oldb = new Data();

        public async Task<List<GradingNew>> GetGrading()
        {
            var logtxt = "";
            DataTable dt = new DataTable();
            int count = 0;
            DataTable dt1 = new DataTable();
            GradingNew g = new GradingNew();
            List<GradingNew> grade = new List<GradingNew>();

            try
            {
                //string strqry = "SELECT DISTINCT A.batchno,A.purchaseType,A.nextProcess FROM UnloadFinalProcess A JOIN BeheadingFinalData BH ON A.BatchWiseLotNo = BH.BatchLotNumber AND BH.Status = 'pending'";
                //       strqry += "JOIN UnloadBatchAllocation C ON A.BatchNo = C.BatchParent WHERE BH.ProcessStatus != 'closed'";
                //       strqry += "AND A.batchno NOT IN(SELECT DISTINCT batchNumber FROM GradingProcess WHERE status = 'filled') ORDER BY A.batchno";

                string strqry = "SELECT DISTINCT A.batchno, A.purchaseType, A.nextProcess FROM UnloadFinalProcess A JOIN BeheadingFinalData BH ON A.BatchWiseLotNo = BH.BatchLotNumber AND BH.Status = 'pending' ";
                    strqry += "LEFT JOIN GradingProcess GP ON A.batchno = GP.batchNumber AND GP.status = 'filled' WHERE BH.ProcessStatus != 'closed' AND GP.batchNumber IS NULL";

                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        g = new GradingNew();
                        if (dt.Rows[i]["purchaseType"].ToString() == "factory purchase")
                        {
                            string qry1 = "select sum(convert(float, TotalWeight)) as TotalWeight  from UnloadWashingWeighnment where batchNo = '" + dt.Rows[i]["batchno"].ToString() + "' ";
                            DataTable dt2 = new DataTable();
                            dt2 = Oldb.GetDataTable(qry1);

                            int count2 = dt2.Rows.Count;
                            if (count2 > 0)
                            {
                                g.inFeedHeadOnWeight = dt2.Rows[0]["TotalWeight"].ToString();
                            }

                        }
                        else if (dt.Rows[i]["purchaseType"].ToString() == "pond purchase")
                        {
                            if (dt.Rows[i]["nextprocess"].ToString() == "washing/beheading")
                            {
                                string qry2 = "select sum(convert(float, TotalWeight)) as TotalWeight from UnloadWashingWeighnment where batchNo = '" + dt.Rows[i]["batchno"].ToString() + "'";
                                DataTable dt3 = new DataTable();
                                dt3 = Oldb.GetDataTable(qry2);
                                int count3 = dt3.Rows.Count;
                                if (count3 > 0)
                                {
                                    g.inFeedHeadOnWeight = dt3.Rows[0]["TotalWeight"].ToString();
                                }

                            }
                            else if (dt.Rows[i]["nextprocess"].ToString() == "beheading")
                            {
                                string BatchWiseLotNo = "";
                                string qry3 = "select batchno,purchaseType,nextProcess ,BatchWiseLotNo from UnloadFinalProcess where batchNo='" + dt.Rows[i]["batchno"].ToString() + "'";
                                DataTable ddt = new DataTable();
                                ddt = Oldb.GetDataTable(qry3);
                                if (ddt.Rows.Count > 0)
                                {
                                    BatchWiseLotNo = ddt.Rows[0]["BatchWiseLotNo"].ToString();
                                }
                                string qry4 = "select TotalWeight from [Weighment] where LotNumber =  (select LotNumber from UnloadBatchAllocation where BatchNumber = '" + BatchWiseLotNo + "')";

                                DataTable dt4 = new DataTable();
                                dt4 = Oldb.GetDataTable(qry4);
                                int count4 = dt4.Rows.Count;
                                if (count4 > 0)
                                {
                                    g.inFeedHeadOnWeight = dt4.Rows[0]["TotalWeight"].ToString();
                                }

                            }

                        }
                        g.batchNumber = dt.Rows[i]["batchno"].ToString();
                        grade.Add(g);
                    }


                }
                else { }

                if (grade.Count == 0)
                {
                    logtxt = DateTime.Now.ToString() + ":::" + "Get Grading Data Empty or Failed";
                }
                else
                {
                    logtxt = DateTime.Now.ToString() + ":::" + "Get Grading Success";
                }
                log.writeLog(logtxt);
                return grade;
            }
            catch (Exception ex)
            {
                var log_txt_exc = DateTime.Now.ToString() + ":::" + "Exception in Get Grading" + ex.Message;
                log.writeLog(log_txt_exc);
                return grade;
            }
        }

        public async Task<string> InsertFinalGrading(List<Grading> Grade)
        {
            string s = "";
            string qry1 = "";
            string qry2 = "";
            DataTable dt = new DataTable();
            List<string> lstrQrys = new List<string>();
            try
            {
                if (Grade != null)
                {
                    foreach (Grading g in Grade)
                    {
                        qry1 = "Select * from GradingProcess where batchNumber='" + g.batchNumber + "'";
                        dt = Oldb.GetDataTable(qry1);
                        if (dt.Rows.Count == 0)
                        {
                            qry2 = " Insert into  GradingProcess(batchNumber, gradingDateTime, inFeedHeadOnWeight, inFeedCount, recMaterialTemp, gradingStartTime, gradingEndTime, overallBeheadingYield, remarks, ";
                            qry2 += "monitoredBy, ApprovedBy, dateAndTime,SyncDate,status) values('" + g.batchNumber + "', '" + g.gradingDateTime + "', ";
                            qry2 += " '" + g.inFeedHeadOnWeight + "' ,'" + g.inFeedCount + "', '" + g.recMaterialTemp + "', '" + g.gradingStartTime + "' , '" + g.gradingEndTime + "', ";
                            qry2 += " '" + g.overallBeheadingYield + "', '" + g.remarks + "', '" + g.monitoredBy + "','" + g.ApprovedBy + "', '" + g.dateAndTime + "',getdate(),'pending') ";
                            lstrQrys.Add(qry2);

                            string qry3 = "update BeheadingFinalData set status ='filled',ProcessStatus='Closed' where batchnumber ='" + g.batchNumber + "'";
                            lstrQrys.Add(qry3);

                        }
                    }

                    s = (lstrQrys.Count <= 0) ? "Please Contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQrys)) ? qry2 : "Success");
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString() + s;
            }
            return s;
        }


        public async Task<string> InsertFinalGradingScan(List<GradingScan> Gradsscns)
        {
            string s = "";
            string qry1;
            string Qry2 = "";
            string Qry1;
            DataTable dt = new DataTable();
            List<string> lstQrys = new List<string>();

            List<string> insidechk = new List<string>();
            try
            {
                if (Gradsscns != null)
                {
                    foreach (GradingScan g in Gradsscns)
                    {
                        qry1 = "select count(*) as dtvlu from GradingScanningProcess where barcode='" + g.barcode + "'";
                        dt = Oldb.GetDataTable(qry1);
                        int vlu = Convert.ToInt32(dt.Rows[0]["dtvlu"].ToString());
                        if (vlu == 0)
                        {
                            Qry2 = " Insert into GradingScanningProcess (barcode, batchNo, productType, grade,   targetFlatCount, weighment, dateAndTime, BSRatio, ";
                            Qry2 += " Crate,status, SyncDate) values('" + g.barcode + "', '" + g.batchNo + "', '" + g.productType + "', '" + g.grade + "','" + g.targetFlatCount + "' , ";
                            Qry2 += "  '" + g.weighment + "', '" + g.dateAndTime + "', '" + g.BSRatio + "', '" + g.Crate + "','" + g.status + "',getdate()) ";

                            

                            if (insidechk.Contains(g.barcode))//For Log Purpose
                            {
                                string Qry = " Insert into GradingScanningProcess (barcode, batchNo, productType, grade,   targetFlatCount, weighment, dateAndTime, BSRatio, ";
                                Qry += " Crate,status, SyncDate) values(''" + g.barcode + "'', ''" + g.batchNo + "'', ''" + g.productType + "'', ''" + g.grade + "'',''" + g.targetFlatCount + "'' , ";
                                Qry += "  ''" + g.weighment + "'', ''" + g.dateAndTime + "'', ''" + g.BSRatio + "'', ''" + g.Crate + "'',''" + g.status + "'',getdate()) ";

                                string Qryr = " update BeheadingFinalData set ProcessStatus=''Processing'' where batchNumber =''" + g.batchNo + "'' ";

                                string querrys = Qry.ToString() + ":::Q2:::" + Qryr.ToString() + "::";

                                var txtlog = querrys.ToString() + ":::" + "Duplicate Querrys"  ;
                                //log.writeLog_Grading(txtlog);
                                //s = "Duplicate data Loged Success";

                                string rt = "INSERT INTO [dbo].[StoreQueries] ([DateTime] ,[QueryText]) VALUES  (Getdate() ,'" + txtlog + "')";
                                Oldb.ExecuteNonQuery(rt);
                            }
                            else
                            {
                                lstQrys.Add(Qry2);
                                insidechk.Add(g.barcode);
                            }


                            Qry1 = " update BeheadingFinalData set ProcessStatus='Processing' where batchNumber ='" + g.batchNo + "' ";
                            lstQrys.Add(Qry1);

                        }
                        else//For Log Purpose
                        {
                            Qry2 = " Insert into GradingScanningProcess (barcode, batchNo, productType, grade,   targetFlatCount, weighment, dateAndTime, BSRatio, ";
                            Qry2 += " Crate,status, SyncDate) values(''" + g.barcode + "'', ''" + g.batchNo + "'', ''" + g.productType + "'', ''" + g.grade + "'',''" + g.targetFlatCount + "'' , ";
                            Qry2 += "  ''" + g.weighment + "'', ''" + g.dateAndTime + "'', ''" + g.BSRatio + "'', ''" + g.Crate + "'',''" + g.status + "'',getdate()) ";

                            Qry1 = " update BeheadingFinalData set ProcessStatus=''Processing'' where batchNumber =''" + g.batchNo + "'' ";


                            string querrys = Qry2.ToString() + ":::Q2:::" + Qry1.ToString() + "::";
                            var txtlog = querrys.ToString() + ":::" + "Duplicate Querrys";
                            //log.writeLog_Grading(txtlog);
                            string rt = "INSERT INTO [dbo].[StoreQueries] ([DateTime] ,[QueryText]) VALUES  (Getdate() ,N'" + txtlog + "')";
                            Oldb.ExecuteNonQuery(rt);


                        }
                    }
                    
                    s = (lstQrys.Count <= 0) ? "Please Contact Admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstQrys)) ? Qry2 : "Success");
                }
            }
            catch (Exception ex)
            {
                return ex.Message + s;
            }
            return s;
        }


    }
}