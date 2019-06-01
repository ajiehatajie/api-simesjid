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

namespace ICN.Core.Income
{
    public class DisplayIncome : BaseDatabase, IMaster<TransIncomeModel>, ILookUp
    {
        public UserModel objUser;

        public TransIncomeModel MasterData
        {
            get;
            set;
        }
        public string Query
        {
            get;
            set;
        }
        public DisplayIncome()
        {
            MasterData = new TransIncomeModel();
        }

        public object Display()
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<TransIncomeModel>(DbQuery.IncomeGetAll, new { userId = objUser.user_id }).ToList();

                    
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
                   
                    return Cn.Query<TransIncomeModel>(DbQuery.IncomeSearchByName, new { account_userid = objUser.user_id, cari = strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
