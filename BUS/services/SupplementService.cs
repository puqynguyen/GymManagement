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

        public void AddSupplement(Supplement supplement)
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

        public Supplement GetSupplementById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Supplement> GetAllSupplements()
        {
            return _repository.GetAll();
        }

        public void UpdateSupplement(Supplement supplement)
        {
            _repository.Update(supplement);
        }
    }
}
