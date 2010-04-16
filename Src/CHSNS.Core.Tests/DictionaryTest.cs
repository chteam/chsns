//using System.Web.TestUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.TestUtil;

namespace CHSNS.Test {
    /// <summary>
    ///这是 DictionaryTest 的测试类，旨在
    ///包含所有 DictionaryTest 单元测试
    ///</summary>
    [TestClass]
    public class DictionaryTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }

        #region ToJsonString
        /// <summary>
        ///ToJsonString 的测试
        ///</summary>
        [TestMethod]
        public void ToJsonStringTest() {
            var a = new Dictionary {{"title", "gogo"}};
            Assert.AreEqual(a.ToJsonString(), "{\"title\":\"gogo\"}");

        }
        #endregion
        #region CreateFromArgs
        /// <summary>
        ///CreateFromArgs 的测试
        ///</summary>
        [TestMethod]
        public void CreateFromArgsTest() {
            var expected = new Dictionary {{"id", 1}, {"name", "xx"}}; 
            var actual = Dictionary.CreateFromArgs("id", 1, "name", "xx");
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.IsTrue(expected.ContainsKey("id"));
            Assert.IsTrue(expected.ContainsKey("name"));
            Assert.AreEqual(expected["id"], actual["id"]);
            Assert.AreEqual(expected["name"], actual["name"]);
            ExceptionHelper.ExpectArgumentException(
                () => Dictionary.CreateFromArgs("id", 1, "name", "xx", "untitl"),
                "参数必须为偶数个。");
        }
        #endregion

        #region ctor
        /// <summary>
        ///Dictionary 构造函数 的测试
        ///</summary>
        [TestMethod]
        public void DictionaryConstructorTest() {
            var dict = new Dictionary();

            Assert.IsNotNull(dict);
        }
        #endregion

    }
}