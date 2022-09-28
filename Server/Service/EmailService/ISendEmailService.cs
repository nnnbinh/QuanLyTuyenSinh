namespace QuanLyTuyenSinh.Server.Service.EmailService
{
    public interface ISendEmailService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
