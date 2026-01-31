using BuggyApp.Model;

namespace BuggyApp.Repo
{
   
        public interface IInvoiceRepository
        {
            Invoice GetInvoiceById(int invoiceId);
        }
    
}
