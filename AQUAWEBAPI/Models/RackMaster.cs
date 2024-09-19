// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.RackMaster
namespace AQUAWEBAPI
{
    public class RackMaster
    {
        private string m_storeNumber;

        private string m_rackNumber;

        private string m_locationName;

        public string storeNumber
        {
            get
            {
                return m_storeNumber;
            }
            set
            {
                m_storeNumber = value;
            }
        }

        public string rackNumber
        {
            get
            {
                return m_rackNumber;
            }
            set
            {
                m_rackNumber = value;
            }
        }

        public string locationName
        {
            get
            {
                return m_locationName;
            }
            set
            {
                m_locationName = value;
            }
        }
    }
}