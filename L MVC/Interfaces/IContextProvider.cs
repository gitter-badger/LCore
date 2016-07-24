using System;
using System.Data.Entity;
using System.Web;
using JetBrains.Annotations;
using LMVC.Controllers;

namespace LMVC.Context
    {
    public interface IContextProvider
        {
        [CanBeNull]
        string SiteTitle { get; }

        [CanBeNull]
        IMenuController[] AllMenuControllers(HttpSessionStateBase Session);

        [CanBeNull]
        Type[] GetContextTypes(HttpSessionStateBase Session);
        [CanBeNull]
        DbSet GetDBSet(HttpSessionStateBase Session, Type Type);
        [CanBeNull]
        DbSet<T> GetDBSet<T>(HttpSessionStateBase Session) where T : class, new();

        [CanBeNull]
        string GetFileUploadFilePath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID);

        [CanBeNull]
        string GetFileUploadRootPath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID);

        [CanBeNull]
        string GetVersionNumber();
        }
    }