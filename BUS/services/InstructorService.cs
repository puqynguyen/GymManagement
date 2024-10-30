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

        public InstructorService()
        {
            _repository = new GenericRepository<Instructor>(new DBContext());
        }

        public void Add(Instructor instructor)
        {
            _repository.Add(instructor);
        }
        public void Delete(int instructorId)
        {
            _repository.Delete(GetById(instructorId));
        }
        public Instructor GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Update(Instructor instructor)
        {
            _repository.Update(instructor);
        }
        public IEnumerable<Instructor> GetAll()
        {
            return _repository.GetAll();
        }
        
    }
}
