using System;
using System.ComponentModel.DataAnnotations;
using Singularity.Models;
using System.Collections.Generic;

namespace SingularityInstanceClasses.Models
    {
    public class TestModel : IModel
        {
        [Key]
        public int TestModelID { get; set; }

        public virtual int ParentModelID { get; set; }
        public virtual TestModel ParentModel { get; set; }

        public virtual ICollection<TestModel> ChildModels { get; set; }
        }
    }