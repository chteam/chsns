namespace CHSNS.Core.Tests
{
    using CHSNS.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CHSNS.Common.Email;

    /// <summary>
    ///这是 IEmailTest 的测试类，旨在
    ///包含所有 IEmailTest 单元测试
    ///</summary>
	[TestClass()]
	public class IEmailTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }

		internal virtual IEmail CreateIEmail() {
			// TODO: 实例化相应的具体类。
			IEmail target = new NetEmail();
			return target;
		}

	}
}
