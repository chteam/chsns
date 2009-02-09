using CHSNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace CHSNS.Test {
    /// <summary>
    ///这是 DictionaryTest 的测试类，旨在
    ///包含所有 DictionaryTest 单元测试
    ///</summary>
    [TestClass()]
    public class DictionaryTest {
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


        #region ToJsonString
        /// <summary>
        ///ToJsonString 的测试
        ///</summary>
        [TestMethod()]
        public void ToJsonStringTest() {
            Dictionary a = new Dictionary();
            a.Add("title", "gogo");
            Assert.AreEqual(a.ToJsonString(), "{title:'gogo'}");

        }
        #endregion
        #region CreateFromArgs
        /// <summary>
        ///CreateFromArgs 的测试
        ///</summary>
        [TestMethod()]
        public void CreateFromArgsTest() {
            object[] args = null; // TODO: 初始化为适当的值
            Dictionary expected = new Dictionary(); // TODO: 初始化为适当的值
            expected.Add("id", 1);
            expected.Add("name", "xx");
            Dictionary actual;
            actual = Dictionary.CreateFromArgs("id", 1, "name", "xx");
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.IsTrue(expected.ContainsKey("id"));
            Assert.IsTrue(expected.ContainsKey("name"));
            Assert.AreEqual(expected["id"], actual["id"]);
            Assert.AreEqual(expected["name"], actual["name"]);
        }
        #endregion

        #region ctor
        /// <summary>
        ///Dictionary 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void DictionaryConstructorTest() {
            Dictionary target = new Dictionary();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }
        #endregion

    }
}