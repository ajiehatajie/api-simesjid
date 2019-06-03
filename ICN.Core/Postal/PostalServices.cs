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

namespace ICN.Core.Postal
{
    public class PostalServices : BaseDatabase, IBusiness<PostalModel>
    {
        public Task<int> Add(PostalModel data)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(string id)
        {
            throw new NotImplementedException();
        }

        

        public Task<int> Update(PostalModel data, string id)
        {
            throw new NotImplementedException();
        }

        public PagedList<PostalModel> GetAll(PagingParams pagingParams)
        {
            throw new NotImplementedException();
        }

        public PagedList<PostalModel> GetAllProvince(PagingParams pagingParams)
        {
            DisplayPostal displayPostal = new DisplayPostal();
            
            var query = new List<PostalModel>((List<PostalModel>)displayPostal.DisplayProvince()).AsQueryable();
            var filter = query.Where(p => p.province.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<PostalModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public PagedList<PostalModel> GetAllKabupaten(PagingParams pagingParams)
        {
            DisplayPostal displayPostal = new DisplayPostal();

            var query = new List<PostalModel>((List<PostalModel>)displayPostal.DisplayKabupaten()).AsQueryable();
            var filter = query.Where(p => p.kabupaten.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<PostalModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public PagedList<PostalModel> GetAllKecamatan(PagingParams pagingParams)
        {
            DisplayPostal displayPostal = new DisplayPostal();

            var query = new List<PostalModel>((List<PostalModel>)displayPostal.DisplayKecamatan()).AsQueryable();
            var filter = query.Where(p => p.kecamatan.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<PostalModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public PagedList<PostalModel> GetAllKelurahan(PagingParams pagingParams)
        {
            DisplayPostal displayPostal = new DisplayPostal();

            var query = new List<PostalModel>((List<PostalModel>)displayPostal.DisplayKelurahan()).AsQueryable();
            var filter = query.Where(p => p.kelurahan.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<PostalModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);
        }
    }
}
