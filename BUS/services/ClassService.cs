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

        public ClassService()
        {
            _repository = new ClassRepository(new DBContext());
        }
        public void Add(Class cls)
        {
            _repository.Add(cls);
        }
        public void Delete(int clsId)
        {
            var cls = _repository.GetById(clsId);
            if (cls != null)
            {
                _repository.Delete(cls);
            }
        }
        public Class GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Update(Class cls)
        {
            _repository.Update(cls);
        }
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
        public void RemoveCustomerFromClass(int customerId, int classId)
        {
            _repository.RemoveCustomerFromClass(customerId, classId);
        }
        public void RemoveInstructorFromClass(int instructorId, int classId)
        {
            _repository.RemoveInstructorFromClass(instructorId, classId);
        }
    }
}
