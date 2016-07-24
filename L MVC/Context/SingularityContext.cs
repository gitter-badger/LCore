using System;
using System.Collections.Generic;
using System.Data.Entity;
using JetBrains.Annotations;
using LCore.Extensions;
using LMVC.Models;
using FileUpload = LMVC.Models.FileUpload;

//TODO: Implement: Rename SingularityInstanceClasses to [YourProject]Classes
namespace LMVC.Context
    {
    //TODO: Implement: Rename SingularityContext to [YourProject]Context
    public class SingularityContext : ModelContext, ISingularityContext
        {
        //TODO: Implement: Rename Singularity to [YourProject]
        public const string Name = "Singularity";

        //TODO: Implement: Change Connection String to your own
        public SingularityContext()
            : base("DevelopmentConnection")
            {
            }

        public override Type[] ContextTypes => new[] {
        typeof(AccountRole),
        typeof(Event),
        typeof(UserAccount),
        typeof(GlobalSettings),

        typeof(FileUpload),
        typeof(Error),
        typeof(TextContent),
        typeof(Template),
        typeof(CustomExport),
        typeof(SavedSearch),
        typeof(EmailTemplate),
        typeof(EmailJob),
        typeof(EmailHistory)
        };

        public DbSet<UserAccount> UserAccounts { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<GlobalSettings> GlobalSettingsData { get; set; }

        public DbSet<FileUpload> FileUploads { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<TextContent> TextContent { get; set; }
        public DbSet<Template> Templates { get; set; }


        public DbSet<CustomExport> ExportHeaders { get; set; }
        public DbSet<SavedSearch> SavedSearches { get; set; }
        public DbSet<EmailTemplate> EmailNotifications { get; set; }
        public DbSet<EmailJob> EmailJobs { get; set; }
        public DbSet<EmailHistory> EmailHistory { get; set; }

        public DbSet<SiteConfig> SiteConfig { get; set; }

        public DbSet<SecurityLog> SecurityLogs { get; set; }

        public override Type UserAccountType => typeof(UserAccount);
        public override Type UserRoleType => typeof(AccountRole);

        public GlobalSettings GlobalSettings => this.GlobalSettingsData.First();

        public override string ContextName => Name;

        [NotNull]
        public override string GetLogoURL()
            {
            return "/Images/logo.png";
            }

        protected override void OnModelCreating([CanBeNull] DbModelBuilder ModelBuilder)
            {
            // Many to Many parent child relationship             
            ModelBuilder?.Entity<TestModel>()
                        .HasMany(TestModel => TestModel.ChildModels)
                        .WithOptional(TestModel => TestModel.ParentModel);
            }
        }
    }
