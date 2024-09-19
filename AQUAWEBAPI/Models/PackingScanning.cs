// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.PackingScanning

namespace AQUAWEBAPI
{
    public class PackingScanning
    {
        private string m_barcode = "";

        private string m_palletId = "";

        private string m_monitoredBy = "";

        private string m_approvedBy = "";

        private string m_dateAndTime = "";

        public string barcode
        {
            get
            {
                return m_barcode;
            }
            set
            {
                m_barcode = value;
            }
        }

        public string palletId
        {
            get
            {
                return m_palletId;
            }
            set
            {
                m_palletId = value;
            }
        }

        public string monitoredBy
        {
            get
            {
                return m_monitoredBy;
            }
            set
            {
                m_monitoredBy = value;
            }
        }

        public string approvedBy
        {
            get
            {
                return m_approvedBy;
            }
            set
            {
                m_approvedBy = value;
            }
        }

        public string dateAndTime
        {
            get
            {
                return m_dateAndTime;
            }
            set
            {
                m_dateAndTime = value;
            }
        }
    }
}