using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Security
{
    public class UserSessionManager
    {
        public DisplayUserSecurity UserLog(string userId)
        {
            DisplayUserSecurity objUser = new DisplayUserSecurity();

            objUser._userInfo.user_id = userId;

            objUser.Display();

            return objUser;
        }

    }
}
