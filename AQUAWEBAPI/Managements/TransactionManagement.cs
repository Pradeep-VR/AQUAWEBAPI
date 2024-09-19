using AQUA;
using AQUAWEBAPI.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AQUAWEBAPI.Managements
{
    public class TransactionManagement
    {
        Logger log = new Logger();
        Data _serv = new Data();

        public async Task<List<Transactions>> GetTransactions()
        {
            List<Transactions> lstTrans = new List<Transactions>();
            try
            {
                string Query = "SELECT * FROM TRANSACTIONS";
                var dt = _serv.GetDataTable(Query);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var trans = new Transactions()
                        {
                            TransId = dt.Rows[i]["TRANS_ID"].ToString(),
                            Modules = dt.Rows[i]["MODULES"].ToString(),
                            SendingCount = Convert.ToInt32(dt.Rows[i]["SENDING_CNT"]),
                            SendingBy = dt.Rows[i]["SENDING_BY"].ToString(),
                            SendingTime = Convert.ToDateTime(dt.Rows[i]["SENDING_DATETIME"].ToString()),
                            RecevingCount = Convert.ToInt32(dt.Rows[i]["RECEVING_CNT"]),
                            RecevingTime = Convert.ToDateTime(dt.Rows[i]["RECEVING_DATETIME"].ToString()),
                            SuccessCount = Convert.ToInt32(dt.Rows[i]["SUCCESS_CNT"]),
                            FailureCount = Convert.ToInt32(dt.Rows[i]["FAILURE_CNT"]),
                        };
                        lstTrans.Add(trans);
                    }
                    return lstTrans;
                }
                else
                {
                    return new List<Transactions>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<ResponseApi> GetTransactionsById(string strTransId)
        {
            try
            {
                if (strTransId.IsNullOrWhiteSpace())
                {
                    return new ResponseApi() { ResponseCode = 204, Result = "Transaction Id Is Null/Empty", data = null };
                }
                string Query = "SELECT * FROM TRANSACTIONS WHERE TRANS_ID = '" + strTransId + "'";
                var dt = _serv.GetDataTable(Query);
                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    var trans = new Transactions()
                    {
                        TransId = dt.Rows[i]["TRANS_ID"].ToString(),
                        Modules = dt.Rows[i]["MODULES"].ToString(),
                        SendingCount = Convert.ToInt32(dt.Rows[i]["SENDING_CNT"]),
                        SendingBy = dt.Rows[i]["SENDING_BY"].ToString(),
                        SendingTime = Convert.ToDateTime(dt.Rows[i]["SENDING_DATETIME"].ToString()),
                        RecevingCount = Convert.ToInt32(dt.Rows[i]["RECEVING_CNT"]),
                        RecevingTime = Convert.ToDateTime(dt.Rows[i]["RECEVING_DATETIME"].ToString()),
                        SuccessCount = Convert.ToInt32(dt.Rows[i]["SUCCESS_CNT"]),
                        FailureCount = Convert.ToInt32(dt.Rows[i]["FAILURE_CNT"]),
                    };


                    return new ResponseApi() { ResponseCode = 200, Result = "Success", data = trans };
                }
                else
                {
                    return new ResponseApi() { ResponseCode = 204, Result = "Data Not Found", data = null };
                }

            }
            catch (Exception ex)
            {
                return new ResponseApi() { ResponseCode = 400, Result = "Exception", data = ex.Message };
            }
        }

        public async Task<string> PostTransaction(Transactions trans)
        {
            string response = string.Empty;
            try
            {

                string Qry = "INSERT INTO TRANSACTIONS (MODULES,SENDING_CNT,SENDING_BY,SENDING_DATETIME) VALUES " +
                    "('" + trans.Modules + "','" + trans.SendingCount + "','" + trans.SendingBy + "',GETDATE())";
                bool x = _serv.ExecuteNonQuery(Qry);
                if (x)
                {
                    string qry = "SELECT TOP 1 * FROM TRANSACTIONS ORDER BY SENDING_DATETIME DESC";
                    var dts = _serv.GetDataTable(qry);
                    if (dts != null)
                    {
                        response = "TransactionId :" + dts.Rows[0]["TRANS_ID"].ToString();
                    }
                }
                return response + "~ Success.";
            }
            catch (Exception ex)
            {
                response = "Exception :" + ex.Message;
                return response;
            }
        }

    }
}