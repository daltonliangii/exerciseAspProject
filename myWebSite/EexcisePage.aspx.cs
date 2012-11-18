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
            string tt = Request.Form["TextBox1"] + " - "  + Request.Form["TextBox2"];
            Label1.Text = tt;
            Response.Write(tt);
        }


    }
}