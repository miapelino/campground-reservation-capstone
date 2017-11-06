using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Interfaces;

namespace Capstone.Models
{
    public class Reservation : IReservation
    {
        public int Id { get; set; }
        public int SiteID { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreateDate { get; set; }

        public Reservation(int id, int siteID, string name, DateTime fromDate, DateTime toDate, DateTime createDate)
        {
            this.Id = id;
            this.SiteID = siteID;
            this.Name = name;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.CreateDate = createDate;
        }
    }
}
