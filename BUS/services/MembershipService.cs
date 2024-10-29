using System;
using System.Collections.Generic;
using DAL.Repository;
using DTO.Entities;

namespace BUS.Services
{
    internal class MembershipService
    {
        private readonly MembershipRepository _repository;

        public MembershipService()
        {
            _repository = new MembershipRepository(new DBContext());
        }

        // Thêm mới Membership
        public void Add(Membership membership)
        {
            _repository.Add(membership);
        }

        // Lấy Membership theo ID
        public Membership GetById(int membershipId)
        {
            return _repository.GetById(membershipId);
        }

        // Xóa Membership theo ID
        public void Delete(int membershipId)
        {
            var membership = _repository.GetById(membershipId);
            if (membership != null)
            {
                _repository.Delete(membership);
            }
        }

        // Cập nhật Membership
        public void Update(Membership membership)
        {
            _repository.Update(membership);
        }

        // Lấy tất cả Memberships
        public IEnumerable<Membership> GetAll()
        {
            return _repository.GetAll();
        }

        // Thêm Membership cho Customer
        public void AddMembershipToCustomer(int customerId, int membershipId, DateTime startDate)
        {
            _repository.AddMembershipToCustomer(customerId, membershipId, startDate);
        }
    }
}
