using System;
using System.Net.Mail;
using MimeKit;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;

namespace MyBot
{
    public class LicenseManager
    {
        private const string TargetEmail = "mehdiattari@gmail.com";
        private const string AppId = "MyBot";
        private const string SecretKey = "YourSecretKey";
        private const string BotToken = "YourBotToken";
        private const long AdminChatId = 123456789; // شناسه چت ادمین بات

        private string licenseCode;
        private DateTime expirationDate;

        public LicenseManager(string initialLicenseCode)
        {
            ValidateLicense(initialLicenseCode);
        }

        private void ValidateLicense(string userCode)
        {
            string[] parts = userCode.Split(':');
            string appId = parts[0];
            DateTime expiryDate = DateTime.ParseExact(parts[1], "yyyy-MM-dd HH:mm:ss", null);

            if (appId != AppId || expiryDate < DateTime.Now)
            {
                throw new InvalidOperationException("Invalid license.");
            }

            licenseCode = userCode;
            expirationDate = expiryDate;
        }

        public bool IsLicenseValid()
        {
            return DateTime.Now < expirationDate;
        }

        public void ExtendLicenseValidity(int weeks, long adminChatId)
        {
            expirationDate = expirationDate.AddDays(7 * weeks);
            SendLicenseToAdmin(adminChatId);
        }

        private void SendLicenseToAdmin(long adminChatId)
        {
            var bot = new Telegram.Bot.TelegramBotClient(BotToken);

            var message = $"تاریخ انقضاء لایسنس به {expirationDate:yyyy-MM-dd HH:mm:ss} تغییر یافت.";

            bot.SendTextMessageAsync(adminChatId, message);
        }

        public string GenerateLicense(int validityWeeks, long adminChatId)
        {
            expirationDate = DateTime.Now.AddDays(7 * validityWeeks);
            var userCode = $"{AppId}:{expirationDate:yyyy-MM-dd HH:mm:ss}";

            var hmac = new System.Security.Cryptography.HMACSHA256(System.Text.Encoding.UTF8.GetBytes(SecretKey));
            var hashBytes = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userCode));
            var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            licenseCode = $"{userCode}:{hash}";
            SendLicenseToAdmin(adminChatId);

            return licenseCode;
        }
    }
}
