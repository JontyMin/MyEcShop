<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goodAdd.aspx.cs" Inherits="MyEcShop.manage.goodAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加商品</title>
     <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
    <h1>
<span class="action-span"><a href="goods.aspx">商品列表</a></span>
<span class="action-span1"><a href="main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1"> - 添加商品信息 </span>
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
    <div id="tabbody-div">
        <!-- 通用信息 -->
        <table width="90%" id="general-table" align="center">
          <tr>
            <td class="label">商品名称：</td>
            <td><asp:TextBox ID="txtName" runat="server" size="20" MaxLength="20"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" runat="server" ErrorMessage="请填写商品名称"></asp:RequiredFieldValidator>
			  </td>
          </tr>
          <tr>
            <td class="label">商品货号：</td>
            <td><span
      </p>
                <asp:TextBox ID="txtbisd" runat="server" size="20" MaxLength="20"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtbisd" runat="server" ErrorMessage="请填写商品货号"></asp:RequiredFieldValidator>
			  </td>
          </tr>
          <tr>
            <td class="label">作者：</td>
            <td><span
      </p>
                <asp:TextBox ID="txtAuthor" runat="server" size="20" MaxLength="20"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAuthor" runat="server" ErrorMessage="请填写商品作者"></asp:RequiredFieldValidator>
			  </td>
          </tr>
          <tr>
            <td class="label">商品小类：</td>
            <td><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <span class="require-field">*</span>            </td>
          </tr>
          <tr>
            <td class="label">商品价格：</td>
            <td><asp:TextBox ID="txtPrice" runat="server" MaxLength="10"></asp:TextBox>
			<asp:RequiredFieldValidator ControlToValidate="txtPrice" ID="RequiredFieldValidator4" runat="server" ErrorMessage="请输入商品价格"></asp:RequiredFieldValidator>
          	 <%-- <asp:RegularExpressionValidator  ID="RegularExpressionValidator1" ControlToValidate="txtPrice" ValidationExpression="^-?\d+$" runat="server" ErrorMessage="价格只能为数字"></asp:RegularExpressionValidator>--%>
				<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPrice" Type="Double" ErrorMessage="价格只能为数字"></asp:CompareValidator>
          </tr>
          <tr>
            <td class="label">上传商品图片：</td>
            <td>
              <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>

            </td>
          </tr>
          <tr>
            <td class="label">商品库存：</td>
            <td><asp:TextBox ID="txtBcount" runat="server" MaxLength="10"></asp:TextBox>
				<asp:RequiredFieldValidator ControlToValidate="txtBcount" ID="RequiredFieldValidator5" runat="server" ErrorMessage="请输入商品库存"></asp:RequiredFieldValidator>
          	  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtBcount" ValidationExpression="^-?\d+$" runat="server" ErrorMessage="库存只能为整数"></asp:RegularExpressionValidator>
          	  
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
    </div>
    </form>
</body>
</html>
