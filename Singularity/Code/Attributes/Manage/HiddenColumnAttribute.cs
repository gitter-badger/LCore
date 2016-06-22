using System;

namespace Singularity.Annotations
    {
    public class HideManageViewColumnAttribute : AdditionalValueAttribute
        {
        public const string Key = "HiddenColumn";

        public override string ValueKey => Key;

        public override object ValueData => true;
        }
    }