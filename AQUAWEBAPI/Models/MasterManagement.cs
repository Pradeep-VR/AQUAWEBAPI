// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.MasterManagement
using System;
using System.Collections.Generic;
using System.Data;
using AQUA;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class MasterManagement
    {
        Logger log = new Logger();
        Data Oldb = new Data();

        public List<PeelingYield> GetPeelingYield()
        {
            List<PeelingYield> lyield = new List<PeelingYield>();
            PeelingYield py;
            DataTable dt = new DataTable();
            try
            {
                string strQry = "select Grade,ProductType,TargetYield from PeelingTargetYiledMaster where Status=1";
                dt = Oldb.GetDataTable(strQry);
                int cnt = dt.Rows.Count;
                if(cnt > 0 )
                {
                    for(int i=0; i<cnt; i++)
                    {
                        py = new PeelingYield();
                        py.grade = dt.Rows[i]["Grade"].ToString();
                        py.productType = dt.Rows[i]["ProductType"].ToString();
                        py.yieldPercentage = dt.Rows[i]["TargetYield"].ToString();

                        lyield.Add(py);
                    }                    
                }
            }
            catch (Exception ex)
            {
                var log_txt_exc = DateTime.Now.ToString() + ":::" + "Exception in Get PeelingYield Master" + ex.Message;
                log.writeLog(log_txt_exc);
                lyield = null;
            }

            return lyield;
        }
        public Master GetMasterDetails()
        {
            List<Master> lMaster = new List<Master>();
            Master master = new Master();
            DataTable dt = new DataTable();
            int count = 0;
            SupplierMaster s = null;
            List<SupplierMaster> supplier = new List<SupplierMaster>();
            try
            {
                string strqry = " select SupplierName from [SupplierMaster]  where status='1'";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i2 = 0; i2 < count; i2++)
                    {
                        s = new SupplierMaster();
                        s.supplierName = dt.Rows[i2]["SupplierName"].ToString();
                        supplier.Add(s);
                    }
                    master.suppliers = supplier;
                }
                strqry = " select SupplierName from [SupplierMaster]  where status='1'";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i3 = 0; i3 < count; i3++)
                    {
                        s = new SupplierMaster();
                        s.supplierName = dt.Rows[i3]["SupplierName"].ToString();
                        supplier.Add(s);
                    }
                    master.suppliers = supplier;
                }
                count = 0;
                dt = null;
                strqry = "";
                VillageMaster v = null;
                List<VillageMaster> village = new List<VillageMaster>();
                strqry = "select ID, VillageName, MandalName from Village where Status='1'";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int n = 0; n < count; n++)
                    {
                        v = new VillageMaster();
                        v.ID = dt.Rows[n]["ID"].ToString();
                        v.villageName = dt.Rows[n]["VillageName"].ToString();
                        v.mandalName = dt.Rows[n]["MandalName"].ToString();
                        village.Add(v);
                    }
                    master.villages = village;
                }
                count = 0;
                dt = null;
                strqry = "";
                MandalMaster m2 = null;
                List<MandalMaster> mandal = new List<MandalMaster>();
                strqry = "select ID, MandalName, DistrictName from Mandal where Status='1'";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int m = 0; m < count; m++)
                    {
                        m2 = new MandalMaster();
                        m2.ID = dt.Rows[m]["ID"].ToString();
                        m2.mandalName = dt.Rows[m]["MandalName"].ToString();
                        m2.districtName = dt.Rows[m]["DistrictName"].ToString();
                        mandal.Add(m2);
                    }
                    master.mandals = mandal;
                }
                count = 0;
                dt = null;
                strqry = "";
                DistrictMaster d = null;
                List<DistrictMaster> district = new List<DistrictMaster>();
                strqry = "select ID, DistrictName from District where Status = '1'";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int l = 0; l < count; l++)
                    {
                        d = new DistrictMaster();
                        d.ID = dt.Rows[l]["ID"].ToString();
                        d.districtName = dt.Rows[l]["DistrictName"].ToString();
                        district.Add(d);
                    }
                    master.districts = district;
                }
                count = 0;
                dt = null;
                strqry = "";
                RackMaster rm = null;
                List<RackMaster> rMaster = new List<RackMaster>();
                strqry = "select StoreRoomNo,RackNumber,LocationName  from  [StoreRackMaster] where status =1";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int k = 0; k < count; k++)
                    {
                        rm = new RackMaster();
                        rm.storeNumber = dt.Rows[k]["StoreRoomNo"].ToString();
                        rm.rackNumber = dt.Rows[k]["RackNumber"].ToString();
                        rm.locationName = dt.Rows[k]["LocationName"].ToString();
                        rMaster.Add(rm);
                    }
                    master.rackMaster = rMaster;
                }
                count = 0;
                dt = null;
                strqry = "";
                Grade g = null;
                List<Grade> gMaster = new List<Grade>();
                strqry = "select GradeName, BarcodeType,CheckLength from [Grade] where flag = 1";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                    {
                        g = new Grade();
                        g.gradeName = dt.Rows[j]["GradeName"].ToString();
                        g.barcodeType = dt.Rows[j]["BarcodeType"].ToString();
                        g.checkLength = dt.Rows[j]["CheckLength"].ToString();
                        gMaster.Add(g);
                    }
                    master.gradeMaster = gMaster;
                }
                count = 0;
                dt = null;
                strqry = "";
                ProductType pt = null;
                List<ProductType> ptMaster = new List<ProductType>();
                strqry = "select ProductTypeID,ProductTypeName from  [ProductType] where flag = 1";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        pt = new ProductType();
                        pt.productTypeID = dt.Rows[i]["ProductTypeID"].ToString();
                        pt.productTypeName = dt.Rows[i]["ProductTypeName"].ToString();
                        ptMaster.Add(pt);
                    }
                    master.productTypeMaster = ptMaster;
                }

                count = 0;
                dt = null;
                strqry = "";
                FinancialYearModel fym = null;
                List<FinancialYearModel> fymMaster = new List<FinancialYearModel>();
                strqry = "SELECT DISTINCT CURRENTYEAR,NEXTYEAR,FINANCIALYEAR FROM FinancialYearMaster WHERE ACTIVESTATUS = 1";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        fym = new FinancialYearModel();
                        fym.CurrentYear = dt.Rows[i]["CURRENTYEAR"].ToString();
                        fym.NextYear = dt.Rows[i]["NEXTYEAR"].ToString();
                        fym.FinancialYear = dt.Rows[i]["FINANCIALYEAR"].ToString();
                        fymMaster.Add(fym);
                    }
                    master.FinancialYear = fymMaster;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return master = null;
            }
            return master;
        }

        public string newSupplierPost(string SupplierName,string CreatedBy)
        {
            List<string> lstrQry = new List<string>();
            string s = "";
            string qry = "";
            try
            {
                qry = "INSERT INTO SupplierMaster(SupplierName,CreatedBy,CreatedDate,status) VALUES ('"+ SupplierName.TrimEnd().ToString() +"', '"+ SupplierName.TrimEnd().ToString() +"', GETDATE(), 1)";
                lstrQry.Add(qry);

                s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "Adding New Supplier failed." : "New Supplier Added Successfully."));
                if (s == "New Supplier Added Successfully.")
                {
                    var log_txt = DateTime.Now + ":::" + s;
                    log.writeLog(log_txt);
                }
                else
                {
                    var log_txt = DateTime.Now + ":::" + s;
                    log.writeLog(log_txt);
                }
            }
            catch(Exception ex)
            {
                var log_txt = DateTime.Now + ":::" + ex.Message + s ;
                log.writeLog(log_txt);
                return ex.Message + s ;

            }
            return s;
        }
    }
}