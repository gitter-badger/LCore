using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Singularity.Models
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