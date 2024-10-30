using System.Collections.Generic;
using DAL.Repository;
using DTO.Entities;

namespace BUS.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService()
        {
            _repository = new CustomerRepository(new DBContext());
        }
        public void Add(Customer customer)
        {
            _repository.Add(customer);
        }
        public void Delete(int customerId)
        {
            var customer = _repository.GetById(customerId);
            if (customer != null)
            {
                _repository.Delete(customer);
            }
        }
        public Customer GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Update(Customer customer)
        {
            _repository.Update(customer);
        }
        public IEnumerable<Customer> GetAll()
        {
            return _repository.GetAll();
        }
        public IEnumerable<Customer> GetAllNeedRenew(bool needRenew = true)
        {
            return _repository.GetAllNeedRenew(needRenew);
        }
        public Membership GetActiveMembershipByCustomerId(int customerId)
        {
            return _repository.GetActiveMembershipByCustomerId(customerId);
        }
    }
}
