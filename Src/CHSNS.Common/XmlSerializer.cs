
namespace CHSNS
{
    using System.IO;

    public class XmlSerializer
    {
        /// <summary>
        /// 序列化到配置文件　
        /// </summary>
        /// <typeparam name="T">序列化此类型</typeparam>
        /// <param name="obj">要序列化的对象</param>
        /// <param name="filepath">文件路径</param>
        public static void Save<T>(T obj, string filepath) where T : class
        {
            var mySerializer = new System.Xml.Serialization.XmlSerializer(typeof (T));
            if (!File.Exists(filepath))
                File.Create(filepath);
            using (var myWriter = new StreamWriter(filepath))
            {
                mySerializer.Serialize(myWriter, obj);
            }
        }

        /// <summary>
        /// 从配置文件反序列化
        /// </summary>
        /// <parameters name="T"/>反序列化的目标类型
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public static T Load<T>(string filepath) where T : class
        {
            //string filepath = HttpContext.Current.Server.MapPath(fn);
            if (!File.Exists(filepath))
                File.Create(filepath);

            var mySerializer = new System.Xml.Serialization.XmlSerializer(typeof (T));
            using (Stream myFileStream = new StreamReader(filepath).BaseStream)
            {
                return mySerializer.Deserialize(myFileStream) as T;
            }
        }
    }
}