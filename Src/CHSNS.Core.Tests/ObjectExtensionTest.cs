using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CHSNS.Core.Tests {


    /// <summary>
    ///这是 ObjectExtensionTest 的测试类，旨在
    ///包含所有 ObjectExtensionTest 单元测试
    ///</summary>
    [TestClass]
    public class ObjectExtensionTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }



        [TestMethod]
        public void ObjectToNotNullTest() {
            //   ToNotNullTestHelper<GenericParameterHelper>();
            var list = new List<int> { 1, 2, 3 };
            const List<int> list2 = null;
            Assert.AreEqual(list, list.ToNotNull());
            Assert.IsNotNull(list2.ToNotNull());
            Assert.AreEqual(0, ((List<int>)list2.ToNotNull()).Count);
            Assert.AreEqual(3, ((List<int>)list.ToNotNull()).Count);
        }
    }
}
