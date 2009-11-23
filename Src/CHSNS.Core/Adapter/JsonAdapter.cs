namespace CHSNS{
    public static class JsonAdapter {
        static public string Serialize(object o)
        {

            return Newtonsoft.Json.JsonConvert.SerializeObject(o);
            // try {  }
            //catch
            //{
            //    return string.Empty;
            //}
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
