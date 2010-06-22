using System;

using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.Service {
    public class VideoService {
        static readonly VideoService Instance = new VideoService();
        private readonly VideoOperator _video;
        public VideoService() {
            _video = new VideoOperator();
        }

        public static VideoService GetInstance() {
            return Instance;
        }
        #region ICURDService<SuperNote> 成员

        public void Create(IUser user, SuperNote content) {
            content.UserId = user.UserId;
            content.AddTime = DateTime.Now;
            var m = new Media(content.Url);
            content.Title = content.Title ?? m.Title;
            content.FaceURL = m.Pic;
            content.Type = (byte)SuperNoteType.Video;
            _video.Create(content);
        }

        public void Update(SuperNote content) {
            throw new NotImplementedException();
        }

        public void Remove(IUser user,params long[] uid) {
            _video.Remove(user.UserId, uid);
        }

        public PagedList<SuperNote> List(long? uid,int p,int ep,IUser user) {
            //类型,时间排序,用户
            return _video.List(uid ?? user.UserId, p, ep);
        }

        #endregion
    }
}
