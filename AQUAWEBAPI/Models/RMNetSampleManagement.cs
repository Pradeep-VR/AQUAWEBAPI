// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.RMNetSampleManagement
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AQUA;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class RMNetSampleManagement
    {
        Data Oldb = new Data();
        public string InsertRMNetSampling(UnloadRMNetSample Pr)
        {
            //bool b = false;
            string s = "";
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("saudaNumber", Pr.saudaNumber));
                parameters.Add(new SqlParameter("sampleWeight", Pr.sampleWeight));
                parameters.Add(new SqlParameter("noOfnormalpieces", Pr.noOfnormalpieces));
                parameters.Add(new SqlParameter("noOfSmallPieces", Pr.noOfSmallPieces));
                parameters.Add(new SqlParameter("noOfSmallPiecesAccAsOne", Pr.noOfSmallPiecesAccAsOne));
                parameters.Add(new SqlParameter("totalNoOfpieces", Pr.totalNoOfpieces));
                parameters.Add(new SqlParameter("plantCount", Pr.plantCount));
                parameters.Add(new SqlParameter("weightDifference", Pr.weightDifference));
                parameters.Add(new SqlParameter("countDifference", Pr.countDifference));
                parameters.Add(new SqlParameter("dateTime", Pr.dateTime));
                s = ((!Oldb.ExecuteSP_new(parameters, "InsertRMNetSampling")) ? "Fail" : "Success");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }
    }
}