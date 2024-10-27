using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DTO.Entities;

namespace BUS
{
    internal class InstructorService
    {
        private readonly IGenericRepository<Instructor> _repository;
        public InstructorService(IGenericRepository<Instructor> repository)
        {
            _repository = repository;
        }

        public void Add(Instructor instructor)
        {
            _repository.Add(instructor);
        }
        public void Delete(int instructorId)
        {
            _repository.Delete(_repository.GetById(instructorId));
        }
        public Instructor GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Update(Instructor instructor)
        {
            _repository.Update(instructor);
        }
        public IEnumerable<Instructor> GetCustomers()
        {
            return _repository.GetAll();
        }
        
    }
}
