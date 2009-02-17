using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOW.localhost;

namespace WOW
{
    public partial class Join : System.Web.UI.Page
    {
        Users user = new Users();
        protected void Clicke(object sender, EventArgs e)
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.Where(c => c.UID == user.UserID()).FirstOrDefault();
                if (u == null)
                {
                    u = new CurrentUser()
                    {
                        ConsumerGB = 0,
                        Evaluation = 0,
                        GB = 100,
                        UID = user.UserID(),
                        WorkerGB = 0
                    };
                    w.CurrentUser.InsertOnSubmit(u);
                    w.SubmitChanges();
                    //参加应用
                    Response.Redirect("Index.aspx");
                }
            }
        }
    }
}
