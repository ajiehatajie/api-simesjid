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

namespace ICN.Core.Setting
{
    public class DisplaySetting : BaseDatabase, IMaster<SettingModel>, ILookUp
    {
        public UserModel objUser;

        public SettingModel MasterData
        {
            get;
            set;
        }
        public string Query
        {
            get;
            set;
        }
        public DisplaySetting()
        {
            MasterData = new SettingModel();
        }

        public object Display()
        {
            try
            {
                using (var Cn = OpenDB())
                {
                  
                    return  Cn.Query<SettingModel>(DbQuery.SettingGetAll, new { userId = objUser.user_id }).ToList();

                }
            }
            catch (DatabaseException ex)
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
                
                    return Cn.Query<SettingModel>(DbQuery.SettingSearchByMosque, new { account_userid = objUser.user_id, cari = strSearch }).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
