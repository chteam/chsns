using CHSNS.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace CHSNS.Test
{
    
    
    /// <summary>
    ///这是 HtmlHelperExtTest 的测试类，旨在
    ///包含所有 HtmlHelperExtTest 单元测试
    ///</summary>
	[TestClass()]
	public class HtmlHelperExtTest {


		private TestContext testContextInstance;

		/// <summary>
		///获取或设置测试上下文，上下文提供
		///有关当前测试运行及其功能的信息。
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		#region 附加测试属性
		// 
		//编写测试时，还可使用以下属性:
		//
		//使用 ClassInitialize 在运行类中的第一个测试前先运行代码
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//使用 ClassCleanup 在运行完类中的所有测试后再运行代码
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//使用 TestInitialize 在运行每个测试前先运行代码
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//使用 TestCleanup 在运行完每个测试后运行代码
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///UserPageLink 的测试
		///</summary>
		[TestMethod()]
		public void UserPageLinkTest() {
			HtmlHelper Html = null; // TODO: 初始化为适当的值
			long userid = 0; // TODO: 初始化为适当的值
			string text = string.Empty; // TODO: 初始化为适当的值
			string expected = string.Empty; // TODO: 初始化为适当的值
			string actual;
			actual = HtmlHelperExt.UserPageLink(Html, userid, text);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///UserEditLink 的测试
		///</summary>
		[TestMethod()]
		public void UserEditLinkTest() {
			HtmlHelper Html = null; // TODO: 初始化为适当的值
			string mode = string.Empty; // TODO: 初始化为适当的值
			string text = string.Empty; // TODO: 初始化为适当的值
			string expected = string.Empty; // TODO: 初始化为适当的值
			string actual;
			actual = HtmlHelperExt.UserEditLink(Html, mode, text);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///FriendLink 的测试
		///</summary>
		[TestMethod()]
		public void FriendLinkTest1() {
			HtmlHelper Html = null; // TODO: 初始化为适当的值
			long userid = 0; // TODO: 初始化为适当的值
			string text = string.Empty; // TODO: 初始化为适当的值
			string expected = string.Empty; // TODO: 初始化为适当的值
			string actual;
			actual = HtmlHelperExt.FriendLink(Html, userid, text);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///FriendLink 的测试
		///</summary>
		[TestMethod()]
		public void FriendLinkTest() {
			HtmlHelper Html = null; // TODO: 初始化为适当的值
			long userid = 0; // TODO: 初始化为适当的值
			string expected = string.Empty; // TODO: 初始化为适当的值
			string actual;
			actual = HtmlHelperExt.FriendLink(Html, userid);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///BlogLink 的测试
		///</summary>
		[TestMethod()]
		public void BlogLinkTest1() {
			HtmlHelper Html = null; // TODO: 初始化为适当的值
			long userid = 0; // TODO: 初始化为适当的值
			string text = string.Empty; // TODO: 初始化为适当的值
			string expected = string.Empty; // TODO: 初始化为适当的值
			string actual;
			actual = HtmlHelperExt.BlogLink(Html, userid, text);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///BlogLink 的测试
		///</summary>
		[TestMethod()]
		public void BlogLinkTest() {
			HtmlHelper Html = null; // TODO: 初始化为适当的值
			long userid = 0; // TODO: 初始化为适当的值
			string expected = string.Empty; // TODO: 初始化为适当的值
			string actual;
			actual = HtmlHelperExt.BlogLink(Html, userid);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///AlbumLink 的测试
		///</summary>
		[TestMethod()]
		public void AlbumLinkTest1() {
			HtmlHelper Html = null; // TODO: 初始化为适当的值
			long userid = 0; // TODO: 初始化为适当的值
			string text = string.Empty; // TODO: 初始化为适当的值
			string expected = string.Empty; // TODO: 初始化为适当的值
			string actual;
			actual = HtmlHelperExt.AlbumLink(Html, userid, text);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///AlbumLink 的测试
		///</summary>
		[TestMethod()]
		public void AlbumLinkTest() {
			HtmlHelper Html = null; // TODO: 初始化为适当的值
			long userid = 0; // TODO: 初始化为适当的值
			string expected = string.Empty; // TODO: 初始化为适当的值
			string actual;
			actual = HtmlHelperExt.AlbumLink(Html, userid);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("验证此测试方法的正确性。");
		}
	}
}
