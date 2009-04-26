namespace CHSNS{
    /// <summary>
    /// 暂无对象依赖可以成为static 单例
    /// </summary>
    public interface IPathGenerate{
        /// <summary>
        /// 生成如/fils/userid/filname.ext的用户图片路径
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        string NewPhoto(long userId, string fileExt);
    }
}