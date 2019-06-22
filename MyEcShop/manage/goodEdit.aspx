<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goodEdit.aspx.cs" Inherits="MyEcShop.manage.goodEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
<span class="action-span"><a href="goods.aspx">商品列表</a></span>
<span class="action-span1"><a href="main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1"> - 编辑商品信息 </span>
<div style="clear:both"></div>
</h1>

<!-- start goods form -->
<div class="tab-div">
    <!-- tab bar -->
    <div id="tabbar-div">
      <p>
        <span class="tab-front" id="general-tab">通用信息</span><span
      </p>
    </div>

    <!-- tab body -->
      </div>
        <!-- 通用信息 -->
        <span
      </p>
        <table width="90%" id="general-table" align="center">
          <tr>
            <td class="label">商品名称：</td>
            <td><asp:TextBox ID="txtName" runat="server" size="20"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="label">商品货号：</td>
            <td><span
      </p>
                <asp:TextBox ID="txtbisd" runat="server" size="20"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="label">作者：</td>
            <td><span
      </p>
                <asp:TextBox ID="txtAuthor" runat="server" size="20"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="label">商品小类：</td>
            <td><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <span class="require-field">*</span>            </td>
          </tr>
          <tr>
            <td class="label">商品价格：</td>
            <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
          </tr>
          <tr>
            <td class="label">上传商品图片：</td>
            <td>
              <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
            </td>
          </tr>
          <tr>
            <td class="label">商品库存：</td>
            <td><asp:TextBox ID="txtBcount" runat="server"></asp:TextBox>
          </tr>
        </table>
        </span>
        <div class="button-div">
           <asp:Button ID="Button1" runat="server" Text="确定" class="button" 
                onclick="Button1_Click"></asp:Button>
          <asp:Button ID="Button2" runat="server" Text="重置" class="button" 
                onclick="Button2_Click"></asp:Button>
        </div>
      </form>
    </div>
</div>
<!-- end goods form -->
    </div>
    </form>
</body>
</html>
