using CHSNS.Email;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CHSNS.Test
{
    
    
    /// <summary>
    ///这是 IEmailTest 的测试类，旨在
    ///包含所有 IEmailTest 单元测试
    ///</summary>
	[TestClass()]
	public class IEmailTest {


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


		internal virtual IEmail CreateIEmail() {
			// TODO: 实例化相应的具体类。
			IEmail target = new NetEmail();
			return target;
		}

		/// <summary>
		///Send 的测试
		///</summary>
		[TestMethod()]
		public void SendTest() {
			IEmail target = CreateIEmail(); // TODO: 初始化为适当的值
			string to = "chsword.z@gmail.com"; // TODO: 初始化为适当的值
			string from = "chsword@126.com"; // TODO: 初始化为适当的值
			string subject = "what is the 4400?"; // TODO: 初始化为适当的值
			string body = "It's a TV Set"; // TODO: 初始化为适当的值
			string username = "chsword"; // TODO: 初始化为适当的值
			string password = "789123"; // TODO: 初始化为适当的值
			string smtpHost = "smtp.126.com"; // TODO: 初始化为适当的值
			target.Send(to, from, subject, body, username, password, smtpHost);
			Assert.Inconclusive("无法验证不返回值的方法。");
		}
	}
}
