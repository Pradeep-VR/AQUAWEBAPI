using AQUA;

namespace AQUAWEBAPI.Managements
{
    public class ExecutionManagement
    {
        Data _serve = new Data();
        public dynamic ExecuteQuerys(string strQuery)
        {
            if (strQuery != null)
            {
                var retData = _serve.GetDataTable(strQuery);
                if (retData != null)
                {
                    return retData;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}