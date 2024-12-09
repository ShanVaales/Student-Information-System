using SIS.Model;
using SIS.SISContext;

namespace SIS.Service.Account
{
    public class AccountsService : IAccountsService
    {
        private readonly SISDbContext _context;
        public AccountsService( SISDbContext context)
        {
            _context = context;
        }
        public Task<int> SaveUser(AspUser user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public async Task<AspUser> GetByIdUserName (string userName)
        {
            var result =  _context.AspUsers.Where(x => x.Username == userName).FirstOrDefault();
            return result;
        }

        public async Task<int> LoginInfoSave(Login Dto)
        {
            _context.Logins.Add(Dto);
            await _context.SaveChangesAsync();
            return 1;
        }


    }
}
