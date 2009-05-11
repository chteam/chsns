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


   
       

        [TestMethod()]
        public void ToDictionaryTest() {
            EnumExtensionType x = (EnumExtensionType) 0;
            var dict = EnumExtension.ToDictionary<EnumExtensionType>(x);
            Assert.AreEqual(dict["A"], 3);
            Assert.AreEqual(dict["B"], 8);
        }
    }
    enum EnumExtensionType
    {
        A=3,B=8
    }
}
