namespace CHSNS.Interface {
    /// <summary>
    /// 路径生成器
    /// </summary>
    public interface IPathBuilder {
        /// <summary>
        /// 源路径
        /// </summary>
        string SourcePath { get; set; }
        /// <summary>
        /// 目标路径
        /// </summary>
        string DescPath { get; }
    }
}