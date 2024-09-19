// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.ReglazingManagement
using System;
using System.Collections.Generic;
using System.Data;
using AQUA;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class ReglazingManagement
    {
        Logger log = new Logger();
        Data Oldb = new Data();
        public List<Store> GetBeforeReglazingDetails()
        {
            DataTable dt = new DataTable();
            int count = 0;
            List<Store> storageList = new List<Store>();
            Store store = null;
            var log_txt = "";
            try
            {
                dt = new DataTable();
                string strqry = " SELECT[Barcode],[MaterialOutType],[StoreRoomNO],[PalletID],[RackNO],[LocNO],[PoNO] ";
                strqry += " ,[CargoNumber],[MatTemp],[ContainerNO],[TrailerOrVehNO], ";
                strqry += " [plantName],[outSideColdStorageName] ";
                strqry += " ,[packingStyle],[cartonType],[noOfCartons],[storageType],[materialIssuedFor],[rePackingType], ";
                strqry += " [rePackingNewId],changeInFinalGrade,changeInFinalProductType,changeInFinalGlazePercentage,materialSendingTo ";
                strqry += "  FROM [StorageOut] where materialIssuedFor ='RE-PACKING' ";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        store = new Store();
                        store.barcode = dt.Rows[i]["Barcode"].ToString();
                        store.materialOutType = dt.Rows[i]["MaterialOutType"].ToString();
                        store.storeRoomNo = dt.Rows[i]["StoreRoomNO"].ToString();
                        store.palletId = dt.Rows[i]["PalletID"].ToString();
                        store.rackNo = dt.Rows[i]["RackNO"].ToString();
                        store.locNO = dt.Rows[i]["LocNO"].ToString();
                        store.poNo = dt.Rows[i]["PoNO"].ToString();
                        store.cargoNo = dt.Rows[i]["CargoNumber"].ToString();
                        store.matTemp = dt.Rows[i]["MatTemp"].ToString();
                        store.containerNo = dt.Rows[i]["ContainerNO"].ToString();
                        store.trailerOrVehNo = dt.Rows[i]["TrailerOrVehNO"].ToString();
                        store.plantName = dt.Rows[i]["plantName"].ToString();
                        store.cartonType = dt.Rows[i]["cartonType"].ToString();
                        store.noOfCartons = dt.Rows[i]["noOfCartons"].ToString();
                        store.storageType = dt.Rows[i]["storageType"].ToString();
                        store.materialIssuedFor = dt.Rows[i]["materialIssuedFor"].ToString();
                        store.rePackingType = dt.Rows[i]["rePackingType"].ToString();
                        store.rgRpRpaNewId = dt.Rows[i]["rePackingNewId"].ToString();
                        store.changeInFinalGrade = dt.Rows[i]["changeInFinalGrade"].ToString();
                        store.changeInFinalProductType = dt.Rows[i]["changeInFinalProductType"].ToString();
                        store.changeInFinalGlazePercentage = dt.Rows[i]["changeInFinalGlazePercentage"].ToString();
                        store.materialSendingTo = dt.Rows[i]["materialSendingTo"].ToString();
                        storageList.Add(store);
                    }
                }
                if(storageList.Count == 0)
                {
                     log_txt = DateTime.Now.ToString() + ":::" + "GetBefore Reglazing Details is Failed.." + store ;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "GetBefore Reglazing Details is Success.." ;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched in GetBefore Reglazing Details.." + ex.ToString();
                log.writeLog(log_exc);
                return storageList = null;
            }
            return storageList;
        }
    }
}