using BuggyApp.Model;

using System.Data.SqlClient;

namespace BuggyApp.Repo
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly string _connectionString;

        public InvoiceRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Get Invoice with Items by InvoiceID
        public Invoice GetInvoiceById(int invoiceId)
        {
            Invoice invoice = null;

            using SqlConnection con = new(_connectionString);
            using SqlCommand cmd = new(@"
                SELECT 
                    i.InvoiceID,
                    i.CustomerName,
                    ii.ItemID,
                    ii.Name AS ItemName,
                    ii.Price
                FROM Invoices i
                LEFT JOIN InvoiceItems ii ON i.InvoiceID = ii.InvoiceID               
", con);

            //cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (invoice == null)
                {
                    invoice = new Invoice
                    {
                        InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                        CustomerName = reader["CustomerName"].ToString(),
                        Items = new List<InvoiceItem>()
                    };
                }

                if (reader["ItemID"] != DBNull.Value)
                {
                    invoice.Items.Add(new InvoiceItem
                    {
                        ItemID = Convert.ToInt32(reader["ItemID"]),
                        InvoiceID = invoice.InvoiceID,
                        Name = reader["ItemName"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
                    });
                }
            }

            return invoice;
        }
    }
}
