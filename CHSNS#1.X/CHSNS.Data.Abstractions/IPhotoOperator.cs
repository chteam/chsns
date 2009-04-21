using CHSNS.Models.Abstractions;

namespace CHSNS.Operator{
	public interface IPhotoOperator{
	    void Add(IPhoto photo);
	   IPhoto Get(long id);
	    void Delete(long id);
	}
}