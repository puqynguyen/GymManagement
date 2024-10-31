using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL;
using DAL.Repository;
using DTO.Entities;

namespace BUS.Services
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        private readonly DBContext _context;

        public CustomerRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllNeedRenew(bool needRenew = true)
        {
            if (needRenew)
            {
                return _context.Database.SqlQuery<Customer>("SELECT * FROM GetAllNeedRenew").ToList();
            }
            else
            {
                return _context.Database.SqlQuery<Customer>("SELECT * FROM GetAllNotNeedRenew").ToList();
            }
        }
        public Membership GetActiveMembershipByCustomerId(int customerId)
        {
            var membership = _context.Database.SqlQuery<Membership>(
                "SELECT * FROM dbo.GetActiveMembershipByCustomerId(@CustomerId)",
                new SqlParameter("@CustomerId", customerId)
            ).FirstOrDefault();

            return membership;
        }
        public IEnumerable<Class> GetClassesNotRegisteredByCustomer(int customerId)
        {
            var classes = _context.Database.SqlQuery<Class>(
                "GetClassesNotRegisteredByCustomer @CustomerId",
                new SqlParameter("@CustomerId", customerId)
            ).ToList();

            return classes;
        }


    }
}
