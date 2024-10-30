using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO.Entities;

namespace DAL.Repository
{
    public class PurchaseInvoiceRepository : GenericRepository<PurchaseInvoice>
    {
        private readonly DBContext _context;

        public PurchaseInvoiceRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public void AddPurchaseDetailsToInvoice(int invoiceId, List<PurchaseDetail> details)
        {
            var invoice = _context.Set<PurchaseInvoice>().Find(invoiceId);
            if (invoice == null)
            {
                throw new Exception("PurchaseInvoice not found");
            }

            decimal totalAmount = 0;
            foreach (var detail in details)
            {
                detail.InvoiceID = invoiceId;
                _context.PurchaseDetails.Add(detail);
                totalAmount += (detail.quantity ?? 0) * (detail.price ?? 0);
                invoice.PurchaseDetails.Add(detail);
            }
            invoice.totalAmount = totalAmount;
            _context.SaveChanges();
        }
    }
}
