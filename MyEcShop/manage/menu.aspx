<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="MyEcShop.manage.menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        td
        {
            text-align: center;
        }
        th
        {
            font-weight: bold;
        }
    </style>
    <style type="text/css">
        body
        {
            background: #80BDCB;
        }
        #tabbar-div
        {
            background: #278296;
            padding-left: 10px;
            height: 21px;
            padding-top: 0px;
        }
        #tabbar-div p
        {
            margin: 1px 0 0 0;
        }
        .tab-front
        {
            background: #80BDCB;
            line-height: 20px;
            font-weight: bold;
            padding: 4px 15px 4px 18px;
            border-right: 2px solid #335b64;
            cursor: hand;
            cursor: pointer;
        }
        .tab-back
        {
            color: #F4FAFB;
            line-height: 20px;
            padding: 4px 15px 4px 18px;
            cursor: hand;
            cursor: pointer;
        }
        .tab-hover
        {
            color: #F4FAFB;
            line-height: 20px;
            padding: 4px 15px 4px 18px;
            cursor: hand;
            cursor: pointer;
            background: #2F9DB5;
        }
        #top-div
        {
            padding: 3px 0 2px;
            background: #BBDDE5;
            margin: 5px;
            text-align: center;
        }
        #main-div
        {
            border: 1px solid #345C65;
            padding: 5px;
            margin: 5px;
            background: #FFF;
        }
        #menu-list
        {
            padding: 0;
            margin: 0;
        }
        #menu-list ul
        {
            padding: 0;
            margin: 0;
            list-style-type: none;
            color: #335B64;
        }
        #menu-list li
        {
            padding-left: 16px;
            line-height: 16px;
            cursor: hand;
            cursor: pointer;
        }
        #main-div a:visited, #menu-list a:link, #menu-list a:hover
        {
            color: #335B64;
            text-decoration: none;
        }
        #menu-list a:active
        {
            color: #EB8A3D;
        }
        .explode
        {
            background: url(images/menu_minus.gif) no-repeat 0px 3px;
            font-weight: bold;
        }
        .collapse
        {
            background: url(images/menu_plus.gif) no-repeat 0px 3px;
            font-weight: bold;
        }
        .menu-item
        {
            background: url(images/menu_arrow.gif) no-repeat 0px 3px;
            font-weight: normal;
        }
        #help-title
        {
            font-size: 14px;
            color: #000080;
            margin: 5px 0;
            padding: 0px;
        }
        #help-content
        {
            margin: 0;
            padding: 0;
        }
        .tips
        {
            color: #CC0000;
        }
        .link
        {
            color: #000099;
        }
    	.auto-style1 {
			margin-left: 0;
		}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="tabbar-div">
        <p class="auto-style1">
            <span class="tab-front" id="menu-tab">菜单</span>
        </p>
    </div>
    <div id="main-div">
        <div id="menu-list">
            <ul>
                <li class="explode" key="02_cat_and_goods" name="menu">商品管理
                    <ul>
                        <li class="menu-item"><a href="goods.aspx" target="main-frame">商品列表</a></li>
                        <li class="menu-item"><a href="goodAdd.aspx" target="main-frame">添加新商品</a></li>
                    </ul>
                </li>
                <li class="explode" key="03_promotion" name="menu">商品分类
                    <ul>
                        <li class="menu-item"><a href="goodLType.aspx" target="main-frame">大类别</a></li>
                        <li class="menu-item"><a href="goodSType.aspx" target="main-frame">小类别</a></li>
                    </ul>
                </li>
                <li class="explode" key="04_order" name="menu">订单管理
                    <ul>
                        <li class="menu-item"><a href="Orders.aspx" target="main-frame">订单列表</a></li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
