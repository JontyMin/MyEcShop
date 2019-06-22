<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyEcShop.manage.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript">
    
</script>
    <title>
    </title>
     <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            color: white;
            background: #278296;
            font-size:12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table cellspacing="0" cellpadding="0" style="margin-top: 100px" align="center">
        <tr>
            <td>
                <img src="images/login.png" width="178" height="256" border="0" alt="ECSHOP" />
            </td>
            <td style="padding-left: 50px">
                <table>
                    <tr>
                        <td>
                            管理员姓名：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            管理员密码：
                        </td>
                        <td>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            验证码：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" class="capital"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                            <img src="CodeMa.aspx" width="145" height="20" alt="CAPTCHA" border="1"  style="cursor: pointer;"
                                title="看不清？点击更换另一个验证码。" onclick="this.src='CodeMa.aspx?a='+Math.random();"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="进入管理中心" class="button" 
                                onclick="Button1_Click"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    </div>
    </form>
</body>
</html>
