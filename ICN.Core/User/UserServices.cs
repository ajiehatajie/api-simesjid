using Dapper;
using ICN.Base;
using ICN.Core.Account;
using ICN.Core.Properties;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICN.Core.User
{
    public class UserServices : BaseDatabase, IBusiness<UserModel>
    {
        public UserModel objUser = null;
      

        #region "CRUD"


        public async Task<int> Add(UserModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                    var guid = Guid.NewGuid().ToString();
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(data.user_password);

                    return await x.ExecuteAsync(DbQuery.UserNew, new { id = guid,
                        name = data.user_name, email = data.user_email,
                        password = hashedPassword, lastname = data.user_lastname,
                        parent = data.user_parentid    
                    });
                   
                    

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
                   
                    return await x.ExecuteAsync(DbQuery.UserDelete, new { id =  objUser.user_id });

                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<int> Update(UserModel data,string id)
        {
            try
            {
                using (var x = OpenDB())
                {
                   
                    

                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(data.user_password);

                    return await x.ExecuteAsync(DbQuery.UserUpdate, new { name=data.user_name,email=data.user_email,
                        password = hashedPassword,
                        lastname = data.user_lastname,
                        userid = objUser.user_id });


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

     
        public PagedList<UserModel> GetAll(PagingParams pagingParams)
        {
            DisplayUser displayUser  =  new DisplayUser();
            displayUser.objUser = this.objUser;
            var query = new List<UserModel>((List<UserModel>)displayUser.Display()).AsQueryable();
            var filter = query.Where(p => p.user_name.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<UserModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);

        }
    }
}
