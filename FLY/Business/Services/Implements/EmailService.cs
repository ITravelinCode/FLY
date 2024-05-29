using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.Buffers.Text;
using static System.Net.Mime.MediaTypeNames;

namespace FLY.Business.Services.Implements
{
    public class EmailService : IEmailService
    {
        private readonly string? _credentialsPath;
        private readonly string? _mailboxAddress;
        private UserCredential? _credential;

        public EmailService()
        {
            _credentialsPath = Environment.GetEnvironmentVariable("CREDENTIALS_PATH");
            _mailboxAddress = Environment.GetEnvironmentVariable("MAILBOX_ADDRESS");
        }

        public async Task SendVerificationEmailAsync(string email, string verificationCode)
        {
            try
            {
                var credential = await GetCredentialAsync();
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    ApplicationName = "FLY",
                    HttpClientInitializer = credential
                });

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("FLY", _mailboxAddress));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = "FLY: Email Verification Code";
                message.Body = new TextPart("plain")
                {
                    Text = $"Your verification code is: {verificationCode}.\nPlease enter this code to verify, it will be expired after 1 hour.\n\nBest regards\nFLY Team"
                };

                var gmailMessage = new Message
                {
                    Raw = Base64UrlEncoder.Encode(message.ToString())
                };

                await service.Users.Messages.Send(gmailMessage, "me").ExecuteAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new InvalidOperationException("Failed to send verification email", ex);
            }
        }

        public async Task<UserCredential> GetCredentialAsync()
        {
            if (_credential != null && !_credential.Token.IsExpired(_credential.Flow.Clock))
            {
                return _credential;
            }

            try
            {
                using (var stream = new FileStream(_credentialsPath, FileMode.Open, FileAccess.Read))
                {
                    _credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        new[] { GmailService.Scope.GmailSend },
                        "user", CancellationToken.None,
                        new FileDataStore("Token.json", true)
                    );
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new InvalidOperationException("Failed to get Google API credentials", ex);
            }

            return _credential;
        }
    }
}
