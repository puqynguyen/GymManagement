using System;
using DAL;
using DTO.Entities;

namespace DAL.Repository
{
    internal class MembershipRepository : GenericRepository<Membership>
    {
        private readonly DBContext _context;

        public MembershipRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public void AddMembershipToCustomer(int customerId, int membershipId, DateTime startDate)
        {
            var customer = _context.Set<Customer>().Find(customerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            var membership = _context.Set<Membership>().Find(membershipId);
            if (membership == null)
            {
                throw new Exception("Membership not found");
            }

            var endDate = startDate.AddMonths(membership.membership_length ?? 0);
            var customerMembership = new CustomerMembership
            {
                CustomerID = customerId,
                MembershipID = membershipId,
                start_date = startDate,
                end_date = endDate
            };
            _context.Set<CustomerMembership>().Add(customerMembership);
            _context.SaveChanges();
        }
    }
}
