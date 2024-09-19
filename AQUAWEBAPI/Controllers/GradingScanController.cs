using System;
using System.Collections.Generic;
using System.Web.Http;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI.Controllers
{
    public class GradingScanController : ApiController
    {
        Logger log = new Logger();
        GradingScanManagement gMgt = new GradingScanManagement();
        public IEnumerable<string> Get()
        {
            return new string[2] { "value1", "value2" };
        }

        [Route("api/AquaGradingScanPost")]
        [HttpPost]        
        public string Post([FromBody] Dictionary<string,List<GradingScan>> GradingScanData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if(GradingScanData != null)
                {
                    foreach(KeyValuePair<string,List<GradingScan>> GradingScanDatum in  GradingScanData)
                    {
                        List<GradingScan> p = GradingScanDatum.Value;
                        foreach(GradingScan p2 in p)
                        {
                            b = gMgt.InsertGradingScanData(p2);
                            s = ((!(b == "Success")) ? "Failure" : "successfully");
                        }
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s == "successfully")
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting GradingScan Data Success !!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting GradingScan Data Failed..." + ":::" + s;
                }
                log.writeLog(log_txt);
            }
            catch(Exception ex)
            {
                s = ex.ToString();
                var log_txt_cap = DateTime.Now.ToString() + " ::: " + "Exception catched in GradingScan Data.." + ":::" + s;
                log.writeLog(log_txt_cap);
            }
            return s;
        }
    }
}
