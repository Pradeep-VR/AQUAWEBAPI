using AQUAWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AQUAWEBAPI.Controllers
{
    public class GradingController : ApiController
    {
        Logger log = new Logger();
        GradingManagement gMgt = new GradingManagement();

        [Route("api/GetGradingDetails")]
        public async Task<List<GradingNew>> GetGradingCtrl()
        {
            return await gMgt.GetGrading();
        }

        [Route("api/AquaGradingPost")]
        [HttpPost]
        public async Task<string> Post([FromBody] Dictionary<string, List<Grading>> GradingDetails)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var txt_log = "";
            try
            {
                if(GradingDetails != null)
                {
                    foreach(KeyValuePair<string , List<Grading>> GradingDtls in GradingDetails)
                    {
                        List<Grading> p = GradingDtls.Value;
                        b = await gMgt.InsertFinalGrading(p);
                        s = (!(b == "Success") ? b : "successfully");
                    }
                }
                else
                {
                    s = "Error " + b;
                }


                if(b == "successfully")
                {
                    txt_log = DateTime.Now.ToString() + ":::" + "Post Final Data is Success.";
                }
                else
                {
                    txt_log = DateTime.Now.ToString() + ":::" + "Post Final Data is Failed." + ":::" + s + ":::" + b;
                }
                log.writeLog(txt_log);

            }
            catch (Exception ex)
            {
                s = s + ex.Message;
                var logytxt = DateTime.Now.ToString() + ":::" + "Exception in Post Final Grading Data" + s;
                log.writeLog(logytxt);  
            }
            return s;
        }

        [Route("api/InsertGradingScan")]
        [HttpPost]
        public async Task<string> PostGradingScan([FromBody] Dictionary<string,List<GradingScan>> GradingScanDetails)
        {
            string s = "";
            string b = "";
            var log_txt = "";
            try
            {
                if(GradingScanDetails != null)
                {
                    foreach(KeyValuePair<string,List<GradingScan>> GradingScanDtls in GradingScanDetails)
                    {
                        List<GradingScan> p = GradingScanDtls.Value;
                        b = await gMgt.InsertFinalGradingScan(p);
                        s = (!(b == "Success") ? b : "successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if(b == "successfully")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Grading Scan data is Success";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Grading Scan data is Failed" + b +":::"+ s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = s + ex.Message;
                var loggtxt = DateTime.Now.ToString() + ":::" + "Exception in Post Gradingscan " + s + ":::" + b;
                log.writeLog(loggtxt);
            }
            return s;
        }
    }
}
