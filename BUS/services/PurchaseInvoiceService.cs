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
        public void AddPurchaseInvoice(PurchaseInvoice invoice)
        {
            _invoiceRepository.Add(invoice);
        }

        // Lấy hóa đơn theo ID
        public PurchaseInvoice GetPurchaseInvoiceById(int invoiceId)
        {
            return _invoiceRepository.GetById(invoiceId);
        }

        // Xóa hóa đơn theo ID
        public void DeletePurchaseInvoice(int invoiceId)
        {
            var invoice = _invoiceRepository.GetById(invoiceId);
            if (invoice != null)
            {
                _invoiceRepository.Delete(invoice);
            }
        }

        // Lấy tất cả hóa đơn
        public IEnumerable<PurchaseInvoice> GetAllPurchaseInvoices()
        {
            return _invoiceRepository.GetAll();
        }

        // Thêm danh sách PurchaseDetail cho một PurchaseInvoice và tính tổng tiền
        public void AddPurchaseDetailsToInvoice(int invoiceId, List<PurchaseDetail> details)
        {
            _invoiceRepository.AddPurchaseDetailsToInvoice(invoiceId, details);
        }

        // Cập nhật hóa đơn
        public void UpdatePurchaseInvoice(PurchaseInvoice invoice)
        {
            _invoiceRepository.Update(invoice);
        }
    }
}
