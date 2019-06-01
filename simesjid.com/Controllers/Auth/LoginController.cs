using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICN.Interface;
using ICN.Model;
using ICN.Security.Bus;
using ICN.Security.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simesjid.com.Controllers.Auth
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IAuthenticate _authservice;
        private ILoggerManager _logger;
        public LoginController(IAuthenticate authService, ILoggerManager logger)
        {
            _authservice = authService;
            _logger = logger;

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] LoginRequestModel request)
        {
            LoginModelOutput _ouput = new LoginModelOutput();

            try
            {
                if (ModelState.IsValid)
                {
                    string token;
                    if (_authservice.IsAuthenticated(request, out token))
                    {
                        DisplayUserSecurityRepository displayUserSecurity = new DisplayUserSecurityRepository();
                        CheckUserRepository checkUserRepository = new CheckUserRepository();

                        List<UserModel> collection = new List<UserModel>((IEnumerable<UserModel>)displayUserSecurity.SearchUserWithSetting(request.Email));
                       
                        string refreshToken = GenerateToken();

                        checkUserRepository.InsertLogToken(request.Email, refreshToken, collection[0].user_id);
                        checkUserRepository.updateUserToken(refreshToken, collection[0].user_id);


                        _ouput.IsSuccess = true;
                        _ouput.Code = 200;
                        _ouput.Message = "Success Login";
                        _ouput.Data = collection.ToList();
                        _ouput.token = token;
                        _ouput.RefreshToken = refreshToken;



                       
                    }
                    else
                    {
                        _ouput.IsSuccess = false;
                        _ouput.Code = 422;
                        _ouput.Message = "Username And Password Is Not Match";
                    }

                }
                else
                {
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

                    _ouput.IsSuccess = false;
                    _ouput.Message = "error login";
                    _ouput.Code = 422;
                    _ouput.CustomField = dict;
                }
               
            }
            catch(Exception ex)
            {
                _ouput.IsSuccess = false;
                _ouput.Code = 422;
                _ouput.Message = ex.Message.ToString();
              
            }

            return Ok(_ouput);

        }




        public string GenerateToken(int size = 32)
        {

            return Guid.NewGuid().ToString();
        }

        [HttpPost("{refreshToken}/refresh")]
        public IActionResult RefreshToken([FromRoute]string refreshToken)
        {
            LoginModelOutput _ouput = new LoginModelOutput();
            CheckUserRepository checkUserRepository = new CheckUserRepository();

            try
            {
                bool validToken = checkUserRepository.IsValidToken(refreshToken);
                if (validToken)
                {
                    List<UserModel> collection = new List<UserModel>((IEnumerable<UserModel>)checkUserRepository.SearchTokenUser(refreshToken));
                    string tokenNew = _authservice.TokenNew(refreshToken);
                    string RefreshToken = GenerateToken();
                    checkUserRepository.updateUserToken(RefreshToken, collection[0].user_id);

                    _ouput.IsSuccess = true;
                    _ouput.Code = 200;
                    _ouput.token = tokenNew;
                    _ouput.RefreshToken = RefreshToken;
                    _ouput.Message = "Success Refresh Token";
                }
                else
                {
                    _ouput.IsSuccess = false;
                    _ouput.Code = 422;
                    _ouput.Message = "token is not Valid";
                }
            }
            catch (Exception ex)
            {
                _ouput.IsSuccess = false;
                _ouput.Code = 422;
                _ouput.Message = ex.Message.ToString();
                
            }

            return Ok(_ouput);
        }


        #region " Mappings "

        private LoginRequestModel ToAccountInfo(LoginRequestModel model)
        {
            return new LoginRequestModel
            {
               Username = model.Username
            };
        }

        #endregion
    }
}