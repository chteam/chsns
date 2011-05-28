using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CHSNS
{
    ///<summary>自定义的字典
    ///</summary>
    [Serializable]
    public class Dictionary : Dictionary<string, object>
    {
        public Dictionary() { }
        protected Dictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        ///<summary>数组转为字典
        ///</summary>
        ///<param name="args"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public static Dictionary CreateFromArgs(params object[] args)
        {
            if (args.Length % 2 != 0)
                throw new ArgumentException("参数必须为偶数个。", "args");
            var dict = new Dictionary();
            for (var i = 0; i < args.Length; i += 2)
            {
                dict.Add(args[i].ToString(), args[i + 1]);
            }
            return dict;
        }
       
    }
}