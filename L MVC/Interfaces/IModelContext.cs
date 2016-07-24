using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using JetBrains.Annotations;
using LMVC.Models;

namespace LMVC.Context
    {
    public interface IModelContext
        {
        DbContextConfiguration Configuration { get; }

        string ContextName { get; }
        Type[] ContextTypes { get; }
        Type UserAccountType { get; }
        Type UserRoleType { get; }

        SqlConnection CreateConnection();
        [CanBeNull]
        DbSet GetDBSet(Type Type);
        [CanBeNull]
        DbSet<T> GetDBSet<T>() where T : class;
        [CanBeNull]
        string GetHomeAction(IUserAccount User);
        [CanBeNull]
        string GetHomeController(IUserAccount User);
        [CanBeNull]
        string GetLogoURL();
        [CanBeNull]
        ISiteConfig GetSiteConfig(HttpContextBase Context);


        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken CancellationToken);
        }
    }