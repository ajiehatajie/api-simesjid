using ICN.Model;
using ICN.Security.Bus;


namespace ICN.Security
{
    public class DisplayUserSecurity
    {
        public UserModel _userInfo { get; set; }

        public RoleModelOutput _rolesUser { get; set; }

        public DisplayUserSecurity()
        {
            _userInfo = new UserModel();
        }

        public void Display()
        {
            DisplayUserSecurityRepository displayUserSecurityRepository = new DisplayUserSecurityRepository();
            _userInfo = displayUserSecurityRepository.SearchTopOne(_userInfo.user_id);
        }

        public void DisplayByUsername()
        {
            DisplayUserSecurityRepository displayUserSecurityRepository = new DisplayUserSecurityRepository();
            _userInfo = displayUserSecurityRepository.SearchTopOneByUsername(_userInfo.user_name);

        }

        public void DisplayByEmail()
        {
            DisplayUserSecurityRepository displayUserSecurityRepository = new DisplayUserSecurityRepository();
            _userInfo = displayUserSecurityRepository.SearchTopOneByEmail(_userInfo.user_email);

        }
        public object DisplayRolesUser()
        {
            DisplayUserSecurityRepository displayUserSecurityRepository = new DisplayUserSecurityRepository();
            return  displayUserSecurityRepository.SearchRolesByUserId(_userInfo.user_id);
        }

    }
}
