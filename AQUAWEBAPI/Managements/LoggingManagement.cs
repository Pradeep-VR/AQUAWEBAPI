using AQUA;
using AQUAWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AQUAWEBAPI.Managements
{
    public class LoggingManagement
    {
        Data _serve = new Data();
        public async Task<ApiResponse> LoggingQueries(List<QueriesLog> lstQrys)
        {
            ApiResponse res = new ApiResponse();
            if (lstQrys == null || lstQrys.Count == 0)
            {
                res = new ApiResponse()
                {
                    data = null,
                    Result = "Sended List was Null."
                };
            }
            else
            {
                Guid id = Guid.NewGuid();
                string strId = id.ToString();

                List<string> Qrys = new List<string>();                
                foreach (var query in lstQrys)
                {
                    string qry = "INSERT INTO QUERIES_LOG (ID,QUERIE,CREATEDBY,CREATEDATE) VALUES ('" + strId + "','" + query.Queries + "','" + query.CreatedBy + "',GETDATE())";
                    Qrys.Add(qry);
                }
                bool x = _serve.UpdateUsingExecuteNonQueryList(Qrys);
                res = x ? new ApiResponse() { Result = "Queries Executed Success.", data = strId } : new ApiResponse() { Result = "Execution Failed.", data = strId };
            }
            return res;
        }
    }
}