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

namespace ICN.Core.Income
{
    public class IncomeServices : BaseDatabase, IBusiness<TransIncomeModel>
    {
        public UserModel objUser = null;
        

        #region "CRUD"
       
        public async Task<int> Add(TransIncomeModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                    

                    var guid = Guid.NewGuid().ToString();
                    return await x.ExecuteAsync(DbQuery.IncomeNew, new { id = guid,
                        name = data.income_name,amount = data.income_amount,
                        referency = data.income_ref,date = data.income_date,account = data.income_accountid,
                        category = data.income_categoryid, subcategory = data.income_subcategoryid,note= data.income_note,
                        picture = data.income_pictureid,userid = objUser.user_id,settingid = objUser.setting_id });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(string id)
        {
            try
            {
                using (var x = OpenDB())
                {
                    
                    return await x.ExecuteAsync(DbQuery.IncomeDelete, new { id = id, userid = objUser.user_id });


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(TransIncomeModel data,string id)
        {
            try
            {
                using (var x = OpenDB())
                {


                    return await x.ExecuteAsync(DbQuery.IncomeUpdate, new {
                        id = id,
                        name = data.income_name,
                        amount = data.income_amount,
                        referency = data.income_ref,
                        date = data.income_date,
                        account = data.income_accountid,
                        category = data.income_categoryid,
                        subcategory = data.income_subcategoryid,
                        note = data.income_note,
                        picture = data.income_pictureid,
                        updated=data.income_updated,
                        userid = objUser.user_id });

                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        public PagedList<TransIncomeModel> GetAll(PagingParams pagingParams)
        {
            DisplayIncome displayIncome = new DisplayIncome();
            displayIncome.objUser = this.objUser;
            var query = new List<TransIncomeModel>((List<TransIncomeModel>)displayIncome.Display()).AsQueryable();
            var filter = query.Where(p => p.income_name.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<TransIncomeModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);
        }
    }
}
