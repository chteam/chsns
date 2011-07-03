using CHSNS.Common.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CHSNS.Core.Tests
{
    /// <summary>
    ///这是 JsonAdapterTest 的测试类，旨在
    ///包含所有 JsonAdapterTest 单元测试
    ///</summary>
    [TestClass]
    public class JsonAdapterTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }


        /// <summary>
        ///Serialize 的测试
        ///</summary>
        [TestMethod]
        public void Serialize() {
            object o = new {Name = "chsword", Sex = true};
            const string expected = "{\"Name\":\"chsword\",\"Sex\":true}";
            var actual = JsonAdapter.Serialize(o);
            Assert.AreEqual(expected, actual);
           // Assert.AreEqual(string.Empty, JsonAdapter.Serialize(typeof(EnumExtensionType)));
        }

        /// <summary>
        ///Deserialize 的测试
        ///</summary>
        public void DeserializeTestHelper<T>() {
            var o = string.Empty; 
            var expected = default(T); 
            var actual = JsonAdapter.Deserialize<T>(o);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deserialize() {
            DeserializeTestHelper<GenericParameterHelper>();
            Assert.AreEqual(default(GenericParameterHelper), JsonAdapter.Deserialize<GenericParameterHelper>("{\"Data\":\"1\"}"));
        }

    }
}
