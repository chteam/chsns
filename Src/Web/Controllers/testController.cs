using System.Web.Mvc;
using CHSNS.Models;
using System.Configuration;

namespace CHSNS.Controllers
{
    //using Castle.Components.Common.EmailSender;
    
    //using ChAlumna.TemplateEngine;
    //using ChAlumna.components;
//	[Rescue("index")]
    public partial class TestController : BaseController 
    {
        //private DefaultControllerFactory factory;

        //public virtual ActionResult Index()
        //{
            //var db = new DataBaseExecutor(new SqlDataOpener(
            //    @"Data Source=.\SQLEXPRESS;Initial Catalog=sq_menglei;Integrated Security=True"
            //    ));
            //var rows = db.GetRows("select id,name from province");
            //List<Province> ps = new List<Province>();
            //foreach (DataRow dr in rows)
            //    ps.Add(new Province {
            //        ID = dr.Field<int>("id"),
            //        Name = dr.Field<string>("name")
            //    });
            //ConfigSerializer.Serializer<List<Province>>(ps, "Province");
            //var rows2 = db.GetRows("select id,name,pid from city");
            //List<City> cs = new List<City>();
            //foreach (DataRow dr in rows2)
            //    cs.Add(new City {
            //        ID = dr.Field<int>("id"),
            //        Name = dr.Field<string>("name"),
            //        ParentId = dr.Field<int>("pid")
            //    });
            //ConfigSerializer.Serializer<List<City>>(cs, "City");
            //string str = "";
            //foreach (object item in HttpContext.Session.Keys) {
            //    if (HttpContext.Session[item.ToString()] != null)
            //        str += string.Format("{0}:{1}<br/>", item, HttpContext.Session[item.ToString()]);
            //}

        //	return Content("");
        //}
        public virtual ActionResult Index()
        {
            using (var db = new DbEntities(
                    ConfigurationManager.ConnectionStrings["CHSNSDBLink"].ConnectionString
                    ))
            {
                int i = 100;
                db.ExecuteStoreCommand(
            "INSERT INTO [Tags]([Title],[Count],[Type])VALUES('',@id,2);",i);
                var c =
                   db.ExecuteStoreCommand(
               "UPDATE [TAGS] SET COUNT+=1;");
              //  var ret = c.Execute(mergeOption: System.Data.Objects.MergeOption.AppendOnly);

                return Content(c.ToString());
            }

        }
        //#region NVelocity
        //public void nvelocity() {
        //    VelocityEngine velocity = new VelocityEngine();

        //    ExtendedProperties props = new ExtendedProperties();
        //    ArrayList paths = new ArrayList();
        //    paths.Add(".");
        //    paths.Add("C:\\Chsword\\Web\\");

        //    props.AddProperty("file.resource.loader.path", paths);

        //    velocity.Init(props);
        //    Template template = velocity.GetTemplate(@"\views\Components\utility.vm");





        //    StringWriter writer1 = new StringWriter();
        //        TextWriter sw = new StreamWriter(writer);
        //    NVelocityViewContextAdapter c=new NVelocityViewContextAdapter
        //    VelocityContext context = new VelocityContext();
        //    if (template != null) {
        //        template.Merge(context, writer1);
        //    }

        //    ViewData.Add("note", writer1.GetStringBuilder().ToString());

        //}
        //#endregion
        
    }
}
