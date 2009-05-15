using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 BytesExtensionTest 的测试类，旨在
    ///包含所有 BytesExtensionTest 单元测试
    ///</summary>
    [TestClass]
    public class BytesExtensionTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }



        /// <summary>
        ///ToHexLowerString 的测试
        ///</summary>
        [TestMethod]
        public void ToHexLowerStringTest() {
            var data = new byte[] { 254, 20, 1, 5, 255 };
            const string expected = "fe140105ff";
            var actual = data.ToHexLowerString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ToHexUpperString 的测试
        ///</summary>
        [TestMethod]
        public void ToHexUpperStringTest() {
            var data = new byte[] { 254, 20, 1, 5, 255 };
            const string expected = "FE140105FF";
            var actual = data.ToHexUpperString();
            Assert.AreEqual(expected, actual);
        }
    }
}
