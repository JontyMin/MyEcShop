<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="MyEcShop.Orders" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单列表</title>
    <script type="text/javascript">
        function que() {
            if (confirm("您确定要执行吗?")) {
                return true;
            }
            return false;
        }
    </script>
    <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        td
        {
            text-align: center;
        }
        th
        {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1>
        <span class="action-span1"><a href="main.htm">ECSHOP 管理中心</a> </span><span id="search_id"
            class="action-span1">- 订单列表 </span>
        <div style="clear: both">
        </div>
    </h1>
    <!-- 商品搜索 -->
    <div class="form-div">
        </div>
        订单号
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        收货人
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="搜索" class="button" 
            onclick="Button1_Click"/>
    </div>
    <!-- 商品列表 -->
    <!-- start goods list -->
    <div class="list-div" id="listDiv">
        <table cellpadding="3" cellspacing="1">
            <tr>
                <th>
                    订单号
                </th>
                <th>
                    订单时间
                </th>
                <th>
                    收货人
                </th>
                <th>
                    总金额
                </th>
                <th>
                    订单状态
                </th>
                <th>
                    操作
                </th>
                </tr>
            <asp:Repeater ID="Repeater1" runat="server" 
                onitemdatabound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <tr>
                <td>
                    <%# Eval("OID") %>
                </td>
                <td align="left">
                    <%# Eval("ODate") %>
                </td>
                <td>
                    <%# Eval("OConsignee")%>
                </td>
                <td align="right">
                    <%# Eval("OSumPrice")%>
                </td>
                 <td align="right">
                  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                     <asp:Button ID="Button2" runat="server" Text="订单确定" OnClick="Button2_Click" CommandArgument='<%# Eval("OState") %>' CommandName='<%# Eval("OID") %>' OnClientClick="return que()"/>
                </td>
                <td align="center">
                    <a href='OrderDetail.aspx?OID=<%# Eval("OID") %>' title="查看">
                        <img src="images/icon_view.gif" width="16" height="16" border="0" /></a> 
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
        <!-- end goods list -->
        <!-- 分页 -->
        
  <center>
                   <font id="ECS_MEMBERZONE">
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
        CenterCurrentPageButton="True" FirstPageText="首页" LastPageText="尾页" 
        NextPageText="下一页" onpagechanging="AspNetPager1_PageChanging" 
        PageIndexBoxType="DropDownList" PageSize="5" PrevPageText="上一页" 
        ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" 
        TextBeforePageIndexBox="转到" UrlPaging="True">
    </webdiyer:AspNetPager>
                    </font>
  </center>
    </div>
    </form>
    </div>
    </form>
</body>
</html>
