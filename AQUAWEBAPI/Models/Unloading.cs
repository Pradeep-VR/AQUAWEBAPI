// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.Unloading
namespace AQUAWEBAPI
{
    public class Unloading
    {
        private string m_saudaNumber = null;

        private string m_batchParent = null;

        private string m_crates = null;

        private string m_reachedDateTime = null;

        private string m_unloadDateTime = null;

        private string m_totalWeight = null;

        private string m_batchWiseLotNo = null;

        private string m_sealNo = null;

        private string m_receivedRmTemp = null;

        private string m_icCondition = null;

        private string m_nextProcess = null;

        private string m_purchaseDate = null;

        private string m_farmerName = null;

        private string m_purchaseType = null;

        private string m_driverName = null;

        private string m_vehicleNo = null;

        private string m_rmUnloadingStatus = null;

        private string m_rmDrainTimeCalculationStatus = null;

        private string m_rmWeighmentStatus = null;

        private string m_rmQualityStatus = null;

        private string m_rmNetSamplingStatus = null;

        private string m_rmBeheadingStatus = null;

        private string m_rmTableAllocationStatus = null;

        private string m_rmTableWiseStatus = null;

        private string m_createdBy = null;

        private string m_supplierName = null;

        private string m_purchaseCount = null;

        private string m_dateTime = null;

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

        public string batchParent
        {
            get
            {
                return m_batchParent;
            }
            set
            {
                m_batchParent = value;
            }
        }

        public string crates
        {
            get
            {
                return m_crates;
            }
            set
            {
                m_crates = value;
            }
        }

        public string reachedDateTime
        {
            get
            {
                return m_reachedDateTime;
            }
            set
            {
                m_reachedDateTime = value;
            }
        }

        public string unloadDateTime
        {
            get
            {
                return m_unloadDateTime;
            }
            set
            {
                m_unloadDateTime = value;
            }
        }

        public string totalWeight
        {
            get
            {
                return m_totalWeight;
            }
            set
            {
                m_totalWeight = value;
            }
        }

        public string batchWiseLotNo
        {
            get
            {
                return m_batchWiseLotNo;
            }
            set
            {
                m_batchWiseLotNo = value;
            }
        }

        public string sealNo
        {
            get
            {
                return m_sealNo;
            }
            set
            {
                m_sealNo = value;
            }
        }

        public string receivedRmTemp
        {
            get
            {
                return m_receivedRmTemp;
            }
            set
            {
                m_receivedRmTemp = value;
            }
        }

        public string icCondition
        {
            get
            {
                return m_icCondition;
            }
            set
            {
                m_icCondition = value;
            }
        }

        public string nextProcess
        {
            get
            {
                return m_nextProcess;
            }
            set
            {
                m_nextProcess = value;
            }
        }

        public string farmerName
        {
            get
            {
                return m_farmerName;
            }
            set
            {
                m_farmerName = value;
            }
        }

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

        public string purchaseDate
        {
            get
            {
                return m_purchaseDate;
            }
            set
            {
                m_purchaseDate = value;
            }
        }

        public string purchaseType
        {
            get
            {
                return m_purchaseType;
            }
            set
            {
                m_purchaseType = value;
            }
        }

        public string driverName
        {
            get
            {
                return m_driverName;
            }
            set
            {
                m_driverName = value;
            }
        }

        public string vehicleNo
        {
            get
            {
                return m_vehicleNo;
            }
            set
            {
                m_vehicleNo = value;
            }
        }

        public string purchaseCount
        {
            get
            {
                return m_purchaseCount;
            }
            set
            {
                m_purchaseCount = value;
            }
        }

        public string rmUnloadingStatus
        {
            get
            {
                return m_rmUnloadingStatus;
            }
            set
            {
                m_rmUnloadingStatus = value;
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

        public string rmDrainTimeCalculationStatus
        {
            get
            {
                return m_rmDrainTimeCalculationStatus;
            }
            set
            {
                m_rmDrainTimeCalculationStatus = value;
            }
        }

        public string rmWeighmentStatus
        {
            get
            {
                return m_rmWeighmentStatus;
            }
            set
            {
                m_rmWeighmentStatus = value;
            }
        }

        public string rmQualityStatus
        {
            get
            {
                return m_rmQualityStatus;
            }
            set
            {
                m_rmQualityStatus = value;
            }
        }

        public string rmNetSamplingStatus
        {
            get
            {
                return m_rmNetSamplingStatus;
            }
            set
            {
                m_rmNetSamplingStatus = value;
            }
        }

        public string rmBeheadingStatus
        {
            get
            {
                return m_rmBeheadingStatus;
            }
            set
            {
                m_rmBeheadingStatus = value;
            }
        }

        public string rmTableAllocationStatus
        {
            get
            {
                return m_rmTableAllocationStatus;
            }
            set
            {
                m_rmTableAllocationStatus = value;
            }
        }

        public string rmTableWiseStatus
        {
            get
            {
                return m_rmTableWiseStatus;
            }
            set
            {
                m_rmTableWiseStatus = value;
            }
        }

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
    }

    public class UnloadingNew
    {
        public string TransId { get; set; }
        public string saudaNumber { get; set; }
        public string batchParent { get; set; }
        public string crates { get; set; }
        public string reachedDateTime { get; set; }
        public string unloadDateTime { get; set; }
        public string totalWeight { get; set; }
        public string batchWiseLotNo { get; set; }
        public string sealNo { get; set; }
        public string receivedRmTemp { get; set; }
        public string icCondition { get; set; }
        public string nextProcess { get; set; }
        public string farmerName { get; set; }
        public string supplierName { get; set; }
        public string purchaseDate { get; set; }
        public string purchaseType { get; set; }
        public string driverName { get; set; }
        public string vehicleNo { get; set; }
        public string purchaseCount { get; set; }
        public string rmUnloadingStatus { get; set; }
        public string dateTime { get; set; }
        public string rmDrainTimeCalculationStatus { get; set; }
        public string rmWeighmentStatus { get; set; }
        public string rmQualityStatus { get; set; }
        public string rmNetSamplingStatus { get; set; }
        public string rmBeheadingStatus { get; set; }
        public string rmTableAllocationStatus { get; set; }
        public string rmTableWiseStatus { get; set; }
        public string createdBy { get; set; }
    }
}