using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Interfaces
{
    interface ICampground
    {
        int Id { get; set; }
        int AlphaID { get; set; }
        string Name { get; set; }
        int ParkID { get; set; }
        int OpenFrom { get; set; }
        int OpenTo { get; set; }
        decimal DailyFee { get; set; }
    }
}
