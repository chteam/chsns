using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CHSNS.Test
{
    
    
    /// <summary>
    ///这是 DateTimeExtensionTest 的测试类，旨在
    ///包含所有 DateTimeExtensionTest 单元测试
    ///</summary>
	[TestClass]
	public class DateTimeExtensionTest
	{
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
		///Ago 的测试
		///</summary>
		[TestMethod]
		public void AgoTest()
		{
			Assert.AreEqual(DateTime.Now.Ago(), "刚刚");
			Assert.AreEqual(DateTime.Now.AddMinutes(-3).Ago(), "3 分钟前");
			Assert.AreEqual(DateTime.Now.AddHours(-11).Ago(), "11 小时前");
			Assert.AreEqual(DateTime.Now.AddMinutes(-3).AddHours(-3).Ago(), "3 小时, 3 分钟前");
			Assert.AreEqual(DateTime.Now.AddDays(-33).Ago(), "33 天前");
			Assert.AreEqual(DateTime.Now.AddDays(-101).AddHours(-3).Ago(), "很久以前");
			Assert.AreEqual(DateTime.Now.AddDays(-10).AddHours(-23).AddMinutes(-59).Ago(), "10 天前");
			//Assert.("验证此测试方法的正确性。");
		}
	}
}
