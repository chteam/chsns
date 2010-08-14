
namespace CHSNS.Common
{
    using System.Web;
    using System.Diagnostics.CodeAnalysis;

    public class ImageOptimizationModule : IHttpModule {
        private static readonly object _lockObj = new object();
        private static bool _hasAlreadyRun;

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public void Init(HttpApplication context) {
            lock (_lockObj) {
                if (_hasAlreadyRun)
                    return;
                else
                    _hasAlreadyRun = true;
            }

            ImageOptimizations.AddCacheDependencies(context.Context.Server.MapPath("~/App_Sprites/"), rebuildImages: true);
            return;
        }

        public void Dispose() { }
    }
}
