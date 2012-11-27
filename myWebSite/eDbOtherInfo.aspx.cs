using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DBUtility;

public partial class eDbOtherInfo : System.Web.UI.Page// GeneralFunc.GeneralFunc
{
    public string strRefresh = "";
    private int iRefreshInv = 0;

    private string strPageID;
    private string strLine;
    private string strModel;
    private string strProjectID;
    private string strActiveLine;
    private string strDBConn;
    private DBUtility.SQLHelper sqlh;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlh = new SQLHelper();
        strDBConn=sqlh.ConnString;
        string strRefreshInv = (Request.QueryString["RefreshInv"] != null) ? Request.QueryString["RefreshInv"].ToString().Replace("\"", "").Trim() : "0";
        if (strRefreshInv != "0")
        {
            try
            {
                iRefreshInv = Convert.ToInt32(strRefreshInv);
                if (iRefreshInv < 1) iRefreshInv = 0;
            }
            catch
            {
                iRefreshInv = 0;
            }
        }
        if (iRefreshInv > 0)
        {
            strRefresh = "<meta http-equiv=\"refresh\" content=\"" + iRefreshInv.ToString() + "\">";
        }
        //strPageID = Session["PageID"].ToString();
        //strPageID = Request.QueryString["PageID"].ToString();
        strPageID = (Request.QueryString["PageID"] != null) ? Request.QueryString["PageID"].ToString().Replace("\"", "").Trim() : "";
        strLine = (Request.QueryString["Line"] != null) ? Request.QueryString["Line"].ToString().Replace("\"", "").Trim() : "";
        strModel = (Request.QueryString["Model"] != null) ? Request.QueryString["Model"].ToString().Replace("\"", "").Trim() : "";
        strProjectID = (Request.QueryString["ProjectID"] != null) ? Request.QueryString["ProjectID"].ToString().Replace("\"", "").Trim() : "";
        //strActiveLine = (Request.QueryString["ActiveLine"] != null) ? Request.QueryString["ActiveLine"].ToString().Replace("\"", "").Trim().ToLower() : "0";

        //if (!IsPostBack)
        //{
        //    btnSave.Attributes.Add("onmouseover", "this.src='Images/Save1_1.gif'");
        //    btnSave.Attributes.Add("onmouseout", "this.src='Images/Save1.gif'");
        //}
    }

    public void fnGenLineInfo()
    {

            
            SqlConnection  myConnection=new SqlConnection();
            myConnection.ConnectionString= sqlh.ConnString ;
            SqlCommand myCommand = new SqlCommand("uspEdbGetUPH");
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 6000;

            SqlParameter myParameter1 = new SqlParameter("@sqlxml", SqlDbType.VarChar, 2000);
            SqlParameter myParameter2 = new SqlParameter("@msg", SqlDbType.NVarChar, 4000);
            SqlParameter myParameter3 = new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4);
            
            myParameter1.Direction = ParameterDirection.Input;
            myParameter2.Direction = ParameterDirection.Output;
            myParameter3.Direction = ParameterDirection.ReturnValue;

            myCommand.Parameters.Add(myParameter1);
            myCommand.Parameters.Add(myParameter2);
            myCommand.Parameters.Add(myParameter3);

                  
            myCommand.Parameters["@sqlxml"].Value = "<eDb><data PageID=\"" + strPageID + "\" Line=\"" + strLine + "\" Model=\"" + strModel + "\" ProjectID=\"" + strProjectID + " \"/></eDb>";

            try
            {
                SqlDataAdapter adapter1 = new SqlDataAdapter(myCommand);
                DataSet set1 = new DataSet();
                try
                {
                    adapter1.Fill(set1);

                    int iRn = Convert.ToInt32(myCommand.Parameters["@RETURN_VALUE"].Value);

                    Response.Write(set1.DataSetName );

                    if (myCommand.Parameters["@msg"].Value.ToString() != "") Response.Write(myCommand.Parameters["@msg"].Value.ToString());//this.ShowAlertMessage(myCommand.Parameters["@msg"].Value.ToString());
                }
                catch (SqlException ex3)
                {
                    Response.Write(ex3.Message.Replace("\r", "\\r").Replace("\n", "\\n"));
                    //this.ShowAlertMessage(ex3.Message.Replace("\r", "\\r").Replace("\n", "\\n"));
                }
                finally
                {
                    set1 = null;

                    myConnection.Close();
                    myConnection.Dispose();
                }

            }
            catch (Exception ex)
            {
                string strErrMsg = ex.Message.Replace("\r", "\\r").Replace("\n", "\\n");
                if (strErrMsg.ToUpper().IndexOf("TABLE 0") > 0)
                    strErrMsg = myCommand.Parameters["@msg"].Value.ToString();
                if (strErrMsg != "") Response.Write(strErrMsg);// this.ShowAlertMessage(strErrMsg);
            }
  
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (strProjectID != "" && strModel != "" && strLine != "")
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(strDBConn);
                myConnection.Open();

                //SqlCommand myCommand = new SqlCommand(sSQL);
                //myCommand.Connection = myConnection;
                //myCommand.CommandType = CommandType.Text;

                SqlCommand myCommand = new SqlCommand("uspEdbSaveLineInfo");
                myCommand.Connection = myConnection;
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandTimeout = 6000;

                SqlParameter myParameter1 = new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4);
                SqlParameter myParameter2 = new SqlParameter("@sqlxml", SqlDbType.NVarChar, 2000);
                SqlParameter myParameter3 = new SqlParameter("@msg", SqlDbType.NVarChar, 2000);

                myParameter1.Direction = ParameterDirection.ReturnValue;
                myParameter2.Direction = ParameterDirection.Input;
                myParameter3.Direction = ParameterDirection.Output;

                myCommand.Parameters.Add(myParameter1);
                myCommand.Parameters.Add(myParameter2);
                myCommand.Parameters.Add(myParameter3);

                string strK = "K=\"", strV = "V=\"";
                for (int i = 0; i < Request.Form.AllKeys.Length; i++)
                {
                    if (Request.Form.Keys[i].Substring(0, 1).ToUpper() == "K")
                    {
                        strK += Request.Form.Keys[i].ToUpper().Replace("K", "") + "#|";
                        strV += Request.Form[i].Trim().Replace("\"","") + "#|";
                        //strK += Request.Form.Keys[i].ToUpper() + "=\"" + Request.Form[i].Trim() + "\" ";
                    }
                }
                if (strK.Substring(strK.Length - 2) == "#|")
                {
                    strK = strK.Substring(0, strK.Length - 2) + "\"";
                    strV = strV.Substring(0, strV.Length - 2) + "\"";
                }

                myCommand.Parameters["@sqlxml"].Value = "<eDb><data Line=\"" + strLine + "\" Model=\"" + strModel + "\" ProjectID=\"" + strProjectID + "\" " + strK + " " + strV + " /></eDb>";

                myCommand.ExecuteNonQuery();

                myConnection.Close();
                myConnection.Dispose();

                int iRet = Convert.ToInt32(myCommand.Parameters["@RETURN_VALUE"].Value.ToString());
                string strMsg = myCommand.Parameters["@msg"].Value.ToString().Replace("\r", "\\r").Replace("\n", "\\n").ToString();

                if (strMsg != "")
                {
                    Response.Write(strMsg);
                    //this.ShowAlertMessage(strMsg);
                }
            }
            catch { }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
