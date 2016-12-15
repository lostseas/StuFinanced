using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuFinanced.Common.ComFunction
{
    public class ConvertHelper
    {


        #region byte 转 hex（十六进制）
        /// <summary>
        /// byte 转 hex（十六进制）
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string ByteToHex(byte[] b)
        {
            char[] hex = {'0', '1', '2', '3', '4', '5', '6', '7',
                      '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            char[] newChar = new char[b.Length * 2];
            for (int i = 0; i < b.Length; i++)
            {
                newChar[2 * i] = hex[(b[i] & 0xf0) >> 4];
                newChar[2 * i + 1] = hex[b[i] & 0xf];
            }
            return new string(newChar);
        }
        #endregion

        #region hex(十六进制) 转 byte
        /// <summary>
        /// hex(十六进制) 转 byte 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] HexToByte(String src)
        {
            byte[] res = new byte[src.Length / 2];
            char[] chs = src.ToCharArray();
            for (int i = 0, c = 0; i < chs.Length; i += 2, c++)
            {
                res[c] = (byte)(Convert.ToInt32(new string(chs, i, 2), 16));
            }

            return res;
        }
        #endregion

        #region 字符串转ASCII
        /// <summary>
        /// 字符串转ASCII
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static string CharToASC(string character)
        {
            string str = "";
            byte[] array = Encoding.GetEncoding("ASCII").GetBytes(character);
            for (int i = 0; i < array.Length; i++)
            {
                str += array[i].ToString();
            }
            return str;
        }
        #endregion

        #region Dictionary 转 sting(格式为：Name=boby&Age=18)
        public static string DicToString(Dictionary<string, string> dic)
        {
            string value = "";
            foreach (KeyValuePair<string, string> kv in dic)
            {
                value += kv.Key + "=" + kv.Value + "&";
            }
            return value.Substring(0, value.Length - 1);
        }
        #endregion

        #region sting 转 Dictionary(格式为：UID=1&UGUID=35278AE6B4E14F1F9582937C5C836453&UNumber=6622052800000000)
        public static Dictionary<string, string> StrToDictionary(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string[] Array = value.Split('&');
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
        #endregion
    }
}
