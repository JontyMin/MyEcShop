<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="MyEcShop.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
    window.onLoad = adv();
    var NowFrame = 1;
    var MaxFrame = 9;
    function adv() {
        for (var i = 1; i <= MaxFrame; i++) {
            if (i == NowFrame)
                document.getElementById('img' + NowFrame).style.display = 'block';
            else
                document.getElementById('img' + i).style.display = 'none';
        }
        {
            if (NowFrame == MaxFrame)
                NowFrame = 1;
            else
                NowFrame = NowFrame + 1;
        }
        setTimeout('adv()', 1000);
    }
</script>
<style type="text/css">
        dt, dl
        {
            margin: 0px;
            padding: 0px;
        }
        dd
        {
            margin-left: 40px;
        }
        .flash1
        {
            width: 387px;
            height: 200px;
        }
    </style>
            <div class="blank5">
            </div>
            <div class="box clearfix">
                <a href="Category.aspx"><center><img src="img/20070802101706625.jpg" style="display: none; margin: 0px 0px; width:750px; height:200px;" id="img1" index="1" /></center></a>
                <a href="Category.aspx"><center><img src="img/two.jpg" style="display: block; margin: 0px 0px;width:750px; height:200px;" id="img2" index="2" /></center></a>

                <a href="Category.aspx"><center><img src="images/dd_scroll_2.jpg" style="display:none; margin: 0px 0px; width:750px; height:200px;" id="img3" index="3" /></center></a>
                <a href="Category.aspx"><center><img src="images/dd_scroll_3.jpg" style="display:none; margin: 0px 0px; width:750px; height:200px;" id="img4" index="4" /></center></a>
                <a href="Category.aspx"><center><img src="images/dd_scroll_4.jpg" style="display:none; margin: 0px 0px; width:750px; height:200px;" id="img5" index="5" /></center></a>
                <a href="Category.aspx"><center><img src="images/dd_scroll_5.jpg" style="display:none; margin: 0px 0px; width:750px; height:200px;" id="img6" index="6" /></center></a>
                <a href="Category.aspx"><center><img src="images/dd_scroll_6.jpg" style="display:none; margin: 0px 0px; width:750px; height:200px;" id="img7" index="7" /></center></a>
                <a href="Category.aspx"><center><img src="img/one.jpg" style="display: none; margin: 0px 0px; width:750px; height:200px; " id="img8" index="8"  /></center></a>
                <a href="Category.aspx"><center><img src="img/two.jpg" style="display: block; margin: 0px 0px;width:750px; height:200px;" id="img9" index="9" /></center></a>
            				</div>
				<div class="blank5">
            </div>
            <div class="blank5">
            </div>
            <div class="box">
                <div class="box_2 centerPadd">
                    <div id="itemBest" class="itemTit">
                    </div>
                    <div class="clearfix goodsBox" id="show_best_area">
                        
                        <asp:DataList ID="DataList1" runat="server" RepeatColumns="5">
                        <ItemTemplate>
                            <div class="goodsItem">
                            <span class="best"></span><a href='goods.aspx?url=Main.aspx&id=<%# Eval("BID") %>'>
                                <img class="goodsimg" alt='<%# Eval("BName") %>' src='<%# Eval("BPic","BookImages/{0}") %>'></a><br>
                            <p>
                                <a title='<%# Eval("BName") %>' href="#"><%# Eval("BName") %></a></p>
                            <font class="f1">￥<%# Eval("BPrice") %>元 </font>
                        </div>
                        </ItemTemplate>
                        </asp:DataList>
                        <div class="more">
                            <a href="Category.aspx">
                                <img src="images/more.gif"></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="blank5">
            </div>
                  <div class="box">
                <div class="box_2 centerPadd">
                    <div id="Div1" class="itemTit">
                    </div>
                    <div class="clearfix goodsBox" id="Div2">
                        
                        <asp:DataList ID="DataList2" runat="server" RepeatColumns="5">
                        <ItemTemplate>
                            <div class="goodsItem">
                            <span class="best"></span><a href='goods.aspx?url=Main.aspx&id=<%# Eval("BID") %>'>
                                <img class="goodsimg" alt='<%# Eval("BName") %>' src='<%# "BookImages/"+Eval("BPic") %>'></a><br>
                            <p>
                                <a title='<%# Eval("BName") %>' href="#"><%# Eval("BName") %></a></p>
                            <font class="f1">￥<%# Eval("BPrice") %>元 </font>
                        </div>
                        </ItemTemplate>
                        </asp:DataList>
                        <div class="more">
                            <a href="Category.aspx"><img src="images/more.gif"></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="blank5">
            </div>
            <div class="blank5">
            </div>
            </div>
</asp:Content>
