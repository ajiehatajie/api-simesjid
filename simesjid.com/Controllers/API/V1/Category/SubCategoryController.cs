using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ICN.Core.Category;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using ICN.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.Category.API.V1
{
    [Route("api/v1/subcategory")]
    [Authorize]
    public class SubCategoryController : Controller
    {
        private ILoggerManager _logger;
        private PagedList<CategoryModel> objResponse;

        public SubCategoryController(ILoggerManager logger)
        {

            _logger = logger;
        }

        // index api/v1/subcategory/idnya?Term=type&PageSize=1&PageNumber=5
        //[HttpGet(Name = "GetSubCategory","{id}")]

        [HttpGet(Name = "GetSubCategory")]
        public IActionResult IndexSubCategory(PagingParams pagingParams,string id = null,string parent = null)
        {
            try
            {
                _logger.Information("GetSubCategory");
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

              

                if (id == null)
                {
                    CategoryServices categoryServices = new CategoryServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };

                    objResponse = categoryServices.GetAllSubCategories(pagingParams, parent);
                    Response.Headers.Add("X-Pagination", objResponse.GetHeader().ToJson());

                    var response = new CategoryModelOutput
                    {
                        IsSuccess = true,
                        Code = 200,
                        Message = "Success Get Category",
                        Data = objResponse.List.Select(m => CategoryInfo(m)).ToList(),
                        Pagination = GetLinks(objResponse, "GetSubCategory")

                    };
                    return Ok(response);
                }
                else
                {
                    DisplayCategory displayCategory = new DisplayCategory
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };
                    var collection = new List<CategoryModel>((IEnumerable<CategoryModel>)displayCategory.DisplayDetailSubCategory(id));
                    
                    var response = new CategoryModelOutput
                    {
                        IsSuccess = true,
                        Code = 200,
                        Message = "Success Get Category",
                        Data = collection,
                      

                    };
                    return Ok(response);
                }
              

              


            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                var response = new CategoryModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }

        [HttpPost(Name = "PostSubCategory")]
        [Authorize(Roles = "Expense Category,Income Category")]
        public IActionResult Store([FromBody] CategoryModel model)
        {
            CategoryModelOutput categoryModel = new CategoryModelOutput();
            try
            {

                if (ModelState.IsValid)
                {
                    _logger.Information("Post Sub Category " + model.category_name);
                    UserSessionManager usrSession = new UserSessionManager();
                    var user = User as ClaimsPrincipal;
                    string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                    CategoryServices categoryServices = new CategoryServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };

                    model.category_parentid = model.category_parentid;
                    var response = categoryServices.AddSubCategory(model);

                    categoryModel.IsSuccess = true;
                    categoryModel.Message = "Success Saving";
                    categoryModel.Code = 200;
                }
                else
                {
                    _logger.Error("Post Sub Category " + model.category_name);


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

                    categoryModel.IsSuccess = false;
                    categoryModel.Message = "error saving validating";
                    categoryModel.Code = 422;
                    categoryModel.CustomField = dict;
                }


            }
            catch (Exception ex)
            {
                _logger.Error("Post Sub Category" + ex.Message);
                categoryModel.IsSuccess = false;
                categoryModel.Message = "Failed Saving" + ex.Message;
                categoryModel.Code = 422;

            }

            return Ok(categoryModel);
        }



            #region " Links "
            private List<LinkInfo> GetLinks(PagedList<CategoryModel> list, string routename)
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

        private CategoryModel CategoryInfo(CategoryModel model)
        {
            return new CategoryModel
            {
                parent_id = model.parent_id,
                parent_name = model.parent_name,
                category_id = model.category_id,
                category_name = model.category_name,
                category_color = model.category_color,
                category_desc = model.category_desc,
                category_type = model.category_type,
                category_userid = model.category_userid
            };
        }

        #endregion
    }
}