using System;
using System.Configuration;
namespace StuFinanced.Common.ComFunction
{
    public class ConfigHelper
    {
    
        /// <summary>
        /// 网站域名
        /// </summary>
        /// <returns></returns>
        public static string GetDomainName()
        {
            return Convert.ToString(ConfigurationManager.ConnectionStrings["DomainName"]);
        }

        /// <summary>
        /// 网站首页
        /// </summary>
        /// <returns></returns>
        public static string GetWebIndex()
        {
            return Convert.ToString(ConfigurationManager.ConnectionStrings["YWAPI_URL"]) + "/Home/Index";
        }

    }
}
