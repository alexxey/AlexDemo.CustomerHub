using AlexDemo.CustomerHub.Core.Application.ServiceProviders;

namespace AlexDemo.CustomerHub.Core.Application.UnitTests.ServiceProviders
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

            var passwordData = BuildPasswordData(hash, salt);

            var restoredHash = Convert.FromBase64String(passwordData.Item1);
            var restoredSalt = Convert.FromBase64String(passwordData.Item2);

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

            Tuple<string, string> passwordData = BuildPasswordData(hash, salt);

            var restoredHash = Convert.FromBase64String(passwordData.Item1);
            var restoredSalt = Convert.FromBase64String(passwordData.Item2);

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

        private Tuple<string, string> BuildPasswordData(byte[] hash, byte[] salt)
        {
            return new Tuple<string, string>(Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }
    }
}
