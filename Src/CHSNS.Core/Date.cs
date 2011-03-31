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
        /// <summary>
        /// 求时间与现在的分数间隔
        /// </summary>
        /// <param name="oldtime"></param>
        /// <returns></returns>
        public static int DivMinutes(DateTime oldtime)
        {
            TimeSpan st = DateTime.Now - oldtime;
            return (int)st.TotalMinutes;
        }

        public static int DivMinutes(object oldtime)
        {
            DateTime dt;
            if (DateTime.TryParse(oldtime.ToString(), out dt))
                return DivMinutes(dt);
            return 1000;
        }
    }
}