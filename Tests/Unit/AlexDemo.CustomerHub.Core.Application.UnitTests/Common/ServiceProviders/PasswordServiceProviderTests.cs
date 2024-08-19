using AlexDemo.CustomerHub.Core.Application.ServiceProviders;
using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.UnitTests.Common.ServiceProviders
{
    public class PasswordServiceProviderTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        [InlineData("AlP1n3Rz!!@")]
        [InlineData("12345678910111213DFF!!@#")]
        [InlineData("Te4X6zP)m[+(v^1akt!-a&a6hi[8R+xqpaU.")]
        public void CheckPassword_WithBytesData_ValidationPassed(string password)
        {
            // arrange
            PasswordServiceProvider.CreatePasswordHash(password, out byte[] hash, out byte[] salt);

            // act
            var areChecksValid = PasswordServiceProvider.VerifyPasswordHash(password, hash, salt);

            // assert
            Assert.True(areChecksValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        [InlineData("AlP1n3Rz!!@")]
        [InlineData("T2{sCCx_m845N]_GndxFp")]
        [InlineData("Te4X6zP)m[+(v^1akt!-a&a6hi[8R+xqpaU.")]
        public void CheckPassword_WithBytesData_NotValidInfo_ValidationFailed(string password)
        {
            // arrange
            PasswordServiceProvider.CreatePasswordHash(password, out byte[] hash, out byte[] salt);

            // act
            var areChecksValid = PasswordServiceProvider.VerifyPasswordHash(password + 1, hash, salt);

            // assert
            Assert.False(areChecksValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        [InlineData("AlP1n3Rz!!@")]
        [InlineData("12345678910111213DFF!!@#")]
        [InlineData("Te4X6zP)m[+(v^1akt!-a&a6hi[8R+xqpaU.")]
        public void CheckPassword_WithDatabaseData_ValidationPassed(string password)
        {
            // arrange
            PasswordServiceProvider.CreatePasswordHash(password, out byte[] hash, out byte[] salt);

            var userEntity = BuildUser(hash, salt);

            var restoredHash = Convert.FromBase64String(userEntity.PasswordHash);
            var restoredSalt = Convert.FromBase64String(userEntity.PasswordSalt);

            // act
            var areChecksValid = PasswordServiceProvider.VerifyPasswordHash(password, restoredHash, restoredSalt);

            // assert
            Assert.True(areChecksValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        [InlineData("AlP1n3Rz!!@")]
        [InlineData("12345678910111213DFF!!@#")]
        [InlineData("Te4X6zP)m[+(v^1akt!-a&a6hi[8R+xqpaU.")]
        public void CheckPassword_WithDatabaseData_NotValidInfo_ValidationFailed(string password)
        {
            // arrange
            PasswordServiceProvider.CreatePasswordHash(password, out byte[] hash, out byte[] salt);

            var userEntity = BuildUser(hash, salt);

            var restoredHash = Convert.FromBase64String(userEntity.PasswordHash);
            var restoredSalt = Convert.FromBase64String(userEntity.PasswordSalt);

            // act
            var areChecksValid = PasswordServiceProvider.VerifyPasswordHash(password + " ", restoredHash, restoredSalt);

            // assert
            Assert.False(areChecksValid);
        }

        [Theory]
        [InlineData(null)]
        public void CheckPassword_WithDatabaseData_PasswordIsNull_ExceptionIsThrown(string password)
        {
            // arrange
            Assert.Throws<ArgumentNullException>(() =>
            {
                PasswordServiceProvider.CreatePasswordHash(password, out byte[] _, out byte[] _);
            });
        }

        private User BuildUser(byte[] hash, byte[] salt)
        {
            var userEntity = new User
            {
                Id = 1,
                DateOfBirth = DateTime.UtcNow.AddYears(-20),
                Login = "testLogin",
                PasswordHash = Convert.ToBase64String(hash),
                PasswordSalt = Convert.ToBase64String(salt),
                PrimaryOfficeId = 1,
                UpdatedOn = DateTime.UtcNow,
                CompanyRole = EmployeeCompanyRole.Manager,
                Email = "testlogin@testcompany.com"
            };

            return userEntity;
        }
    }
}
