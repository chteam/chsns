 
namespace CHSNS
{
    public class CastTool
    {
        public static TDest Cast<TDest>(object source)
        {
            return AutoMapper.Mapper.Map<TDest>(source);
        }
    }
}