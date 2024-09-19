// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.UserController
using System;
using System.Collections.Generic;
using System.Web.Http;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class UserController : ApiController
    {
        Logger log = new Logger();
        UserManagement usrmgt = new UserManagement();

        [Route("api/User")]
        public List<User> GetUsers()
        {
            
            DateTime date_time = DateTime.Now;
            var log_txt = date_time.ToString() + " ::: " + "User Data get Call Success !!";
            log.writeLog(log_txt);

            return usrmgt.GetUserDetails();
        }

        [Route("api/UserChangePassword")]
        [HttpPost]
        public string PostUserPasswordChange([FromBody] Dictionary<string, List<User>> UserPasswordChange)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            try
            {                
                if (UserPasswordChange != null)
                {
                    foreach (KeyValuePair<string, List<User>> item in UserPasswordChange)
                    {
                        List<User> PassCh = item.Value;
                        foreach (User pc in PassCh)
                        {
                            b = usrmgt.InsertUserChangePassword(pc);
                            s = ((!(b == "Success")) ? b : " successfully");
                        }
                        
                    }
                }
                else
                {
                    s = "Error" + b;
                    
                }
                if(b == "successfully")
                {
                    var log_txt = DateTime.Now.ToString() + ":::" + "Password Successfully Changed..";
                    log.writeLog(log_txt);
                }
                else
                {
                    var log_txt = DateTime.Now.ToString() + ":::" + "Error in Password Change.." + s;
                    log.writeLog(log_txt);
                }
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_txt = DateTime.Now.ToString() + ":::" + s + ":::"+ "Password Changing Is Failed..";
                log.writeLog(log_txt);
            }
            return s;
        }
    }
}