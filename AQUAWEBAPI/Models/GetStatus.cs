using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AQUAWEBAPI.Models
{
    public class GetStatus
    {
        private bool m_status = false;

        public bool status
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