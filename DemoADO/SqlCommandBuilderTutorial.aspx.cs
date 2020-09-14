using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DemoADO
{
    public partial class SqlCommandBuilderTutorial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MVCDemo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string selectquery = "select * from tblStudents where ID = " + txtStudentID.Text;
                SqlDataAdapter da = new SqlDataAdapter(selectquery, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Student");

                ViewState["SQL_QUERY"] = selectquery;
                ViewState["DATASET"] = ds;

                if (ds.Tables["Student"].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["Student"].Rows[0];
                    txtStudentName.Text = dr["Name"].ToString();
                    txtTotalMarks.Text = dr["TotalMarks"].ToString();
                    ddlGender.SelectedValue = dr["Gender"].ToString();
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "No student records with Id = " + txtStudentID.Text;
                }

            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["MVCDemo"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            // Retrieve the Select query from ViewState and use it to build
            // SqlCommand command object, which will then be set as the 
            // SelectCommand of the SqlDataAdapter object
            dataAdapter.SelectCommand = new SqlCommand((string)ViewState["SELECT_QUERY"], con);

            // Associate SqlDataAdapter object with SqlCommandBuilder. At this point
            // SqlCommandBuilder should generate T-SQL statements automatically
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

            DataSet ds = (DataSet)ViewState["DATASET"];
            DataRow dr = ds.Tables["Students"].Rows[0];
            dr["Name"] = txtStudentName.Text;
            dr["Gender"] = ddlGender.SelectedValue;
            dr["TotalMarks"] = txtTotalMarks.Text;
            dr["Id"] = txtStudentID.Text;

            int rowsUpdated = dataAdapter.Update(ds, "Students");
            if (rowsUpdated == 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No rows updated";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = rowsUpdated.ToString() + " row(s) updated";
            }

    }
    }
}