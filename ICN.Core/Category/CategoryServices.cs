using Dapper;
using ICN.Base;
using ICN.Core.Account;
using ICN.Core.Properties;
using ICN.Generic;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICN.Core.Category
{
    public class CategoryServices : BaseDatabase, IBusiness<CategoryModel>
    {
        public UserModel objUser = null;
       

        #region "CRUD"

       
        public async Task<int> Add(CategoryModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                    var guid = Guid.NewGuid().ToString();
                    string SettingID = GlobalFunction.RandomIDSetting();

                    return await x.ExecuteAsync(DbQuery.CategoryNew, new {
                        id = guid, name = data.category_name, desc = data.category_desc,
                        settingid = SettingID,
                        color= data.category_color, user = objUser.user_id });

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

                    return await x.ExecuteAsync(DbQuery.CategoryDeleteById, new { id = id, userid = objUser.user_id });

                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public async Task<int> Update(CategoryModel data,string id)
        {
            try
            {
                using (var x = OpenDB())
                {


                    return await x.ExecuteAsync(DbQuery.CategoryUpdate, new { id = id,name = data.category_name, categor_userid = objUser.user_id });

                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddSubCategory(CategoryModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                    var guid = Guid.NewGuid().ToString();
                    string SettingID = GlobalFunction.RandomIDSetting();
                    return await x.ExecuteAsync(DbQuery.SubCategoryAdd, new { id = guid,
                        name = data.category_name,
                        desc = data.category_desc, settingid = data.category_settingid,
                        color = data.category_color,parent=data.category_parentid, user = objUser.user_id });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public PagedList<CategoryModel> GetAll(PagingParams pagingParams)
        {
            DisplayCategory category = new DisplayCategory();
            category.objUser = this.objUser;
            var query = new List<CategoryModel>((List<CategoryModel>)category.Display()).AsQueryable();
            IQueryable<CategoryModel> filter;

         
            if (pagingParams.Term.ToUpper()  == "TYPE")
            {
                 filter = query.Where(p => p.category_name.StartsWith(pagingParams.Query ?? string.Empty, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                 filter = query.Where(p => p.category_name.StartsWith(pagingParams.Query ?? string.Empty, StringComparison.InvariantCultureIgnoreCase));

            }

            return new PagedList<CategoryModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);

        }

        #region "sub categories"
        public PagedList<CategoryModel> GetAllSubCategories(PagingParams pagingParams,string id)
        {
            DisplayCategory category = new DisplayCategory();
            category.objUser = this.objUser;
            var query = new List<CategoryModel>((List<CategoryModel>)category.DisplaySubCategory(id)).AsQueryable();
            IQueryable<CategoryModel> filter;


            if (pagingParams.Term.ToUpper() == "TYPE")
            {
                filter = query.Where(p => p.category_type.StartsWith(pagingParams.Query ?? string.Empty, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                filter = query.Where(p => p.category_name.StartsWith(pagingParams.Query ?? string.Empty, StringComparison.InvariantCultureIgnoreCase));

            }

            return new PagedList<CategoryModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);

        }
        #endregion

        #region "sub categories"
        public PagedList<CategoryModel> GetAllCategoryParent(PagingParams pagingParams)
        {
            DisplayCategory category = new DisplayCategory();
            category.objUser = this.objUser;
            var query = new List<CategoryModel>((List<CategoryModel>)category.DisplayCategoryParent()).AsQueryable();
            IQueryable<CategoryModel> filter;

            filter = query.Where(p => p.category_name.StartsWith(pagingParams.Query ?? string.Empty, StringComparison.InvariantCultureIgnoreCase));
           
            return new PagedList<CategoryModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);

        }
        #endregion
    }
}
