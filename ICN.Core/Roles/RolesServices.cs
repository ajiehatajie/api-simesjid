using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ICN.Base;
using ICN.Core.Properties;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;

namespace ICN.Core.Roles
{
    public class RolesServices : BaseDatabase, IBusiness<RoleModel>
    {
        public UserModel objUser;

        public  Task<int> Add(RoleModel data)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(string id)
        {
            try
            {
                using (var x = OpenDB())
                {
                   
                    string[] pecah = id.Split('*');
                    var res = 0;
                   
                  
                    if(pecah.Count() > 1)
                    {
                        foreach (var item in pecah)
                        {
                           
                            res =  await x.ExecuteAsync(DbQuery.RolesDeleteByUseridAndRoleID, new { item = item, userid = objUser.user_id });
                        }
                    }
                    else
                    {
                          
                            res =  await x.ExecuteAsync(DbQuery.RolesDeleteByUseridAndRoleID, new { item = id, userid = objUser.user_id });
                    }
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public async Task<int> Update(RoleModel data,string id )
        {
            try
            {
                using (var x = OpenDB())
                {

                    string[] pecah = id.Split('*');
                    var res = 0;

                    await x.ExecuteAsync(DbQuery.RolesDeleteByUser, new { userid = objUser.user_id });

                    if (pecah.Count() > 1)
                    {
                        foreach (var item in pecah)
                        {

                            res = await x.ExecuteAsync(DbQuery.RolesNewByUser, new { roleid = item, userid = objUser.user_id });
                        }
                    }
                    else
                    {

                        res = await x.ExecuteAsync(DbQuery.RolesNewByUser, new { roleid = id, userid = objUser.user_id });
                    }

                  
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateRoles(string id)
        {
            try
            {
                using (var x = OpenDB())
                {

                    string[] pecah = id.Split('*');
                    var res = 0;

                    await x.ExecuteAsync(DbQuery.RolesDeleteByUser, new { userid = objUser.user_id });

                    if (pecah.Count() > 1)
                    {
                        foreach (var item in pecah)
                        {

                            res = await x.ExecuteAsync(DbQuery.RolesNewByUser, new { roleid = item, userid = objUser.user_id });
                        }
                    }
                    else
                    {

                        res = await x.ExecuteAsync(DbQuery.RolesNewByUser, new { roleid = id, userid = objUser.user_id });
                    }


                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PagedList<RoleModel> GetAll(PagingParams pagingParams)
        {
            DisplayRoles displayRoles = new DisplayRoles();
            displayRoles.objUser = this.objUser;
            var query = new List<RoleModel>((List<RoleModel>)displayRoles.Display()).AsQueryable();
            var filter = query.Where(p => p.role_name.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<RoleModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);
        }

    }
}
