// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.ICECond
namespace AQUAWEBAPI
{
    public class ICECond
    {
        private string iCECond = string.Empty;

        public string ICECondition
        {
            get
            {
                return iCECond;
            }
            set
            {
                iCECond = value;
            }
        }
    }
}