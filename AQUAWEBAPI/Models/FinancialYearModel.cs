using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AQUAWEBAPI.Models
{
    public class FinancialYearModel
    {
        private string m_CurrentYear = null;
        private string m_NextYear = null;
        private string m_FinancialYear = null;

        public string CurrentYear
        {
            get
            {
                return m_CurrentYear;
            }
            set
            {
                m_CurrentYear = value;
            }
        }

        public string NextYear
        {
            get
            {
                return m_NextYear;
            }
            set
            {
                m_NextYear = value;
            }
        }

        public string FinancialYear
        {
            get
            {
                return m_FinancialYear;
            }
            set
            {
                m_FinancialYear = value;
            }
        }
    }
}