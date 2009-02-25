using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CHSNS;
using CHSNS.Controllers;
using Rhino.Mocks;
using Microsoft.Web.Testing.Light;
using UnitView;
using CHSNS.Models;
namespace CHSNS.MvcTest.Controllers
{
    [WebTestClass]

    public class HomeTest {
        [WebTestMethod]
        public void Index() {
            var data = new TestViewData<Note> {
                ControllerName = "Home",
                ActionName = "Index",
                Model = null
            };
            HtmlPage page = new HtmlPage(TestViewData.GenerateHostUrl(data));
            // Assert title
            Assert.AreEqual("UUSPARK旅游搜索 - 首页", page.Elements.Find("title", 0).GetInnerText());
        }
    }
}
 