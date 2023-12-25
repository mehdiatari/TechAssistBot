using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;
var licenseCode = LicenseHelper.GenerateLicense();
var isValidLicense = LicenseHelper.RequestLicense(licenseCode);

namespace MyBot
{
    public partial class Form1 : Form
        // جنریت کد بات ذخیره فایل متنی 
        // ایجاد یک نمونه از LicenseGenerator
var licenseGenerator = new LicenseGenerator();

    // تولید و ذخیره لایسنس و اطلاعات مربوطه در فایل تکست
    licenseGenerator.GenerateAndSaveLicense("YourBotId");




    {
        if (isValidLicense)
{
    // اجازه استفاده از برنامه
}
else
{
    // عدم اعتبار لایسنس
}

/// لایسنس مسنجر 
// ایجاد یک نمونه از LicenseManager با یک لایسنس اولیه
var licenseManager = new LicenseManager("MyBot:2023-01-01 00:00:00:123abc");

// اعتبارسنجی لایسنس
if (licenseManager.IsLicenseValid())
{
    // برنامه قابل اجرا است
}
else
{
    // عدم اعتبار لایسنس
}

// تغییر مدت زمان اعتبار لایسنس به مدت 2 هفته و ارسال به ادمین
licenseManager.ExtendLicenseValidity(2, 123456789);

// تولید یک لایسنس جدید با اعتبار 1 سال و ارسال به ادمین
var newLicense = licenseManager.GenerateLicense(52, 123456789);
Console.WriteLine($"New License: {newLicense}");

private static string Token = "";
private Thread botThread;
private Telegram.Bot.TelegramBotClient bot;
private ReplyKeyboardMarkup mainKeyboardMarkup;

private int bale1, bale2, bale3 = 0;
public Form1()
{
    InitializeComponent();
}

private void btnStart_Click(object sender, EventArgs e)
{
                private License license;

public Form1()
{
    InitializeComponent();
    InitializeLicense();
}

private void InitializeLicense()
{
    // اینجا لایسنس را از کاربر دریافت کنید
    // شما می‌توانید از TextBox و یا سایر وسایل برای دریافت کد لایسنس استفاده کنید
    string licenseKey = GetLicenseKeyFromUser();

    // اگر لایسنس معتبر بود، اطلاعات آن را در متغیر license ذخیره کنید
    if (IsValidLicense(licenseKey))
    {
        license = ParseLicense(licenseKey);
    }
    else
    {
        // اگر لایسنس نامعتبر بود، برنامه را خاتمه دهید یا اقدامات مناسبی انجام دهید
        MessageBox.Show("لایسنس نامعتبر است. برنامه به پایان می‌رسد.");
        Environment.Exit(0);
    }
}

private string GetLicenseKeyFromUser()
{
    // اینجا کد لایسنس را از کاربر دریافت کنید (از TextBox یا سایر وسایل)
    // مثال: return txtLicenseKey.Text;
}

private bool IsValidLicense(string licenseKey)
{
    // اینجا لایسنس را بررسی کنید (اگر فرمت یا قوانین خاصی وجود دارد)
    // مثال: return licenseKey.Length == 16;
}

private License ParseLicense(string licenseKey)
{
    // اینجا اطلاعات لایسنس را از رشته کلید لایسنس استخراج کنید
    // مثال: 
    // License license = new License();
    // license.Key = licenseKey.Substring(0, 8);
    // license.ExpirationDate = DateTime.ParseExact(licenseKey.Substring(8, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
    // license.AllowedVersions = new List<string> { "1.0", "2.0" }; // یا از دیگر منابع دریافت کنید
    // return license;
}

private void btnStart_Click(object sender, EventArgs e)
{
    // اگر لایسنس معتبر نبود، اقدامات مناسبی انجام دهید
    if (license == null || !license.IsValid("1.0"))
    {
        MessageBox.Show("لایسنس نامعتبر است. برنامه به پایان می‌رسد.");
        Environment.Exit(0);
    }

    // اگر لایسنس معتبر بود، برنامه را ادامه دهید
    Token = txtToken.Text;
    botThread = new Thread(new ThreadStart(runBot));
    botThread.Start();
}
Token = txtToken.Text;
botThread = new Thread(new ThreadStart(runBot));
botThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
{
    mainKeyboardMarkup = new ReplyKeyboardMarkup();
    KeyboardButton[] row1 =
    {
                new KeyboardButton("درباره ما" + " \U00002764"), new KeyboardButton("تماس با ما" + "\U00002709"),
            };
    KeyboardButton[] row2 =
    {
                new KeyboardButton("آدرس ما" + " \U0001F68C"),new KeyboardButton("نظر سنجی" +"\U0001F6A5")
            };
    mainKeyboardMarkup.Keyboard = new KeyboardButton[][]
    {
                row1 , row2
    };

}


void runBot()
{
    bot = new Telegram.Bot.TelegramBotClient(Token);

    this.Invoke(new Action(() =>
    {
        lblStatus.Text = "Online";
        lblStatus.ForeColor = Color.Green;
    }));
    int offset = 0;

    while (true)
    {
        try
        {
            Telegram.Bot.Types.Update[] update = bot.GetUpdatesAsync(offset).Result;

            foreach (var up in update)
            {
                offset = up.Id + 1;

                if (up.CallbackQuery != null)
                {
                    switch (up.CallbackQuery.Data)
                    {
                        case "1":
                            {
                                bale1 += 1;
                                break;
                            }
                        case "2":
                            {
                                bale2 += 1;
                                break;
                            }
                        case "3":
                            {
                                bale3 += 1;
                                break;
                            }
                    }

                    InlineKeyboardMarkup inline = new InlineKeyboardMarkup();
                    InlineKeyboardCallbackButton[] row1 =
                    {
                        new InlineKeyboardCallbackButton("بله راضی هستم ("+bale1+")","1")
                    };
                    InlineKeyboardCallbackButton[] row2 =
                    {
                        new InlineKeyboardCallbackButton("بله خیلی زیاد ("+bale2+")", "2")
                    };
                    InlineKeyboardCallbackButton[] row3 =
                    {
                        new InlineKeyboardCallbackButton("بله قطعا ("+bale3+")","3")
                    };
                    inline.InlineKeyboard = new InlineKeyboardButton[][]
                    {
                        row1,row2,row3
                    };

                    bot.EditMessageReplyMarkupAsync(up.CallbackQuery.Message.Chat.Id,
                        up.CallbackQuery.Message.MessageId, inline);
                }

                if (up.Message == null)
                    continue;

                var text = up.Message.Text.ToLower();
                var from = up.Message.From;
                var chatId = up.Message.Chat.Id;

                private string abtText = ""; // متغیر برای ذخیره متن ارسالی با /abt
private string abtLink = ""; // متغیر برای ذخیره لینک ارسالی با /abt
private void ProcessCommand(string text, long chatId)
{
    if (text.Contains("/start"))
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(from.Username + " به بات ما خوش آمدید !" + " \U00002764");
        sb.AppendLine("میتوانید از امکاناتی که در اختیار شما قرار داده ایم استفاده کنید .");
        sb.AppendLine("درباره ما : /AboutUs");
        sb.AppendLine("تماس با ما : /ContactUs");
        sb.AppendLine("آدرس ما : /Address");
        bot.SendTextMessageAsync(chatId, sb.ToString(), ParseMode.Default, false, false, 0, mainKeyboardMarkup);
    }
    else if (text.Contains("/aboutus") || text.Contains("درباره ما"))
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("ما خیلی خوبیم");
        bot.SendTextMessageAsync(chatId, sb.ToString());
    }
    else if (text.Contains("/contactus") || text.Contains("تماس با ما"))
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Email : Mehdiattari8@gmail.com");
        sb.AppendLine("Phone : 0000000000000");
        sb.AppendLine("Mobile : 000000000000");


        ReplyKeyboardMarkup contactKeyboardMarkup = new ReplyKeyboardMarkup();
        KeyboardButton[] row1 =
        {
                            new KeyboardButton("تماس با مدیریت"),new KeyboardButton("تماس با پشتیبانی"),new KeyboardButton("تماس با واحد فروش"),
                        };
        KeyboardButton[] row2 =
        {
                            new KeyboardButton("بازگشت"),
                        };
        contactKeyboardMarkup.Keyboard = new KeyboardButton[][]
        {
                            row1,row2
        };





        bot.SendTextMessageAsync(chatId, sb.ToString(), ParseMode.Default, false, false, 0, contactKeyboardMarkup);
    }
    else if (text.Contains("/address") || text.Contains("پشتیبانی"))
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("https://github.com/mehdiatari");


        InlineKeyboardMarkup inline = new InlineKeyboardMarkup();
        InlineKeyboardUrlButton[] row1 =
        {
                            new InlineKeyboardUrlButton("مدیریت","http://t.me/Mehdi19a97")new InlineKeyboardUrlButton("Web ","https://github.com/mehdiatari"),new InlineKeyboardUrlButton("کانال ","http://t.me/Mu8icf")
                        };
        inline.InlineKeyboard = new InlineKeyboardButton[][]
        {
                            row1
        };


        bot.SendTextMessageAsync(chatId, sb.ToString(), ParseMode.Default, false, false, 0, inline);



    }
    else if (text.Contains("بازگشت"))
    {
        bot.SendTextMessageAsync(chatId, "بازگشت به منوی اصلی", ParseMode.Default, false, false, 0,
            mainKeyboardMarkup);
    }
    else if (text.Contains("نظر سنجی"))
    {
        InlineKeyboardMarkup inline = new InlineKeyboardMarkup();
        InlineKeyboardCallbackButton[] row1 =
        {
                            new InlineKeyboardCallbackButton("بله راضی هستم ("+bale1+")","1")
                        };
        InlineKeyboardCallbackButton[] row2 =
        {
                            new InlineKeyboardCallbackButton("بله خیلی زیاد ("+bale2+")", "2")
                        };
        InlineKeyboardCallbackButton[] row3 =
        {
                            new InlineKeyboardCallbackButton("بله قطعا ("+bale3+")","3")
                        };
        inline.InlineKeyboard = new InlineKeyboardButton[][]
        {
                            row1,row2,row3
        };
        bot.SendTextMessageAsync(chatId, "آیا از این آموزش راضی هستید ؟", ParseMode.Default, false,
            false, 0, inline);



    }
    else if(text.Contains("/abt"))
    {
        // اگر درخواست متن شیشه ای شده باشد، کاربر را به درخواست متن دعوت می‌کنیم
        isWaitingForLink = true;
        waitingForLinkChatId = chatId;

        bot.SendTextMessageAsync(chatId, "لطفاً متن موردنظر خود را ارسال کنید.", ParseMode.Html, true);
    }
    else if (text.Contains("/sendabt"))
    {
        // اگر دستور /sendabt ارسال شده باشد
        if (!string.IsNullOrEmpty(abtText) && !string.IsNullOrEmpty(abtLink))
        {
            // اگر متن و لینک موجود باشد، آنها را به کاربر ارسال می‌کنیم
            bot.SendTextMessageAsync(chatId, $"متن ارسالی: {abtText}\nلینک ارسالی: {abtLink}", ParseMode.Html, true);
        }
        else
        {
            // اگر متن یا لینک موجود نباشد، اطلاعات کافی برای ارسال وجود ندارد
            bot.SendTextMessageAsync(chatId, "متن یا لینک برای ارسال وجود ندارد.");
        }
    }
}

private void btnSend_Click(object sender, EventArgs e)
{
    if (isWaitingForLink)
    {
        // در حالت انتظار برای لینک، متن درخواست شده را دریافت کرده و به کاربر ارسال می‌کنیم
        long chatId = waitingForLinkChatId;
        abtText = txtMessage.Text;

        // درخواست لینک ارسال می‌شود
        bot.SendTextMessageAsync(chatId, "حالا لطفاً لینک مربوطه را ارسال کنید.", ParseMode.Html, true);

        // متن ورودی را پاک می‌کنیم
        txtMessage.Text = "";
    }
    else
    {
        // در غیر این صورت متن به صورت عادی ارسال می‌شود
        if (dgReport.CurrentRow != null)
        {
            int chatId = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
            bot.SendTextMessageAsync(chatId, txtMessage.Text, ParseMode.Html, true);
            txtMessage.Text = "";
        }
    }
}
}


dgReport.Invoke(new Action(() =>
{
    dgReport.Rows.Add(chatId, from.Username, text, up.Message.MessageId,
        up.Message.Date.ToString("yyyy/MM/dd - HH:mm"));
}));
            }
        }
        catch (Exception ex)
{
    // در صورت بروز خطا، خطا را چاپ کنید و ادامه برنامه را فراهم کنید
    Console.WriteLine("Error: " + ex.Message);
}

// افزودن یک تاخیر برای جلوگیری از تکرار سریع
Thread.Sleep(1000);
    }
}


private void Form1_FormClosing(object sender, FormClosingEventArgs e)
{
    botThread.Abort();
}

private void btnSend_Click(object sender, EventArgs e)
{
    if (dgReport.CurrentRow != null)
    {
        int chatId = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
        bot.SendTextMessageAsync(chatId, txtMessage.Text, ParseMode.Html, true);
        txtMessage.Text = "";
    }
}

private void btnSelectFile_Click(object sender, EventArgs e)
{
    OpenFileDialog openFile = new OpenFileDialog();
    if (openFile.ShowDialog() == DialogResult.OK)
    {
        txtFilePath.Text = openFile.FileName;
    }
}

private void btnPhoto_Click(object sender, EventArgs e)
{
    if (dgReport.CurrentRow != null)
    {
        int chatId = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());

        FileStream imageFile = System.IO.File.Open(txtFilePath.Text, FileMode.Open);

        bot.SendPhotoAsync(chatId, new FileToSend("1234.jpg", imageFile), txtMessage.Text);
    }
}

private void btnVideo_Click(object sender, EventArgs e)
{
    if (dgReport.CurrentRow != null)
    {
        int chatId = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());

        FileStream videoFile = System.IO.File.Open(txtFilePath.Text, FileMode.Open);

        bot.SendVideoAsync(chatId, new FileToSend("iman.mp4", videoFile));
    }
}

private void btnSendText_Click(object sender, EventArgs e)
{
    bot.SendTextMessageAsync(txtChannel.Text, txtMessage.Text, ParseMode.Html);
}

private void checkBox1_CheckedChanged(object sender, EventArgs e)
{


}

private void textBox6_TextChanged(object sender, EventArgs e)
{

}

private void button2_Click(object sender, EventArgs e)
{

}

private void dgReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void btnSendPhoto_Click(object sender, EventArgs e)
{
    FileStream imageFile = System.IO.File.Open(txtFilePath.Text, FileMode.Open);

    bot.SendPhotoAsync(txtChannel.Text, new FileToSend("1234.jpg", imageFile), txtMessage.Text);
}

private void btnSendVideo_Click(object sender, EventArgs e)
{
    FileStream videoFile = System.IO.File.Open(txtFilePath.Text, FileMode.Open);

    bot.SendVideoAsync(txtChannel.Text, new FileToSend("iman.mp4", videoFile));
}
    }
}
