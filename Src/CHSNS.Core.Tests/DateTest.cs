using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 DateTest 的测试类，旨在
    ///包含所有 DateTest 单元测试
    ///</summary>
    [TestClass]
    public class DateTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }


        /// <summary>
        ///DivMinutes 的测试
        ///</summary>
        [TestMethod]
        public void DivMinutesTest1() {
            var ot = DateTime.Now;
            var dt2 = new DateTime(2009, 02, 22, 22, 22, 22);
            Assert.AreEqual(Date.DivMinutes((object)dt2), (int)(ot - dt2).TotalMinutes);
            Assert.AreEqual(Date.DivMinutes("xx"),1000);
        }

        /// <summary>
        ///DivMinutes 的测试
        ///</summary>
        [TestMethod]
        public void DivMinutesTest() {
            var ot = DateTime.Now;
            var dt2 = new DateTime(2009, 02, 22, 22, 22, 22);
            Assert.AreEqual(Date.DivMinutes(dt2), (int)(ot - dt2).TotalMinutes);
        }

        /// <summary>
        ///Date 构造函数 的测试
        ///</summary>
        [TestMethod]
        public void DateConstructorTest() {
            var target = new Date();
            Assert.IsNotNull(target);
        }
    }
}
