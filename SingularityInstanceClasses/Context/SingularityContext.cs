using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SingularityInstanceClasses.Models;

//TODO: Implement: Rename SingularityInstanceClasses to [YourProject]Classes
namespace SingularityInstanceClasses
    {
    //TODO: Implement: Rename SingularityContext to [YourProject]Context
    public class SingularityContext : Singularity.Context.ModelContext
        {
        //TODO: Implement: Rename Singularity to [YourProject]
        public const string Name = "Singularity";

        //TODO: Implement: Change Connection String to your own
        public SingularityContext()
            : base("DevelopmentConnection")
            {
            }

        public override Type[] ContextTypes => new[] {
        typeof(UserProfile),
        typeof(ProfileRole),
        typeof(Event),
        typeof(UserInfo),
        typeof(GlobalSettings),

        typeof(Singularity.Models.FileUpload),
        typeof(Singularity.Models.Error),
        typeof(Singularity.Models.TextContent),
        typeof(Singularity.Models.Template),
        typeof(Singularity.Models.CustomExport),
        typeof(Singularity.Models.SavedSearch),
        typeof(Singularity.Models.EmailTemplate),
        typeof(Singularity.Models.EmailJob),
        typeof(Singularity.Models.EmailHistory)
        };


        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ProfileRole> ProfileRoles { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<GlobalSettings> GlobalSettingsData { get; set; }

        public DbSet<Singularity.Models.FileUpload> FileUploads { get; set; }
        public DbSet<Singularity.Models.Error> Errors { get; set; }
        public DbSet<Singularity.Models.TextContent> TextContent { get; set; }
        public DbSet<Singularity.Models.Template> Templates { get; set; }


        public DbSet<Singularity.Models.CustomExport> ExportHeaders { get; set; }
        public DbSet<Singularity.Models.SavedSearch> SavedSearches { get; set; }
        public DbSet<Singularity.Models.EmailTemplate> EmailNotifications { get; set; }
        public DbSet<Singularity.Models.EmailJob> EmailJobs { get; set; }
        public DbSet<Singularity.Models.EmailHistory> EmailHistory { get; set; }

        public DbSet<Singularity.Models.SiteConfig> SiteConfig { get; set; }


        public override Type UserAccountType => typeof(UserProfile);

        public override Type UserInfoType => typeof(UserInfo);
        public override Type UserRoleType => typeof(UserProfile);

        public GlobalSettings GlobalSettings => this.GlobalSettingsData.FirstOrDefault();

        public override string ContextName => Name;

        public override string GetLogoURL()
            {
            return "/Images/logo.png";
            }

        protected override void OnModelCreating(DbModelBuilder ModelBuilder)
            {
            // Many to Many parent child relationship             
            ModelBuilder.Entity<TestModel>()
                        .HasMany(s => s.ChildModels)
                        .WithOptional(s => s.ParentModel);
            }
        }
    }
