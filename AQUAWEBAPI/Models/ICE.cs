// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.ICE
using System.Collections.Generic;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class ICE
    {
        private List<ICECond> ICECond;

        public List<ICECond> ICECondition
        {
            get
            {
                return ICECond;
            }
            set
            {
                ICECond = value;
            }
        }
    }
}