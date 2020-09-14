using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DemoADO
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MVCDemo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {

            }
        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] == null)
            {

                string CS = ConfigurationManager.ConnectionStrings["MVCDemo"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from tblProductInventory", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    Cache["Data"] = ds;

                    gvProducts.DataSource = ds;
                    gvProducts.DataBind();
                }
                lblMessage.Text = "Data is loaded from the DataBase.";
            }
            else
            {
                gvProducts.DataSource = (DataSet)Cache["Data"];
                gvProducts.DataBind();
                lblMessage.Text = "Data is loaded from cache.";
            }
        }

        protected void btnClearData_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] != null )
            {
                Cache.Remove("Data");
                lblMessage.Text = "DataSet is removed from the cache";
            }
            else
            {
                lblMessage.Text = "There is nothing in the cache to remove";
            }
        }
    }
}