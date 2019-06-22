<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="MyEcShop.manage.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            font-weight: bold;
        }
        #header-div
        {
            background: #278296;
            border-bottom: 1px solid #FFF;
        }
        #logo-div
        {
            height: 50px;
            float: left;
        }
        #license-div
        {
            height: 50px;
            float: left;
            text-align: center;
            vertical-align: middle;
            line-height: 50px;
        }
        #license-div a:visited, #license-div a:link
        {
            color: #EB8A3D;
        }
        #license-div a:hover
        {
            text-decoration: none;
            color: #EB8A3D;
        }
        #submenu-div
        {
            height: 50px;
            
        }
        #submenu-div ul
        {
            margin: 0;
            padding: 0;
            list-style-type: none;
        }
        #submenu-div li
        {
            float: right;
            padding: 0 10px;
            margin: 3px 0;
            border-left: 1px solid #FFF;
        }
        #submenu-div a:visited, #submenu-div a:link
        {
            color: #FFF;
            text-decoration: none;
        }
        #submenu-div a:hover
        {
            color: #F5C29A;
        }
        #loading-div
        {
            clear: right;
            text-align: right;
            display: block;
        }
        #menu-div
        {
            background: #80BDCB;
            font-weight: bold;
            height: 24px;
            line-height: 24px;
        }
        #menu-div ul
        {
            margin: 0;
            padding: 0;
            list-style-type: none;
        }
        #menu-div li
        {
            float: left;
            border-right: 1px solid #192E32;
            border-left: 1px solid #BBDDE5;
        }
        #menu-div a:visited, #menu-div a:link
        {
            display: block;
            padding: 0 20px;
            text-decoration: none;
            color: #335B64;
            background: #9CCBD6;
        }
        #menu-div a:hover
        {
            color: #000;
            background: #80BDCB;
        }
        #submenu-div a.fix-submenu
        {
            clear: both;
            margin-left: 5px;
            padding: 1px 5px;
            background: #DDEEF2;
            color: #278296;
        }
        #submenu-div a.fix-submenu:hover
        {
            padding: 1px 5px;
            background: #FFF;
            color: #278296;
        }
        #menu-div li.fix-spacel
        {
            width: 30px;
            border-left: none;
        }
        #menu-div li.fix-spacer
        {
            border-right: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div id="header-div">
        <div id="logo-div" style="bgcolor: #000000;">
            <img alt="" src="images/ecshop_logo.gif" />

            </div>
        <div id="license-div" style="bgcolor: #000000;">
        </div>
        <div id="submenu-div">
            <div id="send_info" style="padding: 5px 10px 0 0;text-align: right;
                color: #FF9900; width: 40%; float: right;">
                <a href="" target="main-frame" class="fix-submenu">清除缓存</a> 
                <a href="clear.aspx" target="_top"class="fix-submenu">退出</a>
            </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
