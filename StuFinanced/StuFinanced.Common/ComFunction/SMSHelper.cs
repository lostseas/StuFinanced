﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuFinanced.Common.ComFunction
{
    public class SMSHelper
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="DstMobile"></param>
        /// <param name="SmsMsg"></param>
        /// <returns></returns>
        public static bool SendSms(string DstMobile, string SmsMsg)
        {
            string mToUrl = "";	//即将引用的url   			
            string mRtv = "";		//引用的返回字符串
            //编码
            SmsMsg = System.Web.HttpUtility.UrlEncode(SmsMsg, System.Text.Encoding.GetEncoding("utf-8"));
            mToUrl = "http://sms.1xinxi.cn/asmx/smsservice.aspx?name=15039090920&pwd=E6B7B873CCF1CBFB2AF9945D9532&content=" + SmsMsg + "&mobile=" + DstMobile + "&sign=我惠集团&type=pt";
            try
            {
                System.Net.HttpWebResponse rs = (System.Net.HttpWebResponse)System.Net.HttpWebRequest.Create(mToUrl).GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(rs.GetResponseStream(), System.Text.Encoding.UTF8);
                mRtv = sr.ReadToEnd();
            }
            catch
            {
                return false;	//对 url http 请求的时候发生的错误  比如页面不存在 或者页面本身执行发生错误
            }
            if (mRtv.Substring(0, 1) == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
