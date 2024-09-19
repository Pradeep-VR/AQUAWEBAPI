// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.BeheadingGet
namespace AQUAWEBAPI
{
    public class BeheadingGet
    {
        private string m_saudaNumber = "";

        private string m_batchNo = "";

        private string m_batchWiseLotNo = "";

        private string m_farmerName = "";

        private string m_purchaseDate = "";

        private string m_purchaseType = "";

        private string m_supplierName = "";

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

        public string supplierName
        {
            get
            {
                return m_supplierName;
            }
            set
            {
                m_supplierName = value;
            }
        }

        public string batchNumber
        {
            get
            {
                return m_batchNo;
            }
            set
            {
                m_batchNo = value;
            }
        }

        public string batchWiseLotNo
        {
            get
            {
                return m_batchWiseLotNo;
            }
            set
            {
                m_batchWiseLotNo = value;
            }
        }

        public string farmerName
        {
            get
            {
                return m_farmerName;
            }
            set
            {
                m_farmerName = value;
            }
        }

        public string purchaseDate
        {
            get
            {
                return m_purchaseDate;
            }
            set
            {
                m_purchaseDate = value;
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
    }
}