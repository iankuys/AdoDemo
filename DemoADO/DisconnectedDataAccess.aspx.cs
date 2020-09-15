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
    public partial class DisconnectedDataAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetDataFromDB()
        {
            string cs = ConfigurationManager.ConnectionStrings["MVCDemo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string strSelectQuery = "Select * from tblStudents";
                SqlDataAdapter da = new SqlDataAdapter(strSelectQuery, con);

                DataSet ds = new DataSet();
                da.Fill(ds, "Students");

                ds.Tables["Students"].PrimaryKey = new DataColumn[] { ds.Tables["Students"].Columns["Id"] };
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

                gvStudent.DataSource = ds;
                gvStudent.DataBind();

                lblMessage.Text = "Data Loaded from Database.";
            }

        }

        private void GetDataFromCache()
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                gvStudent.DataSource = ds;
                gvStudent.DataBind();
            }
        }
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void btnGetDataFromDB_Click(object sender, EventArgs e)
        {
            GetDataFromDB();
        }

        protected void gvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStudent.EditIndex = e.NewEditIndex;
            GetDataFromCache();
        }

        protected void gvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["ID"]);
                dr["Name"] = e.NewValues["Name"];
                dr["Gender"] = e.NewValues["Gender"];
                dr["TotalMarks"] = e.NewValues["TotalMarks"];

                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                gvStudent.EditIndex = -1;
                GetDataFromCache();

            }
        }

        protected void gvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudent.EditIndex = -1;
            GetDataFromCache();
        }

        protected void gvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["ID"]);
                dr.Delete();

                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                GetDataFromCache();

            }
        }

        protected void btnUpdateDB_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MVCDemo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string strSelectQuery = "Select * from tblStudents";
                SqlDataAdapter da = new SqlDataAdapter(strSelectQuery, con);

                DataSet ds = (DataSet)Cache["DATASET"];

                string strUpdateCommand = "Update tblStudents set Name = @Name, Gender = @Gender, TotalMarks = @TotalMarks where Id=@Id";
                SqlCommand updateCommand = new SqlCommand(strUpdateCommand, con);

                updateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
                updateCommand.Parameters.Add("@Gender", SqlDbType.NVarChar, 20, "Gender");
                updateCommand.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");
                updateCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");

                da.UpdateCommand = updateCommand;

                string strDeleteCommand = "Delete from tblStudents where Id=@Id";
                SqlCommand deleteCommand = new SqlCommand(strDeleteCommand, con);
                deleteCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id"); ;
                da.DeleteCommand = deleteCommand;

                da.Update(ds, "Students");
            }
        }
    }
}