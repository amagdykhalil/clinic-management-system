using CMS.Application.Abstractions.Services;
using CMS.Domain.Entities;

namespace CMS.Infrastructure.Email
{
    /// <summary>
    /// Service for sending user-related emails using templates
    /// </summary>
    public class UserEmailService : IUserEmailService
    {
        private readonly IEmailService _emailService;

        public UserEmailService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
        {
            var message = new EmailMessage(
                "Confirm Your Email Address",
                "EmailConfirmation",
                new[]
                {
                        new Placeholder("UserName", user.FirstName + " " + user.LastName),
                        new Placeholder("ConfirmationLink", confirmationLink)
                },
                new EmailAddress("noreply@arc.com", "CMS Team"),
                new[] { (EmailAddress)email }
            );

            await _emailService.SendAsync(message);
        }

        public async Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
        {
            var message = new EmailMessage(
                "Reset Your Password",
                "PasswordReset",
                new[]
                {
                        new Placeholder("UserName", user.FirstName + " " + user.LastName),
                        new Placeholder("ResetLink", resetLink)
                },
                new EmailAddress("noreply@arc.com", "CMS Team"),
                new[] { (EmailAddress)email }
            );

            await _emailService.SendAsync(message);
        }

        public async Task SendWelcomeAndConfirmationAsync(User user, string email, string confirmationLink)
        {
            var message = new EmailMessage(
                "Welcome to CMS! Please Confirm Your Email",
                "WelcomeAndConfirm",
                new[]
                {
                        new Placeholder("UserName", user.FirstName + " " + user.LastName),
                        new Placeholder("ConfirmationLink", confirmationLink)
                },
                new EmailAddress("noreply@arc.com", "CMS Team"),
                new[] { (EmailAddress)email }
            );

            await _emailService.SendAsync(message);
        }

        public async Task SendCreatePasswordLinkAsync(User user, string email, string createPasswordLink)
        {
            var message = new EmailMessage(
                "Create Your Password",
                "CreatePassword",
                new[]
                {
                        new Placeholder("UserName", user.FirstName + " " + user.LastName),
                        new Placeholder("ResetLink", createPasswordLink)
                },
                new EmailAddress("noreply@arc.com", "CMS Team"),
                new[] { (EmailAddress)email }
            );

            await _emailService.SendAsync(message);
        }

        public async Task SendPasswordChangedNotificationAsync(User user, string email, string resetLink)
        {
            var message = new EmailMessage(
                "Your Password Was Changed",
                "PasswordChanged",
                new[]
                {
                        new Placeholder("UserName", user.FirstName + " " + user.LastName),
                        new Placeholder("ResetLink", resetLink)
                },
                new EmailAddress("noreply@arc.com", "CMS Team"),
                new[] { (EmailAddress)email }
            );

            await _emailService.SendAsync(message);
        }

        public async Task SendEmailChangedNotificationAsync(User user, string email, string newEmail)
        {
            var message = new EmailMessage(
                "Your Email Address Was Changed",
                "EmailChanged",
                new[]
                {
                        new Placeholder("UserName", user.FirstName + " " + user.LastName),
                        new Placeholder("NewEmail", newEmail)
                },
                new EmailAddress("noreply@arc.com", "CMS Team"),
                new[] { (EmailAddress)email }
            );

            await _emailService.SendAsync(message);
        }
    }
}
