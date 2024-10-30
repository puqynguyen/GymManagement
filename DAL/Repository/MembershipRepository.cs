using System;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DTO.Entities;

namespace DAL.Repository
{
    public class MembershipRepository : GenericRepository<Membership>
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
            var customerMembership = new CustomerMembership
            {
                CustomerID = customerId,
                MembershipID = membershipId,
                start_date = startDate
            };
            _context.Set<CustomerMembership>().Add(customerMembership);
            _context.SaveChanges();
        }
        public DataTable GetMonthlyMembershipRevenue()
        {
            var dataTable = new DataTable();
            using (var conn = _context.Database.Connection)
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GetMonthlyMembershipRevenue";
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                    conn.Close();
                }
            }
            return dataTable;
        }
    }
}
