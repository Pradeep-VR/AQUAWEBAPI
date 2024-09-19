// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.BeHeadingTableAllocation
namespace AQUAWEBAPI
{
    public class BeHeadingTableAllocationNew
    {
        public string TransId { get; set; }
        public string batchParent { get; set; }
        public string batchNumber { get; set; }
        public string tableNumber { get; set; }
        public string totalNoOfCrates { get; set; }
        public string noOfCratesAllocated { get; set; }
        public string cratesRemaining { get; set; }
        public string dateTime { get; set; }
    }
    public class BeHeadingTableAllocation
    {
        private string m_batchParent = "";

        private string m_batchNumber = "";

        private string m_tableNumber = "";

        private string m_totalNoOfCrates = "";

        private string m_noOfCratesAllocated = "";

        private string m_cratesRemaining = "";

        private string m_dateTime = "";

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

        public string tableNumber
        {
            get
            {
                return m_tableNumber;
            }
            set
            {
                m_tableNumber = value;
            }
        }

        public string totalNoOfCrates
        {
            get
            {
                return m_totalNoOfCrates;
            }
            set
            {
                m_totalNoOfCrates = value;
            }
        }

        public string noOfCratesAllocated
        {
            get
            {
                return m_noOfCratesAllocated;
            }
            set
            {
                m_noOfCratesAllocated = value;
            }
        }

        public string cratesRemaining
        {
            get
            {
                return m_cratesRemaining;
            }
            set
            {
                m_cratesRemaining = value;
            }
        }

        public string datetime
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
    }
}