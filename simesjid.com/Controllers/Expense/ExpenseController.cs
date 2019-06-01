using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ICN.Core.Expense;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using ICN.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.Expense
{
    [Route("api/v1/expense")]
    [Authorize]
    public class ExpenseController : Controller
    {
        private ILoggerManager _logger;
        private PagedList<TransExpenseModel> objResponse;

        public ExpenseController(ILoggerManager logger)
        {

            _logger = logger;
        }

        [HttpGet(Name = "GetExpense")]
        [Authorize(Roles = "Expense")]
        public IActionResult Index(PagingParams pagingParams)
        {
            try
            {
                _logger.Information("GetExpense");
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                ExpenseServices _expense = new ExpenseServices
                {
                    objUser = usrSession.UserLog(userId)._userInfo
                };

                objResponse = _expense.GetAll(pagingParams);

                Response.Headers.Add("X-Pagination", objResponse.GetHeader().ToJson());

                var response = new TransExpenseModelOutput
                {
                    IsSuccess = true,
                    Code = 200,
                    Message = "Success Get Expense",
                    Data = objResponse.List.Select(m => ExpenseInfo(m)).ToList(),
                    Pagination = GetLinks(objResponse, "GetExpense")

                };
                return Ok(response);


            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                var response = new TransExpenseModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }

        [HttpPost(Name = "PostExpense")]
        [Authorize(Roles = "Transactions")]
        public IActionResult Store([FromBody] TransExpenseModel model)
        {
            TransExpenseModelOutput _expenseModel = new TransExpenseModelOutput();
            try
            {

                if (ModelState.IsValid)
                {
                    _logger.Information("Post Expense");
                    UserSessionManager usrSession = new UserSessionManager();
                    var user = User as ClaimsPrincipal;
                    string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                    ExpenseServices _expense = new ExpenseServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };

                    var response = _expense.Add(model);

                    _expenseModel.IsSuccess = true;
                    _expenseModel.Message = "Success Saving";
                    _expenseModel.Code = 200;
                }
                else
                {
                    _logger.Error("Post Expense");


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

                    _expenseModel.IsSuccess = false;
                    _expenseModel.Message = "error saving validating";
                    _expenseModel.Code = 422;
                    _expenseModel.CustomField = dict;
                }


            }
            catch (Exception ex)
            {
                _logger.Error("Post Expense" + ex.Message);
                _expenseModel.IsSuccess = false;
                _expenseModel.Message = "Failed Saving" + ex.Message;
                _expenseModel.Code = 422;

            }

            return Ok(_expenseModel);
        }


        // DELETE api/v1/expense/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Transactions")]
        public IActionResult Delete(string id)
        {
            TransExpenseModelOutput _expenseModel = new TransExpenseModelOutput();
            try
            {
                _logger.Information("Delete Expense " + id);
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                ExpenseServices _expense = new ExpenseServices
                {
                    objUser = usrSession.UserLog(userId)._userInfo
                };

                var response = _expense.Delete(id);

                _expenseModel.IsSuccess = true;
                _expenseModel.Message = "Success Delete";
                _expenseModel.Code = 200;

            }
            catch (Exception ex)
            {
                _logger.Error("delete Expense" + ex.Message);
                _expenseModel.IsSuccess = false;
                _expenseModel.Message = "Failed Delete" + ex.Message;
                _expenseModel.Code = 422;

            }
            return Ok(_expenseModel);
        }

        #region " Links "
        private List<LinkInfo> GetLinks(PagedList<TransExpenseModel> list, string routename)
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

        private TransExpenseModel ExpenseInfo(TransExpenseModel model)
        {
            return new TransExpenseModel
            {
                expense_amount = model.expense_amount,
                expense_accountid = model.expense_accountid,
                expense_date = model.expense_date,
                expense_name = model.expense_name,
                expense_categoryid = model.expense_categoryid
               
            };
        }

        #endregion
    }
}