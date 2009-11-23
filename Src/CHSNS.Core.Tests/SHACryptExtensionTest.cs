using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 SHACryptExtensionTest 的测试类，旨在
    ///包含所有 SHACryptExtensionTest 单元测试
    ///</summary>
    [TestClass]
    public class SHACryptExtensionTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }

        private const string SOURCESTRING = @"asdfjl;f,[e]=-43320590uifahklsfd5+789+-*/-*/fsdafkp\//.,joi28{}|_+(*():>?<";

        /// <summary>
        ///ToSHA1 的测试
        ///</summary>
        [TestMethod]
        public void ToSHA1() {

            const string expected = "05EAE9582A1F950D404B3E61E3AE6C4E16E35D37"; 
            string actual = SOURCESTRING.ToSHA1();
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///SHA512Encrypt 的测试
        ///</summary>
        [TestMethod]
        public void SHA512Encrypt() {

            const string expected = "E582F2234CD1D198B76F79A256B97E01E0CBE45D1F09F65A8D9468E3610F95DEE9635C43B5C6F730098DDD4A9A8A1F7F02F6C9A7E6B4CD8CC75F0FE96B537CA8"; 
            string actual = SHACryptExtension.SHA512Encrypt(SOURCESTRING);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///SHA256Encrypt 的测试
        ///</summary>
        [TestMethod]
        public void SHA256Encrypt() {

            const string expected = "24F608A7F6A836BAA7372B57DC06E0E362242024C64573403C90867EB05DF6DC";
            string actual = SHACryptExtension.SHA256Encrypt(SOURCESTRING);
            Assert.AreEqual(expected, actual);

        }
    }
}
