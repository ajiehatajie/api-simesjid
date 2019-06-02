using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICN.Interface
{
    public interface IBusiness<T>
    {
        Task<int> Add(T data);

        Task<int> Delete(string id);

        Task<int> Update(T data,string id);

        PagedList<T> GetAll(PagingParams pagingParams);
    }
}
