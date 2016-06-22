
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LCore.Extensions;
using Singularity.Context;
using System.Net.Mail;
using System.IO;
using Singularity.Annotations;
using Singularity.Extensions;


namespace Singularity.Models
    {
    [Table("EmailHistory")]
    public class EmailHistory : IModel
        {
        [Key]
        public int EmailHistoryID { get; set; }

        public DateTime? Sent { get; set; }

        public int? UserID { get; set; }

        public int? EmailJobID { get; set; }
        [FieldNoToken]
        public virtual EmailJob EmailJob { get; set; }

        public int? EmailTemplateID { get; set; }

        [FieldNoToken]
        public virtual EmailTemplate EmailTemplate { get; set; }

        public string ToAddresses { get; set; }
        public string ReplyToAddress { get; set; }

        public string CCAddresses { get; set; }
        public string BCCAddresses { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        public static void ProcessAllMessages(ModelContext DbContext, string SMTPHost, string SMTPUser, string SMTPPassword)
            {
            List<EmailHistory> Unsent = FindUnsent(DbContext).List();

            foreach (EmailHistory Email in Unsent)
                {
                MailMessage Mail = new MailMessage();
                SmtpClient Client = new SmtpClient
                    {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Host = SMTPHost,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPassword)
                    };

                Mail.To.Add(Email.ToAddresses);

                /////////////////////////////////////////////

                Mail.From = new MailAddress(SMTPUser);

                if (!string.IsNullOrEmpty(Email.ReplyToAddress))
                    Mail.ReplyToList.Add(new MailAddress(Email.ReplyToAddress));

                Mail.Body = Email.Body;
                Mail.Subject = Email.Subject;

                Mail.IsBodyHtml = true;

                /////////////////////////////////////////////

                Type ModelUserType = DbContext.UserInfoType;

                Type ModelContextType = typeof(EmailContext<>);

                // Inject the project's user type so the context matches
                ModelContextType = ModelContextType.MakeGenericType(ModelUserType);

                IModel EmailUser = (IModel)DbContext.GetDBSet(ModelUserType).Find(Email.UserID);

                IModel EmailContext = (IModel)ModelContextType.New(new object[] { Email, EmailUser });

                Mail.Body = EmailContext.TemplateTokenFill(Mail.Body);
                Mail.Subject = EmailContext.TemplateTokenFill(Mail.Subject);

                /////////////////////////////////////////////

                List<FileUpload> Attachments = new List<FileUpload>();

                // Add attachements from EmailJob
                Attachments.AddRange(FileUpload.GetFileUploads(DbContext, Email.EmailJob, nameof(Email.EmailJob.Attachments)));

                // Add attachements from EmailTemplate
                Attachments.AddRange(FileUpload.GetFileUploads(DbContext, Email.EmailJob.EmailTemplate, nameof(Email.EmailJob.Attachments)));

                foreach (FileUpload Attachment in Attachments)
                    {
                    byte[] Bytes = Attachment.GetCloudBytes();

                    string Name = Attachment.FilePath;

                    if (Name.Contains("\\"))
                        Name = Name.Substring(Name.LastIndexOf('\\') + 1);

                    Mail.Attachments.Add(new Attachment(new MemoryStream(Bytes), Name));
                    }

                /////////////////////////////////////////////

                Client.Send(Mail);

                Email.Sent = DateTime.Now;

                DbContext.SaveChanges();
                }
            }

        public static IQueryable<EmailHistory> FindUnsent(ModelContext DbContext)
            {
            return DbContext.GetDBSet<EmailHistory>().Where(
                h => h.Sent == null);
            }

        public static EmailHistory FindEmail(ModelContext DbContext, EmailHistory Email, bool? Sent = null)
            {
            return DbContext.GetDBSet<EmailHistory>()
                    .FirstOrDefault(h => h.ToAddresses == Email.ToAddresses &&
                    h.Body == Email.Body &&
                    h.Subject == Email.Subject &&
                        (Sent == null ||
                        (Sent == true && h.Sent != null) ||
                        (Sent == false && h.Sent == null)));
            }

        public override string ToString()
            {
            return $"{this.ToAddresses} - {this.Subject}";
            }

        public class EmailContext<T> : IModel
            where T : IModel
            {
            public EmailContext(EmailHistory Email, T User)
                {
                this.Email = Email;
                this.User = User;
                }

            public EmailHistory Email { get; set; }

            public T User { get; set; }
            }
        }
    }