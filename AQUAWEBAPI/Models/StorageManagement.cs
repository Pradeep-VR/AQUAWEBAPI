using System;
using System.Collections.Generic;
using System.Data;
using AQUA;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class StorageManagement 
    {
        Logger log = new Logger();
        Data Oldb = new Data();

        public string InsertStorageINData(List<StorageIN> storage)
        {
            //bool b = false;
            var log_txt = "";
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (storage != null)
                {
                    foreach (StorageIN sIN in storage)
                    {
                        strQry = "select * from StorageIN where BarcodeCarton='" + sIN.barcodeCarton + "'";
                        dt = Oldb.GetDataTable(strQry);
                        if (dt.Rows.Count == 0)
                        {
                            strQry = "INSERT INTO  StorageIN ([PalletId],[BarcodeCarton],[StorageLocation],[StoreRoomNo],[MaterialTemp], ";
                            strQry += " [PlantOrOutSide],[Status] ,[DateAndTime],[RackNumber],[LocationNo],[MonitoredBy],[VerifiedBy] ";
                            strQry += "  ,[Remarks] ,[MaterialStatus] ,[PalletInsertedDteAndTime] ,[CreatedBy] ,[CreatedDate],[Flag] ) VALUES  ";
                            strQry = strQry + "  ('" + sIN.palletId + "' , '" + sIN.barcodeCarton + "' ,'" + sIN.storageLocation + "' , ";
                            strQry = strQry + " '" + sIN.storeRoomNo + "' , '" + sIN.materialTemp + "' ,'" + sIN.plantOrOutside + "' ,  ";
                            strQry = strQry + " '" + sIN.fgStatus + "' , '" + sIN.dateAndTime + "' ,'" + sIN.rackNo + "' , ";
                            strQry = strQry + " '" + sIN.locationNo + "' , '" + sIN.monitoredBy + "' ,'" + sIN.verifiedBy + "' , ";
                            strQry = strQry + " '" + sIN.remarks + "' , '" + sIN.matInStatus + "' ,'" + sIN.palletInsertedDteAndTime + "' , '1022',getdate(),1) ";
                            lstrQry.Add(strQry);
                        }
                    }
                    s = ((lstrQry.Count <= 0) ? "Please contact admin" : ((!Oldb.UpdateUsingExecuteNonQueryList(lstrQry)) ? "fail" : "Success"));
                }

                if (s == "Success")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Data success in StorageInData";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Post Data Failed in StorageInData" + s + ":::" + strQry;
                }
                log.writeLog(log_txt);

            }
            catch (Exception ex)
            {
                var txt_log = DateTime.Now.ToString() + ex.Message + ":::" + s + ":::" + strQry;
                log.writeLog(txt_log);
                return ex.Message + ":::" + s + ":::" + strQry;
            }
            return s;
        }

        public List<StorageIN> GetStorageINDetails()
        {
            var log_txt = "";
            DataTable dt = new DataTable();
            int count = 0;
            List<StorageIN> storageList = new List<StorageIN>();
            StorageIN store = null;
            try
            {
                dt = new DataTable();
                string strqry = " SELECT PalletId, BarcodeCarton, StorageLocation, StoreRoomNo, MaterialTemp,  ";
                strqry += "  PlantOrOutSide, Status, DateAndTime, RackNumber, LocationNo, ";
                strqry += " MonitoredBy,VerifiedBy,Remarks,MaterialStatus,PalletInsertedDteAndTime  FROM StorageIN where flag = 1  ";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        store = new StorageIN();
                        store.palletId = dt.Rows[i]["PalletId"].ToString();
                        store.barcodeCarton = dt.Rows[i]["BarcodeCarton"].ToString();
                        store.storageLocation = dt.Rows[i]["StorageLocation"].ToString();
                        store.storeRoomNo = dt.Rows[i]["StoreRoomNo"].ToString();
                        store.materialTemp = dt.Rows[i]["MaterialTemp"].ToString();
                        store.plantOrOutside = dt.Rows[i]["PlantOrOutSide"].ToString();
                        store.fgStatus = dt.Rows[i]["Status"].ToString();
                        store.dateAndTime = dt.Rows[i]["DateAndTime"].ToString();
                        store.rackNo = dt.Rows[i]["RackNumber"].ToString();
                        store.locationNo = dt.Rows[i]["LocationNo"].ToString();
                        store.monitoredBy = dt.Rows[i]["MonitoredBy"].ToString();
                        store.verifiedBy = dt.Rows[i]["VerifiedBy"].ToString();
                        store.remarks = dt.Rows[i]["Remarks"].ToString();
                        store.matInStatus = dt.Rows[i]["MaterialStatus"].ToString();
                        store.palletInsertedDteAndTime = dt.Rows[i]["PalletInsertedDteAndTime"].ToString();
                        storageList.Add(store);
                    }
                }
                if (storageList.Count == 0)
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Get StorageIN Details is Failed.." + store;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Get StorageIN Details is Success..";
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched in StorageIN Details .." + ex.ToString();
                log.writeLog(log_exc);
                return storageList = null;
            }
            return storageList;
        }

        public List<Storage> GetStorageDetails()
        {
            DataTable dt = new DataTable();
            int count = 0;
            List<Storage> storageList = new List<Storage>();
            Storage store = null;
            var log_txt = "";
            try
            {
                dt = new DataTable();
                string strqry = " Select SoakingBarcode, SlabPacking, PONumber, Grade, Variety, StorageType, PalletId , ";
                strqry += " ProductionCode, ExportCode, NoOfSlabCotton, LooseCotton, BatchNumber, ";
                strqry += "  PackBarcode, PackingStyle, Brand , GlazeSpec , Actpackingstyle  from  IQFBarcodePrinting where status = '1' and LabelStatus = 'Scanned' ";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        store = new Storage();
                        store.soakingBarcode = dt.Rows[i]["SoakingBarcode"].ToString();
                        store.slabPacking = dt.Rows[i]["SlabPacking"].ToString();
                        store.poNumber = dt.Rows[i]["PONumber"].ToString();
                        store.grade = dt.Rows[i]["Grade"].ToString();
                        store.variety = dt.Rows[i]["Variety"].ToString();
                        store.storageType = dt.Rows[i]["StorageType"].ToString();
                        store.productionCode = dt.Rows[i]["ProductionCode"].ToString();
                        store.exportCode = dt.Rows[i]["ExportCode"].ToString();
                        store.noOfSlabCotton = dt.Rows[i]["NoOfSlabCotton"].ToString();
                        store.looseCotton = dt.Rows[i]["LooseCotton"].ToString();
                        store.batchNumber = dt.Rows[i]["BatchNumber"].ToString();
                        store.packBarcode = dt.Rows[i]["PackBarcode"].ToString();
                        store.palletId = dt.Rows[i]["PalletId"].ToString();
                        store.packingStyle = dt.Rows[i]["PackingStyle"].ToString();
                        store.brand = dt.Rows[i]["Brand"].ToString();
                        store.glazeSpec = dt.Rows[i]["GlazeSpec"].ToString();
                        store.actPackingStyle = dt.Rows[i]["Actpackingstyle"].ToString();
                        storageList.Add(store);
                    }
                }
                if (storageList.Count == 0)
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Get Storage Details is Failed.." + store;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Get Storage Details is Success..";
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched in Storage Details .." + ex.ToString();
                log.writeLog(log_exc);
                return storageList = null;
            }
            return storageList;
        }

        public List<StorageOut> GetStorageOutDetails()
        {
            DataTable dt = new DataTable();
            int count = 0;
            List<StorageOut> storageList = new List<StorageOut>();
            StorageOut store = null;
            var log_txt = "";
            try
            {
                dt = new DataTable();
                string strqry = "  select Distinct B.PackBarcode, B.SoakingBarcode, B.SlabPacking, B.Ponumber, B.Grade, B.Variety, ";
                strqry += "   B.storageType, B.NoofslabCotton,B.ProductionCode,B.ExportCode, B.LooseCotton, B.BatchNumber, ";
                strqry += "   B.PackingStyle, B.Brand,B.GlazeSpec,B.Actpackingstyle, A.PalletId, A.StorageLocation, A.StoreRoomNo, ";
                strqry += "  A.RackNumber, A.LocationNo, A.PlantorOutSide,C.CargoNumber from IQFBarcodePrinting B ";
                strqry += "  join StorageIN A on B.PackBarcode = A.BarcodeCarton  ";
                strqry += " left join PackingSpecification C on B.Ponumber = C.Ponumber ";
                strqry += "  where B.LabelStatus = 'Scanned' and A.Flag=1  and C.DeleteStatus = 0 ";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        store = new StorageOut();
                        store.soakingBarcode = dt.Rows[i]["SoakingBarcode"].ToString();
                        store.slabPacking = dt.Rows[i]["SlabPacking"].ToString();
                        store.poNumber = dt.Rows[i]["PONumber"].ToString();
                        store.grade = dt.Rows[i]["Grade"].ToString();
                        store.variety = dt.Rows[i]["Variety"].ToString();
                        store.storageType = dt.Rows[i]["StorageType"].ToString();
                        store.productionCode = dt.Rows[i]["ProductionCode"].ToString();
                        store.exportCode = dt.Rows[i]["ExportCode"].ToString();
                        store.noOfSlabCotton = dt.Rows[i]["NoOfSlabCotton"].ToString();
                        store.looseCotton = dt.Rows[i]["LooseCotton"].ToString();
                        store.batchNumber = dt.Rows[i]["BatchNumber"].ToString();
                        store.packBarcode = dt.Rows[i]["PackBarcode"].ToString();
                        store.packingStyle = dt.Rows[i]["PackingStyle"].ToString();
                        store.brand = dt.Rows[i]["Brand"].ToString();
                        store.glazeSpec = dt.Rows[i]["GlazeSpec"].ToString();
                        store.actPackingStyle = dt.Rows[i]["Actpackingstyle"].ToString();
                        store.palletId = dt.Rows[i]["PalletId"].ToString();
                        store.storageLocation = dt.Rows[i]["StorageLocation"].ToString();
                        store.storeRoomNo = dt.Rows[i]["StoreRoomNo"].ToString();
                        store.rackNumber = dt.Rows[i]["RackNumber"].ToString();
                        store.locationNo = dt.Rows[i]["LocationNo"].ToString();
                        store.plantorOutSide = dt.Rows[i]["PlantorOutSide"].ToString();
                        store.cargoNo = dt.Rows[i]["CargoNumber"].ToString();
                        storageList.Add(store);
                    }
                }
                if (storageList.Count == 0)
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Get StorageOut Details is Failed.." + store;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Get StorageOut Details is Success..";
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return storageList = null;
            }
            return storageList;
        }


        public string InsertStorageOutData(List<Store> storage)
        {
            bool b = true;
            //bool b2 = true;
            //bool b3 = true;
            //bool b4 = true;
            string s = "";
            string strQry = "";
            DataTable dt = new DataTable();
            List<string> lstrQry = new List<string>();
            try
            {
                if (storage != null)
                {
                    foreach (Store SO2 in storage)
                    {
                        strQry = "select * from StorageOut where Barcode='" + SO2.barcode + "'  ";
                        dt = Oldb.GetDataTable(strQry);

                        if (!(SO2.materialIssuedFor != "") || SO2.materialIssuedFor != "" || dt.Rows.Count != 0)
                        {
                            strQry = " INSERT INTO [StorageOut] ([Barcode] ,[MaterialOutType] ,[StoreRoomNO],[PalletID],[RackNO]";
                            strQry += "  ,[LocNO],[PoNO],[CargoNumber],[MatTemp],[ContainerNO],[TrailerOrVehNO] ,[SealNO]";
                            strQry += " ,[MoniteredBy],[ApprovedBy],[Remarks] ,[DateAndTime],[Status],[CreatedDate],[UpdatedBy]";
                            strQry += "  ,[UpdatedDate],SyncDate,fgOutDateAndTime,materialOutStatus, ";
                            strQry += " fgOutOrMatOutDateAndTime,finalDateAndTime,plantName,outSideColdStorageName,packingStyle,  ";
                            strQry += " cartonType,noOfCartons, storageType,materialIssuedFor,rePackingType,rePackingNewId,";
                            strQry += " changeInFinalGrade,changeInFinalProductType,changeInFinalGlazePercentage,materialSendingTo ";
                            strQry += "  )  VALUES  ('" + SO2.barcode + "','" + SO2.materialOutType + "','" + SO2.storeRoomNo + "', ";
                            strQry += " '" + SO2.palletId + "' ,'" + SO2.rackNo + "','" + SO2.locNO + "','" + SO2.poNo + "','" + SO2.cargoNo + "' , ";
                            strQry += " '" + SO2.matTemp + "' ,'" + SO2.containerNo + "','" + SO2.trailerOrVehNo + "','" + SO2.sealNo + "','" + SO2.monitoredBy + "' , ";
                            strQry += " '" + SO2.approvedBy + "' ,'" + SO2.remarks + "','" + SO2.dateAndTime + "','Filled',getdate(),'1',getdate(),getdate() ,'" + SO2.fgOutDateAndTime + "','" + SO2.materialOutStatus + "',    ";
                            strQry += " '" + SO2.fgOutOrMatOutDateAndTime + "','" + SO2.finalDateAndTime + "','" + SO2.plantName + "','" + SO2.outSideColdStorageName + "',    ";
                            strQry += " '" + SO2.packingStyle + "', '" + SO2.cartonType + "','" + SO2.noOfCartons + "', ";
                            strQry += "  '" + SO2.storageType + "','" + SO2.materialIssuedFor + "','" + SO2.rePackingType + "','" + SO2.rgRpRpaNewId + "', ";
                            strQry += " '" + SO2.changeInFinalGrade + "','" + SO2.changeInFinalProductType + "','" + SO2.changeInFinalGlazePercentage + "','" + SO2.materialSendingTo + "' )  ";


                            lstrQry.Add(strQry);
                        }

                        if (SO2.materialIssuedFor.ToUpper() == "RE-PACKING" || SO2.materialIssuedFor.ToUpper() == "RE-PROCESSING")
                        {
                            string ss2 = "select Grade,Variety,noofSlabCotton,PONumber,StorageType,PackBarcode,PackingStyle,Brand,FreezingType,noofSlabCotton from  [IQFBarcodePrinting] where packBarcode='" + SO2.barcode + "' ";
                            DataTable dtChk2 = new DataTable();
                            dtChk2 = Oldb.GetDataTable(ss2);
                            if (dtChk2.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtChk2.Rows.Count; j++)
                                {
                                    string strQry2 = " Insert into IQFFinalData(barcodeId, freezingType, machineNo, operation, batch, grade, productType, ";
                                    strQry2 += " count, quantity, antibioticStatus, checkOfBsRatio, checkOfFlatCount, ";
                                    strQry2 += " changeInGrade, balQtyFromBfToIqf,balQtyFromCookingToIqf, rejection, freezTemp, ";
                                    strQry2 += " cookingTemp, cookingTime, packingAgainstCoNo, ";
                                    strQry2 += "  packingStyle, noOfSlabsToBePacked, dc, broken, g2, big, small, ";
                                    strQry2 += " remarks, monitoredBy, verifiedBy, dateAndTime,status,SyncDate) ";
                                    strQry2 += "  Values('" + SO2.rgRpRpaNewId + "', 'IQF', '" + SO2.materialSendingTo + "', '" + SO2.materialIssuedFor + "', ";
                                    strQry2 += " '" + SO2.rgRpRpaNewId + "', '" + dtChk2.Rows[j]["Grade"].ToString() + "', '" + dtChk2.Rows[j]["Variety"].ToString() + "', '0', '0', ";
                                    strQry2 += "  'PASS', '0', '0', ";
                                    strQry2 += " '" + SO2.changeInFinalGrade + "',  ";
                                    strQry2 += "  '0', '0', '0', '0', ";
                                    strQry2 += " '0','0', '" + SO2.poNo + "', ";
                                    strQry2 += " '" + SO2.packingStyle + "', '0','0', '0', '0', '0', ";
                                    strQry2 += " '0', '" + SO2.remarks + "', '" + SO2.monitoredBy + "','" + SO2.approvedBy + "', '" + SO2.dateAndTime + "','Pending',getdate()) ";


                                    lstrQry.Add(strQry2);
                                }
                            }
                        }

                        if (SO2.materialIssuedFor.ToUpper() == "RE-GLAZING") //|| SO2.materialIssuedFor.ToUpper() == "RE-PACKING")
                        {
                            string ss = "select Grade,Variety,noofSlabCotton from  [IQFBarcodePrinting] where packBarcode='" + SO2.barcode + "' ";
                            DataTable dtChk = new DataTable();
                            dtChk = Oldb.GetDataTable(ss);
                            if (dtChk.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtChk.Rows.Count; i++)
                                {
                                    string strQry3 = "";
                                    strQry3 = "  Insert into SoakingFinalData(date, batchNo, soakingType, barcodeIdsOfCrate, ";
                                    strQry3 += " preSoakingWeight, changeInGrade, changeInProduct, soakingTankBarcodeId, ";
                                    strQry3 += " soakingTankSerialNo, soakingStartTime,soakingEndTime, soakingTime, ";
                                    strQry3 += " totalMaterialWtInTank, soakOutWt, changeInGrade2,quantityGoneForDiffGrade, ";
                                    strQry3 += "  flatCountCheck, bsRatio, remarks, chemicalStatus, dateAndTime,masterBarcodeId,SyncDate,status) Values ";
                                    strQry3 += "  (getdate(),'" + SO2.rgRpRpaNewId + "','Separate Crate Wise','" + SO2.rgRpRpaNewId + "', ";
                                    strQry3 += "  '0', '" + dtChk.Rows[i]["Grade"].ToString() + "', ";
                                    strQry3 += "  '" + dtChk.Rows[i]["Variety"].ToString() + "', '" + SO2.rgRpRpaNewId + "', '" + SO2.rgRpRpaNewId + "' , ";
                                    strQry3 += "  getdate(), getdate() , ";
                                    strQry3 += " getdate() , '0','0', ";
                                    strQry3 += " '" + dtChk.Rows[i]["Grade"].ToString() + "', ' ' , ";
                                    strQry3 += "  '0' , '0',' ', ' ', ";
                                    strQry3 += " ' " + SO2.dateAndTime + "','" + SO2.rgRpRpaNewId + "',getdate(),'pending') ";


                                    lstrQry.Add(strQry3);
                                }
                            }
                        }
                        /* //Commented By Pradeep.
                          if (SO2.materialIssuedFor.ToUpper() == "RE-PROCESSING")
                        {
                            string strReProcess = "select Grade,Variety,noofSlabCotton from  [IQFBarcodePrinting] where packBarcode='" + SO2.barcode + "' ";
                            DataTable dtReprocess = new DataTable();
                            dtReprocess = Oldb.GetDataTable(strReProcess);
                            if (dtReprocess.Rows.Count > 0)
                            {
                                for (int reprocess = 0; reprocess < dtReprocess.Rows.Count; reprocess++)
                                {
                                    strQry = " Insert into  GradingProcess(batchNumber, gradingDateTime, inFeedHeadOnWeight, inFeedCount, ";
                                    strQry += " recMaterialTemp, gradingStartTime, gradingEndTime, overallBeheadingYield, remarks, ";
                                    strQry += "monitoredBy, ApprovedBy, dateAndTime,SyncDate,status) values('" + SO2.rgRpRpaNewId + "', getdate(), ";
                                    strQry += " '0' ,'0', '0', getdate() , getdate(),";
                                    strQry += " '0', '" + SO2.remarks + "', '" + SO2.monitoredBy + "','" + SO2.approvedBy + "', '" + SO2.dateAndTime + "',getdate(),'pending') ";

                                    log.writeLog_Storage(SO2.materialIssuedFor + ":::" + strQry);

                                    lstrQry.Add(strQry);
                                }
                            }
                        }*/

                    }
                    if (lstrQry.Count > 0)
                    {
                        b = Oldb.UpdateUsingExecuteNonQueryList(lstrQry);
                        if (b)
                        {
                            bool x  = false;
                            foreach (Store SO in storage)
                            {
                                strQry = "";
                                strQry = "Update storageIN set flag=0 where BarcodeCarton='" + SO.barcode + "' ";
                                x = Oldb.ExecuteNonQuery(strQry);
                            }
                            s = ((!x) ? strQry : "Success");
                        }
                        else
                        {
                            s = "fail";
                        }
                    }
                }
                else
                {
                    s = "No Data Found!. Please check.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + strQry;
            }
            return s;
        }


    }
}