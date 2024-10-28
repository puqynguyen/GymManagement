using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO.Entities;

namespace BUS.Services
{
    public class CustomerRepository
    {
        private readonly DBContext _context;

        public CustomerRepository(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllNeedRenew(bool needRenew = true)
        {
            if (needRenew)
            {
                // Truy vấn `GetAllNeedRenew` nếu `needRenew` là true
                return _context.Database.SqlQuery<Customer>("SELECT * FROM GetAllNeedRenew").ToList();
            }
            else
            {
                // Truy vấn `GetAllNotNeedRenew` nếu `needRenew` là false
                return _context.Database.SqlQuery<Customer>("SELECT * FROM GetAllNotNeedRenew").ToList();
            }
        }

    }
}
