using Dapper;
using ICN.Base;
using ICN.Core.Properties;
using ICN.Interface;
using ICN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICN.Core.Roles
{
    public class DisplayRoles : BaseDatabase, IMaster<RoleModel>, ILookUp
    {
        public UserModel objUser;
        public RoleModel MasterData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Query { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Display()
        {
            try
            {
                using (var Cn = OpenDB())
                {
                    return Cn.Query<RoleModel>(DbQuery.RoleGetAll).ToList();

                }
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
                    return Cn.Query<RoleModel>(DbQuery.RoleUserSearchById, new { userid = objUser.user_id, cari = strSearch }).ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
