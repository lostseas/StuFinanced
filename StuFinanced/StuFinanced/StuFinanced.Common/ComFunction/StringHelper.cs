using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace StuFinanced.Common.ComFunction
{
    public class StringHelper
    {
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="oldString">传入字符串</param>
        /// <param name="length">截取后的长度</param>
        /// <returns></returns>
        public static string SubString(string oldString, int length)
        {
            if (oldString != null)
            {
                if (oldString.Length > length)
                {
                    string newString = "";
                    newString = oldString.Substring(0, length) + "......";
                    return newString;
                }
                else
                {
                    return oldString;
                }
            }
            else
            {
                return "";
            }
        }
        ///   <summary>   
        ///   去除HTML标记   
        ///   </summary>   
        ///   <param   name="NoHTML">包括HTML的源码   </param>   
        ///   <returns>已经去除后的文字</returns> 
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring.Length > 230 ? Htmlstring.Substring(0, 230) + "..." : Htmlstring;
        }

        /// <summary>
        /// 隐藏卡号
        /// </summary>
        /// <param name="cardNum">卡号</param>
        /// <returns></returns>
        public static string CardNumHide(string cardNum)
        {
            int length = cardNum.Length;
            //后4位
            string back4 = cardNum.Substring(length - 4, 4);
            //前面的
            string front = cardNum.Substring(0, length - 8);
            return front + "****" + back4;

        }
    }
}
