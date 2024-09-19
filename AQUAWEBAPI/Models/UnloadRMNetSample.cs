// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.UnloadRMNetSample

namespace AQUAWEBAPI
{
    public class UnloadRMNetSampleNew
    {
        public string TransId { get; set; }
        public string createdBy { get; set; }
        public string noOfNets { get; set; }
        public string tareWtPerNet { get; set; }
        public string grossWeight { get; set; }
        public string totalWeight { get; set; }
        public string batchparent { get; set; }
        public string lotWiseBatch { get; set; }
        public string saudaNumber { get; set; }
        public string sampleWeight { get; set; }
        public string noOfnormalpieces { get; set; }
        public string noOfSmallPieces { get; set; }
        public string noOfSmallPiecesAccAsOne { get; set; }
        public string totalNoOfpieces { get; set; }
        public string plantCount { get; set; }
        public string weightDifference { get; set; }
        public string countDifference { get; set; }
        public string dateTime { get; set; }
    }
    public class UnloadRMNetSample
    {
        private string m_saudaNumber = null;

        private string m_noOfNets = null;

        private string m_tareWtPerNet = null;

        private string m_grossWeight = null;

        private string m_totalWeight = null;

        private string m_lotWiseBatch = null;

        private string m_batchparent = null;

        private string m_sampleWeight = null;

        private string m_noOfnormalpieces = null;

        private string m_noOfSmallPieces = null;

        private string m_noOfSmallPiecesAccAsOne = null;

        private string m_totalNoOfpieces = null;

        private string m_plantCount = null;

        private string m_weightDifference = null;

        private string m_countDifference = null;

        private string m_dateTime = null;

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

        public string noOfNets
        {
            get
            {
                return m_noOfNets;
            }
            set
            {
                m_noOfNets = value;
            }
        }

        public string tareWtPerNet
        {
            get
            {
                return m_tareWtPerNet;
            }
            set
            {
                m_tareWtPerNet = value;
            }
        }

        public string grossWeight
        {
            get
            {
                return m_grossWeight;
            }
            set
            {
                m_grossWeight = value;
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

        public string lotWiseBatch
        {
            get
            {
                return m_lotWiseBatch;
            }
            set
            {
                m_lotWiseBatch = value;
            }
        }

        public string batchparent
        {
            get
            {
                return m_batchparent;
            }
            set
            {
                m_batchparent = value;
            }
        }

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

        public string sampleWeight
        {
            get
            {
                return m_sampleWeight;
            }
            set
            {
                m_sampleWeight = value;
            }
        }

        public string noOfnormalpieces
        {
            get
            {
                return m_noOfnormalpieces;
            }
            set
            {
                m_noOfnormalpieces = value;
            }
        }

        public string noOfSmallPieces
        {
            get
            {
                return m_noOfSmallPieces;
            }
            set
            {
                m_noOfSmallPieces = value;
            }
        }

        public string noOfSmallPiecesAccAsOne
        {
            get
            {
                return m_noOfSmallPiecesAccAsOne;
            }
            set
            {
                m_noOfSmallPiecesAccAsOne = value;
            }
        }

        public string totalNoOfpieces
        {
            get
            {
                return m_totalNoOfpieces;
            }
            set
            {
                m_totalNoOfpieces = value;
            }
        }

        public string plantCount
        {
            get
            {
                return m_plantCount;
            }
            set
            {
                m_plantCount = value;
            }
        }

        public string weightDifference
        {
            get
            {
                return m_weightDifference;
            }
            set
            {
                m_weightDifference = value;
            }
        }

        public string countDifference
        {
            get
            {
                return m_countDifference;
            }
            set
            {
                m_countDifference = value;
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
    }
}