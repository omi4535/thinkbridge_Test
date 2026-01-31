using System.Data.SqlClient;

namespace BuggyApp.Model
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string CustomerName { get; set; }

        // One Invoice → Many Items
        public List<InvoiceItem> Items { get; set; } = new();
    }

    public class InvoiceItem
    {
        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}
