<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="MyEcShop.manage.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ECSHOP管理中心</title>
    <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1>
        <span class="action-span1"><a href="main.htm">ECSHOP 管理中心</a> </span><span
            id="search_id" class="action-span1"></span>
        <div style="clear: both">
        </div>
    </h1>
    <div class="list-div">
        <table cellspacing='1' cellpadding='3'>
            <tr>
                <th colspan="4" class="group-title">
                    订单统计信息
                </th>
            </tr>
            <tr>
                <td width="20%">
                    新订单:
                </td>
                <td width="30%">
                    <strong style="color: red">
                       <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></strong>
                </td>
                <td width="20%">
                    确认订单:
                </td>
                <td width="30%">
                    <strong><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></strong>
                </td>
            </tr>
            <tr>
                <td>
                    发货订单:
                </td>
                <td>
                    <strong><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></strong>
                </td>
                <td>
                    成交订单数:
                </td>
                <td>
                    <strong><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></strong>
                </td>
            </tr>
        </table>
    </div>
    <br />
    </div>
    </form>
</body>
</html>
