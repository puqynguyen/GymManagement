using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
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
        public void CancelActiveMembership(int customerId)
        {
            using (var context = new DBContext())
            {
                // Lấy bản ghi membership đang hoạt động
                var activeMembership = context.CustomerMemberships
                    .FirstOrDefault(cm => cm.CustomerID == customerId && cm.cancel == 0 && cm.end_date > DateTime.Now);

                if (activeMembership != null)
                {
                    activeMembership.cancel = 1;
                    context.Entry(activeMembership).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("No active membership found for cancellation.");
                }
            }
        }

    }
}
