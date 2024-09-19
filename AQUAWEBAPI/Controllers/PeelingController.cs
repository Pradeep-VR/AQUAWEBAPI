// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.PeelingController
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class PeelingController : ApiController
    {
        Logger log = new Logger();
        PeelingManagement pMgt = new PeelingManagement();
        private string days = ConfigurationManager.AppSettings["beforedays"].ToString();
        public IEnumerable<string> Get()
        {
            return new string[2] { "value1", "value2" };
        }

        [Route("api/GetPeelingFinal")]
        public async Task<List<PeelingGet>> getPeeling()
        {
            return await pMgt.GetPeeling(days);

        }

        [Route("api/PeelingFinalPending")]
        public async Task<List<Peeling>> getPeelingPending()
        {

            return await pMgt.GetPeelingFinalData("Pending", days);
        }

        [Route("api/PeelingFinalFilled")]
        public async Task<List<Peeling>> getPeelingFilled()
        {

            return await pMgt.GetPeelingFinalData("Filled", days);

        }

        [Route("api/PeelingRejFinalPending")]
        public async Task<List<PeelingRejection>> getPeelingRejPending()
        {
            List<PeelingRejection> lPeeling = new List<PeelingRejection>();
            try
            {
                return await pMgt.GetPeelingRejFinalData("Pending", days);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [Route("api/PeelingRejFinalFilled")]
        public async Task<List<PeelingRejection>> getPeelingRejFilled()
        {

            return await pMgt.GetPeelingRejFinalData("Filled", days);

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

        [Route("api/AquaPeelingFinalData")]
        [HttpPost]
        public async Task<string> PostPeelingFinal([FromBody] Dictionary<string, List<Peeling>> PeelingFinalData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (PeelingFinalData != null)
                {
                    foreach (KeyValuePair<string, List<Peeling>> PeelingFinalDatum in PeelingFinalData)
                    {
                        List<Peeling> p = PeelingFinalDatum.Value;
                        b = await pMgt.InsertPeelingFinalData(p);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Peeling Final Data Success !!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Peeling Final Data Failed..." + ":::" + s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + " ::: " + "Exception Catched in Inserting Peeling Final Data ..." + ":::" + s;
                log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/AquaPeelingRejectionFinalData")]
        [HttpPost]
        public async Task<string> PostPeelingRejection([FromBody] Dictionary<string, List<PeelingRejection>> PeelingRejectionFinalData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (PeelingRejectionFinalData != null)
                {
                    foreach (KeyValuePair<string, List<PeelingRejection>> PeelingRejectionFinalDatum in PeelingRejectionFinalData)
                    {
                        List<PeelingRejection> p = PeelingRejectionFinalDatum.Value;
                        b = await pMgt.InsertPeelingRejectionFinalData(p);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Peeling Rejection Final Data Success !!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Peeling Rejection Final Data Failed..." + ":::" + s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + " ::: " + "Exception Catched in Inserting Rejection Peeling Final Data ..." + ":::" + s;
                log.writeLog(log_exc);
            }
            return s;
        }
    }
}