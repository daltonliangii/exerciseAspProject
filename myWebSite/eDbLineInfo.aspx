<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eDbLineInfo.aspx.cs" Inherits="eDbLineInfo" %>

<!--
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.1 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Line Info</title>
    
    <%=strRefresh%> 
    
    <link href="style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;height:100%;">
    <tr>
        <td style="white-space:nowrap;"><%fnGenLineInfo();%></td>
        <td style="width:98%;"><div id="divBtn" class="eDbLineInfo_div_btn" runat="server">
            <asp:GridView ID="GridView1" runat="server" 
                onselectedindexchanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            </div></td>
    </tr>
    </table>
    </form>
</body>
</html>
