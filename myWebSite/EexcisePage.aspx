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
        .style2
        {
            width: 100%;
            border-collapse: collapse;
            border: 1px solid #008000;
            background-color: #808080;
        }
        .style3
        {
        }
        .style4
        {
            height: 15px;
            width: 191px;
        }
        .style5
        {
            width: 191px;
        }
        .style6
        {
            height: 15px;
            width: 212px;
        }
        .style7
        {
            width: 212px;
        }
        .style8
        {
            width: 132px;
        }
        #Reset2
        {
            width: 100px;
        }
        #Submit2
        {
            width: 155px;
        }
        .style10
        {
            height: 15px;
            width: 48px;
        }
        .style11
        {
            width: 48px;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[



// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server" action="resultPage.aspx"  >
    <div style="height: 81px; font-weight: bold; font-size: large; background-color: #008080; clip: rect(auto, auto, auto, auto);">
        Head</div>
    <div style="height: 500px" class="style1">
    
        &nbsp;<table align="left" class="style2">
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style4">
                    Enter Your First Name:</td>
                <td class="style6">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td class="style8" rowspan="4">
                    <asp:Button ID="Button1" runat="server"  Text="Button" PostBackUrl ="~/resultPage.aspx" />
                </td>
                <td class="style3" rowspan="4">
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style5">
                    Enter Your Last Name:</td>
                <td class="style7">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style5">
                    Your Full Name is:</td>
                <td class="style7">
                    <asp:Label ID="Label2" runat="server" Text="Label" ViewStateMode="Enabled" 
                        Width="90px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style5">
                    <input id="Reset2" type="reset" value="reset" /></td>
                <td class="style7">
                    <input id="Submit2" type="submit" value="submit"/></td>
            </tr>
        </table>
    </div>
    </form>
    <div id="footDiv" 
        
        style="height: 75px; background-color: #C0C0C0; clip: rect(auto, auto, auto, auto);">
        foot</div>
</body>
</html>
