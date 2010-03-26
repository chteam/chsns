using System.Web.Script.Serialization;
using System.Text;
namespace CHSNS
{
    public static class JsonAdapter
    {
        static public string Serialize(object o)
        {
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            var outputStringBuilder = new StringBuilder();
            serialize.Serialize(o, outputStringBuilder);
            return outputStringBuilder.ToString();

        }

        static public T Deserialize<T>(string o)
        {
            try
            {
                JavaScriptSerializer serialize = new JavaScriptSerializer();
                var outputStringBuilder = new StringBuilder();
                return serialize.Deserialize<T>(o);
            }
            catch
            {
                return default(T);
            }
        }

    }
}
