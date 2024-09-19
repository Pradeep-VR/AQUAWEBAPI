// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.BeheadingController
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;
using AQUA;
using AQUAWEBAPI.Managements;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class BeheadingController : ApiController
    {
        Logger log = new Logger();

        [Route("api/GetBeheading")]
        public async Task<List<BeheadingGet>> GetBeHeading()
        {
            DataTable dt = new DataTable();
            dt = null;
            List<BeheadingGet> rtdata = new List<BeheadingGet>();
            var log_txt = "";
            List<BeheadingGet> lbhload = new List<BeheadingGet>();
            BeheadingManagement bhMgt = new BeheadingManagement();
            rtdata = await bhMgt.GetBeheadingDetails();
            if (rtdata.Count == 0)
            {
                log_txt = DateTime.Now.ToString() + ":::" + "Get Beheadding Details Faild...";
            }
            else
            {
                log_txt = DateTime.Now.ToString() + ":::" + "Get Beheadding Details Success !!!";
            }
            log.writeLog(log_txt);
            return rtdata;
        }


        [Route("api/AquaBeheadingTableAllocation")]
        [HttpPost]
        public async Task<string> Postallocation([FromBody] Dictionary<string, List<BeHeadingTableAllocation>> BeheadingTableAllocation)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                BeheadingManagement APMgt = new BeheadingManagement();
                if (BeheadingTableAllocation != null)
                {
                    foreach (KeyValuePair<string, List<BeHeadingTableAllocation>> item in BeheadingTableAllocation)
                    {
                        List<BeHeadingTableAllocation> p = item.Value;
                        b = await APMgt.InsertBaheadingTableAllocation(p);
                        s = ((!(b == "Success")) ? ("Failure" + BeheadingTableAllocation.Count + b) : " successfully");
                    }

                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Insert Beheadding Tabel Allocation Details Success.!!!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Insert Beheadding Tabel Allocation Details Failed.!!!" + ":::" + s;
                }
            }
            catch (Exception ex)
            {
                s = ex.ToString();
            }

            log.writeLog(log_txt);
            return s;
        }

        [Route("api/AquaBeheadingFinalData")]
        [HttpPost]
        public async Task<string> PostFinal([FromBody] Dictionary<string, List<Beheading>> BeheadingFinalData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                BeheadingManagement APMgt = new BeheadingManagement();
                if (BeheadingFinalData != null)
                {
                    foreach (KeyValuePair<string, List<Beheading>> BeheadingFinalDatum in BeheadingFinalData)
                    {
                        List<Beheading> p = BeheadingFinalDatum.Value;
                        b = await APMgt.InsertBeheadingFinalData(p);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }

                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Beheadding Final Data Success...";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Beheadding Final Data Failed !!!" + ":::" + s;
                }
            }
            catch (Exception ex)
            {
                s = ex.ToString() + b;
            }
            log.writeLog(log_txt);
            return s;
        }

        [Route("api/AquaBeheadingTablewise")]
        [HttpPost]
        public async Task<string> Posttable([FromBody] Dictionary<string, List<BeHeadingTableWise>> BeheadingTablewise)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                BeheadingManagement APMgt = new BeheadingManagement();
                if (BeheadingTablewise != null)
                {
                    foreach (KeyValuePair<string, List<BeHeadingTableWise>> item in BeheadingTablewise)
                    {
                        List<BeHeadingTableWise> p = item.Value;
                        b = await APMgt.InsertBeheadingTablewise(p);
                        s = ((!(b == "Success")) ? ("Failure" + BeheadingTablewise.Count + b) : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Insert Beheadding Tabelwise Details Success.!!!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Insert Beheadding Tabelwise Details Failed.!!!" + ":::" + s;
                }
            }
            catch (Exception ex)
            {
                s = ex.ToString();
            }
            log.writeLog(log_txt);
            return s;
        }


        /*  New Api's  */

        BeheadingManagement bhMgt = new BeheadingManagement();
        TransactionManagement _transMgnt = new TransactionManagement();

        [Route("api/GetBeheadingNew")]
        public async Task<ResponseApi> GetBeHeadingData()
        {
            var res = await bhMgt.GetBeheadingDetails();
            if (res != null)
            {
                return new ResponseApi() { ResponseCode = 200, Result = "Success", data = res };
            }
            return new ResponseApi() { ResponseCode = 204, Result = "Failed", data = res };
        }

        [Route("api/PostBeheadingTableAllocation")]
        [HttpPost]
        public async Task<ResponseApi> InsertAllocation([FromBody] List<BeHeadingTableAllocationNew> BeheadingTableAllocation)
        {
            //string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            var retList = new List<BeHeadingTableAllocationNew>();
            int succnt = 0;
            int erccnt = 0;
            try
            {
                if (BeheadingTableAllocation != null)
                {
                    var trsns = await _transMgnt.GetTransactionsById(BeheadingTableAllocation[0].TransId);
                    Transactions transs = trsns.data;
                    if (trsns.Result == "Success" && BeheadingTableAllocation[0].TransId.ToUpper() == transs.TransId.ToString().ToUpper())
                    {
                        string Qry = "UPDATE TRANSACTIONS SET RECEVING_CNT='" + BeheadingTableAllocation.Count + "' , RECEVING_DATETIME=GETDATE() WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                        var exec = new Data();
                        if (exec.ExecuteNonQuery(Qry))
                        {
                            foreach (var item in BeheadingTableAllocation)
                            {
                                b = await bhMgt.InsertBaheadingTableAllocationNew(item);
                                //s = ((!(b == "Success")) ? ("Failure" + BeheadingTableAllocation + b) : "Successfully");
                                if (b != "Success")
                                {
                                    retList.Add(item);
                                    erccnt++;
                                }
                                else
                                {
                                    succnt++;
                                }
                            }

                            Qry = "UPDATE TRANSACTIONS SET SUCCESS_CNT='" + succnt + "' , FAILURE_CNT='" + erccnt + "' WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                            if (exec.ExecuteNonQuery(Qry))
                            {
                                if (transs.SuccessCount != succnt && erccnt > 0)
                                {
                                    return new ResponseApi() { ResponseCode = 204, Result = "Success. Transaction Count Not Match.", data = retList };
                                }
                                else
                                {
                                    return new ResponseApi() { ResponseCode = 200, Result = "Success", data = "" };
                                }
                            }
                            else
                            {
                                return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = BeheadingTableAllocation[0].TransId };
                            }
                        }
                        else
                        {
                            return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = BeheadingTableAllocation[0].TransId };
                        }
                    }
                    else
                    {
                        return new ResponseApi() { ResponseCode = 204, Result = "Transaction Details Not Matched.", data = trsns };
                    }
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Batch Details Data is Null." + BeheadingTableAllocation;
                    await log.writeLog(log_txt);
                    return new ResponseApi() { ResponseCode = 204, Result = "Data is Null/Empty.", data = BeheadingTableAllocation };
                }

            }
            catch (Exception ex)
            {
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Batch Allocation.." + ex.Message;
                await log.writeLog(log_exc);
                return new ResponseApi() { ResponseCode = 400, Result = "Fail", data = ex.Message };
            }
        }

        [Route("api/PostBeheadingFinalData")]
        [HttpPost]
        public async Task<ResponseApi> BatchFinal([FromBody] List<BeheadingNew> BeheadingFinalData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            var retList = new List<BeheadingNew>();
            int succnt = 0;
            int erccnt = 0;
            try
            {
                if (BeheadingFinalData != null)
                {
                    var trsns = await _transMgnt.GetTransactionsById(BeheadingFinalData[0].TransId);
                    Transactions transs = trsns.data;
                    if (trsns.Result == "Success" && BeheadingFinalData[0].TransId.ToUpper() == transs.TransId.ToString().ToUpper())
                    {
                        string Qry = "UPDATE TRANSACTIONS SET RECEVING_CNT='" + BeheadingFinalData.Count + "' , RECEVING_DATETIME = GETDATE() WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                        var exec = new Data();
                        if (exec.ExecuteNonQuery(Qry))
                        {
                            foreach (var item in BeheadingFinalData)
                            {
                                b = await bhMgt.InsertBeheadingFinalDataNew(item);
                                if (b != "Success")
                                {
                                    retList.Add(item);
                                    erccnt++;
                                }
                                else
                                {
                                    succnt++;
                                }
                            }

                            Qry = "UPDATE TRANSACTIONS SET SUCCESS_CNT='" + succnt + "' , FAILURE_CNT='" + erccnt + "' WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                            if (exec.ExecuteNonQuery(Qry))
                            {
                                if (transs.SuccessCount != succnt && erccnt > 0)
                                {
                                    return new ResponseApi() { ResponseCode = 204, Result = "Success. Transaction Count Not Match.", data = retList };
                                }
                                else
                                {
                                    return new ResponseApi() { ResponseCode = 200, Result = "Success", data = "" };
                                }
                            }
                            else
                            {
                                return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = BeheadingFinalData[0].TransId };
                            }
                        }
                        else
                        {
                            return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = BeheadingFinalData[0].TransId };
                        }
                    }
                    else
                    {
                        return new ResponseApi() { ResponseCode = 204, Result = "Transaction Details Not Matched.", data = trsns };
                    }
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Beheading Details Data is Null." + BeheadingFinalData;
                    await log.writeLog(log_txt);
                    return new ResponseApi() { ResponseCode = 204, Result = "Data is Null/Empty.", data = BeheadingFinalData };
                }

            }
            catch (Exception ex)
            {
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Behearding Final.." + ex.Message;
                await log.writeLog(log_exc);
                return new ResponseApi() { ResponseCode = 400, Result = "Fail", data = ex.Message };
            }

        }

        [Route("api/PostBeheadingTablewise")]
        [HttpPost]
        public async Task<ResponseApi> InsertTable([FromBody] List<BeHeadingTableWiseNew> BeheadingTablewise)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            var retList = new List<BeHeadingTableWiseNew>();
            int succnt = 0;
            int erccnt = 0;
            try
            {
                if (BeheadingTablewise != null)
                {
                    var trsns = await _transMgnt.GetTransactionsById(BeheadingTablewise[0].TransId);
                    Transactions transs = trsns.data;
                    if (trsns.Result == "Success" && BeheadingTablewise[0].TransId.ToUpper() == transs.TransId.ToString().ToUpper())
                    {
                        string Qry = "UPDATE TRANSACTIONS SET RECEVING_CNT='" + BeheadingTablewise.Count + "' , RECEVING_DATETIME = GETDATE() WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                        var exec = new Data();
                        if (exec.ExecuteNonQuery(Qry))
                        {
                            foreach (var item in BeheadingTablewise)
                            {
                                b = await bhMgt.InsertBeheadingTablewiseNew(item);
                                if (b != "Success")
                                {
                                    retList.Add(item);
                                    erccnt++;
                                }
                                else
                                {
                                    succnt++;
                                }
                            }


                            Qry = "UPDATE TRANSACTIONS SET SUCCESS_CNT='" + succnt + "' , FAILURE_CNT='" + erccnt + "' WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                            if (exec.ExecuteNonQuery(Qry))
                            {
                                if (transs.SuccessCount != succnt && erccnt > 0)
                                {
                                    return new ResponseApi() { ResponseCode = 204, Result = "Success. Transaction Count Not Match.", data = retList };
                                }
                                else
                                {
                                    return new ResponseApi() { ResponseCode = 200, Result = "Success", data = "" };
                                }
                            }
                            else
                            {
                                return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = BeheadingTablewise[0].TransId };
                            }
                        }
                        else
                        {
                            return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = BeheadingTablewise[0].TransId };
                        }
                    }
                    else
                    {
                        return new ResponseApi() { ResponseCode = 204, Result = "Transaction Details Not Matched.", data = trsns };
                    }

                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Beheading TarbleWise Data is Null." + BeheadingTablewise;
                    await log.writeLog(log_txt);
                    return new ResponseApi() { ResponseCode = 204, Result = "Data is Null/Empty.", data = BeheadingTablewise };
                }

            }
            catch (Exception ex)
            {
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Beheading TarbleWise.." + ex.Message;
                await log.writeLog(log_exc);
                return new ResponseApi() { ResponseCode = 400, Result = "Fail", data = ex.Message };
            }

        }
    }
}