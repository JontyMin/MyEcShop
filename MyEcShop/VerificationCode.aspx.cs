using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
namespace ECShop
{
	public partial class VerificationCode : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GreateCheckCodeImage(GetExpressions());
		}

		/// <summary>
		/// 产生算术式
		/// </summary>
		/// <returns>String</returns>
		public String GetExpressions() {
			Random rd = new Random();//创建随机对象
			int Results = 0;
			int num1 = rd.Next(10);
			int num2 = rd.Next(10);
			String Expressions = "";

			int index = (rd.Next(4) + 1);
			switch (index) {
				case 1:
					Results = num1 + num2;
					Expressions = num1 + " ＋ " + num2 + "=";// +" 结果是" +Results;
					break;
				case 2:
					Results = num1 - num2;
					Expressions = num1 + " － " + num2 + "=";
					break;
				case 3:
					Results = num1 * num2;
					Expressions = num1 + " × " + num2 + "=";
					break;
				case 4:
					if (num2 > 0)
					{
						Results = Convert.ToInt16(num1 / num2);
						Expressions = num1 + " ÷ " + num2+"=";
					}
					else
					{
						Results = num1;
						Expressions = num1 + " ÷ 1" + "=";// + Results;
					}
					break;
			}
			//验证码值放入session
			Session["Code"] = Results.ToString();
			return Expressions;
		}

		/// <summary>
		/// 生成图片
		/// </summary>
		/// <param name="checkCode"></param>
		public void GreateCheckCodeImage(String checkCode) {
			if (checkCode.Trim() == "" || checkCode == null)
				return;
				
				Bitmap img = new Bitmap((int)(checkCode.Length * 14), 22);
				Graphics gr = Graphics.FromImage(img);
				try
				{
					//随机生成器
					Random rd = new Random();

					//清空img背景色
					gr.Clear(Color.White);

					//背景噪音线
					int i;
					for ( i = 0; i < 25; i++)
					{
						int x1 = rd.Next(img.Width);
						int x2 = rd.Next(img.Width);
						int y1 = rd.Next(img.Height);
						int y2 = rd.Next(img.Height);
						gr.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
					}

					//定义字体数组
					String[] fontFamily = { "Arial", "Verdana", "Comic Sans MS", "Impact", "Haettenschweiler", "幼圆", "黑体", "隶书", "宋体", "楷体_GB2312" };
					FontStyle[] fontStyle = { FontStyle.Bold, FontStyle.Italic, FontStyle.Regular, FontStyle.Strikeout, FontStyle.Underline };
					Font font = new System.Drawing.Font(fontFamily[rd.Next(9)], 12, fontStyle[rd.Next(5)]);
					System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, img.Width, img.Height), Color.Blue, Color.DarkRed, 1.2F, true);
					gr.DrawString(checkCode, font, brush, 2, 2);

					//前景噪音点
					gr.DrawRectangle(new Pen(Color.Silver), 0, 0, img.Width - 1, img.Height - 1);
					System.IO.MemoryStream ms = new System.IO.MemoryStream();
					img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
					Response.ClearContent();
					Response.ContentType = "image/Gif";
					Response.BinaryWrite(ms.ToArray());
				}
				catch (Exception)
				{

					gr.Dispose();
					img.Dispose();
				}
			}
		}
}
