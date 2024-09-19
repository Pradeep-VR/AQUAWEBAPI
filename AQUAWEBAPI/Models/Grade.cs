// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.Grade
namespace AQUAWEBAPI
{
    public class Grade
    {
        private string m_gradeName;

        private string m_barcodeType;

        private string m_checkLength;

        public string gradeName
        {
            get
            {
                return m_gradeName;
            }
            set
            {
                m_gradeName = value;
            }
        }

        public string barcodeType
        {
            get
            {
                return m_barcodeType;
            }
            set
            {
                m_barcodeType = value;
            }
        }

        public string checkLength
        {
            get
            {
                return m_checkLength;
            }
            set
            {
                m_checkLength = value;
            }
        }
    }
}