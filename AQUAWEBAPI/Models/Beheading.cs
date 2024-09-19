// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.Beheading
namespace AQUAWEBAPI
{
    public class BeheadingNew
    {
        public string TransId { get; set; }
        public string createdBy { get; set; }
        public string batchParent { get; set; }
        public string batchNumber { get; set; }
        public string startDate { get; set; }
        public string purchaseType { get; set; }
        public string supplierName { get; set; }
        public string cratesAllocatedForBeheading { get; set; }
        public string materialTempBeforeBeheading { get; set; }
        public string materialTempDuringBeheading { get; set; }
        public string materialTempAfterBeheading { get; set; }
        public string headOnCountPerKg { get; set; }
        public string beheadingStartTime { get; set; }
        public string beheadingEndTime { get; set; }
        public string chillWaterTemperature { get; set; }
        public string calibration { get; set; }
        public string sampleHeadOnWeight { get; set; }
        public string sampleHeadlessWeight { get; set; }
        public string sampleBeheadingYieldPercentage { get; set; }
        public string weightOfBatchAfterBeheading { get; set; }
        public string remarks { get; set; }
        public string monitoredBy { get; set; }
        public string verifiedBy { get; set; }
        public string dateAndTime { get; set; }

    }
    public class Beheading
    {
        private string m_batchNumber = null;

        private string m_batchLotNumber = null;

        private string m_startDate = null;

        private string m_purchaseType = null;

        private string m_supplierName = null;

        private string m_cratesAllocatedForBeheading = null;

        private string m_materialTempBeforeBeheading = null;

        private string m_materialTempDuringBeheading = null;

        private string m_materialTempAfterBeheading = null;

        private string m_headOnCountPerKg = null;

        private string m_beheadingStartTime = null;

        private string m_beheadingEndTime = null;

        private string m_chillWaterTemperature = null;

        private string m_calibration = null;

        private string m_sampleHeadOnWeight = null;

        private string m_sampleHeadlessWeight = null;

        private string m_sampleBeheadingYieldPercentage = null;

        private string m_weightOfBatchAfterBeheading = null;               

        private string m_remarks = null;

        private string m_monitoredBy = null;

        private string m_verifiedBy = null;

        private string m_dateAndTime = null;

        private string m_createdBy = null;

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

        public string batchParent
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

        public string batchNumber
        {
            get
            {
                return m_batchLotNumber;
            }
            set
            {
                m_batchLotNumber = value;
            }
        }

        public string startDate
        {
            get
            {
                return m_startDate;
            }
            set
            {
                m_startDate = value;
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

        public string cratesAllocatedForBeheading
        {
            get
            {
                return m_cratesAllocatedForBeheading;
            }
            set
            {
                m_cratesAllocatedForBeheading = value;
            }
        }

        public string materialTempBeforeBeheading
        {
            get
            {
                return m_materialTempBeforeBeheading;
            }
            set
            {
                m_materialTempBeforeBeheading = value;
            }
        }

        public string materialTempDuringBeheading
        {
            get
            {
                return m_materialTempDuringBeheading;
            }
            set
            {
                m_materialTempDuringBeheading = value;
            }
        }

        public string materialTempAfterBeheading
        {
            get
            {
                return m_materialTempAfterBeheading;
            }
            set
            {
                m_materialTempAfterBeheading = value;
            }
        }

        public string headOnCountPerKg
        {
            get
            {
                return m_headOnCountPerKg;
            }
            set
            {
                m_headOnCountPerKg = value;
            }
        }

        public string beheadingStartTime
        {
            get
            {
                return m_beheadingStartTime;
            }
            set
            {
                m_beheadingStartTime = value;
            }
        }

        public string beheadingEndTime
        {
            get
            {
                return m_beheadingEndTime;
            }
            set
            {
                m_beheadingEndTime = value;
            }
        }

        public string chillWaterTemperature
        {
            get
            {
                return m_chillWaterTemperature;
            }
            set
            {
                m_chillWaterTemperature = value;
            }
        }

        public string calibration
        {
            get
            {
                return m_calibration;
            }
            set
            {
                m_calibration = value;
            }
        }

        public string sampleHeadOnWeight
        {
            get
            {
                return m_sampleHeadOnWeight;
            }
            set
            {
                m_sampleHeadOnWeight = value;
            }
        }

        public string sampleHeadlessWeight
        {
            get
            {
                return m_sampleHeadlessWeight;
            }
            set
            {
                m_sampleHeadlessWeight = value;
            }
        }

        public string sampleBeheadingYieldPercentage
        {
            get
            {
                return m_sampleBeheadingYieldPercentage;
            }
            set
            {
                m_sampleBeheadingYieldPercentage = value;
            }
        }

        public string weightOfBatchAfterBeheading
        {
            get
            {
                return m_weightOfBatchAfterBeheading;
            }
            set
            {
                m_weightOfBatchAfterBeheading = value;
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