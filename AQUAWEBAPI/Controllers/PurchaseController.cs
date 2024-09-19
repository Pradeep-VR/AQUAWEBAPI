// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.PurchaseController
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class PurchaseController : ApiController
    {
        Logger log = new Logger();
        PurchaseManagement PMgt = new PurchaseManagement();

        public IEnumerable<string> Get()
        {
            return new string[2] { "value1", "value2" };
        }

        //public string Get(int id)
        //{
        //    return "value";
        //}

        [Route("api/Purchase")]
        public async Task<string> Post([FromBody] Dictionary<string, List<Purchase>> PurchaseDetails)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                
                if (PurchaseDetails != null)
                {
                    foreach (KeyValuePair<string, List<Purchase>> PurchaseDetail in PurchaseDetails)
                    {
                        List<Purchase> p = PurchaseDetail.Value;
                        b = await PMgt.InsertAQUAPurchaseDetailsNew(p);
                        s = ((!(b == "Success")) ? b : "successfully");
                        
                    }
                }
                else
                {
                    s = "Error" + b;
                }

                if (s.ToUpper() == "SUCCESSFULLY")
                {
                     log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Purchase Details,Success..";                    
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Purchase Details,Failed.." + s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString() + b;
                var log_txt_exc = DateTime.Now.ToString() + ":::" + "Exception catched During Inserting Purchase Details.. " + s;
                log.writeLog(log_txt_exc);
            }            
            return s;
        }

        //public void Put(int id, [FromBody] string value)
        //{
        //}
        
        //public void Delete(int id)
        //{
        //}
    }
}