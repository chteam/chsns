using System.Web;

namespace CHSNS.Common.PathBuilder
{
    using Interface;

    /// <summary>
    /// 使用Server.MapPath来生成目标路径
    /// </summary>
    public class ServerPathBuilder : IPathBuilder
    {
        private readonly HttpServerUtilityBase Server;
        private string _descpath;

        public ServerPathBuilder(HttpServerUtilityBase server)
        {
            Server = server;
        }

        public ServerPathBuilder(HttpServerUtilityBase server, string path)
        {
            Server = server;
            SourcePath = path;
        }

        #region IPathBuilder Members

        public string SourcePath { get; set; }

        public string DescPath
        {
            get
            {
                if (string.IsNullOrEmpty(_descpath))
                {
                    _descpath = Server.MapPath(SourcePath);
                }
                return _descpath;
            }
        }

        #endregion
    }
}