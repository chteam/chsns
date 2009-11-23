using System.Web.TestUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 EnumExtensionTest 的测试类，旨在
    ///包含所有 EnumExtensionTest 单元测试
    ///</summary>
    [TestClass]
    public class EnumExtensionTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }


        [TestMethod]
        public void ToDictionaryTest() {
            const EnumExtensionType x = (EnumExtensionType) 0;
            var dict = x.ToDictionary<EnumExtensionType>();
            Assert.AreEqual(dict["A"], 3);
            Assert.AreEqual(dict["B"], 8);
            ExceptionHelper.ExpectArgumentException(
                () => x.ToDictionary<int>(), "System.ArgumentException: 提供的类型必须是 Enum。"
                );
            ExceptionHelper.ExpectException<System.InvalidCastException>(
             () => EnumExtension.ToDictionary<EnumExtensionType2>(x), "System.InvalidCastException: 指定的转换无效。"
             );
        }
    }
    enum EnumExtensionType
    {
        A=3,B=8
    }
    enum EnumExtensionType2:long {
        A = long.MaxValue, B = long.MaxValue
    }
}
