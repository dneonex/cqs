using NUnit.Framework;
using Recruitment.Common.Helpers;
using System;

namespace Recruitment.UnitTests
{
    [TestFixture]
    public class HashCalculatorTests
    {
        private const int Sha256EncodedLenght = 64;

        [Test]
        public void CalculateSha256Hash_TextDataIsEmpty_ReturnsNull()
        {
            var sourceString = String.Empty;

            var result = HashCalculator.CalculateSha256Hash(sourceString);

            Assert.IsNull(result);
        }

        [Test]
        public void CalculateSha256Hash_EncryptData_AlwaysReturnsFixedLenght()
        {
            var sourceString = TestContext.CurrentContext.Random.GetString();

            var result = HashCalculator.CalculateSha256Hash(sourceString);

            Assert.IsTrue(result.Length == Sha256EncodedLenght);
        }

        [Test]
        public void CalculateSha256Hash_EncryptData_SameDataProducesSameResult()
        {
            var sourceString = TestContext.CurrentContext.Random.GetString();

            var result1 = HashCalculator.CalculateSha256Hash(sourceString);
            var result2 = HashCalculator.CalculateSha256Hash(sourceString);
            var result3 = HashCalculator.CalculateSha256Hash(sourceString);

            Assert.AreEqual(result1, result2, result3);
        }
    }
}