<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goodLTypeAdd.aspx.cs" Inherits="MyEcShop.manage.goodLTypeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增大类别</title>
    <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1>
        <span class="action-span"><a href="goodSType.htm">商品小类别</a></span> <span class="action-span1">
            <a href="main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1">
                - 添加小类别 </span>
        <div style="clear: both">
        </div>
    </h1>
    <!-- start Type form -->
    <div class="tab-div">
        <!-- tab body -->
        <div id="tabbody-div">
            <!-- 通用信息 -->
            <table width="90%" id="general-table" align="center">
                <tr>
                    <td class="label">
                        大类别名称：
                    </td>
                    <td><asp:TextBox ID="TextBox1" runat="server" style="float: left; color: " size="30" ></asp:TextBox>
                        <span class="require-field">*</span><br />
                </tr>
            </table>
            <div class="button-div">
                <input type="hidden" name="goods_id" value="32" />
                <asp:Button ID="Button1" runat="server" Text="确定" class="button" 
                    onclick="Button1_Click"></asp:Button>
                <asp:Button ID="Button2" runat="server" Text="重置" class="button" 
                    onclick="Button2_Click"></asp:Button>
            </div>
        </div>
    </div>
    <!-- end Type form -->
    </div>
    </form>
</body>
</html>
