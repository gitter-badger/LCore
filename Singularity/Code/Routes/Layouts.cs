using System;
using System.Collections;
using System.Collections.Generic;

namespace Singularity.Routes
    {
    public static class Layouts
        {
        private static readonly string Views = $"{nameof(Views)}";
        private static readonly string Shared = $"{nameof(Shared)}";
        private static readonly string cshtml = $"{nameof(cshtml)}";

        
        public static readonly string Main = $"~/{Views}/{Shared}/_{nameof(Main)}.{cshtml}";
        public static readonly string Admin = $"~/{Views}/{Shared}/{nameof(Admin)}/_{nameof(Admin)}.{cshtml}";
        }
    }