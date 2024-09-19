// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.Peeling

namespace AQUAWEBAPI
{
    public class Peeling
    {
        private string m_barcodeId = null;

        private string m_syntaxTankNo = null;

        private string m_batchNo = null;

        private string m_grade = null;

        private string m_productType = null;

        private string m_targetGradingCount = null;

        private string m_hlQtyAfterGrading = null;

        private string m_nextProcess = null;

        private string m_changeInProductType = null;

        private string m_tableNoAllotedForPeeling = null;

        private string m_contractorSelection = null;

        private string m_peeledMaterialWeighted = null;

        private string m_qualityIssue = null;

        private string m_targetPeelingYield = null;

        private string m_actualPeelingYield = null;

        private string m_pdConvertToHlv = null;

        private string m_ppcHlvDiff = null;

        private string m_remarks = null;

        private string m_soakingProcess = null;

        private string m_dateAndTime = null;

        private string m_status = null;

        public string soakingProcess
        {
            get
            {
                return m_soakingProcess;
            }
            set
            {
                m_soakingProcess = value;
            }
        }

        public string barcodeId
        {
            get
            {
                return m_barcodeId;
            }
            set
            {
                m_barcodeId = value;
            }
        }

        public string syntaxTankNo
        {
            get
            {
                return m_syntaxTankNo;
            }
            set
            {
                m_syntaxTankNo = value;
            }
        }

        public string batchNo
        {
            get
            {
                return m_batchNo;
            }
            set
            {
                m_batchNo = value;
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

        public string productType
        {
            get
            {
                return m_productType;
            }
            set
            {
                m_productType = value;
            }
        }

        public string targetGradingCount
        {
            get
            {
                return m_targetGradingCount;
            }
            set
            {
                m_targetGradingCount = value;
            }
        }

        public string hlQtyAfterGrading
        {
            get
            {
                return m_hlQtyAfterGrading;
            }
            set
            {
                m_hlQtyAfterGrading = value;
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

        public string changeInProductType
        {
            get
            {
                return m_changeInProductType;
            }
            set
            {
                m_changeInProductType = value;
            }
        }

        public string tableNoAllotedForPeeling
        {
            get
            {
                return m_tableNoAllotedForPeeling;
            }
            set
            {
                m_tableNoAllotedForPeeling = value;
            }
        }

        public string contractorSelection
        {
            get
            {
                return m_contractorSelection;
            }
            set
            {
                m_contractorSelection = value;
            }
        }

        public string peeledMaterialWeighted
        {
            get
            {
                return m_peeledMaterialWeighted;
            }
            set
            {
                m_peeledMaterialWeighted = value;
            }
        }

        public string qualityIssue
        {
            get
            {
                return m_qualityIssue;
            }
            set
            {
                m_qualityIssue = value;
            }
        }

        public string targetPeelingYield
        {
            get
            {
                return m_targetPeelingYield;
            }
            set
            {
                m_targetPeelingYield = value;
            }
        }

        public string actualPeelingYield
        {
            get
            {
                return m_actualPeelingYield;
            }
            set
            {
                m_actualPeelingYield = value;
            }
        }

        public string pdConvertToHlv
        {
            get
            {
                return m_pdConvertToHlv;
            }
            set
            {
                m_pdConvertToHlv = value;
            }
        }

        public string ppcHlvDiff
        {
            get
            {
                return m_ppcHlvDiff;
            }
            set
            {
                m_ppcHlvDiff = value;
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

        public string status
        {
            get
            {
                return m_status;
            }
            set
            {
                m_status = value;
            }
        }
    }
}