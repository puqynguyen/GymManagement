using System.Collections.Generic;
using DAL.Repository;
using DTO.Entities;

namespace BUS.services
{
    internal class EquipmentService
    {
        private readonly IGenericRepository<Equipment> _repository;

        public EquipmentService(IGenericRepository<Equipment> repository)
        {
            _repository = repository;
        }

        public void AddEquipment(Equipment equipment)
        {
            _repository.Add(equipment);
        }

        public void DeleteEquipment(int id)
        {
            var equipment = _repository.GetById(id);
            if (equipment != null)
            {
                _repository.Delete(equipment);
            }
        }

        public Equipment GetEquipmentById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Equipment> GetAllEquipments()
        {
            return _repository.GetAll();
        }

        public void UpdateEquipment(Equipment equipment)
        {
            _repository.Update(equipment);
        }
    }
}
