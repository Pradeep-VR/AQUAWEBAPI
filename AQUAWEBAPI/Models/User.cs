// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.User
namespace AQUAWEBAPI
{
    public class User
    {
        private string m_userName = "";

        private string m_password = "";

        private string m_password1 = "";

        private string m_password2 = "";

        private string m_password3 = "";

        private string m_password4 = "";

        private string m_deviceID = "";

        private string m_userType = null;

        private string m_expiryDate = null;

        private string m_lastLoggedIn = null;

        private string m_updatedBy = "";

        private string m_updatedDate = "";

        public string updatedBy
        {
            get
            {
                return m_updatedBy;
            }
            set
            {
                m_updatedBy = value;
            }
        }

        public string updatedDate
        {
            get
            {
                return m_updatedDate;
            }
            set
            {
                m_updatedDate = value;
            }
        }

        public string password1
        {
            get
            {
                return m_password1;
            }
            set
            {
                m_password1 = value;
            }
        }

        public string password2
        {
            get
            {
                return m_password2;
            }
            set
            {
                m_password2 = value;
            }
        }

        public string password3
        {
            get
            {
                return m_password3;
            }
            set
            {
                m_password3 = value;
            }
        }

        public string password4
        {
            get
            {
                return m_password4;
            }
            set
            {
                m_password4 = value;
            }
        }

        public string deviceID
        {
            get
            {
                return m_deviceID;
            }
            set
            {
                m_deviceID = value;
            }
        }

        public string expiryDate
        {
            get
            {
                return m_expiryDate;
            }
            set
            {
                m_expiryDate = value;
            }
        }

        public string lastLoggedIn
        {
            get
            {
                return m_lastLoggedIn;
            }
            set
            {
                m_lastLoggedIn = value;
            }
        }

        public string userName
        {
            get
            {
                return m_userName;
            }
            set
            {
                m_userName = value;
            }
        }

        public string password
        {
            get
            {
                return m_password;
            }
            set
            {
                m_password = value;
            }
        }

        public string userType
        {
            get
            {
                return m_userType;
            }
            set
            {
                m_userType = value;
            }
        }
    }

}