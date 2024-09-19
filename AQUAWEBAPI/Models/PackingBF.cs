// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.PackingBF
using System;

namespace AQUAWEBAPI
{
    public class PackingBF
    {
        private string m_packID = null;

        private string m_buyerName = null;

        private string m_poNumber = null;

        private string m_cargoNumber = null;

        private string m_brand = null;

        private string m_packingStyle = null;

        private string m_packingType = null;

        private string m_glaze = null;

        private string m_unit = null;

        private string m_grade = null;

        private string m_variety = null;

        private string m_targetCount = null;

        private string m_orderQty = null;

        private string m_noOfSlabs = null;

        private string m_matchedFromOpen = null;

        private string m_noOfSlabsYesterday = null;

        private string m_noOfSlabsToday = null;

        private string m_balanceSlabs = null;

        private string m_balanceCartons = null;

        private string m_balanceQty = null;

        private string m_cartonPacked = null;

        private string m_cartonRepack = null;

        private string m_cartonBalRepack = null;

        private string m_chemicalTreatment = null;

        private string m_remarks = null;

        private string m_packingStatus = null;

        private string m_verifiedBy = null;

        //private string m_createdBy = null;
        //private string m_updatedBy = null;
        //private DateTime m_createdDate = DateTime.Now;
        //private DateTime m_updatedDate = DateTime.Now;
        //private bool m_deleteSts = false;

        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool DeleteStatus { get; set; }
        public string packID
        {
            get
            {
                return m_packID;
            }
            set
            {
                m_packID = value;
            }
        }

        public string buyerName
        {
            get
            {
                return m_buyerName;
            }
            set
            {
                m_buyerName = value;
            }
        }

        public string poNumber
        {
            get
            {
                return m_poNumber;
            }
            set
            {
                m_poNumber = value;
            }
        }

        public string cargoNumber
        {
            get
            {
                return m_cargoNumber;
            }
            set
            {
                m_cargoNumber = value;
            }
        }

        public string brand
        {
            get
            {
                return m_brand;
            }
            set
            {
                m_brand = value;
            }
        }

        public string packingStyle
        {
            get
            {
                return m_packingStyle;
            }
            set
            {
                m_packingStyle = value;
            }
        }

        public string packingType
        {
            get
            {
                return m_packingType;
            }
            set
            {
                m_packingType = value;
            }
        }

        public string glaze
        {
            get
            {
                return m_glaze;
            }
            set
            {
                m_glaze = value;
            }
        }

        public string unit
        {
            get
            {
                return m_unit;
            }
            set
            {
                m_unit = value;
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

        public string variety
        {
            get
            {
                return m_variety;
            }
            set
            {
                m_variety = value;
            }
        }

        public string targetCount
        {
            get
            {
                return m_targetCount;
            }
            set
            {
                m_targetCount = value;
            }
        }

        public string orderQty
        {
            get
            {
                return m_orderQty;
            }
            set
            {
                m_orderQty = value;
            }
        }

        public string noOfSlabs
        {
            get
            {
                return m_noOfSlabs;
            }
            set
            {
                m_noOfSlabs = value;
            }
        }

        public string matchedFromOpen
        {
            get
            {
                return m_matchedFromOpen;
            }
            set
            {
                m_matchedFromOpen = value;
            }
        }

        public string noOfSlabsYesterday
        {
            get
            {
                return m_noOfSlabsYesterday;
            }
            set
            {
                m_noOfSlabsYesterday = value;
            }
        }

        public string noOfSlabsToday
        {
            get
            {
                return m_noOfSlabsToday;
            }
            set
            {
                m_noOfSlabsToday = value;
            }
        }

        public string balanceSlabs
        {
            get
            {
                return m_balanceSlabs;
            }
            set
            {
                m_balanceSlabs = value;
            }
        }

        public string balanceCartons
        {
            get
            {
                return m_balanceCartons;
            }
            set
            {
                m_balanceCartons = value;
            }
        }

        public string balanceQty
        {
            get
            {
                return m_balanceQty;
            }
            set
            {
                m_balanceQty = value;
            }
        }

        public string cartonPacked
        {
            get
            {
                return m_cartonPacked;
            }
            set
            {
                m_cartonPacked = value;
            }
        }

        public string cartonRepack
        {
            get
            {
                return m_cartonRepack;
            }
            set
            {
                m_cartonRepack = value;
            }
        }

        public string cartonBalRepack
        {
            get
            {
                return m_cartonBalRepack;
            }
            set
            {
                m_cartonBalRepack = value;
            }
        }

        public string chemicalTreatment
        {
            get
            {
                return m_chemicalTreatment;
            }
            set
            {
                m_chemicalTreatment = value;
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

        public string packingStatus
        {
            get
            {
                return m_packingStatus;
            }
            set
            {
                m_packingStatus = value;
            }
        }

        public string verifiedBy
        {
            get
            {
                return m_verifiedBy;
            }
            set
            {
                m_verifiedBy = value;
            }
        }
    }
}