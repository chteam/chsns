using CHSNS.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;

namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 AccountControllerTest 的测试类，旨在
    ///包含所有 AccountControllerTest 单元测试
    ///</summary>
    [TestClass]
    public class AccountControllerTest
    {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }


        /// <summary>
        ///UsernameCanUse 的测试
        ///</summary>
        // TODO: 确保 UrlToTest 属性指定一个指向 ASP.NET 页的 URL(例如，
        // http://.../Default.aspx)。这对于在 Web 服务器上执行单元测试是必需的，
        //无论要测试页、Web 服务还是 WCF 服务都是如此。
        [TestMethod]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("G:\\CHSNS2", "/")]
        [UrlToTest("http://localhost:6377/")]
        public void UsernameCanUseTest()
        {
            AccountController target = new AccountController(); // TODO: 初始化为适当的值
            string username = string.Empty; // TODO: 初始化为适当的值
            ActionResult expected = null; // TODO: 初始化为适当的值
            ActionResult actual;
            actual = target.UsernameCanUse(username);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SaveReg 的测试
        ///</summary>
        // TODO: 确保 UrlToTest 属性指定一个指向 ASP.NET 页的 URL(例如，
        // http://.../Default.aspx)。这对于在 Web 服务器上执行单元测试是必需的，
        //无论要测试页、Web 服务还是 WCF 服务都是如此。
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("G:\\CHSNS2", "/")]
        [UrlToTest("http://localhost:6377/")]
        public void SaveRegTest()
        {
            AccountController target = new AccountController(); // TODO: 初始化为适当的值
            string userName = string.Empty; // TODO: 初始化为适当的值
            string password = string.Empty; // TODO: 初始化为适当的值
            string name = string.Empty; // TODO: 初始化为适当的值
            ActionResult expected = null; // TODO: 初始化为适当的值
            ActionResult actual;
            actual = target.SaveReg(userName, password, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///RegPage 的测试
        ///</summary>
        // TODO: 确保 UrlToTest 属性指定一个指向 ASP.NET 页的 URL(例如，
        // http://.../Default.aspx)。这对于在 Web 服务器上执行单元测试是必需的，
        //无论要测试页、Web 服务还是 WCF 服务都是如此。
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("G:\\CHSNS2", "/")]
        [UrlToTest("http://localhost:6377/")]
        public void RegPageTest()
        {
            AccountController target = new AccountController(); // TODO: 初始化为适当的值
            ActionResult expected = null; // TODO: 初始化为适当的值
            ActionResult actual;
            actual = target.RegPage();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///Logout 的测试
        ///</summary>
        // TODO: 确保 UrlToTest 属性指定一个指向 ASP.NET 页的 URL(例如，
        // http://.../Default.aspx)。这对于在 Web 服务器上执行单元测试是必需的，
        //无论要测试页、Web 服务还是 WCF 服务都是如此。
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("G:\\CHSNS2", "/")]
        [UrlToTest("http://localhost:6377/")]
        public void LogoutTest()
        {
            AccountController target = new AccountController(); // TODO: 初始化为适当的值
            ActionResult expected = null; // TODO: 初始化为适当的值
            ActionResult actual;
            actual = target.Logout();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///Login 的测试
        ///</summary>
        // TODO: 确保 UrlToTest 属性指定一个指向 ASP.NET 页的 URL(例如，
        // http://.../Default.aspx)。这对于在 Web 服务器上执行单元测试是必需的，
        //无论要测试页、Web 服务还是 WCF 服务都是如此。
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("G:\\CHSNS2", "/")]
        [UrlToTest("http://localhost:6377/")]
        public void LoginTest()
        {
            AccountController target = new AccountController(); // TODO: 初始化为适当的值
            string u = string.Empty; // TODO: 初始化为适当的值
            string p = string.Empty; // TODO: 初始化为适当的值
            bool a = false; // TODO: 初始化为适当的值
            ActionResult expected = null; // TODO: 初始化为适当的值
            ActionResult actual;
            actual = target.Login(u, p, a);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }


        [TestMethod]
        public void InitCreaterTest()
        {
            var target = new AccountController();          
            var actual = target.InitCreater() as ViewResult;
            Assert.IsNotNull(actual);
          
        }

        [TestMethod]
        public void ChangePasswordPost()
        {
            var target = new AccountController(); // TODO: 初始化为适当的值
            string oldpassword = string.Empty; // TODO: 初始化为适当的值
            string password = string.Empty; // TODO: 初始化为适当的值
            ActionResult expected = null; // TODO: 初始化为适当的值
            var actual = target.ChangePassword(oldpassword, password) as ViewResult;
            Assert.AreEqual("您已经成功修改密码", actual.TempData["page_message"]);
        }

        [TestMethod]

        public void ChangePasswordGet()
        {
            var target = new AccountController(); // TODO: 初始化为适当的值
            var actual = target.ChangePassword()  as ViewResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual("修改密码", actual.ViewData["Page_title"]);
        }

        [TestMethod]
        public void AgreementTest()
        {
            var target = new AccountController(); // TODO: 初始化为适当的值
            ViewResult actual;
            actual = target.Agreement() as ViewResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual("注册 - 注册协议", actual.ViewData["Page_Title"]);
          
        }
    }
}
