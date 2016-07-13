﻿using System;

namespace Singularity.Annotations
    {
    public class GlobalSearchDisabledAttribute : AdditionalValueAttribute
        {
        public const string Key = "GlobalSearchDisabled";

        public override string ValueKey => Key;

        public override object ValueData => true;
        }
    }