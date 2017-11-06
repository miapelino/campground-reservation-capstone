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
    public class ReservationDAL
    {
        private const string getReservation = @"SELECT * FROM reservation WHERE site_id = @siteID;";
        private const string getReservationID = @"SELECT * FROM reservation WHERE site_id = @siteID;";
        private const string makeReservation = @"INSERT INTO reservation VALUES (@siteNumSelection, @reservationName, @arriveDate, @departDate, GETDATE()); SELECT CAST(SCOPE_IDENTITY() as int);";
        private string connectionString;

        public ReservationDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Reservation> GetReservation(int siteID)
        {
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(getReservation, connection);
                    cmd.Parameters.AddWithValue("@site_id", siteID);
                    SqlDataReader results = cmd.ExecuteReader();

                    while (results.Read())
                    {
                        Reservation reservation = new Reservation(Convert.ToInt32(results["reservation_id"]), Convert.ToInt32(results["site_id"]), Convert.ToString(results["name"]), Convert.ToDateTime(results["from_date"]), Convert.ToDateTime(results["to_date"]), Convert.ToDateTime(results["create_date"]));
                        reservations.Add(reservation);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw;
            }
            return reservations;
        }

        public int MakeReservation(int siteNumSelection, string reservationName, DateTime arriveDate, DateTime departDate)
        {
            int reservationID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(makeReservation, connection);
                    cmd.Parameters.AddWithValue("@siteNumSelection", siteNumSelection);
                    cmd.Parameters.AddWithValue("@reservationName", reservationName);
                    cmd.Parameters.AddWithValue("@arriveDate", arriveDate);
                    cmd.Parameters.AddWithValue("@departDate", departDate);
                    reservationID = (int)cmd.ExecuteScalar();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw;
            }
            return reservationID;
        }
    }
}
