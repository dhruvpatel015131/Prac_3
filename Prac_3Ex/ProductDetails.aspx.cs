using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Prac_3Ex
{
    public partial class PracticalDetails : System.Web.UI.Page
    {
        static string conStr = ConfigurationManager.ConnectionStrings["ExConnString"].ToString();
        SqlConnection conn = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);

            if (!IsPostBack)
            {
                dataBind();
            }
        }

        public void dataBind()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ExConnString"].ToString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM ProductDetails", conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        // Bind to GridView
                        GridView1.DataSource = dr;
                        GridView1.DataBind();

                        // Bind to DataList
                        DataList1.DataSource = dr;
                        DataList1.DataBind();

                        // Bind to DetailsView
                        DetailsView1.DataSource = dr;
                        DetailsView1.DataBind();

                        // Bind to FormView
                        FormView1.DataSource = dr;
                        FormView1.DataBind();

                        // Bind to ListView
                        ListView1.DataSource = dr;
                        ListView1.DataBind();

                        // Bind to Repeater
                        Repeater1.DataSource = dr;
                        Repeater1.DataBind();
                    }
                    else
                    {
                        // Handle case where no data is available
                        // For example, display a message or hide the controls
                        lblMessage.Text = "No data available.";
                    }

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Exception Occurred! " + ex.Message;
            }
        }

        protected void btnSubmitDataList_Click(object sender, EventArgs e)
        {
           
            
        }
    }
}
