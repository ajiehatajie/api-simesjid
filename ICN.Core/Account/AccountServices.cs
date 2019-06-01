using Dapper;
using ICN.Base;
using ICN.Core.Properties;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using ICN.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICN.Core.Account
{
    public class AccountServices : BaseDatabase, IBusiness<AccountModel>
    {
       
        public UserModel objUser = null;
        private string SQL;

        #region "CRUD"
        public async Task<int> Add(AccountModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                    var guid = Guid.NewGuid().ToString();

                    return await x.ExecuteAsync(DbQuery.AccountNew, new { id = guid, name = data.account_name,
                        balance = data.account_balance, desc = data.account_desc, user = objUser.user_id });

                   

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(string data)
        {
            try
            {
                using (var x = OpenDB())
                {

                    return await x.ExecuteAsync(DbQuery.AccountDelete, new { id = data, userid = objUser.user_id });


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(AccountModel data)
        {
            try
            {
                using (var x = OpenDB())
                {

                    return await x.ExecuteAsync(DbQuery.AccountUpdate, new { id = data.account_id,
                        name = data.account_name, balance = data.account_balance,
                        desc = data.account_desc, userid = objUser.user_id });

                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public PagedList<AccountModel> GetAll(PagingParams pagingParams)
        {
            DisplayAccount account = new DisplayAccount();
            account.objUser = this.objUser;
            var query = new List<AccountModel>((List<AccountModel>)account.Display()).AsQueryable();
            var filter = query.Where(p => p.account_name.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<AccountModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);

        }
    }
}
