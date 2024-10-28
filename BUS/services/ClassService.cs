using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL;
using DAL.Repository;
using DTO.Entities;

namespace BUS
{
    public class CustomerService
    {
        private readonly IGenericRepository<Customer> _repository;
        private readonly DBContext _context;

        public CustomerService(IGenericRepository<Customer> repository, DBContext context)
        {
            _repository = repository;
            _context = context;
        }

        // Thêm mới Customer
        public void Add(Customer customer)
        {
            _repository.Add(customer);
        }

        // Xóa Customer theo ID
        public void Delete(int customerId)
        {
            var customer = _repository.GetById(customerId);
            if (customer != null)
            {
                _repository.Delete(customer);
            }
        }

        // Lấy Customer theo ID
        public Customer GetById(int id)
        {
            return _repository.GetById(id);
        }

        // Cập nhật thông tin Customer
        public void Update(Customer customer)
        {
            _repository.Update(customer);
        }

        // Lấy tất cả các Customer
        public IEnumerable<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        // Lấy danh sách khách hàng cần gia hạn hoặc không cần gia hạn dựa trên tham số `needRenew`
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
