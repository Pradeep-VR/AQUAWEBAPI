

namespace AQUAWEBAPI
{
    public class PeelingYield
    {
        private string m_grade;
        private string m_productType;
        private string m_yieldPercentage;


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

        public string yieldPercentage
        {
            get
            {
                return m_yieldPercentage;
            }
            set
            {
                m_yieldPercentage = value;
            }
        }
    }
}