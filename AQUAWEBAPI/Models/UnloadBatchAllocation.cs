// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.UnloadBatchAllocation
namespace AQUAWEBAPI
{
    public class UnloadBatchAllocationNew
    {
        public string TransId { get; set; }
        public string batchNoActLot { get; set; }
        public string batchNo { get; set; }
        public string batchParent { get; set; }
        public string saudaNo { get; set; }
        public string dateTime { get; set; }
        public string noOfCrates { get; set; }
        public string status { get; set; }
        public string createdBy { get; set; }
        public string createdDate { get; set; }
        public string lotNo { get; set; }
    }
    public class UnloadBatchAllocation
    {
        private string m_batchNo;

        private string m_batchParent;

        private string m_saudaNo;

        private string m_dateTime;

        private string m_noOfCrates;

        private string m_status;

        private string m_createdBy;

        private string m_createdDate;

        private string m_lotNo;

        public string batchNoActLot
        {
            get
            {
                return m_lotNo;
            }
            set
            {
                m_lotNo = value;
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

        public string batchParent
        {
            get
            {
                return m_batchParent;
            }
            set
            {
                m_batchParent = value;
            }
        }

        public string saudaNo
        {
            get
            {
                return m_saudaNo;
            }
            set
            {
                m_saudaNo = value;
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

        public string noOfCrates
        {
            get
            {
                return m_noOfCrates;
            }
            set
            {
                m_noOfCrates = value;
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

        public string createdBy
        {
            get
            {
                return m_createdBy;
            }
            set
            {
                m_createdBy = value;
            }
        }

        public string createdDate
        {
            get
            {
                return m_createdDate;
            }
            set
            {
                m_createdDate = value;
            }
        }
    }
}