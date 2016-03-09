using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Routing;
using LCore;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Singularity.Annotations
    {
    public interface IFileUpload
        {
        Boolean AllowDeactivate { get; set; }
        Boolean AllowMultipleUploads { get; set; }

        int SizeMinimum { get; set; }
        int SizeMaximum { get; set; }

        String[] AllowFileTypes { get; set; }
        }
    }
