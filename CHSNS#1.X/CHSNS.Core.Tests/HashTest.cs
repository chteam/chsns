using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CHSNS.Core.Tests
{
    
    
    /// <summary>
    ///这是 HashTest 的测试类，旨在
    ///包含所有 HashTest 单元测试
    ///</summary>
    [TestClass]
    public class HashTest {
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///Empty 的测试
        ///</summary>
        public void EmptyTestHelper<TValue>()
        {
            var actual = Hash<TValue>.Empty;
            Assert.IsNotNull(actual);
           
        }

        [TestMethod]
        public void EmptyTest() {
            EmptyTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Hash`1 构造函数 的测试
        ///</summary>
        public void HashConstructorTest1Helper<TValue>() {
            Func<object, TValue>[] hash = null; 
            var target = new Hash<TValue>(hash);
            Assert.IsNotNull(target);
        
        }

        [TestMethod]
        public void HashConstructorTest1() {
            HashConstructorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///Hash 构造函数 的测试
        ///</summary>
        [TestMethod]
        public void HashConstructorTest() {
            Func<object, object>[] hash = null;
            var target = new Hash(hash);
            Assert.IsNotNull(target);
            Assert.IsNotNull(new Hash(id => "goose", @class => "chicken"));
        }
    }
}
