﻿using System;
using System.Web.Mvc;
using LCore.Extensions;
using Singularity.Models;

namespace Singularity.Annotations
    {
    public interface ISetFormField : ITopLevelAttribute
        {
        bool SetFormField(FormCollection Form, IModel Model, ModelMetadata Meta, string Value);
        }

    [AttributeUsage(AttributeTargets.Property)]
    public abstract class SetFormFieldAttribute : Attribute, ISetFormField
        {
        public abstract bool SetFormField(FormCollection Form, IModel Model, ModelMetadata Meta, string Value);
        }
    }
