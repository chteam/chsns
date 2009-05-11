using CHSNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 DateTest 的测试类，旨在
    ///包含所有 DateTest 单元测试
    ///</summary>
    [TestClass()]
    public class DateTest {


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

        #region 附加测试属性
        // 
        //编写测试时，还可使用以下属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///FormatTime 的测试
        ///</summary>
        [TestMethod()]
        public void FormatTimeTest2() {
            DateTime d = new DateTime(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = Date.FormatTime(d);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///FormatTime 的测试
        ///</summary>
        [TestMethod()]
        public void FormatTimeTest1() {
            DateTime d = new DateTime(); // TODO: 初始化为适当的值
            string s = string.Empty; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = Date.FormatTime(d, s);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///FormatTime 的测试
        ///</summary>
        [TestMethod()]
        public void FormatTimeTest() {
            object d = null; // TODO: 初始化为适当的值
            string s = string.Empty; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = Date.FormatTime(d, s);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DivMinutes 的测试
        ///</summary>
        [TestMethod()]
        public void DivMinutesTest1() {
            var ot = DateTime.Now;
            var dt2 = new DateTime(2009, 02, 22, 22, 22, 22);
            Assert.AreEqual(Date.DivMinutes((object)dt2), (int)(ot - dt2).TotalMinutes);
            Assert.AreEqual(Date.DivMinutes("xx"),1000);
        }

        /// <summary>
        ///DivMinutes 的测试
        ///</summary>
        [TestMethod()]
        public void DivMinutesTest() {
            var ot = DateTime.Now;
            var dt2 = new DateTime(2009, 02, 22, 22, 22, 22);
            Assert.AreEqual(Date.DivMinutes(dt2), (int)(ot - dt2).TotalMinutes);
        }

        /// <summary>
        ///Date 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void DateConstructorTest() {
            Date target = new Date();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }
    }
}
