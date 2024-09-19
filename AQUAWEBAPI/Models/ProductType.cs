// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.ProductType
namespace AQUAWEBAPI
{
    public class ProductType
    {
        private string m_productTypeID = null;

        private string m_productTypeName = null;

        public string productTypeID
        {
            get
            {
                return m_productTypeID;
            }
            set
            {
                m_productTypeID = value;
            }
        }

        public string productTypeName
        {
            get
            {
                return m_productTypeName;
            }
            set
            {
                m_productTypeName = value;
            }
        }
    }
}