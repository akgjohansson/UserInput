using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserInput;

namespace TestUserInput
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWriteAsFraction()
        {
           string output = InputCleanup.WriteAsFraction(1f / 6f);
        }
    }
}
