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
            // Tìm PurchaseInvoice theo invoiceId
            var invoice = _context.Set<PurchaseInvoice>().Find(invoiceId);
            if (invoice == null)
            {
                throw new Exception("PurchaseInvoice not found");
            }

            decimal totalAmount = 0;

            // Duyệt qua từng PurchaseDetail trong danh sách
            foreach (var detail in details)
            {
                // Thiết lập InvoiceID cho từng PurchaseDetail
                detail.InvoiceID = invoiceId;

                // Tính tổng cộng: quantity * price cho mỗi chi tiết
                totalAmount += (detail.quantity ?? 0) * (detail.price ?? 0);

                // Thêm chi tiết vào danh sách PurchaseDetails của invoice
                invoice.PurchaseDetails.Add(detail);
            }

            // Cập nhật total_amount cho invoice
            invoice.total_amount = totalAmount;

            // Lưu thay đổi vào cơ sở dữ liệu
            _context.SaveChanges();
        }
    }
}
