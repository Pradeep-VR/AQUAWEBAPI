// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.UnloadWashingDrainTime
namespace AQUAWEBAPI
{
    public class UnloadWashingDrainTimeNew
    {
        public string TransId { get; set; }
        public string createdBy { get; set; }
        public string createdDate { get; set; }
        public string status { get; set; }
        public string saudaNumber { get; set; }
        public string lotWiseBatchNo { get; set; }
        public string noOfCrates { get; set; }
        public string washingStartTime { get; set; }
        public string washingEndTime { get; set; }
        public string weighmentStartTime { get; set; }
        public string weighmentEndTime { get; set; }
        public string drainedTime { get; set; }
        public string drainedTimeMillis { get; set; }
        public string dateTime { get; set; }

    }

    public class UnloadWashingDrainTime
    {
        private string m_saudaNumber = null;

        private string m_lotWiseBatchNo = null;

        private string m_noOfCrates = null;

        private string m_washingStartTime = null;

        private string m_washingEndTime = null;

        private string m_weighmentStartTime = null;

        private string m_weighmentEndTime = null;

        private string m_drainedTime = null;

        private string m_drainedTimeMillis = null;

        private string m_status;

        private string m_dateTime = null;

        private string m_createdBy = null;

        private string m_createdDate = null;

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

        public string lotWiseBatchNo
        {
            get
            {
                return m_lotWiseBatchNo;
            }
            set
            {
                m_lotWiseBatchNo = value;
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

        public string washingStartTime
        {
            get
            {
                return m_washingStartTime;
            }
            set
            {
                m_washingStartTime = value;
            }
        }

        public string washingEndTime
        {
            get
            {
                return m_washingEndTime;
            }
            set
            {
                m_washingEndTime = value;
            }
        }

        public string weighmentStartTime
        {
            get
            {
                return m_weighmentStartTime;
            }
            set
            {
                m_weighmentStartTime = value;
            }
        }

        public string weighmentEndTime
        {
            get
            {
                return m_weighmentEndTime;
            }
            set
            {
                m_weighmentEndTime = value;
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

        public string drainedTimeMillis
        {
            get
            {
                return m_drainedTimeMillis;
            }
            set
            {
                m_drainedTimeMillis = value;
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