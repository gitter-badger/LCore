using System;
using LCore.Extensions;

namespace LMVC.Annotations
    {
    public class HideManageViewColumnAttribute : AdditionalValueAttribute, ISubClassPersistentAttribute
        {
        public const string Key = "HiddenColumn";

        public override string ValueKey => Key;

        public override object ValueData => true;
        }
    }