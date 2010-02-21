using System;

using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.Service {
    public class VideoService {
        static readonly VideoService Instance = new VideoService();
        private readonly ISuperNoteOperator Video;
        public VideoService() {
            Video = new VideoOperator();
        }

        public static VideoService GetInstance() {
            return Instance;
        }
        #region ICURDService<SuperNote> 成员

        public void Create(IUser user, SuperNote content) {
            content.UserId = user.UserID;
            content.AddTime = DateTime.Now;
            var m = new Media(content.Url);
            content.Title = content.Title ?? m.Title;
            content.FaceURL = m.Pic;
            content.Type = (byte)SuperNoteType.Video;
            Video.Create(content);
        }

        public void Update(SuperNote content) {
            throw new NotImplementedException();
        }

        public void Remove(IUser user,params long[] uid) {
            Video.Remove(user.UserID, uid);
        }

        public PagedList<SuperNote> List(long? uid,int p,int ep,IUser user) {
            //类型,时间排序,用户
            return Video.List(uid ?? user.UserID, p, ep);
        }

        #endregion
    }
}
