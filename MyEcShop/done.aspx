<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="done.aspx.cs" Inherits="MyEcShop.done" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="box_1">
                <h3>
                    <span>系统信息</span></h3>
                <div align="center" class="boxCenterList RelaArticle">
                    <div style="margin: 20px auto;">
                        <p style="font-size: 14px; font-weight: bold; color: red;">
                            订单号：
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></p>
                        <div class="blank">
                        </div>

                    </div>
                </div>
            </div>
</asp:Content>

