namespace CHSNS
{
    public class CacheFactory
    {
        public static ICache Instance { get;private set; }
        public static void Register(ICache cache) {
            Instance = cache;
        }
    }
}
