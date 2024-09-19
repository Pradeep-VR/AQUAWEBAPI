// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.Grading
namespace AQUAWEBAPI
{
    public class Grading
    {
        private string m_batchNumber = null;

        //private string m_batchLotNumber = null;

        private string m_gradingDateTime = null;

        private string m_inFeedHeadOnWeight = null;

        private string m_inFeedCount = null;

        private string m_recMaterialTemp = null;

        private string m_gradingStartTime = null;

        private string m_gradingEndTime = null;

        private string m_overallBeheadingYield = null;

        private string m_remarks = null;

        private string m_monitoredBy = null;

        private string m_ApprovedBy = null;

        private string m_dateAndTime = null;
      

        public string batchNumber
        {
            get
            {
                return m_batchNumber;
            }
            set
            {
                m_batchNumber = value;
            }
        }
        
        //public string batchLotNumber
        //{
        //    get
        //    {
        //        return m_batchLotNumber;
        //    }
        //    set
        //    {
        //        m_batchLotNumber = value;
        //    }
        //}

        public string gradingDateTime
        {
            get
            {
                return m_gradingDateTime;
            }
            set
            {
                m_gradingDateTime = value;
            }
        }

        public string inFeedHeadOnWeight
        {
            get
            {
                return m_inFeedHeadOnWeight;
            }
            set
            {
                m_inFeedHeadOnWeight = value;
            }
        }

        public string inFeedCount
        {
            get
            {
                return m_inFeedCount;
            }
            set
            {
                m_inFeedCount = value;
            }
        }

        public string recMaterialTemp
        {
            get
            {
                return m_recMaterialTemp;
            }
            set
            {
                m_recMaterialTemp = value;
            }
        }

        public string gradingStartTime
        {
            get
            {
                return m_gradingStartTime;
            }
            set
            {
                m_gradingStartTime = value;
            }
        }

        public string gradingEndTime
        {
            get
            {
                return m_gradingEndTime;
            }
            set
            {
                m_gradingEndTime = value;
            }
        }

        public string overallBeheadingYield
        {
            get
            {
                return m_overallBeheadingYield;
            }
            set
            {
                m_overallBeheadingYield = value;
            }
        }

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

        public string ApprovedBy
        {
            get
            {
                return m_ApprovedBy;
            }
            set
            {
                m_ApprovedBy = value;
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