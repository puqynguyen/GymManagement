using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DTO.Entities;

namespace BUS.services
{
    public class AccountService
    {
        private readonly AccountRepository _repository;

        public AccountService()
        {
            _repository = new AccountRepository(new DBContext());
        }
        public bool Login(string username, string password)
        {
            return _repository.Login(username, password);
        }
        public void ChangePassword(string username, string password, string newpassword)
        {
            _repository.ChangePassword(username, password, newpassword);
        }
    }
}
