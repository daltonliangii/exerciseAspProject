<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="myWebSite._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        #Checkbox1
        {
            width: 19px;
        }
        #Checkbox2
        {
            width: 21px;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Submit1_onclick() {
            
        }

// ]]>
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
        <input id="Text1" type="text" /></p>
    <p>
        <input id="Checkbox1" type="checkbox" name="QQ" title ="title" value="value" checked ="checked"/> Open QQ</p>
    <p>
        <input id="Checkbox2" type="checkbox" name="MSN"/> Open MSN</p>
    <p>
        <input id="Submit1" type="submit" value="submit" onclick="return Submit1_onclick()" /></p>
</asp:Content>
