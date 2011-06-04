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
            const string expected = "8ElU3E8IM5P8wdMj26GZNw==";
            var actual = originalValue.DESEncrypt(DESKEY);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///DESEncrypt 的测试
        ///</summary>
        [TestMethod]
        public void DESEncryptTest() {
            const string originalValue = "sdfj89wjf;sdafj"; 
            const string expected = "/6nZEDbNazIXPhjVLLAZOQ==";
            var actual = originalValue.DESEncrypt(DESKEY, DESVI);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///DESDecrypt 的测试
        ///</summary>
        [TestMethod]
        public void DESDecryptTest1() {
            const string encryptedValue = "8ElU3E8IM5P8wdMj26GZNw==";
            const string expected = "sdfj89wjf;sdafj"; 
            var actual = encryptedValue.DESDecrypt(DESKEY);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///DESDecrypt 的测试
        ///</summary>
        [TestMethod]
        public void DESDecryptTest() {
            const string encryptedValue = "/6nZEDbNazIXPhjVLLAZOQ==";
            const string expected = "sdfj89wjf;sdafj";
            var actual = encryptedValue.DESDecrypt(DESKEY, DESVI);
            Assert.AreEqual(expected, actual);
        }
    }
}
