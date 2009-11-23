using CHSNS.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace CHSNS.Test
{
    
    
    /// <summary>
    ///这是 PagerExtTest 的测试类，旨在
    ///包含所有 PagerExtTest 单元测试
    ///</summary>
	[TestClass()]
	public class PagerExtTest {


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
		///Pager 的测试
		///</summary>
		public void PagerTestHelper() {
			var i = (new int[] { 1, 2, 3, 4, 5, 6, 7, 8, }).OrderBy(c=>c).Where(c=>c<100) ;
								  // TODO: 初始化为适当的值
			int nowpage = 2; // TODO: 初始化为适当的值
			int everypage = 4; // TODO: 初始化为适当的值
			IEnumerable<int> expected = new int[] { 5, 6, 7, 8 }; // TODO: 初始化为适当的值

			IEnumerable<int> actual = i.Pager(nowpage, everypage);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		[TestMethod]
		public void PagerTest() {
			PagerTestHelper();
		}
	}
}
