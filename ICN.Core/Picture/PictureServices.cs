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

namespace ICN.Core.Picture
{
    public class PictureServices : BaseDatabase, IBusiness<PictureModel>
    {
        public UserModel objUser = null;
      

        #region "CRUD"

        public async Task<int> Add(PictureModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                   
                    var guid = Guid.NewGuid().ToString();
                    return await x.ExecuteAsync(DbQuery.PictureNew, new
                    {
                        id = guid,
                        name = data.picture_filename,
                        path = data.picture_path,
                        userid = objUser.user_id
                    });

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


                    return await x.ExecuteAsync(DbQuery.PictureDelete, new { id = id, userid = objUser.user_id });

                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(PictureModel data,string id)
        {
            try
            {
                using (var x = OpenDB())
                {
                  
                   
                    return await x.ExecuteAsync(DbQuery.PictureUpdate, new
                    {
                        id = id,
                        name = data.picture_filename,
                        path = data.picture_path,
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

        public PagedList<PictureModel> GetAll(PagingParams pagingParams)
        {
            DisplayPicture displayPicture  = new DisplayPicture();
            displayPicture.objUser = this.objUser;
            var query = new List<PictureModel>((List<PictureModel>)displayPicture.Display()).AsQueryable();
            var filter = query.Where(p => p.picture_filename.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<PictureModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);
        }
    }
}
