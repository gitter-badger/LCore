using System;
using System.Collections;
using System.Collections.Generic;

namespace LMVC.Routes
    {
    public static class Layouts
        {
        // ReSharper disable InconsistentNaming
        private static readonly string Views = $"{nameof(Views)}";
        private static readonly string Shared = $"{nameof(Shared)}";
        private static readonly string cshtml = $"{nameof(cshtml)}";
        // ReSharper restore InconsistentNaming


        public static readonly string Main = $"~/{Views}/{Shared}/_{nameof(Main)}.{cshtml}";
        public static readonly string Admin = $"~/{Views}/{Shared}/{nameof(Admin)}/_{nameof(Admin)}.{cshtml}";
        }
    }