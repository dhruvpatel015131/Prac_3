using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac_3Ex
{
    public partial class LINQEmployeeData : System.Web.UI.Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        public void clearData()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDesignation.Text = "";
            txtSalary.Text = "";
            txtDisplay.Text = "";
        }

        public void showData()
        {
            try
            {
                var q = from a in dc.GetTable<emp_info>() select a;
                GVEmployee.DataSource = q;
                GVEmployee.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            showData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                emp_info objEmp = new emp_info();
                objEmp.eid = Convert.ToByte(txtID.Text);
                objEmp.enmae = Convert.ToString(txtName.Text);
                objEmp.designation = Convert.ToString(txtDesignation.Text);
                objEmp.salary = Convert.ToByte(txtSalary.Text);
                dc.emp_infos.InsertOnSubmit(objEmp);
                dc.SubmitChanges();

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                showData();
                clearData();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                emp_info objDelete = dc.emp_infos.Single(emp => emp.eid == Convert.ToByte(txtID.Text));
                if (objDelete != null)
                {
                    dc.emp_infos.DeleteOnSubmit(objDelete);
                    dc.SubmitChanges();
                }


            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                showData();
                clearData();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                emp_info objUpdate = dc.emp_infos.Single(emp => emp.eid == Convert.ToByte(txtID.Text));

                objUpdate.enmae = Convert.ToString(txtName.Text);
                objUpdate.designation = Convert.ToString(txtDesignation.Text);
                objUpdate.salary = Convert.ToByte(txtSalary.Text);

                dc.SubmitChanges();

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                showData();
                clearData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                emp_info objSearch = dc.emp_infos.Single(emp => emp.eid == Convert.ToByte(txtID.Text));
                txtName.Text = objSearch.enmae;
                txtDesignation.Text = objSearch.designation;
                txtSalary.Text = objSearch.salary.ToString();
                txtDisplay.Text = "Record Found!";

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                showData();
            }
        }
    }
}