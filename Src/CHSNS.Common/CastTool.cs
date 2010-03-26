namespace CHSNS {
    public class CastTool {
        static public TDest Cast<TDest>(object source) {
            var json = JsonAdapter.Serialize(source);
            return JsonAdapter.Deserialize<TDest>(json);
        }
    }
}