using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Interfaces;

namespace Capstone.Models
{
    public class Site : ISite
    {
        public string CampgroundName { get; set; }
        public int SiteNum { get; set; }
        public int MaxOccupancy { get; set; }
        public string Accessible { get; set; }
        public string MaxRVLength { get; set; }
        public string Utilities { get; set; }

        public Site(string campgroundName, int siteNum, int maxOccupancy, int accessible, int maxRVLength, int utilities)
        {
            this.CampgroundName = campgroundName;
            this.SiteNum = siteNum;
            this.MaxOccupancy = maxOccupancy;

            if (accessible == 1)
            {
                this.Accessible = "Yes";
            }
            else
            {
                this.Accessible = "No";
            }

            if (maxRVLength == 0)
            {
                this.MaxRVLength = "N/A";
            }
            else
            {
                this.MaxRVLength = maxRVLength.ToString();
            }

            if (utilities == 1)
            {
                this.Utilities = "Yes";
            }
            else
            {
                this.Utilities = "N/A";
            }
        }
    }
}
