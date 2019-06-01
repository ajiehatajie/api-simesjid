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

namespace simesjid.com.Controllers.Category
{
    [Route("api/v1/category")]
    [Authorize]
    public class CategoryController : Controller
    {
        private ILoggerManager _logger;
        private PagedList<CategoryModel> objResponse;

        public CategoryController(ILoggerManager logger)
        {

            _logger = logger;
        }

        // index api/v1/category?Term=type&PageSize=1&PageNumber=5
        [HttpGet(Name = "GetCategory")]
        public IActionResult Index(PagingParams pagingParams)
        {
            try
            {
                _logger.Information("GetCategory");
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();
                 
                CategoryServices categoryServices = new CategoryServices
                {
                    objUser = usrSession.UserLog(userId)._userInfo
                };
            
                objResponse = categoryServices.GetAll(pagingParams);
                
                Response.Headers.Add("X-Pagination", objResponse.GetHeader().ToJson());

                var response = new CategoryModelOutput
                {
                    IsSuccess = true,
                    Code = 200,
                    Message = "Success Get Category",
                    Data = objResponse.List.Select(m => CategoryInfo(m)).ToList(),
                    Pagination = GetLinks(objResponse, "GetCategory")

                };
                return Ok(response);


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

        // post api/v1/category?
        [HttpPost(Name = "PostCategory")]
        [Authorize(Roles = "Expense Category,Income Category")]
        public IActionResult Store([FromBody] CategoryModel model)
        {
            CategoryModelOutput categoryModel = new CategoryModelOutput();
            try
            {

                if(ModelState.IsValid)
                {
                    _logger.Information("Post Category");
                    UserSessionManager usrSession = new UserSessionManager();
                    var user = User as ClaimsPrincipal;
                    string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                    CategoryServices categoryServices = new CategoryServices
                    {
                        objUser = usrSession.UserLog(userId)._userInfo
                    };

                    var response = categoryServices.Add(model);

                    categoryModel.IsSuccess = true;
                    categoryModel.Message = "Success Saving";
                    categoryModel.Code = 200;
                }
                else
                {
                    _logger.Error("Post Category");

                    
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
                _logger.Error("Post Category" + ex.Message);
                categoryModel.IsSuccess = false;
                categoryModel.Message = "Failed Saving" + ex.Message;
                categoryModel.Code = 422;

            }

            return Ok(categoryModel);
        }

        // Detail api/v1/category/5
        [HttpGet("{id}")]
        public IActionResult DetailCategory(string id)
        {
            CategoryModelOutput categoryModel = new CategoryModelOutput();
            try
            {
                _logger.Information("Delete Category " + id);
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                DisplayCategory displayCategory = new DisplayCategory
                {
                    objUser = usrSession.UserLog(userId)._userInfo
                };
                var collection = new List<CategoryModel>((List<CategoryModel>)displayCategory.DisplayDetailCategory(id));

                categoryModel.IsSuccess = true;
                categoryModel.Message = "Success";
                categoryModel.Code = 200;
                categoryModel.Data = collection;
            }
            catch (Exception ex)
            {
                _logger.Error("detail Category" + ex.Message);
                categoryModel.IsSuccess = false;
                categoryModel.Message = "Failed Delete" + ex.Message;
                categoryModel.Code = 422;

            }
            return Ok(categoryModel);
        }

        #region sub categorypost uncomment
        //[HttpPost(Name = "PostSubCategory")]
        //[Route("subcategory")]
        ///*
        //* cara manggil nya  url/category/subcategory
        //*/
        //public IActionResult StoreSubCategory([FromBody] CategoryModel model)
        //{
        //    CategoryModelOutput categoryModel = new CategoryModelOutput();
        //    try
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            _logger.Information("Post Sub Category " + model.category_name);
        //            UserSessionManager usrSession = new UserSessionManager();
        //            var user = User as ClaimsPrincipal;
        //            string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

        //            CategoryServices categoryServices = new CategoryServices
        //            {
        //                objUser = usrSession.UserLog(userId)._userInfo
        //            };

        //            model.category_parentid = model.category_parentid;
        //            var response = categoryServices.AddSubCategory(model);

        //            categoryModel.IsSuccess = true;
        //            categoryModel.Message = "Success Saving";
        //            categoryModel.Code = 200;
        //        }
        //        else
        //        {
        //            _logger.Error("Post Sub Category " + model.category_name);


        //            string errordetails = "";
        //            var errors = new List<string>();
        //            foreach (var state in ModelState)
        //            {
        //                foreach (var error in state.Value.Errors)
        //                {
        //                    string p = error.ErrorMessage;
        //                    errordetails = errordetails + error.ErrorMessage;

        //                }
        //            }
        //            Dictionary<string, object> dict = new Dictionary<string, object>();
        //            dict.Add("error", errordetails);

        //            categoryModel.IsSuccess = false;
        //            categoryModel.Message = "error saving validating";
        //            categoryModel.Code = 422;
        //            categoryModel.CustomField = dict;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error("Post Sub Category" + ex.Message);
        //        categoryModel.IsSuccess = false;
        //        categoryModel.Message = "Failed Saving" + ex.Message;
        //        categoryModel.Code = 422;

        //    }

        //    return Ok(categoryModel);
        //}

        #endregion
        /*
         * delete category 
         */
        // DELETE api/v1/category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            CategoryModelOutput categoryModel = new CategoryModelOutput();
            try
            {
                _logger.Information("Delete Category " + id);
                UserSessionManager usrSession = new UserSessionManager();
                var user = User as ClaimsPrincipal;
                string userId = user.Claims.Where(c => c.Type == "USERID").Select(c => c.Value).SingleOrDefault();

                CategoryServices categoryServices = new CategoryServices
                {
                    objUser = usrSession.UserLog(userId)._userInfo
                };

                var response = categoryServices.Delete(id);

                categoryModel.IsSuccess = true;
                categoryModel.Message = "Success Delete";
                categoryModel.Code = 200;

            }
            catch (Exception ex)
            {
                _logger.Error("delete Category" + ex.Message);
                categoryModel.IsSuccess = false;
                categoryModel.Message = "Failed Delete" + ex.Message;
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
               
               category_id = model.category_id,
               category_name =  model.category_name,
               category_color = model.category_color,
               category_desc = model.category_desc,
               category_type = model.category_type,
               category_userid =model.category_userid
            };
        }

        #endregion
    }
}