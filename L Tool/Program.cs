using System;
using System.Windows.Forms;
using System.Net.Mail;

namespace L_Tool
    {
    public static class Program
        {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
            {
            /*
            String s =
                $"{L.Type_GetAllLambdas(typeof(FileInfo))}\r\n{L.Type_GetAllLambdas(typeof(Directory))}\r\n{L.Type_GetAllLambdas(typeof(Path))}\r\n{L.Type_GetAllLambdas(typeof(DirectoryInfo))}\r\n{L.Type_GetAllLambdas(typeof(DriveInfo))}\r\n{L.Type_GetAllLambdas(typeof(File))}\r\n{L.Type_GetAllLambdas(typeof(FileStream))}\r\n{L.Type_GetAllLambdas(typeof(Stream))}\r\n{L.Type_GetAllLambdas(typeof(BufferedStream))}\r\n";
            
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LTool());
            }

        private const string SMTPHost = "smtp.gmail.com";
        private const string SMTPUser = "";
        private const string SMTPPassword = "";

        private static SmtpClient _SMTP;
        public static SmtpClient SMTP
            {
            get
                {
                if (_SMTP == null)
                    {
                    string Host = SMTPHost.Trim();
                    if (string.IsNullOrEmpty(Host))
                        {
                        Host = "localhost";
                        }

                    _SMTP = new SmtpClient(Host);

                    string User = SMTPUser.Trim();
                    string Password = SMTPPassword.Trim();

                    _SMTP.Port = 587;
                    _SMTP.EnableSsl = true;
                    _SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                    _SMTP.UseDefaultCredentials = false;

                    if (User != "")
                        _SMTP.Credentials = new System.Net.NetworkCredential(User, Password);

                    }
                return _SMTP;
                }
            }
        }
    }
