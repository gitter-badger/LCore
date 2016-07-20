using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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
        DbSet GetDBSet(Type Type);
        DbSet<T> GetDBSet<T>() where T : class;
        string GetHomeAction(IUserAccount User);
        string GetHomeController(IUserAccount User);
        string GetLogoURL();
        ISiteConfig GetSiteConfig(HttpContextBase Context);


        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken CancellationToken);
        }
    }