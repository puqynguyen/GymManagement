using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using DAL.Repository;
using DTO.Entities;

namespace BUS.services
{
    public class ClassService
    {
        private readonly ClassRepository _repository;

        public ClassService(ClassRepository repository)
        {
            _repository = repository;
        }

        // Thêm mới Customer
        public void Add(Class cls)
        {
            _repository.Add(cls);
        }

        // Xóa Customer theo ID
        public void Delete(int clsId)
        {
            var cls = _repository.GetById(clsId);
            if (cls != null)
            {
                _repository.Delete(cls);
            }
        }

        // Lấy Customer theo ID
        public Class GetById(int id)
        {
            return _repository.GetById(id);
        }

        // Cập nhật thông tin Customer
        public void Update(Class cls)
        {
            _repository.Update(cls);
        }

        // Lấy tất cả các Customer
        public IEnumerable<Class> GetAll()
        {
            return _repository.GetAll();
        }


        public IEnumerable<Class> GetAllAvailableClass()
        {
            return _repository.GetAllAvailableClass();
        }

        public void AssignInstructorToClass(int instructorId, int classId)
        {
            _repository.AssignInstructorToClass(instructorId, classId);
        }
        public void RegisterCustomerToClass(int customerId, int classId)
        {
            _repository.RegisterCustomerToClass(customerId, classId);
        }
        public IEnumerable<Customer> GetCustomersInClass(int classId)
        {
            return _repository.GetCustomersInClass(classId);
        }
        public IEnumerable<Instructor> GetInstructorsInClass(int classId)
        {
            return _repository.GetInstructorsInClass(classId);
        }
        public IEnumerable<Customer> GetCustomersNotInClass(int classId)
        {
            return _repository.GetCustomersNotInClass(classId);
        }
        public IEnumerable<Instructor> GetInstructorsNotInClass(int classId)
        {
            return _repository.GetInstructorsNotInClass(classId);
        }
    }
}
