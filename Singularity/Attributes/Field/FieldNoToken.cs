using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Singularity.Annotations
    {
    public interface IFieldNoToken
        {
        }

    public class FieldNoTokenAttribute : Attribute, IFieldNoToken
        {
        }
    }