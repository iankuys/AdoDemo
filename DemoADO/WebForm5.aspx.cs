using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DemoADO
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MVCDemo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select ProductId, ProductName, UnitPrice from tblProductInventory", con);
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("ProductId");
                    table.Columns.Add("ProductName");
                    table.Columns.Add("UnitPrice");
                    table.Columns.Add("DiscountedPrice");

                    while (rdr.Read())
                    {
                        DataRow datarow = table.NewRow();

                        int OriginalPrice = Convert.ToInt32(rdr["UnitPrice"]);
                        double DiscountedPrice = 0.9 * OriginalPrice;

                        datarow["ProductId"] = rdr["ProductId"];
                        datarow["ProductName"] = rdr["ProductName"];
                        datarow["UnitPrice"] = rdr["UnitPrice"];
                        datarow["DiscountedPrice"] = DiscountedPrice;
                        table.Rows.Add(datarow);
                    }
                }
            }
        }
    }
}