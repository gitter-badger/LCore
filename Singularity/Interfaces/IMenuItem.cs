
using System;
using System.Collections.Generic;
using LCore;
using Singularity;
using Singularity.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Singularity.Controllers
    {
    public interface IMenuItem
        {
        String PageGroup { get; set; }
        String MenuText { get; set; }

        String Action { get; set; }
        String ControllerName { get; set; }

        int? TotalCount { get; set; }
        }
    public class MenuItem : IMenuItem
        {
        public String PageGroup { get; set; }
        public String MenuText { get; set; }

        public String Action { get; set; }
        public String ControllerName { get; set; }

        public int? TotalCount { get; set; }
        }
    }