using System;
using System.Collections.Generic;
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
                // Use the function to get the active membership for the customer
                var activeMembership = context.Database.SqlQuery<CustomerMembership>(
                    "SELECT * FROM GetActiveMembershipByCustomerId(@CustomerId)",
                    new SqlParameter("@CustomerId", customerId)
                ).FirstOrDefault();

                // Check if there is an active membership to cancel
                if (activeMembership != null)
                {
                    activeMembership.cancel = 1;
                    context.CustomerMemberships.Attach(activeMembership);
                    context.Entry(activeMembership).Property(cm => cm.cancel).IsModified = true;
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
