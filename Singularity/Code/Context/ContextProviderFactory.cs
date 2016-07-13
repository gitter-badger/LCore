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

        /// <exception cref="InvalidOperationException">ContextProvider is already set.</exception>
        public static void SetCurrent(ContextProvider Value)
            {
            if (CurrentProvider != null)
                throw new InvalidOperationException("ContextProvider is already set.");

            CurrentProvider = Value;
            }

        public static DbSet<T> GetDBSet<T>(this DbContext Context)
            where T : class
            {
            var Type = typeof(T);

            return Context.GetType()
                .GetProperties().First(Prop =>
                {
                    if (Prop.PropertyType.IsGenericType &&
                        Prop.PropertyType.GetGenericArguments()[0] == Type)
                        return (DbSet<T>)Prop.GetValue(Context);

                    return null;
                });
            }
        }
    }
