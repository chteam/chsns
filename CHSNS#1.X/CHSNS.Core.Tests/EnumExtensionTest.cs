using CHSNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 EnumExtensionTest 的测试类，旨在
    ///包含所有 EnumExtensionTest 单元测试
    ///</summary>
    [TestClass()]
    public class EnumExtensionTest {


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


   
        /// <summary>
        ///ToDictionary 的测试
        ///</summary>
        public void ToDictionaryTestHelper<T>() {
            Enum e = null; // TODO: 初始化为适当的值
            Dictionary expected = null; // TODO: 初始化为适当的值
            Dictionary actual;
            actual = EnumExtension.ToDictionary<T>(e);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        [TestMethod()]
        public void ToDictionaryTest() {
            ToDictionaryTestHelper<GenericParameterHelper>();
        }
    }
}
