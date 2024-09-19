// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.RMWashingManagement
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AQUA;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{

    public class RMWashingManagement
    {
        Data Oldb = new Data();
        public string InsertRMWashing(RMWashing Pr)
        {
            //bool b = false;
            string s = "";
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("saudaNumber", Pr.saudaNumber));
                parameters.Add(new SqlParameter("purchaseType", Pr.purchaseType));
                parameters.Add(new SqlParameter("totalWeight", Pr.totalWeight));
                parameters.Add(new SqlParameter("totalCrates", Pr.totalCrates));
                parameters.Add(new SqlParameter("drainedTime", Pr.drainedTime));
                parameters.Add(new SqlParameter("dateTime", Pr.dateTime));
                s = ((!Oldb.ExecuteSP_new(parameters, "InsertRMWashing")) ? "Fail" : "Success");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }
    }
}