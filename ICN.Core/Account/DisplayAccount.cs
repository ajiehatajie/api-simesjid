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

namespace ICN.Core.Account
{
    public class DisplayAccount : BaseDatabase, IMaster<AccountModel>, ILookUp
    {
        public UserModel objUser;

      

        public AccountModel MasterData
        {
            get;
            set;
        }
        public string Query
        {
            get;
            set;
        }
        public DisplayAccount()
        {
            MasterData = new AccountModel();
        }

        public object Display()
        {
            try
            {
                using (var Cn = OpenDB())
                {


                    return Cn.Query<AccountModel>(DbQuery.AccountGetAll, new { userId = objUser.user_id }).ToList();

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

        public object Search(string strSearch)
        {
            try
            {
                using (var Cn = OpenDB())
                {
                   
                    return Cn.Query<CategoryModel>(DbQuery.AccountSearchByName, new { account_userid = objUser.user_id, cari = strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
