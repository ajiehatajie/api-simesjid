using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICN.Core.Register;
using ICN.Core.User;
using ICN.Interface;
using ICN.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.Auth
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        private ILoggerManager _logger;
        public RegisterController(ILoggerManager logger)
        {

            _logger = logger;

        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register([FromBody] RegisterModel request)
        {
            UserModelOutput userModelOutput = new UserModelOutput();

            DisplayUser displayUser = new DisplayUser();

            try
            {
              
                var query = new List<UserModel>((List<UserModel>)displayUser.DisplayAll()).AsQueryable();
                var CheckEmail =  query.Where(p => p.user_email.StartsWith(request.user_email ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));

                if(CheckEmail.Count() > 0)
                {
                    ModelState.AddModelError("Email", "Email already exists");
                }

                if (ModelState.IsValid)
                {
                    _logger.Information("Post Register");
                    RegisterServices _register = new RegisterServices();
                    var saving = _register.Add(request);

                    if (saving.Result == 1)
                    {
                        userModelOutput.IsSuccess = true;
                        userModelOutput.Code = 200;
                        userModelOutput.Message = "Success Register";


                    }
                }
                else
                {
                    _logger.Error("Failed Register");
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
                    userModelOutput.IsSuccess = false;
                    userModelOutput.Code = 422;
                    userModelOutput.Message = "Failed Register";
                    userModelOutput.CustomField = dict;
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Failed Register" + ex.Message.ToString());
                userModelOutput.IsSuccess = false;
                userModelOutput.Code = 422;
                userModelOutput.Message = ex.Message.ToString();

            }
            return Ok(userModelOutput);
        }
    }
}