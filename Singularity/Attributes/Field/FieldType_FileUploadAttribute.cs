using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Singularity
    {
    public class FieldType_FileUploadAttribute : CustomPartialAttribute, IFileUpload
        {
        public Boolean AllowDeactivate { get; set; }
        public Boolean AllowMultipleUploads { get; set; }

        public int SizeMinimum { get; set; }
        public int SizeMaximum { get; set; }

        public String[] AllowFileTypes { get; set; }

        public FieldType_FileUploadAttribute(Boolean AllowDeactivate = true, Boolean AllowMultipleUploads = true,
            int SizeMinimum = 0, int SizeMaximum = int.MaxValue, String[] AllowFileTypes = null)
            : base(ControllerHelper.PartialViews.Field_FileUpload, ControllerHelper.ViewType.All)
            {
            this.AllowDeactivate = AllowDeactivate;
            this.AllowMultipleUploads = AllowMultipleUploads;

            this.SizeMinimum = SizeMinimum;
            this.SizeMaximum = SizeMaximum;

            this.AllowFileTypes = AllowFileTypes;
            }
        }
    }