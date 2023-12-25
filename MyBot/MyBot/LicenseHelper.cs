// در یک فایل به نام LicenseHelper.cs

using System;
using System.Net.Mail;
using MimeKit;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;

namespace MyBot
{
    public static class LicenseHelper
    {
        private const string TargetEmail = "mehdiattari@gmail.com";
        private const string AppId = "MyBot";
        private const string SecretKey = "YourSecretKey";

        public static bool RequestLicense(string userCode)
        {
            SendEmail(userCode);
            string responseCode = ReceiveEmail();
            return ValidateResponse(responseCode);
        }

        private static void SendEmail(string userCode)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("License Server", "licenseserver@example.com"));
            message.To.Add(new MailboxAddress("License User", TargetEmail));
            message.Subject = "درخواست لایسنس";
            message.Body = new TextPart("plain")
            {
                Text = $"لطفاً این کد را به کاربر ارسال کنید: {userCode}"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.example.com", 587, false);
                client.Authenticate("yourusername", "yourpassword");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        private static string ReceiveEmail()
        {
            using (var client = new Pop3Client())
            {
                client.Connect("pop.example.com", 995, true);
                client.Authenticate("yourusername", "yourpassword");

                var message = client.GetMessage(0);
                return message.TextBody;
            }
        }

        private static bool ValidateResponse(string responseCode)
        {
            return responseCode == "ValidLicense";
        }

        public static string GenerateLicense()
        {
            var userCode = $"{AppId}:{DateTime.Now.AddDays(30):yyyy-MM-dd HH:mm:ss}";
            var hmac = new System.Security.Cryptography.HMACSHA256(System.Text.Encoding.UTF8.GetBytes(SecretKey));
            var hashBytes = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userCode));
            var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return $"{userCode}:{hash}";
        }
    }
}
