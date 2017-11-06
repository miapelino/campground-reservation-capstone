using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Interfaces;

namespace Capstone.Models
{
    public class Park : IPark
    {
        public int Id { get; set; }
        public int AlphaID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime EstDate { get; set; }
        public int Area { get; set; }
        public int NumVisitors { get; set; }
        public string Description { get; set; }

        public Park (int id, int alphaID, string name, string location, DateTime estDate, int area, int numVisitors, string description)
        {
            this.Id = id;
            this.AlphaID = alphaID;
            this.Name = name;
            this.Location = location;
            this.EstDate = estDate;
            this.Area = area;
            this.NumVisitors = numVisitors;
            this.Description = description;
        }
    }
}
