using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ReservationSiteDAL
    {
        private const string getAllReservations = @"SELECT reservation.reservation_id, campground.name as cname, daily_fee, site_number, reservation.name as rname, max_occupancy, accessible, max_rv_length,utilities, from_date, to_date FROM campground 
                                                    JOIN site ON campground.campground_id = site.campground_id
                                                    JOIN reservation ON site.site_id = reservation.site_id
                                                    WHERE from_date > @arriveDate AND to_date < DATEADD(day, 30, @arriveDate) AND park_id = @park;";
        private string connectionString;

        public ReservationSiteDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ReservationSite> GetAllReservations(int parkID, DateTime arriveDate)
        {
            List<ReservationSite> next30DayReservation = new List<ReservationSite>();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(getAllReservations, connection);
                    cmd.Parameters.AddWithValue("@park", parkID);
                    cmd.Parameters.AddWithValue("@arriveDate", arriveDate);
                    SqlDataReader results = cmd.ExecuteReader();

                    while (results.Read())
                    {
                        ReservationSite availableSite = new ReservationSite(Convert.ToInt32(results["reservation_id"]), Convert.ToString(results["cname"]), Convert.ToString(results["rname"]), Convert.ToDecimal(results["daily_fee"]), Convert.ToInt32(results["site_number"]), Convert.ToInt32(results["max_occupancy"]), Convert.ToInt32(results["accessible"]), Convert.ToInt32(results["max_rv_length"]), Convert.ToInt32(results["utilities"]), Convert.ToDateTime(results["from_date"]), Convert.ToDateTime(results["to_date"]));
                        next30DayReservation.Add(availableSite);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw;
            }
            return next30DayReservation;
        }
    }
}
