using CHSNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Security;
namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 StringExtensionTest 的测试类，旨在
    ///包含所有 StringExtensionTest 单元测试
    ///</summary>
	[TestClass()]
	public class StringExtensionTest {


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
		///ToMd5 的测试
		///</summary>
		[TestMethod()]
		public void ToMd5Test() {
            Assert.AreEqual("".ToMd5(), FormsAuthentication.HashPasswordForStoringInConfigFile("", "MD5"));
            Assert.AreEqual("MD5".ToMd5(), FormsAuthentication.HashPasswordForStoringInConfigFile("MD5", "MD5"));
            Assert.AreEqual(new string('x', 10000000).ToMd5(), FormsAuthentication.HashPasswordForStoringInConfigFile(new string('x', 10000000), "MD5"));

		}

		/// <summary>
		///NoHtml 的测试
		///</summary>
		[TestMethod()]
		public void NoHtmlTest() {
			const string str = @"asdffg<br><><script type='text/javascript'></script>
<br /> <br><br               />asd";
            var expected = @"asdffg<br />
<br /> <br /><br />asd";
			var actual = str.NoHtml();
			Assert.AreEqual(expected, actual);

		}

        /// <summary>
        ///TrimEnd 的测试
        ///</summary>
        [TestMethod()]
        public void TrimEndTest() {
            Assert.AreEqual("abcdefghhhd".TrimEnd("hd"), "abcdefghh");
            Assert.AreEqual("a".TrimEnd("hd"), "a");
       }

        /// <summary>
        ///SubStr 的测试
        ///</summary>
        [TestMethod()]
        public void SubStrTest() {
            string str = "whatisyourname"; // TODO: 初始化为适当的值
         //   int n = 0; // TODO: 初始化为适当的值
          //  string actual;
            Assert.AreEqual(str.SubStr(100), "whatisyourname");
            Assert.AreEqual(str.SubStr(4), "what");
        }


	}
}
