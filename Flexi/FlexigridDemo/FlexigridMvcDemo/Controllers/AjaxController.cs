﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.MobileControls;
using FlexigridMvcDemo.Models;
using MvcHelper;

namespace FlexigridMvcDemo.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/

        public ActionResult Index(int? page, int? rp, string sortname, string sortorder)
        {
            var sql = "select * from UserInfo";
            if (!string.IsNullOrEmpty(sortname))
                sql += string.Format(" order by {0} {1}", sortname, sortorder);
            var ad = new SqlDataAdapter(sql, DataConfig.ConnectionString);
            new SqlCommandBuilder(ad);
            var ds = new DataSet();
            ad.Fill(ds, "UserInfo");
            var pager = ds.Tables[0].AsEnumerable().Pager(page ?? 1, rp ?? 20);
            
            var json  = pager.ToFlexigridObject(page ?? 1, pager.TotalCount, "id");
            return Json(json);
        }
        public ActionResult Remove(int id)
        {
            using (var conn = new SqlConnection(DataConfig.ConnectionString))
            {
                var com = conn.CreateCommand();
                conn.Open();
                com.CommandText = "delete from userinfo where id=" + id;
                com.ExecuteNonQuery();
            }
            return Content("");
        }
        public ActionResult Add()
        {
            using (var conn = new SqlConnection(DataConfig.ConnectionString))
            {
                var com = conn.CreateCommand();
                conn.Open();
                com.CommandText = "insert userinfo(name,email,age) values(newid(),newid(),25)";
                com.ExecuteNonQuery();
            }
            return Content("");
        }
    }
}
