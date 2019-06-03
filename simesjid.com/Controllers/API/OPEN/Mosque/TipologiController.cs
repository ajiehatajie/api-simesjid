using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICN.Core.Tipologi;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.API.OPEN.Mosque
{
    [Route("api/tipologi")]
    public class TipologiController : Controller
    {
        private ILoggerManager _logger;
        private PagedList<MosqueCategoryModel> objResponse;

        public TipologiController(ILoggerManager logger)
        {

            _logger = logger;
        }


        [HttpGet(Name = "GetOpenTipologi")]
        public IActionResult Index(PagingParams pagingParams)
        {
            try
            {
                TipologiServices tipologiServices = new TipologiServices();
                objResponse = tipologiServices.GetAll(pagingParams);
                Response.Headers.Add("X-Pagination", objResponse.GetHeader().ToJson());
                var response = new MosqueCategoryModelOutput
                {
                    IsSuccess = true,
                    Code = 200,
                    Message = "Success",
                    Data = objResponse.List.Select(m => TipologiInfo(m)).ToList(),
                    Pagination = GetLinks(objResponse, "GetOpenTipologi")

                };
                return Ok(response);


            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                var response = new MosqueCategoryModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }

        #region " Links "
        private List<LinkInfo> GetLinks(PagedList<MosqueCategoryModel> list, string routename)
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

        private MosqueCategoryModel TipologiInfo(MosqueCategoryModel model)
        {
            return new MosqueCategoryModel
            {
               category_id = model.category_id,
               category_name = model.category_name,
               category_type = model.category_type

            };
        }

        #endregion
    }
}