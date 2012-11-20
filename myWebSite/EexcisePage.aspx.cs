using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myWebSite
{
    public partial class EexcisePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string tt = Request.Form["TextBox3"] + " - " + Request.Form["TextBox4"];
            //Label2.Text = tt;
            //Response.Write(tt);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tt = Request.Form["TextBox3"] + " - " + Request.Form["TextBox4"];
            Label2.Text = tt;
        }


    }
}