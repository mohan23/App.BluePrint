﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Common
{
    public enum LoginType
    {
        Forms,
        Windows,
        Faceboot,
        Google,
        Live,
        Custom
    }

    public enum ExPropType
    {
        Form,
        Group,
        Section,
        Field,
        Table,
        TableField,
        FormulaField,
        ImmutableField
    }
}
