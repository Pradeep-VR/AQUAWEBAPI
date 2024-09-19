// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.BeHeadingTableWise
namespace AQUAWEBAPI
{
    public class BeHeadingTableWiseNew
    {
        public string TransId { get; set; }
        public string batchParent { get; set; }
        public string batchNumber { get; set; }
        public string tableNumber { get; set; }
        public string totalNoOfPieces { get; set; }
        public string noOfCuttingPieces { get; set; }
        public string noOfBlackMeatPieces { get; set; }
        public string cuttingPercentage { get; set; }
        public string blackMeatPercentage { get; set; }
        public string datetime { get; set; }
    }
    public class BeHeadingTableWise
    {
        private string m_batchNumber = "";

        private string m_batchLotNumber = "";

        private string m_tableNumber = "";

        private string m_totalNoOfPieces = "";

        private string m_noOfCuttingPieces = "";

        private string m_noOfBlackMeatPieces = "";

        private string m_cuttingPercentage = "";

        private string m_blackMeatPercentage = "";

        private string m_dateTime = "";

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

        public string totalNoOfPieces
        {
            get
            {
                return m_totalNoOfPieces;
            }
            set
            {
                m_totalNoOfPieces = value;
            }
        }

        public string noOfCuttingPieces
        {
            get
            {
                return m_noOfCuttingPieces;
            }
            set
            {
                m_noOfCuttingPieces = value;
            }
        }

        public string noOfBlackMeatPieces
        {
            get
            {
                return m_noOfBlackMeatPieces;
            }
            set
            {
                m_noOfBlackMeatPieces = value;
            }
        }

        public string cuttingPercentage
        {
            get
            {
                return m_cuttingPercentage;
            }
            set
            {
                m_cuttingPercentage = value;
            }
        }

        public string blackMeatPercentage
        {
            get
            {
                return m_blackMeatPercentage;
            }
            set
            {
                m_blackMeatPercentage = value;
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