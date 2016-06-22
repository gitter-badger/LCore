using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singularity.Models;

namespace SingularityInstanceClasses.Models
    {
    [Table("Roles")]
    public class SingularityRole : IModel
        {
        [Key]
        public int RoleID { get; set; }
        
        public bool AllowLogin { get; set; }

        public string Name { get; set; }

        public override string ToString()
            {
            return this.Name;
            }
        }
    }