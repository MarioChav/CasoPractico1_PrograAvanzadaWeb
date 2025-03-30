using FrontEnd.ApiModels;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISecurityHelper
    {
        LoginAPI Login(string username, string password);
    }
}
