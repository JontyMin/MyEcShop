<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="flow.aspx.cs" Inherits="MyEcShop.flow" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
    function Del() {
        if (confirm("您确定要移出购物车吗？")) {
            return true;
        }
        return false;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<%--<form method="get" runat="server">--%>
<div>
<div>
            <h6>
                <span>商品列表</span></h6>
           
            <table align="center" width="99%" cellspacing="1" cellpadding="5" border="0" bgcolor="#dddddd" id="tb1">
                <tbody>
                <tr>
                 <th bgcolor="#ffffff">
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                                oncheckedchanged="CheckBox2_CheckedChanged" Text="全选" />
                        </th>
                        <th bgcolor="#ffffff">
                            
                            商品名称
                        </th>
                        <th bgcolor="#ffffff">
                            价格
                        </th>
                        <th bgcolor="#ffffff">
                            购买数量
                        </th>
                        <th bgcolor="#ffffff">
                            小计
                        </th>
                        <th bgcolor="#ffffff">
                            操作
                        </th>
                    </tr>
                    
                    <asp:Repeater ID="Repeater1" runat="server" 
                        onitemcommand="Repeater1_ItemCommand" >
                    <ItemTemplate>
                                <tr>
                                <td align="center" bgcolor="#ffffff">
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_OnCheckedChanged" AutoPostBack="true"/>
                        </td>
                    <td align="center" bgcolor="#ffffff">
                            <img border="0" width="100px" height="100px;" title="Visual C++2005入门经典" src='<%# Eval("BPic","BookImages/{0}") %> 'height="200px" width="200px"><br>
                           <%# Eval("BName") %>
                        </td>
                        <td align="right" bgcolor="#ffffff">
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("BPrice") %>'></asp:Label>
                        </td>
                        <td align="right" bgcolor="#ffffff">
                            <asp:TextBox ID="TextBox1" runat="server" style="text-align: center" class="inputBg" size="4" OnTextChanged="TextBox1_Changed" AutoPostBack="true" MaxLength="5" Text='<%# Eval("BCount") %>' onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}"></asp:TextBox>
                        </td>
                        <td align="right" bgcolor="#ffffff">
                            <asp:Label ID="lblSum" runat="server" Text='<%# Convert.ToSingle(Eval("BPrice")) * Convert.ToInt32(Eval("BCount"))%>' ></asp:Label>
                        </td>
                        <td align="center" bgcolor="#ffffff">
                            <asp:LinkButton class="f6"  ID="LinkButton1" runat="server" OnClientClick="return Del()" onclick="LinkButton_Click" CommandArgument='<%# Eval("TID") %>' CommandName='<%# Eval("BID") %>'>删除</asp:LinkButton>
                        </td>
                         </tr>
                    </ItemTemplate>
                    </asp:Repeater>
                    
                    
                </tbody>
            </table>
            <table align="center" width="99%" cellspacing="0" cellpadding="5" border="0" bgcolor="#dddddd">
                <tbody>
					<tr>
						<td align="right" bgcolor="#ffffff">
							<asp:Button ID="Button1" runat="server" Text="清空购物车" BackColor="#CCFFFF" BorderColor="#CCFFCC" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Overline="False" OnClick="Button1_Click" OnClientClick="return Del()" />
						</td>

					</tr>
                    <tr>
                        <td align="right" bgcolor="#ffffff">
                                <asp:ImageButton ID="ImageButton1" runat="server" src="images/checkout.gif" OnClick="ImageButton1_Click"/>
                        </td>
                    </tr>
                </tbody>
            </table>
        
        </div>
    </div>
<%--            </form>--%>
</asp:Content>
