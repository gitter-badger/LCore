using System;
using System.Web.Mvc;
using Singularity.Models;

namespace Singularity.Annotations
    {
    public interface ISetFormField
        {
        bool SetFormField(FormCollection Form, IModel Model, ModelMetadata Meta, string Value);
        }

    [AttributeUsage(AttributeTargets.Property)]
    public abstract class SetFormFieldAttribute : Attribute, ISetFormField
        {
        public abstract bool SetFormField(FormCollection Form, IModel Model, ModelMetadata Meta, string Value);
        }
    }
