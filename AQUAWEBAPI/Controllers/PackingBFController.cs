// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.PackingBFController
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{

    public class PackingBFController : ApiController
    {
        Logger log = new Logger();
        PackingBFManagement packMgt = new PackingBFManagement();

        [Route("api/PackingBF")]
        public async Task<List<PackingBF>> GetPackingBF()
        {
            DataTable dt = new DataTable();
            dt = null;
            List<PackingBF> LPck = new List<PackingBF>();
            return await packMgt.GetPackingBFDetails();
        }


        [Route("api/PackingFinal")]
        [HttpPost]
        public async Task<ApiResponse> PostPackingFinalNew([FromBody] List<PackingScanning> PackingFinalData)
        {
            string s = "Fail";
            var log_txt = "";
            var Result = new ApiResponse();
            try
            {

                if (PackingFinalData != null)
                {
                    var res = await packMgt.InserPackingscanningNew(PackingFinalData);
                    Result = new ApiResponse()
                    {
                        Result = res.Result,
                        data = res.data
                    };
                    s = res.Result;
                }
                else
                {
                    s = "Error :" + PackingFinalData;
                }

                if (s == "Success")
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Packing Scan Data Success !!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Packing Scan Data Failed..." + ":::" + s;
                }

                await log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                Result = new ApiResponse()
                {
                    Result = ex.Message,
                };
                var log_exc = DateTime.Now.ToString() + " ::: " + "Exception Catched in Packing Scan Data..." + ":::" + s;
                await log.writeLog(log_exc);
            }
            return Result;
        }



        [Route("api/AquaPackingData")]
        [HttpPost]

        public async Task<string> PostPackingFinal([FromBody] Dictionary<string, List<PackingScanning>> PackingFinalData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {

                if (PackingFinalData != null)
                {
                    foreach (KeyValuePair<string, List<PackingScanning>> PackingFinalDatum in PackingFinalData)
                    {
                        List<PackingScanning> p = PackingFinalDatum.Value;
                        //b = await packMgt.InsertPackingScanData(p);
                        b = await packMgt.InserPackingscanning(p);
                        s = (!(b == "Success")) ? b : "successfully";

                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s == "successfully")
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Packing Scan Data Failed..." + ":::" + s;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Packing Scan Data Success !!";
                }
                await log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + " ::: " + "Exception Catched in Packing Scan Data..." + ":::" + s;
                await log.writeLog(log_exc);
            }
            return s;
        }

        //public void Post([FromBody] string value)
        //{
        //}

        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //public void Delete(int id)
        //{
        //}
    }
}