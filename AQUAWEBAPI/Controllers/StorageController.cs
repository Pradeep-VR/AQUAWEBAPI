// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.StorageController
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using AQUAWEBAPI;
using AQUAWEBAPI.Models;

public class StorageController : ApiController
{
    Logger log = new Logger();
    StorageManagement storeMgt = new StorageManagement();

    [Route("api/Storage")]
	public List<Storage> GetStorage()
	{ 
		return storeMgt.GetStorageDetails();
	}

	[Route("api/GetStorageDetails")]
	public List<StorageOut> GetStorageOutDetails()
	{
		return storeMgt.GetStorageOutDetails();
	}

	[Route("api/StorageIN")]
	public List<StorageIN> GetStorageIN()
	{
		return storeMgt.GetStorageINDetails();
	}

	public IEnumerable<string> Get()
	{
		return new string[2] { "value1", "value2" };
	}

	//public string Get(int id)
	//{
	//	return "value";
	//}

	[Route("api/AquaStorageInData")]
	public string PostStorageIN([FromBody] Dictionary<string, List<StorageIN>> StorageINData)
	{
		string s = "Not Loaded";
		string b = "Loaded";
        var log_txt = "";
        try
		{
			if (StorageINData != null)
			{
				foreach (KeyValuePair<string, List<StorageIN>> StorageINDatum in StorageINData)
				{
					List<StorageIN> sin = StorageINDatum.Value;
					b = storeMgt.InsertStorageINData(sin);
					s = ((!(b == "Success")) ? ("Failure" + StorageINData.Count + b) : "successfully");
				}
			}
			else
			{
				s = "Error" + b;
			}
            if (s == "successfully")
            {
                log_txt = DateTime.Now.ToString() + ":::" + "Inserting StorageIN Data is Success..";
            }
            else
            {
                log_txt = DateTime.Now.ToString() + ":::" + "Inserting StorageIN Data is Failed.." + s;
            }
            log.writeLog(log_txt);
        }
		catch (Exception ex)
		{
			s = ex.ToString();
            var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In StorageIN Data.." + s;
            log.writeLog(log_exc);
        }
		return s;
	}

	[Route("api/AquaStorageOutData")]
	public string PostStorageOut([FromBody] Dictionary<string, List<Store>> store)
	{
		string s = "Not Loaded";
		string b = "Loaded";
        var log_txt = "";
        try
		{
			if (store != null)
			{
				foreach (KeyValuePair<string, List<Store>> item in store)
				{
					List<Store> sin = item.Value;
					b = storeMgt.InsertStorageOutData(sin);
					s = ((!(b == "Success")) ? ("Failure " + store.Count + b) : "successfully");
				}
			}
			else
			{
				s = "Error" + b;
			}
            if (s == "successfully")
            {
                log_txt = DateTime.Now.ToString() + ":::" + "Inserting StorageOUT Data is Success..";
            }
            else
            {
                log_txt = DateTime.Now.ToString() + ":::" + "Inserting StorageOUT Data is Failed.." + s;
            }
            log.writeLog(log_txt);
        }
		catch (Exception ex)
		{
			s = ex.ToString();
            var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In StorageOUT Data.." + s;
            log.writeLog(log_exc);
        }
		return s;
	}

}
