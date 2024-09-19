using AQUA;
using System;
using System.Data;

namespace AQUAWEBAPI.Models
{
    public class GradingScanManagement
    {
        Data Oldb = new Data();
        Logger log = new Logger();
        public string InsertGradingScanData(GradingScan Gs)
        {
            string s = "";
            string qry;
            string qry1;
            try
            {
                qry1 = "select Count(*) as dtvlu from GradingScanningProcess where barcode='" + Gs.barcode + "'";
                DataTable dt = Oldb.GetDataTable(qry1);
                int vlu = Convert.ToInt32(dt.Rows[0]["dtvlu"].ToString());
                if (vlu == 0)
                {
                    qry = "Insert into GradingScanningProcess(barcode, batchNo, productType, grade, targetFlatCount, weighment, dateAndTime,BSRatio,Crate) ";
                    qry += "values('" + Gs.barcode + "','" + Gs.batchNo + "','" + Gs.productType + "','" + Gs.grade + "','" + Gs.targetFlatCount + "','" + Gs.weighment + "','" + Gs.dateAndTime + "','" + Gs.BSRatio + "','" + Gs.Crate + "')";

                    s = ((!Oldb.ExecuteNonQuery(qry1)) ? "Fail" : "Success");
                }
                else
                {
                    qry = "Insert into GradingScanningProcess(barcode, batchNo, productType, grade, targetFlatCount, weighment, dateAndTime,BSRatio,Crate) ";
                    qry += "values(''" + Gs.barcode + "'',''" + Gs.batchNo + "'',''" + Gs.productType + "'',''" + Gs.grade + "'',''" + Gs.targetFlatCount + "'',''" + Gs.weighment + "'',''" + Gs.dateAndTime + "'',''" + Gs.BSRatio + "'',''" + Gs.Crate + "'')";

                    var logtxt =  qry + ":::" + "Duplicate Data Insert in Partial Sync";
                    //log.writeLog_Grading(logtxt);
                    string rt = "INSERT INTO [dbo].[StoreQueries] ([DateTime] ,[QueryText]) VALUES  (Getdate() ,'" + logtxt + "')";
                    Oldb.ExecuteNonQuery(rt);
                }
                
            }
            catch(Exception ex)
            {
                var logtxt = DateTime.Now.ToString() + ":::" + ex.Message + ":::" + "Exception During Partial Sync";
                log.writeLog(logtxt);
                return ex.Message;
            }
            return s;
        }
    }
}