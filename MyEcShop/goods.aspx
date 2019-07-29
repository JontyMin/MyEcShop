<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="goods.aspx.cs" Inherits="MyEcShop.goods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" 
        >
    <ItemTemplate>
            <div class="clearfix" id="goodsInfo">
                <div class="imgInfo">
                    <img alt='<%# Eval("BPic","BookImages/{0}") %>' src='<%# Eval("BPic","BookImages/{0}") %> ' width="200px" height="200px"/>
                </div>
                <!--书籍简要介绍-->
                <div class="textInfo">
                    <div class="clearfix">
                        <p class="f_l">
                            <%#Eval("BName") %></p>
                    </div>
                    <ul>
                        <li class="clearfix">
                            <dd>
                                <strong>书籍货号：</strong><%# Eval("BISBN") %></dd>
                            <dd class="ddR">
                                <strong>书籍库存：</strong> <font color="red"><%# Eval("BCount") %></font>
                            </dd>
                        </li>
                        <li class="clearfix">
                            <dd>
                                <strong>书籍作者：</strong><%# Eval("BAuthor") %></dd>
                            <dd class="ddR">
                                <strong>书籍价格：</strong><font id="Font1" class="shop"><%# Eval("BPrice") %></font></dd>
                        </li>
                        <li class="clearfix">
                            <dd>
                                <strong>购买数量：</strong> <asp:TextBox ID="TextBox1" runat="server" style="text-align: center" class="inputBg" size="4" AutoPostBack="true" OnTextChanged="TextBox1_Changed" MaxLength="8"  onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}">1</asp:TextBox>
                            </dd>
                            <dd class="ddR">
                            </dd>
                        </li>
                        <li class="padd">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/bnt_cat.gif" OnClick="ImageButton1_Click" />
                         </li>
                    </ul>
                </div>
            </div>
            <!--书籍简介介绍-->
            <div class="textInfo">
                <div class="clearfix">
                    <p class="f_l">
                        <font color="red">书籍简介:</font></p>
                </div>
                <ul>
                    <li class="clearfix">
                        <dd>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("BComment")%>'></asp:Label>
                        </dd>
                    </li>
                </ul>
            </div>
            <!--书籍描述介绍-->
            <div class="textInfo">
                <div class="clearfix">
                    <p class="f_l">
                       <font color="red">书籍描述:</font></p>
                </div>
                <ul>
                    <li class="clearfix">
                        <dd>
                             <asp:Label ID="Label2" runat="server" Text='<%# Eval("BTOC")%>'></asp:Label>
                        </dd>
                    </li>
                </ul>
            </div>
    </ItemTemplate>
    </asp:Repeater>

</asp:Content>
