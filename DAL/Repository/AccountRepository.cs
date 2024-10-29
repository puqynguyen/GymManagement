using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entities;

namespace DAL.Repository
{
    public class AccountRepository : GenericRepository<ACCOUNT>
    {
        private readonly DBContext _context;

        public AccountRepository(DBContext context) : base(context)
        {
            _context = context;
        }
        public bool Login(string username, string password)
        {
            var account = _context.Set<ACCOUNT>()
                                  .FirstOrDefault(a => a.username == username && a.password == password);
            return account != null;
        }
        public void ChangePassword(string username, string password, string newpassword)
        {
            if (!Login(username, password))
            {
                throw new Exception("Invalid username or password.");
            }

            if (password == newpassword)
            {
                throw new Exception("The new password must not be the same as the old password.");
            }
            var account = _context.Set<ACCOUNT>().FirstOrDefault(a => a.username == username);
            if (account != null)
            {
                account.password = newpassword;
                _context.SaveChanges();
            }
        }

    }
}
