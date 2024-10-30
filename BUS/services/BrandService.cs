using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DTO.Entities;

namespace BUS.services
{
    public class BrandService
    {
        private readonly IGenericRepository<Brand> _repository;

        public BrandService()
        {
            _repository = new GenericRepository<Brand>(new DBContext());
        }
        public void Add(Brand brand)
        {
            _repository.Add(brand);
        }
        public void Update(Brand brand)
        {
            _repository.Update(brand);
        }
        public void Delete(int brandId)
        {
            _repository.Delete(GetById(brandId));
        }
        public Brand GetById(int id)
        {
            return _repository.GetById(id);
        }
        public IEnumerable<Brand> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
