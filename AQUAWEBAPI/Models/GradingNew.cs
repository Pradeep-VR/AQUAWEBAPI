// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.GradingNew
namespace AQUAWEBAPI
{
    public class GradingNew
    {
        private string m_batchNumber = "";

        //private string m_batchLotNumber = "";

        private string m_inFeedHeadOnWeight = "";

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
    }
}