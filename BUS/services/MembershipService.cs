using System;
using System.Collections.Generic;
using DAL.Repository;
using DTO.Entities;

namespace BUS.Services
{
    internal class MembershipService
    {
        private readonly MembershipRepository _membershipRepository;

        public MembershipService(MembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        // Thêm mới Membership
        public void Add(Membership membership)
        {
            _membershipRepository.Add(membership);
        }

        // Lấy Membership theo ID
        public Membership GetById(int membershipId)
        {
            return _membershipRepository.GetById(membershipId);
        }

        // Xóa Membership theo ID
        public void Delete(int membershipId)
        {
            var membership = _membershipRepository.GetById(membershipId);
            if (membership != null)
            {
                _membershipRepository.Delete(membership);
            }
        }

        // Cập nhật Membership
        public void Update(Membership membership)
        {
            _membershipRepository.Update(membership);
        }

        // Lấy tất cả Memberships
        public IEnumerable<Membership> GetAll()
        {
            return _membershipRepository.GetAll();
        }

        // Thêm Membership cho Customer
        public void AddMembershipToCustomer(int customerId, int membershipId, DateTime startDate)
        {
            _membershipRepository.AddMembershipToCustomer(customerId, membershipId, startDate);
        }
    }
}
