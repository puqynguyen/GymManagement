using System;
using System.Collections.Generic;
using DAL.Repository;
using DTO.Entities;

namespace BUS.Services
{
    public class MembershipService
    {
        private readonly MembershipRepository _repository;

        public MembershipService()
        {
            _repository = new MembershipRepository(new DBContext());
        }
        public void Add(Membership membership)
        {
            _repository.Add(membership);
        }
        public Membership GetById(int membershipId)
        {
            return _repository.GetById(membershipId);
        }
        public void Delete(int membershipId)
        {
            var membership = _repository.GetById(membershipId);
            if (membership != null)
            {
                _repository.Delete(membership);
            }
        }
        public void Update(Membership membership)
        {
            _repository.Update(membership);
        }
        public IEnumerable<Membership> GetAll()
        {
            return _repository.GetAll();
        }
        public void AddMembershipToCustomer(int customerId, int membershipId, DateTime startDate)
        {
            _repository.AddMembershipToCustomer(customerId, membershipId, startDate);
        }
    }
}
