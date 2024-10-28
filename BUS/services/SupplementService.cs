using System.Collections.Generic;
using DAL.Repository;
using DTO.Entities;

namespace BUS.services
{
    internal class SupplementService
    {
        private readonly IGenericRepository<Supplement> _repository;

        public SupplementService(IGenericRepository<Supplement> repository)
        {
            _repository = repository;
        }

        public void Add(Supplement supplement)
        {
            _repository.Add(supplement);
        }

        public void DeleteSupplement(int id)
        {
            var supplement = _repository.GetById(id);
            if (supplement != null)
            {
                _repository.Delete(supplement);
            }
        }

        public Supplement GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Supplement> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Supplement supplement)
        {
            _repository.Update(supplement);
        }
    }
}
