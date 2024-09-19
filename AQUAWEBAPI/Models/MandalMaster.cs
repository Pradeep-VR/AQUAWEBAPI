// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.MandalMaster
namespace AQUAWEBAPI
{
    public class MandalMaster
    {
        private string m_ID = null;

        private string m_mandalName = null;

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

        public string mandalName
        {
            get
            {
                return m_mandalName;
            }
            set
            {
                m_mandalName = value;
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