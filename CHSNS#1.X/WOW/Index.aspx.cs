using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOW.localhost;

namespace WOW
{
    public partial class Index : System.Web.UI.Page
    {
        Users user = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.Where(c => c.UID == user.UserID()).FirstOrDefault();
                if (u == null)
                {   
                    //参加应用
                    Response.Redirect("Join.aspx");
                }
                if (u.Character.Count==0)
                {
                    //没创建角色
                }
                if (u.Character1 == null)
                {
                    //没设置当前角色
                }
                //可以使用了

            }
        }
    }
}
