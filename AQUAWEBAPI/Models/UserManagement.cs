// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.UserManagement
using System;
using System.Collections.Generic;
using System.Data;
using AQUA;

namespace AQUAWEBAPI
{
    public class UserManagement
    {
        Data Oldb = new Data();
        public List<User> GetUserDetails()
        {
            DataTable dt = new DataTable();
            int count = 0;
            User u = null;
            List<User> user = new List<User>();
            try
            {
                string strqry = "SELECT UserName, Password, UserType,convert(varchar(10),ExpiryDate,103) as ExpiryDate,LastLoggedIN, ";
                strqry += " Password1,Password2,Password3,Password4,DeviceID FROM  USERMASTER WHERE Flag =1";
                strqry += " and ProcessIn = 'Android' or ProcessIn = 'Both' ";
                dt = Oldb.GetDataTable(strqry);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        u = new User();
                        u.userName = dt.Rows[i]["UserName"].ToString();
                        u.password = dt.Rows[i]["Password"].ToString();
                        u.userType = dt.Rows[i]["UserType"].ToString();
                        u.expiryDate = dt.Rows[i]["ExpiryDate"].ToString();
                        u.lastLoggedIn = dt.Rows[i]["LastLoggedIN"].ToString();
                        u.password1 = dt.Rows[i]["Password1"].ToString();
                        u.password2 = dt.Rows[i]["Password2"].ToString();
                        u.password3 = dt.Rows[i]["Password3"].ToString();
                        u.password4 = dt.Rows[i]["Password4"].ToString();
                        u.deviceID = dt.Rows[i]["deviceID"].ToString();
                        user.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return user = null;
            }
            return user;
        }

        public string InsertUserChangePassword(User u)
        {
            bool b = false;
            string s = "";
            string s2 = "";
            DataTable dt = new DataTable();
            string strQry = "";
            string strPass2 = "";
            string strPass3 = "";
            string strPass4 = "";
            string strPass5 = "";
            string strPass = "";
            string strUserID = "";
            try
            {
                s2 = "select * from USERMASTER where username ='" + u.userName + "' ";
                dt = Oldb.GetDataTable(s2);
                if (dt.Rows.Count > 0)
                {
                    strPass = dt.Rows[0]["Password"].ToString();
                    strPass2 = dt.Rows[0]["Password1"].ToString();
                    strPass3 = dt.Rows[0]["Password2"].ToString();
                    strPass4 = dt.Rows[0]["Password3"].ToString();
                    strUserID = dt.Rows[0]["id"].ToString();
                    strPass5 = strPass4;
                    strPass4 = strPass3;
                    strPass3 = strPass2;
                    strPass2 = strPass;
                    strPass = u.password;
                    strQry = " UPDATE [USERMASTER] SET [Password] = '" + strPass + "' ,[UpdatedBy] = '" + strUserID + "' ";
                    strQry = strQry + " ,[UpdatedDate] = '" + u.updatedDate + "',[ExpiryDate] = DATEADD(MONTH, +3, getdate()) ";
                    strQry = strQry + " ,[LastLoggedIN] = getdate() ,[Password1] = '" + strPass2 + "',[Password2] = '" + strPass3 + "' ";
                    strQry = strQry + " ,[Password3] = '" + strPass4 + "' ,Password4= '" + strPass5 + "' ,[DeviceID] = '" + u.deviceID + "' ";
                    strQry = strQry + " where userName = '" + u.userName + "' ";
                    b = Oldb.ExecuteNonQuery(strQry);
                }
                s = ((!b) ? strQry : "Success");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return s;
        }
    }

}