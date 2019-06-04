using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ICN.Base;
using ICN.Core.Account;
using ICN.Generic;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using ICN.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.Account.API.V1
{

    [Route("api/v1/account")]
    [Authorize(Roles = "Akun")]
    public class AccountController : Controller
    {
      
        private ILoggerManager _logger;
        private PagedList<AccountModel> objResponse;

        public AccountController(ILoggerManager logger)
        {
          
            _logger = logger;
        }

        [HttpGet(Name = "GetAccount")]
        
        public IActionResult Index(PagingParams pagingParams)
        {
            try
            {
                _logger.Information("Get Account");
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                AccountServices accountServices = new AccountServices
                {
                    objUser = usrSession.UserLog(userId)._userInfo
                };

                objResponse = accountServices.GetAll(pagingParams);
                Response.Headers.Add("X-Pagination", objResponse.GetHeader().ToJson());
                var response = new AccountModelOutput
                {
                    IsSuccess = true,
                    Code = 200,
                    Message = "Success Get Account",
                    Data = objResponse.List.Select(m => ToAccountInfo(m)).ToList(),
                    Pagination  = GetLinks(objResponse, "GetAccount")

                };
                return Ok(response);


            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                var response = new AccountModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),
                  
                };
                return Ok(response);
            }

           
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]AccountModel request)
        {
            UserSessionManager usrSession = new UserSessionManager();
            var user = User as ClaimsPrincipal;
            string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();
            AccountModelOutput accountModelOutput = new AccountModelOutput();
            try
            {
                _logger.Information("Saving Account");
                if (ModelState.IsValid)
                {
                    AccountServices accountServices = new AccountServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };
                    var res = accountServices.Add(request);
                    accountModelOutput.IsSuccess = true;
                    accountModelOutput.Message = "Success Saving";
                    accountModelOutput.Code = 200;
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

                    accountModelOutput.IsSuccess = false;
                    accountModelOutput.Message = "error saving validating";
                    accountModelOutput.Code = 422;
                    accountModelOutput.CustomField = dict;
                }
                   
              


            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                accountModelOutput.IsSuccess = false;
                accountModelOutput.Message = "Failed Saving" + ex.Message;
                accountModelOutput.Code = 422;
                

            }

            return Ok(accountModelOutput);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update([FromBody]AccountModel request,string id)
        {
            UserSessionManager usrSession = new UserSessionManager();
            var user = User as ClaimsPrincipal;
            string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();
            AccountModelOutput accountModelOutput = new AccountModelOutput();
            try
            {
                _logger.Information("Saving Update Account");
                if (ModelState.IsValid)
                {
                    AccountServices accountServices = new AccountServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                        
                    };
                  
                    var res = accountServices.Update(request,id);
                    accountModelOutput.IsSuccess = true;
                    accountModelOutput.Message = "Success Upate";
                    accountModelOutput.Code = 200;
                }
                else
                {
                    _logger.Error("ErrorUpdate Account");


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

                    accountModelOutput.IsSuccess = false;
                    accountModelOutput.Message = "error Update Account validating";
                    accountModelOutput.Code = 422;
                    accountModelOutput.CustomField = dict;
                }




            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                accountModelOutput.IsSuccess = false;
                accountModelOutput.Message = "Failed Update Account" + ex.Message;
                accountModelOutput.Code = 422;


            }

            return Ok(accountModelOutput);
        }

        #region " Links "
        private List<LinkInfo> GetLinks(PagedList<AccountModel> list,string routename)
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
                //Href = urlHelper.Link(routeName, new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method
            };
            return link;

        }

        #endregion

        #region " Mappings "

        private AccountModel ToAccountInfo(AccountModel model)
        {
            return new AccountModel
            {
                account_id = model.account_id,
                account_name = model.account_name,
                account_balance = model.account_balance,
                account_desc = model.account_desc,
                account_created = model.account_created,
                user_name = model.user_name,
                user_email = model.user_email
              
            };
        }

        #endregion
    }
}