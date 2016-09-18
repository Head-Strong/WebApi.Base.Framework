using FluentAssertions;
using NUnit.Framework;

namespace WebApi.Common.Utility.Test
{
    [TestFixture]
    public class CredentialManagerTest
    {
        [Test]
        public void EncodeCredential_Then_Decode_It()
        {
            var userName = "aditya";
            var password = "test";

            var encodedCredential = CredentialManager.EncodedCredentials(userName, password);

            var decodedCredential = CredentialManager.DecodeCredentials(encodedCredential);

            decodedCredential.Should().BeEquivalentTo(userName + ":" + password);
        }
    }
}
