namespace CMS.Application.Abstractions.Services
{
    /// <summary>
    /// Service interface for sending user-related emails (confirmation, password reset, etc.)
    /// </summary>
    public interface IUserEmailService
    {
        Task SendConfirmationLinkAsync(User user, string email, string confirmationLink);
        Task SendPasswordResetLinkAsync(User user, string email, string resetLink);
        Task SendWelcomeAndConfirmationAsync(User user, string email, string confirmationLink);
        Task SendCreatePasswordLinkAsync(User user, string email, string createPasswordLink);
        Task SendPasswordChangedNotificationAsync(User user, string email, string resetLink);
        Task SendEmailChangedNotificationAsync(User user, string email, string newEmail);
    }
}
