namespace CHSNS.Interface {
    /// <summary>
    /// ·��������
    /// </summary>
    public interface IPathBuilder {
        /// <summary>
        /// Դ·��
        /// </summary>
        string SourcePath { get; set; }
        /// <summary>
        /// Ŀ��·��
        /// </summary>
        string DescPath { get; }
    }
}