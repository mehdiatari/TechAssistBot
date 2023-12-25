using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MyBot
{
    public class LicenseGenerator
    {
        private const string TokenFileName = "your_token_bot.txt";
        private const string SecretKey = "YourSecretKey";

        public void GenerateAndSaveLicense(string botId)
        {
            string license = GenerateLicense();
            SaveTokenAndLicense(botId, license);
        }

        private string GenerateLicense()
        {
            string randomString = GenerateRandomString();
            string timestamp = DateTime.Now.ToString("yyyy/MM/dd - HH:mm:ss");
            string dataToHash = $"{randomString}{timestamp}{SecretKey}";

            using (var sha256 = new SHA256Managed())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        private string GenerateRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 16)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void SaveTokenAndLicense(string botId, string license)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TokenFileName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Bot ID: {botId}");
                writer.WriteLine($"License: {license}");
                writer.WriteLine($"Timestamp: {DateTime.Now}");
            }
        }
    }
}
