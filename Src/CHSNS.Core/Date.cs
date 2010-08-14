using System;

namespace CHSNS
{
    /// <summary>
    /// 计算特殊时间的类
    /// AU:邹健
    /// LE:2006年8月
    /// </summary>
    public class Date
    {
        //#region SkyTreeText enum

        ///// <summary>
        ///// 天干地支
        ///// </summary>
        //public enum SkyTreeText
        //{
        //    /// <summary>
        //    /// 天干 值为0
        //    /// </summary>
        //    天干 = 0,
        //    /// <summary>
        //    /// 地枝 值为1
        //    /// </summary>
        //    地支 = 1
        //}

        //#endregion


        /// <summary>
        /// 求时间与现在的分数间隔
        /// </summary>
        /// <param name="oldtime"></param>
        /// <returns></returns>
        public static int DivMinutes(DateTime oldtime)
        {
            TimeSpan st = DateTime.Now - oldtime;
            return (int)st.TotalMinutes;
            //.Minutes;
        }

        public static int DivMinutes(object oldtime)
        {
            DateTime dt;
            if (DateTime.TryParse(oldtime.ToString(), out dt))
                return DivMinutes(dt);
            return 1000;
            //.Minutes;
        }

        ///// <summary>
        ///// 获取天干或地枝的编号
        ///// </summary>
        ///// <param name="dat">要计算日期</param>
        ///// <param name="i">天干/地枝</param>
        ///// <returns>天干返回 10之内的数字,地枝返回11之内的数字</returns>
        //public int SkyTree(DateTime dat, SkyTreeText i)
        //{
        //    //得到干支序号

        //    var Dom = new XmlDocument();
        //    Dom.Load(HttpContext.Current.Request.MapPath("/") + ConfigurationManager.AppSettings["AnimalSignDate"]);
        //    int y = dat.Year;
        //    int m = dat.Month;
        //    int d = dat.Day;
        //    XmlNode Node = Dom.SelectSingleNode(string.Format("//item[@year={0}]", y));
        //    int start;
        //    int n;
        //    if (i == SkyTreeText.地支)
        //    {
        //        start = 1901;
        //        n = 12;
        //    }
        //    else
        //    {
        //        start = 1905;
        //        n = 10;
        //    }
        //    int result = ((y - start)%n) + 2;
        //    result = (result <= 0 ? result + n : result);
        //    if (byte.Parse(Node.Attributes["month"].InnerXml) > m) result = result - 1;
        //    if (byte.Parse(Node.Attributes["month"].InnerXml) == m & byte.Parse(Node.Attributes["day"].InnerXml) > d)
        //        result = result - 1;
        //    result = (result == 0 ? n : result);
        //    result = (result == n + 1 ? 1 : result);
        //    return result;
        //    //本最多用时16MS一般1MS内可以完成
        //}

        ///// <summary>
        ///// 获取天干或地枝的编号
        ///// </summary>
        ///// <param name="dats">以字符串表示,要计算日期</param>
        ///// <param name="i">天干/地枝</param>
        ///// <returns>天干返回 10之内的数字,地枝返回11之内的数字</returns>
        //public int SkyTree(string dats, SkyTreeText i)
        //{
        //    if (!Information.IsDate(dats)) return 0;
        //    return SkyTree(DateTime.Parse(dats), i);
        //}

        ////通用读取XML
        //public string XmlItemName(string Xpath, string name, string xmlfilename)
        //{
        //    var Dom = new XmlDocument();
        //    Dom.Load(HttpContext.Current.Request.MapPath("/") + ConfigurationManager.AppSettings[xmlfilename]);
        //    XmlNode Node = Dom.SelectSingleNode(Xpath);
        //    return Node.Attributes[name].InnerXml;
        //}

        ///// <summary>
        ///// 获取生肖名
        ///// </summary>
        ///// <param name="num">生肖编号</param>
        ///// <returns>生肖名 例:鼠</returns>
        //public string AnimalSignName(int num)
        //{
        //    return XmlItemName(string.Format("//item[@id={0}]", num), "name", "AnimalSign");
        //}

        ///// <summary>
        ///// 获取生肖名
        ///// </summary>
        ///// <param name="dat">要计算的日期</param>
        ///// <returns>生肖名 例:鼠</returns>
        //public string AnimalSignName(DateTime dat)
        //{
        //    return AnimalSignName(SkyTree(dat, SkyTreeText.地支));
        //}

        ///// <summary>
        ///// 获取生肖名
        ///// </summary>
        ///// <param name="dats">要计算的日期的字符串</param>
        ///// <returns>生肖名 例:鼠</returns>
        //public string AnimalSignName(string dats)
        //{
        //    if (!Information.IsDate(dats)) return "";
        //    return AnimalSignName(SkyTree(DateTime.Parse(dats), SkyTreeText.地支));
        //}

        ///// <summary>
        ///// 获取地枝名
        ///// </summary>
        ///// <param name="dat">要计算的时间</param>
        ///// <returns>地枝名</returns>
        //public string TreeName(DateTime dat)
        //{
        //    return XmlItemName(string.Format("//item[@id={0}]", SkyTree(dat, SkyTreeText.地支)), "tree", "AnimalSign");
        //}

        ///// <summary>
        ///// 获取地枝名
        ///// </summary>
        ///// <param name="dats">要计算的时间的字符串</param>
        ///// <returns>地枝名</returns>
        //public string TreeName(string dats)
        //{
        //    if (!Information.IsDate(dats)) return "";
        //    return TreeName(DateTime.Parse(dats));
        //}

        ///// <summary>
        ///// 获取天干名
        ///// </summary>
        ///// <param name="dat">要计算的时间</param>
        ///// <returns>天干名</returns>
        //public string SkyName(DateTime dat)
        //{
        //    return XmlItemName(string.Format("//item[@id={0}]", SkyTree(dat, SkyTreeText.天干)), "tree", "SkyTree");
        //}

        ///// <summary>
        ///// 获取天干名
        ///// </summary>
        ///// <param name="dats">要计算的时间的字符串</param>
        ///// <returns>天干名</returns>
        //public string SkyName(string dats)
        //{
        //    if (!Information.IsDate(dats)) return "";
        //    return SkyName(DateTime.Parse(dats));
        //}

        ///// <summary>
        ///// 获取天干地枝的组合
        ///// </summary>
        ///// <param name="dat">要计算的时间</param>
        ///// <returns>天干地枝 例:甲子</returns>
        //public string SkyTreeName(DateTime dat)
        //{
        //    return SkyName(dat) + TreeName(dat);
        //}

        ///// <summary>
        ///// 获取天干地枝的组合
        ///// </summary>
        ///// <param name="dats">要计算的时间的字符串</param>
        ///// <returns>天干地枝 例:甲子</returns>
        //public string SkyTreeName(string dats)
        //{
        //    return SkyName(dats) + TreeName(dats);
        //}

        ///// <summary>
        ///// 获取星座名
        ///// </summary>
        ///// <param name="dats">要计算的时间的字符串</param>
        ///// <returns>星座名:如水瓶</returns>
        //public string StarSignName(string dats)
        //{
        //    return StarSignName(StarSign(dats).ToString());
        //}

        ///// <summary>
        ///// 获取星座名
        ///// </summary>
        ///// <param name="dat">要计算的时间</param>
        ///// <returns>星座名:如水瓶</returns>
        //public string StarSignName(DateTime dat)
        //{
        //    return StarSignName(StarSign(dat).ToString());
        //}

        ///// <summary>
        ///// 获取星座名
        ///// </summary>
        ///// <param name="Num">星座编号</param>
        ///// <returns>星座名:如水瓶</returns>
        //public string StarSignName(byte Num)
        //{
        //    return XmlItemName(string.Format("/root/item[@id={0}]", Num), "name", "StarSign");
        //}

        ///// <summary>
        ///// 获取星座编号
        ///// </summary>
        ///// <param name="dats">要计算的时间的字符串</param>
        ///// <returns>星座编号</returns>
        //public int StarSign(string dats)
        //{
        //    if (!Information.IsDate(dats)) return 0;
        //    return StarSign(DateTime.Parse(dats));
        //}

        ///// <summary>
        ///// 获取星座编号
        ///// </summary>
        ///// <param name="dat">要计算的时间</param>
        ///// <returns>星座编号</returns>
        //public int StarSign(DateTime dat)
        //{
        //    int functionReturnValue;
        //    if (!Information.IsDate(dat)) return 0;
        //    int m = dat.Month;
        //    int d = dat.Day;
        //    //int y = 2007;
        //    DateTime temp = DateTime.Parse(string.Format("{0}/{1}/2007", m, d));
        //    if ((((DateTime.Compare(temp, new DateTime(633100320000000000L)) >= 0) &&
        //          (DateTime.Compare(temp, new DateTime(633125376000000000L)) <= 0))
        //            ? 1
        //            : 0) != 0)
        //    {
        //        functionReturnValue = 1;
        //    }
        //    else
        //    {
        //        if ((((DateTime.Compare(temp, new DateTime(633126240000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633152160000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 2;
        //        }
        //        if ((((DateTime.Compare(temp, new DateTime(633153024000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633179808000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 3;
        //        }
        //        if ((((DateTime.Compare(temp, new DateTime(633180672000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633206592000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 4;
        //        }
        //        if ((((DateTime.Compare(temp, new DateTime(633207456000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633233376000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 5;
        //        }
        //        if ((((DateTime.Compare(temp, new DateTime(633234240000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633260160000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 6;
        //        }
        //        if ((((DateTime.Compare(temp, new DateTime(633261024000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633286944000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 7;
        //        }
        //        if ((((DateTime.Compare(temp, new DateTime(633287808000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633312000000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 8;
        //        }
        //        if ((((DateTime.Compare(temp, new DateTime(633312864000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633337920000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 9;
        //        }
        //        if ((((DateTime.Compare(temp, new DateTime(633338784000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633346560000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 10;
        //        }
        //        if ((((DateTime.Compare(temp, new DateTime(633032064000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633047616000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 10;
        //        }
        //        if ((((DateTime.Compare(temp, new DateTime(633048480000000000L)) >= 0) &&
        //              (DateTime.Compare(temp, new DateTime(633073536000000000L)) <= 0))
        //                ? 1
        //                : 0) != 0)
        //        {
        //            return 11;
        //        }
        //        functionReturnValue = (((DateTime.Compare(temp, new DateTime(633074400000000000L)) >= 0) &&
        //                                (DateTime.Compare(temp, new DateTime(633099456000000000L)) <= 0))
        //                                ? 1
        //                                : 0) != 0 ? 12 : 0;
        //    }
        //    return functionReturnValue;
        //}
    }
}