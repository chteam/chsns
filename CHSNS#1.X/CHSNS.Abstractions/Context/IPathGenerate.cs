namespace CHSNS{
    /// <summary>
    /// ���޶����������Գ�Ϊstatic ����
    /// </summary>
    public interface IPathGenerate{
        /// <summary>
        /// ������/fils/userid/filname.ext���û�ͼƬ·��
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        string NewPhoto(long userId, string fileExt);
    }
}