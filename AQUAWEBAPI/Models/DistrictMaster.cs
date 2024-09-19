// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.DistrictMaster
namespace AQUAWEBAPI
{
    public class DistrictMaster
    {
        private string m_ID = null;

        private string m_districtName = null;

        public string ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        public string districtName
        {
            get
            {
                return m_districtName;
            }
            set
            {
                m_districtName = value;
            }
        }
    }
}