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
    public partial class EmployeeInfoDisconnectedArchitecture : System.Web.UI.Page
    {
        static string conStr = ConfigurationManager.ConnectionStrings["ExConnString"].ToString();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        SqlCommandBuilder builder = null;
        DataSet ds = null;

        public void showData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                da = new SqlDataAdapter();
                ds = new DataSet();
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;


                cmd = new SqlCommand("SELECT * FROM emp_info", conn);
                cmd.CommandType = CommandType.Text;

                da.SelectCommand = cmd;

                da.Fill(ds, "empDS");

                // Fill(ds,"empDS"); -automatically connect with database fetch data and fill in the dataset

                GVEmployee.DataSource = ds.Tables["empDS"];
                GVEmployee.DataBind();
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
        public void clearData()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDesignation.Text = "";
            txtDisplay.Text = "";
            txtSalary.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);

            // Call the showDisplay method to display Employee information
            showData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && txtName.Text != "" && txtDesignation.Text != "" && txtSalary.Text != "")
                {
                    builder = new SqlCommandBuilder(da);
                    DataRow drNew = ds.Tables["empDS"].NewRow();

                    drNew[0] = txtID.Text;
                    drNew[1] = txtName.Text;
                    drNew[2] = txtDesignation.Text;
                    drNew[3] = txtSalary.Text;

                    ds.Tables["empDS"].Rows.Add(drNew); // add new record is added into dataset
                    builder.GetInsertCommand();

                    int r = da.Update(ds, "empDS");

                    if (r != 0)
                    {
                        lblMessage.Text = "Data Inserted Sucessfully ";
                    }
                    else lblMessage.Text = "Data Not Inserted";

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                showData();
                clearData();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    builder = new SqlCommandBuilder(da);
                    DataRow drDelete = ds.Tables["empDS"].Rows.Find(Convert.ToInt32(txtID.Text));

                    drDelete.Delete();// delete from dataset

                    builder.GetDeleteCommand();
                    int r = da.Update(ds, "empDS");
                    if (r != 0)
                    {
                        lblMessage.Text = "Data Deleted Sucessfully ";
                    }
                    else lblMessage.Text = "Data Not Deleted ";

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                showData();
                clearData();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && txtName.Text != "" && txtDesignation.Text != "" && txtID.Text != "")
                {
                    builder = new SqlCommandBuilder(da);
                    DataRow drUpdate = ds.Tables["empDS"].Rows.Find(Convert.ToInt32(txtID.Text));

                    drUpdate[1] = txtName.Text;
                    drUpdate[2] = txtDesignation.Text;
                    drUpdate[3] = txtSalary.Text;

                    builder.GetUpdateCommand();

                    int r = da.Update(ds, "empDS");

                    if (r != 0)
                    {
                        lblMessage.Text = "Data Updated Sucessfully ";
                    }
                    else lblMessage.Text = "Data Not Updated ";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                showData();
                clearData();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" && Convert.ToInt32(txtID.Text) > 0)
                {
                    builder = new SqlCommandBuilder(da);

                    DataRow drSearch = ds.Tables["empDS"].Rows.Find(Convert.ToInt32(txtID.Text));
                    if (drSearch != null)
                    {
                        clearData();
                        txtID.Text = drSearch[0].ToString();
                        txtName.Text = drSearch[1].ToString();
                        txtDesignation.Text = drSearch[2].ToString();
                        txtSalary.Text = drSearch[3].ToString();

                        builder.GetUpdateCommand();
                        txtDisplay.Text = "Data Found";
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Found";
                    }

                    // int r = da.Update(ds, "empDS");

                    // if (r != 0)
                    //{
                    //  lblMessage.Text = "Data Updated Sucessfully ";
                    //}
                    // else lblMessage.Text = "Data Not Updated ";





                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                showData();
               
            }
        }
    }
}