<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="consignee.aspx.cs" Inherits="MyEcShop.consignee" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h6>
                <span>商品列表</span></h6>
            <table align="center" width="99%" cellspacing="1" cellpadding="5" border="0" bgcolor="#dddddd">
                <tbody>
                    <tr>
                        <th bgcolor="#ffffff" colspan="2">
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
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                                <tr>
                    <td align="left" bgcolor="#ffffff">
                        <asp:ImageButton ID="ImageButton1" runat="server"  title='<%# Eval("BName") %>'  ImageUrl='<%# "BookImages/"+ Eval("BPic") %> ' Height="80px" Width="80px" CommandArgument='<%# Eval("BID") %>'/>
                           </td>
									<td align="left" bgcolor="#ffffff">
						<%# Eval("BName") %>
                        </td>
                        <td align="right" bgcolor="#ffffff">
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("BPrice") %>'></asp:Label> 
                        </td>
                        <td align="right" bgcolor="#ffffff">
                            <asp:Label ID="lblBCount" runat="server" Text='<%# Eval("BCount") %>'></asp:Label>
                        </td>
                        <td align="right" bgcolor="#ffffff">
                           <asp:Label ID="lblSum" runat="server" Text='<%# Convert.ToInt32(Eval("BPrice")) * Convert.ToInt32(Eval("BCount"))%>' ></asp:Label>
                        </td>
                         </tr>
                    </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            
             <div class="block">
        <div class="flowBox">
            <h6>
                <span>收货人信息</span></h6>
            <table align="center" width="99%" cellspacing="1" cellpadding="5" border="0" bgcolor="#dddddd">
                <tbody>
                    <tr>
                        <td bgcolor="#ffffff">
                            收货人姓名:
                        </td>
                        <td bgcolor="#ffffff">
                            <asp:TextBox ID="txtName" runat="server" class="inputBg"></asp:TextBox>
                            (必填)
                        </td>
                        <td bgcolor="#ffffff">
                            详细地址:
                        </td>
                        <td bgcolor="#ffffff">
                            <asp:TextBox ID="txtAddress" runat="server" class="inputBg"></asp:TextBox>
                            (必填)
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#ffffff">
                            电话:
                        </td>
                        <td bgcolor="#ffffff">
                            <asp:TextBox ID="txtTel" runat="server" class="inputBg"></asp:TextBox>
                            (必填)
                        </td>
                        <td bgcolor="#ffffff">
                            总金额:
                        </td>
                        <td bgcolor="#ffffff">
                            <asp:Label ID="Label1" runat="server" Text="0"></asp:Label></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#ffffff" colspan="4">
                            <asp:Button ID="Button1" class="bnt_blue_2" runat="server" Text="配送至这个地址" OnClick="Button1_Click" Width="139px"/>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
