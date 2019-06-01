using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using ICN.Base;
using ICN.Interface;
using ICN.Model;

namespace ICN.Security.Bus
{
    public class DisplayUserSecurityRepository : BaseDatabase, IMaster<UserModel>, ILookUp
    {
        public UserModel MasterData
        {
            get;
            set;
        }
        public string Query { get; set; }

        public object Display()
        {
            throw new NotImplementedException();
        }

        public object Search(string strSearch)
        {
            throw new NotImplementedException();
        }

        public UserModel SearchTopOne(string strSearch)
        {
            try
            {
                using (var x = OpenDB())
                {
                    Query = @"SELECT * FROM mst_users a
                                inner join mst_settings b on a.user_id=b.setting_created_by
                                WHERE a.user_id LIKE CONCAT('%',?id,'%')";

                    return x.Query<UserModel>(Query, new { id = strSearch }).SingleOrDefault();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserModel SearchTopOneByEmail(string strSearch)
        {
            try
            {
                using (var x = OpenDB())
                {
                    Query = "select * from mst_users where user_email LIKE CONCAT('%',?id,'%') ";
                    return x.Query<UserModel>(Query, new { id = strSearch }).SingleOrDefault();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserModel SearchTopOneByUsername(string strSearch)
        {
            try
            {
                using (var x = OpenDB())
                {
                    Query = "select * from mst_users where user_name LIKE CONCAT('%',?id,'%') ";
                    return x.Query<UserModel>(Query, new { id = strSearch }).SingleOrDefault();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object SearchUserWithSetting(string strSearch)
        {
            try
            {
                using (var x = OpenDB())
                {
                    Query = @"SELECT * FROM mst_users a INNER JOIN mst_settings b ON a.user_id=b.setting_created_by 
                            where  a.user_email LIKE CONCAT('%',?name,'%') ";
                    return x.Query<UserModel>(Query, new { name = strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object SearchRolesByUserId(string UserId)
        {
            try
            {
                using (var Cn = OpenDB())
                {
                    Query = @"SELECT * FROM vi_role_users where role_userid=?role_userid order by role_name asc";
                    return Cn.Query<RoleModel>(Query, new { role_userid = UserId }).ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
