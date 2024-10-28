using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Services;
using DAL.Repository;
using DTO.Entities;

namespace BUS.services
{
    internal class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Customer> GetAllNeedRenew(bool needRenew = true)
        {
            return _repository.GetAllNeedRenew(needRenew);
        }
    }
}
