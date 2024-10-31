using System;
using System.Collections.Generic;
using DAL.Repository;
using DTO.Entities;

namespace BUS
{
    public class PurchaseInvoiceService
    {
        private readonly PurchaseInvoiceRepository _invoiceRepository;

        public PurchaseInvoiceService()
        {
            _invoiceRepository = new PurchaseInvoiceRepository(new DBContext());
        }
        public void Add(PurchaseInvoice invoice)
        {
            _invoiceRepository.Add(invoice);
        }
        public PurchaseInvoice GetById(int invoiceId)
        {
            return _invoiceRepository.GetById(invoiceId);
        }
        public void Delete(int invoiceId)
        {
            var invoice = _invoiceRepository.GetById(invoiceId);
            if (invoice != null)
            {
                _invoiceRepository.Delete(invoice);
            }
        }
        public IEnumerable<PurchaseInvoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }
        public void AddPurchaseDetailsToInvoice(int invoiceId, List<PurchaseDetail> details)
        {
            _invoiceRepository.AddPurchaseDetailsToInvoice(invoiceId, details);
        }
    }
}
