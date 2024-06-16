using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac_3Ex
{
    public partial class LINQOddNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] mydata = {41,42,43,44,45,46,47,48,49,50};
            foreach (int s in mydata)
            {
                lblInputData.Text = lblInputData.Text + " " + s;
            }
            var small = from odd in mydata where odd %2 !=0 select odd;
            foreach (var odd1 in small)
            {
                lblOdd.Text = lblOdd.Text + " " + odd1;
            }
        }
    }
}