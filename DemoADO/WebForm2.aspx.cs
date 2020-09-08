using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace DemoADO
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MVCDemo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@Gender",  ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@City", txtSalary.Text);
                cmd.Parameters.AddWithValue("@DepartmentId", TextDepartment.Text);

                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@EmployeeId";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                string EmployeeId = outPutParameter.Value.ToString();
                lblMessage.Text = "Employee Id = " + EmployeeId;

            }
        }
    }
}