using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 EnumerableExtensionsTest 的测试类，旨在
    ///包含所有 EnumerableExtensionsTest 单元测试
    ///</summary>
    [TestClass]
    public class EnumerableExtensionsTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }



        /// <summary>
        ///ToNotNull 的测试
        ///</summary>
        public void ToNotNullTestHelper<T>()
        {
            const IEnumerable<T> ie = null;
            Assert.IsNotNull(ie.ToNotNull());
        }

        [TestMethod]
        public void EnumerableToNotNullTest() {
            ToNotNullTestHelper<GenericParameterHelper>();
            ToNotNullTestHelper<int>();
        }
    }
}
