using CHSNS.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CHSNS.Config;
using CHSNS;
using CHSNS.Data;

namespace CHSNS.Test
{
    
    
    /// <summary>
    ///这是 ChHelperTest 的测试类，旨在
    ///包含所有 ChHelperTest 单元测试
    ///</summary>
	[TestClass()]
	public class ChHelperTest {


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
		///User 的测试
		///</summary>
		[TestMethod()]
		public void UserTest() {
			ChHelper target = new ChHelper(); // TODO: 初始化为适当的值
			CHSNSUser actual;
			actual = target.User;
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///Str 的测试
		///</summary>
		[TestMethod()]
		public void StrTest() {
			ChHelper target = new ChHelper(); // TODO: 初始化为适当的值
			StringHelper actual;
			actual = target.Str;
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///Path 的测试
		///</summary>
		[TestMethod()]
		public void PathTest() {
			ChHelper target = new ChHelper(); // TODO: 初始化为适当的值
			Path actual;
			actual = target.Path;
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///DB 的测试
		///</summary>
		[TestMethod()]
		public void DBTest() {
			ChHelper target = new ChHelper(); // TODO: 初始化为适当的值
			DBExt actual;
			actual = target.DB;
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///DataCache 的测试
		///</summary>
		[TestMethod()]
		public void DataCacheTest() {
			ChHelper target = new ChHelper(); // TODO: 初始化为适当的值
			DataSetCache actual;
			actual = target.DataCache;
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///ChSite 的测试
		///</summary>
		[TestMethod()]
		public void ChSiteTest() {
			ChHelper target = new ChHelper(); // TODO: 初始化为适当的值
			SiteConfig actual;
			actual = target.ChSite;
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///ChHelper 构造函数 的测试
		///</summary>
		[TestMethod()]
		public void ChHelperConstructorTest() {
			ChHelper target = new ChHelper();
			Assert.Inconclusive("TODO: 实现用来验证目标的代码");
		}
	}
}
