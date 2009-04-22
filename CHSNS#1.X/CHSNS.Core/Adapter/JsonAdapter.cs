namespace CHSNS{
    public class JsonAdapter {
        static public string Serialize(object o) {
            try {
                return Newtonsoft.Json.JsonConvert.SerializeObject(o);
            }
            catch
            {
                return string.Empty;
            }
        }
        static public T Deserialize<T>(string o) {
            try {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(o);
            }
            catch {
                return default(T);
            }
        }

    }
}
