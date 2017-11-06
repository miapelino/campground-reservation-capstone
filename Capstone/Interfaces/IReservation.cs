using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Interfaces
{
    interface IReservation
    {
        int Id { get; set; }
        int SiteID { get; set; }
        string Name { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        DateTime CreateDate { get; set; }
    }
}
