
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;


namespace StuFinanced.Common.ComFunction
{
    /// <summary>
    /// 接口调用方法
    /// </summary>
    public class WebServiceHelper
    {
        /// <summary>
        /// 接口调用通用请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="SignKey"></param>
        /// <returns></returns>
        private string APIWebRequest(string Url, string SignKey)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.Headers.Add("apikey", SignKey);
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            return myStreamReader.ReadToEnd();
        }



        /// <summary>
        /// sso 获取用户
        /// </summary>
        /// <param name="ToKen"></param>
        /// <returns></returns>
        public string SSOWebRequest(string ToKen)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("http://sso.wohuiyun.com/sso/GetUser?ToKen={0}"
                  , HttpUtility.UrlEncode(ToKen))); //根据令牌请求数据并且把获取到的数据保存到本地 
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            return myStreamReader.ReadToEnd();
        }
    }
}
