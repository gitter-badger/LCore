using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using LCore.Extensions;

namespace LCore.LUnit
    {
    public interface IValidateAttribute : ILUnitAttribute
        {
        string[] Validate(MemberInfo Member);
        }
    }