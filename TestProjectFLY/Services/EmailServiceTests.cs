using FLY.Business.Services.Implements;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Util.Store;
using Moq;

namespace TestProjectFLY.Services
{
    public class EmailServiceTests
    {
        private readonly EmailService _emailService;
        private readonly Mock<GmailService> _gmailServiceMock;
        private readonly Mock<IGoogleAuthorizationBroker> _authBrokerMock;

        public EmailServiceTests()
        {
            _gmailServiceMock = new Mock<GmailService>();
            _authBrokerMock = new Mock<IGoogleAuthorizationBroker>();

            _emailService = new EmailService();
        }

        [Fact]
        public async Task SendVerificationEmailAsync_ShouldSendEmail()
        {
            // Arrange
            var email = "test@example.com";
            var verificationCode = "123456";
            var userCredentialMock = new Mock<UserCredential>();

            _emailService.GetType()
                .GetField("_credential", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(_emailService, userCredentialMock.Object);

            _gmailServiceMock.Setup(x => x.Users.Messages.Send(It.IsAny<Message>(), "me").ExecuteAsync(It.IsAny<CancellationToken>()))
                .Returns((Task<Message>)Task.CompletedTask);

            // Act
            await _emailService.SendVerificationEmailAsync(email, verificationCode);

            // Assert
            _gmailServiceMock.Verify(x => x.Users.Messages.Send(It.IsAny<Message>(), "me").ExecuteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetCredentialAsync_ShouldReturnCredential()
        {
            // Arrange
            var userCredentialMock = new Mock<UserCredential>();

            using (var stream = new MemoryStream())
            {
                var writer = new StreamWriter(stream);
                writer.Write("{\"installed\": {\"client_id\": \"CLIENT_ID\",\"client_secret\": \"CLIENT_SECRET\"}}");
                writer.Flush();
                stream.Position = 0;

                var clientSecrets = GoogleClientSecrets.FromStream(stream).Secrets;

                _authBrokerMock.Setup(x => x.AuthorizeAsync(clientSecrets, It.IsAny<string[]>(), "user", It.IsAny<CancellationToken>(), It.IsAny<IDataStore>()))
                    .ReturnsAsync(userCredentialMock.Object);
            }

            // Act
            var credential = await _emailService.GetCredentialAsync();

            // Assert
            Assert.NotNull(credential);
        }
    }
}
