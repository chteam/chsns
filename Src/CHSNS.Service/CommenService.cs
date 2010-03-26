﻿using System;
using CHSNS.Config;
using CHSNS.Model;

using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.Service {
    public class CommentService {
        static readonly CommentService Instance = new CommentService();
        private readonly ICommentOperator Comment;
        public CommentService() {
            Comment = new CommentOperator();
        }

        public static CommentService GetInstance() {
            return Instance;
        }

        #region reply

        public PagedList<CommentPas> GetReply(long uid, int p, int ep) {
            return Comment.GetReply(uid, p, ep);
        }
        public Reply AddReply(Reply r) {
            r.AddTime = DateTime.Now;
            return Comment.AddReply(r);
        }

        public void DeleteReply(long id, long userid) {
            Comment.DeleteReply(id, userid);
        }

        #endregion

        #region comment

        /// <summary>
        /// Comments the list.
        /// </summary>
        /// <param name="ShowerID">The shower ID.</param>
        /// <param name="type">The type.</param>
        /// <param name="p"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public PagedList<CommentPas> CommentList(long ShowerID, CommentType type, int p
            , SiteConfig site) {
            return Comment.CommentList(ShowerID, type, p, site.EveryPage.NoteComment);


        }

        /// <summary>
        /// 删除回复
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Delete(long id, CommentType type) {
            return Comment.Delete(id, type);
        }


        public void Add(Comment cmt, CommentType type) {
            cmt.AddTime = DateTime.Now;
            Comment.Add(cmt, type);
        }

        #endregion
    }
}