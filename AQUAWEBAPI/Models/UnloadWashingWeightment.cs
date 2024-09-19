// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.UnloadWashingWeightment
namespace AQUAWEBAPI
{
    public class UnloadWashingWeightmentNew
    {
        public string TransId { get; set; }
        public string saudaNo { get; set; }
        public string batchParent { get; set; }
        public string lotWiseBatch { get; set; }
        public string noOfCrates { get; set; }
        public string crateWt { get; set; }
        public string grossWeight { get; set; }
        public string totalRmWeight { get; set; }
        public string status { get; set; }
        public string dateTime { get; set; }
        public string createdBy { get; set; }
        public string createdDate { get; set; }
    }
    public class UnloadWashingWeightment
    {
        private string m_saudaNo;

        private string m_batchParent;

        private string m_lotWiseBatch;

        private string m_noOfCrates;

        private string m_crateWt;

        private string m_grossWeight;

        private string m_totalRmWeight;

        private string m_status;

        private string m_dateTime;

        private string m_createdBy;

        private string m_createdDate;

        public string totalRmWeight
        {
            get
            {
                return m_totalRmWeight;
            }
            set
            {
                m_totalRmWeight = value;
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

        public string crateWt
        {
            get
            {
                return m_crateWt;
            }
            set
            {
                m_crateWt = value;
            }
        }

        public string grossWeight
        {
            get
            {
                return m_grossWeight;
            }
            set
            {
                m_grossWeight = value;
            }
        }

        public string lotWiseBatch
        {
            get
            {
                return m_lotWiseBatch;
            }
            set
            {
                m_lotWiseBatch = value;
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