<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="false" CodeBehind="Category.aspx.cs" Inherits="MyEcShop.Category" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <font id="ECS_MEMBERZONE0">
    <asp:Repeater ID="Repeater1" runat="server" 
         >
        <ItemTemplate>
   

            <div class="flowBox">
                <table align="center" width="99%" cellspacing="1" cellpadding="5" border="0" bgcolor="#dddddd">
                    <tbody>
                        <tr>
                            <td align="center" bgcolor="#ffffff" rowspan="3" style="width: 100px;">
                                <a href="manage/goods.aspx"> <asp:ImageButton ID="ImageButton1" runat="server" 
                                    src='<%# "BookImages/"+Eval("BPic") %>' CssClass="goodsimg" Width="100px" 
                                    Height="100px" onclick="ImageButton1_Click" 
                                    CommandArgument='<%# Eval("BID") %>'/></a><br>
                            </td>
                            <td align="left" bgcolor="#ffffff">
                                书籍名：<%# Eval("BName") %></td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#ffffff" colspan="2">
                                书籍作者: <%# Eval("BAuthor") %>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#ffffff" colspan="2">
                                商品价格:<%# Eval("BPrice") %></td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#ffffff" colspan="2">
                                简介:<br />
                                 <textarea id="TextArea1" cols="20" rows="2" ><%# Eval("BComment") %></textarea>
                            </td>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            

        </ItemTemplate>
    </asp:Repeater>
    </font>
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
        CenterCurrentPageButton="True" FirstPageText="首页" LastPageText="尾页" 
        NextPageText="下一页" onpagechanging="AspNetPager1_PageChanging" 
        PageIndexBoxType="DropDownList" PageSize="4" PrevPageText="上一页" 
        ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" 
        TextBeforePageIndexBox="转到" UrlPaging="True" 
        onpagechanged="AspNetPager1_PageChanged">
    </webdiyer:AspNetPager>
</asp:Content>
