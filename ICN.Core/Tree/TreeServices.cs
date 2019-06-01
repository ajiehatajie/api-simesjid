using ICN.Base;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICN.Core.Tree
{
    public class TreeServices : BaseDatabase, IBusiness<TreeModel>
    {
        public Task<int> Add(TreeModel data)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(string data)
        {
            throw new NotImplementedException();
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
