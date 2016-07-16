using System;
using System.Collections.Generic;
using LCore.Extensions;
using Singularity.Models;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Singularity.Context;
using Singularity.Extensions;


namespace Singularity.Controllers
    {
    public static class ControllerHelper
        {
        [Flags]
        public enum ViewType
            {
            Create = 1,
            Edit = 2,
            Display = 4,
            TableCell = 8,
            FieldHeader = 16,
            Export = 32,

            All = Create | Display | Edit | Export | FieldHeader | TableCell
            }

        [Flags]
        public enum ManageViewType
            {
            Normal = 1,
            Inactive = 2,
            Archive = 4,

            All = Normal | Inactive | Archive
            }

        /// <exception cref="InvalidOperationException">Could not log error to database</exception>
        public static void HandleError(HttpContextBase Context, Exception Ex)
            {
            var ContextProvider = ContextProviderFactory.GetCurrent();

            if (ContextProvider.GetContextTypes(Context.Session).Has(typeof(Error)))
                {
                var DbContext = ContextProvider.GetContext(Context.Session);
                DbSet<Error> ErrorsTable = DbContext.GetDBSet<Error>();

                try
                    {
                    var Error = new Error
                        {
                        Message = Ex.Message,
                        FullDetails = Ex.ToString(),
                        Created = DateTime.Now,
                        Active = true,
                        URL = Context.Request.Url?.AbsoluteUri
                        };

                    if (ErrorsTable.Count(
                        DataError => DataError.FullDetails == Error.FullDetails &&
                                     DataError.URL == Error.URL &&
                                     // e.Created.Date == Error.Created.Date &&
                                     DataError.Active) > 0)
                        {
                        // Don't duplicate errors more than once per day.
                        return;
                        }

                    ErrorsTable.Add(Error);

                    DbContext.SaveChanges();
                    }
                catch (Exception Ex2)
                    {
                    throw new InvalidOperationException("Could not log error to database", Ex2);
                    }
                }
            }


        public static class AutomaticFields
            {
            public const string Active = "Active";
            public const string Created = "Created";
            public const string Updated = "Updated";
            public const string Archived = "Archived";
            }

        }
    }
