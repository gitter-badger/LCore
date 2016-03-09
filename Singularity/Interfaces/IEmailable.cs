using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCore;
using System.Linq.Expressions;
using Singularity.Models;

namespace Singularity.Annotations
    {
    public interface IEmailable : IModel
        {
        String[] GetEmails();
        String[] GetEmails(String Field);
        }
    }
