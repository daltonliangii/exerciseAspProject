using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myWebSite
{
    public partial class resultPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = ((TextBox)PreviousPage.FindControl("TextBox3")).Text + ((TextBox)PreviousPage.FindControl("TextBox4")).Text;
        }
    }
}