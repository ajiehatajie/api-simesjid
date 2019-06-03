using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.Account.API.V1
{
    public class DetailAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}