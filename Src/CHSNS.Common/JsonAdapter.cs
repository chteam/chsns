﻿using System.Text;
using System.Web.Script.Serialization;

namespace CHSNS.Common.Serializer
{
    public static class JsonAdapter
    {
        /// <summary>
        /// 序列化 传入的对象 为Json字符串
        /// </summary>
        /// <param name="objToSer">要进行序列化 的 对象</param>
        /// <returns>序列化后 的 字符串</returns>
        public static string Serialize(object objToSer)
        {
            var serialize = new JavaScriptSerializer();
            var outputStringBuilder = new StringBuilder();
            serialize.Serialize(objToSer, outputStringBuilder);
            return outputStringBuilder.ToString();
        }

        /// <summary>
        /// 反序列化 Json字符串
        /// </summary>
        /// <typeparam name="T">泛型，来表示要进行 反序列化的类型</typeparam>
        /// <param name="jsonStr">准备要进行反序列化的Json 字符串</param>
        /// <returns>反序列化后 的 对象</returns>
        public static T Deserialize<T>(string jsonStr)
        {
            var serialize = new JavaScriptSerializer();
            return serialize.Deserialize<T>(jsonStr);
        }
    }
}
