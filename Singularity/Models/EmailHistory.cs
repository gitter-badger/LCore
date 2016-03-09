
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;

using LCore;
using Singularity;
using Singularity.Context;
using Singularity.Controllers;
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

        public String ToAddresses { get; set; }
        public String ReplyToAddress { get; set; }

        public String CCAddresses { get; set; }
        public String BCCAddresses { get; set; }

        public String Subject { get; set; }
        public String Body { get; set; }

        public static void ProcessAllMessages(ModelContext DbContext, String SMTPHost, String SMTPUser, String SMTPPassword)
            {
            List<EmailHistory> Unsent = EmailHistory.FindUnsent(DbContext).List();

            foreach (EmailHistory Email in Unsent)
                {
                MailMessage Mail = new MailMessage();
                SmtpClient Client = new SmtpClient();

                Client.Port = 587;
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;

                Client.Host = SMTPHost;
                Client.EnableSsl = true;

                Client.UseDefaultCredentials = false;
                Client.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPassword);

                Mail.To.Add(Email.ToAddresses);

                /////////////////////////////////////////////

                Mail.From = new MailAddress(SMTPUser);

                if (!String.IsNullOrEmpty(Email.ReplyToAddress))
                    Mail.ReplyToList.Add(new MailAddress(Email.ReplyToAddress));

                Mail.Body = Email.Body;
                Mail.Subject = Email.Subject;

                Mail.IsBodyHtml = true;

                /////////////////////////////////////////////

                Type ModelUserType = DbContext.UserInfoType;

                Type ModelContextType = typeof(EmailHistory.EmailContext<>);

                // Inject the project's user type so the context matches
                ModelContextType = ModelContextType.MakeGenericType(ModelUserType);

                IModel EmailUser = (IModel)DbContext.GetDBSet(ModelUserType).Find(Email.UserID);

                IModel EmailContext = (IModel)ModelContextType.New(new[] { Email, EmailUser });

                Mail.Body = EmailContext.TemplateTokenFill(Mail.Body);
                Mail.Subject = EmailContext.TemplateTokenFill(Mail.Subject);

                /////////////////////////////////////////////

                List<Singularity.Models.FileUpload> Attachments = new List<FileUpload>();

                // Add attachements from EmailJob
                Attachments.AddRange(Singularity.Models.FileUpload.GetFileUploads(DbContext, Email.EmailJob, MetaExt.Name<EmailJob>(e => e.Attachments)));

                // Add attachements from EmailTemplate
                Attachments.AddRange(Singularity.Models.FileUpload.GetFileUploads(DbContext, Email.EmailJob.EmailTemplate, MetaExt.Name<EmailTemplate>(e => e.Attachments)));

                foreach (Singularity.Models.FileUpload Attachment in Attachments)
                    {
                    Byte[] Bytes = Attachment.GetCloudBytes();

                    String Name = Attachment.FilePath;

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

        public static EmailHistory FindEmail(ModelContext DbContext, EmailHistory Email, Boolean? Sent = null)
            {
            return DbContext.GetDBSet<EmailHistory>().Where(
                h => h.ToAddresses == Email.ToAddresses &&
                    h.Body == Email.Body &&
                    h.Subject == Email.Subject &&
                        (Sent == null ||
                        (Sent == true && h.Sent != null) ||
                        (Sent == false && h.Sent == null)))
                    .FirstOrDefault();
            }

        public override string ToString()
            {
            return ToAddresses + " - " + Subject;
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