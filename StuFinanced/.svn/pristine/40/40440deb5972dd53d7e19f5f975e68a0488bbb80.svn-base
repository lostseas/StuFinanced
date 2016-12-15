using System;
using System.Web;
using System.Drawing;

namespace StuFinanced.Common.ComFunction
{
    public class ValidateCodeHelper
    {
        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="length"></param>
        /// <param name="Request"></param>
        public static void ImageCode(int length ,HttpResponseBase Request)
        {
            string randomcode = CreateRandomCode(length);
            CookieHelper.SetCookie("VerCode", SecurityHelper.MD5Encrypt(randomcode.ToUpper()), DateTime.Now.AddMinutes(1));
            //HttpCookie Cookie = new HttpCookie("VerCode");
            //Cookie.Expires = DateTime.Now.AddMinutes(15);
            //Cookie.Value = SecurityHelper.MD5Encrypt(randomcode.ToUpper());
            //Request.Cookies.Add(Cookie);
            CreateImage(randomcode, Request);            
        }
        ///  <summary>  
        ///  生成随机码  
        ///  </summary>  
        ///  <param  name="length">随机码个数</param>  
        ///  <returns></returns>  
        public static string CreateRandomCode(int length)
        {
            int rand;
            char code;
            string randomcode = String.Empty;

            //生成一定长度的验证码  
            System.Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                rand = random.Next();

                //if (rand % 3 == 0)
                //{
                //    code = (char)('A' + (char)(rand % 26));
                //}
                //else
                //{
                    code = (char)('0' + (char)(rand % 10));
                //}

                randomcode += code.ToString();
            }
            return randomcode;
        }

        ///  <summary>  
        ///  创建随机码图片  
        ///  </summary>  
        ///  <param  name="randomcode">随机码</param>  
        public static void CreateImage(string randomcode, HttpResponseBase Request)
        {
            int randAngle = 45;     //随机转动角度  
            int mapwidth = (int)(randomcode.Length * 20);
            Bitmap map = new Bitmap(mapwidth, 41);  //创建图片背景，设置其长宽  
            Graphics graph = Graphics.FromImage(map);
            graph.Clear(Color.AliceBlue);
            graph.DrawRectangle(new Pen(Color.Gainsboro, 0), 0, 0, map.Width - 1, map.Height - 1);//画一个边框  

            Random rand = new Random();

            // 生成背景噪点  
            Pen blackPen = new Pen(Color.LightGray, 0);
            for (int i = 0; i < 50; i++)
            {
                int x = rand.Next(0, map.Width);
                int y = rand.Next(0, map.Height);
                graph.DrawRectangle(blackPen, x, y, 1, 1);
            }

            //验证码旋转，防止机器识别  
            char[] chars = randomcode.ToCharArray();//拆散字符串成单字符数组  

            //文字距中  
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // 定义随机颜色列表  
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            // 定义随机字体字体  
            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

            for (int i = 0; i < chars.Length; i++)
            {
                int cindex = rand.Next(7);
                int findex = rand.Next(5);

                Font f = new Font(font[findex], 20, FontStyle.Bold); // 字体样式(参数2为字体大小)  
                Brush b = new SolidBrush(c[cindex]);

                Point dot = new Point(11, 11);  // 括号内数值越大，字符间距越大  
                float angle = rand.Next(0, randAngle);  // 转动的度数，如果将0改为-randAngle，那么旋转角度为-45度～45度  

                graph.TranslateTransform(dot.X, dot.Y);
                graph.RotateTransform(angle);
                graph.DrawString(chars[i].ToString(), f, b, 15, 8, format); // 第4、5个参数控制左、上间距  
                graph.RotateTransform(-angle);
                graph.TranslateTransform(2, -dot.Y);
            }

            //生成图片  
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            map.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Request.ClearContent();
            Request.ContentType = "image/gif";
            Request.BinaryWrite(ms.ToArray());
            graph.Dispose();
            map.Dispose();
        }
    }
}
