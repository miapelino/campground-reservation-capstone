using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Interfaces
{
    interface IPark
    {
        int Id { get; set; }
        int AlphaID { get; set; }
        string Name { get; set; }
        string Location { get; set; }
        DateTime EstDate { get; set; }
        int Area { get; set; }
        int NumVisitors { get; set; }
        string Description { get; set; }
    }
}
