<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="MyEcShop.manage.OrderDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单列表</title>
    <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1>
        <span class="action-span"><a href="Orders.aspx">订单列表</a></span> <span class="action-span1">
            <a href="main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1">
                - 订单信息 </span>
        <div style="clear: both">
        </div>
    </h1>
    <div class="list-div" style="margin-bottom: 5px">
    <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
             <table width="100%" cellpadding="3" cellspacing="1">
            <tr>
                <th colspan="4">
                    收货信息
                </th>
            </tr>
            <tr>
                <td width="18%">
                    <div align="right">
                        <strong>订单号：</strong></div>
                </td>
                <td width="34%">
                   <%# Eval("OID") %>
                </td>
                <td width="15%">
                    <div align="right">
                        <strong>订单状态：</strong></div>
                </td>
                <td>
                    <%# Eval("state")%>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>收货人：</strong></div>
                </td>
                <td>
                     <%# Eval("OConsignee")%>
                </td>
                <td>
                    <div align="right">
                        <strong>订单时间：</strong></div>
                </td>
                <td>
                     <%# Eval("ODate")%>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>送货地址：</strong></div>
                </td>
                <td>
                    <%# Eval("OAddress")%>
                </td>
                <td>
                    <div align="right">
                        <strong>联系电话：</strong></div>
                </td>
                <td>
                        <%# Eval("OTelephone")%>
                </td>
            </tr>
        </table>
            </ItemTemplate>
            </asp:Repeater>
       
    </div>
    <div class="list-div" style="margin-bottom: 5px">
        
            <table width="100%" cellpadding="3" cellspacing="1">
            <tr>
                <th colspan="7" scope="col">
                    商品信息
                </th>
            </tr>
            <tr>
                <td scope="col">
                    <div align="center">
                        <strong>订单号</strong></div>
                </td>
                <td scope="col">
                    <div align="center">
                        <strong>书籍编号</strong></div>
                </td>
                <td scope="col">
                    <div align="center">
                        <strong>价格</strong></div>
                </td>
                <td scope="col">
                    <div align="center">
                        <strong>数量</strong></div>
                </td>
            </tr>
            <asp:Repeater ID="Repeater2" runat="server" 
                    onitemdatabound="Repeater2_ItemDataBound">
        <ItemTemplate>
            <tr>
                <td align="center">
                    <%# Eval("OID")%>
                </td>
                <td align="center">
                    <%# Eval("BID")%>
                </td>
                <td>
                    <div align="center">
                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("BPrice")%>'></asp:Label>
                        </div>
                </td>
                <td>
                    <div align="center">
                     <asp:Label ID="lblCount" runat="server" Text=' <%# Eval("BCount")%>'></asp:Label>
                         
                    </div>
                </td>
            </tr>
            
         </ItemTemplate>
        </asp:Repeater>
        <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <div align="right">
                        <strong>合计：</strong></div>
                </td>
                <td>
                    <div align="right">
                    ￥ 
                        <asp:Label ID="lblCountPrice" runat="server" Text="Label"></asp:Label>
                       </div>
                </td>
            </tr>
        </table>
    </div>
    </div>
    </form>
</body>
</html>
