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
            return _repository.GetAllNeedRenew(needRenew);
        }
    }
}
