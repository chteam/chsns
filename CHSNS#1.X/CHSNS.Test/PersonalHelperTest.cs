using CHSNS.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CHSNS.Test
{
    
    
    /// <summary>
    ///这是 PersonalHelperTest 的测试类，旨在
    ///包含所有 PersonalHelperTest 单元测试
    ///</summary>
	[TestClass()]
	public class PersonalHelperTest {


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
		///TrimLast 的测试
		///</summary>
		[TestMethod()]
		public void TrimLastTest() {
			PersonalHelper target = new PersonalHelper(); // TODO: 初始化为适当的值
			string s = string.Empty; // TODO: 初始化为适当的值
			string expected = string.Empty; // TODO: 初始化为适当的值
			string actual;
			actual = target.TrimLast(s);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("验证此测试方法的正确性。");
		}

		/// <summary>
		///PersonalHelper 构造函数 的测试
		///</summary>
		[TestMethod()]
		public void PersonalHelperConstructorTest() {
			PersonalHelper target = new PersonalHelper();
			Assert.Inconclusive("TODO: 实现用来验证目标的代码");
		}
	}
}
