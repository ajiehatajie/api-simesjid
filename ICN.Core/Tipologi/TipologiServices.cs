using ICN.Base;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICN.Core.Tipologi
{
    public class TipologiServices : BaseDatabase, IBusiness<MosqueCategoryModel>
    {
        public Task<int> Add(MosqueCategoryModel data)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(string id)
        {
            throw new NotImplementedException();
        }

        

        public Task<int> Update(MosqueCategoryModel data, string id)
        {
            throw new NotImplementedException();
        }

        public PagedList<MosqueCategoryModel> GetAll(PagingParams pagingParams)
        {
            DisplayTipologi  displayTipologi = new DisplayTipologi();

            var query = new List<MosqueCategoryModel>((List<MosqueCategoryModel>)displayTipologi.Display()).AsQueryable();
            var filter = query.Where(p => p.category_name.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<MosqueCategoryModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);
        }
    }
}
