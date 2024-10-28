using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repository;
using DTO.Entities;

namespace BUS
{
    internal class ClassService
    {
        private readonly ClassRepository _repository;
        public ClassService(ClassRepository repository)
        {
            _repository = repository;
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
            else
            {
                throw new Exception($"Class not found");
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
        public IEnumerable<Class> GetCustomers()
        {
            return _repository.GetAll();
        }
        public void AssignInstructorToClass(int instructorId, int classId)
        {
            _repository.AssignInstructorToClass(instructorId, classId);
        }
        public void RegisterCustomerToClass(int customerId, int classId)
        {
            _repository.RegisterCustomerToClass(customerId, classId);
        }
        //asd
    }
}
