using System;
using System.Collections.Generic;
using DAL.Repository;
using DTO.Entities;

namespace BUS
{
    internal class PurchaseInvoiceService
    {
        private readonly PurchaseInvoiceRepository _invoiceRepository;

        public PurchaseInvoiceService(PurchaseInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        // Thêm mới hóa đơn
        public void Add(PurchaseInvoice invoice)
        {
            _invoiceRepository.Add(invoice);
        }

        // Lấy hóa đơn theo ID
        public PurchaseInvoice GetById(int invoiceId)
        {
            return _invoiceRepository.GetById(invoiceId);
        }

        // Xóa hóa đơn theo ID
        public void Delete(int invoiceId)
        {
            var invoice = _invoiceRepository.GetById(invoiceId);
            if (invoice != null)
            {
                _invoiceRepository.Delete(invoice);
            }
        }

        // Lấy tất cả hóa đơn
        public IEnumerable<PurchaseInvoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }

        // Thêm danh sách PurchaseDetail cho một PurchaseInvoice và tính tổng tiền
        public void AddPurchaseDetailsToInvoice(int invoiceId, List<PurchaseDetail> details)
        {
            _invoiceRepository.AddPurchaseDetailsToInvoice(invoiceId, details);
        }

        // Cập nhật hóa đơn
        public void Update(PurchaseInvoice invoice)
        {
            _invoiceRepository.Update(invoice);
        }
    }
}
