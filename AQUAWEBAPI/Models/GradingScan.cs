// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.GradingScan
namespace AQUAWEBAPI
{
    public class GradingScan
    {
        private string m_barcode = string.Empty;

        private string m_batchNo = string.Empty;

        private string m_productType = string.Empty;

        private string m_grade = string.Empty;

        private string m_targetFlatCount = string.Empty;

        private string m_weighment = string.Empty;

        private string m_dateAndTime = string.Empty;

        private string m_BSRatio = string.Empty;

        private string m_Crate = string.Empty;

        private string m_status = "";
        private string m_batchLotNumber = "";


        public string batchLotNumber
        {
            get
            {
                return m_batchLotNumber;
            }
            set
            {
                m_batchLotNumber = value;
            }
        }


        public string status
        {
            get
            {
                return m_status;
            }
            set
            {
                m_status = value;
            }
        }

        public string BSRatio
        {
            get
            {
                return m_BSRatio;
            }
            set
            {
                m_BSRatio = value;
            }
        }

        public string Crate
        {
            get
            {
                return m_Crate;
            }
            set
            {
                m_Crate = value;
            }
        }

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

        public string batchNo
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

        public string productType
        {
            get
            {
                return m_productType;
            }
            set
            {
                m_productType = value;
            }
        }

        public string grade
        {
            get
            {
                return m_grade;
            }
            set
            {
                m_grade = value;
            }
        }

        public string targetFlatCount
        {
            get
            {
                return m_targetFlatCount;
            }
            set
            {
                m_targetFlatCount = value;
            }
        }

        public string weighment
        {
            get
            {
                return m_weighment;
            }
            set
            {
                m_weighment = value;
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