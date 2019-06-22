<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="drag.aspx.cs" Inherits="MyEcShop.manage.drag" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
            background: #80BDCB;
            cursor: E-resize;
            
        }
        table
        {
          margin-top:240px;
        }
    </style>

    <script type="text/javascript" language="JavaScript">

        var pic = new Image();
        pic.src = "images/arrow_right.gif";

        function toggleMenu() {
            frmBody = parent.document.getElementById('frame-body');
            imgArrow = document.getElementById('img');

            if (frmBody.cols == "0, 10, *") {
                frmBody.cols = "200, 10, *";
                imgArrow.src = "images/arrow_left.gif";
            }
            else {
                frmBody.cols = "0, 10, *";
                imgArrow.src = "images/arrow_right.gif";
            }
        }
     

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table height="100%" cellspacing="0" cellpadding="0" id="tbl">
        <tr>
            <td>
                <a href="javascript:toggleMenu();">
                    <img src="images/arrow_left.gif" width="10" height="30" id="img" border="0"  /></a>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
