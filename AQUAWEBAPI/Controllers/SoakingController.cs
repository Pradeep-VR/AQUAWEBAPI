// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.SoakingController
using System;
using System.Collections.Generic;
using System.Web.Http;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class SoakingController : ApiController
    {
        Logger log = new Logger();
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

        [Route("api/AquaSoakingFinalData")]
        [HttpPost]
        public string PostSoaking([FromBody] Dictionary<string, List<Soaking>> SoakingFinalData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                SoakingManagement APMgt = new SoakingManagement();
                if (SoakingFinalData != null)
                {
                    foreach (KeyValuePair<string, List<Soaking>> SoakingFinalDatum in SoakingFinalData)
                    {
                        List<Soaking> p = SoakingFinalDatum.Value;
                        b = APMgt.InsertSoakingFinalData(p);
                        s = ((!(b == "Success")) ? ("Failure" + SoakingFinalData.Count + b) : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s == "successfully")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Soaking Final Data is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Soaking Final Data is Failed.." + s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Soaking Final Data.." + s;
                log.writeLog(log_exc);
            }
            return s;
        }
    }
}