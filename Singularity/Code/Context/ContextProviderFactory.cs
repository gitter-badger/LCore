using System;
using System.Data.Entity;

using LCore.Extensions;

namespace Singularity.Context
    {
    public static class ContextProviderFactory
        {
        private static ContextProvider CurrentProvider { get; set; }

        public static ContextProvider GetCurrent()
            {
            return CurrentProvider;
            }

        public static void SetCurrent(ContextProvider Value)
            {
            if (CurrentProvider != null)
                throw new Exception("ContextProvider is already set.");

            CurrentProvider = Value;
            }

        public static DbSet<T> GetDBSet<T>(this DbContext Context)
            where T : class
            {
            var Type = typeof(T);

            return Context.GetType()
                .GetProperties().First(prop =>
                {
                    if (prop.PropertyType.IsGenericType &&
                        prop.PropertyType.GetGenericArguments()[0] == Type)
                        return (DbSet<T>)prop.GetValue(Context);

                    return null;
                });
            }
        }
    }
