// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.PeelingGet

namespace AQUAWEBAPI
{
    public class PeelingGet
    {
        private string m_barcode = null;

        private string m_batchNo = null;

        private string m_grade = null;

        private string m_productType = null;

        private string m_targetFlatCount = null;

        private string m_weighment = null;

        private string m_dateAndTime = null;

        private string m_bsRatio = null;

        private string m_crate = null;

        //private string m_infeedHeadOnWeight = null;

        //private string m_inFeedCount = null;

        //private string m_overallBeHeadingYield = null;

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

        public string bsRatio
        {
            get
            {
                return m_bsRatio;
            }
            set
            {
                m_bsRatio = value;
            }
        }

        public string crate
        {
            get
            {
                return m_crate;
            }
            set
            {
                m_crate = value;
            }
        }

        //public string infeedHeadOnWeight
        //{
        //    get
        //    {
        //        return m_infeedHeadOnWeight;
        //    }
        //    set
        //    {
        //        m_infeedHeadOnWeight = value;
        //    }
        //}

        //public string inFeedCount
        //{
        //    get
        //    {
        //        return m_inFeedCount;
        //    }
        //    set
        //    {
        //        m_inFeedCount = value;
        //    }
        //}

        //public string overallBeHeadingYield
        //{
        //    get
        //    {
        //        return m_overallBeHeadingYield;
        //    }
        //    set
        //    {
        //        m_overallBeHeadingYield = value;
        //    }
        //}
    }
}