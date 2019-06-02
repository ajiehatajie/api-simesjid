using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ICN.Core.Setting;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using ICN.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.Setting
{
    [Route("api/v1/setting")]
    [Authorize]
    public class SettingController : Controller
    {
        private ILoggerManager _logger;
       
        public SettingController(ILoggerManager logger)
        {

            _logger = logger;
        }

        [HttpGet(Name = "GetSeting")]

        public IActionResult Index()
        {
            try
            {
                _logger.Information("Get Setting");
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

               
                DisplaySetting displaySetting = new DisplaySetting
                {

                    objUser = usrSession.UserLog(userId)._userInfo
                };
                var query = new List<SettingModel>((List<SettingModel>)displaySetting.Display()).ToList();
               
                var response = new SettingModelOutput
                {
                    IsSuccess = true,
                    Code = 200,
                    Message = "Success",
                    Data = query
                     
                };


                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                var response = new SettingModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update([FromBody]SettingModel request, string id)
        {
            UserSessionManager usrSession = new UserSessionManager();
            var user = User as ClaimsPrincipal;
            string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();
            SettingModelOutput settingModelOutput = new SettingModelOutput();
            try
            {
                _logger.Information("Saving Update setting");
                if (ModelState.IsValid)
                {
                    SettingServices settingServices = new SettingServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };

                    var res = settingServices.Update(request, id);
                    settingModelOutput.IsSuccess = true;
                    settingModelOutput.Message = "Success Update";
                    settingModelOutput.Code = 200;
                }
                else
                {
                    _logger.Error("Error Update Setting");


                    string errordetails = "";
                    var errors = new List<string>();
                    foreach (var state in ModelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            string p = error.ErrorMessage;
                            errordetails = errordetails + error.ErrorMessage;

                        }
                    }
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    dict.Add("error", errordetails);

                    settingModelOutput.IsSuccess = false;
                    settingModelOutput.Message = "error Update Setting validating";
                    settingModelOutput.Code = 422;
                    settingModelOutput.CustomField = dict;
                }
            }
            catch (Exception ex)
            {

                _logger.Error(ex.Message.ToString());
                settingModelOutput.IsSuccess = false;
                settingModelOutput.Message = "Failed Update Setting" + ex.Message;
                settingModelOutput.Code = 422;

            }

            return Ok(settingModelOutput);
        }


        #region " Mappings "

        private SettingModel ToSettingInfo(SettingModel model)
        {
            return new SettingModel
            {
                setting_id = model.setting_id,
                setting_address = model.setting_address,
                setting_mosque_email = model.setting_mosque_email,
                setting_city = model.setting_city,
                setting_countries = model.setting_countries,
                setting_geolocation = model.setting_geolocation,
                setting_phone = model.setting_phone
            };
        }

        #endregion

    }
}