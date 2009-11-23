
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 HtmlEncodeExtensionTest 的测试类，旨在
    ///包含所有 HtmlEncodeExtensionTest 单元测试
    ///</summary>
    [TestClass]
    public class HtmlEncodeExtensionTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }


        /// <summary>
        ///HtmlEncode 的测试
        ///</summary>
        [TestMethod]
        public void HtmlEncodeTest1() {
            const string s = "\x00a0Ā \n\r&<a href='http://www.live.com'>初始化<a/>'\"";
            const string expected = "&#160;Ā \n\r&amp;&lt;a href='http://www.live.com'&gt;初始化&lt;a/&gt;'&quot;";
            var actual = s.HtmlEncode();
            Assert.AreEqual(expected, actual);
            const string str = null;
            Assert.AreEqual(null, str.HtmlEncode());
        }

    }
}
