using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Configuration;

namespace DemoADO
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Cs = ConfigurationManager.ConnectionStrings["MVCDemo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Cs))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Employee_Tbl values ('Derrick', 'Male', 'New York', 3)";
                cmd.Connection = con;
                con.Open();
                int RowsAffected = cmd.ExecuteNonQuery();
                Response.Write("Rows Inserted = " + RowsAffected);

                cmd = new SqlCommand("Select * from Employee_Tbl", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
        }
    }
}