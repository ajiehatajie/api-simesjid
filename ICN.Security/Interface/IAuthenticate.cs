using ICN.Model;


namespace ICN.Security.Interface
{
    public interface IAuthenticate
    {
        bool IsAuthenticated(LoginRequestModel request, out string token);

        string TokenNew(string tokenRefresh);
    }
}
