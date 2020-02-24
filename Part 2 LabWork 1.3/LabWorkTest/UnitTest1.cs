using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part_2_LabWork_1._3;

namespace LabWorkTest
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void StringExtensionsIsBlueBaseTest()
        {
            string color = "blue";
            bool actual = color.IsBaseColor();
            Assert.AreEqual(true, actual);
        }

        //Advanced

        [TestMethod]
        public void TryEncryptTest()
        {
            CryptedString.EncryptString("ПЕРЕМОГА");
        }

        [TestMethod]
        public void TryDecryptTest()
        {
            CryptedString.DecryptString("*--* * *-* * -- --- --* *-");
        }
    }
}
