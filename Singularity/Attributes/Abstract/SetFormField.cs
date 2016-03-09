using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Routing;
using LCore;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Singularity.Models;

namespace Singularity.Annotations
    {
    public interface ISetFormField
        {
        Boolean SetFormField(FormCollection Form, IModel Model, ModelMetadata Meta, String Value);
        }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class SetFormFieldAttribute : Attribute, ISetFormField
        {
        public abstract Boolean SetFormField(FormCollection Form, IModel Model, ModelMetadata Meta, String Value);

        public SetFormFieldAttribute()
            {
            }
        }
    }
