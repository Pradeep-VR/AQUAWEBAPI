// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.PeelingRejection

namespace AQUAWEBAPI
{
    public class PeelingRejection
    {
        private string m_barcodeId = null;

        private string m_batchNo = null;

        private string m_selectGrade = null;

        private string m_initialProductType = null;

        private string m_hlQtyRejForPeeling = null;

        private string m_newProductType = null;

        private string m_tableNo = null;

        private string m_qualityIssue = null;

        private string m_peelingDate = null;

        private string m_peeledQty = null;

        private string m_peelingYield = null;

        private string m_remarks = null;

        private string m_dateAndTime = null;

        private string m_status = null;

        public string remarks
        {
            get
            {
                return m_remarks;
            }
            set
            {
                m_remarks = value;
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

        public string qualityIssue
        {
            get
            {
                return m_qualityIssue;
            }
            set
            {
                m_qualityIssue = value;
            }
        }

        public string barcodeId
        {
            get
            {
                return m_barcodeId;
            }
            set
            {
                m_barcodeId = value;
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

        public string selectGrade
        {
            get
            {
                return m_selectGrade;
            }
            set
            {
                m_selectGrade = value;
            }
        }

        public string initialProductType
        {
            get
            {
                return m_initialProductType;
            }
            set
            {
                m_initialProductType = value;
            }
        }

        public string hlQtyRejForPeeling
        {
            get
            {
                return m_hlQtyRejForPeeling;
            }
            set
            {
                m_hlQtyRejForPeeling = value;
            }
        }

        public string newProductType
        {
            get
            {
                return m_newProductType;
            }
            set
            {
                m_newProductType = value;
            }
        }

        public string tableNo
        {
            get
            {
                return m_tableNo;
            }
            set
            {
                m_tableNo = value;
            }
        }

        public string peelingDate
        {
            get
            {
                return m_peelingDate;
            }
            set
            {
                m_peelingDate = value;
            }
        }

        public string peeledQty
        {
            get
            {
                return m_peeledQty;
            }
            set
            {
                m_peeledQty = value;
            }
        }

        public string peelingYield
        {
            get
            {
                return m_peelingYield;
            }
            set
            {
                m_peelingYield = value;
            }
        }
    }
}