using CHSNS.Common.Serializer;

namespace CHSNS
{
    public class CastTool
    {
        public static TDest Cast<TDest>(object source)
        {
            string json = JsonAdapter.Serialize(source);
            return JsonAdapter.Deserialize<TDest>(json);
        }
    }
}