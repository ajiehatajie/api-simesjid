using ICN.Model;
using ICN.Security.Bus;
using ICN.Security.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ICN.Security
{
    public class TokenAuthenticate : IAuthenticate
    {
        private readonly TokenManagement tokenManagement;
        private readonly IUserCheck userCheck;

        public TokenAuthenticate(IUserCheck userCheck, IOptions<TokenManagement> tokenManagement)
        {
            this.tokenManagement = tokenManagement.Value;
            this.userCheck = userCheck;

        }

        public bool IsAuthenticated(LoginRequestModel request, out string token)
        {
            token = string.Empty;
            if(userCheck.IsValidUser(request.Email,request.Password))
            {
                token = GenerateToken(request.Email);
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GenerateToken(string email)
        {
            string token = string.Empty;
            DisplayUserSecurity Ds = new DisplayUserSecurity();
            Ds._userInfo.user_email = email;
            Ds.DisplayByEmail();

            #region "ROLES USER"
            DisplayUserSecurity _RolesUser = new DisplayUserSecurity();
            _RolesUser._userInfo.user_id = Ds._userInfo.user_id;
            
            List<RoleModel> collection = new List<RoleModel>((IEnumerable<RoleModel>)_RolesUser.DisplayRolesUser());
           
            var claims = new List<Claim>();

            foreach (var groupRoles in collection)
            {
                claims.Add(new Claim(ClaimTypes.Role, groupRoles.role_name));
            }
            claims.Add(new Claim(ClaimTypes.Name, email));
            claims.Add(new Claim("USERID", Ds._userInfo.user_id));
            claims.Add(new Claim("USEREMAIL", email));
            #endregion


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                tokenManagement.Issuer,
                tokenManagement.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }

        public string TokenNew(string tokenRefresh)
        {
            CheckUserRepository checkUserRepository = new CheckUserRepository();
            var user = checkUserRepository.SearchTokenUser(tokenRefresh);
            List<UserModel> collection = new List<UserModel>((IEnumerable<UserModel>)user);

            string token = GenerateToken(collection[0].user_name);

            return token;
        }
    }
}
