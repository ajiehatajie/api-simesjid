using Dapper;
using ICN.Base;
using ICN.Model;
using ICN.Security.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Security.Bus
{
    public class CheckUserRepository : BaseDatabase, IUserCheck
    {
        private string SQL;
        public bool IsValidUser(string email, string password)
        {
            try
            {
                using (var x = OpenDB())
                {
                    SQL = "select * from mst_users where user_email = ?email ";
                    var result = x.Query<UserModel>(SQL, new { email = email }).AsList();

                    if (result.Count > 0)
                    {
                        bool validPassword = BCrypt.Net.BCrypt.Verify(password, result[0].user_password);
                        return validPassword;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void InsertLogToken(string name, string refresh, string user)
        {
            try
            {
                using (var x = OpenDB())
                {
                    var guid = Guid.NewGuid().ToString();
                    SQL = "insert into log_tokens (token_id,token_name,token_userid,token_revoked,token_refresh) values(?id,?name,?user,?revoked,?refresh) ";
                    var result = x.Execute(SQL, new { id = guid, name = name, user = user, revoked = 0, refresh = refresh });

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void updateUserToken(string token, string userId)
        {
            try
            {
                using (var x = OpenDB())
                {
                    var guid = Guid.NewGuid().ToString();
                    SQL = "update mst_users set user_token=?token where user_id=?id";
                    var result = x.Execute(SQL, new { id = userId, token = token });

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool IsValidToken(string token)
        {
            try
            {
                using (var x = OpenDB())
                {
                    SQL = "select * from mst_users where user_token = ?token ";
                    var result = x.Query<UserModel>(SQL, new { token = token }).AsList();

                    if (result.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public object SearchTokenUser(string token)
        {
            try
            {
                using (var x = OpenDB())
                {
                    SQL = "select * from mst_users where user_token = ?token ";
                    var result = x.Query<UserModel>(SQL, new { token = token }).AsList();

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
