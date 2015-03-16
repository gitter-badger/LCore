using MVCL;
using MVCL.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Security;

namespace MVCL.Models
    {
    [ComplexType]
    public class ModelPermissions
        {
        public Boolean? View { get; set; }
        public Boolean? ViewInactive { get; set; }
        public Boolean? Export { get; set; }
        public Boolean? Create { get; set; }
        public Boolean? Edit { get; set; }
        public Boolean? Deactivate { get; set; }

        public static ModelPermissions AllowAll
            {
            get
                {
                return new ModelPermissions()
                {
                    View = true,
                    ViewInactive = true,
                    Export = true,
                    Create = true,
                    Edit = true,
                    Deactivate = true,
                };
                }
            }
        }
    }
