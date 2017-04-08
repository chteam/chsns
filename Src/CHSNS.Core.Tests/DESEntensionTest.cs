using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CHSNS.Core.Tests
{
    using CHSNS.Encrypt;


    /// <summary>
    ///这是 DESEntensionTest 的测试类，旨在
    ///包含所有 DESEntensionTest 单元测试
    ///</summary>
    [TestClass]
    public class DESEntensionTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }

        private const string DESKEY = "sal'JI897";
        private const string DESVI = "ar45e']";
        /// <summary>
        ///DESEncrypt 的测试
        ///</summary>
        [TestMethod]
        public void DESEncryptTest1() {
            const string originalValue = "sdfj89wjf;sdafj";

            var actual = originalValue.DESEncrypt(DESKEY);
            var decrypt = actual.DESDecrypt(DESKEY);
            Assert.AreEqual(originalValue, decrypt);
        }

        /// <summary>
        ///DESEncrypt 的测试
        ///</summary>
        [TestMethod]
        public void DESEncryptTest() {
            const string originalValue = "sdfj89wjf;sdafj"; 
             
            var actual = originalValue.DESEncrypt(DESKEY, DESVI);
            var decrypt = actual.DESDecrypt(DESKEY, DESVI);
            Assert.AreEqual(originalValue, decrypt);

        }

 
    }
}
