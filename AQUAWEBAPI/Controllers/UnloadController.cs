// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.UnloadController
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AQUA;
using AQUAWEBAPI.Managements;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class UnloadController : ApiController
    {
        Logger log = new Logger();
        UnloadManagement uMgt = new UnloadManagement();

        [Route("api/UnloadDataNew")]
        public async Task<UnloadMaster> GetUnloadDataNew()
        {
            return await uMgt.unloaddetailsNew();
        }

        [Route("api/InsertUnloadData")]
        [HttpPost]
        public async Task<string> Post([FromBody] Dictionary<string, List<Unloading>> UnloadDetails)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (UnloadDetails != null)
                {
                    foreach (KeyValuePair<string, List<Unloading>> UnloadDetail in UnloadDetails)
                    {
                        List<Unloading> u = UnloadDetail.Value;
                        b = await uMgt.InsertUnloadData(u);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Data is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Data is Failed.." + s;
                }
                await log.writeLog(log_txt);

            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload Data.." + s;
                await log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/InsertUnloadBatchAllocation")]
        [HttpPost]
        public async Task<string> PostInsertBatchAllocation([FromBody] Dictionary<string, List<UnloadBatchAllocation>> UnloadBatchAllocation)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (UnloadBatchAllocation != null)
                {
                    foreach (KeyValuePair<string, List<UnloadBatchAllocation>> item in UnloadBatchAllocation)
                    {
                        List<UnloadBatchAllocation> u = item.Value;
                        b = await uMgt.InsertBatchAllocation(u);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Batch Allocation is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Batch Allocation is Failed.." + s;
                }
                await log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Batch Allocation.." + s;
                await log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/UnloadWashingDrainTime")]
        [HttpPost]
        public async Task<string> PostUnloadDrainTime([FromBody] Dictionary<string, List<UnloadWashingDrainTime>> UnloadDrainTime)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (UnloadDrainTime != null)
                {
                    foreach (KeyValuePair<string, List<UnloadWashingDrainTime>> item in UnloadDrainTime)
                    {
                        List<UnloadWashingDrainTime> DTime = item.Value;
                        b = await uMgt.InsertUnloadWashingDrainTime(DTime);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Washing DrainTime is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Washing DrainTime is Failed.." + s;
                }
                await log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload Washing DrainTime .." + s;
                await log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/UnloadWashingWeightment")]
        [HttpPost]
        public async Task<string> PostUnloadWashingWeightment([FromBody] Dictionary<string, List<UnloadWashingWeightment>> UnloadWashWeightment)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {

                if (UnloadWashWeightment != null)
                {
                    foreach (KeyValuePair<string, List<UnloadWashingWeightment>> item in UnloadWashWeightment)
                    {
                        List<UnloadWashingWeightment> ww = item.Value;
                        b = uMgt.InsertUnloadWashingWeightment(ww);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload WashWeightment is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload WashWeightment is Failed.." + s;
                }
                await log.writeLog(log_txt);

            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload WashWeightment .." + s;
                await log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/UnloadNetSample")]
        [HttpPost]
        public async Task<string> PostUnloadNetSample([FromBody] Dictionary<string, List<UnloadRMNetSample>> UnloadNetSample)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (UnloadNetSample != null)
                {
                    foreach (KeyValuePair<string, List<UnloadRMNetSample>> item in UnloadNetSample)
                    {
                        List<UnloadRMNetSample> Net = item.Value;
                        b = await uMgt.InsertUnloadNetSampling(Net);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Net Sampling is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Net Sampling is Failed.." + s;
                }
                await log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload Net Sampling .." + s;
                await log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/UnloadRMQuality")]
        [HttpPost]
        public async Task<string> PostUnloadQuality([FromBody] Dictionary<string, List<UnloadRMQuality>> UnloadRMQuality)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (UnloadRMQuality != null)
                {
                    foreach (KeyValuePair<string, List<UnloadRMQuality>> item in UnloadRMQuality)
                    {
                        List<UnloadRMQuality> Qty = item.Value;
                        b = await uMgt.InsertUnloadRMQuality(Qty);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting UnloadRM Quality is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting UnloadRM Quality is Failed.." + s;
                }
                await log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In UnloadRM Quality .." + s;
                await log.writeLog(log_exc);
            }
            return s;
        }


        /*         New Api's          */

        TransactionManagement _transMgnt = new TransactionManagement();
        ExecutionManagement _execMgnt = new ExecutionManagement();

        [Route("api/GetUnloadData")]
        public async Task<ResponseApi> GetUnloadData()
        {
            var res = await uMgt.unloaddetailsNew();
            if (res != null)
            {
                return new ResponseApi() { ResponseCode = 200, Result = "Success", data = res };
            }
            return new ResponseApi() { ResponseCode = 204, Result = "Failed", data = res };
        }


        [Route("api/PostUnloadData")]
        [HttpPost]
        public async Task<ResponseApi> PostUnloadDetails([FromBody] List<UnloadingNew> UnloadDetails)
        {
            string b = "Loaded";
            var log_txt = "";
            var retList = new List<UnloadingNew>();
            int succnt = 0;
            int erccnt = 0;
            try
            {
                if (UnloadDetails != null)
                {
                    var trsns = await _transMgnt.GetTransactionsById(UnloadDetails[0].TransId);
                    Transactions transs = trsns.data;
                    if (trsns.Result == "Success" && UnloadDetails[0].TransId.ToUpper() == transs.TransId.ToString().ToUpper())
                    {
                        string Qry = "UPDATE TRANSACTIONS SET RECEVING_CNT='" + UnloadDetails.Count + "' , RECEVING_DATETIME=GETDATE() WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                        var exec = new Data();
                        if (exec.ExecuteNonQuery(Qry))
                        {
                            foreach (var item in UnloadDetails)
                            {
                                b = await uMgt.InsertUnloadDataNew(item);
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
                                return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadDetails[0].TransId };
                            }
                        }
                        else
                        {
                            return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadDetails[0].TransId };
                        }

                    }
                    else
                    {
                        return new ResponseApi() { ResponseCode = 204, Result = "Transaction Details Not Matched.", data = trsns };
                    }

                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Unload Details Data is Null." + UnloadDetails;
                    await log.writeLog(log_txt);
                    return new ResponseApi() { ResponseCode = 204, Result = "Data is Null/Empty.", data = UnloadDetails };
                }

            }
            catch (Exception ex)
            {
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload Data.." + ex.Message;
                await log.writeLog(log_exc);
                return new ResponseApi() { ResponseCode = 400, Result = "Fail", data = ex.Message };
            }
        }


        [Route("api/PostUnloadBatchAllocation")]
        [HttpPost]
        public async Task<ResponseApi> InsertBatchAllocation([FromBody] List<UnloadBatchAllocationNew> UnloadBatchAllocation)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            var retData = new List<UnloadBatchAllocationNew>();
            int succnt = 0;
            int erccnt = 0;
            try
            {
                if (UnloadBatchAllocation != null)
                {
                    var trsns = await _transMgnt.GetTransactionsById(UnloadBatchAllocation[0].TransId);
                    Transactions transs = trsns.data;
                    if (trsns.Result == "Success" && UnloadBatchAllocation[0].TransId.ToUpper() == transs.TransId.ToString().ToUpper())
                    {
                        string Qry = "UPDATE TRANSACTIONS SET RECEVING_CNT='" + UnloadBatchAllocation.Count + "' , RECEVING_DATETIME=GETDATE() WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                        var exec = new Data();
                        if (exec.ExecuteNonQuery(Qry))
                        {
                            foreach (UnloadBatchAllocationNew item in UnloadBatchAllocation)
                            {
                                b = await uMgt.InsertBatchAllocationNew2(item);

                                if (b != "Success")
                                {
                                    retData.Add(item);
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
                                    return new ResponseApi() { ResponseCode = 204, Result = "Success. Transaction Count Not Match.", data = retData };
                                }
                                else
                                {
                                    return new ResponseApi() { ResponseCode = 200, Result = "Success", data = "" };
                                }
                            }
                            else
                            {
                                return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadBatchAllocation[0].TransId };
                            }
                        }
                        else
                        {
                            return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadBatchAllocation[0].TransId };
                        }
                    }
                    else
                    {
                        return new ResponseApi() { ResponseCode = 204, Result = "Transaction Details Not Matched.", data = trsns };
                    }

                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Unload Details Data is Null." + UnloadBatchAllocation;
                    await log.writeLog(log_txt);
                    return new ResponseApi() { ResponseCode = 204, Result = "Data is Null/Empty.", data = UnloadBatchAllocation };
                }

            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Batch Allocation.." + s;
                     await log.writeLog(log_exc);
                return new ResponseApi() { data = s, ResponseCode = 400, Result = "Exception in Batch Allocation." };
            }
        }


        [Route("api/PostUnloadWashingDrainTime")]
        [HttpPost]
        public async Task<ResponseApi> InsertUnloadDrainTime([FromBody] List<UnloadWashingDrainTimeNew> UnloadDrainTime)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            var retData = new List<UnloadWashingDrainTimeNew>();
            int succnt = 0;
            int erccnt = 0;
            try
            {
                if (UnloadDrainTime != null)
                {
                    var trsns = await _transMgnt.GetTransactionsById(UnloadDrainTime[0].TransId);
                    Transactions transs = trsns.data;
                    if (trsns.Result == "Success" && UnloadDrainTime[0].TransId.ToUpper() == transs.TransId.ToString().ToUpper())
                    {
                        string Qry = "UPDATE TRANSACTIONS SET RECEVING_CNT='" + UnloadDrainTime.Count + "' , RECEVING_DATETIME=GETDATE() WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                        var exec = new Data();
                        if (exec.ExecuteNonQuery(Qry))
                        {

                            foreach (UnloadWashingDrainTimeNew item in UnloadDrainTime)
                            {
                                b = await uMgt.InsertUnloadWashingDrainTimeNew(item);
                                if (b != "Success")
                                {
                                    retData.Add(item);
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
                                    return new ResponseApi() { ResponseCode = 204, Result = "Success. Transaction Count Not Match.", data = retData };
                                }
                                else
                                {
                                    return new ResponseApi() { ResponseCode = 200, Result = "Success", data = "" };
                                }
                            }
                            else
                            {
                                return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadDrainTime[0].TransId };
                            }
                        }
                        else
                        {
                            return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadDrainTime[0].TransId };
                        }
                    }
                    else
                    {
                        return new ResponseApi() { ResponseCode = 204, Result = "Transaction Details Not Matched.", data = trsns };
                    }

                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Unload DrainTaim Data is Null." + UnloadDrainTime;
                    await log.writeLog(log_txt);
                    return new ResponseApi() { ResponseCode = 204, Result = "Data is Null/Empty.", data = UnloadDrainTime };
                }

            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload Washing DrainTime .." + s;
                await log.writeLog(log_exc);
                return new ResponseApi() { ResponseCode = 400, Result = "Exception in Unload Washing DrainTime.", data = ex.ToString() };

            }
        }


        [Route("api/PostUnloadWashingWeightment")]
        [HttpPost]
        public async Task<ResponseApi> InsertUnloadWashingWeightment([FromBody] List<UnloadWashingWeightmentNew> UnloadWashWeightment)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            var retData = new List<UnloadWashingWeightmentNew>();
            int succnt = 0;
            int erccnt = 0;
            try
            {

                if (UnloadWashWeightment != null)
                {
                    var trsns = await _transMgnt.GetTransactionsById(UnloadWashWeightment[0].TransId);
                    Transactions transs = trsns.data;
                    if (trsns.Result == "Success" && UnloadWashWeightment[0].TransId.ToUpper() == transs.TransId.ToString().ToUpper())
                    {
                        string Qry = "UPDATE TRANSACTIONS SET RECEVING_CNT='" + UnloadWashWeightment.Count + "' , RECEVING_DATETIME=GETDATE() WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                        var exec = new Data();
                        if (exec.ExecuteNonQuery(Qry))
                        {
                            foreach (UnloadWashingWeightmentNew item in UnloadWashWeightment)
                            {
                                b = uMgt.InsertUnloadWashingWeightmentNew(item);
                                if (b != "Success")
                                {
                                    retData.Add(item);
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
                                    return new ResponseApi() { ResponseCode = 204, Result = "Success. Transaction Count Not Match.", data = retData };
                                }
                                else
                                {
                                    return new ResponseApi() { ResponseCode = 200, Result = "Success", data = "" };
                                }
                            }
                            else
                            {
                                return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadWashWeightment[0].TransId };
                            }
                        }
                        else
                        {
                            return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadWashWeightment[0].TransId };
                        }
                    }
                    else
                    {
                        return new ResponseApi() { ResponseCode = 204, Result = "Transaction Details Not Matched.", data = trsns };
                    }

                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Unload DrainTaim Data is Null." + UnloadWashWeightment;
                    await log.writeLog(log_txt);
                    return new ResponseApi() { ResponseCode = 204, Result = "Data is Null/Empty.", data = UnloadWashWeightment };
                }
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload WashWeightment .." + s;
                await log.writeLog(log_exc);
                return new ResponseApi() { ResponseCode = 400, Result = "Exception in Unload WashWeightment.", data = ex.ToString() };
            }
        }


        [Route("api/PostUnloadNetSample")]
        [HttpPost]
        public async Task<ResponseApi> InsertUnloadNetSample([FromBody] List<UnloadRMNetSampleNew> UnloadNetSample)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            var retData = new List<UnloadRMNetSampleNew>();
            int succnt = 0;
            int erccnt = 0;
            try
            {
                if (UnloadNetSample != null)
                {
                    var trsns = await _transMgnt.GetTransactionsById(UnloadNetSample[0].TransId);
                    Transactions transs = trsns.data;
                    if (trsns.Result == "Success" && UnloadNetSample[0].TransId.ToUpper() == transs.TransId.ToString().ToUpper())
                    {
                        string Qry = "UPDATE TRANSACTIONS SET RECEVING_CNT='" + UnloadNetSample.Count + "' , RECEVING_DATETIME=GETDATE() WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                        var exec = new Data();
                        if (exec.ExecuteNonQuery(Qry))
                        {
                            foreach (UnloadRMNetSampleNew item in UnloadNetSample)
                            {
                                b = await uMgt.InsertUnloadNetSamplingNew(item);
                                if (b != "Success")
                                {
                                    retData.Add(item);
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
                                    return new ResponseApi() { ResponseCode = 204, Result = "Success. Transaction Count Not Match.", data = retData };
                                }
                                else
                                {
                                    return new ResponseApi() { ResponseCode = 200, Result = "Success", data = "" };
                                }
                            }
                            else
                            {
                                return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadNetSample[0].TransId };
                            }
                        }
                        else
                        {
                            return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadNetSample[0].TransId };
                        }
                    }
                    else
                    {
                        return new ResponseApi() { ResponseCode = 204, Result = "Transaction Details Not Matched.", data = trsns };
                    }
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Unload Net Sampling Data is Null." + UnloadNetSample;
                    await log.writeLog(log_txt);
                    return new ResponseApi() { ResponseCode = 204, Result = "Data is Null/Empty.", data = UnloadNetSample };
                }

            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload Net Sampling .." + s;
                await log.writeLog(log_exc);
                return new ResponseApi() { ResponseCode = 400, Result = "Exception in Unload Net Sampling.", data = ex.ToString() };
            }
        }


        [Route("api/PostUnloadRMQuality")]
        [HttpPost]
        public async Task<ResponseApi> InsertUnloadQuality([FromBody] List<UnloadRMQualityNew> UnloadRMQuality)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            var retData = new List<UnloadRMQualityNew>();
            int succnt = 0;
            int erccnt = 0;
            try
            {
                if (UnloadRMQuality != null)
                {
                    var trsns = await _transMgnt.GetTransactionsById(UnloadRMQuality[0].TransId);
                    Transactions transs = trsns.data;
                    if (trsns.Result == "Success" && UnloadRMQuality[0].TransId.ToUpper() == transs.TransId.ToString().ToUpper())
                    {
                        string Qry = "UPDATE TRANSACTIONS SET RECEVING_CNT='" + UnloadRMQuality.Count + "' , RECEVING_DATETIME=GETDATE() WHERE TRANS_ID='" + transs.TransId.ToString() + "'";
                        var exec = new Data();
                        if (exec.ExecuteNonQuery(Qry))
                        {
                            foreach (UnloadRMQualityNew item in UnloadRMQuality)
                            {
                                b = await uMgt.InsertUnloadRMQualityNew(item);
                                if (b != "Success")
                                {
                                    retData.Add(item);
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
                                    return new ResponseApi() { ResponseCode = 204, Result = "Success. Transaction Count Not Match.", data = retData };
                                }
                                else
                                {
                                    return new ResponseApi() { ResponseCode = 200, Result = "Success", data = "" };
                                }
                            }
                            else
                            {
                                return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadRMQuality[0].TransId };
                            }
                        }
                        else
                        {
                            return new ResponseApi() { ResponseCode = 204, Result = "Updating Transaction Details Failed.", data = UnloadRMQuality[0].TransId };
                        }
                    }
                    else
                    {
                        return new ResponseApi() { ResponseCode = 204, Result = "Transaction Details Not Matched.", data = trsns };
                    }

                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Unload Net Sampling Data is Null." + UnloadRMQuality;
                    await log.writeLog(log_txt);
                    return new ResponseApi() { ResponseCode = 204, Result = "Data is Null/Empty.", data = UnloadRMQuality };
                }

            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In UnloadRM Quality .." + s;
                await log.writeLog(log_exc);
                return new ResponseApi() { ResponseCode = 400, Result = "Exception in UnloadRM Quality.", data = ex.ToString() };
            }
        }
    }
}