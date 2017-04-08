namespace CHSNS.Common.PathBuilder
{
    using CHSNS.Interface;

    /// <summary>
    /// 使用Server.MapPath来生成目标路径
    /// </summary>
    public class ServerPathBuilder : IPathBuilder
    {
       // private readonly HttpServerUtilityBase _server;
        private string _descpath;

        //public ServerPathBuilder(HttpServerUtilityBase server)
        //{
        //    _server = server;
        //}

        //public ServerPathBuilder(HttpServerUtilityBase server, string path)
        //{
        //    _server = server;
        //    SourcePath = path;
        //}

        #region IPathBuilder Members

        public string SourcePath { get; set; }

        public string DescPath
        {
            get
            {
                if (string.IsNullOrEmpty(_descpath))
                {
                   // _descpath = _server.MapPath(SourcePath);
                }
                return _descpath;
            }
        }

        #endregion
    }
}