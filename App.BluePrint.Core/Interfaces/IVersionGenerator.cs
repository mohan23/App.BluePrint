using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Interfaces
{
    internal interface IVersionGenerator
    {
        int Major { get; set; }
        int Minor { get; set; }
        int Revision { get; set; }
        int Build { get; set; }
    }
}
