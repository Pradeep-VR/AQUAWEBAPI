// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.RMNetSampleController
using System;
using System.Collections.Generic;
using System.Web.Http;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class RMNetSampleController : ApiController
    {
        Logger log = new Logger();
        RMNetSampleManagement APMgt = new RMNetSampleManagement();
        public IEnumerable<string> Get()
        {
            return new string[2] { "value1", "value2" };
        }

        //public string Get(int id)
        //{
        //    return "value";
        //}

        //public void Post([FromBody] string value)
        //{
        //}

        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //public void Delete(int id)
        //{
        //}

        [Route("api/AquaRMNetSamplingPost")]
        [HttpPost]
        public string Post([FromBody] Dictionary<string, List<UnloadRMNetSample>> RMNetSampleData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (RMNetSampleData != null)
                {
                    foreach (KeyValuePair<string, List<UnloadRMNetSample>> RMNetSampleDatum in RMNetSampleData)
                    {
                        List<UnloadRMNetSample> p = RMNetSampleDatum.Value;
                        foreach (UnloadRMNetSample p2 in p)
                        {
                            b = APMgt.InsertRMNetSampling(p2);
                            s = ((!(b == "Success")) ? ("Failure" + RMNetSampleData.Count + b) : " successfully");
                        }
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if(s == "successfully")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting RM NetSampling Data is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting RM NetSampling Data is Failed.." + s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In RM NetSampling.." + s;
                log.writeLog(log_exc);
            }
            return s;
        }
    }
}