using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ICN.Core.User;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using ICN.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.User.API.V1
{
    [Route("api/v1/user")]
    [Authorize]
    public class UserController : Controller
    {
        private ILoggerManager _logger;
        private PagedList<UserModel> objResponse;

        public UserController(ILoggerManager logger)
        {

            _logger = logger;
        }

        [HttpGet(Name = "GetUser")]
        public IActionResult Index(PagingParams pagingParams)
        {
            try
            {
                _logger.Information("Get User");
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                UserServices userServices  = new UserServices
                {
                    objUser = usrSession.UserLog(userId)._userInfo
                };

                objResponse = userServices.GetAll(pagingParams);
                Response.Headers.Add("X-Pagination", objResponse.GetHeader().ToJson());
                var response = new UserModelOutput
                {
                    IsSuccess = true,
                    Code = 200,
                    Message = "Success Get Account",
                    Data = objResponse.List.Select(m => ToUserInfo(m)).ToList(),
                    Pagination = GetLinks(objResponse, "GetAccount")

                };
                return Ok(response);


            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                var response = new UserModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }

        [HttpPost]
        [Authorize(Roles = "User Role")]
        public IActionResult Post([FromBody]UserModel request)
        {
            UserSessionManager usrSession = new UserSessionManager();
            var user = User as ClaimsPrincipal;
            string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();
            UserModelOutput userModelOutput = new UserModelOutput();
            try
            {
                _logger.Information("Saving User");
                DisplayUser displayUser = new DisplayUser();
                var query = new List<UserModel>((List<UserModel>)displayUser.DisplayAll()).AsQueryable();
                var CheckEmail = query.Where(p => p.user_email.StartsWith(request.user_email ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));

                if (CheckEmail.Count() > 0)
                {
                    ModelState.AddModelError("Email", "Email already exists");
                }

                if (ModelState.IsValid)
                {
                    UserServices userServices = new UserServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };
                    var res = userServices.Add(request);
                    userModelOutput.IsSuccess = true;
                    userModelOutput.Message = "Success Saving";
                    userModelOutput.Code = 200;
                }
                else
                {
                    _logger.Error("Error Post Account");


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

                    userModelOutput.IsSuccess = false;
                    userModelOutput.Message = "error saving validating";
                    userModelOutput.Code = 422;
                    userModelOutput.CustomField = dict;
                }




            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                userModelOutput.IsSuccess = false;
                userModelOutput.Message = "Failed Saving" + ex.Message;
                userModelOutput.Code = 422;


            }

            return Ok(userModelOutput);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UPdate([FromBody]UserModel request,string id)
        {
            UserSessionManager usrSession = new UserSessionManager();
            var user = User as ClaimsPrincipal;
            string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();
            UserModelOutput userModelOutput = new UserModelOutput();
            try
            {
                _logger.Information("Update User");
                DisplayUser displayUser = new DisplayUser();
                var query = new List<UserModel>((List<UserModel>)displayUser.DisplayAll()).AsQueryable();
               
                if (ModelState.IsValid)
                {
                    UserServices userServices = new UserServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };
                    var res = userServices.Update(request,id);
                    userModelOutput.IsSuccess = true;
                    userModelOutput.Message = "Success Update";
                    userModelOutput.Code = 200;
                }
                else
                {
                    _logger.Error("Error Post Account");


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

                    userModelOutput.IsSuccess = false;
                    userModelOutput.Message = "error Update validating";
                    userModelOutput.Code = 422;
                    userModelOutput.CustomField = dict;
                }




            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                userModelOutput.IsSuccess = false;
                userModelOutput.Message = "Failed Update" + ex.Message;
                userModelOutput.Code = 422;


            }

            return Ok(userModelOutput);
        }
        #region " Links "
        private List<LinkInfo> GetLinks(PagedList<UserModel> list, string routename)
        {
            var links = new List<LinkInfo>();
            if (list.HasPreviousPage)
                links.Add(LinkUrl(routename, list.PreviousPageNumber, list.PageSize, "previousPage", "GET"));

            links.Add(LinkUrl(routename, list.PageNumber, list.PageSize, "self", "GET"));

            if (list.HasNextPage)
                links.Add(LinkUrl(routename, list.NextPageNumber, list.PageSize, "nextPage", "GET"));

            return links;
        }

        private LinkInfo LinkUrl(string routeName, int pageNumber, int pageSize, string rel, string method)
        {

            var link = new LinkInfo
            {
                Href = this.Url.Link(routeName, new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method
            };
            return link;

        }

        #endregion

        #region " Mappings "

        private UserModel ToUserInfo(UserModel model)
        {
            return new UserModel
            {
                
            };
        }

        #endregion
    }
}