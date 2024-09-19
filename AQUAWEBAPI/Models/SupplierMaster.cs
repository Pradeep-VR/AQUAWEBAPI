// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.SupplierMaster
namespace AQUAWEBAPI
{
    public class SupplierMaster
    {
        private string m_supplierName = null;

        public string supplierName
        {
            get
            {
                return m_supplierName;
            }
            set
            {
                m_supplierName = value;
            }
        }
    }
}