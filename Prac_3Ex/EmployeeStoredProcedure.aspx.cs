using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac_3Ex
{
    public partial class EmployeeStoredProcedure : System.Web.UI.Page
    {

            static string conStr = ConfigurationManager.ConnectionStrings["ExConnString"].ToString();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DataTable dt = null;

        public void clearData()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDesignation.Text = "";
            txtSalary.Text = "";
            txtDisplay.Text = "";
        }

        public void showDisplay()
        {
            try
            {
                // Create a new SqlCommand to retrieve student information
                cmd = new SqlCommand("SELECT * FROM emp_info", conn);

                // Check if the connection is closed, if so open it
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Create a new DataTable to store the student information
                dt = new DataTable();

                // Load the student information into the DataTable
                dr = cmd.ExecuteReader();
                dt.Load(dr);

                // Set the GridView data source to the DataTable
                GVEmployee.DataSource = dt;

                // Bind the data to the GridView
                GVEmployee.DataBind();
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                lblMessage.Text = "Exception Occured! " + ex.Message;
            }
            finally
            {
                // Close the connection
                conn.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);

            // Call the showDisplay method to display employee information
            showDisplay();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && txtName.Text != "" && txtDesignation.Text != "" && txtSalary.Text != "")
                {
                    cmd = new SqlCommand();
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertData";
                    cmd.Parameters.Add(new SqlParameter("@eid", SqlDbType.SmallInt)).Value = Convert.ToInt16(txtID.Text);
                    cmd.Parameters.Add(new SqlParameter("@ename", SqlDbType.VarChar)).Value = txtName.Text;
                    cmd.Parameters.Add(new SqlParameter("@designation", SqlDbType.VarChar)).Value = txtDesignation.Text;
                    cmd.Parameters.Add(new SqlParameter("@salary", SqlDbType.SmallInt)).Value = Convert.ToInt16(txtSalary.Text);
                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        lblMessage.Text = r + " Data Inserted Sucessfully";

                    }
                    else
                    {
                        lblMessage.Text = "Record not Inserted";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                clearData();
                showDisplay();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && Convert.ToInt32(txtID.Text) > 0)
                {

                    cmd = new SqlCommand();
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "selectData";
                    cmd.Parameters.Add(new SqlParameter("@eid", SqlDbType.SmallInt)).Value = Convert.ToInt16(txtID.Text);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        txtDisplay.Text = "Record Found";
                        while (dr.Read())
                        {
                            txtID.Text = dr[0].ToString();
                            txtName.Text = dr[1].ToString();
                            txtDesignation.Text = dr[2].ToString();
                            txtSalary.Text = dr[3].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                showDisplay();
             
            }
        }
    }
}