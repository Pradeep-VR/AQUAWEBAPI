// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.FreezingController
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class FreezingController : ApiController
    {
        Logger log = new Logger();
        public IEnumerable<string> Get()
        {
            return new string[2] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return "value";
        }

        [Route("api/GetFreezing")]
        public List<FreezingGet> GetGradingNew()
        {
            DataTable dt = new DataTable();
            dt = null;
            List<FreezingGet> lfree = new List<FreezingGet>();
            FreezingManagement fMgt = new FreezingManagement();
            return fMgt.GetFreezing();
        }

        public void Post([FromBody] string value)
        {
        }

        public void Put(int id, [FromBody] string value)
        {
        }

        public void Delete(int id)
        {
        }

        [Route("api/AquaIQFFinalData")]
        [HttpPost]
        public string PostIQFFinal([FromBody] Dictionary<string, List<Freezing>> IQFFinalData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                FreezingManagement APMgt = new FreezingManagement();
                if (IQFFinalData != null)
                {
                    foreach (KeyValuePair<string, List<Freezing>> IQFFinalDatum in IQFFinalData)
                    {
                        List<Freezing> p = IQFFinalDatum.Value;
                        b = APMgt.InsertIQFFinalData(p);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s == "successfully")
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting IQF FinalData Success !!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting IQF FinalData Failed .." + ":::" + s; 
                }
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_txt_cap = DateTime.Now.ToString() + " ::: " + "Exception catched in Inserting IQF FinalData.." + ":::" + s;
                log.writeLog(log_txt_cap);
            }
            log.writeLog(log_txt);
            return s;
        }

        [Route("api/AquaBLOCKFinalData")]
        [HttpPost]
        public string PostBLOCKFinal([FromBody] Dictionary<string, List<FreezingBlock>> IQFBlockData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                FreezingManagement APMgt = new FreezingManagement();
                if (IQFBlockData != null)
                {
                    foreach (KeyValuePair<string, List<FreezingBlock>> IQFBlockDatum in IQFBlockData)
                    {
                        List<FreezingBlock> p = IQFBlockDatum.Value;
                        b = APMgt.InsertBlockFinalData(p);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s == "successfully")
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Block FinalData Success !!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Block FinalData Failed .." + ":::" + s;
                }

            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_txt_cap = DateTime.Now.ToString() + " ::: " + "Exception catched in Inserting Block FinalData.." + ":::" + s;
                log.writeLog(log_txt_cap);
            }
            log.writeLog(log_txt);
            return s;
        }

        [Route("api/AquaMixedBatchData")]
        [HttpPost]
        public string PostMixedBatchData([FromBody] Dictionary<string, List<Freezing>> MixedBatchData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                FreezingManagement APMgt = new FreezingManagement();
                if (MixedBatchData != null)
                {
                    foreach (KeyValuePair<string, List<Freezing>> MixedBatchDatum in MixedBatchData)
                    {
                        List<Freezing> p = MixedBatchDatum.Value;
                        b = APMgt.InsertMixedBatchData(p);
                        s = ((!(b == "Success")) ? ("Failure" + MixedBatchData.Count + b) : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;

                }
                if (s == "successfully")
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Mixed BatchData Success !!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Mixed BatchData Failed .." + ":::" + s;
                }
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_txt_cap = DateTime.Now.ToString() + " ::: " + "Exception catched in Inserting Mixed BatchData.." + ":::" + s;
                log.writeLog(log_txt_cap);
            }
            log.writeLog(log_txt);
            return s;
        }
    }
}