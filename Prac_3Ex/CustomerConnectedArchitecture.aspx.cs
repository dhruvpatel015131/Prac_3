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
    public partial class CustomerConnectedArchitecture : System.Web.UI.Page
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
            txtAddress.Text = "";
            txtDisplay.Text = "";
        }

        public void showDisplay()
        {
            try
            {
                // Create a new SqlCommand to retrieve student information
                cmd = new SqlCommand("SELECT * FROM customer_info", conn);

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
                GVCustomer.DataSource = dt;

                // Bind the data to the GridView
                GVCustomer.DataBind();
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

            // Call the showDisplay method to display student information
            showDisplay();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && txtName.Text != "" && txtAddress.Text != "")
                {
                    // insert the new student information @rn is placeholder
                    cmd = new SqlCommand("INSERT INTO customer_info VALUES(@id,@nm,@add)", conn);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@nm", txtName.Text);
                    cmd.Parameters.AddWithValue("@add", txtAddress.Text);
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && Convert.ToUInt16(txtID.Text) > 0)
                {
                    cmd = new SqlCommand("DELETE customer_info WHERE cid=@id ", conn);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    cmd.Parameters.AddWithValue("@id", txtID.Text);

                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        lblMessage.Text = r + " Data DELEED Sucessfully";

                    }
                    else
                    {
                        lblMessage.Text = "Record not DELETED ";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && txtName.Text != "" && txtAddress.Text != "")
                {
                    cmd = new SqlCommand("UPDATE customer_info SET cname=@nm,cadd=@add WHERE cid=@id", conn);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@nm", txtName.Text);
                    cmd.Parameters.AddWithValue("@add", txtAddress.Text);
                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        lblMessage.Text = r + " Data Updated Sucessfully";

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
                if (txtID.Text != "")
                {
                    // insert the new student information @rn is placeholder
                    cmd = new SqlCommand("SELECT * FROM customer_info WHERE cid=@id", conn);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtDisplay.Text = "Record Found";
                        txtID.Text = dr[0].ToString();
                        txtName.Text = dr[1].ToString();
                        txtAddress.Text = dr[2].ToString();
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
                
            }
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt);
                //dv.Sort = txtDisplay.Text; // "rollno ASC"
                dv.RowFilter = txtDisplay.Text;// "address = 'Ratnagiri'"
                GVCustomer.DataSource = dv;
                GVCustomer.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                
            }
        }
    }

}