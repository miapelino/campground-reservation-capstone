using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Interfaces;

namespace Capstone.Models
{
    public class Campground : ICampground
    {
        public int Id { get; set; }
        public int AlphaID { get; set; }
        public string Name { get; set; }
        public int ParkID { get; set; }
        public int OpenFrom { get; set; }
        public int OpenTo { get; set; }
        public decimal DailyFee { get; set; }

        public Campground(int id, int alphaID, int parkID, string name, int openFrom, int openTo, decimal dailyFee)
        {
            this.Id = id;
            this.AlphaID = alphaID;
            this.Name = name;
            this.ParkID = parkID;
            this.OpenFrom = openFrom;
            this.OpenTo = openTo;
            this.DailyFee = dailyFee;
        }
    }
}
