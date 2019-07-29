using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace MyEcShop.manage
{
    public partial class CodeMa : System.Web.UI.Page
    {
        static Random r = new Random();
        string ma = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"; 
        protected void Page_Load(object sender, EventArgs e)
        {
            //产生随机验证码
            string code = "";
            for (int i = 0; i < 4; i++)
            {
                code += ma[r.Next(0, ma.Length)].ToString();
            }
			//将验证码保存在Session中
			Session["code"] = code;
            //设置一张图片
            Response.ContentType = "images/gif";

            //创建图片
            int width = 60;
            int height = 25;
            Bitmap bitmap = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.Yellow);
            g.DrawString(code, new Font("楷体", 14), Brushes.Blue, 0, 0);
            //画干扰线
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(Pens.Red,
                    r.Next(0, width),
                    r.Next(0, height),
                    r.Next(0, width),
                    r.Next(0, height));
            }

            //将图片保存到输出流中
            bitmap.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
        }
    }
}