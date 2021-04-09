using NUnit.Framework;
using SimplePasswordCheck.Password.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Tests.Password.Service
{
    public class PasswordValidatorService_Tests
    {
        PasswordValidatorService passwordValidatorService;

        [SetUp]
        public void SetUp()
        {
            passwordValidatorService = new PasswordValidatorService();
        }

        [Test]
        [TestCase("")]
        [TestCase("aa")]
        [TestCase("ab")]
        [TestCase("AAAbbbCc")]
        [TestCase("AbTp9!foo")]
        [TestCase("AbTp9!foA")]
        [TestCase("AbTp9 fok")]
        public void ShouldFailPasswordValidation(string password)
        {
            var result = passwordValidatorService.Validate(password);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("AbTp9!fok")]
        [TestCase("AbTp9!feka")]
        [TestCase("AbTp9!fek123")]
        [TestCase("AbTp9!fek123()")]
        [TestCase("AbTp9!fek123)")]
        public void ShouldPassPasswordValidation(string password)
        {
            var result = passwordValidatorService.Validate(password);

            Assert.IsTrue(result);
        }
    }
}
