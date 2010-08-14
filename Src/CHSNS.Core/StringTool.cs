
namespace CHSNS {
    /// <summary>
    /// 字符串格式化规则
    /// AU:邹健
    /// </summary>
    public class StringTool {

        #region 对富文本编辑器内容进行格式化
        ///// <summary>
        ///// 格式化title
        ///// </summary>
        ///// <param name="str">要格式化的字符串</param>
        ///// <returns></returns>
        //public string FormatTitle(string str) {
        //    return str;
        //}

        ///// <summary>
        ///// 富文本过滤
        ///// </summary>
        ///// <param name="str">源文本</param>
        ///// <returns>过滤后的文本</returns>
        //static public String FormatRichEdit(String str) {
        //    //const string f = "EditFormat";
        //    //var dom = new XmlDocument();
        //    //if (CHCache.IsNullorEmpty(f))
        //    //	if (!CHCache.a(f))
        //            return "过滤配置文件无法加载";
        //    //dom.LoadXml(HttpContext.Current.Cache[f].ToString());
        //    //XmlNodeList nl = dom.SelectNodes("/root/item");
        //    //if (nl != null)
        //    //    foreach (XmlNode xn in nl) {
        //    //        str = Regex.Replace(str,
        //    //                            xn.InnerText,
        //    //                            @"", RegexOptions.IgnoreCase);
        //    //    }
        //    ////str = str.Replace("\n", "<br>");
        //    //return str;
        //}
        #endregion

        #region 正则匹配


        //static public string[] Trim(string[] val) {
        //    for (var i = 0; i < val.Length; i++) {
        //        val[i] = val[i].Trim();
        //    }
        //    return val;
        //}

        #endregion
        
        #region 兴趣爱好格式化
        ///// <summary>
        ///// 将分隔符规范化为','
        ///// </summary>
        ///// <param name="str">要规范的文本</param>
        ///// <returns>规范后的文本,以','结束</returns>
        //static public String FormatJoin(String str) {
        //    if (String.IsNullOrEmpty(str))
        //        return ",";
        //    var sbout = new StringBuilder(str);
        //    sbout.Replace("\n", ",");
        //    sbout.Replace(";", ",");
        //    sbout.Replace("，", ",");
        //    sbout.Replace("、", ",");
        //    if (!sbout.ToString().EndsWith(","))
        //        sbout.Append(",");
        //    return HtmlEncode(sbout.ToString().Trim());
        //}
    



        ///// <summary>
        ///// 将分隔符规范化为',',以传递给数据库
        ///// </summary>
        ///// <param name="str">要规范的文本</param>
        //// <returns>规范后的文本,以','结束,但如果字符串为空,则返回System.DBNull.Value</returns>
        //static public Object FormatLove(object str) {
        //    var ret = FormatJoin(str.ToString());
        //    if (ret == "," || string.IsNullOrEmpty(ret))
        //        return DBNull.Value;
        //    return ret;
        //}
        #endregion

        //#region 去除HTML注释
        ///// <summary>
        ///// 去除HTML注释
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //static internal String ClearRemarks(String str) {
        //    str = Regex.Replace(str,
        //                        @"<!--(.|\n)+?-->",
        //                        "", RegexOptions.IgnoreCase);
        //    return str;
        //}
        //#endregion

        //#region 清除字符串中的通配符....
        ///// <summary>
        ///// 去除文本中的通匹符
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //static public string ClearWildcard(string str) {
        //    return str.Replace("%", "").Replace("*", "");
        //}
        //#endregion
        //#region 中文数字转阿拉伯数字
        //static readonly string[] HuaNum ={
        //    "一","二","三","四","五","六","七","八","九"
        //};
        //static readonly string[] Number ={
        //    "1","2","3","4","5","6","7","8","9"
        //};
        ///// <summary>
        ///// 中文数字转阿拉伯数字
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //static public string HuaNumtoNumber(string str) {
        //    var sbout = new StringBuilder(str);
        //    for (var i = 0; i < HuaNum.Length; i++) {
        //        sbout.Replace(HuaNum[i], Number[i]);
        //    }
        //    return sbout.ToString();
        //}
        //#endregion
        ///// <summary>
        ///// 字符串为''或空时转为System.DBNull.Value
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //static public object StringNull(string str)
        //{
        //    if (string.IsNullOrEmpty(str))
        //        return DBNull.Value;
        //    return str.Trim();
        //}


    
        //static public string SexName(object b) {
        //    bool isb;
        //    if (bool.TryParse(b.ToString(), out isb)) {
        //        return isb ? "男生" : "女生";
        //    }
        //    return "未设置";
        //}
        ///// <summary>
        ///// 字节与文件大小字符串比较
        ///// </summary>
        ///// <param name="bytes"></param>
        ///// <returns></returns>
        //public static string BytesToString(long bytes) {
        //    if (bytes < 1024L) {
        //        return (bytes + " B");
        //    }
        //    if (bytes < 1048576L) {
        //        return string.Format("{0:N2} KB", bytes / 1024f);
        //    }
        //    return bytes < 1073741824L ? string.Format("{0:N2} MB", bytes / 1048576f) : string.Format("{0:N2} GB", bytes / 1.073742E+09f);
        //}
    
    }
}
