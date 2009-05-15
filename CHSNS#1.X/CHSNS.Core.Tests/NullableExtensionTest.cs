using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 NullableExtensionTest 的测试类，旨在
    ///包含所有 NullableExtensionTest 单元测试
    ///</summary>
    [TestClass]
    public class NullableExtensionTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void NullableExtensionGet() {
            int? x = 1;
            int? x1=null;
            Assert.AreEqual(x.Get(), 1);
            Assert.AreEqual(x1.Get(), DBNull.Value);
        }
    }
}
