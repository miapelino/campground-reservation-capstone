using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ReservationSite
    {
        public int ReservationID { get; set; }
        public string CampgroundName { get; set; }
        public string ReservationName { get; set; }
        public decimal DailyFee { get; set; }
        public int SiteNumber { get; set; }
        public int MaxOccupancy { get; set; }
        public string Accessible { get; set; }
        public string MaxRvLength { get; set; }
        public string Utilities { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


        public ReservationSite(int rID, string cgName, string reservationName, decimal dailyFee, int siteNumber, int maxOccupancy, int accessible, int maxRvLength, int utilities, DateTime fromDate, DateTime toDate)
        {
            this.ReservationID = rID;
            this.CampgroundName = cgName;
            this.ReservationName = reservationName;
            this.DailyFee = dailyFee;
            this.SiteNumber = siteNumber;
            this.MaxOccupancy = maxOccupancy;

            if (accessible == 1)
            {
                this.Accessible = "Yes";
            }
            else
            {
                this.Accessible = "No";
            }

            if (maxRvLength == 0)
            {
                this.MaxRvLength = "N/A";
            }
            else
            {
                this.MaxRvLength = maxRvLength.ToString();
            }

            if (utilities == 1)
            {
                this.Utilities = "Yes";
            }
            else
            {
                this.Utilities = "N/A";
            }
            this.FromDate = fromDate;
            this.ToDate = toDate;
            
        }
    }
}
