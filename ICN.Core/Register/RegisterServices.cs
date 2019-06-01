﻿using Dapper;
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

namespace ICN.Core.Register
{
    public class RegisterServices : BaseDatabase, IBusiness<RegisterModel>
    {
        private string SQL;
        public async Task<int> Add(RegisterModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                 
                    var guid = Guid.NewGuid().ToString();
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(data.user_password);

                   
                    var res = await x.ExecuteAsync(DbQuery.RegisterNew, new {
                        id = guid, name = data.user_name,
                        email = data.user_email, password = hashedPassword });
                    await CreateSetting(guid, data.mosque_name);
                    await CreateRoles(guid);
                    return res;
                  

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task CreateSetting(string userId,string Mosque)
        {
            try
            {
                using (var x = OpenDB())
                {
                    var guid = Guid.NewGuid().ToString();
                   
                    await x.ExecuteAsync(DbQuery.RegisterNewSetting, new { id = guid, name=Mosque, userid = userId });
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task CreateRoles(string userId)
        {
            try
            {
                using (var x = OpenDB())
                {
                    var guid = Guid.NewGuid().ToString();

                    await x.ExecuteAsync(DbQuery.RolesInsertRegister, new { userid = userId });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<int> Delete(string data)
        {
            throw new NotImplementedException();
        }

        public PagedList<RegisterModel> GetAll(PagingParams pagingParams)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(RegisterModel data)
        {
            throw new NotImplementedException();
        }


    }
}
