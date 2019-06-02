using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICN.Base;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;

namespace ICN.Core.Roles
{
    public class RolesServices : BaseDatabase, IBusiness<RoleModel>
    {
        public Task<int> Add(RoleModel data)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public PagedList<RoleModel> GetAll(PagingParams pagingParams)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(RoleModel data,string id )
        {
            throw new NotImplementedException();
        }
    }
}
