using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CHSNS.Test
{
    public static class ExceptionAssert
    {
        public static void IsException<TException>(Action func, string message = null) where TException : Exception
        {
            try
            {
                func();
            }
            catch (TException e)
            {
                Assert.IsInstanceOfType(e, typeof(TException));
                if (!string.IsNullOrEmpty(message)) Assert.AreEqual(e.Message, message);
            }
        }
    }
}