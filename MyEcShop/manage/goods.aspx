<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goods.aspx.cs" Inherits="MyEcShop.manage.goods" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商品列表</title>
    <script type="text/javascript">
		function del() {
			if (confirm("您确定要删除吗？")) {
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
          text-align:center;
        }
        th
        {
           font-weight:bold;
        }
        .style1
        {
            height: 58px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
        <span class="action-span"><a href="goodAdd.aspx">添加新商品</a></span> <span class="action-span1">
            <a href="main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1">
                - 商品列表 </span>
        <div style="clear: both">
        </div>
    </h1>
    <!-- 商品搜索 -->
    <div class="form-div">
        商品名
        <asp:TextBox ID="TextBox1" runat="server" size="15"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="搜索" class="button" 
            onclick="Button1_Click"/>
    </div>
    <!-- 商品列表 -->
        
    <!-- start goods list -->
    <div class="list-div" id="listDiv">
        <table cellpadding="3" cellspacing="1">
            <tr>
                <th>
                    编号
                </th>
                <th colspan="2">
                    商品名称
                </th>
                <th>
                    ISBN
                </th>
                <th>
                    价格
                </th>
                <th>
                    库存
                </th>
                <th>
                    操作
                </th>
                </tr>
             <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <tr>
                <td>
                    4976
                </td>
                <td align="left">
                    <img src= "../BookImages/<%# Eval("BPic") %> " width="50px" height="50px" />
                </td>
			<td> <%# Eval("BName") %></td>
                <td>
                    <span><%# Eval("BISBN") %></span>
                </td>
                <td align="right">
                    <span><%# Eval("BPrice") %></span>
                </td>
                <td align="center">
                    <span><%# Eval("BCount") %></span>
                </td>
                <td align="center">
                       <a href='goodEdit.aspx?BID=<%# Eval("BID") %>'> <img alt="" src="images/icon_edit.gif" width="16" height="16" border="0" /></a>
                    <asp:ImageButton ID="ImageButton1" src="images/icon_trash.gif" runat="server" width="16" height="16" border="0" OnClientClick=" return del()" OnClick="ImageButton1_Click" CommandArgument='<%# Eval("BID") %>'></asp:ImageButton>
                </td>
            </tr>
        </ItemTemplate>
        </asp:Repeater>
        </table>
       
        <!-- end goods list -->
        <!-- 分页 -->
        <table id="page-table" cellspacing="0">
            <tr>
                <td align="right" nowrap="true">
                    <div id="turn-page">
     
                        <font id="ECS_MEMBERZONE">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
        CenterCurrentPageButton="True" FirstPageText="首页" LastPageText="尾页" 
        NextPageText="下一页" onpagechanging="AspNetPager1_PageChanging" 
        PageIndexBoxType="DropDownList" PageSize="4" PrevPageText="上一页" 
        ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" 
        TextBeforePageIndexBox="转到" UrlPaging="True" onpagechanged="AspNetPager1_PageChanged">
    </webdiyer:AspNetPager>
    
                        </font>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </div>
    </form>
</body>
</html>
