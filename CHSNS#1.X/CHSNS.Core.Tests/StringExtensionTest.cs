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
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }


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
