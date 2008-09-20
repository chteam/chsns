using CHSNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CHSNS.Test
{
    
    
    /// <summary>
    ///这是 DateTimeExtensionTest 的测试类，旨在
    ///包含所有 DateTimeExtensionTest 单元测试
    ///</summary>
	[TestClass()]
	public class DateTimeExtensionTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///获取或设置测试上下文，上下文提供
		///有关当前测试运行及其功能的信息。
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
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
		///Ago 的测试
		///</summary>
		[TestMethod()]
		public void AgoTest()
		{
			Assert.AreEqual(DateTime.Now.Ago(), "刚刚");
			Assert.AreEqual(DateTime.Now.AddMinutes(-3).Ago(), "3 分钟前");
			Assert.AreEqual(DateTime.Now.AddHours(-11).Ago(), "11 小时前");
			Assert.AreEqual(DateTime.Now.AddMinutes(-3).AddHours(-3).Ago(), "3 小时, 3 分钟前");
			Assert.AreEqual(DateTime.Now.AddDays(-33).Ago(), "33 天前");
			Assert.AreEqual(DateTime.Now.AddDays(-100).AddHours(-3).Ago(), "100 天, 3 小时前");
			Assert.AreEqual(DateTime.Now.AddDays(-100).AddHours(-23).AddMinutes(-59).Ago(), "100 天, 23 小时, 59 分钟前");
			//Assert.("验证此测试方法的正确性。");
		}
	}
}
