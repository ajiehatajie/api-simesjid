using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.API.OPEN.Postal
{
    public class PostalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}