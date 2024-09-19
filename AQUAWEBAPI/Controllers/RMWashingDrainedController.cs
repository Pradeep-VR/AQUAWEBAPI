// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.RMWashingDrainedController
using System.Collections.Generic;
using System.Web.Http;

public class RMWashingDrainedController : ApiController
{
	public IEnumerable<string> Get()
	{
		return new string[2] { "value1", "value2" };
	}

	public string Get(int id)
	{
		return "value";
	}

	public void Post([FromBody] string value)
	{
	}

	public void Put(int id, [FromBody] string value)
	{
	}

	public void Delete(int id)
	{
	}
}
