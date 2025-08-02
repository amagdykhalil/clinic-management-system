namespace CMS.Application.Abstractions.Services
{
    /// <summary>
    /// Provides functionality to compile and queue email messages using templates.
    /// </summary>
    public interface IEmailService
    {
        Task SendAsync(EmailMessage message);
    }

    public record EmailMessage(
        string Subject, 
        string TemplateName, 
        IEnumerable<Placeholder> Placeholders,
        EmailAddress From, 
        IEnumerable<EmailAddress> To,
        IEnumerable<EmailAddress>? Cc = null,
        IEnumerable<EmailAddress>? Bcc = null,
        IEnumerable<EmailAttachment>? Attachments = null);
}




