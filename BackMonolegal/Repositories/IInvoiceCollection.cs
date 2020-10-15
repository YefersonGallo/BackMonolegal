using BackMonolegal.Models;
using System.Collections.Generic;

namespace BackMonolegal.Repositories
{
    interface IInvoiceCollection
    {
        void CreateInvoice(Invoice invoice);
        List<Invoice> getAllInvoices();
        Invoice getInvoiceById(string id);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(string id);

    }
}
