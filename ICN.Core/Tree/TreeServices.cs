using ICN.Base;
using ICN.Core.Properties;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace ICN.Core.Tree
{
    public class TreeServices : BaseDatabase, IBusiness<TreeModel>
    {
        public UserModel objUser = null;

        public async Task<int> Add(TreeModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                    var guid = Guid.NewGuid().ToString();
                   
                    return await x.ExecuteAsync(DbQuery.TreeNew, new
                    {
                        id = guid,
                        userid = data.tree_userid,
                        job = data.tree_jobposition,
                        parent = data.tree_parentid,
                        setting = objUser.setting_id,
                        created_by = objUser.user_id
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


                    return await x.ExecuteAsync(DbQuery.TreeDeleteById, new { id = data, settingid = objUser.setting_id });

                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PagedList<TreeModel> GetAll(PagingParams pagingParams)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(TreeModel data)
        {
            throw new NotImplementedException();
        }
    }
}
