using AQUAWEBAPI.Managements;
using AQUAWEBAPI.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace AQUAWEBAPI
{
    public class TransactionController : ApiController
    {
        TransactionManagement _mgnt = new TransactionManagement();

        [Route("api/GetTransaction")]
        [HttpGet]
        public async Task<ApiResponse> GetTransactions()
        {
            var data = await _mgnt.GetTransactions();
            if (data == null)
            {
                return new ApiResponse() { data = data, Result = "Exception While Executions." };
            }
            else
            {
                if (data.Count == 0)
                {
                    return new ApiResponse() { data = data, Result = "Data Not Found In Transaction Table." };
                }
                else
                {
                    return new ApiResponse() { data = data, Result = "Getting Transaction Data Success." };
                }
            }

        }

        [Route("api/Trans")]
        [HttpGet]
        public async Task<ApiResponse> test()
        {
            Guid id = Guid.NewGuid();
            string strId = id.ToString();
            return  new ApiResponse() { data = strId, Result = "Success." };
        }


        [Route("api/PostTransaction")]
        [HttpPost]
        public async Task<ApiResponse> PostTransactions(Transactions lstTrans)
        {
            if (lstTrans == null)
            {
                return new ApiResponse() { data = null, Result = "Warning : Sended Data is Null." };
            }
            else
            {                
                var dta = await _mgnt.PostTransaction(lstTrans);
                var res = dta.Split('~');
                if (res[0].ToString() == "Error")
                {
                    return new ApiResponse() { data = res[0], Result = res[1] };
                }
                return new ApiResponse() { data = res[0], Result = res[1] };
            }
        }
    }
}
