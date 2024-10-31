using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DTO.Entities;

namespace BUS.services
{
    public class CustomerMembershipService
    {
        private readonly IGenericRepository<CustomerMembership> _repository;

        public CustomerMembershipService()
        {
            _repository = new GenericRepository<CustomerMembership>(new DBContext());
        }
        public IEnumerable<CustomerMembership> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
