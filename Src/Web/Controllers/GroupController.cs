using System.Collections.Generic;
using System.Web.Mvc;
using CHSNS.Model;
using System.Transactions;
using CHSNS.Models;


namespace CHSNS.Controllers {

    [Authorize]
    public partial class GroupController : BaseController
    {
        #region ��ҳ
        public virtual ActionResult Index(long id, int? p)
        {
            InitPage(ref p);

            #region Ⱥ��Ϣ���û�

            var g = ServicesFactory.Group.Get(id);
            if (g == null)
                return HttpNotFound("group not found");
            var u = ServicesFactory.Group.GetGroupUser(id, CHUser.UserId);
            if (u == null)
                return HttpNotFound("group user not found");
            ViewData["guser"] = u;
            Title = g.Name;

            #endregion

            #region Ȩ�޼���

            int ret = g.ShowLevel;
            if (u != null && u.Status != (byte) GroupUserStatus.Wait)
            {
                ret = 0;
            }
            if (User.IsInRole("admin"))
            {
                ret = 0;
            }

            var userlevel = 0;
            if (User.IsInRole("admin"))
            {
                ret = 0;
                userlevel = 255;
            }
            else
            {
                if (u != null) userlevel = u.Status;
            }
            ViewData["right"] = userlevel;
            ViewData["showlevel"] = ret;

            #endregion

            #region ͳ��

            ViewData["MemberList"] = ServicesFactory.View.ViewList(6, 2, g.Id, 6);
            ViewData["ViewList"] = ServicesFactory.View.ViewList(1, 6, g.Id, 6);

            ViewData["Applycount"] = ServicesFactory.Group.WaitJoinCount(id);

            var adminList = ServicesFactory.Group.GetAdmins(id);
            ViewData["adminlist"] = adminList;

            #endregion

            var posts = ServicesFactory.Note.GetNotes(id, NoteType.GroupPost, p.Value, 20);
            ViewData["posts"] = posts;
            return View(g);
        }

        #endregion

        public virtual ActionResult List(long? uid, int? p)
        {
            InitPage(ref p);
            uid = uid ?? CHUser.UserId;
            Title = "Ⱥ�б�";
            return View(ServicesFactory.Group.GetList(uid.Value, p.Value, 10));
        }

        #region Create
        [HttpGet]
        public virtual ActionResult Create()
        {
            Title = "�½�Ⱥ";
            //ViewData["category"] = ConfigSerializer.GetConfig("Category").ToSelectList(c => c.Value, c => c.Text);
            return View();
        }
        [HttpPost]
        public virtual ActionResult Create(string name)
        {
            Message = "�����ɹ�";
            ServicesFactory.Group.Add(name, CHUser.UserId);
            return this.RedirectToReferrer();
        }
        #endregion

        #region ����
        [HttpGet]
        public virtual ActionResult Manage(long id)
        {
            //TODO:���Ʒ�����Ա
            return ManageResult(ServicesFactory.Group.Get(id));
        }

        [NonAction]
        ActionResult ManageResult(Group g) {
            if (g == null)
                return HttpNotFound("group not found");
            Title = g.Name + "����";
            ViewData["group.ShowLevel"] = new SelectList(
                ConfigSerializer.Load<List<SelectListItem>>("Group/ShowLevel"),
                "Value", "Text", g.ShowLevel);
            ViewData["group.JoinLevel"] = new SelectList(
                ConfigSerializer.Load<List<SelectListItem>>("Group/JoinLevel"),
                "Value", "Text", g.JoinLevel);
            ViewData["group"] = g;
            return View();
        }

        [HttpPost]
        public virtual ActionResult Manage(long id, Group group)
        {
            //TODO:���Ʒ�����Ա
            ServicesFactory.Group.Update(id, group);
            return RedirectToAction("Manage", new{id});
        }

        #endregion

        #region �û�����
        public virtual ActionResult ManageUser(long id)
        {
            Title = "�û�����";
            ViewData["list"] = ServicesFactory.Group.GetGroupUser(id);
            
            return View();
        }
        #endregion

        #region ����
        public virtual ActionResult Details(long id)
        {
            var note = ServicesFactory.Note.Details(id, NoteType.GroupPost);
            var cl = ServicesFactory.Comment.CommentList(id, CommentType.Note, 1, CHContext.Site);
            ViewData["commentlist"] = cl;
            Title = note.Title;
            return View(note);
        }

        [HttpPost]
        public virtual ActionResult Post(long? id, Note note)
        {
            using (var ts = new TransactionScope()) {
                if (note.Title.Length < 1 || note.Body.Length < 1) {
                    Message = "��������ȷ����־����";
                    return this.RedirectToReferrer();
                }
                note.Type = (int)NoteType.GroupPost;
                note.UserId = CHContext.User.UserId;
                if (id.HasValue) {
                    note.Id = id.Value;
                    ServicesFactory.Note.Edit(note);
                } else {
                    ServicesFactory.Note.Add(note,CHUser);
                }
                ts.Complete();
                return this.RedirectToReferrer();
            }
        }
        #endregion
        /*public void ClassList() {

            Dictionary dict = new Dictionary();
            dict.Add("@userid", CHSNSUser.Current.UserId);
            ViewData.Add("rows",DataBaseExecutor.GetRows(
                "GetRelationClass", dict));
        }
        
        public void CreateClass() {
            Dictionary dict=new Dictionary();
            dict.Add("@userid",CHSNSUser.Current.UserId);
            DataRowCollection rows = DataBaseExecutor.GetRows(
                "SchoolInfo", dict);
            if (rows.Count != 0) {
                ViewData.Add("University", rows[0]["University"]);
                ViewData.Add("Xueyuan", rows[0]["XueYuan"]);
                ViewData.Add("Grade", rows[0]["Grade"]);
            }
        }

        public ActionResult ShowGroupList(string template,long Ownerid,
            int groupclass,int Npage,int Epage,int type) {
            return View(template, DataBaseExecutor.GetRows("GroupList",
                "@userid", Ownerid
                , "@page", Npage
                , "@everypage", Epage
                , "@GroupClass", groupclass
                , "@type", type
                ));
        }*/
    }
}
