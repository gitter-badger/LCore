using System;
using System.Data.Entity;
using System.Web;
using Singularity.Controllers;

namespace Singularity.Context
    {
    public interface IContextProvider
        {
        string SiteTitle { get; }

        IMenuController[] AllMenuControllers(HttpSessionStateBase Session);

        Type[] GetContextTypes(HttpSessionStateBase Session);
        DbSet GetDBSet(HttpSessionStateBase Session, Type Type);
        DbSet<T> GetDBSet<T>(HttpSessionStateBase Session) where T : class, new();
        
        string GetFileUploadFilePath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID);
        string GetFileUploadRootPath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID);
        string GetVersionNumber();
        }
    }