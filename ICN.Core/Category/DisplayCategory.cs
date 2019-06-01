using Dapper;
using ICN.Base;
using ICN.Core.Properties;
using ICN.Data;
using ICN.Interface;
using ICN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICN.Core.Category
{
    public class DisplayCategory : BaseDatabase, IMaster<CategoryModel>, ILookUp 
    {
        public UserModel objUser;

       

        public CategoryModel MasterData
        {
            get;
            set;
        }
        public string Query
        {
            get;
            set;
        }
        public DisplayCategory()
        {
            MasterData = new CategoryModel();
        }

        public object Display()
        {
            try
            {
                using (var Cn = OpenDB())
                {
                    return Cn.Query<CategoryModel>(DbQuery.CategoryGetAll, new { userId = objUser.user_id }).ToList();

                }
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Search(string strSearch)
        {
            try
            {
                using (var Cn = OpenDB())
                {
                    return Cn.Query<CategoryModel>(DbQuery.CategorySearchByName, new { account_userid = objUser.user_id, cari = strSearch }).ToList();

                 }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object DisplayDetailCategory(string id)
        {
            try
            {
                using (var Cn = OpenDB())
                {
                    return Cn.Query<CategoryModel>(DbQuery.CategoryDetailByCategoryId, new { id = id, userId = objUser.user_id }).ToList();

                }
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object DisplaySubCategory(string parentid)
        {
            try
            {
                using (var Cn = OpenDB())
                {
                    return Cn.Query<CategoryModel>(DbQuery.SubCategoryGetAll, new { parent = parentid ,userId = objUser.user_id }).ToList();

                }
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object DisplayDetailSubCategory(string id)
        {
            try
            {
                using (var Cn = OpenDB())
                {
                   
                    return Cn.Query<CategoryModel>(DbQuery.SubCategoryDetail, new { id = id, userId = objUser.user_id }).ToList();

                }
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
