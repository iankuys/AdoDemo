using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace DemoADO
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["MVCDemo"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from tblProductInventory; select * from tblProductCategories", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    ProductsGridView.DataSource = reader;
                    ProductsGridView.DataBind();

                    while (reader.NextResult())
                    {
                        CategoriesGridView.DataSource = reader;
                        CategoriesGridView.DataBind();
                    }

                }
            }
        }
    }
}