// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.ReglazingController
using System;
using System.Collections.Generic;
using System.Web.Http;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class ReglazingController : ApiController
    {
        Logger log = new Logger();
        ReglazingManagement pMgt = new ReglazingManagement();

        [Route("api/GetReglazing")]
        public List<Store> getPeeling()
        {
            List<Store> lstStore = new List<Store>();
            try
            {
                return pMgt.GetBeforeReglazingDetails();
            }
            catch (Exception ex)
            {
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched in GetBefore Reglazing Details" + ":::" + ex.ToString();
                log.writeLog(log_exc);
                return null;
            }
        }

        //public IEnumerable<string> Get()
        //{
        //    return new string[2] { "value1", "value2" };
        //}

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
    }
}