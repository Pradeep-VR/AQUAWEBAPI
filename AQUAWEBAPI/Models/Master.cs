// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.Master
using System.Collections.Generic;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class Master
    {
        private List<SupplierMaster> m_supplier;

        private List<VillageMaster> m_village;

        private List<MandalMaster> m_mandal;

        private List<DistrictMaster> m_district;

        private List<RackMaster> m_rackMaster;

        private List<Grade> m_gradeMaster;

        private List<ProductType> m_productTypeMaster;

        private List<FinancialYearModel> m_financialyearmaster;

        public List<FinancialYearModel> FinancialYear
        {
            get
            {
                return m_financialyearmaster;
            }
            set
            {
                m_financialyearmaster = value;
            }
        }

        public List<ProductType> productTypeMaster
        {
            get
            {
                return m_productTypeMaster;
            }
            set
            {
                m_productTypeMaster = value;
            }
        }

        public List<Grade> gradeMaster
        {
            get
            {
                return m_gradeMaster;
            }
            set
            {
                m_gradeMaster = value;
            }
        }

        public List<RackMaster> rackMaster
        {
            get
            {
                return m_rackMaster;
            }
            set
            {
                m_rackMaster = value;
            }
        }

        public List<SupplierMaster> suppliers
        {
            get
            {
                return m_supplier;
            }
            set
            {
                m_supplier = value;
            }
        }

        public List<VillageMaster> villages
        {
            get
            {
                return m_village;
            }
            set
            {
                m_village = value;
            }
        }

        public List<MandalMaster> mandals
        {
            get
            {
                return m_mandal;
            }
            set
            {
                m_mandal = value;
            }
        }

        public List<DistrictMaster> districts
        {
            get
            {
                return m_district;
            }
            set
            {
                m_district = value;
            }
        }
    }
}