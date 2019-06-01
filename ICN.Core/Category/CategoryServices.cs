using Dapper;
using ICN.Base;
using ICN.Core.Account;
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
        private string SQL;

        #region "CRUD"

       
        public async Task<int> Add(CategoryModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                    SQL = "insert into mst_categories (category_id,category_name,category_desc,category_type,category_color,category_userid) values (?id,?name,?desc,?type,?color,?user)";
                    var guid = Guid.NewGuid().ToString();
                    return await x.ExecuteAsync(SQL, new {
                        id = guid, name = data.category_name, desc = data.category_desc,
                        type = data.category_type, color= data.category_color, user = objUser.user_id });

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
                    SQL = "delete from mst_categories where category_id = ?id and category_userid =?userid ";

                    var result = await x.ExecuteAsync(SQL, new { id = data, userid = objUser.user_id });

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public async Task<int> Update(CategoryModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                    
                    SQL = "update from mst_categories set category_name=?name,category_desc=?desc,category_type=?type where account_id = ?id  and category_userid =?userid";

                    var result = await x.ExecuteAsync(SQL, new { id = data.category_id,name = data.category_name,type = data.category_type, categor_userid = objUser.user_id });

                    return result;

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
                    SQL = "insert into mst_categories (category_id,category_name,category_desc,category_type,category_color,category_parentid,category_userid) values (?id,?name,?desc,?type,?color,?parent,?user)";
                    var guid = Guid.NewGuid().ToString();
                    return await x.ExecuteAsync(SQL, new { id = guid,
                        name = data.category_name,
                        desc = data.category_desc, type = data.category_type,
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
                 filter = query.Where(p => p.category_type.StartsWith(pagingParams.Query ?? string.Empty, StringComparison.InvariantCultureIgnoreCase));
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
    }
}
