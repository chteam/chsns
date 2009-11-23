using System.Web;
namespace CHSNS {
	public interface IApplication {
		HttpApplicationState Application { get; }
	}
}
