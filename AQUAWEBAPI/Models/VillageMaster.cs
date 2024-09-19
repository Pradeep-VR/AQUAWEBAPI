// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.VillageMaster
namespace AQUAWEBAPI
{
    public class VillageMaster
    {
        private string m_ID = null;

        private string m_villageName = null;

        private string m_mandalName = null;

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

        public string villageName
        {
            get
            {
                return m_villageName;
            }
            set
            {
                m_villageName = value;
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
    }
}