using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ICN.Core.Income;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using ICN.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.Income
{
    [Route("api/v1/income")]
    [Authorize]

    public class IncomeController : Controller
    {
        private ILoggerManager _logger;
        private PagedList<TransIncomeModel> objResponse;

        public IncomeController(ILoggerManager logger)
        {

            _logger = logger;
        }

        [HttpGet(Name = "GetIncome")]
        [Authorize(Roles = "Income")]
        public IActionResult Index(PagingParams pagingParams)
        {
            try
            {
                _logger.Information("GetIncome");
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                IncomeServices _income = new IncomeServices
                {
                    objUser = usrSession.UserLog(userId)._userInfo
                };

                objResponse = _income.GetAll(pagingParams);

                Response.Headers.Add("X-Pagination", objResponse.GetHeader().ToJson());

                var response = new TransIncomeModelOutput
                {
                    IsSuccess = true,
                    Code = 200,
                    Message = "Success Get Expense",
                    Data = objResponse.List.Select(m => IncomeInfo(m)).ToList(),
                    Pagination = GetLinks(objResponse, "GetIncome")

                };
                return Ok(response);


            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                var response = new TransIncomeModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }

        [HttpPost(Name = "PostIncome")]
        [Authorize(Roles = "Transactions")]
        public IActionResult Store([FromBody] TransIncomeModel model)
        {
            TransIncomeModelOutput _incomeModel = new TransIncomeModelOutput();
            try
            {

                if (ModelState.IsValid)
                {
                    _logger.Information("Post Income");
                    UserSessionManager usrSession = new UserSessionManager();
                    var user = User as ClaimsPrincipal;
                    string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                    IncomeServices _income = new IncomeServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };

                    var response = _income.Add(model);

                    _incomeModel.IsSuccess = true;
                    _incomeModel.Message = "Success Saving";
                    _incomeModel.Code = 200;
                }
                else
                {
                    _logger.Error("Post Income");


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

                    _incomeModel.IsSuccess = false;
                    _incomeModel.Message = "error saving validating";
                    _incomeModel.Code = 422;
                    _incomeModel.CustomField = dict;
                }


            }
            catch (Exception ex)
            {
                _logger.Error("Post Income" + ex.Message);
                _incomeModel.IsSuccess = false;
                _incomeModel.Message = "Failed Saving" + ex.Message;
                _incomeModel.Code = 422;

            }

            return Ok(_incomeModel);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Transactions")]
        public IActionResult Update([FromBody] TransIncomeModel model,string id)
        {
            TransIncomeModelOutput _incomeModel = new TransIncomeModelOutput();
            try
            {

                if (ModelState.IsValid)
                {
                    _logger.Information("update Income");
                    UserSessionManager usrSession = new UserSessionManager();
                    var user = User as ClaimsPrincipal;
                    string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                    IncomeServices _income = new IncomeServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };

                    var response = _income.Update(model,id);

                    _incomeModel.IsSuccess = true;
                    _incomeModel.Message = "Success update";
                    _incomeModel.Code = 200;
                }
                else
                {
                    _logger.Error("update Income");


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

                    _incomeModel.IsSuccess = false;
                    _incomeModel.Message = "error update saving validating";
                    _incomeModel.Code = 422;
                    _incomeModel.CustomField = dict;
                }


            }
            catch (Exception ex)
            {
                _logger.Error("update Income" + ex.Message);
                _incomeModel.IsSuccess = false;
                _incomeModel.Message = "Failed Saving update" + ex.Message;
                _incomeModel.Code = 422;

            }

            return Ok(_incomeModel);
        }
        // DELETE api/v1/expense/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Transactions")]
        public IActionResult Delete(string id)
        {
            TransIncomeModelOutput _incomeModel = new TransIncomeModelOutput();
            try
            {
                _logger.Information("Delete Income " + id);
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                IncomeServices _income = new IncomeServices
                {
                    objUser = usrSession.UserLog(userId)._userInfo
                };

                var response = _income.Delete(id);

                _incomeModel.IsSuccess = true;
                _incomeModel.Message = "Success Delete";
                _incomeModel.Code = 200;

            }
            catch (Exception ex)
            {
                _logger.Error("delete Income" + ex.Message);
                _incomeModel.IsSuccess = false;
                _incomeModel.Message = "Failed Delete" + ex.Message;
                _incomeModel.Code = 422;

            }
            return Ok(_incomeModel);
        }

        #region " Links "
        private List<LinkInfo> GetLinks(PagedList<TransIncomeModel> list, string routename)
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

        private TransIncomeModel IncomeInfo(TransIncomeModel model)
        {
            return new TransIncomeModel
            {
                income_amount = model.income_amount,
                //income_amount_rupiah = model.income_amount_rupiah,
                income_accountid = model.income_accountid,
                income_date = model.income_date,
                income_name = model.income_name,
                income_categoryid = model.income_categoryid

            };
        }

        #endregion
    }
}