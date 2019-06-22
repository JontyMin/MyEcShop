<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MyEcShop.manage.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
 <frameset rows="52,*" framespacing="0" border="0">
        <frame src="top.aspx" id="header-frame" name="header-frame" frameborder="no" scrolling="no" />
        <frameset cols="180, 10, *" framespacing="0" border="0" id="frame-body">
            <frame src="menu.aspx" id="menu-frame" name="menu-frame" frameborder="no" scrolling="yes">
            <frame src="drag.aspx" id="drag-frame" name="drag-frame" frameborder="no" scrolling="no">
            <frame src="main.aspx" id="main-frame" name="main-frame" frameborder="no" scrolling="yes">
        </frameset>
    </frameset>
</html>
