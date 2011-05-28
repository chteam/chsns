using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CHSNS.Core.Tests
{
 
    [TestClass]
    public class NullableExtensionTest {
 
        [TestMethod]
        public void NullableExtensionGetHasValue()
        {
            var myClass = new MyClass();
            myClass.Id = 1;
            Assert.AreEqual(myClass.GetProperty(c=>c.Id), 1);
        }
        [TestMethod]
        public void NullableExtensionGetNull()
        {
            MyClass myClass = null;
            Assert.AreEqual(myClass.GetProperty(c => c.Id), 0);
        }

        public class MyClass
        {
            public int Id { get; set; }
        }
    }
}
