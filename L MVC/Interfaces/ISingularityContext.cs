using System;

namespace Singularity.Context
    {
    public interface ISingularityContext
        {
        string ContextName { get; }
        Type[] ContextTypes { get; }
        Type UserAccountType { get; }
        Type UserRoleType { get; }

        string GetLogoURL();
        }
    }