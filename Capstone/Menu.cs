using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capstone.Models;
using Capstone.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Interfaces;

namespace Capstone
{
    public class Menu : IMenu
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CapstoneDatabase"].ConnectionString;

        public void Runner()
        {
            bool running = true;

            while (running)
            {
                running = ParkDisplay();
            }
        }

        public bool ParkDisplay()
        {
            Console.Clear();
            ParkDAL parkDAL = new ParkDAL(connectionString);
            List<Park> parks = parkDAL.GetParks();
            Console.WriteLine("  __  __  ___  ______ __   ___   __  __  ___  __       ____   ___  ____  __ __  __");
            Console.WriteLine(@"  ||\ || // \\ | || | ||  // \\  ||\ || // \\ ||       || \\ // \\ || \\ || // (( \");
            Console.WriteLine(@"  ||\\|| ||=||   ||   || ((   )) ||\\|| ||=|| ||       ||_// ||=|| ||_// ||<<   \\ ");
            Console.WriteLine(@"  || \|| || ||   ||   ||  \\_//  || \|| || || ||__|    ||    || || || \\ || \\ \_))");
            Console.WriteLine();
            Console.WriteLine(@"  ........::::::::::::..           .......|...............::::::::........");
            Console.WriteLine(@"     .:::::; ; ; ; ; ; ; ; ; ; ;:::::.... .     \   | ../....::::; ; ; ;:::::..");
            Console.WriteLine(@"         .       ...........   / \\_   \  |  /     ......  .     ........./\");
            Console.WriteLine(@"...:::../\\_  ......     ..._/'   \\\_  \###/   /\_    .../ \_.......   _//");
            Console.WriteLine(@".::::./   \\\ _   .../\    /'      \\\\#######//   \/\   //   \_   ....////");
            Console.WriteLine(@"    _/      \\\\   _/ \\\ /  x       \\\\###////      \////     \__  _/////");
            Console.WriteLine(@"  ./   x       \\\/     \/ x X           \//////                   \/////");
            Console.WriteLine(@" /     XxX     \\/         XxX X                                    ////   x");
            Console.WriteLine(@"-----XxX-------------|-------XxX-----------*--------|---*-----|------------X--");
            Console.WriteLine(@"       X        _X      *    X      **         **             x   **    *  X");
            Console.WriteLine(@"      _X                    _X           x                *          x     X_");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" *".PadRight(33, '*'));
            Console.WriteLine(" Select a Park for Further Details");
            Console.WriteLine(" *".PadRight(33, '*'));

            foreach (Park p in parks)
            {
                Console.WriteLine($" |{p.AlphaID}| {p.Name}");
            }
            Console.WriteLine(" |Q| Quit");

            string input = Console.ReadLine();

            if (input.ToLower() == "q")
            {
                return false;
            }

            else
            {
                foreach (Park p in parks)
                {
                    if (input == p.AlphaID.ToString())
                    {
                        bool running = true;
                        while (running)
                        {
                            running = ParkInfoScreen(p);
                        }
                        return true;
                    }
                }

                Console.WriteLine(" Please enter a valid park. Press any key to continue.");
                Console.ReadKey();
            }
            return true;
        }

        public bool ParkInfoScreen(Park p)
        {
            Console.Clear();
            Console.WriteLine(" *".PadRight(30, '*'));
            Console.WriteLine(" " + p.Name + " National Park");
            Console.WriteLine(" *".PadRight(30, '*'));
            Console.WriteLine(" Location:".PadRight(20) + p.Location);
            Console.WriteLine(" Established:".PadRight(20) + p.EstDate.ToShortDateString());
            Console.WriteLine(" Area:".PadRight(20) + String.Format("{0:n0}", p.Area) + " sq km");
            Console.WriteLine(" Annual Visitors:".PadRight(20) + String.Format("{0:n0}", p.NumVisitors));
            Console.WriteLine();
            Console.WriteLine(" " + p.Description);
            Console.WriteLine();
            Console.WriteLine(" *".PadRight(25, '*'));
            Console.WriteLine(" Please Select An Option:");
            Console.WriteLine(" *".PadRight(25, '*'));
            Console.WriteLine(" |1| View Campgrounds");
            Console.WriteLine(" |2| Search for Reservation");
            Console.WriteLine(" |3| See Upcoming Reservations (30 Days Out)");
            Console.WriteLine(" |4| Return to Previous Screen");

            string input = Console.ReadLine();

            if (input == "1")
            {
                bool running = true;
                while (running)
                {
                    running = PrintCampgrounds(p);
                }
                return true;
            }
            else if (input == "2")
            {
                bool running = true;
                while (running)
                {
                    running = ParkCampgrounds(p);
                }
                return true;
            }
            //BONUS
            else if (input == "3")
            {
                Console.Clear();
                ReservationSiteDAL allReservations = new ReservationSiteDAL(connectionString);
                bool running = true;
                while (running)
                {
                    DateTime arriveDate = DateTime.Today;
                    int pad = 15;
                    Console.WriteLine();
                    Console.WriteLine(" UPCOMING RESERVATIONS 30 DAYS OUT");
                    Console.WriteLine();
                    Console.WriteLine(" *".PadRight(110, '*'));
                    Console.WriteLine(" Res.#".PadRight(9) + "Reserved For".PadRight(35) + "Site#".PadRight(8) + "Campground".PadRight(17) + "Daily Fee".PadRight(10) + "From Date".PadRight(pad) + "To Date");
                    Console.WriteLine(" *".PadRight(110, '*'));
                    List<ReservationSite> listOfAvailableSites = allReservations.GetAllReservations(p.Id, arriveDate);
                    foreach (ReservationSite r in listOfAvailableSites)
                    {
                        Console.WriteLine(" " + r.ReservationID.ToString().PadRight(9) + r.ReservationName.ToString().PadRight(35) + r.SiteNumber.ToString().PadRight(8) + r.CampgroundName.PadRight(16) + "$" + r.DailyFee.ToString("F2").PadRight(10) + /*r.MaxOccupancy.ToString().PadRight(padding) + r.Accessible.PadRight(padding) + r.MaxRvLength.ToString().PadRight(padding) + r.Utilities.PadRight(padding) +*/ r.FromDate.ToShortDateString().PadRight(pad) + r.ToDate.ToShortDateString());
                    }
                    if (listOfAvailableSites.Count == 0)
                    {
                        Console.WriteLine("There are no reservations for the next 30 days.");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to the previous screen.");
                    Console.ReadKey();
                    return true;
                }
            }
            else if (input == "4")
            {
                return false;
            }
            else
            {
                Console.WriteLine(" Please enter a valid option. Press any key to continue.");
                Console.ReadKey();
                return true;
            }
            return true;
        }

        public bool PrintCampgrounds(Park p)
        {
            int pad = 20;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" " + p.Name.ToUpper() + " PARK CAMPGROUNDS");
            Console.WriteLine();
            Console.WriteLine(" *".PadRight(95, '*'));
            Console.WriteLine(" ".PadRight(8) + "Name".PadRight(35) + "Open".PadRight(pad) + "Close".PadRight(pad) + "Daily Fee");
            Console.WriteLine(" *".PadRight(95, '*'));
            CampgroundDAL campgroundDAL = new CampgroundDAL(connectionString);
            List<Campground> campgrounds = campgroundDAL.GetCampgrounds(p.Id);

            foreach (Campground cg in campgrounds)
            {
                Console.WriteLine(" |#" + cg.AlphaID.ToString() + "|".PadRight(4) + cg.Name.PadRight(35) + GetMonthString(cg.OpenFrom).PadRight(pad) + GetMonthString(cg.OpenTo).PadRight(pad) + "$" + cg.DailyFee.ToString("F2"));
            }
            Console.WriteLine();
            Console.WriteLine(" Press any key to return to the previous menu");
            Console.ReadKey();
            return false;
        }

        public bool ParkCampgrounds(Park p)
        {
            int pad = 20;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" " + p.Name.ToUpper() + " PARK CAMPGROUNDS");
            Console.WriteLine();
            Console.WriteLine(" *".PadRight(95, '*'));
            Console.WriteLine(" ".PadRight(8) + "Name".PadRight(35) + "Open".PadRight(pad) + "Close".PadRight(pad) + "Daily Fee");
            Console.WriteLine(" *".PadRight(95, '*'));
            CampgroundDAL campgroundDAL = new CampgroundDAL(connectionString);
            List<Campground> campgrounds = campgroundDAL.GetCampgrounds(p.Id);

            foreach (Campground cg in campgrounds)
            {
                Console.WriteLine(" |#" + cg.AlphaID.ToString() + "|".PadRight(4) + cg.Name.PadRight(35) + GetMonthString(cg.OpenFrom).PadRight(pad) + GetMonthString(cg.OpenTo).PadRight(pad) + "$" + cg.DailyFee.ToString("F2"));
            }

            ////BONUS
            //Console.WriteLine(" |#" + (campgrounds.Count + 1) + "|".PadRight(4) + $"***Choose this option to search across all campgrounds within {p.Name}***");

            int alphaID = 0;

            Console.WriteLine();
            Console.WriteLine(" Which campground (enter 0 to cancel)?");

            try
            {
                alphaID = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(" Please enter valid option. Press any key to return.");
                Console.ReadKey();
                return true;
            }

            bool campgroundIsInPark = false;

            foreach (Campground cg in campgrounds)
            {
                if (alphaID == cg.AlphaID)
                {
                    campgroundIsInPark = true;
                }
            }

            if (alphaID == 0)
            {
                return false;
            }

            else if (campgroundIsInPark == true)
            {
                int cgID = 0;
                decimal dailyFee = 0;

                foreach (Campground cg in campgrounds)
                {
                    if (cg.AlphaID == alphaID)
                    {
                        cgID = cg.Id;
                        dailyFee = cg.DailyFee;
                    }
                }

                bool running = true;

                while (running)
                {
                    DateTime arriveDate;
                    DateTime departDate;

                    Console.WriteLine(" What is the arrival date? mm/dd/yyyy");

                    try
                    {
                        arriveDate = Convert.ToDateTime(Console.ReadLine());
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("Please enter a valid option. Press any key to return.");
                        Console.ReadKey();
                        return true;
                    }

                    Console.WriteLine(" What is the departure date? mm/dd/yyyy");

                    try
                    {
                        departDate = Convert.ToDateTime(Console.ReadLine());
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(" Please enter a valid option. Press any key to return.");
                        Console.ReadKey();
                        return true;
                    }

                    if (departDate > arriveDate && (departDate - arriveDate).TotalDays > 0 && arriveDate > DateTime.Today)
                    {
                        running = AvailableForReservation(dailyFee, cgID, arriveDate, departDate);
                    }
                    else
                    {
                        Console.WriteLine(" Please enter a valid option. Press any key to continue.");
                        running = false;
                    }
                }

                Console.ReadKey();

                return true;
            }

            ////BONUS Optional Selection To Choose All Campgrounds Within Park:
            //else if (alphaID == (campgrounds.Count + 1))
            //{
            //    int parkID = p.Id;

            //    bool running = true;

            //    while (running)
            //    {
            //        DateTime arriveDate;
            //        DateTime departDate;

            //        Console.WriteLine(" What is the arrival date? mm/dd/yyyy");

            //        try
            //        {
            //            arriveDate = Convert.ToDateTime(Console.ReadLine());
            //        }

            //        catch (Exception e)
            //        {
            //            Console.WriteLine("Please enter a valid option. Press any key to return.");
            //            Console.ReadKey();
            //            return true;
            //        }

            //        Console.WriteLine(" What is the departure date? mm/dd/yyyy");

            //        try
            //        {
            //            departDate = Convert.ToDateTime(Console.ReadLine());
            //        }

            //        catch (Exception e)
            //        {
            //            Console.WriteLine(" Please enter a valid option. Press any key to return.");
            //            Console.ReadKey();
            //            return true;
            //        }

            //        if (departDate > arriveDate && (departDate - arriveDate).TotalDays > 0 && arriveDate > DateTime.Today)
            //        {
            //            running = ParkAvailableForReservation(parkID, arriveDate, departDate);
            //        }
            //        else
            //        {
            //            Console.WriteLine(" Please enter a valid option. Press any key to continue.");
            //            running = false;
            //        }
            //    }

            //    Console.ReadKey();

            //    return true;
            //}

            else
            {
                Console.WriteLine(" Please enter a valid option. Press any key to continue.");
                Console.ReadKey();
                return true;
            }

            Console.WriteLine(" Press any key to return to the previous menu");
            Console.ReadKey();
            return false;
        }

        public bool AvailableForReservation(decimal dailyFee, int cgID, DateTime arriveDate, DateTime departDate)
        {
            SiteDAL siteDAL = new SiteDAL(connectionString);

            List<Site> availableSites = siteDAL.GetAvailableSites(cgID, arriveDate, departDate);

            if (availableSites.Count > 0)
            {
                int pad = 20;
                Console.WriteLine(" Results Matching Your Search Criteria");
                Console.WriteLine();
                Console.WriteLine(" Site#.".PadRight(pad) + "Max Occup.".PadRight(pad) + "Accessible?".PadRight(pad) + "Max RV Length".PadRight(pad) + "Utility".PadRight(pad) + "Cost");
                Console.WriteLine(" *".PadRight(120, '*'));

                foreach (Site a in availableSites)
                {
                    decimal cost = dailyFee * (decimal)((departDate - arriveDate).TotalDays);
                    Console.WriteLine(" " + Convert.ToString(a.SiteNum).PadRight(pad) + Convert.ToString(a.MaxOccupancy).PadRight(pad) + a.Accessible.PadRight(pad) + a.MaxRVLength.PadRight(pad) + a.Utilities.PadRight(pad) + "$" + cost.ToString("F2"));
                }
            }

            else
            {
                Console.WriteLine(" There are no campsites available for the dates you have selected. Would you like to try different dates? Y/N");
                string input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }

            int siteNumSelection = 0;

            Console.WriteLine();
            Console.WriteLine(" Which site should be reserved (enter 0 to cancel)? __");

            try
            {
                siteNumSelection = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(" Please enter valid option. Press any key to return.");
                Console.ReadKey();
                return true;
            }

            bool siteExists = false;

            foreach (Site site in availableSites)
            {
                if (siteNumSelection == site.SiteNum)
                {
                    siteExists = true;
                }
            }

            if (siteNumSelection == 0)
            {
                return false;
            }
            else if (siteExists == true)
            {
                Console.WriteLine(" What name should the reservation be made under? __");
                string reservationName = Console.ReadLine();
                MakeReservation(siteNumSelection, reservationName, arriveDate, departDate);
                Console.WriteLine(" Press any key to continue.");
                Console.WriteLine();
                Console.ReadKey();
                return false;
            }
            else
            {
                Console.WriteLine(" Please enter a valid option. Press any key to return.");
                Console.ReadKey();
                return true;
            }

        }

        ////BONUS Parkwide Site Search
        //public bool ParkAvailableForReservation(int parkID, DateTime arriveDate, DateTime departDate)
        //{

        //    SiteDAL siteDAL = new SiteDAL(connectionString);

        //    CampgroundDAL campgroundDAL = new CampgroundDAL(connectionString);

        //    List<Campground> campgrounds = campgroundDAL.GetCampgrounds(parkID);

        //    List<Site> availableSites = new List<Site>();

        //    int pad = 15;
        //    Console.WriteLine();
        //    Console.WriteLine($"Available Sites Across All Campgrounds Within Selected Park.");
        //    Console.WriteLine();
        //    Console.WriteLine(" Campground".PadRight(35) + " Site#.".PadRight(10) + "Max Occup.".PadRight(pad) + "Accessible?".PadRight(pad) + "Max RV Length".PadRight(pad) + "Utility".PadRight(10) + "Cost");
        //    Console.WriteLine(" *".PadRight(107, '*'));

        //    foreach (Campground cg in campgrounds)
        //    {
        //        int cgID = cg.Id;
        //        decimal dailyFee = cg.DailyFee;

        //        List<Site> getAvailableSites = siteDAL.GetAvailableSites(cgID, arriveDate, departDate);

        //        foreach (Site a in getAvailableSites)
        //        {
        //            decimal cost = dailyFee * (decimal)((departDate - arriveDate).TotalDays);
        //            Console.WriteLine(" " + Convert.ToString(a.CampgroundName.PadRight(35) + Convert.ToString(a.SiteNum).PadRight(10) + Convert.ToString(a.MaxOccupancy).PadRight(pad) + a.Accessible.PadRight(pad) + a.MaxRVLength.PadRight(pad) + a.Utilities.PadRight(10) + "$" + cost.ToString("F2")));
        //            availableSites.Add(a);
        //        }
        //    }

        //    if (availableSites.Count == 0)
        //    {
        //        Console.WriteLine(" There are no campsites available for the dates you have selected. Would you like to try different dates? Y/N");
        //        string input = Console.ReadLine();
        //        if (input.ToLower() == "y")
        //        {
        //            return true;
        //        }
        //        else
        //        {

        //            return false;
        //        }
        //    }

        //    int siteNumSelection = 0;

        //    Console.WriteLine();
        //    Console.WriteLine(" Which site should be reserved (enter 0 to cancel)? __");

        //    try
        //    {
        //        siteNumSelection = Convert.ToInt32(Console.ReadLine());
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(" Please enter valid option. Press any key to return.");
        //        Console.ReadKey();
        //        return true;
        //    }

        //    bool siteExists = false;

        //    foreach (Site site in availableSites)
        //    {
        //        if (siteNumSelection == site.SiteNum)
        //        {
        //            siteExists = true;
        //        }
        //    }

        //    if (siteNumSelection == 0)
        //    {
        //        return false;
        //    }
        //    else if (siteExists == true)
        //    {
        //        Console.WriteLine(" What name should the reservation be made under? __");
        //        string reservationName = Console.ReadLine();
        //        MakeReservation(siteNumSelection, reservationName, arriveDate, departDate);
        //        Console.WriteLine(" Press any key to continue.");
        //        Console.WriteLine();
        //        Console.ReadKey();
        //        return false;
        //    }
        //    else
        //    {
        //        Console.WriteLine(" Please enter a valid option. Press any key to return.");
        //        Console.ReadKey();
        //        return true;
        //    }

        //}

        public void MakeReservation(int siteNumSelection, string reservationName, DateTime arriveDate, DateTime departDate)
        {
            ReservationDAL reservationDAL = new ReservationDAL(connectionString);
            int reservationID = reservationDAL.MakeReservation(siteNumSelection, reservationName, arriveDate, departDate);
            Console.WriteLine($" The reservation has been made and the confirmation id is {reservationID}");
        }

        public string GetMonthString(int month)
        {
            Dictionary<int, string> monthName = new Dictionary<int, string>() {
                {1, "January"},
                {2, "February" },
                {3, "March" },
                {4, "April" },
                {5, "May" },
                {6, "June" },
                {7, "July" },
                {8, "August" },
                {9, "September" },
                {10, "October" },
                {11, "November" },
                {12, "December" }
            };
            return monthName[month];
        }

    }

}

