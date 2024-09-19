// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.RMWashingController
using System;
using System.Collections.Generic;
using System.Web.Http;
using AQUAWEBAPI.Models;


namespace AQUAWEBAPI
{
    public class RMWashingController : ApiController
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

        [Route("api/AquaRMWashingPost")]
        [HttpPost]
        public string Post([FromBody] Dictionary<string, List<RMWashing>> RMWashingData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                RMWashingManagement APMgt = new RMWashingManagement();
                if (RMWashingData != null)
                {
                    foreach (KeyValuePair<string, List<RMWashing>> RMWashingDatum in RMWashingData)
                    {
                        List<RMWashing> p = RMWashingDatum.Value;
                        foreach (RMWashing p2 in p)
                        {
                            b = APMgt.InsertRMWashing(p2);
                            s = ((!(b == "Success")) ? ("Failure" + RMWashingData.Count + b) : " successfully");
                        }
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s == "successfully")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting RM Washing Data is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting RM Washing Data is Failed.." + s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In RM Washing.." + s;
                log.writeLog(log_exc);
            }
            return s;
        }
    }
}