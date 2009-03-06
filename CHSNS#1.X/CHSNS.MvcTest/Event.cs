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
using CHSNS.ViewModel;
namespace CHSNS.MvcTest
{
    [WebTestClass]
    public class Event
    {
        [WebTestMethod]
        public void Index()
        {
            var data = new TestViewData<EventIndexViewModel>
            {
                ControllerName = "Home",
                ActionName = "Index",
                Model = new EventIndexViewModel
                {
                }
            };
            HtmlPage page = new HtmlPage(TestViewData.GenerateHostUrl(data));
            // Assert title
            Assert.AreEqual("UUSPARK旅游搜索 - 首页", page.Elements.Find("title", 0).GetInnerText());
        }
    }
}
