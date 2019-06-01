using Dapper;
using ICN.Base;
using ICN.Core.Properties;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICN.Core.Expense
{
    public class ExpenseServices : BaseDatabase, IBusiness<TransExpenseModel>
    {

        public UserModel objUser = null;
       

        #region "CRUD"

        public async Task<int> Add(TransExpenseModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                    

                    var guid = Guid.NewGuid().ToString();
                    return await x.ExecuteAsync(DbQuery.ExpenseNew, new
                    {
                        id = guid,
                        name = data.expense_name,
                        amount = data.expense_amount,
                        referency = data.expense_ref,
                        date = data.expense_created,
                        account = data.expense_accountid,
                        category = data.expense_categoryid,
                        subcategory = data.expense_subcategoryid,
                        note = data.expense_note,
                        picture = data.expense_pictureid,
                        userid = objUser.user_id,
                        settingid = objUser.setting_id
                    });

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


                    return await x.ExecuteAsync(DbQuery.ExpenseDelete, new { id = data, userid = objUser.user_id });

                   

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(TransExpenseModel data)
        {
            try
            {
                using (var x = OpenDB())
                {

                 
                    return await x.ExecuteAsync(DbQuery.ExpenseUpdate, new
                    {
                        id = data.expense_id,
                        name = data.expense_name,
                        amount = data.expense_amount,
                        referency = data.expense_ref,
                        date = data.expense_created,
                        account = data.expense_accountid,
                        category = data.expense_categoryid,
                        subcategory = data.expense_subcategoryid,
                        note = data.expense_note,
                        picture = data.expense_pictureid,
                        updated = data.expense_updated,
                        userid = objUser.user_id
                    });

                  

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        public PagedList<TransExpenseModel> GetAll(PagingParams pagingParams)
        {
            DisplayExpense displayexpense = new DisplayExpense();
            displayexpense.objUser = this.objUser;
            var query = new List<TransExpenseModel>((List<TransExpenseModel>)displayexpense.Display()).AsQueryable();
            var filter = query.Where(p => p.expense_name.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<TransExpenseModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);
        }
    }
}
