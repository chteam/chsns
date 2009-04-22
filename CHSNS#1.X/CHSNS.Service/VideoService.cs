using System;
using CHSNS.Abstractions;
using CHSNS.Operator;

namespace CHSNS.Service {
    public class VideoService {
        static readonly VideoService _instance = new VideoService();
        private readonly ISuperNoteOperator Video;
        public VideoService() {
            Video = new VideoOperator();
        }

        public static VideoService GetInstance() {
            return _instance;
        }
        #region ICURDService<SuperNote> 成员

        public void Create(IUser user, ISuperNote content) {
            content.UserID = user.UserID;
            content.AddTime = DateTime.Now;
            var m = new Media(content.Url);
            content.Title = content.Title ?? m.Title;
            content.Faceurl = m.Pic;
            content.Type = (byte)SuperNoteType.Video;
            Video.Create(content);
        }

        public void Update(ISuperNote content) {
            throw new NotImplementedException();
        }

        public void Remove(IUser user,params long[] uid) {
            Video.Remove(user.UserID, uid);
        }

        public PagedList<ISuperNote> List(long? uid,int p,int ep,IUser user) {
            //类型,时间排序,用户
            return Video.List(uid ?? user.UserID, p, ep);
        }

        #endregion
    }
}
