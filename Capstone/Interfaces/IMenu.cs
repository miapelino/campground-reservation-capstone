using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.Interfaces
{
    interface IMenu
    {
        void Runner();
        bool ParkDisplay();
        bool ParkInfoScreen(Park p);
        bool PrintCampgrounds(Park p);
        bool ParkCampgrounds(Park p);
        bool AvailableForReservation(decimal dailyFee, int cgID, DateTime arriveDate, DateTime departDate);
        void MakeReservation(int siteNumSelection, string reservationName, DateTime arriveDate, DateTime departDate);
        string GetMonthString(int month);
    }
}
