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

namespace ICN.Core.Expense
{
    public class DisplayExpense : BaseDatabase, IMaster<TransExpenseModel>, ILookUp
    {
        public UserModel objUser;

        public TransExpenseModel MasterData
        {
            get;
            set;
        }
        public string Query
        {
            get;
            set;
        }

        public DisplayExpense()
        {
            MasterData = new TransExpenseModel();
        }

        public object Display()
        {
            try
            {
                using (var Cn = OpenDB())
                {

                    return Cn.Query<TransExpenseModel>(DbQuery.ExpenseGetAll, new { userId = objUser.user_id }).ToList();

                    
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
                   
                    return Cn.Query<TransExpenseModel>(DbQuery.ExpenseSearchByName, new { account_userid = objUser.user_id, cari = strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
