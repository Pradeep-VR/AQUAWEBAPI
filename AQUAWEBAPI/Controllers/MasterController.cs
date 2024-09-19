// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.MasterController
using System.Collections.Generic;
using System.Web.Http;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class MasterController : ApiController
    {
        MasterManagement mMgt = new MasterManagement();

        [Route("api/Master")]
        public Master getMasters()
        {
            Master i = new Master();

            return mMgt.GetMasterDetails();
        }

        [Route("api/newSupplierPost")]
        //public string PostNewSupplier([FromBody] string newSupplierName, string Createdby)
        public string PostNewSupplier(string newSupplierName, string Createdby)
        {
            return mMgt.newSupplierPost(newSupplierName, Createdby);

        }

        [Route("api/PeelingYieldMaster")]

        public List<PeelingYield> GetPeelingYieldMaster()
        {
            return mMgt.GetPeelingYield();
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
    }
}