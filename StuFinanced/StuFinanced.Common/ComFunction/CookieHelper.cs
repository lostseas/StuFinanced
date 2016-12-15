using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
/*=============================================================================
 描  述：Cookie操作类
*=============================================================================*/
namespace StuFinanced.Common.ComFunction
{
    public class CookieHelper
    {
        /// <summary>
        /// Cookies赋值
        /// </summary>
        /// <param name="strName">主键</param>
        /// <param name="strValue">键值</param>
        /// <param name="timeSpan">时间段TimeSpan</param>
        /// <returns></returns>
        public static bool SetCookie(string strName, string strValue)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Value = strValue;
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cookies赋值
        /// </summary>
        /// <param name="strName">主键</param>
        /// <param name="strValue">键值</param>
        /// <param name="timeSpan">时间段TimeSpan</param>
        /// <returns></returns>
        public static bool SetCookie(string strName, string strValue, TimeSpan timeSpan)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Expires = DateTime.Now.Add(timeSpan);
                Cookie.Value = strValue;
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cookie赋值
        /// </summary>
        /// <param name="strName">主键</param>
        /// <param name="strValue">键值</param>
        /// <param name="deadline">过期时间</param>
        /// <returns></returns>
        public static bool SetCookie(string strName, string strValue, DateTime deadline)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Expires = deadline;
                Cookie.Value = strValue;
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cookies赋值
        /// </summary>
        /// <param name="strName">主键</param>
        /// <param name="dic">Dictionary键值对</param>
        /// <param name="strDay">有效天数</param>
        /// <returns></returns>
        public static bool SetCookie(string strName, Dictionary<string, string> dic, TimeSpan timeSpan)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Expires = DateTime.Now.Add(timeSpan);
                foreach (KeyValuePair<string, string> kv in dic)
                {
                    Cookie.Values.Add(kv.Key, kv.Value);
                }
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cookies赋值-跨域（只能跨子域）
        /// </summary>
        /// <param name="strName">主键</param>
        /// <param name="strValue">键值</param>
        /// <param name="timeSpan">时间段TimeSpan</param>
        /// <param name="DomainName">域名</param>
        /// <returns></returns>
        public static bool SetCookie(string strName, string strValue, TimeSpan timeSpan, string DomainName)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Domain = "." + DomainName;//当要跨域名访问的时候,给cookie指定域名即可,格式为.xxx.com
                //Cookie.Path = "/";
                Cookie.Expires = DateTime.Now.Add(timeSpan);
                Cookie.Value = strValue;
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }
      
        /// <summary>
        /// 读取Cookies
        /// </summary>
        /// <param name="strName">主键</param>
        /// <returns></returns>
        public static string GetCookie(string strName)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies[strName];
            if (Cookie != null)
            {
                return Cookie.Value.ToString();
            }
            else
            {
                return null;
            }
        }

        public static Dictionary<string, string> GetDicCookie(string strName)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies[strName];
            if (Cookie != null)
            {
                string[] Array = Cookie.Value.Split('&');
                string[] Array1;
                Dictionary<string, string> Dic = new Dictionary<string, string>();
                foreach (string item in Array)
                {
                    Array1 = item.Split('=');
                    Dic.Add(Array1[0], Array1[1]);
                }
                return Dic;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除Cookies
        /// </summary>
        /// <param name="strName">主键</param>
        /// <returns></returns>
        public static bool DelCookie(string strName)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                //Cookie.Domain = ".xxx.com";//当要跨域名访问的时候,给cookie指定域名即可,格式为.xxx.com
                Cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
