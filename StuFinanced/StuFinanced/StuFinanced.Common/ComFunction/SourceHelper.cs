namespace StuFinanced.Common.ComFunction
{
   public  class SourceHelper
    {
        public static string GetSourceText(string SourceKey)
        {
            switch (SourceKey)
            {
                case "YJ_QB":
                    return "我惠抢宝";
                case "YJ_M":
                    return "云街消费系统";
                case "YC_M":
                    return "云超消费系统";
                case "YD_M":
                    return "云店消费系统";
                case "YW_M":
                    return "云网会员系统";
                case "YD":
                    return "我惠云店";
                case "YJ":
                    return "我惠云街";
                case "YC":
                    return "我惠云超";
                default:
                    return "";
            }
        }
    }
}
