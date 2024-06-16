using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac_3Ex
{
    public partial class WordsLessThan5Char : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string[] data = { "LINQ", "IS", "A", "BEAUTIFUL", "LANGUAGE" };
            foreach (string s in data)
            {
                lblInputData.Text = lblInputData.Text + " " + s;
            }
            var small = from word in data where word.Length <= 4 select word;
            foreach (var word1 in small)
            {
                lblDisplayWords.Text = lblDisplayWords.Text + " " + word1;
            }
        }
    }
}