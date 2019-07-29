<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goodLType.aspx.cs" Inherits="MyEcShop.manage.goodLType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商品大类别</title>
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
            text-align: center;
        }
        th
        {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="get">
    <div>
     <h1>
        <span class="action-span"><a href="goodSTypeAdd.aspx">添加小类别</a></span> <span class="action-span1">
            <a href="main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1">
                - 商品大类别 </span>
        <div style="clear: both">
        </div>
    </h1>
    <!-- 商品搜索 -->
    <div class="form-div">
      
        商品大类别
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="添加" class="button" 
            onclick="Button1_Click" BorderWidth="1px" Width="86px"></asp:Button>
  
    </div>
    <!-- 商品列表 -->
    <!-- start goods list -->
    <div class="list-div" id="listDiv">
        <table cellpadding="3" cellspacing="1">
            <tr>
                <th>
                    大类别名称
                </th>
                <th>
                    操作
                </th>
                </tr>
            <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                        <td>
                            <%# Eval("BLName") %>
                        </td>
                       <td align="center">
                           <a href='goodLTypeEdit.aspx?BLID=<%# Eval("BLID") %>&BLName=<%#Eval("BLName") %>' title="编辑">
                                <img src="images/icon_edit.gif" width="16" height="16" border="0" /></a>
                           <a><asp:ImageButton ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" src="images/icon_trash.gif" CommandArgument='<%# Eval("BLID") %>' title="回收站" OnClientClick="return del()"/></a>
                           <a><asp:ImageButton ID="ImageButton3" runat="server" OnClick="ImageButton3_Click" PostBackUrl="goodSType.aspx" src="images/icon_view.gif" CommandArgument='<%# Eval("BLID") %>' title="查看小类别"/></a>
                        </td>
                    </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
        <!-- end goods list -->
    </div>
    </div>
    </form>
</body>
</html>
