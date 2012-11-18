<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EexcisePage.aspx.cs" Inherits="myWebSite.EexcisePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #footDiv
        {
            height: 200px;
        }
        #Text1
        {
            height: 26px;
            width: 282px;
        }
        .style1
        {
            text-align: left;
        }
        #Reset1
        {
            width: 54px;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[



// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server" action="/EexcisePage.aspx">
    <div style="height: 81px; font-weight: bold; font-size: large; background-color: #008080; clip: rect(auto, auto, auto, auto);">
        Head</div>
    <div style="height: 500px" class="style1">
    
        Enter your first name:
        <asp:TextBox ID="TextBox1" runat="server" Width="157px"></asp:TextBox>
        <br />
        <br />
        Enter your last name:&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Width="157px"></asp:TextBox>
        <br />
        <br />
        Your Full name is:&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" BackColor="#33CCFF" Width="155px">label</asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Submit1" type="submit" value="submit" onclick="" />&nbsp;&nbsp;
        <input id="Reset1" type="reset" value="reset" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
    </form>
    <div id="footDiv" 
        
        style="height: 75px; background-color: #C0C0C0; clip: rect(auto, auto, auto, auto);">
        foot</div>
</body>
</html>
