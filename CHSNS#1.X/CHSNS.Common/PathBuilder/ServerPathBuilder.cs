using System.Web;

namespace CHSNS.Common.PathBuilder {
    /// <summary>
    /// 使用Server.MapPath来生成目标路径
    /// </summary>
    public class ServerPathBuilder : IPathBuilder {
        private readonly HttpServerUtilityBase Server;
        public ServerPathBuilder(HttpServerUtilityBase server) {
            Server = server;
        }
        public ServerPathBuilder(HttpServerUtilityBase server, string path) {
            Server = server;
            SourcePath = path;
        }

        public string SourcePath { get; set; }
        private string _descpath;
        public string DescPath {
            get {
                if (string.IsNullOrEmpty(_descpath)) {
                    _descpath = Server.MapPath(SourcePath);
                }
                return _descpath;
            }
        }
    }
}
