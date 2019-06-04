using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ICN.Core.Roles;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using ICN.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.Roles.API.V1
{
    [Route("api/v1/roles")]
    [Authorize(Roles = "Pengaturan Pengguna")]
    public class RolesAccessController : Controller
    {
        private ILoggerManager _logger;
        private PagedList<RoleModel> objResponse;


        public RolesAccessController(ILoggerManager logger)
        {

            _logger = logger;
        }

        [HttpGet(Name = "GetRoles")]
        public IActionResult Index()
        {
            try
            {
                _logger.Information("Get Roles");
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();


                DisplayRoles displayRoles  = new DisplayRoles
                {

                    objUser = usrSession.UserLog(userId)._userInfo
                };
                var query = new List<RoleModel>((List<RoleModel>)displayRoles.Display()).ToList();

                
                var response = new RoleModelOutput
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
                var response = new RoleModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }


        [HttpGet("{userid}")]
        public IActionResult RoleByUser(string userid)
        {
            try
            {
                _logger.Information("Get Roles by user" + userid);
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();


                DisplayRoles displayRoles = new DisplayRoles
                {

                    objUser = usrSession.UserLog(userId)._userInfo
                };
                var query = new List<RoleModel>((List<RoleModel>)displayRoles.Search(userid)).ToList();


                var response = new RoleModelOutput
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
                var response = new RoleModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }


        [HttpDelete("{rolesid}")]
        [Authorize(Roles = "Pengaturan Pengguna")]
        public IActionResult DeleteRolesByUserid(string rolesid)
        {
            try
            {
                _logger.Information("Get Roles by user" + rolesid);
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();


                RolesServices rolesServices = new RolesServices
                {

                    objUser = usrSession.UserLog(userId)._userInfo
                };
                var query = rolesServices.Delete(rolesid);

                if(query.Result == 1)
                {
                    var response = new RoleModelOutput
                    {
                        IsSuccess = true,
                        Code = 200,
                        Message = "Success",
                       

                    };
                    return Ok(response);
                }
                else
                {
                    var response = new RoleModelOutput
                    {
                        IsSuccess = false,
                        Code = 422,
                        Message = "error",


                    };
                    return Ok(response);

                }

               


               
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                var response = new RoleModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }


        [HttpPut("{rolesid}")]
        [Authorize(Roles = "Pengaturan Pengguna")]
        public IActionResult UpdateRolesUser(string rolesid)
        {
            try
            {
                _logger.Information("update Roles by user" + rolesid);
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();


                RolesServices rolesServices = new RolesServices
                {

                    objUser = usrSession.UserLog(userId)._userInfo
                };
                var query = rolesServices.UpdateRoles(rolesid);

                if (query.Result == 1)
                {
                    var response = new RoleModelOutput
                    {
                        IsSuccess = true,
                        Code = 200,
                        Message = "Success Update",


                    };
                    return Ok(response);
                }
                else
                {
                    var response = new RoleModelOutput
                    {
                        IsSuccess = false,
                        Code = 422,
                        Message = "error update",


                    };
                    return Ok(response);

                }





            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                var response = new RoleModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }

        #region " Mappings "

        private RoleModel ToRolesInfo(RoleModel model)
        {
            return new RoleModel
            {
                role_id = model.role_id,
                role_name = model.role_name,
                user_id = model.user_id
            };
        }

        #endregion
    }
}