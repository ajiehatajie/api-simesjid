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

namespace ICN.Core.Setting
{
    public class SettingServices : BaseDatabase, IBusiness<SettingModel>
    {
        public UserModel objUser = null;
       

        #region "CRUD"

        public async Task<int> Add(SettingModel data)
        {
            try
            {
                using (var x = OpenDB())
                {
                    

                    var guid = Guid.NewGuid().ToString();
                    return await x.ExecuteAsync(DbQuery.SettingNew, new
                    {
                        id = guid,
                        name = data.setting_mosque_name,
                        country = data.setting_countries,
                        city = data.setting_city,
                        web = data.setting_web,
                        phone = data.setting_phone,
                        email = data.setting_mosque_email,
                        currency = data.setting_currency,
                        address = data.setting_address,
                        languange = data.setting_languange,
                        logo = data.setting_logo,
                        userid = objUser.user_id
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

                    return await x.ExecuteAsync(DbQuery.SettingDelete, new { id = data, userid = objUser.user_id });


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(SettingModel data,string id)
        {
            try
            {
                using (var x = OpenDB())
                {


                    return await x.ExecuteAsync(DbQuery.SettingUpdate, new
                    {
                        id = data.setting_id,
                        name = data.setting_mosque_name,
                        country = data.setting_countries,
                        city = data.setting_city,
                        web = data.setting_web,
                        phone = data.setting_phone,
                        email = data.setting_mosque_email,
                        currency = data.setting_currency,
                        address = data.setting_address,
                        languange = data.setting_languange,
                        logo = data.setting_logo,
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


        public PagedList<SettingModel> GetAll(PagingParams pagingParams)
        {
            DisplaySetting displaySetting  = new DisplaySetting();
            displaySetting.objUser = this.objUser;
            var query = new List<SettingModel>((List<SettingModel>)displaySetting.Display()).AsQueryable();
            var filter = query.Where(p => p.setting_mosque_name.StartsWith(pagingParams.Query ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));
            return new PagedList<SettingModel>(filter, pagingParams.PageNumber, pagingParams.PageSize);
        }
    }
}
