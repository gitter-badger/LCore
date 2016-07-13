using Singularity.Controllers;
using Singularity.Routes;
using System;

namespace Singularity.Annotations
    {
    public class FieldTypeFileUploadAttribute : CustomPartialAttribute, IFileUpload
        {
        public bool AllowDeactivate { get; set; }
        public bool AllowMultipleUploads { get; set; }

        public int SizeMinimum { get; set; }
        public int SizeMaximum { get; set; }

        public string[] AllowFileTypes { get; set; }

        public FieldTypeFileUploadAttribute(bool AllowDeactivate = true, bool AllowMultipleUploads = true,
            int SizeMinimum = 0, int SizeMaximum = int.MaxValue, string[] AllowFileTypes = null)
            : base(PartialViews.Manage.Fields.FileUpload, ControllerHelper.ViewType.All)
            {
            this.AllowDeactivate = AllowDeactivate;
            this.AllowMultipleUploads = AllowMultipleUploads;

            this.SizeMinimum = SizeMinimum;
            this.SizeMaximum = SizeMaximum;

            this.AllowFileTypes = AllowFileTypes;
            }
        }
    }