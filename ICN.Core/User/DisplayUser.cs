using Dapper;
using ICN.Base;
using ICN.Core.Properties;
using ICN.Data;
using ICN.Interface;
using ICN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICN.Core.User
{
    public class DisplayUser : BaseDatabase, IMaster<UserModel>, ILookUp
    {
        public UserModel objUser;
        
        public UserModel MasterData
        {
            get;
            set;
        }
        public string Query
        {
            get;
            set;
        }
        public DisplayUser()
        {
            MasterData = new UserModel();
        }

        public object Display()
        {
            try
            {
                using (var Cn = OpenDB())
                {
                   
                    return Cn.Query<UserModel>(DbQuery.UserByUserId, new { userId = objUser.user_id }).ToList();

                }
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object DisplayAll()
        {
            try
            {
                using (var Cn = OpenDB())
                {
                    return Cn.Query<UserModel>(DbQuery.UserGetAll).ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object Search(string strSearch)
        {
            try
            {
                using (var Cn = OpenDB())
                {
                     return Cn.Query<UserModel>(DbQuery.UserSearchByName, new { account_userid = objUser.user_id, cari = strSearch }).ToList();
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
