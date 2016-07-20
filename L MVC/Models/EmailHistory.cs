
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using LCore.Extensions;
using LMVC.Context;
using System.Net.Mail;
using System.IO;
using LMVC.Annotations;
using LMVC.Extensions;


namespace LMVC.Models
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

        /// <exception cref="SmtpException">The connection to the SMTP server failed.-or-Authentication failed.-or-The operation timed out.-or-<see cref="P:System.Net.Mail.SmtpClient.EnableSsl" /> is set to true but the <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod" /> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.SpecifiedPickupDirectory" /> or <see cref="F:System.Net.Mail.SmtpDeliveryMethod.PickupDirectoryFromIis" />.-or-<see cref="P:System.Net.Mail.SmtpClient.EnableSsl" /> is set to true, but the SMTP mail server did not advertise STARTTLS in the response to the EHLO command.</exception>
        /// <exception cref="InvalidOperationException">This <see cref="T:System.Net.Mail.SmtpClient" /> has a <see>
        ///         <cref>SmtpClient.SendAsync</cref>
        ///     </see>
        ///     call in progress.-or- <see cref="P:System.Net.Mail.MailMessage.From" /> is null.-or- There are no recipients specified in <see cref="P:System.Net.Mail.MailMessage.To" />, <see cref="P:System.Net.Mail.MailMessage.CC" />, and <see cref="P:System.Net.Mail.MailMessage.Bcc" /> properties.-or- <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod" /> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network" /> and <see cref="P:System.Net.Mail.SmtpClient.Host" /> is null.-or-<see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod" /> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network" /> and <see cref="P:System.Net.Mail.SmtpClient.Host" /> is equal to the empty string ("").-or- <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod" /> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network" /> and <see cref="P:System.Net.Mail.SmtpClient.Port" /> is zero, a negative number, or greater than 65,535.</exception>
        /// <exception cref="ObjectDisposedException">This object has been disposed.</exception>
        /// <exception cref="SmtpFailedRecipientsException">The <paramref>
        ///         <name>message</name>
        ///     </paramref>
        ///     could not be delivered to one or more of the recipients in <see cref="P:System.Net.Mail.MailMessage.To" />, <see cref="P:System.Net.Mail.MailMessage.CC" />, or <see cref="P:System.Net.Mail.MailMessage.Bcc" />.</exception>
        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        /// <exception cref="NotSupportedException">An attempt was made to use unsupported behavior such as executing multiple asynchronous commands concurrently on the same context instance.</exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
        ///             concurrency violation; that is, a row has been changed in the database since it was queried.
        ///             </exception>
        /// <exception cref="DbEntityValidationException">
        ///             The save was aborted because validation of entity property values failed.
        ///             </exception>
        public static void ProcessAllMessages(ModelContext DbContext, string SMTPHost, string SMTPUser, string SMTPPassword)
            {
            List<EmailHistory> Unsent = FindUnsent(DbContext).List();

            foreach (var Email in Unsent)
                {
                var Mail = new MailMessage();
                var Client = new SmtpClient
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

                var ModelUserType = DbContext.UserAccountType;

                var ModelContextType = typeof(EmailContext<>);

                // Inject the project's user type so the context matches
                ModelContextType = ModelContextType.MakeGenericType(ModelUserType);

                var EmailUser = (IModel)DbContext.GetDBSet(ModelUserType).Find(Email.UserID);

                var EmailContext = (IModel)ModelContextType.New(new object[] { Email, EmailUser });

                Mail.Body = EmailContext.TemplateTokenFill(Mail.Body);
                Mail.Subject = EmailContext.TemplateTokenFill(Mail.Subject);

                /////////////////////////////////////////////

                var Attachments = new List<FileUpload>();

                // Add attachments from EmailJob
                Attachments.AddRange(FileUpload.GetFileUploads(DbContext, Email.EmailJob, nameof(Email.EmailJob.Attachments)));

                // Add attachments from EmailTemplate
                Attachments.AddRange(FileUpload.GetFileUploads(DbContext, Email.EmailJob.EmailTemplate, nameof(Email.EmailJob.Attachments)));

                foreach (var Attachment in Attachments)
                    {
                    byte[] Bytes = Attachment.GetCloudBytes();

                    string Name = Attachment.FilePath;

                    if (Name.Contains("\\"))
                        Name = Name.Substring(Name.LastIndexOf('\\') + 1);

                    Mail.Attachments.Add(new Attachment(new MemoryStream(Bytes), Name));
                    }

                /////////////////////////////////////////////

                try
                    {
                    Client.Send(Mail);
                    }
                catch (ArgumentNullException) { /* Mail will not be null*/ }

                Email.Sent = DateTime.Now;

                DbContext.SaveChanges();
                }
            }

        public static IQueryable<EmailHistory> FindUnsent(ModelContext DbContext)
            {
            return DbContext.GetDBSet<EmailHistory>().Where(
                History => History.Sent == null);
            }

        public static EmailHistory FindEmail(ModelContext DbContext, EmailHistory Email, bool? Sent = null)
            {
            return DbContext.GetDBSet<EmailHistory>()
                    .FirstOrDefault(History => History.ToAddresses == Email.ToAddresses &&
                    History.Body == Email.Body &&
                    History.Subject == Email.Subject &&
                        (Sent == null ||
                        (Sent == true && History.Sent != null) ||
                        (Sent == false && History.Sent == null)));
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