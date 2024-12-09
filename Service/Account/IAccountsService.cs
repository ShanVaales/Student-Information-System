using SIS.Model;

namespace SIS.Service.Account
{
    public interface IAccountsService
    {
        Task<int> SaveUser(AspUser user);
        Task<AspUser> GetByIdUserName(string userName);
    }
}
