using ICN.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Security.Interface
{
    public interface IUserCheck
    {
        bool IsValidUser(string email, string password);

      
    }
}
