<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyEcShop.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
    
</script>
	<style type="text/css">
		.auto-style1 {
			border-style: none;
			border-color: inherit;
			border-width: medium;
			background: url('images/bg.gif') no-repeat 0px -663px;
			width: 77px;
			text-align: center;
			line-height: 21px;
			color: #fff;
			cursor: pointer;
		}
		.auto-style2 {
			width: 67px;
		}
		.auto-style3 {
			border: 1px solid #b3b3b3;
			background: url('css/images/inputbg.gif') repeat-x left top;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table align="center" width="99%" cellspacing="1" cellpadding="5" border="0" bgcolor="#dddddd">
  <tbody>
                    <tr class="tl">
                        <td width="50%" valign="top" bgcolor="#ffffff">
                            <h6>
                                <span>用户登录：</span></h6>

                            <table width="90%" cellspacing="1" cellpadding="8" border="0" bgcolor="#B0D8FF" class="table">
                                <tbody>
                                    <tr>
                                        <td bgcolor="#ffffff">
                                            <div align="right">
                                                <strong>用户名</strong></div>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <asp:TextBox ID="TextBox1" CssClass="inputBg" runat="server" 
                                                ValidationGroup="2"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ControlToValidate="TextBox1" ErrorMessage="用户名不能为空!" 
                                                ValidationGroup="2">用户名不能为空!</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#ffffff">
                                            <div align="right">
                                                <strong>密码</strong></div>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            
                                            <asp:TextBox ID="TextBox2" CssClass="inputBg" runat="server" 
                                                ValidationGroup="2" TextMode="Password"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                ControlToValidate="TextBox2" ErrorMessage="密码不能为空!" 
                                                ValidationGroup="2">密码不能为空!</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td bgcolor="#ffffff">
                                            <div align="right">
                                                <strong>验证码</strong></div>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <font id="ECS_MEMBERZONE">
                    						<asp:Image ID="Image1" runat="server" ImageUrl="~/VerificationCode.aspx" Height="21px" Width="93px"/>
                                            
                                            </font>
                                            <asp:TextBox ID="TextBox7" CssClass="auto-style3" runat="server" 
                                                ValidationGroup="2" Width="43px" Height="16px"></asp:TextBox>
                                               <%-- &nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" 
                                                ErrorMessage="验证码错误" ValidationGroup="2" ControlToValidate="TextBox7" 
                                                Display="None" onservervalidate="CustomValidator1_ServerValidate1"></asp:CustomValidator>--%>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td bgcolor="#ffffff" colspan="2">
                                            <div align="center">
                                                
                                                <asp:Button ID="Button1" runat="server" CssClass="bnt_blue" Text="登录" 
                                                    onclick="Button1_Click" ValidationGroup="2" />
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                       
                        </td>
                        <td valign="top" bgcolor="#ffffff">
                            <h6>
                                <span class="auto-style2">用户注册：</span></h6>
                           
                            <table width="98%" cellspacing="1" cellpadding="8" border="0" bgcolor="#B0D8FF" class="table">
                                <tbody>
                                    <tr>
                                        <td align="right" width="25%" bgcolor="#ffffff">
                                            <strong>用户名</strong>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="inputBg" 
                                                AutoPostBack="True" ValidationGroup="1" ></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="TextBox3" Display="Dynamic" 
                                                ErrorMessage="用户名不能为空!" ValidationGroup="1">用户名不能为空!</asp:RequiredFieldValidator>
                                            <asp:Label ID="Label1" runat="server" ForeColor="#CC3300"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" bgcolor="#ffffff">
                                            <strong>电子邮件地址</strong>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="inputBg" 
                                                ValidationGroup="1"></asp:TextBox> 
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ControlToValidate="TextBox4" Display="Dynamic" 
                                                ErrorMessage="邮箱不能为空!" ValidationGroup="1">邮箱不能为空!</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                ControlToValidate="TextBox4" Display="None" 
                                                ErrorMessage="邮箱格式不正确!" 
                                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                ValidationGroup="1">邮箱格式不正确!</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" bgcolor="#ffffff">
                                            <strong>密码</strong>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="inputBg" 
                                                ValidationGroup="1" TextMode="Password"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="TextBox5" Display="Dynamic" 
                                                ErrorMessage="密码不能为空!" ValidationGroup="1">密码不能为空!</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" bgcolor="#ffffff">
                                            <strong>确认密码</strong>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="inputBg" 
                                                ValidationGroup="1" TextMode="Password"></asp:TextBox>
                                        &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                ControlToCompare="TextBox5" ControlToValidate="TextBox6" 
                                                ErrorMessage="密码不一致!" ValidationGroup="1">密码不一致!</asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" bgcolor="#ffffff" colspan="2">
                                            <asp:Button ID="Button2" runat="server" Text="注册新用户" CssClass="auto-style1" 
                                                onclick="Button2_Click" ValidationGroup="1" Height="21px"/>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                           
                        </td>
                    </tr>
                </tbody>
</table>
</asp:Content>
