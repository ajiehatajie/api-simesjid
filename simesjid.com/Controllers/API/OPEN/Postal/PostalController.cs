﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICN.Core.Postal;
using ICN.Interface;
using ICN.Model;
using ICN.Paging;
using Microsoft.AspNetCore.Mvc;


namespace simesjid.com.Controllers.API.OPEN.Postal
{
    [Route("api/postal")]
    public class PostalController : Controller
    {
        private ILoggerManager _logger;
        private PagedList<PostalModel> objResponse;

        public PostalController(ILoggerManager logger)
        {

            _logger = logger;
        }
        [HttpGet(Name = "GetOpenPostal")]
        public IActionResult Index(PagingParams pagingParams,string province,string kabupaten, string kelurahan)
        {
            try
            {

                #region "IF PARAM"
                if(province == null )
                {
                    province = "";
                }
                else
                {
                    province = province.ToUpper();
                }


                if (kabupaten == null)
                {
                    kabupaten = "";
                }
                else
                {
                    kabupaten = kabupaten.ToUpper();
                }

                if (kelurahan == null)
                {
                    kelurahan = "";
                }
                else
                {
                    kelurahan = kelurahan.ToUpper();
                }

                #endregion

                PostalServices PostalServices = new PostalServices();
                objResponse = PostalServices.GetFilterThreeParam(pagingParams,province, kabupaten, kelurahan);
                Response.Headers.Add("X-Pagination", objResponse.GetHeader().ToJson());
                var response = new PostalModelOutput
                {
                    IsSuccess = true,
                    Code = 200,
                    Message = "Success",
                    Data = objResponse.List.Select(m => ToPostalInfo(m)).ToList(),
                    Pagination = GetLinks(objResponse, "GetOpenPostal")

                };
                return Ok(response);


            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message.ToString());
                var response = new PostalModelOutput
                {
                    IsSuccess = false,
                    Code = 422,
                    Message = ex.Message.ToString(),

                };
                return Ok(response);
            }


        }

        #region " Links "
        private List<LinkInfo> GetLinks(PagedList<PostalModel> list, string routename)
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

        private PostalModel ToPostalInfo(PostalModel model)
        {
            return new PostalModel
            {
                id = model.id,
                province = model.province,
                kabupaten = model.kabupaten,
                kecamatan = model.kecamatan,
                kelurahan = model.kelurahan,
                postal_id= model.postal_id
                
            };
        }

        #endregion
    }
}