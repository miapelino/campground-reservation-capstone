using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Interfaces
{
    interface ISite
    {
        int SiteNum { get; set; }
        int MaxOccupancy { get; set; }
        string Accessible { get; set; }
        string MaxRVLength { get; set; }
        string Utilities { get; set; }
    }
}
