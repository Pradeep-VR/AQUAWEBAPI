// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.PackingBFManagement
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using AQUA;
using AQUAWEBAPI.Models;
using Microsoft.Ajax.Utilities;
namespace AQUAWEBAPI
{
    public class PackingBFManagement
    {
        Logger log = new Logger();
        Data Oldb = new Data();
        public DataTable GetPONumberDetails(string strPONumber, string strGrade, string strVariety, string strPackingStyle, string strBrand, string strPackType)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = " select PONumber,Noofslabs,Matchedfromopen, BalanceSlabs, BalanceCartons, BalanceQty,PackingStyle, Brand ,cartonPacked,CartonRepack,CartonBalRepack,OrderQty from  [PackingSpecification]  where PackingStatus = 'OPEN'  and PONumber ='" + strPONumber + "' and Grade='" + strGrade + "' and variety ='" + strVariety + "' and PackingStyle ='" + strPackingStyle + "' and Brand='" + strBrand + "' and DeleteStatus = 0 ";
                return Oldb.GetDataTable(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetPONumberDetailsFinal(string strPONumber, string strGrade, string strVariety, string strPackingStyle, string strBrand, string strPackType)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = " select PONumber,Noofslabs,Noofslabs,Matchedfromopen, BalanceSlabs, BalanceCartons, BalanceQty,PackingStyle, Brand ,cartonPacked,CartonRepack,CartonBalRepack,OrderQty from  [PackingSpecification]  where  RepackStatus='Open' and PONumber ='" + strPONumber + "' and Grade='" + strGrade + "' and variety ='" + strVariety + "' and PackingStyle ='" + strPackingStyle + "' and Brand='" + strBrand + "' and DeleteStatus = 0 ";
                return Oldb.GetDataTable(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string getDetailsFresh(string strSoakBCode, string strPONumber, string strGrade, string strVariety, string strPackingStyle, string strBrand, string strFreezingType)
        {
            DataTable dt = new DataTable();
            string s = "";
            string strFreshSlab = "";
            try
            {
                s = " select sum(CAST(NoofSlabCotton as int))  FreshSlab  from [IQFBarcodePrinting] ";
                s = s + " where SlabPacking = 'Matched' and StorageType = 'Final' and LabelStatus = 'Scanned'  and soakingBarcode='" + strSoakBCode + "' and ";
                s = s + " PONumber ='" + strPONumber + "' and Grade = '" + strGrade + "' and  ";
                s = s + "  variety = '" + strVariety + "' and PackingStyle = '" + strPackingStyle + "' and Brand='" + strBrand + "' and FreezingType ='" + strFreezingType + "' ";
                dt = Oldb.GetDataTable(s);
                if (dt.Rows.Count > 0)
                {
                    strFreshSlab = dt.Rows[0]["FreshSlab"].ToString();
                    if (strFreshSlab == "")
                    {
                        strFreshSlab = "0";
                    }
                }
            }
            catch (Exception)
            {
                strFreshSlab = "0";
            }
            return strFreshSlab;
        }

        //Newly Added Thing : July 05 : Pradeep :Func Name - InserPackingscanningNew
        public async Task<ApiResponse> InserPackingscanningNew(List<PackingScanning> pack)
        {
            string strStatus = "Fail";
            DataTable dt = new DataTable();
            List<PackingScanning> RtnFunc = new List<PackingScanning>();
            var response = new ApiResponse();
            try
            {
                if (pack != null)
                {
                    foreach (PackingScanning p in pack)
                    {
                        dt = getDetails(p.barcode);
                        if (dt.Rows.Count > 0)
                        {
                            strStatus = "";
                            string slabtype1 = dt.Rows[0]["SlabPacking"].ToString();
                            string StrSoakingBarcode = dt.Rows[0]["SoakingBarcode"].ToString();
                            string PoNumber = dt.Rows[0]["PoNumber"].ToString();
                            string Grade = dt.Rows[0]["Grade"].ToString();
                            string Variety = dt.Rows[0]["Variety"].ToString();
                            string PackingStyle = dt.Rows[0]["PackingStyle"].ToString();
                            string LCarton = dt.Rows[0]["LooseCotton"].ToString();
                            string StorageType = dt.Rows[0]["StorageType"].ToString();
                            string Brand = dt.Rows[0]["Brand"].ToString();
                            string FreezingType = dt.Rows[0]["FreezingType"].ToString();

                            int slab = 0;

                            if (slabtype1 == "Matched")
                            {
                                int s = Convert.ToInt32(dt.Rows[0]["NoOfSlabCotton"]);
                                slab = Convert.ToInt32(dt.Rows[0]["NoofSlabCotton"]);
                                //get the 3 values
                                decimal slabDedt = Convert.ToDecimal(dt.Rows[0]["SlabsDeduct"]);
                                decimal cartnDedt = Convert.ToDecimal(dt.Rows[0]["CartonsDeduct"]);
                                decimal qtyDedt = Convert.ToDecimal(dt.Rows[0]["QuantityDeduct"]);


                                int BalSlab = 0; decimal OrderQty = 0;
                                decimal BalSlabCarton = 0;
                                decimal BalQty = 0; decimal balanceQty = 0;

                                //string sta = "";
                                int Matched = 0;
                                int noofslab = 0;
                                int diff = 0;
                                int CartonPacked = 0;
                                int CartonRepack = 0;
                                int CartonBalRepack = 0;
                                DataTable dt2 = new DataTable();
                                if (StorageType.ToUpper() == "DUMMY")
                                {
                                    dt2 = GetPONumberDetails(PoNumber, Grade, Variety, PackingStyle, Brand, StorageType);
                                }
                                else if (StorageType.ToUpper() == "FINAL")
                                {
                                    dt2 = GetPONumberDetailsFinal(PoNumber, Grade, Variety, PackingStyle, Brand, StorageType);
                                }

                                if (dt2.Rows.Count > 0)
                                {
                                    BalSlab = Convert.ToInt32(dt2.Rows[0]["BalanceSlabs"].ToString());
                                    noofslab = Convert.ToInt32(dt2.Rows[0]["Noofslabs"].ToString());
                                    Matched = Convert.ToInt32(dt2.Rows[0]["Matchedfromopen"].ToString());
                                    BalSlabCarton = Convert.ToDecimal(dt2.Rows[0]["BalanceCartons"].ToString());
                                    BalQty = Convert.ToDecimal(dt2.Rows[0]["BalanceQty"].ToString());
                                    CartonPacked = Convert.ToInt32(dt2.Rows[0]["CartonPacked"].ToString());
                                    OrderQty = Convert.ToDecimal(dt2.Rows[0]["OrderQty"].ToString());
                                    CartonRepack = Convert.ToInt32(dt2.Rows[0]["CartonRepack"].ToString());
                                    CartonBalRepack = Convert.ToInt32(dt2.Rows[0]["CartonBalRepack"].ToString());

                                    double BalQtyCal = 0.0;
                                    double balstyle = 0.0;
                                    string[] strPackStyleList = PackingStyle.Split('*');
                                    int a1 = 1;
                                    string[] array = strPackStyleList;

                                    foreach (string sPackStyle in array)
                                    {
                                        if (a1 == 1)
                                        {
                                            a1++;
                                            BalQtyCal = Convert.ToDouble(sPackStyle);
                                        }
                                        else
                                        {
                                            balstyle = Convert.ToDouble(sPackStyle);
                                        }
                                    }

                                    string FreshSlab = getDetailsFresh(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, Brand, FreezingType);

                                    double d = Convert.ToDouble(FreshSlab) / BalQtyCal;
                                    CartonPacked = Convert.ToInt32(d) + CartonPacked;

                                    //Final Repack Stats
                                    if (StorageType.ToUpper() == "FINAL")
                                    {
                                        CartonRepack = CartonRepack + 1;
                                    }
                                    else
                                    {
                                        CartonRepack = 0;
                                    }

                                    CartonBalRepack -= CartonPacked;

                                    bool b2 = UpdateScan(p.barcode, p.palletId);
                                    string sYes = YesterdayTodayCount(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "Scanned", "yes", Brand, FreezingType);
                                    string sToday = YesterdayTodayCount(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "Scanned", "today", Brand, FreezingType);

                                    decimal balcot = 0;
                                    bool b3 = false;

                                    if (BalSlabCarton != 0)
                                    {
                                        diff = Convert.ToInt32(BalSlab - slabDedt);//BalanceSlab - SlabDedt

                                        balcot = BalSlabCarton - cartnDedt;//balanceCorton - cortenDedt

                                        balanceQty = BalQty - qtyDedt;//balanceQuantity - QuantityDedt

                                        //Its allow to do some extra qty in packing
                                        var sts = "Open";
                                        if (diff == 0)
                                        {
                                            if (diff >= -10)
                                            {
                                                sts = "Open";
                                            }
                                            else
                                            {
                                                sts = "Closed";
                                            }
                                        }

                                        /*b3 = UpdateBalance(strRepackstatus: (CartonRepack != OrderQty) ? "Open" : "Closed", status: (diff != 0) ? "Open" : "Closed",*/
                                        b3 = UpdateBalance(strRepackstatus: (CartonRepack != OrderQty) ? "Open" : "Closed", status: sts, strBalSlab: diff.ToString(), strBalCarton: balcot.ToString("0.00"),
                                            strBalQty: balanceQty.ToString("0.00"), strPONumber: PoNumber, strGrade: Grade, strVariety: Variety, strPackingStyle: PackingStyle, strYesSlab: sYes, strTodaySlab: sToday,
                                            cartonSlab: CartonPacked.ToString(), cartonRepack: CartonRepack.ToString(), cartonBalRepack: CartonBalRepack.ToString(), strBrand: Brand);
                                    }
                                    else//Need To Add The Condiotion to Close the Repack Status
                                    {
                                        b3 = UpdateRepackBalance(strRepackstatus: (CartonRepack != OrderQty) ? "Open" : "Closed", strPONumber: PoNumber, strGrade: Grade, strVariety: Variety, strPackingStyle: PackingStyle,
                                            cartonSlab: CartonPacked.ToString(), cartonRepack: CartonRepack.ToString(), cartonBalRepack: CartonBalRepack.ToString(), strBrand: Brand);
                                    }
                                    strStatus = ((!b3) ? "Fail" : "Success");

                                }
                                else
                                {
                                    strStatus = "Please check the Pack Spec.";
                                }
                            }
                            else
                            {
                                strStatus = ((!UpdateScan(p.barcode, p.palletId)) ? "Fail" : "Success");
                            }
                        }
                        else
                        {
                            strStatus = "Please check the Barcode value";
                            RtnFunc.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return response = new ApiResponse()
                {
                    Result = ex.Message,
                };

            }

            return response = new ApiResponse()
            {
                Result = strStatus,
                data = RtnFunc.ToArray()
            };

        }


        public async Task<string> InserPackingscanning(List<PackingScanning> pack)
        {
            string strStatus = "Fail";
            DataTable dt = new DataTable();
            try
            {
                if (pack != null)
                {
                    foreach (PackingScanning p in pack)
                    {
                        dt = getDetails(p.barcode);
                        if (dt.Rows.Count > 0)
                        {
                            strStatus = "";
                            string slabtype1 = dt.Rows[0]["SlabPacking"].ToString();
                            string StrSoakingBarcode = dt.Rows[0]["SoakingBarcode"].ToString();
                            string PoNumber = dt.Rows[0]["PoNumber"].ToString();
                            string Grade = dt.Rows[0]["Grade"].ToString();
                            string Variety = dt.Rows[0]["Variety"].ToString();
                            string PackingStyle = dt.Rows[0]["PackingStyle"].ToString();
                            string LCarton = dt.Rows[0]["LooseCotton"].ToString();
                            string StorageType = dt.Rows[0]["StorageType"].ToString();
                            string Brand = dt.Rows[0]["Brand"].ToString();
                            string FreezingType = dt.Rows[0]["FreezingType"].ToString();

                            int slab = 0;

                            if (slabtype1 == "Matched")
                            {
                                int s = Convert.ToInt32(dt.Rows[0]["NoOfSlabCotton"]);
                                slab = Convert.ToInt32(dt.Rows[0]["NoofSlabCotton"]);
                                //get the 3 values
                                decimal slabDedt = Convert.ToDecimal(dt.Rows[0]["SlabsDeduct"]);
                                decimal cartnDedt = Convert.ToDecimal(dt.Rows[0]["CartonsDeduct"]);
                                decimal qtyDedt = Convert.ToDecimal(dt.Rows[0]["QuantityDeduct"]);


                                int BalSlab = 0; decimal OrderQty = 0;

                                decimal BalSlabCarton = 0;

                                decimal BalQty = 0; decimal balanceQty = 0;

                                //string sta = "";
                                int Matched = 0;
                                int noofslab = 0;
                                int diff = 0;
                                int CartonPacked = 0;
                                int CartonRepack = 0;
                                int CartonBalRepack = 0;
                                DataTable dt2 = new DataTable();
                                if (StorageType.ToUpper() == "DUMMY")
                                {
                                    dt2 = GetPONumberDetails(PoNumber, Grade, Variety, PackingStyle, Brand, StorageType);
                                }
                                else if (StorageType.ToUpper() == "FINAL")
                                {
                                    dt2 = GetPONumberDetailsFinal(PoNumber, Grade, Variety, PackingStyle, Brand, StorageType);
                                }

                                if (dt2.Rows.Count > 0)
                                {
                                    BalSlab = Convert.ToInt32(dt2.Rows[0]["BalanceSlabs"].ToString());
                                    noofslab = Convert.ToInt32(dt2.Rows[0]["Noofslabs"].ToString());
                                    Matched = Convert.ToInt32(dt2.Rows[0]["Matchedfromopen"].ToString());

                                    BalSlabCarton = Convert.ToDecimal(dt2.Rows[0]["BalanceCartons"].ToString());

                                    BalQty = Convert.ToDecimal(dt2.Rows[0]["BalanceQty"].ToString());
                                    CartonPacked = Convert.ToInt32(dt2.Rows[0]["CartonPacked"].ToString());

                                    OrderQty = Convert.ToDecimal(dt2.Rows[0]["OrderQty"].ToString());
                                    CartonRepack = Convert.ToInt32(dt2.Rows[0]["CartonRepack"].ToString());

                                    CartonBalRepack = Convert.ToInt32(dt2.Rows[0]["CartonBalRepack"].ToString());

                                    double BalQtyCal = 0.0;
                                    double balstyle = 0.0;
                                    string[] strPackStyleList = PackingStyle.Split('*');
                                    int a1 = 1;
                                    string[] array = strPackStyleList;

                                    foreach (string sPackStyle in array)
                                    {
                                        if (a1 == 1)
                                        {
                                            a1++;
                                            BalQtyCal = Convert.ToDouble(sPackStyle);
                                        }
                                        else
                                        {
                                            balstyle = Convert.ToDouble(sPackStyle);
                                        }
                                    }

                                    string FreshSlab = getDetailsFresh(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, Brand, FreezingType);

                                    double d = Convert.ToDouble(FreshSlab) / BalQtyCal;
                                    CartonPacked = Convert.ToInt32(d) + CartonPacked;

                                    //Final Repack Stats
                                    if (StorageType.ToUpper() == "FINAL")
                                    {
                                        CartonRepack = CartonRepack + 1;
                                    }
                                    else
                                    {
                                        CartonRepack = 0;
                                    }

                                    CartonBalRepack -= CartonPacked;

                                    bool b2 = UpdateScan(p.barcode, p.palletId);
                                    string sYes = YesterdayTodayCount(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "Scanned", "yes", Brand, FreezingType);
                                    string sToday = YesterdayTodayCount(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "Scanned", "today", Brand, FreezingType);

                                    decimal balcot = 0;
                                    bool b3 = false;

                                    if (BalSlabCarton != 0)
                                    {
                                        diff = Convert.ToInt32(BalSlab - slabDedt);//BalanceSlab - SlabDedt

                                        balcot = BalSlabCarton - cartnDedt;//balanceCorton - cortenDedt

                                        balanceQty = BalQty - qtyDedt;//balanceQuantity - QuantityDedt

                                        b3 = UpdateBalance(strRepackstatus: (CartonRepack != OrderQty) ? "Open" : "Closed", status: (diff != 0) ? "Open" : "Closed", strBalSlab: diff.ToString(), strBalCarton: balcot.ToString("0.00"),
                                            strBalQty: balanceQty.ToString("0.00"), strPONumber: PoNumber, strGrade: Grade, strVariety: Variety, strPackingStyle: PackingStyle, strYesSlab: sYes, strTodaySlab: sToday,
                                            cartonSlab: CartonPacked.ToString(), cartonRepack: CartonRepack.ToString(), cartonBalRepack: CartonBalRepack.ToString(), strBrand: Brand);
                                    }
                                    else//Need To Add The Condiotion to Close the Repack Status
                                    {
                                        b3 = UpdateRepackBalance(strRepackstatus: (CartonRepack != OrderQty) ? "Open" : "Closed", strPONumber: PoNumber, strGrade: Grade, strVariety: Variety, strPackingStyle: PackingStyle,
                                            cartonSlab: CartonPacked.ToString(), cartonRepack: CartonRepack.ToString(), cartonBalRepack: CartonBalRepack.ToString(), strBrand: Brand);
                                    }
                                    strStatus = ((!b3) ? "Fail" : "Success");

                                }
                                else
                                {
                                    strStatus = "Please check the Pack Spec.";
                                }
                            }
                            else
                            {
                                strStatus = ((!UpdateScan(p.barcode, p.palletId)) ? "Fail" : "Success");
                            }
                        }
                        else
                        {
                            strStatus = "Please check the Barcode value";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return strStatus;
        }

        public async Task<string> InsertPackingScanData(List<PackingScanning> pack)
        {
            string strStatus = "Fail";

            try
            {
                DataTable dt = new DataTable();
                if (pack != null)
                {
                    foreach (PackingScanning p in pack)
                    {
                        dt = getDetails(p.barcode);
                        if (dt.Rows.Count > 0)
                        {
                            strStatus = "";
                            string slabtype1 = dt.Rows[0]["SlabPacking"].ToString();
                            string StrSoakingBarcode = dt.Rows[0]["SoakingBarcode"].ToString();
                            string PoNumber = dt.Rows[0]["PoNumber"].ToString();
                            string Grade = dt.Rows[0]["Grade"].ToString();
                            string Variety = dt.Rows[0]["Variety"].ToString();
                            string PackingStyle = dt.Rows[0]["PackingStyle"].ToString();
                            string LCarton = dt.Rows[0]["LooseCotton"].ToString();
                            string StorageType = dt.Rows[0]["StorageType"].ToString();
                            string Brand = dt.Rows[0]["Brand"].ToString();
                            string FreezingType = dt.Rows[0]["FreezingType"].ToString();
                            int slab = 0;
                            if (slabtype1 == "Matched")
                            {
                                int s = Convert.ToInt32(dt.Rows[0]["NoOfSlabCotton"]);
                                slab = Convert.ToInt32(dt.Rows[0]["NoofSlabCotton"]);
                                int BalSlab = 0;
                                int BalSlabCarton = 0;
                                double BalQty = 0.0;
                                //string sta = "";
                                int Matched = 0;
                                int noofslab = 0;
                                int diff = 0;
                                int CartonPacked = 0;
                                int CartonRepack = 0;
                                int CartonBalRepack = 0;
                                DataTable dt2 = new DataTable();
                                if (StorageType.ToUpper() == "DUMMY")
                                {
                                    dt2 = GetPONumberDetails(PoNumber, Grade, Variety, PackingStyle, Brand, StorageType);
                                }
                                else if (StorageType.ToUpper() == "FINAL")
                                {
                                    dt2 = GetPONumberDetailsFinal(PoNumber, Grade, Variety, PackingStyle, Brand, StorageType);
                                }
                                if (dt2.Rows.Count > 0)
                                {
                                    BalSlab = Convert.ToInt32(dt2.Rows[0]["BalanceSlabs"].ToString());
                                    noofslab = Convert.ToInt32(dt2.Rows[0]["Noofslabs"].ToString());
                                    Matched = Convert.ToInt32(dt2.Rows[0]["Matchedfromopen"].ToString());

                                    decimal vlue = Convert.ToDecimal(dt2.Rows[0]["BalanceCartons"].ToString());
                                    BalSlabCarton = Convert.ToInt32(vlue);

                                    BalQty = Convert.ToDouble(dt2.Rows[0]["BalanceQty"].ToString());
                                    CartonPacked = Convert.ToInt32(dt2.Rows[0]["CartonPacked"].ToString());
                                    CartonRepack = Convert.ToInt32(dt2.Rows[0]["CartonRepack"].ToString());
                                    CartonBalRepack = Convert.ToInt32(dt2.Rows[0]["CartonBalRepack"].ToString());

                                    double BalQtyCal = 0.0;
                                    double balstyle = 0.0;
                                    string[] strPackStyleList = PackingStyle.Split('*');
                                    int a1 = 1;
                                    string[] array = strPackStyleList;

                                    foreach (string sPackStyle in array)
                                    {
                                        if (a1 == 1)
                                        {
                                            a1++;
                                            BalQtyCal = Convert.ToDouble(sPackStyle);
                                        }
                                        else
                                        {
                                            balstyle = Convert.ToDouble(sPackStyle);
                                        }
                                    }

                                    string i = getDetailsFresh(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, Brand, FreezingType);

                                    double d = Convert.ToDouble(i) / BalQtyCal;
                                    CartonPacked = Convert.ToInt32(d) + CartonPacked;

                                    CartonRepack = 0;
                                    CartonBalRepack -= CartonPacked;

                                    bool b2 = UpdateScan(p.barcode, p.palletId);
                                    string sYes = YesterdayTodayCount(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "Scanned", "yes", Brand, FreezingType);
                                    string sToday = YesterdayTodayCount(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "Scanned", "today", Brand, FreezingType);
                                    double balcot = 0.0;
                                    //string sta2 = "";
                                    bool b3 = false;
                                    if (BalSlabCarton != 0)
                                    {
                                        diff = noofslab - Matched - Convert.ToInt32(sYes) - Convert.ToInt32(sToday);

                                        balcot = ((!(LCarton == "0")) ? ((double)BalSlabCarton) : ((double)diff / BalQtyCal));
                                        BalQty = (double)diff * balstyle;
                                        b3 = UpdateBalance(strRepackstatus: (CartonBalRepack != 0) ? "Open" : "Closed", status: (diff != 0) ? "Open" : "Closed", strBalSlab: diff.ToString(), strBalCarton: balcot.ToString(), strBalQty: BalQty.ToString(), strPONumber: PoNumber, strGrade: Grade, strVariety: Variety, strPackingStyle: PackingStyle, strYesSlab: sYes, strTodaySlab: sToday, cartonSlab: CartonPacked.ToString(), cartonRepack: CartonRepack.ToString(), cartonBalRepack: CartonBalRepack.ToString(), strBrand: Brand);
                                    }
                                    else
                                    {
                                        b3 = UpdateRepackBalance(strRepackstatus: (CartonBalRepack != 0) ? "Open" : "Closed", strPONumber: PoNumber, strGrade: Grade, strVariety: Variety, strPackingStyle: PackingStyle, cartonSlab: CartonPacked.ToString(), cartonRepack: CartonRepack.ToString(), cartonBalRepack: CartonBalRepack.ToString(), strBrand: Brand);
                                    }
                                    strStatus = ((!b3) ? "Fail" : "Success");
                                }
                                else
                                {
                                    strStatus = "Please check the Pack Spec.";
                                }
                            }
                            else
                            {
                                strStatus = ((!UpdateScan(p.barcode, p.palletId)) ? "Fail" : "Success");
                            }
                        }
                        else
                        {
                            strStatus = "Please check the Barcode value";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return strStatus;
        }

        public DataTable getPackingDetails(string strBarcode, string PONumber, string strGrade, string strVariety, string strPS, string action, string strBrand)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                if (action == "1")
                {
                    s = "select count(*) as CartonCount from IQFBarcodePrinting where SoakingBarcode = '" + strBarcode + "' and  Grade ='" + strGrade + "' and Variety='" + strVariety + "' and PackingStyle='" + strPS + "' and Brand='" + strBrand + "' and  LabelStatus = 'Scanned' and LooseCotton = '0'";
                }
                else if (action == "2")
                {
                    s = "select count(*) as LooseCartonCount from IQFBarcodePrinting where SoakingBarcode = '" + strBarcode + "' and  Grade ='" + strGrade + "' and Variety='" + strVariety + "' and PackingStyle='" + strPS + "' and Brand='" + strBrand + "'  and LabelStatus = 'Scanned' and LooseCotton != '0' ";
                }
                return Oldb.GetDataTable(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable getDetails(string strBarcode)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = " select *  from  [IQFBarcodePrinting]  where  PackBarcode ='" + strBarcode.Trim() + "' and LabelStatus='Label Print' ";
                return Oldb.GetDataTable(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateBalance(string strBalSlab, string strBalCarton, string strBalQty, string strPONumber, string strGrade, string strVariety, string strPackingStyle, string status, string strYesSlab, string strTodaySlab, string cartonSlab, string cartonRepack, string cartonBalRepack, string strBrand, string strRepackstatus)
        {
            string s = "";
            try
            {
                s = " Update  PackingSpecification set BalanceSlabs='" + strBalSlab + "' ,PackingStatus = '" + status + "',  ";
                s = s + " BalanceCartons ='" + strBalCarton + "' ,BalanceQty ='" + strBalQty + "' , ";
                s = s + " NoofSlabsYesterday ='" + strYesSlab + "',NoofSlabsToday='" + strTodaySlab + "'  , ";
                s = s + " CartonPacked='" + cartonSlab + "', CartonRepack='" + cartonRepack + "' , CartonBalRepack='" + cartonBalRepack + "', RepackStatus = '" + strRepackstatus + "' ";
                s = s + "  where  PONumber ='" + strPONumber + "' ";
                s = s + " and Grade='" + strGrade + "' and variety ='" + strVariety + "' and PackingStyle ='" + strPackingStyle + "'  and Brand ='" + strBrand + "' and DeleteStatus = 0 ";
                return Oldb.ExecuteNonQuery(s);
                //return Data.Instance.ExecuteNonQuery(s);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateRepackBalance(string strPONumber, string strGrade, string strVariety, string strPackingStyle, string cartonSlab, string cartonRepack, string cartonBalRepack, string strBrand, string strRepackstatus)
        {
            string s = "";
            try
            {
                s = " UPDATE  PackingSpecification  ";
                s = s + "  SET   CartonPacked='" + cartonSlab + "', CartonRepack='" + cartonRepack + "' , CartonBalRepack='" + cartonBalRepack + "', RepackStatus = '" + strRepackstatus + "' ";
                s = s + "  WHERE  PONumber ='" + strPONumber + "' ";
                s = s + " and Grade='" + strGrade + "' and variety ='" + strVariety + "' and PackingStyle ='" + strPackingStyle + "'  and Brand ='" + strBrand + "' and DeleteStatus = 0 ";
                return Oldb.ExecuteNonQuery(s);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string YesterdayTodayCount(string strSoakBCode, string strPONumber, string strGrade, string strVariety, string strPackingStyle, string status, string s1, string strBrand, string strFreezingType)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            int noofslab = 0;
            int noofloose = 0;
            string Yescount = "";
            try
            {
                s2 = " select SUM(CAST(Noofslabcotton as int)) as SCount,SUM(CAST(LooseCotton as int)) as LCount ";
                s2 = s2 + "  from  [IQFBarcodePrinting] where soakingBarcode='" + strSoakBCode + "' and ";
                s2 = s2 + " PONumber ='" + strPONumber + "' and Grade = '" + strGrade + "' and  ";
                s2 = s2 + "  variety = '" + strVariety + "' and PackingStyle = '" + strPackingStyle + "' and Brand='" + strBrand + "' and LabelStatus='Scanned' and FreezingType ='" + strFreezingType + "' ";
                if (s1 == "yes")
                {
                    s2 += " and convert(nvarchar(max), UpdatedDate, 112)   <= convert(nvarchar(max), GETDATE(), 112) -1  ";
                }
                if (s1 == "today")
                {
                    s2 += " and convert(nvarchar(max), UpdatedDate, 112)  = convert(nvarchar(max), GETDATE(), 112)   ";
                }
                dt = Oldb.GetDataTable(s2);
                if (dt.Rows.Count > 0)
                {
                    noofslab = ((!(dt.Rows[0]["SCount"].ToString() == "")) ? Convert.ToInt32(dt.Rows[0]["SCount"].ToString()) : 0);
                    noofloose = ((!(dt.Rows[0]["LCount"].ToString() == "")) ? Convert.ToInt32(dt.Rows[0]["LCount"].ToString()) : 0);
                    Yescount = (noofloose + noofslab).ToString();
                }
            }
            catch (Exception)
            {
                Yescount = "";
            }
            return Yescount;
        }

        public bool UpdateQty(string strQty, string status)
        {
            string s = "";
            try
            {
                s = " update IQFFinalData set Quantity = '" + strQty + "' where barcodeId = '" + status + "' ";
                //return Oldb.ExecuteNonQuery(s);
                return Data.Instance.ExecuteNonQuery(s);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateScan(string barcodeid, string palletid)
        {
            string s = "";
            try
            {
                s = " update IQFBarcodePrinting set LabelStatus = 'Scanned',UpdatedDate=getdate(),PalletId='" + palletid + "' where PackBarcode = '" + barcodeid + "'  ";
                return Oldb.ExecuteNonQuery(s);
                //return   Data.Instance.ExecuteNonQuery(s);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<PackingBF>> GetPackingBFDetails()
        {
            var log_txt = "";

            DataTable dt = new DataTable();
            int count = 0;
            PackingBF p = null;
            List<PackingBF> pck = new List<PackingBF>();
            try
            {
                string strqry = "select PackID, BuyerName, PONumber, CargoNumber, Brand, PackingStyle, PackingType, Glaze, Unit, Grade, Variety, TargetCount, OrderQty, NoofSlabs, MatchedfromOpen, NoofSlabsYesterday, NoofSlabsToday, BalanceSlabs, BalanceCartons, BalanceQty, CartonPacked,  CartonRepack, CartonBalRepack, ChemicalTreatment, Remarks, Packingstatus, VerifiedBy ,   DeleteStatus , CreatedDate,CreatedBy,UpdatedBy,UpdatedDate from PackingSpecification  where RepackStatus = 'Open' and DeleteStatus = 0";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        p = new PackingBF();
                        p.packID = dt.Rows[i]["PackID"].ToString();
                        p.buyerName = dt.Rows[i]["BuyerName"].ToString();
                        p.poNumber = dt.Rows[i]["PONumber"].ToString();
                        p.cargoNumber = dt.Rows[i]["CargoNumber"].ToString();
                        p.brand = dt.Rows[i]["Brand"].ToString();
                        p.packingStyle = dt.Rows[i]["PackingStyle"].ToString();
                        p.packingType = dt.Rows[i]["PackingType"].ToString();
                        p.glaze = dt.Rows[i]["Glaze"].ToString();
                        p.unit = dt.Rows[i]["Unit"].ToString();
                        p.grade = dt.Rows[i]["Grade"].ToString();
                        p.variety = dt.Rows[i]["Variety"].ToString();
                        p.targetCount = dt.Rows[i]["TargetCount"].ToString();
                        p.orderQty = dt.Rows[i]["OrderQty"].ToString();
                        p.noOfSlabs = dt.Rows[i]["NoofSlabs"].ToString();
                        p.matchedFromOpen = dt.Rows[i]["MatchedfromOpen"].ToString();
                        p.noOfSlabsYesterday = dt.Rows[i]["NoofSlabsYesterday"].ToString();
                        p.noOfSlabsToday = dt.Rows[i]["NoofSlabsToday"].ToString();
                        p.balanceSlabs = dt.Rows[i]["BalanceSlabs"].ToString();
                        p.balanceCartons = dt.Rows[i]["BalanceCartons"].ToString();
                        p.balanceQty = dt.Rows[i]["BalanceQty"].ToString();
                        p.cartonPacked = dt.Rows[i]["CartonPacked"].ToString();
                        p.cartonRepack = dt.Rows[i]["CartonRepack"].ToString();
                        p.cartonBalRepack = dt.Rows[i]["CartonBalRepack"].ToString();
                        p.chemicalTreatment = dt.Rows[i]["ChemicalTreatment"].ToString();
                        p.remarks = dt.Rows[i]["Remarks"].ToString();
                        p.packingStatus = dt.Rows[i]["Packingstatus"].ToString();
                        p.verifiedBy = dt.Rows[i]["VerifiedBy"].ToString();
                        p.CreatedDate = dt.Rows[i]["CreatedDate"].ToString();
                        p.CreatedBy = dt.Rows[i]["CreatedBy"].ToString();
                        p.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                        p.UpdatedDate = dt.Rows[i]["UpdatedDate"].ToString();
                        p.DeleteStatus = Convert.ToBoolean(dt.Rows[i]["DeleteStatus"].ToString());

                        pck.Add(p);
                    }
                }
                if (pck.Count == 0)
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Get PackingBf Data Failed..." + ":::" + p;
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Get PackingBf Data Success !!";
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched in Get PackingBF.." + ":::" + ex.ToString();
                log.writeLog(log_exc);
                return pck = null;
            }
            return pck;
        }
    }
}