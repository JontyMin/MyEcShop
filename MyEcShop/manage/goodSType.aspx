<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goodSType.aspx.cs" Inherits="MyEcShop.manage.goodSType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function del() {
            if (confirm("您确定要删除吗？")) {
                return true;
            }
            return false;
        }
    </script>
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
        <span class="action-span1"><a href="main.aspx">ECSHOP 管理中心</a></span><span id="search_id"
            class="action-span1"> - 商品小类别 </span>
        <div style="clear: both">
        </div>
    </h1>
    <!-- 商品搜索 -->
    <div class="form-div">
        <input type="button" value=" 显示所有小类别" class="button" />
        <asp:Button ID="Button1" runat="server" Text="小类别添加" class="button" 
            onclick="Button1_Click"/>
    </div>
        
    <!-- 商品列表 -->
    <!-- start goods list -->
    <div class="list-div" id="listDiv">
        <table cellpadding="3" cellspacing="1">
            <tr>
                <th>
                    小类别名称
                </th>
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
                            <%# Eval("BSName")%>
                        </td>
                        <td>
                            <%# Eval("BLName")%>
                        </td>
                        <td align="center">
                            <a href='goodSTypeUpdate.aspx?BSID=<%# Eval("BSID")%>&BSName=<%#Eval("BSName")%>&BLID=<%#Eval("BLID") %>' title="编辑">
                                <img src="images/icon_edit.gif" width="16" height="16" border="0" /></a> 
                                <a><asp:ImageButton ID="ImageButton2" runat="server" OnClick="ImageButton1_Click" src="images/icon_trash.gif" CommandArgument='<%# Eval("BSID") %>' title="回收站" OnClientClick="return del()"/></a>
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
