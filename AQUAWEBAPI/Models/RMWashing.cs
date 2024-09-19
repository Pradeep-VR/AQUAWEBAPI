// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.RMWashing
namespace AQUAWEBAPI
{
    public class RMWashing
    {
        private string m_saudaNumber = null;

        private string m_purchaseType = null;

        private string m_totalWeight = null;

        private string m_totalCrates = null;

        private string m_drainedTime = null;

        private string m_dateTime = null;

        public string saudaNumber
        {
            get
            {
                return m_saudaNumber;
            }
            set
            {
                m_saudaNumber = value;
            }
        }

        public string purchaseType
        {
            get
            {
                return m_purchaseType;
            }
            set
            {
                m_purchaseType = value;
            }
        }

        public string totalWeight
        {
            get
            {
                return m_totalWeight;
            }
            set
            {
                m_totalWeight = value;
            }
        }

        public string totalCrates
        {
            get
            {
                return m_totalCrates;
            }
            set
            {
                m_totalCrates = value;
            }
        }

        public string drainedTime
        {
            get
            {
                return m_drainedTime;
            }
            set
            {
                m_drainedTime = value;
            }
        }

        public string dateTime
        {
            get
            {
                return m_dateTime;
            }
            set
            {
                m_dateTime = value;
            }
        }
    }
}