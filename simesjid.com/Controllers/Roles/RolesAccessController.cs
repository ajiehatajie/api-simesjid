using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.Roles
{
    [Route("api/v1/roles")]
    [Authorize]
    public class RolesAccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}