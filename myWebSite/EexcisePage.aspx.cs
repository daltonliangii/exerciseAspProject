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
            
            //Session["PageID"] = "2";// this.PageID.Text.ToString();
           // Application["PageID"] = "2";
        
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string tt = Request.Form["TextBox3"] + " - " + Request.Form["TextBox4"];
            string url;
            url = "eDbLineInfo.aspx?PageID=" + PageID.Text + "&Line=" + Line.Text + "&Model=" + Model.Text + "&ProjectID=" + ProjectID.Text;
            Response.Redirect(url);
            //Label2.Text = tt;
        }

        protected void PageID_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string url;
            url = "eDbLineInfo.aspx?PageID=" + PageID.Text + "&Line=" + Line.Text + "&Model=" + Model.Text + "&ProjectID=" + ProjectID.Text;
            Response.Redirect(url);

        }


    }
}